using NUnit.Framework;
using ProjectManager.Controllers;
using ProjectManager.Models;
using System;

namespace ProjectManager.Tests.Controllers
{
    [TestFixture]
    public class UserListsControllerTests
    {


        [SetUp]
        public void SetUp()
        {

        }

        private UserListsController CreateUserListsController()
        {
            return new UserListsController();
        }

        [Test]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var userListsController = this.CreateUserListsController();
            string sortOrder = null;
            string currentFilter = null;
            string searchString = null;

            // Act
            var result = userListsController.Index(
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
            var userListsController = this.CreateUserListsController();
            int? id = null;

            // Act
            var result = userListsController.Details(
                id);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var userListsController = this.CreateUserListsController();

            // Act
            var result = userListsController.Create();

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Create_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var userListsController = this.CreateUserListsController();
            UserList userList = null;

            // Act
            //var result = userListsController.Create(
            //    userList);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var userListsController = this.CreateUserListsController();
            int? id = null;

            // Act
            var result = userListsController.Edit(
                id);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Edit_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var userListsController = this.CreateUserListsController();
            UserList userList = null;

            // Act
            //var result = userListsController.Edit(
            //    userList);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var userListsController = this.CreateUserListsController();
            int? id = null;

            // Act
            var result = userListsController.Delete(
                id);

            // Assert
            //Assert.Fail();
        }

        [Test]
        public void DeleteConfirmed_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var userListsController = this.CreateUserListsController();
            int id = 0;

            // Act
            //var result = userListsController.DeleteConfirmed(
            //    id);

            // Assert
            //Assert.Fail();
        }
    }
}
