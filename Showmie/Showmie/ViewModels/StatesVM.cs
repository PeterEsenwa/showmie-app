using Newtonsoft.Json;
using Showmie.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Showmie.ViewModels
{
    internal class StatesVM
    {
        public async Task<ObservableCollection<States>> GetStatesFromJSON()
        {
            try
            {
                ObservableCollection<States> result = await Task.Run(() =>
                         {
                             Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(StatesVM)).Assembly;
                             Stream stream = assembly.GetManifestResourceStream("Showmie.Droid.statesInNG.json");
                             States[] data;
                             using (StreamReader reader = new StreamReader(stream))
                             {
                                 string json = reader.ReadToEnd();
                                 data = JsonConvert.DeserializeObject<States[]>(json);
                             }
                             return new ObservableCollection<States>(data);
                         });
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
