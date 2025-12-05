using Tfg_hotelGestor.Entities;

namespace Tfg_hotelGestor.DTO_s.Response
{
    public class CustomerRs
    {
        public int Id {  get; set; }
        public int CustomerBasicInfoId { get; set; }
        public int VacancyId { get; set; }
        public int ContactId { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
