﻿using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Challenge_KCMS.Models
{
    //definindo o modelo de domínio

    [Table("Products")]
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        // Chave estrangeira -> Categoria
        [ForeignKey(typeof(Category))]
        public int CategoryId { get; set; }

        [ManyToOne]
        public Category Category { get; set; }
    }
}
