using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Petfolio.Comunication.Enum;

namespace Petfolio.comunication.Request
{
    public class RegisterPet
    {
        public string Name { get; set; }
        public DateTime Ano { get; set; }
        public PetType Type { get; set; }

    }
}
