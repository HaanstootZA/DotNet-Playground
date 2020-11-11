using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PathFinding.Dijkstra.Extended
{
	public class SpecializedSet<T> : HashSet<object>
	{
		public SpecializedSet()
		{

		}

		public SpecializedSet(int capacity) : base(capacity)
		{
		}

		public SpecializedSet(IEnumerable<T> collection) : base((IEnumerable<object>)collection)
		{
		}

		protected SpecializedSet(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		public bool Add(T item)
		{
			return base.Add(item);
		}

		public bool Contains(T item)
		{
			return base.Contains(item);
		}

		public void IntersectWith(IEnumerable<T> other)
		{
			base.IntersectWith((IEnumerable<object>)other);
		}

		public bool IsProperSubsetOf(IEnumerable<T> other)
		{
			return base.IsProperSubsetOf((IEnumerable<object>)other);
		}

		public bool IsProperSupersetOf(IEnumerable<T> other)
		{
			return base.IsProperSupersetOf((IEnumerable<object>)other);
		}

		public bool IsSubsetOf(IEnumerable<T> other)
		{
			return base.IsSubsetOf((IEnumerable<object>)other);
		}

		public bool IsSupersetOf(IEnumerable<T> other)
		{
			return base.IsSupersetOf((IEnumerable<object>)other);
		}

		public bool Overlaps(IEnumerable<T> other)
		{
			return base.Overlaps((IEnumerable<object>)other);
		}

		public bool Remove(T item)
		{
			return base.Remove(item);
		}

		public int RemoveWhere(Predicate<T> match)
		{
			return base.RemoveWhere((item) => match.Invoke((T)item));
		}

		public bool SetEquals(IEnumerable<T> other)
		{
			return base.SetEquals((IEnumerable<object>)other);
		}

		public void SymmetricExceptWith(IEnumerable<T> other)
		{
			base.SymmetricExceptWith((IEnumerable<object>)other);
		}

		public bool TryGetValue(T equalValue, out T actualValue)
		{
			object outputValue;
			bool result = base.TryGetValue(equalValue, out outputValue);
			actualValue = (T)outputValue;
			return result;
		}

		public bool TryGetValue(object equalValue, out T actualValue)
		{
			object outputValue;
			bool result = base.TryGetValue(equalValue, out outputValue);
			actualValue = (T)outputValue;
			return result;
		}

		public void UnionWith(IEnumerable<T> other)
		{
			base.UnionWith((IEnumerable<object>)other);
		}
	}
}
