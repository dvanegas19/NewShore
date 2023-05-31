using NewShore.Flight.UseCasesPortsExternal.Flight;
using NewShore.Fligth.Presenters;

namespace NewShore.Flight.ExternalAdapters
{
    public class NewShoreAPI
    {
        private readonly HttpClient _httpClient;
        readonly IGetFligthExternalInputPort GetFligthExternalInputPort;
        readonly IGetFligthExternalOutputPort GetFligthExternalOutputPort;

        public NewShoreAPI(IGetFligthExternalInputPort getFligthExternalInputPort, IGetFligthExternalOutputPort getFligthExternalOutputPort)
        {

            GetFligthExternalInputPort = getFligthExternalInputPort;
            GetFligthExternalOutputPort = getFligthExternalOutputPort;
            _httpClient = new HttpClient();
        }

        public async Task<object> GetDataFromNewShoreApiOnly()
        {
            var response = await _httpClient.GetAsync("https://recruiting-api.newshore.es/api/flights/0");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var Presenter = GetFligthExternalOutputPort as FlightExternalPresenter;

            return Presenter.content;
        }

        public async Task<object> GetDataFromNewShoreApiMultiple()
        {
            var response = await _httpClient.GetAsync("https://recruiting-api.newshore.es/api/flights/0");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var Presenter = GetFligthExternalOutputPort as FlightExternalPresenter;

            return Presenter.content;
        }

        public async Task<object> GetDataFromNewShoreApiMultipleAndReturn()
        {
            var response = await _httpClient.GetAsync("https://recruiting-api.newshore.es/api/flights/0");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var Presenter = GetFligthExternalOutputPort as FlightExternalPresenter;

            return Presenter.content;
        }
    }
}
