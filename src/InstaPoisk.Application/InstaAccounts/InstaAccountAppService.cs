using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using InstaPoisk.InstaAccounts.Dto;
using Microsoft.EntityFrameworkCore;


namespace InstaPoisk.InstaAccounts
{
    public class InstaAccountAppService : InstaPoiskAppServiceBase, IInstaAccountAppService
    {
        private readonly IRepository<InstaAccount> _accountRepository;

        public InstaAccountAppService(IRepository<InstaAccount> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<List<InstaAccountListDto>> GetForTable()
        {
            var accounts = await _accountRepository.GetAllListAsync();
            var modelList = new List<InstaAccountListDto>();
            foreach (var account in accounts)
            {
                var model = ObjectMapper.Map<InstaAccountListDto>(account);
                foreach (var category in account.SubCategories)
                {
                    model.SubItems.Add(category.Category.Name);
                }
                modelList.Add(model);
            }
            return modelList;
        }

        public async Task<List<InstaAccountShortListDto>> GetList(InstaAccountInput input)
        {
            var query = _accountRepository.GetAll().Where(x => x.IsPublish)
                .WhereIf(input.CategoryId != null, x => x.CategoryId == input.CategoryId)
                .WhereIf(input.SubCategoryId != null,
                    x => x.SubCategories.FirstOrDefault(c => c.CategoryId == input.SubCategoryId) != null);
                //.WhereIf(input.Status != 0, x => x.Status == input.Status)
                //.WhereIf(string.IsNullOrEmpty(input.Name), x => x.Name.ToLower().Contains(input.Name.ToLower()) ||
                //                                                x.UserName.ToLower().Contains(input.Name) ||
                //                                                x.Link.ToLower().Contains(input.Name.ToLower()));

            return ObjectMapper.Map<List<InstaAccountShortListDto>>(await query.OrderByDescending(x => x.LinkOpened).ToListAsync());
        }

        public async Task<InstaAccountDto> Get(int id)
        {
            var account = await _accountRepository.GetAsync(id);
            var model = ObjectMapper.Map<InstaAccountDto>(account);
            foreach (var category in account.SubCategories)
            {
                model.SubItems.Add(category.CategoryId);
            }

            return model;
        }

        public async Task Create(InstaAccountDto input)
        {
            var newAccount = ObjectMapper.Map<InstaAccount>(input);
            var id = await _accountRepository.InsertAndGetIdAsync(newAccount);
            await SetSubItems(id, input.SubItems);
        }

        public async Task Delete(int id)
        {
            await _accountRepository.DeleteAsync(id);
        }

        public async Task Update(InstaAccountDto input)
        {
            var account = await _accountRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, account);
            await SetSubItems(input.Id, input.SubItems);
        }

        private async Task SetSubItems(int id, List<int> list)
        {
            var account = await _accountRepository.GetAsync(id);
            account.SubCategories.Clear();
            var subCategories = new List<InstaAccountToSubCategory>();
            foreach (var itemId in list)
            {
                subCategories.Add(new InstaAccountToSubCategory{AccountId = account.Id, CategoryId = itemId});
            }

            account.SubCategories = subCategories;
        }
    }
}
