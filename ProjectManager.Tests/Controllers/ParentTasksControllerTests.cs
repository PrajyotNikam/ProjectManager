using NUnit.Framework;
using ProjectManager.Controllers;
using ProjectManager.Models;
using System;

namespace ProjectManager.Tests.Controllers
{
    [TestFixture]
    public class ParentTasksControllerTests
    {


        [SetUp]
        public void SetUp()
        {

        }

        private ParentTasksController CreateParentTasksController()
        {
            return new ParentTasksController();
        }

        [Test]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var parentTasksController = this.CreateParentTasksController();

            // Act
            var result = parentTasksController.Index();

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Details_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var parentTasksController = this.CreateParentTasksController();
            int? id = null;

            // Act
            var result = parentTasksController.Details(
                id);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var parentTasksController = this.CreateParentTasksController();

            // Act
            var result = parentTasksController.Create();

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Create_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var parentTasksController = this.CreateParentTasksController();
            ParentTask parentTask = null;

            // Act
            //var result = parentTasksController.Create(
            //    parentTask);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void CreateParentTask_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var parentTasksController = this.CreateParentTasksController();
            ParentTask parentTask = null;

            // Act
            //var result = parentTasksController.CreateParentTask(
            //    parentTask);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var parentTasksController = this.CreateParentTasksController();
            int? id = null;

            // Act
            var result = parentTasksController.Edit(
                id);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Edit_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var parentTasksController = this.CreateParentTasksController();
            ParentTask parentTask = null;

            // Act
            //var result = parentTasksController.Edit(
            //    parentTask);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var parentTasksController = this.CreateParentTasksController();
            int? id = null;

            // Act
            var result = parentTasksController.Delete(
                id);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void DeleteConfirmed_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var parentTasksController = this.CreateParentTasksController();
            int id = 0;

            // Act
            //var result = parentTasksController.DeleteConfirmed(
            //    id);

            // Assert
            //Assert.Fail();
        }
    }
}
