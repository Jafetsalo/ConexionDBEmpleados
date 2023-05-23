using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ConexionBDEmpleados
{
    internal class Empleado
    {
        public int IDEmpleado;
        public string Apellido;
        public string Nombre;
        public string Direccion;
        public string Email;

        
    }
}

/*idempleado INTEGER PRIMARY KEY,
apellido VARCHAR(50) NOT NULL,
nombre VARCHAR(50) NOT NULL,
direccion VARCHAR(100) NOT NULL,
email VARCHAR(50) NOT NULL*/
