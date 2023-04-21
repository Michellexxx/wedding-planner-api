namespace wedding_planner_tests;

using System.ComponentModel.DataAnnotations;
using NUnit.Framework;

using wedding_planner.Models;
[TestFixture]
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestBasic()
    {

        var guest = new Guest
        {
            Id = 1,
            CreatedAt = DateTime.Now,
            UpdateddAt = DateTime.Now,
            FirstName = "M",
            LastName = "N"
        };
        Assert.AreEqual(1, guest.Id);
    }

    [Test]
    public void TestEmptyName()
    {
        var invalidGift = new Gift
        {
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Name = ""
        };
    
        Assert.Throws<System.ComponentModel.DataAnnotations.ValidationException>(
            () => Validator.ValidateObject(invalidGift, new ValidationContext(invalidGift), validateAllProperties: true));

    }

}
