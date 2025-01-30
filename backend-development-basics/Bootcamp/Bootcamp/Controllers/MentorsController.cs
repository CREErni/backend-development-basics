using AutoMapper;
using Bootcamp.DTOs;
using Bootcamp.Entities;
using Bootcamp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class MentorsController : ControllerBase
    {
        private readonly IMentorRepository _repository;
        private readonly IMapper _mapper;

        public MentorsController(IMentorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MentorDto>>> GetAll()
        {
            var mentors = await _repository.GetAllMentorsAsync();
            return Ok(_mapper.Map<IEnumerable<MentorDto>>(mentors));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MentorDto>> GetById(int id)
        {
            var mentor = await _repository.GetMentorByIdAsync(id);
            if (mentor == null) return NotFound();
            return Ok(_mapper.Map<MentorDto>(mentor));
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateMentorDto dto)
        {
            var mentor = _mapper.Map<Mentor>(dto);
            await _repository.AddMentorAsync(mentor);
            return CreatedAtAction(nameof(GetById), new { id = mentor.Id }, mentor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CreateMentorDto dto)
        {
            var mentor = await _repository.GetMentorByIdAsync(id);
            if (mentor == null) return NotFound();

            _mapper.Map(dto, mentor);
            await _repository.UpdateMentorAsync(mentor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.DeleteMentorAsync(id);
            return NoContent();
        }
    }
}
