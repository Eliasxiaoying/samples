using _18_TestClassLibrary;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace _18_.NUnit.TestClassLibrary.Test
{
	public class Tests
	{
		private readonly ClassLibrary _service;

		public Tests()
		{
			_service = new ClassLibrary();
		}

		[SetUp]
		public void Setup()
		{

		}

		[Test]
		[TestCase(1, 2, 3)]
		[TestCase(4, 5, 9)]
		[TestCase(2, 6, 7)]
		public void Test1(int value, int anotherValue, int result)
		{
			int thisValue = value;
			int thisAnotherValue = anotherValue;

			var thisResult = _service.Add(thisValue, thisAnotherValue);

			Assert.That(result, Is.EqualTo(thisResult));
		}
	}
}