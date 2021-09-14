using System.Collections.Generic;
using System.Threading.Tasks;
using DijeljeniBlazor.Modeli;

namespace DijeljeniBlazor.Interfejsi
{
    public interface IKatalogBrendServis
    {
        Task<List<KatalogBrend>> Lista();
        Task<KatalogBrend> DohvatiPoIdu(int id);
    }
}
