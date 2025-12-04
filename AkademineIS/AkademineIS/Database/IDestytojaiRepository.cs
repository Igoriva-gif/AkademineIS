using System;
using System.Collections.Generic;
using System.Text;
using AkademineIS.Models;

namespace AkademineIS.Database
{
    public interface IDestytojaiRepository
    {
        IEnumerable<DestytojoEile> GetAll();
        void AddDestytojas(string vardas, string pavarde, string login, string password);
        void DeleteDestytojas(int destytojasId);
    }
}