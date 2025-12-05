using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tfg_hotelGestor.Contracts;
using Tfg_hotelGestor.DTO_s.Response;
using Tfg_hotelGestor.DTO_s.Requests;
using Tfg_hotelGestor.Entities;


namespace Tfg_hotelGestor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericCRUD<Product, int> _service;
        private readonly IMapper _mapper;

        public ProductController(IGenericCRUD<Product, int> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var product = await _service.GetAllAsync();
            var dtoList = _mapper.Map<IEnumerable<ProductRs>>(product);
            try
            {
                return Ok(new ApiResponse<IEnumerable<ProductRs>>
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
            var product = await _service.GetByIdAsync(id);
            var rs = _mapper.Map<ProductRs>(product);

            try
            {
                return Ok(new ApiResponse<ProductRs>
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
        public async Task<IActionResult> Create(ProductRq Rq)
        {
            var newProduct = _mapper.Map<Product>(Rq);
            var created = await _service.CreateAsync(newProduct);
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
        public async Task<IActionResult> Update(int id, ProductRq rq)
        {
            try
            {
                var newProduct = _mapper.Map<Product>(rq);
                var updated = await _service.UpdateAsync(id, newProduct);

                if (updated == null)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Data = null,
                        Error = $"Product with Id {id} not found"
                    });
                }

                return Ok(new ApiResponse<Product>
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
