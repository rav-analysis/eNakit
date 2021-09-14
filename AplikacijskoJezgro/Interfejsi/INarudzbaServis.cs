using eNakit.AplikacijskoJezgro.Entiteti.NarudzbaAgregacija;
using System.Threading.Tasks;

namespace eNakit.AplikacijskoJezgro.Interfejsi
{
    public interface INarudzbaServis
    {
        Task KreirajNarudzbuAsinhrono(int korpaId, Adresa adresaDostave);
    }
}
