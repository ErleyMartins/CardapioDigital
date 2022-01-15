namespace CardapioDigitalWebAPI.Models
{
    public class Usuarios
    {
        private int USR_ID;
        private string USR_LOGIN;
        private byte[] USR_PASSWORD;
        private string USR_NAME;

        public int USR_ID1 {get => USR_ID; set => USR_ID = value; } 
        public string USR_LOGIN1 {get => USR_LOGIN; set => USR_LOGIN = value; } 
        public byte[] USR_PASSWORD1 {get => USR_PASSWORD; set => USR_PASSWORD = value; }
        public string USR_NAME1 {get => USR_NAME; set => USR_NAME = value; }

        public Usuarios()
        {
            
        }

        public Usuarios(int usr_id, string usr_login, byte[] usr_password, string usr_name)
        {
            this.USR_ID1 = usr_id;
            this.USR_LOGIN1 = usr_login;
            this.USR_PASSWORD1 = usr_password;
            this.USR_NAME1 = usr_name;
        }
    }
}