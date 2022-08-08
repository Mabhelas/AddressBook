using AddressBook.Controllers;
using AddressBook.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Tests
{
    public class AddressBookModelTests
    {
        [Fact]
        public void InvalidModelTest()
        {

            // Arrange

            var options = new DbContextOptionsBuilder<AddressBookDbContext>()
                .UseSqlServer()
                .Options;
            var context = new AddressBookDbContext(options);

            var model = new AddressBookContacts { FirstName = "",
                                                  Surname = "",
                                                TelephoneNumber = ""}; // Invalid model
                                                                       
            //var mockRepo = new Mock<AddressBookDbContext>(context);

            var controller = new AddressBookContactsController(context);

            // Have to explictly add this
            controller.ModelState.AddModelError(model.FirstName, "This field is required");
            controller.ModelState.AddModelError(model.Surname, "This field is required");
            controller.ModelState.AddModelError(model.TelephoneNumber, "This field is required");

            // Act
            var result = controller.AddorEdit(model);

            // Assert etc
            Assert.NotNull(result);
        }
    }
}
