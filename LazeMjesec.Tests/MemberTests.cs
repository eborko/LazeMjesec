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
        bool result = Regex.IsMatch(mail, RegexHolder.EmailPattern);

        Assert.IsFalse(result);

        Assert.Throws<ArgumentException>(() => _member.Email = mail);
    }

    [Test]
    [TestCase("borko@admonte.net")]
    public void Set_Valid_Email_UpdatesEmail(string mail)
    {
        Regex emailRegex = new Regex(RegexHolder.EmailPattern);
        bool result = emailRegex.IsMatch(mail);

        Assert.IsTrue(result);

        _member.Email = mail;
        Assert.That(_member.Email, Is.SameAs(mail));
    }

    [Test]
    [TestCase("")]
    public void Set_Empty_Name_ThrowsException(string name)
    {
        Assert.Throws<ArgumentException>(() => _member.Name = name);
    }

    [Test]
    [TestCase("John")]
    public void Set_Valid_Name_UpdatesName(string name)
    {
        _member.Name = name;
        Assert.That(_member.Name.Equals(name));
    }
}
