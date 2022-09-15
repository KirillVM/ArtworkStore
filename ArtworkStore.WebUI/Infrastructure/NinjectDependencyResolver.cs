using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtworkStore.Domain.Abstract;
using ArtworkStore.Domain.Concrete;
using ArtworkStore.Domain.Entities;
using Moq;
using Ninject;

namespace ArtworkStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            /*Mock<IArtworkRepository> mock = new Mock<IArtworkRepository>();
            mock.Setup(m => m.Artworks).Returns(new List<Artwork>
            {
                new Artwork{Name = "Winter", Price = 1500},
                new Artwork{Name = "Spring", Price = 2500},
                new Artwork{Name = "Summer", Price = 3500},
                new Artwork{Name = "Autumn", Price = 1500}
            });
            kernel.Bind<IArtworkRepository>().ToConstant(mock.Object);*/
            kernel.Bind<IArtworkRepository>().To<EFArtworkRepository>();
        }
    }
}