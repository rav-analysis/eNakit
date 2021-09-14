using System.Threading.Tasks;

namespace eNakit.AplikacijskoJezgro.Interfejsi
{
    public interface ITokenTvrdnje
    {
        Task<string> DohvatiTokenAsinhrono(string korisnickoIme);
    }
}
