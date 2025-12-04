using System;
using System.Collections.Generic;
using System.Text;
using AkademineIS.Models;

namespace AkademineIS.Database
{
    public interface IDalykaiRepository
    {
        IEnumerable<Dalykas> GetAll();
        void Add(Dalykas dalykas);
        void Delete(int id);
    }
}