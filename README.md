# WpfEventViewer とは  

<br >
<br >
![トップ画像](https://raw.githubusercontent.com/sutefu7/WpfEventViewer/master/Docs/image01.png)  

<br>
　WpfEventViewer は、Windows のイベントログを表示するソフト、いわゆるイベントビューアです。Windows 標準のイベントビューアが文字列による表現なのに対して、WpfEventViewer ではイメージによる表現（データの視覚化）を重視して作成しています。つまり文字列を読んで理解するのではなく、イメージを見て理解します。  

　イベントビューアを見たい時、それは何らかのエラーを解決したい時ですよね。あるアプリケーションが、いつ頃から、どのような頻度で、どういった通知を残しているのか、時系列で横断して見ることができたなら。その調査作業を WpfEventViewer が担当して、状況把握をお手伝いいたします。  
<br>
<br>
<br>
## 終了するには

　WpfEventViewer を終了するには、画面上部右側の「×ボタン」をクリックするか、同じく画面上部左側の「青いメニュー」をクリックします。「青いメニュー」をクリックした場合は、さらに「終了」をクリックすることで WpfEventViewer を終了することができます。

![終了画像](https://raw.githubusercontent.com/sutefu7/WpfEventViewer/master/Docs/image02.png)

<br>
<br>
<br>
## 操作方法

　最初に、カレンダーから説明します。
![カレンダー画像](https://raw.githubusercontent.com/sutefu7/WpfEventViewer/master/Docs/image03.png)

<br>
　カレンダーは、日表示モード、月表示モード、年表示モードの３段階があります。タイトルをクリックするたびに、日→月→年、と俯瞰的にカテゴリが遷移していき、逆に、該当する各日付コレクションをどれかクリックするたびに、年→月→日、とより詳細にカテゴリが遷移します。  

　まずは、見たいイベントログを選択しましょう。「ログ名」の選択欄から見たいイベントログを選択します。おそらく、Application や System など件数が多いイベントログを選択すると応答なしになります。ごめんなさい。どうかその寛大なお心で、そのまま１分前後お待ちください。この時、WpfEventViewer はデータ取得をしています。バグと言ってしまいますが、このバグは、指定したイベントログが初めての場合のみ発生します。１回取得したイベントログはメモリ上で管理していますので、次回以降はさくさく応答するようになります。

![カレンダー画像](https://raw.githubusercontent.com/sutefu7/WpfEventViewer/master/Docs/image04.png)  

<br>
　取得処理が終わった後のイメージ図が以下です。  

<br>
![カレンダー画像](https://raw.githubusercontent.com/sutefu7/WpfEventViewer/master/Docs/image05.png)  

　日付の下に３つの色分けされた数字が表示されています。左から、種類が「情報」のログ件数、「警告」のログ件数、「エラー」のログ件数になります。例えば、3/1（水）は、情報ログが41件、警告ログが3件、エラーログが2件出ています。  

　任意の日付をクリックすることで、具体的なログ内容を右側に表示します。上が一覧で任意のログをクリックすることで、下に詳細内容が表示されます。例えば、今、Microsoft-Windows-WinLogon というアプリケーションを選択していて、下部に詳細内容が表示されています。  

　画面上部の検索枠から、アプリ名を選択することで「個別」タブページを見ることができるようになります。例えば以下では、Microsoft-Windows-Hyper-V-VmSwitch というアプリケーションのみに絞り込んで状況表示しています。  

<br>
![カレンダー画像](https://raw.githubusercontent.com/sutefu7/WpfEventViewer/master/Docs/image06.png)  

　ここでは、右上にグラフを置いて、アプリケーションの通知の推移を日付別に表示しています。左上にあるカレンダーと同じく日付別の件数表示ですが、グラフの方がより分かりやすいのではと考えています。  

<br>
<br>
<br>
## 最後に

　まだまだ未実装な部分や改良個所がありますが、もしよろしければ、お試しで使ってみてください！  

<br>
<br>
<br>
## 動作環境

* Windows 8.1 Pro  
* .NET Framework 4.5.2
※これ以外の環境では未確認です。  

<br>
<br>
<br>
## 開発環境

* Windows 8.1 Pro  
* .NET Framework 4.5.2  
* Visual Studio Community 2015  
* C# + WPF  

<br>
<br>
<br>
## 使用ライブラリ

　以下のライブラリには、それぞれライセンスがありますので注意してください。  

* Livet  
* Fluent.Ribbon  
* OxyPlot.WPF  



