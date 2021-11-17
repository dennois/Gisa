using System;
using System.Collections.Generic;
using System.Text;

namespace Gisa.Domain.Interfaces.Service
{
    public interface ITokenService
    {
        public string GenerateToken(Usuario usuario);
    }
}
