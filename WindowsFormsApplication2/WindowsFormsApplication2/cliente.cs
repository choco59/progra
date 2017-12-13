using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication2
{
    public class cliente
    {
        public int ci {get;set; }
        public string nombre{get;set;}
        public cliente() { }
        public cliente(int pci, string pnombre)
        {
            this.ci = pci;
            this.nombre = pnombre;
        }
    }
}
