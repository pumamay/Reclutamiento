﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIRCasa.Reclutamiento.Entities.Dtos
{
    public class ClienteCreationDto
    {
        public string Nombre { get; set; } 
        public string Telefono { get; set; } 
        public string Correo { get; set; } 
        public int Edad { get; set; }
        public float MontoSolicitud { get; set; }
    }
}
