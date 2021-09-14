using Ardalis.Specification;
using eNakit.AplikacijskoJezgro.Entiteti;

namespace eNakit.AplikacijskoJezgro.Specifikacije
{
    public class KatalogFilterSpecifikacija : Specification<KatalogStavka>
    {
        public KatalogFilterSpecifikacija(int? brendId, int? tipId)
        {
            Query.Where(i => (!brendId.HasValue || i.KatalogBrendId == brendId) &&
                (!tipId.HasValue || i.KatalogTipId == tipId));
        }
    }
}