using System;
using System.Collections.Generic;

namespace LeerCodigoaMorse
{
    public class Program
    {
        public static string error = string.Empty;
        public static List<string> letras = new List<string>();
        public static List<string> letrasMorse = new List<string>();
        public static string MError = "....--.....---..-...-..";
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Ingrese palabra");
                string palabra = Console.ReadLine();
                //Convertir palabra a morse
                string response = convertirMorse(palabra);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                Console.WriteLine(error);
                throw;
            }

        }
        public static string convertirMorse(string palabra)
        {
            try
            {
                int linea = 0;
                string letra;
                for ( linea = 0; linea < palabra.Length; linea++)
                {
                     letra = palabra.Substring(linea, 1);
                    letras.Add(letra);
                }   
                Console.WriteLine(letras);

                //Conversión a morse
                foreach (var item in letras)
                {
                    string morse = tipificacion(ref error, item);
                    letrasMorse.Add(morse);
                }

                //imprimir palabre en morse
                foreach (var item in letrasMorse)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Termino mensaje");
                Console.ReadLine();
                return "True";
            }
            catch (Exception ex)
            {
                error = ex.Message;
                Console.WriteLine(error);
                return error;
                //throw;
            }
        }
        public static string tipificacion(ref string error, string letra)
        {
            try
            {
                string conver = "";
                switch (letra)
                {
                    case "a" or "A":
                        conver = "· —";
                        break;
                    case "b" or "B":
                        conver = "— · · ·";
                        break;
                    case "c" or "C":
                        conver = "— · — ·";
                        break;
                    case "d" or "D":
                        conver = "— · ·";
                        break;
                    case "e" or "E":
                        conver = "·";
                        break;
                    case "f" or "F":
                        conver = "· · — ·";
                        break;
                    case "g" or "G":
                        conver = "— — ·";
                        break;
                    case "h" or "H":
                        conver = "· · · ·";
                        break;
                    case "i" or "I":
                        conver = "· ·";
                        break;
                    case "j" or "J":
                        conver = "· — — —";
                        break;
                    case "k" or "K":
                        conver = "— · —";
                        break;
                    case "l" or "L":
                        conver = "· — · ·";
                        break;
                    case "m" or "M":
                        conver = "— —";
                        break;
                    case "n" or "N":
                        conver = "— ·";
                        break;
                    case "ñ" or "Ñ":
                        conver = "— — · — —";
                        break;
                    case "o" or "O":
                        conver = "— — —";
                        break;
                    case "p" or "P":
                        conver = "· — — ·";
                        break;
                    case "q" or "Q":
                        conver = "— — · —";
                        break;
                    case "r" or "R":
                        conver = "· — ·";
                        break;
                    case "s" or "S":
                        conver = "· · ·";
                        break;
                    case "t" or "T":
                        conver = "—";
                        break;
                    case "u" or "U":
                        conver = "· · —";
                        break;
                    case "v" or "V":
                        conver = "· · · —";
                        break;
                    case "w" or "W":
                        conver = "· — —";
                        break;
                    case "x" or "X":
                        conver = "— · · —";
                        break;
                    case "y" or "Y":
                        conver = "— · — —";
                        break;
                    case "z" or "Z":
                        conver = "— — · ·";
                        break;
                    case "0":
                        conver = "— — — — —";
                        break;
                    case "1":
                        conver = "· — — — —";
                        break;
                    case "2":
                        conver = "· · — — —";
                        break;
                    case "3":
                        conver = "· · · — —";
                        break;
                    case "4":
                        conver = "· · · · —";
                        break;
                    case "5":
                        conver = "· · · · ·";
                        break;
                    case "6":
                        conver = "— · · · ·";
                        break;
                    case "7":
                        conver = "— — · · ·";
                        break;
                    case "8":
                        conver = "— — — · ·";
                        break;
                    case "9":
                        conver = "— — — — ·";
                        break;
                    case "." :
                        conver = "· — · — · —";
                        break;
                    case "," :
                        conver = "— — · · — —";
                        break;
                    case "\"" :
                        conver = "· — · · — ·";
                        break;
                    case "/":
                        conver = "— · · — ·";
                        break;
                    case "?" or "¿":
                        conver = "· · — — · ·";
                        break;
                    case "" or " ":
                        conver = "  ";
                        break;
                    default:
                        conver = MError;
                        break;
                }
                return conver;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                Console.WriteLine(error);
                return error;
                //throw;
            }
        }
    }
}
