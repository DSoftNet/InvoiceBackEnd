﻿namespace Invoice.Admin
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string InvoiceDb { get; set; }
    }
}