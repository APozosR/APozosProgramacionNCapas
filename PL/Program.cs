using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args) {

            int Seleccion = 1;

            //Saludar
            //Console.WriteLine("Escribe un nombre");
            //string Nombre = Console.ReadLine();
            //OperacionesReference1.OperacionesClient obj = new OperacionesReference1.OperacionesClient();

            //string resultado = obj.Saludar(Nombre);
            //Console.WriteLine(resultado);

            //Suma
            //Console.WriteLine("Ingrese el primer número");
            //int Numero1 = int.Parse(Console.ReadLine());
            //Console.WriteLine("\nIngrese el segundo número");
            //int Numero2 = int.Parse(Console.ReadLine());

            //OperacionesReference1.OperacionesClient obj = new OperacionesReference1.OperacionesClient();

            //int Resultado = obj.Suma(Numero1, Numero2);
            //Console.WriteLine("\nEl resultado es: " + Resultado);

            //Resta
            //Console.WriteLine("Ingrese el primer número");
            //int Numero1 = int.Parse(Console.ReadLine());
            //Console.WriteLine("\nIngrese el segundo número");
            //int Numero2 = int.Parse(Console.ReadLine());

            //OperacionesReference1.OperacionesClient obj = new OperacionesReference1.OperacionesClient();

            //int Resultado = obj.Resta(Numero1, Numero2);
            //Console.WriteLine("\nEl resultado es: " + Resultado);

            //Multiplicación

            //Console.WriteLine("Ingrese el primer número");
            //int Numero1 = int.Parse(Console.ReadLine());
            //Console.WriteLine("\nIngrese el segundo número");
            //int Numero2 = int.Parse(Console.ReadLine());

            //OperacionesReference1.OperacionesClient obj = new OperacionesReference1.OperacionesClient();

            //int Resultado = obj.Multiplicacion(Numero1, Numero2);
            //Console.WriteLine("\nEl resultado es: " + Resultado);

            ////División
            //Console.WriteLine("Ingrese el primer número");
            //int Numero1 = int.Parse(Console.ReadLine());
            //Console.WriteLine("\nIngrese el segundo número");
            //int Numero2 = int.Parse(Console.ReadLine());

            //OperacionesReference1.OperacionesClient obj = new OperacionesReference1.OperacionesClient();

            //int Resultado = obj.Division(Numero1, Numero2);
            //Console.WriteLine("\nEl resultado es: " + Resultado);

            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Actualizar");
            Console.WriteLine("3. Borrar");
            Console.WriteLine("4. Consultar todos los registros");
            Console.WriteLine("5. Consultar un registro");
            Seleccion = int.Parse(Console.ReadLine());

            //switch (Seleccion)
            //{
            //    case 1:
            //        PL.Producto.Add();
            //        break;

            //    case 2:
            //        PL.Producto.Update();
            //       break;

            //    case 3:
            //        PL.Producto.Delete();
            //        break;

            //    case 4:
            //        PL.Producto.GetAll();
            //        break;

            //    case 5:
            //        PL.Producto.GetById();
            //        break;
            //}

            switch (Seleccion)
            {
                case 1:
                    PL.Usuario.Add();
                    break;

                case 2:
                    PL.Usuario.Update();
                    break;

                case 3:
                    PL.Usuario.Delete();
                    break;

                case 4:
                    PL.Usuario.GetAll();
                    break;

                case 5:
                    PL.Usuario.GetById();
                    break;
            }
        }
    }
}

