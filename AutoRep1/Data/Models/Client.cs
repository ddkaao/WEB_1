using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoRep1.Data.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        internal void Remove(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
