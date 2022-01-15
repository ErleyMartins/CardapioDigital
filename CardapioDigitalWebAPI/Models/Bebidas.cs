namespace CardapioDigitalWebAPI.Models
{
    public class Bebidas
    {
        private int BEB_ID;
        private string BEB_NOME; 
        private string BEB_DESC;
        private string BEB_TIPO;
        private string BEB_UM;
        private decimal BEB_VALOR;

        public int BEB_ID1 {get => BEB_ID; set => BEB_ID = value; } 
        public string BEB_NOME1 {get => BEB_NOME; set => BEB_NOME = value; } 
        public string BEB_DESC1 {get => BEB_DESC; set => BEB_DESC = value; }
        public string BEB_TIPO1 {get => BEB_TIPO; set => BEB_TIPO = value; }
        public string BEB_UM1 {get => BEB_UM; set => BEB_UM = value; }
        public decimal BEB_VALOR1 {get => BEB_VALOR; set => BEB_VALOR = value; }

        public Bebidas()
        {
            
        }

        public Bebidas(int beb_id, string beb_nome, string beb_desc, string beb_tipo, string beb_um, decimal beb_valor)
        {
            this.BEB_ID1 = beb_id;
            this.BEB_NOME1 = beb_nome;
            this.BEB_DESC1 = beb_desc;
            this.BEB_TIPO1 = beb_tipo;
            this.BEB_UM1 = beb_um;
            this.BEB_VALOR1 = beb_valor;
        }
    }
}