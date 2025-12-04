using System;
using System.Collections.Generic;
using System.Text;

namespace AkademineIS.Models
{
    public class Naudotojas
    {
        private int _id;
        private string? _vardas;
        private string? _pavarde;
        private string? _role;
        private string? _login;
        private string? _slaptazodis;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string? Vardas
        {
            get => _vardas;
            set => _vardas = value;
        }

        public string? Pavarde
        {
            get => _pavarde;
            set => _pavarde = value;
        }

        public string? Role
        {
            get => _role;
            set => _role = value;
        }

        public string? Login
        {
            get => _login;
            set => _login = value;
        }

        public string? Slaptazodis
        {
            get => _slaptazodis;
            set => _slaptazodis = value;
        }

        public virtual string RodytiInformacija()
        {
            return $"{Vardas} {Pavarde} ({Role})";
        }
    }
}
