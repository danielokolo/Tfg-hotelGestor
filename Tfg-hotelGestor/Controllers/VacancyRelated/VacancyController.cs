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
    public class VacancyController : ControllerBase
    {
        private readonly IGenericCRUD<Vacancy, int> _service;
        private readonly IMapper _mapper;

        public VacancyController(IGenericCRUD<Vacancy, int> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vacancy = await _service.GetAllAsync();
            var dtoList = _mapper.Map<IEnumerable<VacancyRs>>(vacancy);
            try
            {
                return Ok(new ApiResponse<IEnumerable<VacancyRs>>
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
            var vacancy = await _service.GetByIdAsync(id);
            var rs = _mapper.Map<VacancyRs>(vacancy);

            try
            {
                return Ok(new ApiResponse<VacancyRs>
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
        public async Task<IActionResult> Create(VacancyRq Rq)
        {
            var newVacancy = _mapper.Map<Vacancy>(Rq);
            var created = await _service.CreateAsync(newVacancy);
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
        public async Task<IActionResult> Update(int id, VacancyRq rq)
        {
            try
            {
                var newRoom = _mapper.Map<Vacancy>(rq);
                var updated = await _service.UpdateAsync(id, newRoom);

                if (updated == null)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Data = null,
                        Error = $"Room with Id {id} not found"
                    });
                }

                return Ok(new ApiResponse<Vacancy>
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
