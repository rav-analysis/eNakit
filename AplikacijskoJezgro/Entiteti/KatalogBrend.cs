using eNakit.AplikacijskoJezgro.Interfejsi;

namespace eNakit.AplikacijskoJezgro.Entiteti
{
    public class KatalogBrend : BazniEntitet, IAgregacijaKorijen
    {
        public string Brend { get; private set; }
        public KatalogBrend(string brend)
        {
            Brend=brend;
        }
    }
}
