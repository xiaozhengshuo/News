using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsModels
{
    [Serializable()]
    public class User
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string loginName = String.Empty;

        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }
        private string loginPwd = String.Empty;

        public string LoginPwd
        {
            get { return loginPwd; }
            set { loginPwd = value; }
        }
        private string realName = String.Empty;

        public string RealName
        {
            get { return realName; }
            set { realName = value; }
        }
        private string address = String.Empty;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string phone = String.Empty;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string email = String.Empty;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string role = String.Empty;

        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        public User() { }
    }
}
