using Microsoft.AspNetCore.Components;

namespace AdminBlazor.Pomocno
{
    public class BlazorRasporedKomponenta : LayoutComponentBase
    {
        private readonly OsvjeziBroadcast _osvjezi = OsvjeziBroadcast.Instanca;

        protected override void OnInitialized()
        {
            _osvjezi.OsvjeziTrazeno += Osvjezi;
            base.OnInitialized();
        }

        public void PozivZahtjevOsvjezi()
        {
            _osvjezi.PozivZahtjevOsvjezi();
        }

        private void Osvjezi()
        {
            StateHasChanged();
        }
    }
}
