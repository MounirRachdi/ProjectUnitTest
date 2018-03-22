using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestUnitaire.Models;
using TestUnitaire.ViewModels;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
       
        [TestMethod]
        public void TestMethod1()
        {
            var vm = new ProductViewModel(_dependencyService);
         
            Assert.IsNotNull(vm.VALIDATE, "no data found");
            Assert.IsNotNull();
        }
        public void Setup()
        {
            _dependencyService = new DependencyServiceStub();
        }
    
    }
}
