using LojaoBazarDDD.Domain.Core.Interfaces.Services;
using LojaoBazarDDD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Application
{
    public class ApplicationServiceClienteVerify : IClienteSession
    {
        private readonly int currentId=0;

        public ApplicationServiceClienteVerify()
        {
            
        }

        public bool ClienteSessionVerify(int id)
        {
            if (currentId == id)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }
    }
}
