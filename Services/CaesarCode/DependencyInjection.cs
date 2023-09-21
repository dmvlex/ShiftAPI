using Microsoft.Extensions.DependencyInjection;

namespace ShiftAPI.Services.CaesarCode
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCaesar(this IServiceCollection services, CaesarOptions options)
        {
            services.AddSingleton<IEncoder>(x => new CaesarCodeService(options));

            return services;
        }
    }
}
