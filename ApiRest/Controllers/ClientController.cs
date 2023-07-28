using ApiRest.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {


        private readonly IConfiguration _configuration;

        public ClientController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        // POST: api/Client
        [HttpPost]
        public IActionResult Insert(Ticket oTicket)
        {

            string connectionString = _configuration.GetConnectionString("ConexionSQL");


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Definir la consulta SQL para insertar el registro en la tabla "Tickets"
                    string query = "INSERT INTO Tickets (IdTienda, IdRegistradora, FechaHora, NumeroTicket, Impuesto, Total) " +
                                   "VALUES (@IdTienda, @IdRegistradora, @FechaHora, @NumeroTicket, @Impuesto, @Total)";

                    // Crear el objeto SqlCommand y agregar los parámetros
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdTienda", oTicket.IdTienda);
                        command.Parameters.AddWithValue("@IdRegistradora", oTicket.IdRegistradora);
                        command.Parameters.AddWithValue("@FechaHora", oTicket.FechaHora);
                        command.Parameters.AddWithValue("@NumeroTicket", oTicket.NumeroTicket);
                        command.Parameters.AddWithValue("@Impuesto", oTicket.Impuesto);
                        command.Parameters.AddWithValue("@Total", oTicket.Total);

                        // Ejecutar la consulta
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {

                }
            }


            // Aquí puedes agregar lógica para guardar el objeto Ticket en la base de datos u otra fuente de datos
            // En este ejemplo, simplemente retornamos el objeto Ticket en la respuesta
            return Ok(oTicket);
        }
    }
}
