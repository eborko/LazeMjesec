using LazeMjesec.Server;
using System.Text.RegularExpressions;

namespace LazeMjesec.Tests;

public class MemberTests
{
    private Member _member;

    [SetUp]
    public void Setup()
    {
        _member = new Member();
    }

    [Test]
    [TestCase("John")]
    [TestCase("@Jane")]
    [TestCase("John @Doe")]
    public void Set_Invalid_Email_ThrowsException(string mail)
    {
        string emailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        bool result = Regex.IsMatch(mail, emailRegex);

        Assert.IsFalse(result);

        Assert.Throws<ArgumentException>(() => _member.Email = mail);
    }

    [Test]
    [TestCase("borko@admonte.net")]
    public void Set_Valid_Email_UpdatesEmail(string mail)
    {
        string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Regex emailRegex = new Regex(emailPattern);
        bool result = emailRegex.IsMatch(mail);

        Assert.IsTrue(result);

        _member.Email = mail;
        Assert.That(_member.Email, Is.SameAs(mail));
    }
}
