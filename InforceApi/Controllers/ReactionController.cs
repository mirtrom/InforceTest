using AutoMapper;
using InforceData.Data;
using InforceData.Models;
using InforceData.Models.Inputs;
using InforceData.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InforceApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionController : ControllerBase {
        private readonly IReactionRepository _reactionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        public ReactionController(InforceDbContext context, IMapper mapper, UserManager<IdentityUser> userManager) {
            _unitOfWork = new UnitOfWork(context);
            _reactionRepository = _unitOfWork.ReactionRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReactionInput reactionInput) {
            if (reactionInput == null) {
                return BadRequest();
            }
            var user = await _userManager.FindByEmailAsync(reactionInput.UserEmail);
            if (user == null) {
                return Unauthorized();
            }
            var reaction = _mapper.Map<Reaction>(reactionInput);
            var reactionFromDb = await _reactionRepository.GetByUserEmailAsync(reactionInput.UserEmail, reactionInput.PictureId);
            if (reactionFromDb != null) {
                if (reactionFromDb.ReactionType == reactionInput.ReactionType) {
                    await _reactionRepository.Delete(reactionFromDb);
                    return Ok();
                }
                reactionFromDb.ReactionType = reactionInput.ReactionType;
                await _reactionRepository.Update(reactionFromDb);
                await _unitOfWork.SaveAsync();
                return Ok(reactionFromDb);
            }
            reaction.CreatedAt = DateTime.Now;
            reaction.User = user;
            await _reactionRepository.AddAsync(reaction);
            await _unitOfWork.SaveAsync();
            return Ok(reaction);
        }



        [HttpGet("picture/{pictureId}/user/{UserEmail}")]
        public async Task<IActionResult> Get(GetReactionInput reactionInput) {
            var user = await _userManager.FindByEmailAsync(reactionInput.UserEmail);
            if (user == null)
            {
                return Unauthorized();
            }
            var reaction = await _reactionRepository.GetByUserEmailAsync(reactionInput.UserEmail, reactionInput.PictureId);
            if (reaction == null) {
                return NotFound();
            }
            return Ok(reaction);
        }

        [HttpGet("picture/{pictureId}")]
        public async Task<IActionResult> Get(Guid pictureId)
        {
            var reactions = await _reactionRepository.GetByPictureIdAsync(pictureId);
            return Ok(reactions);
        }
/*        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reaction>>> Get() {
            return Ok(await _reactionRepository.GetAllAsync());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Reaction>> Put(Guid id, [FromBody] ReactionInput reaction) {
            if (reaction == null) {
                return BadRequest();
            }
            var existingReaction = await _reactionRepository.GetByIdAsync(id);
            if (existingReaction == null) {
                return NotFound();
            }
            _mapper.Map(reaction, existingReaction);
            await _reactionRepository.Update(existingReaction);
            await _unitOfWork.SaveAsync();
            return Ok(existingReaction);
        }*/

    }
}
