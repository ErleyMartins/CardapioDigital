using AutoMapper;
using CardapioDigital.Data.Interface;
using CardapioDigital.Domain.Model;
using CardapioDigital.Service.DTOs;
using CardapioDigital.Service.Interfaces;

namespace CardapioDigital.Service.Services
{
    public class BordaService : IBordaService
    {
        private readonly IBordaRepositorio _repositorio;
        private readonly IMapper _mapper;

        public BordaService(IBordaRepositorio repositorio, IGeralRepositorio geralRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }

        public async Task<BordaDto> Add(BordaDto bordaDto)
        {
            try
            {
                if (await _repositorio.GetByDescricaoAsync(bordaDto.Descricao) != null) return null;

                var borda = _mapper.Map<Borda>(bordaDto);
                _repositorio.Add<Borda>(borda);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao gravar a borda no banco de dados");

                return _mapper.Map<BordaDto>(borda);
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
                var borda = await _repositorio.GetByIdAsync(id);
                if (borda == null) return false;

                _repositorio.Delete<Borda>(borda);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao deletar a borda informada");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BordaDto[]> GetAllAsync()
        {
            try
            {
                var bordas = await _repositorio.GetAllAsync();

                return _mapper.Map<BordaDto[]>(bordas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BordaDto> GetByDescricaoAsync(string descricao)
        {
            try
            {
                var borda = await _repositorio.GetByDescricaoAsync(descricao);

                return _mapper.Map<BordaDto>(borda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BordaDto> GetByIdAsync(int id)
        {
            try
            {
                var borda = await _repositorio.GetByIdAsync(id);

                return _mapper.Map<BordaDto>(borda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BordaDto> Update(BordaDto bordaDto)
        {
            try
            {
                var borda = await _repositorio.GetByIdAsync(bordaDto.Id);
                if (borda == null) throw new Exception("A borda que você esta tentando atualizar não existe");

                _mapper.Map(bordaDto, borda);
                _repositorio.Update<Borda>(borda);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao atualizar a borda");

                return _mapper.Map<BordaDto>(borda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}