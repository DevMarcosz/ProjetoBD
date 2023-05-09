using ProjetoBD.Application.Dtos;

namespace ProjetoBD.Application.Interfaces
{
    public interface IMusicApplication
    {
        void AddMusic(MusicDto musicDto);
        void UpdateMusic(MusicDto musicDto);
        void DeleteMusicById(string id);
        IEnumerable<MusicDto> GetMusics();
        MusicDto GetMusicById(string id);
    }
}
