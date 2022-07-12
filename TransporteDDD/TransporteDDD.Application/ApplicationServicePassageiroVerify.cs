using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteDDD.Domain.Interfaces;

namespace TransporteDDD.Application
{
    public class ApplicationServicePassageiroVerify : IPassageiroSession
    {
        private readonly int currentId = 0;
        public bool PassageiroSessionVerify(int id)
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
