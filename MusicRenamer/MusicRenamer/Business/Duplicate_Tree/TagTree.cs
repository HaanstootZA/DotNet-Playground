namespace MusicRenamer
{
    class TagTree
    {
        TagNode RootNode;
        int _Size;

        public int Size { get { return _Size; } }

        public void Push(RFile Value)
        {
            TagNode Node = new TagNode(Value);
            if (RootNode == null)
            {
                RootNode = Node;
                _Size++;
            }
            else
                _Size += RootNode.AddNode(Node);
        }

        public RFile Pop()
        {
			RFile ret = null;
            if (_Size > 0)
            {
                TagNode TempNode = RootNode;
				ret = new RFile(TempNode.Value);
                if (RootNode.CenterChild != null)
                {
                    RootNode = TempNode.CenterChild;
					TempNode.CenterChild = null;
                    RootNode.AddNode(TempNode.LeftChild);
					TempNode.LeftChild = null;
                    RootNode.AddNode(TempNode.RightChild);
					TempNode.RightChild = null;
                }
                else if (RootNode.LeftChild != null)
                {
                    RootNode = TempNode.LeftChild;
					TempNode.LeftChild = null;
                    RootNode.AddNode(TempNode.RightChild);
					TempNode.RightChild = null;
                }
                else if (RootNode.RightChild != null)
                {
                    RootNode = TempNode.RightChild;
					TempNode.RightChild = null;
                }
                else
                    RootNode = null;
                _Size--;
            }
			return ret;
        }

		~TagTree() {
			while(_Size > 0){
				Pop();
			}
			if(RootNode != null)
				RootNode = null;
		}
    }
}
