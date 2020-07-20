using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;

namespace Soulgram.IdentityServer
{
    public static class Configuration
    {
        public static IEnumerable<ApiResource> GetApis() =>
            new List<ApiResource>
            {
                new ApiResource("ApiOne"),
                new ApiResource("ApiTwo"),
            };

        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client_id",
                    // TODO more secure
                    ClientSecrets =  {new Secret("client_secret".ToSha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = new List<string>{"ApiOne","ApiTwo"}
                }
            };

    }
}
