using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meeting_test.domain
{
   
    public class UserInfo
    {
        private String username;
        private String passwd;
        private String type;
        private String state;


        public string Username
        {
            get => username;
            set => username = value;
        }

        public string Passwd
        {
            get => passwd;
            set => passwd = value;
        }

        public string Type
        {
            get => type;
            set => type = value;
        }

        public string State
        {
            get => state;
            set => state = value;
        }
    }
}
