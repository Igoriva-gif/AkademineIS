using System;
using System.Collections.Generic;
using System.Text;
using AkademineIS.Models;

namespace AkademineIS.Database
{
    public interface IStudentaiRepository
    {
        IEnumerable<StudentoEile> GetAll();
        void AddStudentas(string vardas, string pavarde, string login, string password, string grupeId);
        void DeleteStudentas(int studentasId);
    }
}