using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStore.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProductContext(
                serviceProvider.GetRequiredService<DbContextOptions<ProductContext>>()))
            {
                // Look for any products.
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }

                context.Product.AddRange(
                    new Product
                    {
                        Name = "Телевизор Shivaki STV-24LED14",
                        Author = "Леонид Данилович",
                        Price = 205.30m,
                        Category = "Бытовая техника",
                        Description = "Телевизор плоский диагональ 22! цветной!!! с очками как в 3Д кинотеатре",
                        UrlPicture = "https://i.imgur.com/ewfWPTD.jpg"
                    },
                    
                    new Product
                    {
                        Name = "Чайник електро-FullHD",
                        Author = "Светлана",
                        Price = 180.90m,
                        Category = "Бытовая техника",
                        Description = "Нормальный чайник пластмассовый на 1,5 литра",
                        UrlPicture = "https://i.imgur.com/VyGi7V1.jpg"
                    },

                    new Product
                    {
                        Name = "ВАЗ-21093",
                        Author = "Зигмунд 3",
                        Price = 2400.00m,
                        Category = "Транспорт",
                        Description = "Авто на повнім ходу мотор 1,5 інжектор масло не бере, розхід пального траса 6 змішаний 7,5 їде добре, обмін,більш детальна інформація за тел.+380123456789 всім вдалих торгів і покупок.",
                        UrlPicture = "https://i.imgur.com/s71S3tn.jpg"
                    },

                    new Product
                    {
                        Name = "Колонки S-90",
                        Author = "Kolunya",
                        Price = 1200.00m,
                        Category = "Разное",
                        Description = "настоящие совдеповские колонки дубасят так шо даже сосед-барабанщик в шоке!!!",
                        UrlPicture = "https://i.imgur.com/YOR6OZ3.jpg"
                    },
                    
                    new Product
                    {
                        Name = "TV-TUNER X16",
                        Author = "Иван Михайлович",
                        Price = 420.59m,
                        Category = "Бытовая техника",
                        Description = "ловит все даже мух...",
                        UrlPicture = "https://i.imgur.com/z28FQDr.jpg"
                    },

                    new Product
                    {
                        Name = "Lenovo NoteBook 17",
                        Author = "Mashenbka",
                        Price = 2310.56m,
                        Category = "Компьютерная техника",
                        Description = "AMD Dual-Core E1-7010 APU (1.5 ГГц, 10 Вт) ✔4 Гб ✔Radeon R2 integrated ✔500 Гб HDD ✔17.3\"(43.9 см) ✔TN ✔Win10",
                        UrlPicture = "https://i.imgur.com/rkVDoCh.png"
                    },

                    new Product
                    {
                        Name = "Їжачок",
                        Author = "Вован Вирвіхвіст",
                        Price = 1000.08m,
                        Category = "Разное",
                        Description = "Кормили мы его, вес 6 кг. но колючий",
                        UrlPicture = "https://i.imgur.com/cNLJxly.jpg"
                    },

                    new Product
                    {
                        Name = "Красівий чепчик",
                        Author = "Joker Semenich",
                        Price = 200.88m,
                        Category = "Одежда",
                        Description = "Повышенная оптикаемость",
                        UrlPicture = "https://i.imgur.com/r1w96Zq.png"
                    },

                    new Product
                    {
                        Name = "Двухстволка",
                        Author = "Вован Вирвіхвіст",
                        Price = 3050.15m,
                        Category = "Разное",
                        Description = "(обрезана вручну)",
                        UrlPicture = "https://i.imgur.com/JY9d0zb.jpg"
                    },

                    new Product
                    {
                        Name = "Перфоратор Cress 2-kWt",
                        Author = "Леонид Данилович",
                        Price = 6941.32m,
                        Category = "Электроинструмент",
                        Description = "2-kWt (У кума 1 раз подовбив и все)",
                        UrlPicture = "https://i.imgur.com/hPpJdoi.jpg"
                    },

                    new Product
                    {
                        Name = "Nokia 3310",
                        Author = "Магазин \"Все для дома\"",
                        Price = 1003.99m,
                        Category = "Мобильные телефоны",
                        Description = "Исторически-эпичнейший орехокол пулеброневодонепроницаемый",
                        UrlPicture = "https://i.imgur.com/PEytUnI.jpg"
                    },

                    new Product
                    {
                        Name = "Старое кресло",
                        Author = "Иван Михайлович",
                        Price = 654.20m,
                        Category = "Мебель",
                        Description = "Очень хорошое мягкое кресло для омоложения зада",
                        UrlPicture = "https://i.imgur.com/UBDj2N7.jpg"
                    },
                    
                    new Product
                    {
                        Name = "Свитер шерстяной",
                        Author = "Kolunya",
                        Price = 1200.00m,
                        Category = "Одежда",
                        Description = "На передке красивый олень (копыт не видно, но они есть)",
                        UrlPicture = "https://i.imgur.com/jxXcFLk.jpg"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
