
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace WebApplication3
{
    public class Config
    {
        // scopes define the API resources in your system
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api1" },
                    Claims =  new List<Claim>{new Claim("Age", "75")},
                },
                new Client
                {
                    ClientId = "client2",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api1" },
                    Claims =  new List<Claim>{new Claim("Age", "17")},
                }
            };
        }
    }
}