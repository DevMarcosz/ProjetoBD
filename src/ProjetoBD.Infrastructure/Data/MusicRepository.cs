using ProjetoBD.Domain.Core.Interfaces.Repositories;
using ProjetoBD.Domain.Model;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace ProjetoBD.Infrastructure.Data
{
    public class MusicRepository : IMusicRepository
    {
        private readonly IDocumentStore _documentStore;
        
        public MusicRepository(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        public void AddMusic(Music music)
        {
            using IDocumentSession session = _documentStore.OpenSession();
            session.Store(music);
            session.SaveChanges();
        }

        public void DeleteMusicById(string id)
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            var music = documentSession.Load<Music>(id);
            if(music is not null)
            {
                documentSession.Delete(music);
                documentSession.SaveChanges();
            }
        }

        public Music GetMusicById(string id)
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            var music = documentSession.Load<Music>(id);
            return music;
        }

        public IEnumerable<Music> GetMusics()
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            var musics = documentSession.Query<Music>().ToList();
            return musics;
        }

        public void UpdateMusic(Music music)
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            var musicEntity = documentSession.Query<Music>().FirstOrDefault(c => c.Track_Name == music.Track_Name);
            if(musicEntity is not null)
            { 
                musicEntity.Track_Name = music.Track_Name;
                musicEntity.Artist_Name = music.Artist_Name;
                musicEntity.Genre = music.Genre;
                musicEntity.Beats_per_Minute = music.Beats_per_Minute;
                musicEntity.Energy = music.Energy;
                musicEntity.Danceability = music.Danceability;
                musicEntity.Loudness = music.Loudness;
                musicEntity.Liveness = music.Liveness;
                musicEntity.Valence = music.Valence;
                musicEntity.Length = music.Length;
                musicEntity.Acousticness = music.Acousticness;
                musicEntity.Speechiness = music.Speechiness;
                musicEntity.Popularity = music.Popularity;
            }
            documentSession.SaveChanges();
        }
    }
}
