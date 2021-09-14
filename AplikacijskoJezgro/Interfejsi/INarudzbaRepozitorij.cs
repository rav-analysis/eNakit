using eNakit.AplikacijskoJezgro.Entiteti.NarudzbaAgregacija;
using System.Threading.Tasks;

namespace eNakit.AplikacijskoJezgro.Interfejsi
{

    public interface INarudzbaRepozitorij : IAsinhroniRepozitorij<Narudzba>
    {
        Task<Narudzba> DohvatiPoIduSaStavkamaAsinhrono(int id);
    }
}
