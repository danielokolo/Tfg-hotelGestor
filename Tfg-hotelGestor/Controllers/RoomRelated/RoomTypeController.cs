using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tfg_hotelGestor.Contracts;
using Tfg_hotelGestor.DTO_s.Requests;
using Tfg_hotelGestor.DTO_s.Response;
using Tfg_hotelGestor.Entities;


namespace Tfg_hotelGestor.Controllers.RoomRelatedControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IGenericCRUD<RoomType, int> _service;
        private readonly IMapper _mapper;

        public RoomTypeController(IGenericCRUD<RoomType, int> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roomType = await _service.GetAllAsync();
            var dtoList = _mapper.Map<IEnumerable<RoomTypeRs>>(roomType);
            try
            {
                return Ok(new ApiResponse<IEnumerable<RoomTypeRs>>
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
            var roomType = await _service.GetByIdAsync(id);
            var rs = _mapper.Map<RoomTypeRs>(roomType);

            try
            {
                return Ok(new ApiResponse<RoomTypeRs>
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
        public async Task<IActionResult> Create(RoomTypeRq Rq)
        {
            var newRoomType = _mapper.Map<RoomType>(Rq);
            var created = await _service.CreateAsync(newRoomType);
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
        public async Task<IActionResult> Update(int id, RoomTypeRq rq)
        {
            try
            {
                var newRoomType = _mapper.Map<RoomType>(rq);
                var updated = await _service.UpdateAsync(id, newRoomType);

                if (updated == null)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Data = null,
                        Error = $"Room Type with Id {id} not found"
                    });
                }

                return Ok(new ApiResponse<RoomType>
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
