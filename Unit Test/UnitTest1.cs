using FullstackCodingChallengeFinal.Data;
using FullstackCodingChallengeFinal.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace UnitTest
{
    public class Tests
    {

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            using (var context = new CompanyContext())
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            }
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_AddOnePerson()
        {
            DbMethods.AddOnePerson("Jota");
            string[] result = DbMethods.GetAllPersonNames();
            CollectionAssert.AreEqual(new[] { "Jota" }, result);
        }

        [Test]
        public void Test_AddOneClient()
        {
            DbMethods.AddOneClient("Academy");
            string[] result = DbMethods.GetAllClients();
            CollectionAssert.AreEqual(new[] { "Academy" }, result);
        }

    }
}