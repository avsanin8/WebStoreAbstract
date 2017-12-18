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
                        Description = "Превосходные раритетные колонки, по мощности не уступают современным.",
                        UrlPicture = "https://i.imgur.com/YOR6OZ3.jpg"
                    },
                    
                    new Product
                    {
                        Name = "TV-TUNER X16",
                        Author = "Иван Михайлович",
                        Price = 420.59m,
                        Category = "Компьютерная техника",
                        Description = "Порты: 1 x PS/2 6 x USB 1 x VGA 1 x DVI 1 x COM 1 x RJ-45 (LAN) 1 х Аудио Слоты расширения: 1 x PCI Express x16 2 x PCI Express x1",
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
                        Name = "Їжак",
                        Author = "Вован Вирвіхвіст",
                        Price = 1000.08m,
                        Category = "Разное",
                        Description = "Рост в холке 25см, вес 8 кг. длинна: 45см.(без учета хвоста)",
                        UrlPicture = "https://i.imgur.com/cNLJxly.jpg"
                    },

                    new Product
                    {
                        Name = "Кепка",
                        Author = "Joker Semenich",
                        Price = 200.88m,
                        Category = "Одежда",
                        Description = "Повышенная оптикаемость, для тех кто любит Рок-н-ролл",
                        UrlPicture = "https://i.imgur.com/r1w96Zq.png"
                    },

                    new Product
                    {
                        Name = "Двухстволка",
                        Author = "Вован Вирвіхвіст",
                        Price = 3050.15m,
                        Category = "Разное",
                        Description = "Уайетт Берри Стэпп Эрп (19 марта 1848 — 13 января 1929) — американский страж закона, ганфайтер, картёжник времён освоения американского Запада. Получил широкую известность благодаря книгам и кинофильмам в жанре вестерн. Макет является копией двуствольного дробовика, эпохи освоения «дикого запада» и станет превосходным элементом декора гостиной у ценителя мировой истории.",
                        UrlPicture = "https://i.imgur.com/JY9d0zb.jpg"
                    },

                    new Product
                    {
                        Name = "Перфоратор Cress 2-kWt",
                        Author = "Леонид Данилович",
                        Price = 6941.32m,
                        Category = "Электроинструмент",
                        Description = "2-kWt (Professional tool)",
                        UrlPicture = "https://i.imgur.com/hPpJdoi.jpg"
                    },

                    new Product
                    {
                        Name = "Nokia 3310",
                        Author = "Магазин \"Все для дома\"",
                        Price = 1003.99m,
                        Category = "Мобильные телефоны",
                        Description = "Для тех, кто не в курсе, Nokia 3310  – это телефон-легенда, который прославился за счет своей выносливости. Не смотря на скудные характеристики, телефон стал популярным. Главные преимущества Nokia 3310 – простота и надежность.",
                        UrlPicture = "https://i.imgur.com/PEytUnI.jpg"
                    },

                    new Product
                    {
                        Name = "Старое кресло",
                        Author = "Иван Михайлович",
                        Price = 654.20m,
                        Category = "Мебель",
                        Description = "Очень хорошое мягкое кресло для омоложения области зада",
                        UrlPicture = "https://i.imgur.com/UBDj2N7.jpg"
                    },
                    
                    new Product
                    {
                        Name = "Свитер шерстяной",
                        Author = "Kolunya",
                        Price = 1200.00m,
                        Category = "Одежда",
                        Description = "Теплый зимний свитер. Удобная и практичная модель. Классический крой. Состав: двойная вязка 70 - шерсти + 30 - акрил.Производитель Турция. Качество на самом высшем уровне.Приятный к телу, не колется, очень теплый.Не растягивается и не вытягивается. Размер универсальный 42 - 46(это S - M - L)",
                        UrlPicture = "https://i.imgur.com/jxXcFLk.jpg"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
