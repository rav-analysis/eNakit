using DijeljeniBlazor.Modeli;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DijeljeniBlazor.Interfejsi
{
    public interface IKatalogTipServis
    {
        Task<List<KatalogTip>> Lista();
        Task<KatalogTip> DohvatiPoIdu(int id);
    }
}

