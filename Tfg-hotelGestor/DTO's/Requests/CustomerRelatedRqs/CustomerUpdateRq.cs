using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tfg_hotelGestor.Entities;

namespace Tfg_hotelGestor.DTO_s.Requests
{
    public class CustomerUpdateRq
    {
        public int CustomerBasicInfoId { get; set; }
        public int VacancyId { get; set; }
        public int ContactId { get; set; }
        public bool IsActive { get; set; }
    }
}
