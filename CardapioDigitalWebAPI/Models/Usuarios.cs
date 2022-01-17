namespace CardapioDigitalWebAPI.Models
{
    public class Usuarios
    {
        private int USR_ID;
        private string USR_LOGIN;
        private string USR_PASSWORD;
        private string USR_NAME;

        private int USR_LOCKED;

        public int USR_ID1 {get => USR_ID; set => USR_ID = value; } 
        public string USR_LOGIN1 {get => USR_LOGIN; set => USR_LOGIN = value; } 
        public string USR_PASSWORD1 {get => USR_PASSWORD; set => USR_PASSWORD = value; }
        public string USR_NAME1 {get => USR_NAME; set => USR_NAME = value; }
        public int USR_LOCKED1 {get => USR_LOCKED; set => USR_LOCKED = value; }

        public Usuarios()
        {
            
        }

        public Usuarios(int usr_id, string usr_login, string usr_password, string usr_name, int usr_locked)
        {
            this.USR_ID1 = usr_id;
            this.USR_LOGIN1 = usr_login;
            this.USR_PASSWORD1 = usr_password;
            this.USR_NAME1 = usr_name;
            this.USR_LOCKED1 = usr_locked;
        }
    }
}