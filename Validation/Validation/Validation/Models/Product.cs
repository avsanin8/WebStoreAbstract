using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Validation.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [StringLength(10,MinimumLength = 3,ErrorMessage ="Недопустимая длинна строки...")]
        [Remote("CheckName", "Home", ErrorMessage ="Incorrect name")]
        public string Name { get; set; }

        [Display(Name = "Производитель")]
        [Required]
        public string Manufacture { get; set; }

        [Display(Name = "Цена")]
        [Required]
        public int Price { get; set; }

        [Display(Name = "Год")]
        [Required]
        [Range(1800, 2017, ErrorMessage = "Не допустимый год")]
        public int Year { get; set; }
    }

        public class Purchase
        {
            // ID покупки
            public int PurchaseId { get; set; }
            // имя и фамилия покупателя
            public string Person { get; set; }
            // адрес покупателя
            public string Address { get; set; }
            // ID Product
            public int ProductId { get; set; }
            // дата покупки
            public DateTime Date { get; set; }
        }

    public class LoginModel
    {
        [RegularExpression(@"[A-Za-z0-9.-_%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        public string Password { get; set; }
        [System.Web.Mvc.Compare("Password", ErrorMessage = "Password is not valid")]
        public string PasswordConfirm { get; set; }
    }
}

   

