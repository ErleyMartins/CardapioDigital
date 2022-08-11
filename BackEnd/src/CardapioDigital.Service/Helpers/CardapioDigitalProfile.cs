using AutoMapper;
using CardapioDigital.Domain.Model;
using CardapioDigital.Service.DTOs;

namespace CardapioDigital.Service.Helpers
{
    public class CardapioDigitalProfile : Profile
    {
        public CardapioDigitalProfile()
        {
            CreateMap<Bebida, BebidaDto>().ReverseMap();
            CreateMap<Borda, BordaDto>().ReverseMap();
            CreateMap<CategoriaBebida, CategoriaBebidaDto>().ReverseMap();
            CreateMap<CategoriaPizza, CategoriaPizzaDto>().ReverseMap();

            CreateMap<Pizza, PizzaDto>().ReverseMap();
            CreateMap<Pizza, PizzaDtoGet>().ReverseMap();
            
            CreateMap<Tamanho, TamanhoDto>().ReverseMap();
            CreateMap<Tamanho, TamanhoDtoGet>().ReverseMap();
            
            CreateMap<Tipo, TipoDto>().ReverseMap();
            CreateMap<Tipo, TipoDtoGet>().ReverseMap();

            CreateMap<TamanhoPizza, TamanhoPizzaDto>().ReverseMap();

            CreateMap<PrecoPizza, PrecoPizzaDto>().ReverseMap();
            CreateMap<PrecoPizza, PrecoPizzaDtoGet>().ReverseMap();
        }
    }
}