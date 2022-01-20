using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comun
{
    public static class Funciones
    {
        private static string User = "";
        private static int CodAlmacen = 0;
        private static DateTime dtCodFecha = DateTime.Now;

        public static void UsuarioActualSet(string user)
        {
            User = user;
        }

        public static string UsuarioActual()
        {
            return User;
        }

        
        public static int CodAlmacenActual()
        {
            return CodAlmacen;
        }

        public static DateTime CodFechaActual()
        {
            return dtCodFecha;
        }

        public static void CodFechaSet(DateTime dtCodAlmacen)
        {
            dtCodFecha = dtCodAlmacen;
        }

        public static void CodAlmacenSet(int codAlmacen)
        {
            CodAlmacen = codAlmacen;
        }

        public static bool DatosVacios( string valorDato)
        {
            if (valorDato == "" || valorDato == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DatosDuplicados(string valorDato)
        {
            return true;
        }

        public static decimal CalcularMonto(decimal num1,decimal num2)
        {
            return num1 * num2;
        }

        public static int ValidarNumeroEntero(KeyPressEventArgs e, TextBox text)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            return 1;
        }

        public static void LimpiarCajas(System.Windows.Forms.Control.ControlCollection Controls)
        {
            foreach (Control item in Controls)
            {
                if (item.Controls != null && item.Controls.Count > 0)
                {
                    LimpiarCajas(item.Controls);
                }
                else if (item.GetType().Name == "TextBox")
                {
                   
                }
            }
        }
     
       
        public static int ValidarNumeroDecimal(KeyPressEventArgs e, TextBox text)
        {
            string Separador = ".";
            int d = e.KeyChar.ToString().Length;
            int f = text.Text.Length;
            int dig = Convert.ToString(text.Text.Trim() + e.KeyChar).Length;
            int a = 0, esDecimal = 0, NumDecimales = 0;
            bool esDec = false;

            if (Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Separador))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return a;
            }
            else
            {
                e.Handled = true;
            }

            if (text.SelectedText != "")
            {
                if (e.KeyChar == Convert.ToChar(Separador))
                {
                    e.Handled = false;
                    return a;
                }
            }
            if (dig == 1 && e.KeyChar == Convert.ToChar(Separador))
            {
                e.Handled = true;
                return a;
            }

            if (text.SelectedText == "")
            {
                for (a = 0; a <= dig - 1; a++)
                {
                    string car = Convert.ToString(text.Text + e.KeyChar);

                    if (Convert.ToChar(car.Substring(a, 1)) == Convert.ToChar(Separador))
                    {
                        esDecimal = esDecimal + 1;
                        esDec = true;
                    }

                    if (esDec)
                    {
                        NumDecimales = NumDecimales + 1;
                    }

                    if (NumDecimales >= 4 || esDecimal >= 2)
                    {
                        e.Handled = true;
                    }

                }
            }

            return 1;
        }
    }
}
