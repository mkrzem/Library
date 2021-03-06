﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicLibrary.DAL.Model
{
    public enum BookGenre
    {
        Drama = 0,
        Action = 1,
        Crime = 2,
        SciFi = 3,
        Fantasy = 4,
        Classical = 5
    }

    public enum BookStatus
    {
        Available = 0,
        Borrowed,
        NotAvailable
    }
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public BookGenre Genre { get; set; }
        public string Author { get; set; }        
        public BookStatus Status { get; set; }
        [DefaultValue(value: 1)]
        public int Quantity { get; set; }
        public int Queued { get; set; }
        [DefaultValue(type: typeof(DateTime), value: "1/1/1900")]
        public DateTime ReleaseDate { get; set; }
    }
}
    
