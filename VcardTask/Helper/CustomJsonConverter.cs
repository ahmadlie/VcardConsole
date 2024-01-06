using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using VcardTask.Models;

namespace VcardTask.Helper
{
    public static class CustomJsonConverter
    {
        public static VCard Convert(string jsonString)
        {
            JObject jsonObject = JObject.Parse(jsonString);
            VCard vCard = new VCard()
            {
                Id = jsonObject["results"][0]["id"]["value"].Value<string>(),
                FirstName = jsonObject["results"][0]["name"]["first"].Value<string>(),
                LastName = jsonObject["results"][0]["name"]["last"].Value<string>(),
                Email = jsonObject["results"][0]["email"].Value<string>(),
                Phone = jsonObject["results"][0]["phone"].Value<string>(),
                Country = jsonObject["results"][0]["location"]["country"].Value<string>(),
                City = jsonObject["results"][0]["location"]["city"].Value<string>()
            };

            return vCard;
        }
    }
}
