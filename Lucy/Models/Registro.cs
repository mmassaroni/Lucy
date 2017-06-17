using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lucy.Models
{
    public class Registro
    {
        public ModelCL.Usuario Usuario { get; set; }
        public ModelCL.Persona Persona { get; set; }
    }
}