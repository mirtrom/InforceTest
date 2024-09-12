using AutoMapper;
using InforceBL.DTO;
using InforceData.Data;
using InforceData.Models;
using InforceData.Models.Inputs;
using InforceData.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InforceApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase {
        private readonly IAlbumRepository _albumRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        public AlbumController(InforceDbContext context, UserManager<IdentityUser> userManager, IMapper mapper) {
            _unitOfWork = new UnitOfWork(context);
            _albumRepository = _unitOfWork.AlbumRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet("count")]
        public async Task<ActionResult> Get() {
            var albums = await _albumRepository.GetAllAsync();
            return Ok(albums.Count());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> Get(Guid id) {
            var album = await _albumRepository.GetByIdWithDetailsAsync(id);
            if (album == null) {
                return NotFound();
            }
            return Ok(album);
        }

        [HttpPost]
        public async Task<ActionResult<Album>> Post([FromBody] AlbumInput albumInput) {
            if (albumInput == null)
            {
                return BadRequest();
            }
            var album = _mapper.Map<Album>(albumInput);
            album.CreatedAt = DateTime.Now;

            var user = await _userManager.FindByEmailAsync(albumInput.UserEmail);
            if (user == null)
            {
                return Unauthorized();
            }
            album.User = user;
            album.UserId = new Guid(user.Id);
            await _albumRepository.AddAsync(album);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(Get), new { id = album.Id }, album);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Album>> Put(Guid id, [FromBody] AlbumInput album) {
            var albumToUpdate = await _albumRepository.GetByIdAsync(id);
            if (albumToUpdate == null)
            {
                return NotFound();
            }
            _mapper.Map(album, albumToUpdate);
            await _unitOfWork.SaveAsync();
            return Ok(album);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Album>> Delete(Guid id) {
            var album = await _albumRepository.GetByIdAsync(id);
            if (album == null) {
                return NotFound();
            }
            await _albumRepository.Delete(album);
            await _unitOfWork.SaveAsync();
            return Ok(_mapper.Map<AlbumDto>(album));
        }

        [HttpGet("page/{page}")]
        public async Task<ActionResult<IEnumerable<AlbumDto>>> GetPage(int page)
        {
            var albums = await _albumRepository.GetPageAsync(page);
            var albumDtos = _mapper.Map<List<AlbumDto>>(albums);
            return Ok(albumDtos);
        }

        [HttpGet("user/{email}")]
        public async Task<ActionResult<IEnumerable<AlbumDto>>> GetUsersAlbums(string email)
        {

            var albums = await _albumRepository.GetUsersAlbumsAsync(email);
            if (albums == null || !albums.Any())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<AlbumDto>>(albums));
        }


    }
}
