using ProtoBuf;

namespace ReadDataExample.PbfClass
{
	[ProtoContract]
	public enum ObservationPointType
	{
		Unknown,
		KiK_net,
		K_NET,
	}

	public static class ObservationPointTypeExtensions
	{
		public static string ToNaturalString(this ObservationPointType type)
		{
			switch (type)
			{
				case ObservationPointType.Unknown:
					return "不明";

				case ObservationPointType.KiK_net:
					return "KiK-net";

				case ObservationPointType.K_NET:
					return "K-NET";
			}
			return "エラー";
		}

		public static ObservationPointType ToObservationPointType(this string str)
			=> str == "1" ? ObservationPointType.KiK_net : ObservationPointType.K_NET;
	}
}