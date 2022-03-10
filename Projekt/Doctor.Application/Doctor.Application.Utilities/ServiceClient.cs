namespace Doctor.Application.Model
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using System.Net.Http;
    using System.Text.Json;

    using System.Text;

    public class ServiceClient
    {
        private static readonly HttpClient httpClient = new HttpClient();

        private readonly string serviceHost;
        private readonly ushort servicePort;

        public ServiceClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !String.IsNullOrEmpty(serviceHost) && servicePort > 0);

            this.serviceHost = serviceHost;
            this.servicePort = (ushort)servicePort;
        }

        public R CallWebService<R>(HttpMethod httpMethod, string webServiceUri)
        {
            Task<string> webServiceCall = this.CallWebService(httpMethod, webServiceUri);

            webServiceCall.Wait();

            string jsonResponseContent = webServiceCall.Result;

            R result = this.ConvertJson<R>(jsonResponseContent);

            return result;
        }

        public void CallWebService(HttpMethod httpMethod, string webServiceUri, string jsonString)
        {
            Task<string> webServiceCall = this.CallWebServicePost(httpMethod, webServiceUri, jsonString);

            webServiceCall.Wait();

            string jsonResponseContent = webServiceCall.Result;

        }

        public async Task<R> CallWebServiceAsync<R>(HttpMethod httpMethod, string webServiceUri)
        {
            string jsonResponseContent = await this.CallWebService(httpMethod, webServiceUri);

            R result = this.ConvertJson<R>(jsonResponseContent);

            return result;
        }

        public async Task<string> CallWebService(HttpMethod httpMethod, string callUri)
        {
            string httpUri = String.Format("http://{0}:{1}/{2}", this.serviceHost, this.servicePort, callUri);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, httpUri);

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            return httpResponseContent;
        }

        public async Task<string> CallWebServicePost(HttpMethod httpMethod, string callUri, string jsonString)
        {
            string httpUri = String.Format("http://{0}:{1}/{2}", this.serviceHost, this.servicePort, callUri);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, httpUri);

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            httpRequestMessage.Content = content;

            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            return httpResponseContent;
        }

        private T ConvertJson<T>(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            return JsonSerializer.Deserialize<T>(json,options);
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            string url = $"http://{this.serviceHost}:{this.servicePort}/delete-appointment?idAppointment={id}";

            var request = new HttpRequestMessage(HttpMethod.Delete,
                url);
            request.Headers.Add("Accept", "application/json");

            var response = await httpClient.SendAsync(request);

            await response.Content.ReadAsStreamAsync();
        }

        public async Task DeletePrescriptionAsync(int id)
        {
            string url = $"http://{this.serviceHost}:{this.servicePort}/delete-prescription?idPrescription={id}";

            var request = new HttpRequestMessage(HttpMethod.Delete,
                url);
            request.Headers.Add("Accept", "application/json");

            var response = await httpClient.SendAsync(request);

            await response.Content.ReadAsStreamAsync();
        }
    }
}
