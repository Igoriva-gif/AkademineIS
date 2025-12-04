using System;
using System.Collections.Generic;
using System.Text;
using AkademineIS.Database;
using AkademineIS.Models;

namespace AkademineIS.Servisai
{
    public class Autentifikacija
    {
        private readonly INaudotojasRepository _repo;

        public Autentifikacija(INaudotojasRepository repo)
        {
            _repo = repo;
        }

        public Naudotojas? Login(string login, string password)
        {
            var user = _repo.GetByLogin(login);
            if (user == null)
                return null;

            if (user.Slaptazodis == password)
                return user;

            return null;
        }
    }
}
