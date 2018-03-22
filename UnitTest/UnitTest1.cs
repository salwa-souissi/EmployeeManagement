using System;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        IDependencyService _dependencyService;
        public void Setup()
        {
            _dependencyService = new DependencyServiceStub();
        }


        [TestMethod]
        public void LoginTest()
        {           
            
            var vm = new LoginViewModel(_dependencyService);
            Assert.IsNotNull(vm.OnSubmitCommand);
    //       Assert.IsNotNull(vm._nav, "Error nullable navigation");


        }
        //[TestMethod]
        //public void SubscribeTest()
        //{
        //    //Arrange View Model and properties
        //    var vm = new SubscribeViewModel();

        //    //Events handler Call
        //    vm.OnSubscribeCommand.Execute(null);
           
        //    //Assert: assurer le resultat
        //    Assert.IsNotNull(vm.OnSubscribeCommand);

        //}
        //[TestMethod]
        //public void AddTest()
        //{
        //    //Arrange View Model and properties
        //    var vm = new AddViewModel();

        //    //Events handler Call
        //    vm.OnSubmitCommand.Execute(null);


        //    //Assert: assurer le resultat
        //    Assert.IsNotNull(vm.OnSubmitCommand);

        //}
        //[TestMethod]
        //public void UpdateTest()
        //{            
        //    //Arrange View Model and properties
        //    var vm = new UpdateViewModel();

        //    //Events handler Call
        //    vm.OnUpdateCommand.Execute(null);

        //    //Assert: assurer le resultat
        //    Assert.IsNotNull(vm.OnUpdateCommand);

        //}
        //[TestMethod]
        //public void DeleteTest()
        //{
        //    //Arrange View Model and properties
        //    var vm = new HomeViewModel();

        //    //Events handler Call
        //    vm.DeleteCommand.Execute(null);

        //    //Assert: assurer le resultat
        //    Assert.IsNotNull(vm.DeleteCommand);

        //}
        

    }
}
