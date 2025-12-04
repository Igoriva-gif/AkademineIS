using System;
using System.Collections.Generic;
using System.Text;

namespace AkademineIS.Models
{
public class Administratorius : Naudotojas
        {
        public override string RodytiInformacija()
        {
            return $"Administratorius: {Vardas} {Pavarde}";
        }
    }
}