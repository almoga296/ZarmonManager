using System.Net.Http;
using Zarmon.Connection.Core.Generic;
using Zarmon.Device.ApiCore.Core;
using Zarmon.Device.ApiCore.TplBooster.Models;
using Zarmon.Device.Implementation.TplBoosterCore;
using Zarmon.Device.SyntaxCore.Core.Generic;

namespace Zarmon.Device.ApiCore.TplBooster
{
    public class TplBoosterApi : Api , IBoosterApi
    {
        private TplBoosterSyntax _tplBoosterSyntax;

        public TplBoosterApi(IConnection connection, TplBoosterSyntax tplBoosterSyntax) : base(connection, tplBoosterSyntax)
        {
            _tplBoosterSyntax = tplBoosterSyntax;
        }

        public BoosterStatusModel GetConfiguration()
        {
            Command<BoosterStatusModel> command = _tplBoosterSyntax.GET_STATUS();
            object statusModel = Connection.Execute(command.Builder());
            return command.Parser((HttpResponseMessage)statusModel);
        }
    }
}