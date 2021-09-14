namespace eNakit.AplikacijskoJezgro.Entiteti.NarudzbaAgregacija
{
    public class NarudzbaStavka : BazniEntitet
    {
        public NarucenaKatalogStavka NarucenaStavka { get; private set; }
        public decimal JedinicnaCijena { get; private set; }
        public int Jedinice { get; private set; }

        private NarudzbaStavka()
        {
            
        }

        public NarudzbaStavka(NarucenaKatalogStavka narucenaStavka, decimal jedinicnaCijena, int jedinice)
        {
            NarucenaStavka = narucenaStavka;
            JedinicnaCijena = jedinicnaCijena;
            Jedinice = jedinice;
        }
    }
}
