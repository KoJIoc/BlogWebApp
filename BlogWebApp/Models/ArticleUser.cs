
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BlogWebApp.Models;

namespace ClassLibrary.Data.Article
{
	public class ArticleUser : IdentityUser
    {
        public override string Id { get; set; }
        public override string Email { get; set; }
        public string Login { get; set; }
		public int Age { get; set; }
		public string Password { get; set; }
		public List<Article> Articles { get; set; }
        public List<Comment> Coments { get; set; }

        public ArticleUser() { }
		public ArticleUser(string name, int age, string password)
		{
			Login = name;
			Age = age;
			Password = password;
		}

	}
}
