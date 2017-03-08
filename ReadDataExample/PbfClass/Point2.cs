using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadDataExample.PbfClass
{
	[ProtoContract]
	public struct Point2
	{
		[ProtoMember(1)]
		public int X { get; set; }

		[ProtoMember(2)]
		public int Y { get; set; }

		public override string ToString()
			=> $"X:{X} Y:{Y}";

		//TODO Formで使う場合はここのコメントアウトを外すと自動でキャストしてくれるようになります。
		/*
		public static implicit operator Point2(Point point)
			=> new Point2(point.X, point.Y);
		public static implicit operator Point(Point2 point)
			=> new Point((int)point.X, (int)point.Y);

		public static implicit operator Point2(Size point)
			=> new Point2(point.Width, point.Height);
		public static implicit operator Size(Point2 point)
			=> new Size((int)point.X, (int)point.Y);
		*/
	}
}
