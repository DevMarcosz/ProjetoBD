namespace ProjetoBD.Application.Dtos
{
    public class MusicDto
    {
        public string Track_Name { get; set; }
        public string Artist_Name { get; set; }
        public string Genre { get; set; }
        public int Beats_per_Minute { get; set; }
        public int Energy { get; set; }
        public int Danceability { get; set; }
        public int Loudness { get; set; }
        public int Liveness { get; set; }
        public int Valence { get; set; }
        public int Length { get; set; }
        public int Acousticness { get; set; }
        public int Speechiness { get; set; }
        public int Popularity { get; set; }
    }
}
