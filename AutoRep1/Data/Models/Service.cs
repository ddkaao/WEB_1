using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRep1.Data.Models
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }
        public string NameOfService { get; set; }
        [Column(TypeName = "money")]
        public double? Price { get; set; }
        public int? Time { get; set; }
        internal void Remove(Service service)
        {
            throw new NotImplementedException();
        }
    }
}
