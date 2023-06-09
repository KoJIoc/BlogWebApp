using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlogWebApp.Models;

namespace ClassLibrary.Data.Article
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string UserID { get; set; }
        [Required]
        public ArticleUser User { get; set; }
        
        public Article() { }
        public Article(string h, string d, DateTime D)
        {
            Title= h;
            Description= d;
            DateOfCreation= D;
        }
    }
}
