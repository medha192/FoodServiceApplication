using Microsoft.AspNetCore.Mvc;
using ProcessOrderService.Api.Controllers;
using ProcessOrderService.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProcessOrderService.Api.Tests
{
    public class ProcessControllerTests
    {
        private ProcessController processController;
        private MockProcessService mockProcessService;
        public ProcessControllerTests()
        {
            processController = new ProcessController(mockProcessService);
        }

        [Fact]
        public void Get_Valid_Test()
        {
            var response = processController.Get();
            Assert.IsType<OkObjectResult>(response);

        }

    }
}
