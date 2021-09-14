using System.Collections.Generic;
using System.Threading.Tasks;
using DijeljeniBlazor.Modeli;

namespace DijeljeniBlazor.Interfejsi
{
    public interface IKatalogStavkaServis
    {
        Task<KatalogStavka> Kreiraj(KreirajKatalogStavkuZahtjev katalogStavka);
        Task<KatalogStavka> Uredi(KatalogStavka katalogStavka);
        Task<string> Obrisi(int id);
        Task<KatalogStavka> DohvatiPoIdu(int id);
        Task<List<KatalogStavka>> ListaStranice(int velicinaStranice);
        Task<List<KatalogStavka>> Lista();
    }
}
