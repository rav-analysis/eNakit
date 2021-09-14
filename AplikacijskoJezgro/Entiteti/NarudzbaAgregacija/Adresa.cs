namespace eNakit.AplikacijskoJezgro.Entiteti.NarudzbaAgregacija
{
    public class Adresa 
    {
        public string Ulica { get; private set; }

        public string Grad { get; private set; }

        public string Kanton { get; private set; }

        public string Drzava { get; private set; }

        public string ZipKod { get; private set; }

        private Adresa() { }

        public Adresa(string ulica, string grad, string kanton, string drzava, string zipkod)
        {
            Ulica = ulica;
            Grad = grad;
            Kanton = kanton;
            Drzava = drzava;
            ZipKod = zipkod;
        }
    }
}
