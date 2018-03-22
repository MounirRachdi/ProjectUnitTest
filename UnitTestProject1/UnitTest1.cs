using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectUnitTest.Models;
using ProjectUnitTest.ViewModels;
using Xamarin.Forms;
namespace UnitTestProject1
{
    
    [TestClass]
    public class UnitTest1
    {   IDependencyService _dependencyService;
       Page c = new Page();
        [TestMethod]
        public void TestMethod1()
        {
            var vm = new ProductViewModel(_dependencyService);
            //vm._nav = c.Navigation;
            Assert.IsNotNull(vm.VALIDATE, "no data found");
        }
        public void Setup()
        {
            _dependencyService = new DependencyServiceStub();
        }
    
    }
}
