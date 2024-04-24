using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace GymManager.UI.Extensions;

public static class IServiceCollectionExtension
{
    public static void DeficeViewLocation(this IServiceCollection services, IConfiguration configuration)
    {
        var templateKey = configuration.GetSection("TemplateKey").Value;
        services.Configure<RazorViewEngineOptions>(x =>
        {
            x.ViewLocationExpanders.Clear();
            if (templateKey != "Basic")
            {
                x.ViewLocationFormats.Add("/Views/" + templateKey + "/{1}/{0}" + RazorViewEngine.ViewExtension);
                x.ViewLocationFormats.Add("/Views/" + templateKey + "/Shared/{0}" + RazorViewEngine.ViewExtension);
            }
            x.ViewLocationFormats.Add("/Views/Basic/{1}/{0}" + RazorViewEngine.ViewExtension);
            x.ViewLocationFormats.Add("/Views/Basic/Shared/{0}" + RazorViewEngine.ViewExtension);
        });

    }

    public static void AddCulture(this IServiceCollection services)
    {
        var supportCultures = new List<CultureInfo>
        {
            new CultureInfo("pl"),
            new CultureInfo("en")
        };

        CultureInfo.DefaultThreadCurrentCulture = supportCultures[0];
        CultureInfo.DefaultThreadCurrentUICulture = supportCultures[0];

        services.Configure<RequestLocalizationOptions>(opt =>
        {
            opt.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(supportCultures[0]);
            opt.SupportedCultures = supportCultures;
            opt.SupportedUICultures = supportCultures;
        });
    }
}