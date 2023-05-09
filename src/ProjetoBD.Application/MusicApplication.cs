using AutoMapper;
using ProjetoBD.Application.Dtos;
using ProjetoBD.Application.Interfaces;
using ProjetoBD.Domain.Core.Interfaces.Services;
using ProjetoBD.Domain.Model;

namespace ProjetoBD.Application
{
    public class MusicApplication : IMusicApplication
    {
        private readonly IMusicService _musicService;
        private IMapper _mapper;
        public MusicApplication(IMusicService musicService, IMapper mapper)
        {
            _musicService = musicService;
            _mapper = mapper;
        }
        public void AddMusic(MusicDto musicDto)
        {
            var music = _mapper.Map<Music>(musicDto);
            _musicService.AddMusic(music);
        }

        public void DeleteMusicById(string id)
        {
            _musicService.DeleteMusicById(id);
        }

        public MusicDto GetMusicById(string id)
        {
            var music = _musicService.GetMusicById(id);
            var musicDto = _mapper.Map<MusicDto>(music);
            return musicDto;
        }

        public IEnumerable<MusicDto> GetMusics()
        {
            var musics = _musicService.GetMusic();
            var musicsDto = _mapper.Map<IEnumerable<MusicDto>>(musics);
            return musicsDto;

        }

        public void UpdateMusic(MusicDto musicDto)
        {
            var musics = _mapper.Map<Music>(musicDto);
            _musicService.UpdateMusic(musics);
        }

    }
}
