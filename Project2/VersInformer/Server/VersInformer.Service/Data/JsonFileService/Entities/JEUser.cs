using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VersInformer.Service.Data.JsonFileService.Entities
{
    [JsonObject]
    public class JEUser
    {
        [JsonProperty("userName", Required = Required.Always)]
        public string UserName { get; set; }

        [JsonProperty("nickName", Required = Required.Always)]
        public string NickName { get; set; }

        [JsonProperty("lastActivationDateTime", Required = Required.Always)]
        public DateTime LastActivationDateTime { get; set; }

        [JsonProperty("passwordHash", Required = Required.Always)]
        public byte[] PasswordHash { get; set; }
    }
}
