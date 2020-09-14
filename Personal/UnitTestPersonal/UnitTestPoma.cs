using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Personal.Controllers;
using Personal.Models;

namespace UnitTestPersonal
{
    [TestClass]
    public class UnitTestPoma
    {
        [TestMethod]
        public void TestMethodGet()
        {
            //Arange
            poma poma_esperado = new poma()
            {
                poma_ID = 5,
                Friendof_poma = "Adhamin Ruben",
                Place = Place.Universidad,
                Email = "adhamin055@gmail.com",
                Birthday = DateTime.Today
            };
            pomasController pomasController = new pomasController();
            //Act
            var listapoma = pomasController.Getpomas();
            var respuesta = pomasController.Getpoma(poma_esperado.poma_ID);
            var actual = respuesta as OkNegotiatedContentResult<poma>;
            //Assert
            Assert.IsNotNull(actual);
            Assert.IsNotNull(listapoma);
        }
        [TestMethod]
        public void TestMethodPost() 
        {
            //Arange
            poma poma_esperado = new poma()
            {
                poma_ID = 5,
                Friendof_poma = "Adhamin Ruben",
                Place = Place.Universidad,
                Email = "adhamin055@gmail.com",
                Birthday = DateTime.Today
            };
            pomasController pomasController = new pomasController();
            //Act
            var respuesta = pomasController.Postpoma(poma_esperado);
            var actual = respuesta as CreatedAtRouteNegotiatedContentResult<poma>;
            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual("DefaultApi", actual.RouteName);
            Assert.AreEqual(poma_esperado.poma_ID, actual.Content.poma_ID);
            Assert.AreEqual(poma_esperado.Friendof_poma, actual.Content.Friendof_poma);
            Assert.AreEqual(poma_esperado.Place, actual.Content.Place);
            Assert.AreEqual(poma_esperado.Email, actual.Content.Email);
            Assert.AreEqual(poma_esperado.Birthday, actual.Content.Birthday);
        }
        [TestMethod]
        public void TestMethodPut()
        {
            //Arange
            poma poma_esperado = new poma()
            {
                poma_ID = 5,
                Friendof_poma = "Adhamin Ruben",
                Place = Place.Universidad,
                Email = "adhamin055@gmail.com",
                Birthday = DateTime.Today
            };
            pomasController pomasController = new pomasController();
            int ID = poma_esperado.poma_ID;
            string New_Friendof = "Oscar";
            string New_Email = "Oscar01@gmail.com";
            //Act
            var actionResult = pomasController.Postpoma(poma_esperado);
            poma_esperado.Friendof_poma = New_Friendof;
            poma_esperado.Email = New_Email;
            var actionResultPut = pomasController.Putpoma(poma_esperado.poma_ID, poma_esperado) as StatusCodeResult;
            //Assert
            Assert.IsNotNull(actionResultPut);
            Assert.AreEqual(HttpStatusCode.NoContent, actionResultPut.StatusCode);
            Assert.IsInstanceOfType(actionResultPut, typeof(StatusCodeResult));
        }
        [TestMethod]
        public void TestMethodDelete() 
        {
            //Arange
            poma poma_esperado = new poma()
            {
                poma_ID = 5,
                Friendof_poma = "Adhamin Ruben",
                Place = Place.Universidad,
                Email = "adhamin055@gmail.com",
                Birthday = DateTime.Today
            };
            pomasController pomasController = new pomasController();
            //Act
            IHttpActionResult actionResult = pomasController.Postpoma(poma_esperado);
            IHttpActionResult actionResultDelete = pomasController.Deletepoma(poma_esperado.poma_ID);
            //Assert
            Assert.IsInstanceOfType(actionResultDelete, typeof(OkNegotiatedContentResult<poma>));
        }
    }
}
