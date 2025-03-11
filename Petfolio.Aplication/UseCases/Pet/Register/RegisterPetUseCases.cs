using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Petfolio.comunication.Request;
using Petfolio.comunication.Responses;

namespace Petfolio.aplication.UseCases.Pet.Register
{
    public class RegisterPetUseCases
    {
        public ResponseRegisterPet execute(RegisterPet request)
        {
            return new ResponseRegisterPet
            {
                id = 0,
                name = request.Name,
            };
        }

    }
}
