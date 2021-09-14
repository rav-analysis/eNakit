using Ardalis.Specification;
using eNakit.AplikacijskoJezgro.Entiteti;

namespace eNakit.AplikacijskoJezgro.Specifikacije
{
    public class KatalogFilterStranicaSpecifikacija : Specification<KatalogStavka>
    {
        public KatalogFilterStranicaSpecifikacija(int preskoci, int uzmi, int? brendId, int? tipId)
            : base()
        {
            Query
                .Where(i => (!brendId.HasValue || i.KatalogBrendId == brendId) &&
                (!tipId.HasValue || i.KatalogTipId == tipId))
                .Paginate(preskoci, uzmi);
        }
    }
}
