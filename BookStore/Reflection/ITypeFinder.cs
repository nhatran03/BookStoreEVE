using System;

namespace BookStore.Reflection
{
	public interface ITypeFinder
	{
		Type[] Find(Func<Type, bool> predicate);

		Type[] FindAll();
	}
}
