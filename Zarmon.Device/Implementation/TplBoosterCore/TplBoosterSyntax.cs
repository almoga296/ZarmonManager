using System;
using System.Net.Http;
using Newtonsoft.Json;
using Zarmon.Device.ApiCore.TplBooster.Models;
using Zarmon.Device.SyntaxCore;
using Zarmon.Device.SyntaxCore.Core.Generic;

namespace Zarmon.Device.Implementation.TplBoosterCore
{
    public class TplBoosterSyntax : Syntax, IBoosterSyntax
    {
        public Command<BoosterStatusModel> GET_STATUS()
        {
            Uri uri = new Uri("https://localhost:44331/api/booster");
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            return new Command<BoosterStatusModel>()
            {
                Builder = () =>
                {
                    return httpRequestMessage;
                },
                Parser = data =>
                {
                    if (data is HttpResponseMessage response)
                    {
                        string content = response.Content.ReadAsStringAsync().Result;
                        BoosterStatusModel boosterConfigurationModel = JsonConvert.DeserializeObject<BoosterStatusModel>(content);
                        return boosterConfigurationModel;
                    }
                    return null;
                }
            };
        }
    }
}
