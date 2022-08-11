namespace CardapioDigital.Service.DTOs
{
    public class TamanhoPizzaDto
    {
        public int PizzaId { get; set; }
        public PizzaDto Pizza { get; set; }

        public int TamanhoId { get; set; }
        public TamanhoDto Tamanho { get; set; }
    }
}
