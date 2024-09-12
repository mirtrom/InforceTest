using AutoMapper;
using InforceData.Data;
using InforceData.Models;
using InforceData.Models.Inputs;
using InforceData.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace InforceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase {
        private readonly IPictureRepository _pictureRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PictureController(InforceDbContext context, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork(context);
            _pictureRepository = _unitOfWork.PictureRepository;
            _mapper = mapper;
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> UploadImage([FromForm] PictureInput imageInput)
        {
            // Validate input
            if (imageInput.File == null || string.IsNullOrWhiteSpace(imageInput.Title))
            {
                return BadRequest("File and title are required.");
            }
            var image = new Picture
            {
                Title = imageInput.Title,
                CreatedAt = DateTime.Now,
                Extension = Path.GetExtension(imageInput.File.FileName).ToLower(),
                AlbumId = imageInput.AlbumId
            };

            // Upload the image using the repository
            await _pictureRepository.Upload(imageInput.File, image);
            await _unitOfWork.SaveAsync();
            // Map and return the response
            return Ok(_mapper.Map<Picture>(image));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImage(Guid id)
        {
            // Fetch the image by ID
            var image = await _pictureRepository.GetByIdAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            // Map and return the response
            return Ok(image);
        }

        [HttpGet]
        public async Task<IActionResult> GetImages()
        {
            // Fetch all images
            var images = await _pictureRepository.GetAllAsync();

            // Map and return the response
            return Ok(images);
        }

        [HttpGet("album/{albumId}")]
        public async Task<IActionResult> GetImagesByAlbum(Guid albumId)
        {
            // Fetch all images by album ID
            var images = await _pictureRepository.GetAllFromAlbum(albumId);

            // Map and return the response
            return Ok(images);
        }


        [HttpGet("album/{albumId}/count")]
        public async Task<IActionResult> GetImagesByAlbumCount(Guid albumId)
        {
            // Fetch all images by album ID
            var images = await _pictureRepository.GetAllFromAlbum(albumId);

            // Map and return the response
            return Ok(images.Count());
        }

        [HttpGet("user/{userEmail}")]
        public async Task<IActionResult> GetImagesByUser(string userEmail)
        {
            var images = await _pictureRepository.GetAllFromUser(userEmail);

            return Ok(images);
        }

        [HttpGet("page/{page}")]
        public async Task<IActionResult> GetImagesByPage(int page)
        {
            var images = await _pictureRepository.GetPaginated(page);

            return Ok(images);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(Guid id)
        {
            var image = await _pictureRepository.GetByIdAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            await _pictureRepository.Delete(image);
            await _unitOfWork.SaveAsync();

            return Ok();
        }
    }
}
