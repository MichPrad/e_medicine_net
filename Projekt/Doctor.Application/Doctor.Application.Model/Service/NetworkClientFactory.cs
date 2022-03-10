namespace Doctor.Application.Model
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    public static class NetworkClientFactory
    {
        public static INetwork GetNetworkClient()
        {
            const string serviceHost = "localhost";
            const int servicePort = 8083;

            return new NetworkClient(serviceHost, servicePort);
        }
    }
}
