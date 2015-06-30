using System;
using System.Linq;

namespace Publicaciones.Dao
{
    public class EnviromentRes
    {
        private readonly string username;
        private readonly string localMachine;
        
        public string Username
        {
            get
            {
                return Environment.UserName;
            }
        }

        public string LocalMachine
        {
            get
            {
                return Environment.MachineName;
            }
        }
    }
}
