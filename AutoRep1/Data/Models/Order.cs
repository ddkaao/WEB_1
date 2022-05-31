using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRep1.Data.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }
        public int ClientID { get; set; }
        public int ServiceID { get; set; }
        public IEnumerable<Client>? Clients { get; set; }
        public IEnumerable<Service>? Services { get; set; }
        internal void Remove(Order order)
        {
            throw new NotImplementedException();
        }

    }
}
