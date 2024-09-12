using AutoMapper;
using InforceBL.DTO;
using InforceData.Models;
using InforceData.Models.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InforceBL
{
    public class InforceMapper : Profile{
        public InforceMapper()
        {
            CreateMap<AlbumInput, Album>();
            CreateMap<ReactionInput, Reaction>();
            CreateMap<PictureInput, Picture>();
            CreateMap<Album, AlbumDto>()
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Pictures, opt => opt.MapFrom(src => src.Pictures ?? new List<Picture>()));
            CreateMap<Picture, PictureDto>().ForMember(dest=> dest.Likes, opt => opt.MapFrom(src => src.Likes()))
                .ForMember(dest => dest.Dislikes, opt => opt.MapFrom(src => src.Dislikes()))
                .ReverseMap();
        }
        
    }
}
