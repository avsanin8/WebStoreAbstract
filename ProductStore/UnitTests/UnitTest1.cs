using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Abstract;
using Domain.Entities;
using System.Collections.Generic;
using Moq;
using WebUI.Controllers;
using WebUI.Models;
using System.Linq;
using System.Web.Mvc;
using WebUI.HtmlHelpers;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            //Организация (arrange)
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<ProductModel>
            {
                new ProductModel{Id = 1, Name = "Product 1"},
                new ProductModel{Id = 2, Name = "Product 2"},
                new ProductModel{Id = 3, Name = "Product 3"},
                new ProductModel{Id = 4, Name = "Product 4"},
                new ProductModel{Id = 5, Name = "Product 5"},
                new ProductModel{Id = 6, Name = "Product 6"},
                new ProductModel{Id = 7, Name = "Product 7"},
                new ProductModel{Id = 8, Name = "Product 8"},
                new ProductModel{Id = 9, Name = "Product 9"},
                new ProductModel{Id = 10, Name = "Product 10"},
                new ProductModel{Id = 11, Name = "Product 11"}
            });

            ProductsController controller = new ProductsController(mock.Object)
            {
                pageSize = 3
            };

            //чтобы получить последовательность для второй страницы...
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;
            //для этого сначала необходимо преобразовать полученную 
            //полседовательность в колекцию с помощью LINQ-метода ToList()
            List<ProductModel> products = result.Products.ToList();

            //проверяем кол-во элементов на второй странице и значения отдельных объектов
            Assert.IsTrue(products.Count() == 3);
            Assert.AreEqual(products[0].Name, "Product 4");
            Assert.AreEqual(products[1].Name, "Product 5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            // Организация
            HtmlHelper myHelper = null;
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            //Действие
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            //Утверждение
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                            + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                            + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                            result.ToString());
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            //Организация (arrange)
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<ProductModel>
            {
                new ProductModel{Id = 1, Name = "Product 1"},
                new ProductModel{Id = 2, Name = "Product 2"},
                new ProductModel{Id = 3, Name = "Product 3"},
                new ProductModel{Id = 4, Name = "Product 4"},
                new ProductModel{Id = 5, Name = "Product 5"},
                new ProductModel{Id = 6, Name = "Product 6"},
                new ProductModel{Id = 7, Name = "Product 7"},
                new ProductModel{Id = 8, Name = "Product 8"},
                new ProductModel{Id = 9, Name = "Product 9"},
                new ProductModel{Id = 10, Name = "Product 10"},
                new ProductModel{Id = 11, Name = "Product 11"}
            });

            ProductsController controller = new ProductsController(mock.Object)
            {
                pageSize = 3
            };

            //чтобы получить последовательность для второй страницы...
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;

            PagingInfo pagingInfo = result.PagingInfo;
            Assert.AreEqual(pagingInfo.CurrentPage, 2);
            Assert.AreEqual(pagingInfo.ItemsPerPage, 3);
            Assert.AreEqual(pagingInfo.TotalItems, 11);
            Assert.AreEqual(pagingInfo.TotalPages, 4);
        }

        [TestMethod]
        public void Can_Filter_Products()
        {
            //Организация (arrange)
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<ProductModel>
            {
                new ProductModel{Id = 1, Name = "Product 1", Category="Сategory 1"},
                new ProductModel{Id = 2, Name = "Product 2", Category="Сategory 2"},
                new ProductModel{Id = 3, Name = "Product 3", Category="Сategory 1"},
                new ProductModel{Id = 4, Name = "Product 4", Category="Сategory 1"},
                new ProductModel{Id = 5, Name = "Product 5", Category="Сategory 3"},
                new ProductModel{Id = 6, Name = "Product 6", Category="Сategory 1"},
                new ProductModel{Id = 7, Name = "Product 7", Category="Сategory 5"},
                new ProductModel{Id = 8, Name = "Product 8", Category="Сategory 5"},
                new ProductModel{Id = 9, Name = "Product 9", Category="Сategory 2"},
                new ProductModel{Id = 10, Name = "Product 10", Category="Сategory 3"},
                new ProductModel{Id = 11, Name = "Product 11", Category="Сategory 8"}
            });

            ProductsController controller = new ProductsController(mock.Object)
            {
                pageSize = 4
            };

            //чтобы получить последовательность для второй страницы...
            List<ProductModel> result = ((ProductsListViewModel)controller.List("Сategory 1", 1).Model).Products.ToList();

            Assert.AreEqual(result.Count(), 4);
            Assert.IsTrue(result[0].Name == "Product 1" && result[0].Category == "Сategory 1");
            Assert.IsTrue(result[1].Name == "Product 3" && result[1].Category == "Сategory 1");
            Assert.IsTrue(result[2].Name == "Product 4" && result[2].Category == "Сategory 1");
            Assert.IsTrue(result[3].Name == "Product 6" && result[3].Category == "Сategory 1");
        }
    }
}
