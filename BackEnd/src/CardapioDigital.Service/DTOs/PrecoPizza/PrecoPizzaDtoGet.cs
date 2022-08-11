namespace CardapioDigital.Service.DTOs
{
    public class PrecoPizzaDtoGet
    {
        public int Id { get; set; }

        public decimal Valor { get; set; }

        public TamanhoDtoGet Tamanho { get; set; }
    }
}