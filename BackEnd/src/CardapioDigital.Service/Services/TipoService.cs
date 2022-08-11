using AutoMapper;
using CardapioDigital.Data.Interface;
using CardapioDigital.Domain.Model;
using CardapioDigital.Service.DTOs;
using CardapioDigital.Service.Interfaces;

namespace CardapioDigital.Service.Services
{
    public class TipoService : ITipoService
    {
        private readonly ITipoRepositorio _repositorio;
        private readonly IMapper _mapper;

        public TipoService(ITipoRepositorio repositorio, IGeralRepositorio geral, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<TipoDto> Add(TipoDto tipoDto)
        {
            try
            {
                var tipo = _mapper.Map<Tipo>(tipoDto);
                _repositorio.Add<Tipo>(tipo);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao gravar o tipo no banco de dados");

                return _mapper.Map<TipoDto>(tipo);
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
                var tipo = await _repositorio.GetByIdAsync(id);
                if (tipo == null) return false;

                _repositorio.Delete<Tipo>(tipo);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao deletar o tipo informada");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TipoDto[]> GetAllAsync()
        {
            try
            {
                var tipos = await _repositorio.GetAllAsync();

                return _mapper.Map<TipoDto[]>(tipos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TipoDto> GetByIdAsync(int id)
        {
            try
            {
                var tipo = await _repositorio.GetByIdAsync(id);

                return _mapper.Map<TipoDto>(tipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TipoDto> Update(TipoDto tipoDto)
        {
            try
            {
                var tipo = await _repositorio.GetByIdAsync(tipoDto.Id);
                if (tipo == null) throw new Exception("O tipo que você esta tentando atualizar não existe");

                _mapper.Map(tipoDto, tipo);
                _repositorio.Update<Tipo>(tipo);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao atualizar o tipo da pizza");

                return _mapper.Map<TipoDto>(tipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}