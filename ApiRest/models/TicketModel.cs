﻿namespace ApiRest.models
{
    public class TicketModel
    {
    }


    public class Ticket
    {
        public string IdTienda { get; set; }
        public string IdRegistradora { get; set; }
        public DateTime FechaHora { get; set; }
        public int NumeroTicket { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
    }
}
