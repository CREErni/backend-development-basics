using AutoMapper;
using Bootcamp.DTOs;
using Bootcamp.Entities;
using Bootcamp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BootcampersController : ControllerBase
    {
        private readonly IBootcampRepository _repository; 
        private readonly IMapper _mapper;

        public BootcampersController(IBootcampRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BootcamperDto>>> GetAll()
        {
            var bootcampers = await _repository.GetAllBootcampersAsync();
            return Ok(_mapper.Map<IEnumerable<BootcamperDto>>(bootcampers));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BootcamperDto>> GetById(int id)
        {
            var bootcamper = await _repository.GetBootcamperByIdAsync(id);
            if (bootcamper == null) return NotFound();
            return Ok(_mapper.Map<BootcamperDto>(bootcamper));
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateBootcamperDto dto)
        {
            var bootcamper = _mapper.Map<Bootcamper>(dto);
            await _repository.AddBootcamperAsync(bootcamper);
            return CreatedAtAction(nameof(GetById), new { id = bootcamper.Id }, bootcamper);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CreateBootcamperDto dto)
        {
            var bootcamper = await _repository.GetBootcamperByIdAsync(id);
            if (bootcamper == null) return NotFound();

            _mapper.Map(dto, bootcamper);
            await _repository.UpdateBootcamperAsync(bootcamper);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.DeleteBootcamperAsync(id);
            return NoContent();
        }
    }
}
