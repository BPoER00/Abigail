using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAbigail.Resources
{
    public struct Mensajes
    {
        public const string Obligatorio = "CAMPO OBLIGATORIO";
        public const string Correo = "CORREO INVALIDO";
        public const string Password = "PASSWORD INVALIDO";
        public const string ConfirmPassword = "LAS PASSWORD NO COINCIDEN";
        public const string MensajeEncontrado = "DATOS ENCONTRADOS CORRECTAMENTE";
        public const string MensajeNoEncontrado = "NO SE ENCONTRO NINGUN DATO";
        public const string ModeloInvalido = "EL MODELO INGRESADO ES INVALIDO";
        public const string DatosGuardatos = "DATOS GUARDADOS CORRECTAMENTE";
        public const string DatosActualizados = "DATOS ACTUALIZADOS CORRECTAMENTE";
        public const string IdInvalido = "EL ID INGRESADO ES INVALIDO O NO EXISTE";
        public const string YaDesactivado = "ESTE DATO YA FUE ELIMINADO";
        public const string Desactivado = "EL DATO FUE ELIMINADO CON EXITO";
        public const int ESTADO_EXITOSO = 1;
        public const int ESTADO_FALLIDO = 0;

    }
}