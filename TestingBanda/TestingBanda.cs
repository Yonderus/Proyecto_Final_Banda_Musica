using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Musica.Controller.API_s;


namespace TestingBanda
{
    [TestClass]
    public sealed class TestingBanda
    {
        /// <summary>
        /// Si el email no tiene el formato correcto, debe lanzar excepción.
        /// </summary>
        [TestMethod]
        public void Validacion_FormatoEmail_Invalido_LanzaExcepcion()
        {
            var api = new MiembrosApi();

            Assert.ThrowsException<Exception>(() =>
                api.Agregar(
                    nombre: "Nombre",
                    apellidos: "Apellidos",
                    telefono: "612345678",
                    email: "usuario.com",
                    idInstrumento: 1));
        }

        /// <summary>
        /// Si el teléfono no tiene 9 dígitos, debe lanzar excepción.
        /// </summary>
        [TestMethod]
        public void Validacion_FormatoTelefono_Invalido_LanzaExcepcion()
        {
            var api = new MiembrosApi();

            Assert.ThrowsException<Exception>(() =>
                api.Agregar(
                    nombre: "Nombre",
                    apellidos: "Apellidos",
                    telefono: "123",
                    email: "usuario@dominio.com",
                    idInstrumento: 1));
        }

        /// <summary>
        /// Integración:
        /// Comprueba que la base de datos responde al listar actuaciones.
        /// </summary>
        [TestMethod]
        public void Integracion_ListarActuaciones_NoDevuelveNulo()
        {
            var api = new ActuacionesApi();

            var lista = api.ListarActuaciones();

            Assert.IsNotNull(lista);
        }
    }
}
