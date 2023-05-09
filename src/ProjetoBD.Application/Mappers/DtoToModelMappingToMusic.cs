using AutoMapper;
using ProjetoBD.Application.Dtos;
using ProjetoBD.Domain.Model;

namespace ProjetoBD.Application.Mappers
{
    public class DtoToModelMappingToMusic : Profile
    {

        public DtoToModelMappingToMusic()
        {
            MappingMusic();
        }
        private void MappingMusic()
        {
            CreateMap<MusicDto, Music>()
                .ForMember(dest => dest.Track_Name, opt => opt.MapFrom(x => x.Track_Name)).ReverseMap()
                .ForMember(dest => dest.Artist_Name, opt => opt.MapFrom(x => x.Artist_Name)).ReverseMap()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(x => x.Genre)).ReverseMap()
                .ForMember(dest => dest.Beats_per_Minute, opt => opt.MapFrom(x => x.Beats_per_Minute)).ReverseMap()
                .ForMember(dest => dest.Energy, opt => opt.MapFrom(x => x.Energy)).ReverseMap()
                .ForMember(dest => dest.Danceability, opt => opt.MapFrom(x => x.Danceability)).ReverseMap()
                .ForMember(dest => dest.Loudness, opt => opt.MapFrom(x => x.Loudness)).ReverseMap()
                .ForMember(dest => dest.Liveness, opt => opt.MapFrom(x => x.Liveness)).ReverseMap()
                .ForMember(dest => dest.Valence, opt => opt.MapFrom(x => x.Valence)).ReverseMap()
                .ForMember(dest => dest.Length, opt => opt.MapFrom(x => x.Length)).ReverseMap()
                .ForMember(dest => dest.Acousticness, opt => opt.MapFrom(x => x.Acousticness)).ReverseMap()
                .ForMember(dest => dest.Speechiness, opt => opt.MapFrom(x => x.Speechiness)).ReverseMap()
                .ForMember(dest => dest.Popularity, opt => opt.MapFrom(x => x.Popularity)).ReverseMap();
        }
    }
}
