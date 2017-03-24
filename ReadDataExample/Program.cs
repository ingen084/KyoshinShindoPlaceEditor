using ProtoBuf;
using ReadDataExample.PbfClass;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReadDataExample
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			if (!File.Exists("ShindoObsPoints.pbf"))
			{
				Console.WriteLine("このサンプルを動かすにはKyoshinShindoPlaceEditorで生成したShindoObsPoints.pbfをexe直下に置く必要があります。\nEnterキーで終了...");
				Console.ReadLine();
				return;
			}

			//変数宣言
			List<ObservationPoint> points;

			//Protobufを使ってデシリアライズ
			using (var stream = new FileStream("ShindoObsPoints.pbf", FileMode.Open))
				points = Serializer.Deserialize<List<ObservationPoint>>(stream);

			//この時点ですでに読み込み完了

			//Protobufの仕様上空のリストの場合nullになる(はず)
			if (points == null) return;

			Console.WriteLine($"項目数: {points.Count}");
			Console.WriteLine("1番目の要素の情報");
			Console.WriteLine($"Type: {points[0].Type.ToNaturalString()}");         //観測地点が属するネットワークの種類 文字を取得する場合は拡張メソッドのToNaturalStringを使用することを推奨。
			Console.WriteLine($"Code: {points[0].Code}");                           //ユニークな観測地点のコード名
			Console.WriteLine($"IsSuspended: {points[0].IsSuspended}");             //観測地点が休止しているかどうか(というかぶっちゃけ有効かどうか) Trueの場合色をチェックしないことを推奨。
			Console.WriteLine($"Name: {points[0].Name}");                           //観測地点名
			Console.WriteLine($"Region: {points[0].Region}");                       //観測地点が属する大まかな地名の名称 (都道府県だけ取得したい場合は『 』(半角スペース)で区切った１つ目の要素を取得すればできる。ただし例外もあるので各都道府県はきちんと名前で用意して比較するべき？)
			Console.WriteLine($"Location: {points[0].Location}");                   //地理座標 震度マップを他の場所に移す場合などに有効。
			Console.WriteLine($"Point: {points[0].Point?.ToString() ?? "なし"}"); //強震モニタ上でのピクセル座標 nullの場合は未設定。
			Console.WriteLine($"ClassificationId: {points[0].ClassificationId}");
			Console.WriteLine($"PrefectureClassificationId: {points[0].PrefectureClassificationId}");

			Console.WriteLine("Enterキーで終了...");
			Console.ReadLine();
		}
	}
}