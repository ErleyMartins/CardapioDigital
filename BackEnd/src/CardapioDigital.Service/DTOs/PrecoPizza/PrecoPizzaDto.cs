namespace CardapioDigital.Service.DTOs
{
    public class PrecoPizzaDto
    {
        public int Id { get; set; }

        public decimal Valor { get; set; }

        public int TamanhoId { get; set; }

        public TamanhoDto Tamanho { get; set; }

        public int PizzaId { get; set; }

        public PizzaDto Pizza { get; set; }

    }
}