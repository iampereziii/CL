using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlConnection;
using Moq;
namespace CL.Tests
{
    [TestClass]
    public class SqlConnectionTests
    {
        Program _sut;

        [TestInitialize]
        public void TestInitialize() {
            _sut = new Program();
        }

        public void TestCleanUp()
        {

            _sut = null;
        }
        
        [TestMethod]
        public void TestMethod1()
        {
            _sut.Run();
        }
    }
}
