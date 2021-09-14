using Ardalis.GuardClauses;
using eNakit.AplikacijskoJezgro.Interfejsi;
using System;

namespace eNakit.AplikacijskoJezgro.Entiteti
{
    public class KatalogStavka : BazniEntitet, IAgregacijaKorijen
    {
        public string Naziv { get; private set; }
        public string Opis { get; private set; }
        public decimal Cijena { get; private set; }
        public string SlikaUri { get; private set; }
        public int KatalogTipId { get; private set; }
        public KatalogTip KatalogTip { get; private set; }
        public int KatalogBrendId { get; private set; }
        public KatalogBrend KatalogBrend { get; private set; }

        public KatalogStavka(int katalogTipId,
            int katalogBrendId,
            string opis,
            string naziv,
            decimal cijena,
            string slikaUri)
        {
            KatalogTipId = katalogTipId;
            KatalogBrendId = katalogBrendId;
            Opis = opis;
            Naziv = naziv;
            Cijena = cijena;
            SlikaUri = slikaUri;
        }

        public void AzurirajDetalje(string naziv, string opis, decimal cijena)
        {
            Guard.Against.NullOrEmpty(naziv, nameof(naziv));
            Guard.Against.NullOrEmpty(opis, nameof(opis));
            Guard.Against.NegativeOrZero(cijena, nameof(cijena));

            Naziv = naziv;
            Opis = opis;
            Cijena = cijena;
        }

        public void AzurirajBrend(int katalogBrendId)
        {
            Guard.Against.Zero(katalogBrendId, nameof(katalogBrendId));
            KatalogBrendId = katalogBrendId;
        }

        public void AzurirajTip(int katalogTipId)
        {
            Guard.Against.Zero(katalogTipId, nameof(katalogTipId));
            KatalogTipId = katalogTipId;
        }

        public void AzurirajSlikaUri(string nazivSlike)
        {
            if (string.IsNullOrEmpty(nazivSlike))
            {
                SlikaUri = string.Empty;
                return;
            }
            SlikaUri = $"slike\\proizvodi\\{nazivSlike}?{new DateTime().Ticks}";
        }
    }
}
