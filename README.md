# Othello
Unityで作ったオセロゲーム  
製作期間･･･一週間  
プレイする→[こちら](https://wataru199410.github.io/Othello/GameDate/)  

# 画面説明
![Unity WebGL Player _ Othello - Google Chrome 2021_10_29 12_02_31](https://user-images.githubusercontent.com/89332031/139368270-ba5154e1-3a90-4c53-9982-1d7d5c76bab3.png)
**操作方法**  
石を置きたいところにカーソルを合わせて左クリック  


# 開発環境
Windows  
Unity2020.3.17  

# 概要
ベーシックなオセロを作りたいと思い作りました。  
**プログラム面**  
クラスの継承を意識して書きました。  
コードが長くなったり、頻繁に使う時はメソッドにしたり、定数も使い読みやすいコードを意識してみたんですが、あまり納得いかず。  
石がひっくり返せるかの判定をするメソッドは形にできたのですが、石の状態を入れる二次元配列と、実際の盤上の石の状態が紐づけが考え付かなくてこちらのサイトを参考にさせてもらいました。  
XR-HUB様[【Unity 入門】2時間で作る五目並べゲーム！](https://xr-hub.com/archives/13899)  

**ゲーム面**  
現在の手番を色を変えつつ表示したり、オセロは相手の石がひっくり返せないところには石が置けないので、置けない時には注意文を表示したりと少しの工夫でゲームは遊びやすくなるんだなと実感しました。  

**バグ**  
石が盤外に生成されてしまうバグが発生。  
とりあえず盤上の周りに空のobjectを置き、その空のobjectに当たったら石を消す。という方法で対応しました。  
**反省点**  
様々なアスペクト比に対応するにはどうしたらいいかまだ理解できなかった  
objectや変数の命名をどうしたらもっといいコードにできるのか勉強不足  

# 参考にさせてもらったサイト
XR-HUB様[【Unity 入門】2時間で作る五目並べゲーム！](https://xr-hub.com/archives/13899)  
Qiita[Unity3D/C#で簡単なリバーシ(オセロ)を作る！！Part1](https://qiita.com/t-o2mt/items/40e4bca24011dd88d8a7)  
Qiita[Unity3D/C#で簡単なリバーシ(オセロ)を作る！！Part2](https://qiita.com/t-o2mt/items/7ec46c62107f965572c1)  
# 素材をお借りしたサイト
音人さま[ホームページ](https://on-jin.com/)



