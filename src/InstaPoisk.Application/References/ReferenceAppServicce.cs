using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.UI;
using InstaPoisk.Common;
using InstaPoisk.References.Dto;

namespace InstaPoisk.References
{
    public class ReferenceAppService : InstaPoiskAppServiceBase, IReferenceAppService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<SubCategory> _subCategoryRepository;
        private readonly IRepository<SubCategoryType> _typeRepository;

        public ReferenceAppService(IRepository<Category> categoryRepository,
            IRepository<SubCategory> subCategoryRepository, IRepository<SubCategoryType> typeRepository)
        {
            _categoryRepository = categoryRepository;
            _subCategoryRepository = subCategoryRepository;
            _typeRepository = typeRepository;
        }

        public async Task<List<ReferenceListDto>> GetForTable(ReferenceEnum type)
        {
            switch (type)
            {
                case ReferenceEnum.Category:
                    var categories = await _categoryRepository.GetAllListAsync();
                    var categoryModel = new List<ReferenceListDto>();
                    foreach (var category in categories)
                    {
                        categoryModel.Add(new ReferenceListDto(category.Id, category.Name, type, null, ObjectMapper.Map<List<EntityNameDto>>(category.SubCategories)));
                    }
                    return categoryModel;
                case ReferenceEnum.SubCategory:
                    var subCategories = await _subCategoryRepository.GetAllListAsync();
                    var subCategoryModel = new List<ReferenceListDto>();
                    foreach (var category in subCategories)
                    {
                        var subList = new List<EntityNameDto>();
                        foreach (var item in category.SubCategoryToTypes)
                        {
                            var model = new EntityNameDto {Id = item.TypeId, Name = item.Type?.Name};
                            subList.Add(model);
                        }
                        subCategoryModel.Add(new ReferenceListDto(category.Id, category.Name, type, category.Category?.Name, subList));
                    }
                    return subCategoryModel;
                case ReferenceEnum.SubCategoryType:
                    var categoryTypes = await _typeRepository.GetAllListAsync();
                    var categoryTypeModel = new List<ReferenceListDto>();
                    foreach (var category in categoryTypes)
                    {
                        var subList = new List<EntityNameDto>();
                        foreach (var item in category.SubCategoryToTypes)
                        {
                            var model = new EntityNameDto { Id = item.SubCategorId, Name = item.SubCategory?.Name };
                            subList.Add(model);
                        }
                        categoryTypeModel.Add(new ReferenceListDto(category.Id, category.Name, type, null, subList));
                    }
                    return categoryTypeModel;
                default:
                    throw new UserFriendlyException("Указан не правильный тип!");
            }
        }

        public async Task<List<EntityNameDto>> GetList(ReferenceEnum type)
        {
            switch (type)
            {
                case ReferenceEnum.Category:
                    return ObjectMapper.Map<List<EntityNameDto>>(await _categoryRepository.GetAllListAsync());
                case ReferenceEnum.SubCategory:
                    return ObjectMapper.Map<List<EntityNameDto>>(await _subCategoryRepository.GetAllListAsync());
                case ReferenceEnum.SubCategoryType:
                    return ObjectMapper.Map<List<EntityNameDto>>(await _typeRepository.GetAllListAsync());
                default:
                    throw new UserFriendlyException("Указан не правильный тип!");
            }
        }

        public async Task<ReferenceDto> Get(int id, ReferenceEnum type)
        {
            switch (type)
            {
                case ReferenceEnum.Category:
                    return ObjectMapper.Map<ReferenceDto>(await _categoryRepository.GetAsync(id));
                case ReferenceEnum.SubCategory:
                    var subCategory = await _subCategoryRepository.GetAsync(id);
                    var subCategoryModel = ObjectMapper.Map<ReferenceDto>(subCategory);
                    subCategoryModel.CategoryId = subCategory.CategoryId;
                    foreach (var item in subCategory.SubCategoryToTypes)
                    {   
                        subCategoryModel.List.Add(item.TypeId);
                    }
                    return subCategoryModel;
                case ReferenceEnum.SubCategoryType:
                    var categoryType = await _typeRepository.GetAsync(id);
                    var categoryTypeModel = ObjectMapper.Map<ReferenceDto>(categoryType);
                    foreach (var item in categoryType.SubCategoryToTypes)
                    {
                        categoryTypeModel.List.Add(item.SubCategorId);
                    }
                    return categoryTypeModel;
                default:
                    throw new UserFriendlyException("Указан не правильный тип!");
            }
        }

        public async Task Create(ReferenceDto input)
        {
            switch (input.Type)
            {
                case ReferenceEnum.Category:
                    await _categoryRepository.InsertAsync(new Category {Name = input.Name});
                    break;
                case ReferenceEnum.SubCategory:
                    var newSubCategoryId = await _subCategoryRepository.InsertAndGetIdAsync(new SubCategory{Name = input.Name, CategoryId = (int)input.CategoryId });
                    await SetSubItems(new SubItemsDto(newSubCategoryId, ReferenceEnum.SubCategory, input.List));
                    break;
                case ReferenceEnum.SubCategoryType:
                    var newTypeId = await _typeRepository.InsertAndGetIdAsync(new SubCategoryType {Name = input.Name});
                    await SetSubItems(new SubItemsDto(newTypeId, ReferenceEnum.SubCategoryType, input.List));
                    break;
                default:
                    throw new UserFriendlyException("Указан не правильный тип!");
            }
        }

        public async Task Delete(int id, ReferenceEnum type)
        {
            switch (type)
            {
                case ReferenceEnum.Category:
                    await _categoryRepository.DeleteAsync(id);
                    break;
                case ReferenceEnum.SubCategory:
                    await _subCategoryRepository.DeleteAsync(id);
                    break;
                case ReferenceEnum.SubCategoryType:
                    await _typeRepository.DeleteAsync(id);
                    break;
                default:
                    throw new UserFriendlyException("Указан не правильный тип!");
            }
        }

        public async Task Update(ReferenceDto input)
        {
            switch (input.Type)
            {
                case ReferenceEnum.Category:
                    var category = await _categoryRepository.GetAsync(input.Id);
                    category.Name = input.Name;
                    break;
                case ReferenceEnum.SubCategory:
                    var subCategory = await _subCategoryRepository.GetAsync(input.Id);
                    subCategory.Name = input.Name;
                    subCategory.CategoryId = (int)input.CategoryId;
                    subCategory.SubCategoryToTypes.Clear();
                    await SetSubItems(new SubItemsDto(input.Id, ReferenceEnum.SubCategory, input.List));
                    break;
                case ReferenceEnum.SubCategoryType:
                    var categoryType = await _typeRepository.GetAsync(input.Id);
                    categoryType.Name = input.Name;
                    categoryType.SubCategoryToTypes.Clear();
                    await SetSubItems(new SubItemsDto(input.Id, ReferenceEnum.SubCategoryType, input.List));
                    break;
                default:
                    throw new UserFriendlyException("Указан не правильный тип!");
            }
        }

        public async Task<List<MenuCategoryDto>> GetCategoryForMenu()
        {
            var categories = await _categoryRepository.GetAllListAsync();
            return ObjectMapper.Map<List<MenuCategoryDto>>(categories);
        }

        private async Task SetSubItems(SubItemsDto input)
        {
            switch (input.Type)
            {
                case ReferenceEnum.SubCategory:
                    var subCategory = await _subCategoryRepository.GetAsync(input.Id);
                    var typeList = new List<SubCategoryToType>();
                    foreach (var id in input.List)
                    {
                        typeList.Add(new SubCategoryToType{SubCategorId = subCategory.Id, TypeId = id});
                    }
                    subCategory.SubCategoryToTypes = typeList;
                    break;
                case ReferenceEnum.SubCategoryType:
                    var categoryType = await _typeRepository.GetAsync(input.Id);
                    var categoryList = new List<SubCategoryToType>();
                    foreach (var id in input.List)
                    {
                        categoryList.Add(new SubCategoryToType { SubCategorId = id, TypeId = categoryType.Id });
                    }
                    categoryType.SubCategoryToTypes = categoryList;
                    break;
                default:
                    throw new UserFriendlyException("Указан не правильный тип!");
            }
        }
    }
}
