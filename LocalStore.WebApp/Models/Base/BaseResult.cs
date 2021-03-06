using Newtonsoft.Json;

namespace LocalStore.WebApp.Models
{    
    public class BaseResult<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("itemsCount")]
        public int ItemsCount { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }
    }
}