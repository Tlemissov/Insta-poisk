using Abp.Application.Navigation;
using Abp.Localization;
using InstaPoisk.Authorization;

namespace InstaPoisk.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class InstaPoiskNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "Admin",
                        icon: "home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.InstaAccount,
                        L("InstaAccount"),
                        url: "Admin/InstaAccounts",
                        icon: "people",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Admin/Tenants",
                        icon: "business",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Admin/Users",
                        icon: "people",
                        requiredPermissionName: PermissionNames.Pages_Users
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Admin/Roles",
                        icon: "local_offer",
                        requiredPermissionName: PermissionNames.Pages_Roles
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Reference,
                        L("Reference"),
                        url: "Admin/Roles",
                        icon: "book"
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Menu,
                            L("Menu"),
                            url: "Admin/Reference/Menu",
                            icon: "local_offer"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Section,
                            L("Section"),
                            url: "Admin/Reference/Section",
                            icon: "local_offer"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.SectionType,
                            L("SectionType"),
                            url: "Admin/Reference/SectionType",
                            icon: "local_offer"
                        )
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, InstaPoiskConsts.LocalizationSourceName);
        }
    }
}
