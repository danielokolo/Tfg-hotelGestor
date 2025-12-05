using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tfg_hotelGestor.Contracts;
using Tfg_hotelGestor.DTO_s.Requests;
using Tfg_hotelGestor.DTO_s.Response;
using Tfg_hotelGestor.Entities;


namespace Tfg_hotelGestor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerContactController : ControllerBase
    {
        private readonly IGenericCRUD<CustomerContact, int> _service;
        private readonly IMapper _mapper;

        public CustomerContactController(IGenericCRUD<CustomerContact, int> service , IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customersContacts = await _service.GetAllAsync();
            var dtoList = _mapper.Map<IEnumerable<CustomerContactRs>>(customersContacts);
            try {
                return Ok(new ApiResponse<IEnumerable<CustomerContactRs>>
                {
                    Success = true,
                    Data = dtoList,
                    Error = null
                });
            }
            catch (Exception ex) {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Data = null,
                    Error = $"Internal server error: {ex.Message}"
                });
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customerContact = await _service.GetByIdAsync(id);
            var rs = _mapper.Map<CustomerContactRs>(customerContact);

            try
            {
                return Ok(new ApiResponse<CustomerContactRs>
                {
                    Success = true,
                    Data = rs,
                    Error = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Data = null,
                    Error = $"Internal server error: {ex.Message}"
                });
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerContactRq Rq)
        {
            var newCustomerContact = _mapper.Map<CustomerContact>(Rq);
            var created = await _service.CreateAsync(newCustomerContact);
            var rs = CreatedAtAction(nameof(GetById), new { id = created.Id }, created);

            try
            {
                return Ok(new ApiResponse<CreatedAtActionResult>
                {
                    Success = true,
                    Data = rs,
                    Error = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Data = null,
                    Error = $"Internal server error: {ex.Message}"
                });
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerContactRq rq)
        {
            try
            {
                var newCustomerContact = _mapper.Map<CustomerContact>(rq);
                var updated = await _service.UpdateAsync(id, newCustomerContact);

                if (updated == null)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Data = null,
                        Error = $"Customer with Id {id} not found"
                    });
                }

                return Ok(new ApiResponse<CustomerContact>
                {
                    Success = true,
                    Data = updated,
                    Error = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Data = null,
                    Error = $"Internal server error: {ex.Message}"
                });
            }

           

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            var deleted = await _service.DeleteAsync(id);

            if (deleted == false)
            {
                return NotFound(new ApiResponse<string>
                {
                    Success = false,
                    Data = null,
                    Error = $"Id not found: {id}"
                });
            }

            // Si existe, devolver OK
            return Ok(new ApiResponse<bool>
            {
                Success = true,
                Data = deleted,
                Error = null
            });
        }

    }

}
