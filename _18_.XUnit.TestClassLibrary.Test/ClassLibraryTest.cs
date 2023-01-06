using System;
using _18_TestClassLibrary;
using Xunit;

namespace _18_.XUnit.TestClassLibrary.Test
{
	public class ClassLibraryTest
	{
		private readonly ClassLibrary _service;

		public ClassLibraryTest()
		{
			_service = new ClassLibrary();
		}

		[Theory]
		[InlineData(1, 2, 3)]
		public void Test1(int value, int anotherValue, int result)
		{
			int thisValue = value;
			int thisAnotherValue = anotherValue;

			var thisResult = _service.Add(thisValue, thisAnotherValue);

			Assert.Equal(thisResult, result);
		}
	}
}
