
using System;
namespace MusicRenamer
{
	class TagKeyValuePair
	{
		private TagKey _Key;
		private RFile _Value;

		public UInt64 iKey
		{
			get
			{
				if(_Key == null)
					return 0;
				else
					return _Key.iKey;
			}
		}
		public RFile Value { get { return _Value; } }

		public TagKeyValuePair() { }

		public TagKeyValuePair(ref RFile Value)
		{
			RFile temp = Value;
			bool corrupt = temp.Corrupt;
			if(!corrupt)
				_Key = new TagKey(temp.Tag);
			_Value = temp;
		}

		public bool CompareKey(TagKeyValuePair KeyValuePair)
		{
			return _Key.Equals(KeyValuePair._Key);
		}

		public void GetFileToDelete(ref TagKeyValuePair KeyValuePair)
		{
			if(!this._Value.isDuplicate)
			{
				if(!this._Value.isOriginal)
				{
					RFile temp = KeyValuePair._Value;
					if(!temp.Corrupt && _Value.Corrupt)
					{
						SwopValue(ref KeyValuePair);
					}
					else if(!temp.Corrupt)
					{
						if(temp.Tag.Bitrate < this._Value.Tag.Bitrate)
							SwopValue(ref KeyValuePair);
						else if(temp.Tag.Duration < this._Value.Tag.Duration)
							SwopValue(ref KeyValuePair);
						else if(temp.isOriginal)
							SwopValue(ref KeyValuePair);
					}
				}
				KeyValuePair._Value.isDuplicate = true;
			}
			if(KeyValuePair._Value.isDuplicate)
				KeyValuePair._Value.DuplicateCount = _Value.DuplicateCount + 1;
		}

		private void SwopValue(ref TagKeyValuePair Right)
		{
			RFile ret = this._Value;
			this._Value = Right._Value;
			Right._Value = ret;
		}
	}
}
