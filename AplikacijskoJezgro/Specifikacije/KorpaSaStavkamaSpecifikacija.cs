using Ardalis.Specification;
using eNakit.AplikacijskoJezgro.Entiteti.KorpaAgregacija;

namespace eNakit.AplikacijskoJezgro.Specifikacije
{
    public sealed class KorpaSaStavkamaSpecifikacija : Specification<Korpa>
    {
        public KorpaSaStavkamaSpecifikacija(int korpaId)
        {
            Query
                .Where(b => b.Id == korpaId)
                .Include(b => b.Stavke);
        }

        public KorpaSaStavkamaSpecifikacija(string kupacId)
        {
            Query
                .Where(b => b.KupacId == kupacId)
                .Include(b => b.Stavke);
        }
    }
}
