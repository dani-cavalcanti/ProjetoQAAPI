using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPilotoQA.Business;
using ProjetoPilotoQA.Business.Implementation;
using ProjetoPilotoQA.Controllers;
using ProjetoPilotoQA.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace ProjetoQA.Tests
{
    public class SinistroControllerTest
    {
        SinistrosController _controller;
        ISinistroBusiness sinistroBusiness;

        public SinistroControllerTest()
        {
            sinistroBusiness = new SinistroTestImp();
            _controller = new SinistrosController(sinistroBusiness);
        }
 
        [Fact]
        public void Get_ListarTodosOsSinistros_RetornaTodosOsSinistros()
        {
            //Arrange
            var controller = new SinistrosController(new SinistroTestImp());

            //Act
            var result = controller.Get();
            var okResult = result as OkObjectResult;

            //Assert
            Assert.NotNull(okResult);
            Assert.True(okResult is OkObjectResult);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);

        }
           
    }
}
