using Elevator.Helpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace Elevator.Helper.Test
{
    public class LiftHelperTest
    {
        private readonly LiftHelper _liftHelper;
        public LiftHelperTest()
        {
            _liftHelper = new LiftHelper();
        }
        [Fact]
        public void CustomCountsTest()
        {
            var list = new List<int>()
            {
                1, 2, 2, 2, 3 , 2, 2
            };

            var result = _liftHelper.CustomCount(list, 2);

            Assert.Equal(7, list.Count);
            Assert.Equal(5, result);
        }
    }
}
