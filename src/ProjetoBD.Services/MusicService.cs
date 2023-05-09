using ProjetoBD.Domain.Core.Interfaces.Repositories;
using ProjetoBD.Domain.Core.Interfaces.Services;
using ProjetoBD.Domain.Model;

namespace ProjetoBD.Services
{
    public class MusicService : IMusicService
    {
            private readonly IMusicRepository _musicRepository;

            public MusicService(IMusicRepository musicRepository)
            {
                _musicRepository = musicRepository;
            }
            public void AddMusic(Music music)
            {
                _musicRepository.AddMusic(music);
            }

            public void DeleteMusicById(string id)
            {
                _musicRepository.DeleteMusicById(id);
            }

            public IEnumerable<Music> GetMusic()
            {
                return _musicRepository.GetMusics();
            }

            public Music GetMusicById(string id)
            {
               return _musicRepository.GetMusicById(id);
            }

            public void UpdateMusic(Music music)
            {
                _musicRepository.UpdateMusic(music);
            }
    }
}
