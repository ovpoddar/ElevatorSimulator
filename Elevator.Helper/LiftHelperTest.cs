using Elevator.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Elevator.Helper.Test
{
    [TestClass]
    public class LiftHelperTest
    {
        private readonly LiftHelper _liftHelper;
        public LiftHelperTest()
        {
            _liftHelper = new LiftHelper();
        }
        [TestMethod]
        public void CustomCountsTest()
        {
            var list = new List<int>()
            {
                1, 2, 2, 2, 3 , 2, 2
            };

            var result = _liftHelper.CustomCount(list, 2);

            Assert.IsNotNull(result);
            Assert.AreEqual(list.Count, 7);
            Assert.AreEqual(result, 5);
        }
    }
}
