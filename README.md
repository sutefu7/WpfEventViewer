﻿# WpfEventViewer とは  

  
  

![トップ画像](https://raw.githubusercontent.com/sutefu7/WpfEventViewer/master/Docs/image01.png)

  
　WpfEventViewer は、Windows のイベントログを表示するソフト、いわゆるイベントビューアです。Windows 標準のイベントビューアが文字列による表現なのに対して、WpfEventViewer ではイメージによる表現（データの視覚化）を重視して作成しています。つまり文字列を読んで理解するのではなく、イメージを見て理解します。  

  
　イベントビューアを見たい時、それは何らかのエラーを解決したい時ですよね。あるアプリケーションが、いつ頃から、どのような頻度で、どういった通知を残しているのか、時系列で横断して見ることができたなら。その調査作業を WpfEventViewer が担当して、状況把握をお手伝いいたします。  
  
  
  

## 終了するには

　WpfEventViewer を終了するには、画面上部右側の「×ボタン」をクリックするか、同じく画面上部左側の「青いメニュー」をクリックします。「青いメニュー」をクリックした場合は、さらに「終了」をクリックすることで WpfEventViewer を終了することができます。  

![終了画像](https://raw.githubusercontent.com/sutefu7/WpfEventViewer/master/Docs/image02.png)

  
  
  

## 操作手順

　最初に、カレンダーから説明します。  

  

![カレンダー画像](https://raw.githubusercontent.com/sutefu7/WpfEventViewer/master/Docs/image03.png)

  
　カレンダーは、日表示モード、月表示モード、年表示モードの３段階があります。タイトルをクリックするたびに、日→月→年、と俯瞰的にカテゴリが遷移していき、逆に、該当する各日付コレクションをどれかクリックするたびに、年→月→日、とより詳細にカテゴリが遷移します。  

  
　まずは、見たいイベントログを選択しましょう。「ログ名」の選択欄から見たいイベントログを選択します。おそらく、Application や System など件数が多いイベントログを選択すると応答なしになります。ごめんなさい。どうかその寛大なお心で、そのまま１分前後お待ちください。この時、WpfEventViewer はデータ取得をしています。バグと言ってしまいますが、このバグは、指定したイベントログが初めての場合のみ発生します。１回取得したイベントログはメモリ上で管理していますので、次回以降はさくさく応答するようになります。  

  

![カレンダー画像](https://raw.githubusercontent.com/sutefu7/WpfEventViewer/master/Docs/image04.png)  

  
  
　取得処理が終わった後のイメージ図が以下です。  

  

![カレンダー画像](https://raw.githubusercontent.com/sutefu7/WpfEventViewer/master/Docs/image05.png)  

  
　日付の下に３つの色分けされた数字が表示されています。左から、種類が「情報」のログ件数、「警告」のログ件数、「エラー」のログ件数になります。例えば、3/1（水）は、情報ログが41件、警告ログが3件、エラーログが2件出ています。  

  
　任意の日付をクリックすることで、具体的なログ内容を右側に表示します。上が一覧で任意のログをクリックすることで、下に詳細内容が表示されます。例えば、今、Microsoft-Windows-WinLogon というアプリケーションを選択していて、下部に詳細内容が表示されています。  

  
　画面上部の検索枠から、アプリ名を選択することで「個別」タブページを見ることができるようになります。例えば以下では、Microsoft-Windows-Hyper-V-VmSwitch というアプリケーションのみに絞り込んで状況表示しています。  

  

![カレンダー画像](https://raw.githubusercontent.com/sutefu7/WpfEventViewer/master/Docs/image06.png)  

  
　ここでは、右上にグラフを置いて、アプリケーションの通知の推移を日付別に表示しています。左上にあるカレンダーと同じく日付別の件数表示ですが、グラフの方がより分かりやすいのではと考えています。  

  
  
  

## 最後に

　まだまだ未実装な部分や改良個所がありますが、もしよろしければ、お試しで使ってみてください！  

  
  
  

## アプリ名

　WpfEventViewer  
　Windows デスクトップ用のアプリケーション  
　32 ビット版  


## ダウンロード

　Visual Studio が入っていない方向けに、実行プログラムを圧縮したファイルをアップロードしていますので、以下フォルダよりその時の最新版をダウンロードできます。  

[/BuildFiles/](https://github.com/sutefu7/WpfEventViewer/tree/master/BuildFiles)  

## 動作環境

* Windows 8.1 Pro  
* .NET Framework 4.5.2
※これ以外の環境では未確認です。  

  
  
  

## 開発環境

* Windows 8.1 Pro  
* .NET Framework 4.5.2  
* Visual Studio Community 2015  
* C# + WPF  

  
  
  

## 使用ライブラリ

　以下のライブラリには、それぞれライセンスがありますので注意してください。  

* Livet  
* Fluent.Ribbon  
* OxyPlot.WPF  

## 実現技術の調査で参考にさせていただいたリンク


github  
RibbonWindow を起動すると、黒い画面が表示される問題の対応  
Can not get started with Fluent Ribbon (Black window appeared) #111  
[https://github.com/fluentribbon/Fluent.Ribbon/issues/111](https://github.com/fluentribbon/Fluent.Ribbon/issues/111)  
→ Office2010/Silver.xaml 以外に、Generic.xaml も一緒に指定すると良いみたい  
→2017/04/18 Offce や Windows8 など他のスキン？は正式に機能削除されたので、使えなくなりました  


かずきのBlog  
[C#][WPF]カレンダーを作ってみよう  
[http://blogs.wankuma.com/kazuki/archive/2008/01/20/118342.aspx](http://blogs.wankuma.com/kazuki/archive/2008/01/20/118342.aspx)  
かずきさんのブログに乗っているプログラムをベースに、カレンダーコントロールに年月日切り替え機能を追加しました  


stackoverflow  
ManagementDateTimeConverter.ToDateTime メソッドで、独自文字列型の日付を DateTime 型に変換できる  
[http://stackoverflow.com/questions/23816470/c-sharp-wmi-reading-remote-event-log](http://stackoverflow.com/questions/23816470/c-sharp-wmi-reading-remote-event-log)  


Netplanetes Memo  
Win32_NTLogEvent をデータクラスとして扱う  
[http://www.pine4.net/Memo/Article/Archives/102](http://www.pine4.net/Memo/Article/Archives/102)  


以前機能として組み込んでいたが、機能削除したもの（削除した機能で参考にしてたもの）  


stackoverflow  
MVVM Passing EventArgs As Command Parameter  
[http://stackoverflow.com/questions/6205472/mvvm-passing-eventargs-as-command-parameter](http://stackoverflow.com/questions/6205472/mvvm-passing-eventargs-as-command-parameter)  
LivetCallMethodAction で、イベント引数を受け取りたい。の実装。  


codeplex  
アイコンを指定しても表示されない。の対応  
RibbonToolbar looks in wrong place for images  
[http://fluent.codeplex.com/workitem/18947](http://fluent.codeplex.com/workitem/18947)  


stackoverflow  
How to display values as images in GridViewColumn?  
[http://stackoverflow.com/questions/3823323/how-to-display-values-as-images-in-gridviewcolumn](http://stackoverflow.com/questions/3823323/how-to-display-values-as-images-in-gridviewcolumn)  




