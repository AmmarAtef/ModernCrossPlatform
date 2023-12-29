using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WorkingWithJson
{
    public class Book
    {
        public string Title { get; set; }
        public string? Author { get; set; }

        public Book(string title)
        {
            Title = title;
        }

        [JsonInclude]
        public DateTime PublishDate;

        [JsonInclude]
        public DateTimeOffset Created;

        public ushort Pages;

    }
}
