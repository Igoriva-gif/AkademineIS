using System;
using System.Collections.Generic;
using System.Text;

namespace AkademineIS.Models
{
public class Destytojas : Naudotojas
     { 
     public override string RodytiInformacija()
     {
         return $"Destytojas: {Vardas} {Pavarde}";
     }
   }
}