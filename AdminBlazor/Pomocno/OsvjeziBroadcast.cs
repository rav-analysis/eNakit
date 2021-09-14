using System;

namespace AdminBlazor.Pomocno
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

        public event Action OsvjeziTrazeno;
        public void PozivZahtjevOsvjezi()
        {
            OsvjeziTrazeno?.Invoke();
        }
    }
}
