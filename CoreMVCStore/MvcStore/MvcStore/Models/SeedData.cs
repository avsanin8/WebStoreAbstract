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
                        Name = "Старый диван",
                        Author = "Леонид Данилович",                                              
                        Price = 205.30m,
                        Category = "Бытовая техника",
                        Description = "Телевизор плоский диагональ 22! цветной!!! с очками как в 3Д кинотеатре"
                    },
                    
                    new Product
                    {
                        Name = "Чайник електро-FullHD",
                        Author = "Светлана",
                        Price = 180.90m,
                        Category = "Бытовая техника",
                        Description = "Нормальный чайник пластмассовый на 1,5 литра"
                    },

                    new Product
                    {
                        Name = "ВАЗ-21093",
                        Author = "Зигмунд 3",
                        Price = 2400.00m,
                        Category = "Транспорт",
                        Description = "Авто на повнім ходу мотор 1,5 інжектор масло не бере, розхід пального траса 6 змішаний 7,5 їде добре, обмін,більш детальна інформація за тел. всім вдалих торгів і покупок."
                    },

                    new Product
                    {
                        Name = "Колонки S-90",
                        Author = "Kolunya Antonyuk",
                        Price = 1200.00m,
                        Category = "Разное",
                        Description = "настоящие совдеповские колонки дубасят так шо даже сосед-барабанщик в шоке!!!"
                    },
                    
                    new Product
                    {
                        Name = "TV-TUNER X16",
                        Author = "Иван Михайлович",
                        Price = 420.59m,
                        Category = "Бытовая техника",
                        Description = "ловит все даже мух..."
                    },

                    new Product
                    {
                        Name = "Lenovo NoteBook 17",
                        Author = "Mashenbka",
                        Price = 2310.56m,
                        Category = "Компьютерная техника",
                        Description = "AMD Dual-Core E1-7010 APU (1.5 ГГц, 10 Вт) ✔4 Гб ✔Radeon R2 integrated ✔500 Гб HDD ✔17.3\"(43.9 см) ✔TN ✔Win10"
                    },

                    new Product
                    {
                        Name = "Їжачок живий",
                        Author = "Вован Вирвіхвіст",
                        Price = 1000.08m,
                        Category = "Разное",
                        Description = "Кормили мы его, вес 6 кг. но колючий"
                    },

                    new Product
                    {
                        Name = "Красівий чепчик U10",
                        Author = "Joker Semenich",
                        Price = 200.88m,
                        Category = "Одежда",
                        Description = "Повышенная оптикаемость"
                    },

                    new Product
                    {
                        Name = "Двухстволка",
                        Author = "Вован Вирвіхвіст",
                        Price = 3050.15m,
                        Category = "Разное",
                        Description = "(обрезана вручну)"
                    },

                    new Product
                    {
                        Name = "Перфоратор Cress 2-kWt",
                        Author = "Леонид Данилович",
                        Price = 6941.32m,
                        Category = "Электроинструмент",
                        Description = "2-kWt (У кума 1 раз подовбив и все)"
                    },

                    new Product
                    {
                        Name = "Nokia 3310",
                        Author = "Магазин \"Все для дома\"",
                        Price = 1003.99m,
                        Category = "Мобильные телефоны",
                        Description = "Исторически-эпичнейший орехокол пулеброневодонепроницаемый"
                    },

                    new Product
                    {
                        Name = "Старое кресло",
                        Author = "Иван Михайлович",
                        Price = 654.20m,
                        Category = "Мебель",
                        Description = "Очень хорошое мягкое кресло для омоложения зада"
                    },
                    
                    new Product
                    {
                        Name = "Свитер шерстяной",
                        Author = "Kolunya Antonyuk",
                        Price = 1200.00m,
                        Category = "Одежда",
                        Description = "На передке красивый олень (копыт не видно, но они есть)"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
