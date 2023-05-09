using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoBD.Application.Dtos;
using ProjetoBD.Application.Interfaces;
using ProjetoBD.Domain.Model;

namespace ProjetoBD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {

        private readonly IMusicApplication _musicApplication;

        public MusicController(IMusicApplication musicApplication)
        {
            _musicApplication = musicApplication;
        }

        [HttpPost("music", Name = "add-music")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MusicDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<IEnumerable<MusicDto>> AddMusic(MusicDto musicDto)
        {
            _musicApplication.AddMusic(musicDto);
            return Ok("Music inserted successfully");
        }

        [HttpPut("music", Name = "update_music")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MusicDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<MusicDto>> UpdateMusic(MusicDto musicDto)
        {
            _musicApplication.UpdateMusic(musicDto);
            return Ok("Music updated successfully!");
        }

        [HttpDelete("music/{musicId}", Name = "delete-music-by-id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MusicDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<MusicDto>> DeleteMusicById(string musicId)
        {
            var formattedMusicId = Uri.UnescapeDataString(musicId);
            _musicApplication.DeleteMusicById(formattedMusicId);
            return Ok("Music deleted successfully!");
        }

        [HttpGet("musics", Name = "get-musics")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MusicDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<MusicDto>> GetMusic()
        {
            return Ok(_musicApplication.GetMusics());
        }

        [HttpGet("musics/{musicId}", Name = "get-music-by-id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MusicDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<MusicDto>> GetMusicById(string musicId)
        {
            var formattedMusicId = Uri.UnescapeDataString(musicId);
            var music = _musicApplication.GetMusicById(formattedMusicId);
            if(music is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(music);
            }
        }
    }
}
