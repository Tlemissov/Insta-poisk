using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace InstaPoisk.Localization
{
    public static class InstaPoiskLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(InstaPoiskConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(InstaPoiskLocalizationConfigurer).GetAssembly(),
                        "InstaPoisk.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
