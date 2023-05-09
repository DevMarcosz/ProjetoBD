using ProjetoBD.Domain.Model;

namespace ProjetoBD.Domain.Core.Interfaces.Services
{
    public interface IMusicService
    {
        void AddMusic(Music music);
        void UpdateMusic(Music music);
        void DeleteMusicById(string id);
        IEnumerable<Music> GetMusic();
        Music GetMusicById(string id);
    }
}
