using System;
using System.Collections.Generic;
using System.Text;

namespace _18_TestClassLibrary;

public class ClassLibrary
{
	/// <summary>
	/// 对两个输入值求和
	/// </summary>
	/// <param name="value">输入值1</param>
	/// <param name="anotherValue">输入值2</param>
	/// <returns>两个输入之和</returns>
	public int Add(int value, int anotherValue) => value + anotherValue;
}