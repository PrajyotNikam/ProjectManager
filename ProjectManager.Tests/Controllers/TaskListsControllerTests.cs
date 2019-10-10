using NUnit.Framework;
using ProjectManager.Controllers;
using ProjectManager.Models;
using System;

namespace ProjectManager.Tests.Controllers
{
    [TestFixture]
    public class TaskListsControllerTests
    {


        [SetUp]
        public void SetUp()
        {

        }

        private TaskListsController CreateTaskListsController()
        {
            return new TaskListsController();
        }

        [Test]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var taskListsController = this.CreateTaskListsController();
            string sortOrder = null;
            string currentFilter = null;
            string searchString = null;

            // Act
            var result = taskListsController.Index(
                sortOrder,
                currentFilter,
                searchString);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Details_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var taskListsController = this.CreateTaskListsController();
            int? id = null;

            // Act
            var result = taskListsController.Details(
                id);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var taskListsController = this.CreateTaskListsController();

            // Act
            var result = taskListsController.Create();

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Create_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var taskListsController = this.CreateTaskListsController();
            TaskList taskList = null;

            // Act
            //var result = taskListsController.Create(
            //    taskList);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var taskListsController = this.CreateTaskListsController();
            int? id = null;

            // Act
            var result = taskListsController.Edit(
                id);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Edit_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var taskListsController = this.CreateTaskListsController();
            TaskList taskList = null;

            // Act
            //var result = taskListsController.Edit(
            //    taskList);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var taskListsController = this.CreateTaskListsController();
            int? id = null;

            // Act
            var result = taskListsController.Delete(
                id);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void DeleteConfirmed_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var taskListsController = this.CreateTaskListsController();
            int id = 0;

            // Act
            //var result = taskListsController.DeleteConfirmed(
            //    id);

            // Assert
            //Assert.Fail();
        }
    }
}
