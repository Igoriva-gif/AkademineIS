using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using AkademineIS.Models;

namespace AkademineIS.Database;
    public interface IGrupesRepository
    {
        IEnumerable<Grupe> GetAll();
        void Add(Grupe grupe);
        void Delete(int id);
    }