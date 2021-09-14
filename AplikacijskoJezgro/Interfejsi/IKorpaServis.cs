using System.Collections.Generic;
using System.Threading.Tasks;

namespace eNakit.AplikacijskoJezgro.Interfejsi
{
    public interface IKorpaServis
    {
        Task PrebaciKorpu(string anonimniId, string korisnickoIme);
        Task DodajStavkuKorpa(int korpaId, int katalogStavkaId, decimal cijena, int kolicina = 1);
        Task PostaviKolicine(int korpaId, Dictionary<string, int> kolicine);
        Task IzbrisiKorpuAsinhrono(int korpaId);
    }
}
