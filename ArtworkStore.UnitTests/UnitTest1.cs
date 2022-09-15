using ArtworkStore.Domain.Abstract;
using ArtworkStore.Domain.Entities;
using ArtworkStore.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ArtworkStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Организация (arrange)
            Mock<IArtworkRepository> mock = new Mock<IArtworkRepository>();
            mock.Setup(m => m.Artworks).Returns(new List<Artwork>
            {
                new Artwork { Id=1, Name="Зима" },
                new Artwork { Id=2, Name="Лето" },
                new Artwork { Id=3, Name="Осень" },
                new Artwork { Id=4, Name="Весна" },
                new Artwork { Id=5, Name="Море" },
                new Artwork { Id=6, Name="Река" },
                new Artwork { Id=7, Name="Поле" },
                new Artwork { Id=8, Name="Серый день" },
                /*new Artwork { Id=9, Name="Солнечный день" },
                new Artwork { Id=10, Name="Гурзуф" },
                new Artwork { Id=11, Name="Вечер в саду" },
                new Artwork { Id=12, Name="Полночь" },*/
            });
            ArtworkController controller = new ArtworkController(mock.Object);
            controller.pageSize = 6;

            // Действие (act)
            IEnumerable<Artwork> result = (IEnumerable<Artwork>)controller.List(2).Model;

            // Утверждение (assert)
            List<Artwork> artworks = result.ToList();
            Assert.IsTrue(artworks.Count == 2);
            Assert.AreEqual(artworks[0].Name, "Поле");
            Assert.AreEqual(artworks[1].Name, "Серый день");
        }
    }
}
