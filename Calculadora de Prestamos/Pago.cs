using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_de_Prestamos
{
    class Pago
    {
        public short Mes { get; set; }
        public float Interes { get; set; }
        public float Cuota { get; set; }
        public float Amortizacion { get; set; }
        public float Saldo { get; set; }
        public Pago(short Mes, float Interes, float Cuota,float Amort, float Saldo)
        {
            this.Mes = Mes;
            this.Interes = Interes;
            this.Cuota = Cuota;
            Amortizacion = Amort;
            this.Saldo = Saldo;
        }
    }
}
