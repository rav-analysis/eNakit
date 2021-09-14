using System.Threading.Tasks;

namespace eNakit.AplikacijskoJezgro.Interfejsi
{

    public interface ISlanjeMaila
    {
        Task SlanjeMailaAsinhrono(string email, string predmet, string poruka);
    }
}
