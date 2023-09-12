using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTest
{
    [TestClass]
    public class AlbumRepositoryTest
    {
        private readonly UnitOfWork _unit;

        public AlbumRepositoryTest()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }

        [TestMethod]
        public void TestEf_Conexion_Album_Cantidad()
        {
            var count = _unit.Albums.Count();
            Assert.AreEqual(count > 0, true);
        }


    }
}
