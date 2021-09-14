using eNakit.AplikacijskoJezgro.Interfejsi;

namespace eNakit.AplikacijskoJezgro.Entiteti
{
    public class KatalogTip : BazniEntitet, IAgregacijaKorijen
    {
        public string Tip { get; private set; }
        public KatalogTip(string tip)
        {
            Tip = tip;
        }
    }
}
