using System;
using System.Collections.Generic;
using System.Text;
using AkademineIS.Models;

namespace AkademineIS.Database
{
    public interface INaudotojasRepository
    {
        Naudotojas? GetByLogin(string login);
    }
}
