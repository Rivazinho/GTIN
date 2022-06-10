using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_GTIN
{
    class Codigo {
        public string referencia; //Almacena la referencia del producto
        bool validez;

        public static string calculaDigitoControl(string GTIN) //Recibe GTIN como String
        {  
            int i;
            int numero = 0;
            int suma = 0;
            int posicion;
            int n;
            int Control = 0;
            string digitoControl;
            for (i = GTIN.Length - 1; i >= 0; i--)
            { //Recorremos la cadena de 12 posiciones desde 11 hasta 0
                numero = Convert.ToInt32(GTIN.Substring(i, 1)); //Toma el valor de la cadena y lo convierte a Integer. Empieza en i y quita un caracter
                posicion = (GTIN.Length) - i; //Empieza en la posición 1 hasta la 12
                if (posicion % 2 == 0) //División entera, nos devuelve el resto. Si el resto es 0, el número es par
                {
                    suma += numero; //Si es par lo acumulamos
                }
                else
                {
                    suma += numero * 3; //Si es impar lo multiplicamos por 3 y lo acumulamos
                }
            }
            //Calcular el dígito de control
            n = suma; //Asignamos suma a una nueva variable n para calcular el dígito de control
            while (n % 10 != 0) //Dividimos n entre 10 hasta que el resto sea 0, esto quiere decir que hemos llegado a una decena
            {
                n += 1; //Mientras no llegamos a la decena vamos incrementando la propia n y una variable que será el propio dígito de control
                Control++;
            }
            digitoControl = Control.ToString(); //Convertimos el dígito de control a String
            return digitoControl; //Devolvemos el dígito de control
        }

        public static string anadeDigitoControl(string GTIN)
        { //Recibe GTIN como string y añade el dígito al número origen
            string ConControl; //Creamos una nueva variable para añadirle el dígito de control
            ConControl = GTIN + calculaDigitoControl(GTIN); //Le concatenamos a la String que recibimos el dígito de control calculado con rl método anterior
            return ConControl; //Devolvemos la nueva variable como String
        }

        public static bool compruebaDigitoControl(string GTIN)
        {//Recibe GTIN como string y comprueba que tiene el dígito de control
            string sinDigitoControl = GTIN.Substring(0, GTIN.Length-1); //Elimina el dígito de control del GTIN solicitado
            string DigitoOrigen = GTIN.Substring(GTIN.Length-1, 1); //Toma el dígito de control del GTIN solicitado
            string DigitoCalculado = calculaDigitoControl(sinDigitoControl); //Calcula el dígito de control
            return DigitoCalculado == DigitoOrigen; //Comprueba si el dígito de origen y el calculado son iguales y devuelve en un Bool
        }

        public Codigo(string valor, bool Control)
        {//Constructor, recibe el código y un booleano que le indica si este viene con/sin dígito de control. Crea el objeto con el valor que se le pasa
         //En el caso de que Control=False se le añadiría el dígito de control calculado con los métodos anteriores
            if (!Control) //Esto es lo mismo que poner Control == False
            {
                referencia = anadeDigitoControl(valor);
                //En caso de venir SIN dígito de control, se le añade con su método correspondiente
            }
            else
            {
                referencia = valor;
                //Si viene CON el digito simplemente se guarda en referencia (Declarada arriba de todo)
                validez = compruebaDigitoControl(valor);
            }
        }

        //Propiedad para saber si una referencia es válida, devuelve Bool
        public bool Valido
        {
            get
            {
                return compruebaDigitoControl(referencia);
            }
        }

        //Propiedad que devuelve como string la referencia de los objetos
        public string Texto
        {
            get
            {
                return referencia;
            }
        }
    } 
}
