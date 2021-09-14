using Microsoft.AspNetCore.Components;

namespace AdminBlazor.PomocneMetode
{
    public class BlazorRasporedKomponenta : LayoutComponentBase
    {
        private readonly OsvjeziBroadcast _osvjezi = OsvjeziBroadcast.Instanca;

        protected override void OnInitialized()
        {
            _osvjezi.OsvjeziZahtjevano += Osvjezi;
            base.OnInitialized();
        }

        public void CallRequestRefresh()
        {
            _osvjezi.OsvjeziZahtjevaniPoziv();
        }

        private void Osvjezi()
        {
            StateHasChanged();
        }
    }
}

