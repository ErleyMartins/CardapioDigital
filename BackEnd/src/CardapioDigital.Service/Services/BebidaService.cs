using AutoMapper;
using CardapioDigital.Data.Context;
using CardapioDigital.Data.Interface;
using CardapioDigital.Domain.Model;
using CardapioDigital.Service.DTOs;
using CardapioDigital.Service.Interfaces;

namespace CardapioDigital.Service.Services
{
    public class BebidaService : IBebidaService
    {
        private readonly IBebidaRepositorio _repositorio;
        private readonly IMapper _mapper;
        private readonly CardapioDigitalContext _context;
        public BebidaService(IBebidaRepositorio repositorio, IGeralRepositorio geralRepositorio, CardapioDigitalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _repositorio = repositorio;
        }

        public async Task<BebidaDto> Add(BebidaDto bebidaDto)
        {
            try
            {
                if (await _repositorio.GetByNomeAsync(bebidaDto.Nome) != null) return null;

                var bebida = _mapper.Map<Bebida>(bebidaDto);

                var categoria = _context.CategoriasBebidas.Local.SingleOrDefault(categoria => categoria.Id == bebida.CategoriaBebida.Id);
            
                if (categoria != null) bebida.CategoriaBebida = categoria;
                else _context.Attach(bebida.CategoriaBebida);

                _repositorio.Add<Bebida>(bebida);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao gravar uma bebida no banco de dados");

                return _mapper.Map<BebidaDto>(bebida);
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
                var bebida = await _repositorio.GetByIdAsync(id);
                if (bebida == null) throw new Exception("Bebida para deletar não encontrada");

                _repositorio.Delete<Bebida>(bebida);

                return await _repositorio.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BebidaDto[]> GetAllAsync()
        {
            try
            {
                var bebidas = await _repositorio.GetAllAsync();

                return _mapper.Map<BebidaDto[]>(bebidas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BebidaDto> GetByIdAsync(int id)
        {
            try
            {
                var bebida = await _repositorio.GetByIdAsync(id);

                return _mapper.Map<BebidaDto>(bebida);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BebidaDto> GetByNomeAsync(string nome)
        {
            try
            {
                var bebida = await _repositorio.GetByNomeAsync(nome);

                return _mapper.Map<BebidaDto>(bebida);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BebidaDto> Update(BebidaDto bebidaDto)
        {
            try
            {
                var bebida = await _repositorio.GetByIdAsync(bebidaDto.Id);
                if (bebida == null) throw new Exception("A bebida que você esta tentando atualizar não existe");

                _mapper.Map(bebidaDto, bebida);
                _repositorio.Update<Bebida>(bebida);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao atualizar a bebida");

                return _mapper.Map<BebidaDto>(bebida);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}