using AutoMapper;
using CardapioDigital.Data.Interface;
using CardapioDigital.Domain.Model;
using CardapioDigital.Service.DTOs;
using CardapioDigital.Service.Interfaces;

namespace CardapioDigital.Service.Services
{
    public class TamanhoService : ITamanhoService
    {
        private readonly ITamanhoRepositorio _repositorio;
        private readonly IMapper _mapper;
        public TamanhoService(ITamanhoRepositorio repositorio, IGeralRepositorio geral, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<TamanhoDto> Add(TamanhoDto tamanhoDto)
        {
            try
            {
                if (await _repositorio.GetByDescricaoAsync(tamanhoDto.Descricao) != null) return null;

                var tamanho = _mapper.Map<Tamanho>(tamanhoDto);
                _repositorio.Add<Tamanho>(tamanho);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao gravar o tamanho no banco de dados");

                return _mapper.Map<TamanhoDto>(tamanho);
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
                var tamanho = await _repositorio.GetByIdAsync(id);
                if (tamanho == null) return false;

                _repositorio.Delete<Tamanho>(tamanho);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao deletar o tamanho da pizza informada");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TamanhoDto[]> GetAllAsync()
        {
            try
            {
                var tamanhos = await _repositorio.GetAllAsync();

                return _mapper.Map<TamanhoDto[]>(tamanhos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TamanhoDto> GetByDescricaoAsync(string descricao)
        {
            try
            {
                var tamanho = await _repositorio.GetByDescricaoAsync(descricao);

                return _mapper.Map<TamanhoDto>(tamanho);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TamanhoDto> GetByIdAsync(int id)
        {
            try
            {
                var tamanho = await _repositorio.GetByIdAsync(id);

                return _mapper.Map<TamanhoDto>(tamanho);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TamanhoDto> Update(TamanhoDto tamanhoDto)
        {
            try
            {
                var tamanho = await _repositorio.GetByIdAsync(tamanhoDto.Id);
                if (tamanho == null) throw new Exception("O tamanho que você esta tentando atualizar não existe");

                _mapper.Map(tamanhoDto, tamanho);
                _repositorio.Update<Tamanho>(tamanho);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao atualizar o tamanho da pizza");

                return _mapper.Map<TamanhoDto>(tamanho);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}