using CloudinaryDotNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Showmie.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Showmie.Utils
{
    internal class UserService : MyServices
    {
        private static readonly Account account = new Account(
            "drgzeuuym",
            "854212394182739",
            "C-fpjLD3MWbHvtV_jLc2vVerY1o");

        private readonly Cloudinary cloudinary = new Cloudinary(account);
        private User user;

        public UserService()
        {
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public async Task<User> GetUserAsync(int UserID)
        {
            NetworkAccess current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                Uri uri = new Uri(string.Format(URLS.GetUserByID, UserID));
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    JObject respBody = JObject.Parse(content);
                    if (respBody.TryGetValue("body", out body))
                    {
                        user = new User();
                        response.Dispose();
                        httpClient.Dispose();
                        user = JsonConvert.DeserializeObject<User>(respBody.GetValue("body").ToString());
                        if (user != null && user.ProfilePicture != null)
                        {
                            if (user.ProfilePicture.Contains("../../img/avatars/default_avatar.png") ||
                                string.IsNullOrWhiteSpace(user.ProfilePicture))
                            {
                                user.ProfilePicture = "http://www.showmie.com/img/avatars/default_avatar.png";
                            }
                        }

                        return user;
                    }
                }

                try
                {
                }
                catch (Exception)
                {
#if RELEASE
                    response.Dispose();
                    httpClient.Dispose();
                    return null;
#endif
#if DEBUG
                    //throw;
#endif
                }
            }

            httpClient.Dispose();
            return null;
        }

        public async Task<User> UserLogin(string username, string password)
        {
            NetworkAccess current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                try
                {
                    Uri uri = new Uri(string.Format(URLS.LoginUser, username, password));
                    HttpResponseMessage response = await httpClient.GetAsync(uri);
                    //Todo: Decouple responses form the pages by passing response info not user object
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        JObject respBody = JObject.Parse(content);
                        if (respBody.TryGetValue("body", out body))
                        {
                            user = new User();
                            response.Dispose();
                            httpClient.Dispose();
                            user = JsonConvert.DeserializeObject<User>(body.ToString());
                            return user;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"ERROR {0}", ex.Message);
                    httpClient.Dispose();
                    return null;
                }

                httpClient.Dispose();
            }
            else
            {
                httpClient.Dispose();
                return null;
            }

            return null;
        }

        public async Task<bool> UpdateUser(string username, string field, string value)
        {
            NetworkAccess current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                try
                {
                    Uri uri = new Uri(string.Format(URLS.UserOperations));
                    var parameters = new Dictionary<string, string>
                    {
                        {"username", username}
                    };

                    parameters.Add(field, value);

                    var encodedContent = new FormUrlEncodedContent(parameters);
                    HttpResponseMessage response = await httpClient.PutAsync(uri, encodedContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        JObject respBody = JObject.Parse(content);
                        if (respBody.TryGetValue("body", out body) && respBody.TryGetValue("error", out error))
                        {
                            if (body != null)
                            {
                                return true;
                            }
                            else if (error != null && error.HasValues)
                            {
                                response.Dispose();
                                httpClient.Dispose();
                                return false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"ERROR {0}", ex.Message);
                    httpClient.Dispose();
                    return false;
                }
            }

            return false;
        }


        public async Task<User> UserSignup(User newUser)
        {
            NetworkAccess networkAccess = Connectivity.NetworkAccess;
            if (networkAccess.Equals(NetworkAccess.Internet))
            {
                try
                {
                    var uri = new Uri(URLS.SignupUser);
                    var dob = newUser?.DateOfBirth != null ? $"{newUser.DateOfBirth:yyyy-MM-dd}" : $"{new DateTime():yyyy-MM-dd}";

                    if (newUser?.Username != null)
                    {
                        var parameters = new Dictionary<string, string>
                        {
                            {"username", newUser.Username},
                            {"email", newUser.Email},
                            {"password", newUser.Password},
                            {"firstname", newUser.FirstName},
                            {"lastname", newUser.LastName},
                            {"admin_role", ((int) newUser.AdminRole).ToString()},
                            {"account_type", newUser.AccountType.ToString()},
                            {"gender", newUser.Gender},
                            {"dob", dob},
                            {"phone", newUser.PhoneNo},
                            {"phone_verified", newUser.PhoneNoVerification},
                            {"country", newUser.Country},
                            {"state", newUser.State}
                        };
                        var encodedContent = new FormUrlEncodedContent(parameters);
                        HttpResponseMessage response = await httpClient.PostAsync(uri, encodedContent);
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            JObject respBody = JObject.Parse(content);
                            if (respBody.TryGetValue("body", out body) && respBody.TryGetValue("error", out error))
                            {
                                if (body != null && body.HasValues)
                                {
                                    return newUser;
                                }

                                if (error != null && error.HasValues)
                                {
                                    response.Dispose();
                                    httpClient.Dispose();
                                    return null;
                                }
                            }
                        }
                    }
                    else
                    {
                      
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"ERROR {0}", ex.Message);
                    httpClient.Dispose();
                    return null;
                }

                httpClient.Dispose();
                return null;
            }
            else
            {
                httpClient.Dispose();
                return null;
            }
        }

        public static async Task<User> DoSignup(UserService userService, User newUser)
        {
            if (newUser != null)
            {
                User NewUser = await userService.UserSignup(newUser);
                return NewUser;
            }
            else
            {
                return null;
            }
        }
    }
}