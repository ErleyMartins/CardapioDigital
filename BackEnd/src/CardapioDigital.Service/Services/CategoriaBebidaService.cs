using AutoMapper;
using CardapioDigital.Data.Interface;
using CardapioDigital.Domain.Model;
using CardapioDigital.Service.DTOs;
using CardapioDigital.Service.Interfaces;

namespace CardapioDigital.Service.Services
{
    public class CategoriaBebidaService : ICategoriaBebidaService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaBebidaRepositorio _repositorio;

        public CategoriaBebidaService(ICategoriaBebidaRepositorio repositorio, IGeralRepositorio geral, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<CategoriaBebidaDto> Add(CategoriaBebidaDto categoriaBebidaDto)
        {
            try
            {
                if (await _repositorio.GetByDescricaoAsync(categoriaBebidaDto.Descricao) != null) return null;

                var categoriaBebida = _mapper.Map<CategoriaBebida>(categoriaBebidaDto);
                _repositorio.Add<CategoriaBebida>(categoriaBebida);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao gravar a categoria de bebida no banco de dados");

                return _mapper.Map<CategoriaBebidaDto>(categoriaBebida);
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
                var categoriaBebida = await _repositorio.GetByIdAsync(id);
                if (categoriaBebida == null) return false;

                _repositorio.Delete<CategoriaBebida>(categoriaBebida);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao deletar a categoria da bebida informada");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoriaBebidaDto[]> GetAllAsync()
        {
            try
            {
                var categoriasBebidas = await _repositorio.GetAllAsync();

                return _mapper.Map<CategoriaBebidaDto[]>(categoriasBebidas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoriaBebidaDto> GetByDescricaoAsync(string descricao)
        {
            try
            {
                var categoriasBebidas = await _repositorio.GetByDescricaoAsync(descricao);

                return _mapper.Map<CategoriaBebidaDto>(categoriasBebidas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoriaBebidaDto> GetByIdAsync(int id)
        {
            try
            {
                var categoriasBebidas = await _repositorio.GetByIdAsync(id);

                return _mapper.Map<CategoriaBebidaDto>(categoriasBebidas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoriaBebidaDto> Update(CategoriaBebidaDto categoriaBebidaDto)
        {
            try
            {
                var categoriaBebida = await _repositorio.GetByIdAsync(categoriaBebidaDto.Id);
                if (categoriaBebida == null) throw new Exception("A categoria de bebidas que você esta tentando atualizar não existe");

                _mapper.Map(categoriaBebidaDto, categoriaBebida);
                _repositorio.Update<CategoriaBebida>(categoriaBebida);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao atualizar a categoria de bebidas");

                return _mapper.Map<CategoriaBebidaDto>(categoriaBebida);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}