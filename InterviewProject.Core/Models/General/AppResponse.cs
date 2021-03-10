using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;
using static InterviewProject.Core.Models.General.AppEnums;

namespace InterviewProject.Core.Models.General
{
    public class AppResponse
    {
        public AppResponse()
        {
            Status = false;
            Type = ResponseType.Error;
        }

        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public string Trace { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ResponseType Type { get; set; }
    }
}
