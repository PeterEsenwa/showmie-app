using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Showmie.Utils
{
    internal class UserService : MyServices
    {
        private Models.User user;

        public UserService()
        {
            httpClient = new HttpClient
            {
                MaxResponseContentBufferSize = 500000
            };
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public async Task<Models.User> GetUser(string username, string password)
        {
            NetworkAccess current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                //using (SHA1Managed sha1 = new SHA1Managed())
                //{
                //    var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                //    var sb = new StringBuilder(hash.Length * 2);

                //    foreach (byte b in hash)
                //    {
                //        sb.Append(b.ToString("x2"));
                //    }

                //    password = sb.ToString();
                //    sha1.Dispose();
                //}

                try
                {
                    var uri = new Uri(string.Format(URLS.GetUserInfo, username, password));
                    var response = await httpClient.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        JObject respBody = JObject.Parse(content);
                        if (respBody.TryGetValue("body", out body))
                        {
                            user = JsonConvert.DeserializeObject<Models.User>(respBody.GetValue("body").ToString());
                        }
                    }
                    response.Dispose();
                    httpClient.Dispose();
                    return user;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"ERROR {0}", ex.Message);
                }
                httpClient.Dispose();
                return null;
            }
            else if (current == NetworkAccess.Local || current == NetworkAccess.None || current == NetworkAccess.Unknown)
            {
                httpClient.Dispose();
                return null;
            }
            httpClient.Dispose();
            return null;
        }
    }
}
