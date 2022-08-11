namespace CardapioDigital.Service.DTOs
{
    public class TamanhoDto
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public ICollection<PizzaDto> Pizzas { get; set; }
        public ICollection<TamanhoPizzaDto> TamanhosPizzas { get; set; }

        public ICollection<PrecoPizzaDto> PrecosPizzas { get; set; }

    }
}