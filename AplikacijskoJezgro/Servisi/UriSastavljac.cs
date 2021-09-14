using eNakit.AplikacijskoJezgro.Interfejsi;

namespace eNakit.AplikacijskoJezgro.Servisi
{
    public class UriSastavljac : IUriSastavljac
    {
        private readonly PostavkeKataloga _postavkeKataloga;

        public UriSastavljac(PostavkeKataloga postavkeKataloga) => _postavkeKataloga = postavkeKataloga;

        public string SastaviUriSlike(string uriPredlozak)
        {
            return uriPredlozak.Replace("http://catalogbaseurltobereplaced", _postavkeKataloga.BazniUrlKataloga);
        }
    }
}
