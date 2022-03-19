using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEquitel.Core
{
    public class FileCore
    {
        static object objlock = new object();
        private string _directory = string.Empty;
        private string _fileRead = string.Empty;
        private string _fileResult = string.Empty;

        public FileCore()
        {
            _directory = ConfigurationManager.AppSettings["Directory"];
            _fileRead = ConfigurationManager.AppSettings["FileRead"];
            _fileResult = ConfigurationManager.AppSettings["FileResult"];
        }

        private string Text()
        {
            string text = string.Empty;
            lock (objlock)
            {
                using (StreamReader sr = new StreamReader(_fileRead, Encoding.UTF8))
                {
                    text = sr.ReadToEnd();
                }
            }

            return text;
        }

        private void WirteText(string message)
        {
            lock (objlock)
            {
                using (StreamWriter sw = new StreamWriter(_fileResult, true))
                {
                    sw.WriteLine(message);
                }
            }
        }

        public void ItemUno()
        {
            int count = 0;
            string message = string.Empty;
            string[] splitText = Text()?.Split(' ');

            foreach (string item in splitText)
            {
                if (item.Contains("n"))
                {
                    count++;
                }
            }
            message = "Para el ejercicio uno se encontraron " + count + " palabras";

            WirteText(message);

            Console.WriteLine(message);
        }

        public void ItemDos()
        {
            int count = 0;
            string message = string.Empty;
            string[] splitText = Text()?.Split('.');

            foreach (string item in splitText)
            {
                if (item.Count() > 15)
                {
                    count++;
                }
            }

            message = "Para el ejercicio dos se encontraron " + count + " oraciones";
            WirteText(message);

            Console.WriteLine(message);
        }

        public void ItemTres()
        {
            int count = 0;
            string message = string.Empty;
            string[] splitText = Text()?.Split('\n');

            foreach (string item in splitText)
            {
                if (item != "\r")
                    count++;
            }

            message = "Para el ejercicio tres se encontraron " + count + " parrafos";
            WirteText(message);

            Console.WriteLine(message);
        }

        private bool ValidateCaracter(char item)
        {
            if (!item.Equals("N".ToLower())
                || !item.Equals("|")
                || !item.Equals("°")
                || !item.Equals("!")
                || !item.Equals("\"")
                || !item.Equals("#")
                || !item.Equals("$")
                || !item.Equals("%")
                || !item.Equals("&")
                || !item.Equals("/")
                || !item.Equals("(")
                || !item.Equals(")")
                || !item.Equals("=")
                || !item.Equals("?")
                || !item.Equals("¡")
                || !item.Equals("¿")
                || !item.Equals("*")
                || !item.Equals("-")
                || !item.Equals("+")
                || !item.Equals(".")
                || !item.Equals("<")
                || !item.Equals(">")
                || !item.Equals(",")
                || !item.Equals(";")
                || !item.Equals(":")
                || !item.Equals("_")
                || !item.Equals("}")
                || !item.Equals("]")
                || !item.Equals("`")
                || !item.Equals(" ")
                || !item.Equals("{")
                || !item.Equals("[")
                || !item.Equals("¨")
                || !item.Equals("´")
                || !item.Equals("~")
                || !item.Equals("'")
                )
                return true;
            else
                return false;
        }
        public void ItemCuatro()
        {
            int count = 0;
            string message = string.Empty;
            string text = Text();

            foreach (char item in text)
            {
                if (ValidateCaracter(item))
                    count++;
            }

            message = "Para el ejercicio cuatro se encontraron " + count + " caracteres";
            WirteText(message);

            Console.WriteLine(message);
        }



    }
}
