using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tfg_hotelGestor.Contracts;
using Tfg_hotelGestor.DTO_s.Requests;
using Tfg_hotelGestor.DTO_s.Response;
using Tfg_hotelGestor.Entities;



namespace Tfg_hotelGestor.Controllers.VacancyRelated
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDetailsController : ControllerBase
    {
        private readonly IGenericCRUD<InvoiceDetails, int> _service;
        private readonly IMapper _mapper;

        public InvoiceDetailsController(IGenericCRUD<InvoiceDetails, int> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoiceDetails = await _service.GetAllAsync();
            var dtoList = _mapper.Map<IEnumerable<InvoiceDetailsRs>>(invoiceDetails);
            try
            {
                return Ok(new ApiResponse<IEnumerable<InvoiceDetailsRs>>
                {
                    Success = true,
                    Data = dtoList,
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var invoiceDetails = await _service.GetByIdAsync(id);
            var rs = _mapper.Map<InvoiceRs>(invoiceDetails);

            try
            {
                return Ok(new ApiResponse<InvoiceRs>
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
        public async Task<IActionResult> Create(InvoiceDetailsRq Rq)
        {
            var newInvoiceDetails = _mapper.Map<InvoiceDetails>(Rq);
            var created = await _service.CreateAsync(newInvoiceDetails);
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
        public async Task<IActionResult> Update(int id, InvoiceDetailsRq rq)
        {
            try
            {
                var newInvoiceDetails = _mapper.Map<InvoiceDetails>(rq);
                var updated = await _service.UpdateAsync(id, newInvoiceDetails);

                if (updated == null)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Data = null,
                        Error = $"Invoice details with Id {id} not found"
                    });
                }

                return Ok(new ApiResponse<InvoiceDetails>
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

            return Ok(new ApiResponse<bool>
            {
                Success = true,
                Data = deleted,
                Error = null
            });
        }

    }

}
