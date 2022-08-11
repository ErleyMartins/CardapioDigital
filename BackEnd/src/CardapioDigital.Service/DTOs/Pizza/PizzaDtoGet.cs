namespace CardapioDigital.Service.DTOs
{
    public class PizzaDtoGet
    {
        public int Id { get; set; }

        public CategoriaPizzaDto CategoriaPizza { get; set; }

        public TipoDtoGet Tipo { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public ICollection<PrecoPizzaDtoGet> PrecosPizzas { get; set; }

    }
}