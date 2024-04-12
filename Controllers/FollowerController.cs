using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TwitterAPI.Contracts;
using TwitterAPI.Models.FollowerDto;

namespace TwitterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerController : ControllerBase
    {
        private readonly IFollowerRepository _followerRepository;

        public FollowerController(IFollowerRepository followerRepository)
        {
            _followerRepository = followerRepository;
        }

        [HttpGet]
        [Route("/api/ResumeFollows/{Id}")]
        public async Task<ActionResult<IEnumerable<GetUserResumeFollowsDto>>> GetResumeFollows(Guid Id)
        {
            var reumeFollows = await _followerRepository.GetResumeFollows(Id);

            return Ok(reumeFollows); 
        }

        
        [HttpGet]
        [Route("/api/Followers/{Id}")]
        public async Task<ActionResult<IEnumerable<GetFollowersDto>>> GetFollowers(Guid Id)
        {
            var followers = await _followerRepository.GetFollowers(Id);

            return Ok(followers);
        }

        [HttpGet]
        [Route("/api/Follows/{Id}")]
        public async Task<ActionResult<IEnumerable<GetFollowersDto>>> GetFollows(Guid Id)
        {
            var follows = await _followerRepository.GetFollows(Id);

            return Ok(follows);
        }


        [HttpPost]
        public async Task<IActionResult> Follow(FollowerDto followerDto)
        {
            await _followerRepository.Follow(followerDto);

            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> UnFollow(Guid Id)
        {
            await _followerRepository.UnFollow(Id);

            return Ok();
        }
    }
}
