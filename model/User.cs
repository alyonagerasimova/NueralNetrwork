namespace NueralNetrwork.model
{
    public class User
    {
        private string email;
        private string password;

        public string getEmail() {
            return email;
        }

        public void setEmail(string email) {
            this.email = email;
        }

        public string getPassword() {
            return password;
        }

        public void setPassword(string password) {
            this.password = password;
        }

        public User(string email, string password) {
            this.email = email;
            this.password = password;
        }
    }
}