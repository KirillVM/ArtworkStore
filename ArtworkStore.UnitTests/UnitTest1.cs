﻿using ArtworkStore.Domain.Abstract;
using ArtworkStore.Domain.Entities;
using ArtworkStore.WebUI.Controllers;
using ArtworkStore.WebUI.HtmlHelpers;
using ArtworkStore.WebUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

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
            ArtworkListViewModel result = (ArtworkListViewModel)controller.List(null,2).Model;

            // Утверждение (assert)
            List<Artwork> artworks = result.Artworks.ToList();
            Assert.IsTrue(artworks.Count == 2);
            Assert.AreEqual(artworks[0].Name, "Поле");
            Assert.AreEqual(artworks[1].Name, "Серый день");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            // Организация - определение вспомогательного метода HTML - это необходимо
            // для применения расширяющего метода
            HtmlHelper myHelper = null;

            // Организация - создание объекта PagingInfo
            PagingInfo pagingInfo = new PagingInfo()
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            // Организация - настройка делегата с помощью лямбда-выражения
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            //Действие
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            // Утверждение
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                           + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                           + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                           result.ToString());
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
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

            ArtworkListViewModel result = (ArtworkListViewModel)controller.List(null, 2).Model;

            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 6);
            Assert.AreEqual(pageInfo.TotalItems, 8);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }

        [TestMethod]
        public void Can_Filter_Artworks()
        {
            Mock<IArtworkRepository> mock = new Mock<IArtworkRepository>();
            mock.Setup(m => m.Artworks).Returns(new List<Artwork>
            {
                new Artwork { Id=1, Name="Зима", Technic = "Watercolor"},
                new Artwork { Id=2, Name="Лето", Technic = "Oil painting"},
                new Artwork { Id=3, Name="Осень", Technic = "Watercolor"},
                new Artwork { Id=4, Name="Весна", Technic = "Watercolor"},
                new Artwork { Id=5, Name="Море", Technic = "Watercolor"},
                new Artwork { Id=6, Name="Река", Technic = "Oil painting"},
                new Artwork { Id=7, Name="Поле", Technic = "Oil painting"},
                new Artwork { Id=8, Name="Серый день", Technic = "Watercolor"},
                /*new Artwork { Id=9, Name="Солнечный день" },
                new Artwork { Id=10, Name="Гурзуф" },
                new Artwork { Id=11, Name="Вечер в саду" },
                new Artwork { Id=12, Name="Полночь" },*/
            });

            ArtworkController controller = new ArtworkController(mock.Object);
            controller.pageSize = 6;

            List<Artwork> result = ((ArtworkListViewModel)controller.List("Watercolor", 1).Model).Artworks.ToList();

            Assert.AreEqual(result.Count, 5);
            Assert.IsTrue(result[0].Name == "Зима" && result[0].Technic == "Watercolor");
            Assert.IsTrue(result[1].Name == "Осень" && result[0].Technic == "Watercolor");
        }
    }
}
