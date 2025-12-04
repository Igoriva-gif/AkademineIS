using System;
using System.Collections.Generic;
using System.Text;
using AkademineIS.Models;

namespace AkademineIS.Database
{
    public interface IStudentaiRepository
    {
        IEnumerable<StudentoEile> GetAll();
        void AddStudent(string vardas, string pavarde, string login, string password, int grupeId);
        void DeleteStudent(int studentasId);
        void PridetiStudenta(string vardas, string pavarde, string login, string password);
    }
}