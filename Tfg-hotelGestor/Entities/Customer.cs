using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tfg_hotelGestor.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomerBasicInfoId { get; set; }
        [Required]
        public int VacancyId { get; set; }
        [Required]
        public int ContactId { get; set; }
        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(CustomerBasicInfoId))]
        public CustomerBasicInfo CustomerBasicInfo { get; set; }

        [ForeignKey(nameof(ContactId))]
        public CustomerContact CustomerContact { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; }
       
    }
}
