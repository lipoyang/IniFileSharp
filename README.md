# IniFileSharp
.NET用のINIファイル読み書きのクラスライブラリです。  
string型, int型, bool型, double型, decimal型のデータをサポートします。

## 使い方

| API | 説明 |
| ---- | ---- |
| IniFile( INIファイルのパス ) | コンストラクタ |
| Exists() | INIファイルが存在するか否かを返す ※|
| Create() | INIファイルを作成する ※|
| ReadInteger( セクション名, キー名, デフォルト値) | int型のデータを取得する |
| ReadString( セクション名, キー名, デフォルト値) | string型のデータを取得する |
| ReadBoolean( セクション名, キー名, デフォルト値) | bool型のデータを取得する |
| ReadDouble( セクション名, キー名, デフォルト値) | double型のデータを取得する |
| ReadDecimal( セクション名, キー名, デフォルト値) | decimal型のデータを取得する |
| WriteInteger( セクション名, キー名, 値) | int型のデータを設定する |
| WriteString( セクション名, キー名, 値) | string型のデータを設定する |
| WriteBoolean( セクション名, キー名, 値) | bool型のデータを設定する |
| WriteDouble( セクション名, キー名, 値) | double型のデータを設定する |
| WriteDecimal( セクション名, キー名, 値) | decimal型のデータを設定する |

※ ディレクトリが既存であればファイルは存在しなくても自動作成されるので、これらのメソッドで存在確認 / 作成するのは必須ではない。
