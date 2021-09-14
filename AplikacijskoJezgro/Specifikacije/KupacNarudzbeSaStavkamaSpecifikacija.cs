using Ardalis.Specification;
using eNakit.AplikacijskoJezgro.Entiteti.NarudzbaAgregacija;

namespace eNakit.AplikacijskoJezgro.Specifikacije
{
    public class KupacNarudzbeSaStavkamaSpecifikacija : Specification<Narudzba>
    {
        public KupacNarudzbeSaStavkamaSpecifikacija(string kupacId)
        {
            Query.Where(o => o.KupacId == kupacId)
                .Include(o => o.StavkeNarudzbe)
                    .ThenInclude(i => i.NarucenaStavka);
        }
    }
}
