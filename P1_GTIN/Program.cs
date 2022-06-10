using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_GTIN
{
    class Program
    {
        static void Main(string[] args)
        {
            string digitoControl = Codigo.calculaDigitoControl("841331100117");
            // Calcula el dígito de control de 308368000427 y lo guarda en 'digitoControl'
            string codigo = Codigo.anadeDigitoControl("841331100117");
            // Calcula el dígito de control de 308368000427, lo añade al final y el resultado
            // lo guarda en 'codigo
            bool correcto = Codigo.compruebaDigitoControl("8413311001178");
            // Guarda en 'correcto' un buleano cierto si el dígito de control contenido en
            // 8413311001178 es correcto
            Codigo c1 = new Codigo("841331100117", false);
            // Construye un objeto para representar al código 841331100117 al que se le añade
            // su dígito de control
            Codigo c2 = new Codigo("8413311001178", true);
            // Construye un objeto para representar al código 8413311001178 que ya tiene
            // su dígito de control

            if (c2.Valido)   // Consulta la propiedad 'Valido' si el digito de control es correcto
                codigo = c2.Texto;  // Consulta en la propiedad 'Texto' el codigo y lo guarda en la cadena
                                    // de caracteres 'codigo'

            GTIN14 gtin14Caja6PacksCuajada = new GTIN14("8413311001178", "Caja de 6 pack de 2 cuajadas en envase de vidrio 125 g", "1", 6);
            // Construye un nuevo objeto de la clase GTIN14 para representar a un código de
            // un tipo de caja de productos en formato GTIN-14. Los parámetros son:
            // El primero indica el código GTIN-13 con código de control del producto empaquetado.
            // El segundo indica la denominación comercial de la caja. El tercero indica el dígito
            // que identifica al tipo de caja. El último indica el número de unidades de producto en la
            // caja.
            GTIN14 gtin14Caja10PacksCuajada = new GTIN14("1841331100117", false, "Caja de 10 pack de 2 cuajadas en envase de vidrio 125 g", 10);
            // Construye un nuevo objeto para representar a un código de un tipo de caja de productos en
            // formato GTIN-14. Primero se indica el código GTIN-14. Luego si el código GTIN-14
            // ya tiene el dígito de control o no. Luego la denominación comercial de
            // la caja. El último indica el número de unidades de producto en la caja.
            string digitoCaja = gtin14Caja10PacksCuajada.DigitoCaja;
            // Propiedad para consultar cuál es el dígito asignado a ese tipo de caja
            int cuantos = gtin14Caja10PacksCuajada.Cantidad;
            // Propiedad para consultar el número de unidades de producto en la caja
            string codigoProducto = gtin14Caja10PacksCuajada.Gtin13;
            // Propiedad para consultar el código GTIN-13 (con su dígito de control) del producto
            string nombre = gtin14Caja10PacksCuajada.Nombre;
            // Propiedad para consultar la denominación comercial de la caja

            GTIN13 gtin13PackCuajada = new GTIN13("8413311001178", true, "Pack de 2 cuajadas en envase de vidrio 125 g");
            // Crea un nuevo objeto para representar a un código en formato GTIN-13.
            // El primer parámetro es el código. En el segundo se indica con un buleano
            // si en el primer parámetro hay dígito de control o no. En el tercero se
            // indica la denominación comercial del producto.
            gtin13PackCuajada.anadeGtin14(gtin14Caja6PacksCuajada);
            gtin13PackCuajada.anadeGtin14(gtin14Caja10PacksCuajada);
            // Este objeto de la clase GTIN13 contiene a una lista de objetos de la clase GTIN14,
            // cada uno de ellos representa a un tipo de caja donde se expenden estos productos
            List<string> codigosGtin14 = gtin13PackCuajada.getCodigosGtin14();
            // Crea una lista de cadenas con los códigos GTIN-14 que dependen de
            // ese GTIN-13 y la apunta con la referencia 'codigosGtin14'
        }
    }
}
