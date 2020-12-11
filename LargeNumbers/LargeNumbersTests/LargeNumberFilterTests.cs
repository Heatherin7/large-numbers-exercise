using System.Linq;
using LargeNumbers;
using NUnit.Framework;

namespace LargeNumbersTests
{
	[TestFixture]
	public class LargeNumberFilterTests
	{
		private LargeNumberFilter _filter;

		[SetUp]
		public void Setup()
		{
			_filter = new LargeNumberFilter();
		}

		[Test]
		public void Null_Returns_Empty_Array()
		{
			var result = _filter.FilterNumbers(null, 0);
			Assert.AreEqual(0, result.Length);
		}

		[Test]
		public void Empty_Returns_Empty_Array()
		{
			var values = new int[0];
			var result = _filter.FilterNumbers(values, 0);
			Assert.AreEqual(0, result.Length);
		}

		[Test]
		public void Single_Item_Below_Max_Value_Returns_Empty_Array()
		{
			var values = new []{3};
			var result = _filter.FilterNumbers(values, 10);
			Assert.AreEqual(0, result.Length);
		}

		[Test]
		public void Single_Item_Equal_To_Max_Value_Returns_Item()
		{
			var values = new[] {10};
			var result = _filter.FilterNumbers(values, 10);
			Assert.AreEqual(1, result.Length);
			Assert.AreEqual(10, result[0]);
		}

		[Test]
		public void Single_Item_Greater_Than_Max_Value_Returns_Item()
		{
			var values = new[] {20};
			var result = _filter.FilterNumbers(values, 10);
			Assert.AreEqual(1, result.Length);
			Assert.AreEqual(20, result[0]);
		}

		[Test]
		public void Multiple_Items_Returns_Values_Greater_Than_Or_Equal_To_Max_Value()
		{
			var values = new[] {1, 3, 5, 6, 7, 1, 2, 4, 11, 12341, 19, 19, 20, 20, 21, 21, 43, 1, -3, 55, -1000, 0};
			var result = _filter.FilterNumbers(values, 20);
			Assert.AreEqual(7, result.Length);
			Assert.AreEqual(1, result.Count(r => r == 12341));
			Assert.AreEqual(2, result.Count(r => r == 20));
			Assert.AreEqual(2, result.Count(r => r == 21));
			Assert.AreEqual(1, result.Count(r => r == 43));
			Assert.AreEqual(1, result.Count(r => r == 55));
		}
	}
}
