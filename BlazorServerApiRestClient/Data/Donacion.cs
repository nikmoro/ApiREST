using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApiRestClient.Data
{
    public class Donacion
    {
        public int id { get; set; } = 0;
        public string nombre_mpio { get; set; } = "";
        public string nombre_arbol { get; set; } = "";
        public int cantidad { get; set; } = 0;
    }
}
