using Ardalis.GuardClauses;
using eNakit.AplikacijskoJezgro.Interfejsi;
using System.Collections.Generic;

namespace eNakit.AplikacijskoJezgro.Entiteti.KupacAgregacija
{
    public class Kupac : BazniEntitet, IAgregacijaKorijen
    {
        public string IdentitetGuid { get; private set; }

        private List<MetodaPlacanja> _metodePlacanja = new List<MetodaPlacanja>();

        public IEnumerable<MetodaPlacanja> MetodePlacanja => _metodePlacanja.AsReadOnly();

        private Kupac()
        {
            
        }

        public Kupac(string identitet) : this()
        {
            Guard.Against.NullOrEmpty(identitet, nameof(identitet));
            IdentitetGuid = identitet;
        }
    }
}
