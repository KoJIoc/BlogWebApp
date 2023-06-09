using ClassLibrary.Data.Article;
using System.ComponentModel.DataAnnotations;
using System;

namespace BlogWebApp.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string UserLogin { get; set; }
        public string ArticleID { get; set; }
        public string UserID { get; set; }
        [Required]
        public ArticleUser User { get; set; }

        public Comment() { }
        public Comment(string text, DateTime date)
        {
            Text = text;
            Date = date;
        }
    }
}
