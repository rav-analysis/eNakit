using Ardalis.Specification;
using eNakit.AplikacijskoJezgro.Entiteti;
using System;
using System.Linq;

namespace eNakit.AplikacijskoJezgro.Specifikacije
{
    public class KatalogStavkeSpecifikacija : Specification<KatalogStavka>
    {
        public KatalogStavkeSpecifikacija(params int[] ids)
        {
            Query.Where(c => ids.Contains(c.Id));
        }
    }
}
