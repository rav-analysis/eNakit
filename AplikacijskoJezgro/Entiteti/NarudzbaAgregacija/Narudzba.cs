using Ardalis.GuardClauses;
using eNakit.AplikacijskoJezgro.Interfejsi;
using System;
using System.Collections.Generic;

namespace eNakit.AplikacijskoJezgro.Entiteti.NarudzbaAgregacija
{
    public class Narudzba : BazniEntitet, IAgregacijaKorijen
    {
        private Narudzba()
        {
            
        }

        public Narudzba(string kupacId, Adresa dostavaNaAdresu, List<NarudzbaStavka> stavke)
        {
            Guard.Against.NullOrEmpty(kupacId, nameof(kupacId));
            Guard.Against.Null(dostavaNaAdresu, nameof(dostavaNaAdresu));
            Guard.Against.Null(stavke, nameof(stavke));

            KupacId = kupacId;
            DostavaNaAdresu = dostavaNaAdresu;
            _stavkeNarudzbe = stavke;
        }

        public string KupacId { get; private set; }
        public DateTimeOffset DatumNarudzbe { get; private set; } = DateTimeOffset.Now;
        public Adresa DostavaNaAdresu { get; private set; }

        private readonly List<NarudzbaStavka> _stavkeNarudzbe = new List<NarudzbaStavka>();

        public IReadOnlyCollection<NarudzbaStavka> StavkeNarudzbe => _stavkeNarudzbe.AsReadOnly();

        public decimal Ukupno()
        {
            var ukupno = 0m;
            foreach (var stavka in _stavkeNarudzbe)
            {
                ukupno += stavka.JedinicnaCijena * stavka.Jedinice;
            }
            return ukupno;
        }
    }
}

