using System;

namespace AdminBlazor.PomocneMetode
{
    internal sealed class OsvjeziBroadcast
    {
        private static readonly Lazy<OsvjeziBroadcast>
            Lazy =
                new Lazy<OsvjeziBroadcast>
                    (() => new OsvjeziBroadcast());

        public static OsvjeziBroadcast Instanca => Lazy.Value;

        private OsvjeziBroadcast()
        {
        }

        public event Action OsvjeziZahtjevano;
        public void OsvjeziZahtjevaniPoziv()
        {
            OsvjeziZahtjevano?.Invoke();
        }
    }
}

