using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRep1.Data.DTOs
{
    public class IncompleteServiceDTO
    {
        public int Id { get; set; }
        [Column(TypeName = "money")]
        public string NameOfService { get; set; }
        public double? Price { get; set; }
    }
}
