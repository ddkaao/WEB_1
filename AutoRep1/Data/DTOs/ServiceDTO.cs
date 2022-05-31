using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRep1.Data.DTOs
{
    public class ServiceDTO
    {
        public string NameOfService { get; set; }
        [Column(TypeName = "money")]
        public double? Price { get; set; }
        public int? Time { get; set; }
    }
}
