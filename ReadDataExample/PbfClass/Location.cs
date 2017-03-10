using ProtoBuf;

namespace ReadDataExample.PbfClass
{
	[ProtoContract]
	public class Location
	{
		public Location()
		{
		}

		public Location(float latitude, float longitude)
		{
			Latitude = latitude;
			Longitude = longitude;
		}

		[ProtoMember(1)]
		public float Latitude { get; set; }

		[ProtoMember(2)]
		public float Longitude { get; set; }

		public override string ToString()
			=> $"緯度:{Latitude} 経度:{Longitude}";
	}
}