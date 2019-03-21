﻿using BookStore.Extensions;
using Castle.Core.Internal;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BookStore
{
	[DebuggerStepThrough]
	public class Check
    {
		[ContractAnnotation("value:null => halt")]
		public static T NotNull<T>(T value,[InvokerParameterName] [NotNull] string parameterName)
		{
			if(value == null)
			{
				throw new ArgumentNullException(parameterName);
			}

			return value;
		}

		[ContractAnnotation("value:null => halt")]
		public static string NotNullOrWhiteSpace(string value, [InvokerParameterName] [NotNull] string parameterName)
		{
			if (value.IsNullOrWhiteSpace())
			{
				throw new ArgumentException($"{parameterName} can not be null, empty or white space!", parameterName);
			}

			return value;
		}

		[ContractAnnotation("value:null => halt")]
		public static ICollection<T> NotNullOrEmpty<T>(ICollection<T> value, [InvokerParameterName] [NotNull] string parameterName)
		{
			if (value.IsNullOrEmpty())
			{
				throw new ArgumentException(parameterName + "can not be null or empty!", parameterName);
			}

			return value;
		}
    }
}