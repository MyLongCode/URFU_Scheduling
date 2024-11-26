using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URFU_Scheduling_lib.Domain.Interfaces
{
    public interface IRegistrationData
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
