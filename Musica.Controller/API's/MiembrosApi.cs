using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Musica.Model;
using Musica.Model.Repositorios;

namespace Musica.Controller.API_s
{
    /// <summary>
    /// <b>MiembrosApi</b><br/>
    /// Esta clase se usa para <b>gestionar los músicos</b> (ver, añadir, editar y eliminar).
    /// </summary>
    public class MiembrosApi
    {
        private MiembrosRepo repositorio = new MiembrosRepo();

        /// <summary>
        /// <b>Listar músicos</b><br/>
        /// Devuelve todos los músicos guardados.
        /// </summary>
        public List<Musico> ListarMusicos()
        {
            return repositorio.ObtenerTodos();
        }

        /// <summary>
        /// <b>Agregar músico</b><br/>
        /// Comprueba datos, valida email y teléfono y lo guarda si está correcto.
        /// </summary>
        public void Agregar(string nombre, string apellidos, string telefono, string email, int idInstrumento)
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new Exception("El email no tiene un formato válido.");

            if (!Regex.IsMatch(telefono, @"^\d{9}$"))
                throw new Exception("El teléfono no tiene un formato válido. Debe contener 9 dígitos.");
    
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(apellidos))
                throw new Exception("Los apellidos son obligatorios.");
            if (string.IsNullOrWhiteSpace(telefono))
                throw new Exception("El teléfono es obligatorio.");
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("El email es obligatorio.");
            if (idInstrumento <= 0)
                throw new Exception("Debe seleccionar un instrumento válido.");

            var emailNorm = email.Trim().ToLower();
            var telNorm = telefono.Trim();

            var lista = ListarMusicos();

            if (lista.Any(m => (m.Email ?? string.Empty).Trim().ToLower() == emailNorm))
                throw new Exception("Ya existe un músico con ese email.");

            if (lista.Any(m => (m.Telefono ?? string.Empty).Trim() == telNorm))
                throw new Exception("Ya existe un músico con ese teléfono.");

            repositorio.Insertar(new Musico
            {
                Nombre = nombre.Trim(),
                Apellidos = apellidos.Trim(),
                Telefono = telNorm,
                Email = email.Trim(),
                IdInstrumento = idInstrumento
            });
        }

        /// <summary>
        /// <b>Editar músico</b><br/>
        /// Cambia los datos del músico seleccionado.
        /// </summary>
        public void Editar(int idMusico, string nombre, string apellidos, string telefono, string email, int idInstrumento)
        {
            if (idMusico <= 0)
                throw new Exception("Debe seleccionar un músico válido.");
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(apellidos))
                throw new Exception("Los apellidos son obligatorios.");
            if (string.IsNullOrWhiteSpace(telefono))
                throw new Exception("El teléfono es obligatorio.");
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("El email es obligatorio.");
            if (idInstrumento <= 0)
                throw new Exception("Debe seleccionar un instrumento válido.");

            var emailNorm = email.Trim().ToLower();
            var telNorm = telefono.Trim();

            var lista = ListarMusicos();

            if (lista.Any(m => m.IdMusico != idMusico && (m.Email ?? string.Empty).Trim().ToLower() == emailNorm))
                throw new Exception("Ya existe un músico con ese email.");

            if (lista.Any(m => m.IdMusico != idMusico && (m.Telefono ?? string.Empty).Trim() == telNorm))
                throw new Exception("Ya existe un músico con ese teléfono.");

            repositorio.Editar(new Musico
            {
                IdMusico = idMusico,
                Nombre = nombre.Trim(),
                Apellidos = apellidos.Trim(),
                Telefono = telNorm,
                Email = email.Trim(),
                IdInstrumento = idInstrumento
            });
        }

        /// <summary>
        /// <b>Eliminar músico</b><br/>
        /// Borra el músico usando su id.
        /// </summary>
        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new Exception("El id debe ser mayor que 0.");

            repositorio.Eliminar(id);
        }
    }
}
