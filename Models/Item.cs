﻿namespace tech_test_payment_api.Models
{
    public class Item
    {
        public int IdItem { get; set; }
        public string Nome { get; set; }
        public Venda Venda { get; set; }
    }
}
