using System;
using IstarWindows.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IstarWindows.Tests
{
    [TestClass]
    public class ActionCommandTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionIfActionParameterIsNull()
        {
            var command = new ActionCommand(null);
            command.CanExecute(false);
        }

        [TestMethod]
        public void ExecuteInvokesAction()
        {
            var invoked = false;

            Action<object> action = obj => invoked = true;

            var command = new ActionCommand(action);

            command.Execute();

            Assert.IsTrue(invoked);
        }

        [TestMethod]
        public void ExecuteOverloadInvokesActionWithParameter()
        {
            var invoked = false;

            Action<object> action = obj =>
                                    {
                                        Assert.IsNotNull(obj);
                                        invoked = true;
                                    };

            var command = new ActionCommand(action);

            command.Execute(new object());

            Assert.IsTrue(invoked);
        }

        [TestMethod]
        public void CanExecuteIsTrueByDefault()
        {
            var command = new ActionCommand(obj => { });
            Assert.IsTrue(command.CanExecute(null));
        }

        [TestMethod]
        public void CanExecuteOverloadExecutesTruePredicate()
        {
            var command = new ActionCommand(obj => { }, obj => (int)obj == 1);
            Assert.IsTrue(command.CanExecute(1));
        }

        [TestMethod]
        public void CanExecuteOverloadExecutesFalsePredicate()
        {
            var command = new ActionCommand(obj => { }, obj => (int)obj == 1);
            Assert.IsFalse(command.CanExecute(0));
        }
    }
}