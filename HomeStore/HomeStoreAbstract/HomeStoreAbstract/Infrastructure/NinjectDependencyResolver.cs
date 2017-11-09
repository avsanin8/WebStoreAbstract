using HomeStoreAbstract.Models;
using HomeStoreAbstract.Models.Abstract;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeStoreAbstract.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //mock.Setup(m => m.Products).Returns(new List<ProductModel>
            //{
            //    new ProductModel {Author = "Валерий Палыч", Name = "Старый диван", Price = 205.30m},
            //    new ProductModel {Author = "Семен Борисыч", Name = "Iphone 4", Price = 605.30m},
            //    new ProductModel {Author = "Валентина", Name = "Электрофен Samsung", Price = 505.20m},
            //});
            //kernel.Bind<IProductRepository>().ToConstant(mock.Object);
            
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}