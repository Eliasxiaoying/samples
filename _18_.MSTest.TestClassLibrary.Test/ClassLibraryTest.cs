using _18_TestClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _18_.MSTest.TestClassLibrary.Test;

[TestClass]
public class ClassLibraryTest
{
	private readonly ClassLibrary _service;

	public ClassLibraryTest()
	{
		_service = new ClassLibrary();
	}

	[DataTestMethod]
	[DataRow(1, 2, 3)]
	[DataRow(4, 5, 9)]
	[DataRow(2, 6, 8)]
	public void TestMethod1(int value, int anotherValue, int result)
	{
		int thisValue = value;
		int thisAnotherValue = anotherValue;

		var thisResult = _service.Add(thisValue, thisAnotherValue);

		Assert.AreEqual(thisResult, result);
	}
}