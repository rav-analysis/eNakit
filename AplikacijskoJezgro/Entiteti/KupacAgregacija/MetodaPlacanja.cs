namespace eNakit.AplikacijskoJezgro.Entiteti.KupacAgregacija
{
    public class MetodaPlacanja : BazniEntitet
    {
        public string Alias { get; private set; }
        public string KarticaId { get; private set; } 
        public string Posljednja4 { get; private set; }
    }
}
