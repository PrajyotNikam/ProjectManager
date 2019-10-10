using NUnit.Framework;
using ProjectManager.Controllers;
using ProjectManager.Models;
using System;

namespace ProjectManager.Tests.Controllers
{
    [TestFixture]
    public class ProjectListsControllerTests
    {


        [SetUp]
        public void SetUp()
        {

        }

        private ProjectListsController CreateProjectListsController()
        {
            return new ProjectListsController();
        }

        [Test]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var projectListsController = this.CreateProjectListsController();
            string sortOrder = null;
            string currentFilter = null;
            string searchString = null;

            // Act
            var result = projectListsController.Index(
                sortOrder,
                currentFilter,
                searchString);

            // Assert
            ////Assert.Fail();
        }

        [Test]
        public void Details_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var projectListsController = this.CreateProjectListsController();
            int? id = null;

            // Act
            var result = projectListsController.Details(
                id);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var projectListsController = this.CreateProjectListsController();

            // Act
            var result = projectListsController.Create();

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Create_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var projectListsController = this.CreateProjectListsController();
            ProjectList projectList = null;

            // Act
            //var result = projectListsController.Create(
            //    projectList);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var projectListsController = this.CreateProjectListsController();
            int? id = null;

            // Act
            var result = projectListsController.Edit(
                id);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Edit_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var projectListsController = this.CreateProjectListsController();
            ProjectList projectList = null;

            // Act
            //var result = projectListsController.Edit(
            //    projectList);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var projectListsController = this.CreateProjectListsController();
            int? id = null;

            // Act
            var result = projectListsController.Delete(
                id);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void DeleteConfirmed_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var projectListsController = this.CreateProjectListsController();
            int id = 0;

            // Act
            var result = projectListsController.DeleteConfirmed(
                id);

            // Assert
            //Assert.Fail();
        }
    }
}
