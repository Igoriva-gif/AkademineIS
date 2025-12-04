using System;
using System.Collections.Generic;
using System.Text;

namespace AkademineIS.Models
{
public class Studentas : Naudotojas
    {
     public int GrupeId { get; set; }

     public override string RodytiInformacija()
     {
         return $"Studentas: {Vardas} {Pavarde}, grupė: {GrupeId}";
     }
   }
}
