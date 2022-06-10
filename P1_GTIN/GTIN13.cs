using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_GTIN
{
    class GTIN13 : Codigo
    {
        string denominacion; 
        List<GTIN14> lista = new List<GTIN14>(); //Creamos una lista en la que iremos añadiendo los GTIN14
        public GTIN13(string referencia_, bool digito_, string denominacion_) : base (referencia_, digito_) //Constructor
        {
            denominacion = denominacion_;
        }
        public void anadeGtin14(GTIN14 cajas) // El método es VOID porque no devuelve ningún valor. En el MAIN cuando se llama a la función tampoco se recoge nada
        {
            lista.Add(cajas); 
        }
        public List<string> getCodigosGtin14()
        {
            int i;
            List<string> listaaux = new List<string>(); // Recorremos la lista y añadimos en una lista auxiliar las referencias (guardadas en la propiedad Texto)
            for (i = 0; i < lista.Count; i++)
            {
                listaaux.Add(lista[i].Texto);
            }
            return listaaux;
        }
    }
}
