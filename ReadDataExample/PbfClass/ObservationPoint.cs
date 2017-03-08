﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadDataExample.PbfClass
{
	[ProtoContract]
	public class ObservationPoint : IComparable
	{
		public ObservationPoint() { }
		public ObservationPoint(ObservationPointType type, string code, bool isSuspended, string name, string pref, Location location, Point2? point = null)
		{
			Type = type;
			Code = code;
			IsSuspended = isSuspended;
			Name = name;
			Region = pref;
			Location = location;
			Point = point;
		}

		/// <summary>
		/// 観測地点のネットワークの種類
		/// </summary>
		[ProtoMember(1)]
		public ObservationPointType Type { get; set; }

		/// <summary>
		/// 観測点コード
		/// </summary>
		[ProtoMember(2)]
		public string Code { get; set; }

		/// <summary>
		/// 観測地点が休止状態(無効)かどうか
		/// </summary>
		[ProtoMember(3)]
		public bool IsSuspended { get; set; }

		/// <summary>
		/// 観測点名
		/// </summary>
		[ProtoMember(4)]
		public string Name { get; set; }

		/// <summary>
		/// 観測点広域名
		/// </summary>
		[ProtoMember(5)]
		public string Region { get; set; }

		/// <summary>
		/// 地理座標
		/// </summary>
		[ProtoMember(6)]
		public Location Location { get; set; }

		/// <summary>
		/// 強震モニタ画像上での座標
		/// </summary>
		[ProtoMember(7)]
		public Point2? Point { get; set; }

		public int CompareTo(object obj)
		{
			if (!(obj is ObservationPoint ins))
				throw new ArgumentException("比較対象はObservationPointでなければなりません。");
			return Code.CompareTo(ins.Code);
		}
	}
}