using AutoMapper;
using InstaPoisk.Common;
using InstaPoisk.References;
using InstaPoisk.References.Dto;

namespace InstaPoisk
{
    internal static class CustomDtoMapper
    {
        private static volatile bool _mappedBefore;
        private static readonly object SyncObj = new object();

        public static void CreateMappings(IMapperConfigurationExpression mapper)
        {
            lock (SyncObj)
            {
                if (_mappedBefore)
                {
                    return;
                }

                CreateMappingsInternal(mapper);

                _mappedBefore = true;
            }
        }

        private static void CreateMappingsInternal(IMapperConfigurationExpression mapper)
        {
            // References
            mapper.CreateMap<SubCategory, EntityNameDto>();

            mapper.CreateMap<ReferenceDto, Category>();

            mapper.CreateMap<Category, ReferenceDto>();

            mapper.CreateMap<ReferenceDto, SubCategory>();

            mapper.CreateMap<SubCategory, ReferenceDto>();

            mapper.CreateMap<ReferenceDto, SubCategoryType>();

            mapper.CreateMap<SubCategoryType, ReferenceDto>();
        }
    }
}
