using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using IstarWindows.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable UnusedAutoPropertyAccessor.Local
#pragma warning disable 612

namespace IstarWindows.Tests
{
    [TestClass]
    public class ViewModelTests
    {
        [TestMethod]
        public void IsAbstractBaseClass()
        {
            var t = typeof (ViewModel);

            Assert.IsTrue(t.IsAbstract);
        }

        [TestMethod]
        public void IsIDataErrorInfo()
        {
            Assert.IsTrue(typeof (IDataErrorInfo).IsAssignableFrom(typeof (ViewModel)));
        }

        [TestMethod]
        public void IsObservableObject()
        {
            Assert.IsTrue(typeof (ViewModel).BaseType == typeof (ObservableObject));
        }

        [TestMethod]
        [ExpectedException(typeof (NotSupportedException))]
        public void IDataErrorInfo_ErrorProperty_IsNotSupported()
        {
            var viewModel = new StubViewModel();
            var value = viewModel.Error;
            Console.WriteLine(value);
            Console.ReadKey();
        }

        [TestMethod]
        public void IndexerValidatesPropertyNameWithInvalidValue()
        {
            var viewModel = new StubViewModel();
            Assert.IsNotNull(viewModel["RequiredProperty"]);
        }

        [TestMethod]
        public void IndexerValidatesPropertyNameWithValidValue()
        {
            var viewModel = new StubViewModel
                            {
                                RequiredProperty = "Some Value"
                            };

            Assert.IsNull(viewModel["RequiredProperty"]);
        }

        [TestMethod]
        public void IndexerReturnsErrorMessageForRequestedInvalidProperty()
        {
            var viewModel = new StubViewModel
                            {
                                RequiredProperty = null,
                                SomeOtherProperty = null
                            };

            var msg = viewModel["SomeOtherProperty"];

            Assert.AreEqual("Требуется поле SomeOtherProperty.", msg);
        }

        private class StubViewModel : ViewModel
        {
            [Required]
            public string RequiredProperty { get; set; }

            [Required]
            public string SomeOtherProperty { get; set; }
        }
    }
}