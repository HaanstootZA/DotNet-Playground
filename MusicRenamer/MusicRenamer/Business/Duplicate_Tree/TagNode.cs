using System;
namespace MusicRenamer
{
	class TagNode
	{
		private TagKeyValuePair _KeyValuePair;
		private TagNode _LeftChild = null;
		private TagNode _CenterChild = null;
		private TagNode _RightChild = null;

		#region Accessor Methods
		public TagKeyValuePair KeyValuePair { get { return _KeyValuePair; } }
		public UInt64 Key { get { return _KeyValuePair.iKey; } }
		public RFile Value { get { return _KeyValuePair.Value; } }
		public TagNode LeftChild
		{
			get { return _LeftChild; }
			set { _LeftChild = value; }
		}
		public TagNode CenterChild
		{
			get { return _CenterChild; }
			set { _CenterChild = value; }
		}
		public TagNode RightChild
		{
			get { return _RightChild; }
			set { _RightChild = value; }
		}
		#endregion

		#region Constructors
		public TagNode() { }
		public TagNode(TagKeyValuePair KeyValuePair)
		{
			_KeyValuePair = KeyValuePair;
		}
		public TagNode(RFile Value)
		{
			_KeyValuePair = new TagKeyValuePair(ref Value);
		}
		#endregion

		private int AddLeft(TagNode Node)
		{
			if(_LeftChild == null)
			{
				_LeftChild = Node;
				return 1;
			}
			else
				return _LeftChild.AddNode(Node);
		}
		private int AddCenter(TagNode Node)
		{
			if(this.KeyValuePair.CompareKey(Node.KeyValuePair))
			{
				KeyValuePair.GetFileToDelete(ref Node._KeyValuePair);
			}
			if(_CenterChild == null)
			{
				_CenterChild = Node;
				return 1;
			}
			else
				return _CenterChild.AddNode(Node);
		}
		private int AddRight(TagNode Node)
		{
			if(_RightChild == null)
			{
				_RightChild = Node;
				return 1;
			}
			else
				return _RightChild.AddNode(Node);
		}
		public int AddNode(TagNode Node)
		{
			if(Node != null)
			{
				if(Key == Node.Key)
				{
						return this.AddCenter(Node);
				}
				else{
					UInt64 val1 = Node.Key;
					UInt64 val2 = Key;
					UInt64 diff = ((val1 - val2) / 2);
					if(diff > val1)
						return this.AddRight(Node);
					else if(diff <= val1)
						return this.AddLeft(Node);
				}
			}
			return 0;
		}
	}
}
