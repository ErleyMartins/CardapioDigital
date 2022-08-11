using AutoMapper;
using CardapioDigital.Data.Interface;
using CardapioDigital.Domain.Model;
using CardapioDigital.Service.DTOs;
using CardapioDigital.Service.Interfaces;

namespace CardapioDigital.Service.Services
{
    public class CategoriaPizzaService : ICategoriaPizzaService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaPizzaRepositorio _repositorio;
        
        public CategoriaPizzaService(ICategoriaPizzaRepositorio repositorio, IGeralRepositorio geral, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<CategoriaPizzaDto> Add(CategoriaPizzaDto categoriaPizzaDto)
        {
            try
            {
                if (await _repositorio.GetByDescricaoAsync(categoriaPizzaDto.Categoria) != null) return null;

                var categoriaPizza = _mapper.Map<CategoriaPizza>(categoriaPizzaDto);
                _repositorio.Add<CategoriaPizza>(categoriaPizza);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao gravar a categoria da pizza no banco de dados");

                return _mapper.Map<CategoriaPizzaDto>(categoriaPizza);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var categoriaPizza = await _repositorio.GetByIdAsync(id);
                if (categoriaPizza == null) return false;

                _repositorio.Delete<CategoriaPizza>(categoriaPizza);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao deletar a categoria da pizza informada");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoriaPizzaDto[]> GetAllAsync()
        {
            try
            {
                var categoriasPizzas = await _repositorio.GetAllAsync();

                return _mapper.Map<CategoriaPizzaDto[]>(categoriasPizzas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoriaPizzaDto> GetByDescricaoAsync(string descricao)
        {
            try
            {
                var categoriaPizza = await _repositorio.GetByDescricaoAsync(descricao);

                return _mapper.Map<CategoriaPizzaDto>(categoriaPizza);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoriaPizzaDto> GetByIdAsync(int id)
        {
            try
            {
                var categoriaPizza = await _repositorio.GetByIdAsync(id);

                return _mapper.Map<CategoriaPizzaDto>(categoriaPizza);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoriaPizzaDto> Update(CategoriaPizzaDto categoriaPizzaDto)
        {
            try
            {
                var categoriaPizza = await _repositorio.GetByIdAsync(categoriaPizzaDto.Id);
                if (categoriaPizza == null) throw new Exception("A categoria de pizzas que você esta tentando atualizar não existe");

                _mapper.Map(categoriaPizzaDto, categoriaPizza);
                _repositorio.Update<CategoriaPizza>(categoriaPizza);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao atualizar a categoria de pizza");

                return _mapper.Map<CategoriaPizzaDto>(categoriaPizza);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}