using eNakit.AplikacijskoJezgro.Entiteti.KorpaAgregacija;
using eNakit.AplikacijskoJezgro.Izuzeci;
using System.Collections.Generic;
using System.Linq;

namespace Ardalis.GuardClauses
{
    public static class CuvarKorpe
    {
        public static void NullKorpa(this IGuardClause cuvarKlauzula, int korpaId, Korpa korpa)
        {
            if (korpa == null)
                throw new KorpaNijePronadjenaIzuzetak(korpaId);
        }

        public static void PraznaKorpaTokomFinalizacije(this IGuardClause guardClause, IReadOnlyCollection<KorpaStavka> stavkeKorpe)
        {
            if (!stavkeKorpe.Any())
                throw new PraznaKorpaTokomFinalizacijeIzuzetak();
        }
    }
}
