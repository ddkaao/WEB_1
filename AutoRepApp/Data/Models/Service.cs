using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRepApp.Data.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string NameOfService { get; set; }
        [Column(TypeName = "money")]
        public double? Price { get; set; }
        public int? Time { get; set; }
    }
}
