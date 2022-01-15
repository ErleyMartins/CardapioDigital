namespace CardapioDigitalWebAPI.Models
{
    public class Pizzas
    {
        private int PIZ_ID;
        private string PIZ_NOME; 
        private string PIZ_DESC;
        private decimal PIZ_MEDIA;
        private decimal PIZ_GRANDE;
        private decimal PIZ_TREM;

        public int PIZ_ID1 {get => PIZ_ID; set => PIZ_ID = value; } 
        public string PIZ_NOME1 {get => PIZ_NOME; set => PIZ_NOME = value; } 
        public string PIZ_DESC1 {get => PIZ_DESC; set => PIZ_DESC = value; }
        public decimal PIZ_MEDIA1 {get => PIZ_MEDIA; set => PIZ_MEDIA = value; }
        public decimal PIZ_GRANDE1 {get => PIZ_GRANDE; set => PIZ_GRANDE = value; }
        public decimal PIZ_TREM1 {get => PIZ_TREM; set => PIZ_TREM = value; }

        public Pizzas(int piz_id, string piz_nome, string piz_desc, decimal piz_media, decimal piz_grande, decimal piz_trem)
        {
            this.PIZ_ID1 = piz_id;
            this.PIZ_NOME1 = piz_nome;
            this.PIZ_DESC1 = piz_desc;
            this.PIZ_MEDIA1 = piz_media;
            this.PIZ_GRANDE1 = piz_grande;
            this.PIZ_TREM1 = piz_trem;
        }

        public Pizzas()
        {
            
        }
    }
}