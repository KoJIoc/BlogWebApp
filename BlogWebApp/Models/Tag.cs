
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Data.Article
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Tag() { }
        public Tag(string title) 
        {
            Title = title;
        }
    }
}
