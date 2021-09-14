using System.Threading;
using System.Threading.Tasks;

namespace eNakit.AplikacijskoJezgro.Interfejsi
{
    public interface IFileSistem
    {
        Task<bool> SnimiSliku(string nazivSlike, string slikaBase64, CancellationToken prekidniToken);
    }
}
