using ProjetoBD.Domain.Model;

namespace ProjetoBD.Domain.Core.Interfaces.Repositories
{
    public interface IMusicRepository
    {
        void AddMusic(Music music);
        void UpdateMusic(Music music);
        void DeleteMusicById(string id);
        IEnumerable<Music> GetMusics();
        Music GetMusicById(string id);
    }
}
