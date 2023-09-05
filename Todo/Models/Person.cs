using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [Required]
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }
        [Required]
        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }
        [Required]
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
    }
}