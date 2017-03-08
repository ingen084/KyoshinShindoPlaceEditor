using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyoshinShindoPlaceEditor
{
	[ProtoContract]
	public struct Point2
	{
		[ProtoMember(1)]
		public int IntX
		{
			get => (int)X;
			set => X = value;
		}

		[ProtoIgnore]
		public double X { get; set; }

		[ProtoMember(2)]
		public int IntY
		{
			get => (int)Y;
			set => Y = value;
		}

		[ProtoIgnore]
		public double Y { get; set; }

		public Point2(double x, double y)
		{
			X = x;
			Y = y;
		}

		public override string ToString() => $"X:{X} Y:{Y}";

		//切り捨て(最大整数)
		public Point2 Floor()
			=> new Point2(Math.Floor(X), Math.Floor(Y));
		//切り捨て(最小整数)
		public Point2 Truncate()
			=> new Point2(Math.Truncate(X), Math.Truncate(Y));

		//切り上げ
		public Point2 Ceiling()
			=> new Point2(Math.Ceiling(X), Math.Ceiling(Y));

		//四捨五入
		public Point2 Round()
			=> new Point2(Math.Round(X), Math.Round(Y));

		public override bool Equals(object obj)
			=> base.Equals(obj);
		public override int GetHashCode()
			=> base.GetHashCode();

		public static Point2 operator +(Point2 point, double num)
			=> new Point2(point.X + num, point.Y + num);
		public static Point2 operator -(Point2 point, double num)
			=> new Point2(point.X - num, point.Y - num);

		public static Point2 operator +(Point2 point1, Point2 point2)
			=> new Point2(point1.X + point2.X, point1.Y + point2.Y);
		public static Point2 operator -(Point2 point1, Point2 point2)
			=> new Point2(point1.X - point2.X, point1.Y - point2.Y);

		public static Point2 operator *(Point2 point, double num)
			=> new Point2(point.X * num, point.Y * num);
		public static Point2 operator /(Point2 point, double num)
			=> new Point2(point.X / num, point.Y / num);

		public static Point2 operator *(Point2 point1, Point2 point2)
			=> new Point2(point1.X * point2.X, point1.Y * point2.Y);
		public static Point2 operator /(Point2 point1, Point2 point2)
			=> new Point2(point1.X / point2.X, point1.Y / point2.Y);

		public static bool operator ==(Point2 point1, Point2 point2)
			=> point1.X == point2.X && point1.Y == point2.Y;
		public static bool operator !=(Point2 point1, Point2 point2)
			=> point1.X != point2.X || point1.Y != point2.Y;

		public static implicit operator Point2(Point point)
			=> new Point2(point.X, point.Y);
		public static implicit operator Point(Point2 point)
			=> new Point((int)point.X, (int)point.Y);

		public static implicit operator Point2(Size point)
			=> new Point2(point.Width, point.Height);
		public static implicit operator Size(Point2 point)
			=> new Size((int)point.X, (int)point.Y);
	}

	public static class Point2Extensions
	{
		public static Point2 ToPixel(this Location loc, double zoom)
			=> MercatorProjection.LatLngToPixel(loc, zoom);
		public static Location ToLocation(this Point2 loc, double zoom)
			=> MercatorProjection.PixelToLatLng(loc, zoom);
	}
}
