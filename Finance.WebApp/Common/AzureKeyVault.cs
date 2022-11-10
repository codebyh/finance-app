using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace Finance.WebApp.Common
{
    public class AzureKeyVault
    {
        SecretClient client;

        public AzureKeyVault()
        {

            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
                    {
                        Delay= TimeSpan.FromSeconds(2),
                        MaxDelay = TimeSpan.FromSeconds(16),
                        MaxRetries = 5,
                        Mode = RetryMode.Exponential
                     }
            };
            client = new SecretClient(new Uri("https://<your-unique-key-vault-name>.vault.azure.net/"), new DefaultAzureCredential(), options);
        }

        string GetSecret(string secretName)
        {
            KeyVaultSecret secret = client.GetSecret("<mySecret>");

            return secret?.Value;
        }

    }
}
