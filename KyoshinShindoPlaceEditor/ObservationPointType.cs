using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyoshinShindoPlaceEditor
{
	[ProtoContract]
	public enum ObservationPointType
	{
		Unknown,
		KiK_NET,
		K_net,
	}

	public static class ObservationPointTypeExtensions
	{
		public static string ToNaturalString(this ObservationPointType type)
		{
			switch (type)
			{
				case ObservationPointType.Unknown:
					return "不明";
				case ObservationPointType.KiK_NET:
					return "KiK-NET";
				case ObservationPointType.K_net:
					return "K-net";
			}
			return "エラー";
		}

		public static ObservationPointType ToObservationPointType(this string str)
			=> str == "1" ? ObservationPointType.KiK_NET : ObservationPointType.K_net;
	}
}
