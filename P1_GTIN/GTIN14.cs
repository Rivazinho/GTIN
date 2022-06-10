using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_GTIN
{
     class GTIN14 : Codigo
     {

        string denominacion, tipoCaja, gtin13; int cantidad;

        //Constructor de copia para GTIN14 a partir de GTIN13. Llama además al constructor de Código con el GTIN13 pasado.
        public GTIN14(string GTIN13, string denominacion_, string tipoCaja_, int cantidad_) : base(tipoCaja_ + GTIN13.Substring(0, 12), false)
        {
            //Asignacion de valores
            denominacion = denominacion_;
            cantidad = cantidad_;
            tipoCaja = tipoCaja_;
            gtin13 = GTIN13;
            //Se genera el GTIN14 a partir de los datos suministrados. Se añade el tipo de caja + el GTIN13 sin el dígito y se añade el nuevo
        }

        //Constructor objeto de clase GTIN14 a partir de un código GTIN14 del que se indica si ya tiene o no dígito control. Si no lo tiene
        //se calcula y se añade.
        public GTIN14(string gtin14, bool digito, string denominacion_,  int cantidad_) : base(gtin14, digito)
        {
            denominacion = denominacion_;
            cantidad = cantidad_;
            gtin13 = anadeDigitoControl(gtin14.Substring(1, 12));
        }

        //Propiedades para la clase GTIN14
        public string DigitoCaja
        {
            get
            {
                return gtin13;
            }
        }
        public int Cantidad
        {
            get
            {
                return cantidad;
            }
        }
        public string Gtin13
        {
            get
            {
                return referencia;
            }
        }
        public string Nombre
        {
            get
            {
                return denominacion;
            }
        }
     }
}
