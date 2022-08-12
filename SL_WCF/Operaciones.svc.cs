using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Operaciones" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Operaciones.svc or Operaciones.svc.cs at the Solution Explorer and start debugging.
    public class Operaciones : IOperaciones
    {
        public string Saludar(string Nombre)
        {
            return "Hola" + Nombre;
        }
        public int Suma(int Numero1, int Numero2)
        {
            int Resultado; 
            Resultado = Numero1 + Numero2;
            return (Resultado);
        }
        public int Resta( int Numero1, int Numero2)
        {
            int Resultado; 
            Resultado = Numero1 - Numero2;
            return (Resultado);
        }
        public int Multiplicacion(int Numero1, int Numero2)
        {
            int Resultado;
            Resultado = Numero1 * Numero2;
            return Resultado;
        }
        public int Division(int Numero1, int Numero2)
        {
            int Resultado; 
            Resultado = Numero1 / Numero2;
            return Resultado;
        }
    }
}
