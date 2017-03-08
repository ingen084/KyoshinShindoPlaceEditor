﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyoshinShindoPlaceEditor
{
	public static class MercatorProjection
	{
		public const int TileSize = 256;
		static double _pixelsPerLonDegree = TileSize / (double)360;
		static double _pixelsPerLonRadian = TileSize / (2 * Math.PI);
		static Point2 _origin = new Point2(128, 128);

		public static Point2 LatLngToPoint(Location location)
		{
			var point = new Point2()
			{
				X = _origin.X + location.Longitude * _pixelsPerLonDegree
			};
			var siny = Bound(Math.Sin(DegreesToRadians(location.Latitude)), -0.9999, 0.9999);
			point.Y = _origin.Y + 0.5 * Math.Log((1 + siny) / (1 - siny)) * -_pixelsPerLonRadian;

			return point;
		}

		public static Location PointToLatLng(Point2 point)
		{
			var origin = _origin;
			var lng = (point.X - _origin.X) / _pixelsPerLonDegree;
			var latRadians = (point.Y - _origin.Y) / -_pixelsPerLonRadian;
			var lat = RadiansToDegrees(2 * Math.Atan(Math.Exp(latRadians)) - Math.PI / 2);

			return new Location() { Latitude = (float)lat, Longitude = (float)lng };
		}

		public static Point2 PointToPixel(Point2 point, double zoom = 0)
		{
			var pixel = new Point2()
			{
				X = point.X * Math.Pow(2, zoom),
				Y = point.Y * Math.Pow(2, zoom)
			};
			return pixel;
		}

		public static Point2 PixelToPoint(Point2 point, double zoom = 0)
		{
			var pixel = new Point2()
			{
				X = point.X / Math.Pow(2, zoom),
				Y = point.Y / Math.Pow(2, zoom)
			};
			return pixel;
		}

		public static Point2 LatLngToPixel(Location loc, double zoom)
			=> PointToPixel(LatLngToPoint(loc), zoom);
		public static Location PixelToLatLng(Point2 pixel, double zoom)
			=> PointToLatLng(PixelToPoint(pixel, zoom));

		public static double Bound(double value, double? opt_min, double? opt_max)
		{
			if (opt_min != null)
				value = Math.Max(value, (double)opt_min);

			if (opt_max != null)
				value = Math.Min(value, (double)opt_max);

			return value;
		}

		//public static RectangleF TileRectanglePosition(int x, int y, long zoom)
		//	=> new RectangleF(x * TileSize, y * TileSize, TileSize, TileSize);

		public static double RadiansToDegrees(double rad)
			=> rad / (Math.PI / 180);

		public static double DegreesToRadians(double deg)
			=> deg * (Math.PI / 180);
	}
}
