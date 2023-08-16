using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
    public class Item
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [Required]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [Required]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "completed")]
        public bool Completed { get; set; }
    }
}