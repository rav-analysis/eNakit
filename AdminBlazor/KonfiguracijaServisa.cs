using AdminBlazor.Servisi;
using DijeljeniBlazor.Interfejsi;
using Microsoft.Extensions.DependencyInjection;

namespace AdminBlazor
{
    public static class KonfiguracijaServisa
    {
        public static IServiceCollection DodajBlazorServise(this IServiceCollection servisi)
        {
            servisi.AddScoped<IKatalogBrendServis, KesiraniKatalogBrendServisDekorator>();
            servisi.AddScoped<KatalogBrendServis>();
            servisi.AddScoped<IKatalogTipServis, KesiraniKatalogTipServisDekorator>();
            servisi.AddScoped<KatalogTipServis>();
            servisi.AddScoped<IKatalogStavkaServis, KesiraniKatalogStavkaServisDekorator>();
            servisi.AddScoped<KatalogStavkaServis>();

            return servisi;
        }
    }
}
