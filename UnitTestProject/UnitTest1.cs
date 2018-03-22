using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectUnitTest.Models;
using ProjectUnitTest.ViewModels;
using Xamarin.Forms;
namespace UnitTestProject
{
    IDependencyService _dependencyservice;
    Page c = new Page();
    [TestClass]
    public class UnitTest1
    { 
        [TestMethod]
        public void TestMethod1()
        {
            var vm = new ProductViewModel(_dependencyService);
            vm._nav = c.Naviagtion;
                Assert.IsNotNull(vm.VALIDATE, "no data found");
            Assert.IsNotNull(vm._nav, "Error navigation "); 
        }
        public void Setup()
        {
            _dependencyService = new DependencyServiceStub();
        }


    }
}
