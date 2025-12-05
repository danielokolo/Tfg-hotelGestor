using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tfg_hotelGestor.Contracts;
using Tfg_hotelGestor.DTO_s.Requests;
using Tfg_hotelGestor.DTO_s.Response;
using Tfg_hotelGestor.Entities;


namespace Tfg_hotelGestor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerBasicInfoController : ControllerBase
    {
        private readonly IGenericCRUD<CustomerBasicInfo, int> _service;
        private readonly IMapper _mapper;

        public CustomerBasicInfoController(IGenericCRUD<CustomerBasicInfo, int> service , IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customersBasicsInfo = await _service.GetAllAsync();
            var dtoList = _mapper.Map<IEnumerable<CustomerBasicInfoRs>>(customersBasicsInfo);
            try {
                return Ok(new ApiResponse<IEnumerable<CustomerBasicInfoRs>>
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
            var customer = await _service.GetByIdAsync(id);
            var rs = _mapper.Map<CustomerBasicInfoRs>(customer);

            try
            {
                return Ok(new ApiResponse<CustomerBasicInfoRs>
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
        public async Task<IActionResult> Create(CustomerBasicInfoRq Rq)
        {
            var newCustomerBasicInfo = _mapper.Map<CustomerBasicInfo>(Rq);
            var created = await _service.CreateAsync(newCustomerBasicInfo);
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
        public async Task<IActionResult> Update(int id, CustomerBasicInfoRq rq)
        {
            try
            {
                var newCustomerBasic = _mapper.Map<CustomerBasicInfo>(rq);
                var updated = await _service.UpdateAsync(id, newCustomerBasic);

                if (updated == null)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Data = null,
                        Error = $"Customer with Id {id} not found"
                    });
                }

                return Ok(new ApiResponse<CustomerBasicInfo>
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
