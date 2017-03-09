# KyoshinShindoPlaceEditor

強震モニタの色を取得するピクセル座標を変換・編集するアプリケーションです。

## 本体のソースコードを読む前に
このアプリケーションは目的のために開発されたため、可読性を大きく失っています。読む際は心して読んで下さい。

## ビルドに必要なもの
- .NET Framework 4.6.2
- VS2017(それ以外では未確認)

## チュートリアル
左上の強震モニタの画像操作については強震モニタ画像右上の`?`ボタンを参照してください。

このチュートリアルではとりあえずNIEDの観測点情報のCSVデータからベースを生成し、EqWatchのデータをインポートするところまでを解説します。

挙動がおかしい場合や、動作を停止した場合は下記のFAQを参考にしてください。

1. とりあえず起動します。右リストには何も無いはずです。
2. まずはNIEDのデータをインポートしてみましょう。 NIEDのページ( http://www.kyoshin.bosai.go.jp/kyoshin/db/index.html?all )の上部にある、`観測点一覧(CSVファイル)は、こちら（ K-NET&KiK-net、K-NET、 KiK-net）をクリックしてダウンロードできます。`の、`K-NET`、`KiK-net`を個別にダウンロードし、このアプリケーションのディレクトリに配置します。
3. 右上にある`NIEDの観測点データからインポート`ボタンを押してください。ファイルが存在しない場合はエラーが表示されます。ここで動作を停止する場合はバグもしくは不正なファイルを読み込ませている可能性があります。もう一度確認してください。
4. 正常にインポートされていることが確認できたら、次はEqWatchのデータをインポートしてみましょう。
5. まず、`EqWatch.exe`と同じディレクトリにある`Kansokuten.dat`をこのアプリケーションのディレクトリに **コピー** してください。(このあと編集するためです)
6. **コピー先のファイルを** 適当なテキストエディタで開いたあと、すべての`烏海`を`鳥海`に置き換えてください。(余談:烏海市は中国の都市)
7. 保存したあと、右上の`EqWatchからインポート`ボタンを押してください。
8. うまく行けば追加0件(更新のみ)になるはずですが、情報が更新などされていた場合はその限りではありません。
9. ズレがある場所がないか左上のマップをチェックして、(右のリストの項目を選択すると左下のマップに赤点が表示されるので場所確認に便利です。マップは右ドラッグで移動できます。)適度修正してください。(特に沖縄周辺)
10. **保存ボタンを押さないと保存されません。** 終了する前には必ず保存するようにしておきましょう。

- 作業を再開する場合は(pbfまたはcsv、前回保存した方の)読み込みボタンを押しましょう。

## pbfファイルとcsvファイルの違い
### pbf
ファイルサイズが少し小さくなります。読み込みが非常に高速です。(まだないけど).protoファイルがあれば様々な言語で直接利用することができます。

### csv
文字ベースになるためファイルサイズが少し大きくなりますが、どのアプリケーションでも簡単に処理することができます。

## 保存したファイルの使用方法
pbf形式にて保存したファイルを読み込む際には`ReadDataExample`を参照してください。

`Program.cs`に重要なことは大体書いてあります。(.protoかけてなくてスミマセン！)

csv形式で保存したファイルの出力形式は、

`所属しているネットワークの種類(0=不明,1=KiK-net,2=K-NET),地点コード,休止(無効)状態にあるかどうか(True/False),観測地点名,観測地点が属する地域の名称,緯度,経度,強震モニタ上でのX座標,強震モニタ上でのY座標`

となっています。強震モニタ上での座標がない場合、X,Y共に空になります。手動微調整する用に作っています。

## 利用について
このアプリケーションで作成したファイルをアプリケーションに使用する際はできるだけ(個人でしか利用しないとしても報告していただければ喜びます)作者(@ingen084)に報告してください。クレジット表記は任意です。

このアプリケーションを添付して配布などは要相談でお願いします。

というか、KyoshinShindoPlaceEditorのソースの方はあまりにもクソすぎるので使わないほうがいいです。マジで(マジで)

サンプルプロジェクトの`PbfClass`フォルダの中に入っているクラス群は自由に使用してください。

もちろん、名前空間やクラス名、プロパティ名の変更などはご自由にどうぞ。

保存したファイルの拡張子を変更して使用してることを気づかせないようなことも可能です。

## 設定
`KyoshinShindoPlaceEditor.exe.config`を編集します。
```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <configSections>
        <sectionGroup name="applicationSettings" type="System.Configuration.ApplicationSettingsGroup, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" >
            <section name="KyoshinShindoPlaceEditor.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
        </sectionGroup>
    </configSections>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.2" />
    </startup>
    <applicationSettings>
        <KyoshinShindoPlaceEditor.Properties.Settings>
            <setting name="PbfFilename" serializeAs="String">
                <value>[読み込むpbfファイルのパス]</value>
            </setting>
            <setting name="CsvFilename" serializeAs="String">
                <value>[読み込むcsvファイルのパス]</value>
            </setting>
        </KyoshinShindoPlaceEditor.Properties.Settings>
    </applicationSettings>
</configuration>
```
ここの`[読み込むpbfファイルのパス]` `[読み込むpbfファイルのパス]`を編集することで、読み込みボタンを押した際に読み込まれるファイルを変更することができます。

絶対・相対パス共に利用できますので、是非活用してください。

## FAQ
### 使い方わかんねぇ
この通りガバガバ解説なのでなんでも聞いてください。

### 落ちた
結構エラー処理適当なので
状況を教えてくれるかデバッグしてくれると助かります。

### プルリクできないんだけど？
いつかGitHubに上げる可能性が微レ存なのでそれまではTwitterのDMかなんかでよろしくお願いします。

### なんやこのクソース アホくさ。辞めたらこの仕事?
わかる