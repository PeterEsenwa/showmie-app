using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Showmie.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Showmie.Utils
{
    internal class DesignService : MyServices
    {
        private List<DesignGroup> DesignGroups { get; set; }

        public JsonSerializerSettings JSON_SerializerSettings { get; } = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Include,
            MissingMemberHandling = MissingMemberHandling.Ignore,
        };

        public DesignService()
        {
            DesignGroups = new List<DesignGroup>();
        }

        public async Task<List<DesignGroup>> GetDesigns(string category)
        {
            NetworkAccess current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                try
                {
                    string uriString = string.Format(URLS.GetDesignsByCategory, category);
                    Uri uri = new Uri(uriString);
                    HttpResponseMessage response = await httpClient.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        JObject respBody = JObject.Parse(await response.Content.ReadAsStringAsync());
                        if (respBody.TryGetValue("body", out body))
                        {

                            DesignGroup designGroup = null;
                            //design = JsonConvert.DeserializeObject<Models.Design>(respBody.GetValue("body").ToString());
                            foreach (JToken bodyValues in respBody["body"].Values())
                            {
                                if (designGroup == null)
                                {
                                    designGroup = new DesignGroup();
                                }
                                if (((JProperty)bodyValues).Name == "design")
                                {
                                    JToken designValue = ((JProperty)bodyValues).Value;
                                    Design design = JsonConvert.DeserializeObject<Design>(designValue.Value<JObject>().ToString());
                                    designGroup.Design = design;
                                }
                                else if (((JProperty)bodyValues).Name == "creator")
                                {
                                    JToken designValue = ((JProperty)bodyValues).Value;
                                    foreach (JToken jToken in designValue)
                                    {
                                        var token = (JObject) jToken;
                                        string path = jToken.Path;
                                        designValue.Value<JObject>().Remove("");
                                    }
                                    User creator = JsonConvert.DeserializeObject<User>(designValue.Value<JObject>().ToString());
                                    designGroup.Creator = creator;
                                    DesignGroups.Add(designGroup);
                                    designGroup = null;
                                }
                            }
                            return DesignGroups;
                        }
                        else
                        {
                            response.Dispose();
                            httpClient.Dispose();
                            return null;
                        }
                    }
                    else
                    {
                        response.Dispose();
                        httpClient.Dispose();
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            httpClient.Dispose();
            return null;
        }

        public async Task<Design> GetDesign(int designID)
        {
            NetworkAccess current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                try
                {
                    string uriString = string.Format(URLS.GetDesignByID, designID);
                    Uri uri = new Uri(uriString);
                    
                    //HttpResponseMessage response = await httpClient.GetAsync(uri);
                    HttpResponseMessage response = await httpClient.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        JObject respBody = JObject.Parse(await response.Content.ReadAsStringAsync());
                        if (respBody.TryGetValue("body", out body))
                        {
                            Design design = JsonConvert.DeserializeObject<Design>(body.Value<JObject>().ToString());
                            return design;
                        }
                        else
                        {
                            response.Dispose();
                            httpClient.Dispose();
                            return null;
                        }
                    }
                    else
                    {
                        response.Dispose();
                        httpClient.Dispose();
                        return null;
                    }
                }
                catch (Exception)
                {
                    httpClient.Dispose();
                    return null;
                }
            }
            httpClient.Dispose();
            return null;
        }
    }
}
