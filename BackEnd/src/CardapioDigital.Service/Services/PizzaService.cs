using AutoMapper;
using CardapioDigital.Data.Interface;
using CardapioDigital.Domain.Model;
using CardapioDigital.Service.DTOs;
using CardapioDigital.Service.Interfaces;

namespace CardapioDigital.Service.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepositorio _repositorio;
        private readonly IMapper _mapper;
        private readonly ITamanhoRepositorio _tamanhoRepositorio;

        public PizzaService(IPizzaRepositorio repositorio, ITamanhoRepositorio tamanhoRepositorio, IGeralRepositorio geralRepo, IMapper mapper)
        {
            _tamanhoRepositorio = tamanhoRepositorio;
            _repositorio = repositorio;
            _mapper = mapper;
        }

        public async Task<PizzaDto> Add(PizzaDto pizzaDto)
        {
            try
            {
                if (await _repositorio.GetBySaborAsync(pizzaDto.Nome) != null) return null;

                var pizza = _mapper.Map<Pizza>(pizzaDto);
                _repositorio.Add<Pizza>(pizza);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao gravar a pizza no banco de dados");

                return _mapper.Map<PizzaDto>(pizza);
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
                var pizza = await _repositorio.GetByIdAsync(id);
                if (pizza == null) return false;

                _repositorio.Delete<Pizza>(pizza);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao deletar a categoria da pizza informada");

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PizzaDtoGet[]> GetAllAsync()
        {
            try
            {
                var pizzas = await _repositorio.GetAllAsync();

                return _mapper.Map<PizzaDtoGet[]>(pizzas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PizzaDto> GetByIdAsync(int id)
        {
            try
            {
                var pizza = await _repositorio.GetByIdAsync(id);

                return _mapper.Map<PizzaDto>(pizza);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PizzaDto> GetBySaborAsync(string sabor)
        {
            try
            {
                var pizza = await _repositorio.GetBySaborAsync(sabor);

                return _mapper.Map<PizzaDto>(pizza);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PizzaDto> Update(PizzaDto pizzaDto)
        {
            try
            {
                var pizza = await _repositorio.GetByIdAsync(pizzaDto.Id);
                if (pizza == null) throw new Exception("A pizza que você esta tentando atualizar não existe");

                _mapper.Map(pizzaDto, pizza);
                _repositorio.Update<Pizza>(pizza);

                if (!await _repositorio.SaveChangesAsync()) throw new Exception("Ocorreu um erro ao atualizar a pizza");

                return _mapper.Map<PizzaDto>(pizza);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}