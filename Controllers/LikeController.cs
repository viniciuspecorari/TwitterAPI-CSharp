using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterAPI.Contracts;
using TwitterAPI.Models.LikeDto;

namespace TwitterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeRepository _likeRepository;

        public LikeController(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddLike(LikeDto likeDto)
        {
            await _likeRepository.AddLike(likeDto);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveLike(LikeDto likeDto)
        {
            await _likeRepository.RemoveLike(likeDto);

            return Ok();
        }
    }
}
