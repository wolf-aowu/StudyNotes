# Html

官方文档地址：https://whatwg-cn.github.io/html/multipage/

英文版官方文档地址：https://html.spec.whatwg.org/multipage/

其他参考网址：

https://www.w3cschool.cn/html/dict/

### 元素

![](图片\html 元素.png)

开始标签（Opening tag）：包含元素的名称（本例为 p），被左、右角括号所包围。开头标签标志着元素开始或开始生效的地方。在这个示例中，它在段落文本的开始之前。

内容（Content）：元素的内容，本例中就是段落的文本。

结束标签（Closing tag）：与开始标签相似，只是其在元素名之前包含了一个斜杠。这标志着该元素的结束。没有包含关闭标签是一个常见的初学者错误，它可能会产生奇特的结果。

空元素：不是所有元素都拥有开始标签、内容和结束标签，一些元素只有一个标签，通常用来在此元素所在位置插入/嵌入一些东西。这些元素被称为空元素。例如：`<img>` 是用来在页面插入一张指定的图片。

![](图片\元素中的属性.png)

属性：属性包含元素的额外信息，这些信息不会出现在实际内容中。在上面的例子中，`class` 是一个识别名称，以后为元素设置样式信息时更加方便。

属性必须包含：

- 一个空格，它在属性和元素名称之间。如果一个元素具有多个属性，则每个属性之间必须由空格分隔。

- 属性名称，后面跟着一个等于号。

- 一个属性值，由一对引号（""）引起来。在某些情况下省略引号也是允许的，但建议始终添加引号。

  ``` html
  <a href=https://www.mozilla.org/>favorite website</a>
  <!-- 当再添加一个 title 属性，就会出现问题 -->
  <a href=https://www.mozilla.org/ title=The Mozilla homepage>favorite website</a>
  ```

  此时浏览器会误解标记，把 `title` 属性理解为三个属性 —— `title` 的属性值为 `The` ，另外还有两个布尔属性 `Mozilla` 和 `homepage`，在这个编码里面它会报错或者出现异常行为。

存在没有值的属性，这些属性被称为布尔属性。布尔属性只能有一个值，这个值一般与属性名称相同。例如：`disabled` 属性，可以将其分配给表单输入元素。用它来禁用表单输入元素，这样用户就不能输入了。被禁用的元素通常有一个灰色的外观。

``` html
<input type="text" disabled="disabled" />
<!-- 使用 disabled 属性来防止终端用户输入文本到输入框中 -->
<input type="text" disabled />

<!-- 下面这个输入框不包含 disabled 属性，所以用户可以向其中输入 -->
<input type="text" />
```

#### 类别

HTML 有两种重要的元素类别：块级元素和内联元素。

块级元素：块级元素在页面中以块的形式展现。<font color=skyblue>一个块级元素出现在它前面的内容之后的新行上。任何跟在块级元素后面的内容也会出现在新的行上。</font>块级元素通常是页面上的结构元素。例如，一个块级元素可能代表标题、段落、列表、导航菜单或页脚。<font color=skyblue>一个块级元素不会嵌套在一个内联元素里面，但它可能嵌套在另一个块级元素里面。</font>

内联元素：内联元素通常出现在块级元素中并环绕文档内容的一小部分，而不是一整个段落或者一组内容。内联元素不会导致文本换行。它通常与文本一起使用，例如，`<a>` 元素创建一个超链接，`<em>` 和 `<strong>` 等元素创建强调。

<font color=skyblue>注意</font>：HTML5 重新定义了元素的类别：https://html.spec.whatwg.org/multipage/indices.html#element-content-categorie。这些新的定义更精确。

<font color=skyblue>注意</font>：这里的 “块” 和 “内联” 不应该与 CSS 盒子的类型块级盒子（block_box）和内联盒子（inline_box）中的同名术语相混淆。尽管它们默认是相关的，但改变 CSS 显示类型并不会改变元素的分类，也不会影响它可以包含和被包含于哪些元素。防止这种混淆也是 HTML5 摒弃这些术语的原因之一。

常见块级元素：

`body`、`main`、`header`、`footer`、`section`、`nav`、`aside`、`div`、`h1-h6`、`p`、`ul`、`ol`、`li` 等。

在 css 中，将内联元素转变为块级元素 `display: block;`。

<font color=skyblue>块级元素的 `height` 和 `width` 对于内联元素是没有用的。同时 `padding` 和 `margin` 也仅在水平方向应用（准确点是不会在垂直方向上创造出新的空间，padding 会拓宽盒子的大小但是内容在垂直方向的位置是不变的，如果它是块级元素同样是用 padding，内容会往下移动一点）。</font>

常见内联元素：

`a`、`img`、`strong`、`em`、`button` 等。

在 css 中，将块级元素转变为内联元素 `display: inline;`。

### HTML 结构

``` html
<!doctype html>
<html lang="zh-CN">
  <head>
    <meta charset="utf-8" />
    <title>我的测试站点</title>
  </head>
  <body>
    <p>这是我的页面</p>
  </body>
</html>
```

`<!doctype html>`：声明文档类型。源于过去用于检测文档错误和其他有用的东西。

`<html></html>`：`<html>` 元素包裹了页面中所有的内容，有时被称为根元素。

`<head></head>`：`<head>` 元素是一个容器，它包含了所有想包含在 HTML 页面但不在 HTML 页面中显示的内容。这些内容包括你想在搜索结果中出现的关键字和页面描述、CSS 样式、字符集声明等等。

`<meta charset="utf-8">`：`<meta>` 元素代表了不能有其他 HTML 元相关元素表示元数据，比如 `<base>`、`<link>`、`<script>`、`<style>` 或 `<title>`。元数据就是描述数据的数据。`charset` 属性将你的文档的字符集设置为 UTF-8，其中包括绝大多数人类书面语言的大多数字符。有了这个设置，页面现在可以处理它可能包含的任何文本内容。没有理由不对它进行设置，它可以帮助避免以后的一些问题。

`<title></title>`：`<title>` 元素设置页面的标题，也就是出现在该页面加载的浏览器标签中的内容。当页面被加入书签时，页面标题也被用来描述该页面。元素的内容也被用在搜索结果中。

`<body></body>`：`<body>` 元素包含了访问页面时所有显示在页面上的内容，包含文本、图片、视频、游戏、可播放音频轨道等。

### HTML 中的空白

下面两个代码片段是等价的：

```html
<p>狗 狗 很 呆 萌。</p>

<p>狗 狗        很
         呆 萌。</p>
```

无论在 HTML 元素的内容中使用多少空格（包括一个或多个空白字符或换行），当渲染这些代码的时候，HTML 解释器会将连续出现的空白字符减少为一个单独的空格符。

### 实体引用

在 HTML 中，字符 `<`、`>`、`"`、`'` 和 `&` 是特殊字符。它们是 HTML 语法自身的一部分，如果希望它们不被浏览器视为代码并解释，需要对它们进行如下转换。每个字符引用以符号 `&` 开始，以分号 `;` 结束。

| 原义字符 | 等价字符引用 |
| -------- | ------------ |
| <        | `&lt;`       |
| >        | `&gt;`       |
| "        | `&quot;`     |
| '        | `&apos;`     |
| &        | `&amp;`      |

### HTML 的属性

#### 设定主语言

通过添加 lang 属性到 HTML 开始的标签中来实现。这在很多方面都很有用。如果你的 HTML 文档的语言设置好了，那么你的 HTML 文档就会被搜索引擎更有效地索引（例如，允许它在特定于语言的结果中正确显示），对于那些使用屏幕阅读器的视障人士也很有用（例如，法语和英语中都有“six”这个单词，但是发音却完全不同）。

``` html
<html lang="zh-CN">
  ...
</html>
```

还可以将文档的分段设置为不同的语言。例如，我们可以把日语部分设置为日语。

``` html
<p>Japanese example: <span lang="ja">ご飯が熱い。</span>.</p>
```

这些代码是根据 [ISO 639-1](https://zh.wikipedia.org/wiki/ISO_639-1) 标准定义的。

参考文档：https://www.w3.org/International/articles/language-tags/

### HTML 的头部

#### 元数据：`<meta>` 元素

元数据就是描述数据的数据。`<meta>` 元素代表了不能有其他 HTML 元相关元素表示元数据，比如 `<base>`、`<link>`、`<script>`、`<style>` 或 `<title>`。有很多不同种类的 `<meta>` 元素可以被包含进页面的 `<head>` 元素。

`charset` 属性将文档的字符集设置为 UTF-8，其中包括绝大多数人类书面语言的大多数字符。有了这个设置，页面现在可以处理它可能包含的任何文本内容。没有理由不对它进行设置，它可以帮助避免以后的一些问题。例如：当字符集被设置为 `ISO-8859-1`（拉丁字母表的字符集） 时不能将日文正确显示。

``` html
<meta charset="utf-8" />
```

许多 `<meta>` 特性已经不再使用。例如，keyword `<meta>` 元素（`<meta name="keywords" content="fill, in, your, keywords, here">`，为搜索引擎提供关键词，用于确定该页面与不同搜索词的相关性）已经被搜索引擎忽略了，因为作弊者填充了大量关键词到 keyword，错误地引导搜索结果。

##### 作者和描述

许多 `<meta>` 元素包含了 `name` 和 `content` 属性。

`name`：指定了 meta 元素的类型，说明该元素包含了什么类型的信息。

`content`：指定了实际的元数据内容。

这两个 meta 元素对于定义你的页面的作者和提供页面的简要描述是很有用的。

```
<meta name="author" content="Chris Mills" />
<meta
  name="description"
  content="The MDN Web Docs Learning Area aims to provide
complete beginners to the Web with all they need to know to get
started with developing web sites and applications." />
```

指定作者在某些情况下是很有用的：如果你需要联系页面的作者，问一些关于页面内容的问题。一些内容管理系统能够自动获取页面作者的信息，然后用于某些用途。

指定一个包括与你的页面内容有关的关键词的描述是有用的，因为它有可能使你的页面在搜索引擎进行的相关搜索中出现得更多（这些行为在术语上被称为：搜索引擎优化 或 SEO）。

##### description

description 也被使用在搜索引擎显示的结果页中。

例如 MDN 首页（https://developer.mozilla.org/zh-CN/），查看网页源代码后可以找到下面这段代码。

```html
<meta
  name="description"
  content="The MDN Web Docs site
  provides information about Open Web technologies
  including HTML, CSS, and APIs for both Web sites and
  progressive web apps." />
```

在谷歌中搜索 "MDN Web Docs"，会看见如下所示。但对于百度搜索引擎似乎不适用。

![](D:\Git 仓库\笔记\StudyNotes\Notes-网页\图片\description 谷歌搜索优化.png)

##### 其他类型元数据

当在网站上查看源码时，也会发现其他类型的元数据。在网站上看到的许多功能都是专有创作，旨在向某些网站（如社交网站）提供可使用的特定信息。

例如，Facebook 编写的元数据协议 [Open Graph Data](https://ogp.me/) 为网站提供了更丰富的元数据。

例如 MDN 首页（https://developer.mozilla.org/zh-CN/），找到下面这段代码，在 Facebook 创建的帖子中链接到 MDN 首页时，该链接将会显示一个图像和描述。

```html
<meta property="og:url" content="https://developer.mozilla.org" />
<meta property="og:title" content="MDN Web Docs" />
<meta property="og:type" content="website" />
<meta property="og:locale" content="en_US" />
<meta property="og:description"
      content="The MDN Web Docs site provides information about Open Web technologies including HTML, CSS, and APIs for both Web sites and progressive web apps." />
<meta property="og:image" content="https://developer.mozilla.org/mdn-social-share.cd6c4a5a.png" />
<meta property="og:image:type" content="image/png" />
<meta property="og:image:height" content="1080" />
<meta property="og:image:width" content="1920" />
<meta property="og:image:alt"
      content="The MDN Web Docs logo, featuring a blue accent color, displayed on a solid black background." />
<meta property="og:site_name" content="MDN Web Docs" />
```

<img src="图片\Facebook 的自定义元数据.png" style="zoom: 33%;" />

Twitter 也拥有自己的类型的专有元数据协议（称为 [Twitter Cards](https://developer.twitter.com/en/docs/twitter-for-websites/cards/overview/abouts-cards)），当网站的 URL 显示在 twitter.com 上时，它具有相似的效果。

``` html
<meta name="twitter:title" content="Mozilla Developer Network" />
```

##### SEO（搜索引擎优化）

SEO（搜索引擎优化）是一种让网站在搜索引擎结果中更加清晰，也帮助我们将搜索结果更靠前。

搜索引擎抓取网页，跟随页面之间的链接，并索引找到的内容。搜索时，搜索引擎会显示索引内容。爬行者遵守规则。如果你在为网站进行搜索引擎优化时密切关注这些规则，则会为网站提供最好的机会，以便在首批结果中显示，增加流量和可能的收入（用于电子商务和广告）。

搜索引擎为 SEO 提供了一些指导，但大型搜索引擎将结果排名保持为商业秘密。SEO 结合了官方搜索引擎指南，经验知识和科学论文或专利的理论知识。

SEO 方法分为三大类：

技术：使用语义标记内容HTML。浏览网站时，抓取工具应该只找到你要编入索引的内容。

撰稿：使用访问者的词汇编写内容。使用文本和图像，以便抓取工具可以理解主题。

声望：当其他已建立的站点链接到你的站点时，你获得最多流量。

#### 自定义图标

可以在元数据中添加对自定义图标的引用，它们会在某些场景下显示。最常见的用例为 favicon（为“favorites icon”的缩写，在浏览器的“收藏夹”及“书签”列表中显示）。

这个不起眼的图标已经存在很多年了，16 像素的方形图标是第一种类型。你可以看见（取决于浏览器）这些图标出现在浏览器每一个打开的标签页中以及书签面板中的书签页面旁边。

页面添加网页图标的方式：

1. 将其保存在与网站的索引页面相同的目录中，以 `.ico` 格式保存（大多数浏览器支持更通用的格式，如 `.gif` 或 `.png`）

2. 将以下行添加到 HTML 的 `head` 块中以引用它：

   ``` html
   <link rel="icon" href="favicon.ico" type="image/x-icon" />
   ```

如今还有很多其他的图标类型可以考虑。例如：

``` html
<!-- 含有高分辨率 Retina 显示屏的第三代 iPad：-->
<link
  rel="apple-touch-icon-precomposed"
  sizes="144x144"
  href="https://developer.mozilla.org/static/img/favicon144.png" />
<!-- 含有高分辨率 Retina 显示屏的 iPhone：-->
<link
  rel="apple-touch-icon-precomposed"
  sizes="114x114"
  href="https://developer.mozilla.org/static/img/favicon114.png" />
<!-- 第一代和第二代 iPad：-->
<link
  rel="apple-touch-icon-precomposed"
  sizes="72x72"
  href="https://developer.mozilla.org/static/img/favicon72.png" />
<!-- 不含高分辨率 Retina 显示的 iPhone、iPod Touch 和 Android 2.1+ 设备：-->
<link
  rel="apple-touch-icon-precomposed"
  href="https://developer.mozilla.org/static/img/favicon57.png" />
<!-- 基本 favicon -->
<link
  rel="icon"
  href="https://developer.mozilla.org/static/img/favicon32.png" />
```

这些注释解释了每个图标的用途——这些元素涵盖的东西提供一个高分辨率图标，这些高分辨率图标当网站保存到 iPad 的主屏幕时使用。

如果网站使用了内容安全策略（Content Security Policy，CSP）来增加安全性，这个策略会应用在 favicon 图标上。如果遇到了图标没有被加载的问题，需要确认 [`Content-Security-Policy`](https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Headers/Content-Security-Policy) 响应头的 [`img-src` 指令](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/img-src) 没有阻止访问图标。<font color=glass>没有看懂。</font>

#### 应用 CSS 和 JavaScript

几乎你使用的所有网站都会使用 CSS 来让网页更加炫酷，并使用 JavaScript 来让网页有交互功能，比如视频播放器、地图、游戏以及更多功能。这些应用在网页中很常见，它们分别使用 `link` 元素以及 `script` 元素。

`<link>`：经常位于文档头部，它有两个属性，`rel="stylesheet"` 表明这是文档的样式表，而 `href` 包含了样式表文件的路径。

``` html
<link rel="stylesheet" href="my-css-file.css" />
```

`<script>`：也应当放在文档的头部，并包含 `src` 属性来指向需要加载的 JavaScript 文件路径，同时最好加上 `defer` 以告诉浏览器在解析完成 HTML 后再加载 JavaScript。这样可以确保在加载脚本之前浏览器已经解析了所有的 HTML 内容。这样你就不会因为 JavaScript 试图访问页面上不存在的 HTML 元素而产生错误。实际上有很多方法来处理在你的页面上加载 JavaScript，但对于现代浏览器来说，这是最可靠的方法。

更多脚本加载策略，请访问：https://developer.mozilla.org/zh-CN/docs/Learn/JavaScript/First_steps/What_is_JavaScript#脚本调用策略

``` html
<script src="my-js-file.js" defer></script>
```

### HTML 文本处理基础

内容结构化会使读者的阅读体验更轻松，更愉快。

正确地使用元素表达语义的优点：

- 能够使读者更快速地查找相关内容
- 对网页建立索引的搜索引擎会将标题的内容视为影响网页搜索排名的重要关键字。
- 严重视力障碍者通常使用屏幕阅读器来阅读网页，该软件提供了快速访问给定文本内容的方法。在使用的各种技术中，它们通过朗读标题来提供文档的概述，让用户能快速找到需要的信息。如果标题不可用，用户将不得不听到整个文档被大声朗读。
- 使用 CSS 样式化内容，或使用 JavaScript 做一些有趣的事情，需要包含相关内容的元素，使得 CSS/JavaScript 可以有效地定位它。

如果使用 `<span style="font-size: 32px; margin: 21px 0; display: block;">这是顶级标题吗？</span>` 虽然能够实现与 `<h1>` 元素相同的效果，但它没有语义，也没有上述的优点。

#### 标题

共有六种标题元素：h1 ~ h6。每个元素代表文档中不同级别的内容：`<h1>` 表示主标题，`<h2>` 表示二级子标题，`<h3>` 表示三级子标题，依此类推。

<font color=skyblue>最好只对每个页面使用一次 `<h1>`。</font>表示顶级标题。

在现有的六个标题层次中，除非觉得有必要，否则应该<font color=skyblue>争取每页使用不超过三个。</font>有很多层次的文件（例如，深层次的标题层次）会变得笨重，难以浏览。在这种情况下，如果可能的话，建议将内容分散到多个页面。

#### 段落

由 `<p>` 元素标签进行定义。

#### 列表

有三种不同类型的列表。

##### 无序列表

``` html
<ul>
  <li>豆浆</li>
  <li>油条</li>
  <li>豆汁</li>
  <li>焦圈</li>
</ul>
```

##### 有序列表

``` html
<ol>
  <li>沿这条路走到头</li>
  <li>右转</li>
  <li>直行穿过第一个十字路口</li>
  <li>在第三个十字路口处左转</li>
  <li>继续走 300 米，学校就在你的右手边</li>
</ol>
```

##### 嵌套列表

```html
<ol>
  <li>
    先用蛋白一个、盐半茶匙及淀粉两大匙搅拌均匀，调成“腌料”，鸡胸肉切成约一厘米见方的碎丁并用“腌料”搅拌均匀，腌渍半小时。
  </li>
  <li>
    用酱油一大匙、淀粉水一大匙、糖半茶匙、盐四分之一茶匙、白醋一茶匙、蒜末半茶匙调拌均匀，调成“综合调味料”。
  </li>
  <li>
    鸡丁腌好以后，色拉油下锅烧热，先将鸡丁倒入锅内，用大火快炸半分钟，炸到变色之后，捞出来沥干油汁备用。
  </li>
  <li>
    在锅里留下约两大匙油，烧热后将切好的干辣椒下锅，用小火炒香后，再放入花椒粒和葱段一起爆香。随后鸡丁重新下锅，用大火快炒片刻后，再倒入“综合调味料”继续快炒。
    <ul>
      <li>如果你采用正宗川菜做法，最后只需加入花生米，炒拌几下就可以起锅了。</li>
      <li>如果你在北方，可加入黄瓜丁、胡萝卜丁和花生米，翻炒后起锅。</li>
    </ul>
  </li>
</ol>
```

#### 重点强调

##### 语气强调（特殊语气）

在口语表达中，我们有时会强调某些字，用来改变这句话的意思。同样地，在书面用语中，我们可以使用斜体字来达到同样的效果。例如，下面两个句子便有不同的意思：

> 我很庆幸你没有迟到。
>
> 我很*庆幸*你没有*迟到*。

第一句话听起来真的像松了一口气因为没有迟到。相反，<font color=skyblue>第二句话听起来具有讽刺性而且有隐含的攻击性</font>，表达对一个人迟到的恼怒。

在 HTML 中我们用 `em`（emphasis）元素来标记这样的情况。这样做既可以让文档读起来更有趣，也可以被屏幕阅读器识别，并以不同的语调发出。浏览器默认样式为斜体，但不应该纯粹为了获得斜体风格而使用这个标签。如果仅仅为了获得斜体样式而不增加语义辅助，应该使用 `span` 元素和一些 CSS，或者是 `i` 元素。

``` html
<p>我很<em>庆幸</em>你没有<em>迟到</em>。</p>
```

##### 重音强调（表示重要）

为了强调重要的词，在口语方面我们往往用重音强调，在书面用语中则是用粗体字来达到强调的效果。例如下面这段：

> 这杯液体**毒性很大**。
>
> 就指望你了，千万**不要**迟到！

在 HTML 中，用 `strong`（strong importance）元素来标记这样的情况。除了使文档更有用之外，也可以被屏幕阅读器识别，并以不同的语调发出。浏览器默认样式为粗体，但不应该纯粹为了获得粗体风格而使用这个标签。如果仅仅为了获得粗体样式而不增加语义辅助，你应该使用 `span` 元素和一些 CSS，或者是 `b` 元素。

``` html
<p>这杯液体<strong>毒性很大</strong>。</p>
<p>就指望你了，千万<strong>不要</strong>迟到！</p>
<!-- em 和 strong 可以互相嵌套 -->
<p>
  这杯液体<strong><em>毒性很大</em></strong>——如果饮用了它，你<em><strong>可能会死</strong></em>。
</p>
```

#### 结构划分

在 HTML 中，可以通过 `div` 划分结构，但 `div` 不表示任何含义的结构划分。所以 HTML5 提供了一些具有特殊含义的结构划分元素，它们在页面上展现的样式与 `div` 一致。

参考网址：https://html.spec.whatwg.org/multipage/sections.html#the-article-element

##### nav

nav 元素表示页面的一部分，其目的是在当前文档或其他文档中提供导航链接。导航部分的常见示例是菜单，目录和索引。

并不是所有的链接都必须使用 nav 元素。

参考网址：https://developer.mozilla.org/zh-CN/docs/Web/HTML/Reference/Elements/nav

##### header

header 元素表示介绍性内容，通常是一组介绍性或导航性辅助内容。它可能包含一些标题元素，也可能包含徽标、搜索表单、作者姓名和其他元素。

参考网址：https://developer.mozilla.org/zh-CN/docs/Web/HTML/Reference/Elements/header

##### article

article 元素表示文档、页面、应用或网站中的独立结构，其意在成为可独立分配的或可复用的结构，如在发布中，它可能是论坛帖子、杂志或新闻文章、博客、用户提交的评论、交互式组件，或者其他独立的内容项目。

通常每个 article 包含至少 1 个标题（h1 ~ h6）。article 中内容应该是独立的，可独立传播的。

参考网址：https://developer.mozilla.org/zh-CN/docs/Web/HTML/Reference/Elements/article

##### aside

aside 元素表示一个和其余页面内容几乎无关的部分，被认为是独立于该内容的一部分并且可以被单独的拆分出来而不会使整体受影响。其通常表现为侧边栏或者标注框（call-out boxes）。

参考网址：https://developer.mozilla.org/zh-CN/docs/Web/HTML/Reference/Elements/aside

##### footer

footer 元素素表示其最近的祖先[分段内容](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Guides/Content_categories#分段内容)的页脚或[分段根](https://developer.mozilla.org/zh-CN/docs/Web/HTML/Reference/Elements/Heading_Elements#标注章节内容)元素。footer 通常包含有关该部分作者、版权数据或相关文档链接的信息。

参考网址：https://developer.mozilla.org/zh-CN/docs/Web/HTML/Reference/Elements/footer

#### 斜体字、粗体字、下划线

`<b>`、`<i>`、`<u>` 出现于人们要在文本中使用粗体、斜体、下划线但 CSS 仍然不被完全支持的时期。像这样仅仅影响表象而且没有语义的元素，被称为表象元素（presentational elements）并且不应该再被使用。

HTML5 重新定义了 `<b>`、`<i>` 和 `<u>`，赋予了它们新的但有点令人困惑的语义角色。

最好的经验法则是：只有在没有更合适的元素时，才适合使用 `<b>`、`<i>` 或 `<u>` 来表达传统上用粗体、斜体或下划线表达的意思；而通常情况下是有更合适的元素可供使用的。`<strong>`、`<em>`、`<mark>` 或 `<span>` 可能是更加合适的选择。

始终保持无障碍的开发理念。斜体的概念对使用屏幕阅读器的人或使用拉丁字母以外的书写系统的人没有什么帮助。

`<i>`：用来传达传统上用斜体表达的意义：外国文字，分类名称，技术术语，一种思想 ……

`<b>`：用来传达传统上用粗体表达的意义：关键字，产品名称，引导句 ……

`<u>`：又来表达传统上用下划线表达的意义：专有名词，拼写错误 …… 人们强烈地将下划线与超链接联系起来。因此，在网页中，最好只给链接加下划线。在语义上合适的时候使用 `<u>` 元素，但要考虑使用 CSS 将默认的下划线改为在网页中更合适的东西。如下所示。

``` html
<!-- 学名 -->
<p>
  红喉北蜂鸟（学名：<i>Archilocus colubris</i>）是北美东部最常见的蜂鸟品种。
</p>

<!-- 舶来词 -->
<p>
  菜单上有好多舶来词汇，比如 <i lang="uk-latn">vatrushka</i>（东欧乳酪面包）、<i
    lang="id"
    >nasi goreng</i
  >（印尼炒饭）以及 <i lang="fr">soupe à l'oignon</i>（法式洋葱汤）。
</p>

<!-- 已知的错误书写 -->
<p>总有一天我会改掉写<u class="spelling-error">措字</u>的毛病。</p>

<!-- 在定义中，被定义的术语 -->
<dl>
  <dt>语义化 HTML</dt>
  <dd>根据元素的<b>语义</b>意义而不是外观来使用它们。</dd>
</dl>
```

#### 超链接

超链接是互联网提供的最令人兴奋的创新之一，它们从一开始就一直是互联网的一个特性，使互联网成为*互联的网络*。超链接使我们能够将我们的文档链接到任何其他文档（或其他资源），也可以链接到文档的指定部分，我们可以在一个简单的网址上提供应用程序。几乎任何网络内容都可以转换为链接，点击（或激活）超链接将使网络浏览器转到另一个网址（URL）。URL 可以指向 HTML 文件、文本文件、图像、文本文档、视频和音频文件以及可以在网络上保存的任何其他内容。如果浏览器不知道如何显示或处理文件，它会询问你是否要打开文件（需要选择合适的本地应用来打开或处理文件）或下载文件（以后处理它）。

通过将文本或其他内容包裹在 `<a>` 元素内，并给它一个包含网址的 `href` 属性（也称为超文本引用或目标，它将包含一个网址）来创建一个基本链接。

当锚点元素 `<a>` 包裹块级内容时，称为块级链接。当锚点元素 `<a>` 包裹图片时，称为图片链接。

``` html
<p>
  我创建了一个指向<a href="https://www.mozilla.org/zh-CN/">Mozilla 主页</a>的链接。
</p>
<!-- 块级链接 -->
<a href="https://developer.mozilla.org/zh-CN/">
  <h1>MDN Web 文档</h1>
</a>
<p>自从 2005 年起，就开始记载包括 CSS、HTML、JavaScript 等网络技术。</p>
<!-- 图片链接 -->
<a href="https://developer.mozilla.org/zh-CN/">
  <img src="mdn_logo.svg" alt="MDN Web 文档主页" />
</a>
```

##### 统一资源定位符（URL）

统一资源定位符（Uniform Resource Locator，URL）是一个定义了在网络上的位置的一个文本字符串。例如，Mozilla 的简体中文主页位于 `https://www.mozilla.org/zh-CN/`。

URL 使用路径查找文件。

![](图片\url 目录结构.png)

同一个项目下可以由多个 `index.html` 文件，但它们必须在不同的文件系统目录下。

这个目录结构的根目录是 `creating-hyperlinks`。

如果想要在顶层的 `index.html` 中包含一个指向 `contacts.html` 的超链接，由于它们在同一个目录下，所以只需要：

``` html
<p>
  要联系某位工作人员，请访问我们的<a href="contacts.html">联系人页面</a>。
</p>
```

如果想要在顶层的 `index.html` 中包含一个指向 `projects/index.html` 的超链接只需要使 URL 为 `projects/index.html`。

``` html
<p>请访问我的<a href="projects/index.html">项目主页</a>。</p>
```

如果想要在 `projects/index.html` 中包含一个指向 `pdfs/project-brief.pdf` 的超链接，需要使用 URL 为 `../pdfs/project-brief.pdf`。

```html
<p>点击打开<a href="../pdfs/project-brief.pdf">项目简介</a>。</p>
```

##### 链接到文档片段

超链接除了可以链接到文档外，也可以链接到 HTML 文档的特定部分（被称为文档片段）。要做到这一点，必须首先给要链接到的元素分配一个 id 属性。通常情况下，链接到一个特定的标题是有意义的。为了链接到那个特定的 id，要将它放在 URL 的末尾，并在前面包含井号（`#`）。

``` html
<h2 id="Mailing_address">邮寄地址</h2>

<p>
  要提供意见和建议，请将信件邮寄至<a href="contacts.html#Mailing_address"
    >我们的地址</a
  >。
</p>
```

也可以在同一份文档下，通过链接文档片段，来链接到当前文档的另一部分。

``` html
<p>本页面底部可以找到<a href="#Mailing_address">公司邮寄地址</a>。</p>
```

只有一个 "#" 时，会回到当前文档顶部

``` html
<a href="#">回到顶部</a>
```

##### 电子邮件链接

当点击一个链接或按钮时，可能会开启新的邮件的发送而不是连接到一个资源或页面。这种场景可以使用 `<a>` 元素和 `mailto:` URL 协议实现。

``` html
<a href="mailto:nowhere@mozilla.org">向 nowhere 发邮件</a>
```

**实现效果：**

<a href="mailto:nowhere@mozilla.org">向 nowhere 发邮件</a>

实际上，电子邮件地址是可选的。如果 `href` 属性仅仅只是简单的 `mailto:` 发送新的电子邮件的窗口也会被用户的邮件客户端打开，只是没有收件人的地址信息，这通常在分享链接是很有用的，用户可以给他们选择的地址发送邮件。

除了电子邮件地址，还可以提供其他信息。任何标准的邮件头字段可以被添加到提供的 `mailto` URL 中。其中最常用的是主题（subject）、抄送（cc）和主体（body）（这不是一个真正的标头字段，但允许为新邮件指定一个简短的内容消息）。每个字段及其值被指定为查询项。

``` html
<a
  href="mailto:nowhere@mozilla.org?cc=name2@rapidtables.com&bcc=name3@rapidtables.com&subject=The%20subject%20of%20the%20email&body=The%20body%20of%20the%20email">
  发送含有 cc、bcc、主题和主体的邮件
</a>
```

<a
  href="mailto:nowhere@mozilla.org?cc=name2@rapidtables.com&bcc=name3@rapidtables.com&subject=The%20subject%20of%20the%20email&body=The%20body%20of%20the%20email">发送含有 cc、bcc、主题和主体的邮件</a>

<font color=skyblue>每个字段的值必须使用 URL 编码，即使用百分号转义的非打印字符（不可见字符如制表符、换行符、分页符）和空格。同时注意使用问号（?）来分隔主 URL 与参数值，以及使用 & 符来分隔 mailto: URL 中的各个参数。这是标准的 URL 查询标记方法。阅读 GET 方法以了解哪种 URL 查询标记方法是更常用的。</font>

##### title 属性

title 属性为链接补充信息，如页面包含什么样的信息或需要注意的事情。当鼠标指针悬停在链接上时，标题将作为提示信息出现。链接的标题仅当鼠标悬停在其上时才会显示，这意味着使用键盘来导航网页的人很难获取到标题信息。如果标题信息对于页面非常重要，应该使用所有用户能都方便获取的方式来呈现，例如放在常规文本中。

``` html
<p>
  我创建了一个指向<a
    href="https://www.mozilla.org/zh-CN/"
    title="了解 Mozilla 使命以及如何参与贡献的最佳站点。"
    >Mozilla 主页</a
  >的超链接。
</p>
```

##### download 属性

当要下载的资源而不是浏览器中打开时，为要下载的文件提供一个默认的保存文件名。

``` html
<a href="https://download.mozilla.org/?product=firefox-latest-ssl&os=win64&lang=zh-CN"
  download="firefox-latest-64bit-installer.exe">
  下载最新的 Firefox 中文版 - Windows（64 位）
</a>
```

##### 最佳链接

- 使用清晰的链接措辞。
- 链接文本中包含关键词。
- 不要在链接文本中说到“链接”或“链接到”。因为链接通常是用不同的颜色设计，并且存在下划线，很容易识别。
- 链接标签尽可能短。
- 减少相同文本地多个副本链接到不同地方。避免“单击此处”、“单击此处”、“单击此处”这样脱离上下文的链接文本。
- 当链接需要下载资源或流媒体或打开一个弹出窗口时应该添加明确的措辞。例如下载资源时链接文本提示文件大小，观看视频时提示将在新标签页播放。

例如：

``` html
<!-- 好的链接文本 -->
<p>
    <a href="https://www.mozilla.org/zh-CN/firefox/">下载 Firefox </a>
</p>

<!-- 不好的链接文本 -->
<p>
    <a href="https://www.mozilla.org/zh-CN/firefox/">点击这里</a>下载
</p>
```

#### 图片

使用 `img` 元素。这个元素是空元素（无法包含任何子内容和结束标签）。它需要两个属性才能起作用：`src` 和 `alt`。

`img` 是内联元素，但它同时具有块级元素的行为，如设置宽高，垂直方向设置 `margin` 等。

##### src 属性

`src` 属性包含一个 URL，该 URL 指向要嵌入页面的图像。`src` 属性可以是相对 URL 或绝对 URL，这与 `href` 属性类似。如果没有 `src` 属性，`img` 元素就没有图像可加载。搜索引擎会读取图像文件名并将其计入 SEO，所以应该为图像起一个描述性的文件名。不建议使用绝对 URL，因为当网站迁移到不同域名时需要更新所有绝对 URL。未经许可绝不要将 `src` 属性指向其他网站上的图像，这被称为“热链接（hotlinking）”。大多数人认为这是不道德的，因为这会导致每当有人访问你的页面，都会有另一些不知情的人为图像交付带宽费用。这也导致你无法掌控图像，图像有可能在你不知情的情况下，被删除或替换为尴尬的内容。

##### alt 属性

`alt` 属性的值是图片的文本描述，用于在图片无法显示或者因为网速慢而加载缓慢的情况下使用。这些文字描述可以提供给搜索引擎使用，例如搜索引擎可能会将图片的文字描述和查询条件进行匹配。如果图片仅用于装饰，请添加空的 `alt=""`。如果你把图片嵌套在 `<a>` 标签里，来把图片变成链接，那你还必须提供无障碍的链接文本。在这种情况下，你可以写在同一个 `<a>` 元素里，或者写在图片的 `alt` 属性里，随你喜欢。你不应该将文本放到图像里。例如，如果你的主标题需要有阴影，你可以用 CSS 来达到这个目的，而不是把文本放到图片里。如果真的必须这么做，那就把文本也放到 `alt` 里。

##### 宽度和高度

可以使用 `width` 和 `height` 来指定图片的宽度和高度。它们的值是不带单位的整数，以像素为单位表示图像的宽度和高度。

这样做有一个好处。页面的 HTML 和图片是分开的资源，由浏览器用相互独立的 HTTP(S) 请求来获取。一旦浏览器接收到 HTML，它就会开始将其显示给用户。如果图片尚未接收到（通常会是这种情况，因为图片文件的大小通常比 HTML 文件大得多），那么浏览器将只渲染 HTML，并在图片接收到后立即更新页面。当图片加载完成时，浏览器会将图片添加到页面中。由于图片占据空间，浏览器必须将文本向下移动，以适应图片的位置，这样移动文本对用户来说非常分散注意力，尤其是如果他们已经开始阅读文本的情况下。如果在 HTML 中使用 `width` 和 `height` 属性来指定图片的实际大小，那么在下载图片之前，浏览器就知道需要为其留出多少空间。这样的话，当图片下载完成时，浏览器不需要移动周围的内容。

没有设置 `width` 和 `height` 属性：

![](图片\img 元素没有 width 和 height.png)

设置了 `width` 和 `height` 属性：

![](图片\img 元素有 width 和 height.png)

参考网址：[设置图像的高度和宽度再次变得重要](https://www.smashingmagazine.com/2020/03/setting-height-width-images-important-again/)

使用 HTML 属性来指定图片的实际大小是一个好的实践，但不应该使用它们来调整图片的大小。如果设置的图片大小过大，图片将看起来粗糙、模糊或太小，不仅浪费带宽而且图片还不符合用户需求。如果长宽比不正确，图片也可能会变形。在将图片放到网页上之前，你应使用图像编辑器将其设置为正确的大小。如果确实需要更改图片的大小，应该使用 CSS 来实现。

##### title 属性

以通过给图片增加 `title` 属性来提供鼠标悬停提示。<font color=skyblue>不推荐使用。</font>

参考网址：[title 属性的考验与磨难](https://www.24a11y.com/2017/the-trials-and-tribulations-of-the-title-attribute/)

##### 为图片搭配说明文字

使用 `figure` 和 `figcaption` 元素，为图片提供一个语义容器，在说明文字和图片之间建立清晰的关联。`figcaption` 元素告诉浏览器和辅助技术工具，这段说明文字描述了 `figure` 元素的内容。

``` html
<figure>
  <img
    src="images/dinosaur.jpg"
    alt="The head and torso of a dinosaur skeleton;
            it has a large head with long sharp teeth"
    width="400"
    height="341" />

  <figcaption>
    A T-Rex on display in the Manchester University Museum.
  </figcaption>
</figure>
```

从无障碍的角度来说，说明文字和 `alt` 文本扮演着不同的角色。看得见图片的人们同样可以受益于说明文字，而 `alt` 文字只有在图片无法显示时才会发挥作用。所以，说明文字和 `alt` 的内容不应该一样，因为当图片无法显示时，它们会同时出现。

`figure` 里不一定要是图片，只要是这样的独立内容单元即可：

- 用简洁、易懂的方式表达意图。
- 可以置于页面线性流的某处。
- 为主要内容提供重要的补充说明。

`figure` 可以是几张图片、一段代码、音视频、方程、表格或类似的东西。

##### css 背景图片

<font color=skyblue>如果想为某段文字插入背景图片，而图片在语义上没有任何意义，那么使用 CSS 属性 `background-image` 和其他 `background-*` 属性实现更合理。</font>

``` css
p {
  background-image: url("images/dinosaur.jpg");
}
```

##### 其他生成图片的方法

###### Canvas

`canvas` 元素提供了使用 JavaScript 绘制 2D 图形的 API。

参考网址：https://developer.mozilla.org/zh-CN/docs/Web/API/Canvas_API

###### SVG

可以借助可缩放矢量图形（SVG）来使用线条、曲线和其他几何形状来渲染 2D 图形。借助矢量图形，你可以创建能够以任意尺寸清晰缩放的图像。

参考网址：https://developer.mozilla.org/zh-CN/docs/Web/SVG

###### WebGL

WebGL API 指南将帮助入门 WebGL，这是用于 Web 的 3D 图形 API，可让 Web 内容中使用标准的 OpenGL ES。

参考网址：https://developer.mozilla.org/zh-CN/docs/Web/API/WebGL_API

###### 使用 HTML 音频和视频

与 `<img>` 类似，可以使用 HTML 将 `video` 和 `audio` 嵌入到网页中，并控制其播放。

参考网址：https://developer.mozilla.org/zh-CN/docs/Learn_web_development/Core/Structuring_content/HTML_video_and_audio

###### WebRTC

WebRTC 中的 RTC 代表实时通信（Real-Time Communications），这是一种可以在浏览器客户端（对等方）之间进行音频/视频流和数据共享的技术。

参考网址：https://developer.mozilla.org/zh-CN/docs/Web/API/WebRTC_API

### 媒体资源和许可

#### 许可类型

##### 版权所有

原创作品（例如歌曲、书籍或软件），其所有者通常以封闭的版权保护方式发布他们的作品。默认情况下，他们（或他们的出版商）拥有独家使用（例如展示或分发）其作品的权利。如果想使用带有版权所有许可的受版权保护的图像，需要执行以下操作之一：

- 从版权持有人获得明确的书面许可。
- 支付许可费用以使用它们。这可以是一次性费用，用于无限制使用（“免版税”），或者可能是“按照时间段、地理区域、行业或媒体类型等特定费用”的“权利管理”方式。
- 仅将使用限制在你所在司法辖区中被视为合理使用或合理交易的用途。

作者不必在其作品中包含版权声明或许可条款。一旦原创作品在有形媒介上创建出来，版权就会自动存在。因此，如果在网上找到一张图像，没有版权声明或许可条款，最安全的做法是假定它受到版权保护，所有权保留。

##### 自由许可

如果图像是根据自由许可发布的，例如 [MIT](https://mit-license.org/)、[BSD](https://opensource.org/license/BSD-3-clause) 或适当的[知识共享（CC）许可](https://chooser-beta.creativecommons.org/)，无需支付许可费用或寻求许可即可使用它。但是，仍需履行各种许可条件，这些条件因许可而异。

例如，可能需要：

- 提供指向图像原始来源的链接，并标明创作者。
- 指示是否对其进行了任何更改。
- 使用相同许可证分享使用该图像创建的任何派生作品。
- 不分享任何派生作品。
- 不将该图像用于任何商业作品。
- 在使用该图像的任何发布中包含许可证的副本。

应该查阅适用的许可证以了解需要遵循的具体条款。

Copyleft 许可（例如 [GNU 通用公共许可证（GPL）](https://www.gnu.org/licenses/gpl-3.0.en.html) 或“相同方式共享”创作共用许可证）规定派生作品需要按照原始许可证发布。Copyleft 许可在软件界中很常见。其基本思想是使用 copyleft 许可的代码构建的新项目（这被称为原始软件的“分支”）也需要根据相同的 copyleft 许可进行许可。这确保新项目的源代码也可供他人学习和修改。请注意，一般来说，为软件起草的许可证（例如 GPL）并不适合非软件作品，因为它们并不考虑非软件作品。

###### MIT

**原文：**

Copyright © 2025 <copyright holders>

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

**翻译：**

版权所有 © 2025 <版权所有者>

特此授予获得此软件和相关文档文件（“软件”）副本的任何人免费许可，以无限制方式处理软件，包括但不限于使用、复制、修改、合并、发布、分发、再授权和/或销售软件副本的权利，并允许向其提供软件的人员这样做，但须遵守以下条件：

上述版权声明和本许可声明均应包含在软件的所有副本或实质性部分中。

本软件按“原样”提供，不附带任何形式的明示或暗示保证，包括但不限于适销性、适用于特定用途和非侵权性的保证。在任何情况下，作者或版权所有者均不对因本软件或使用或以其他方式处理本软件而引起的或与之相关的任何索赔、损害或其他责任承担责任，无论是合同、侵权或其他诉讼。

###### BSD

**原文：**

Note: This license has also been called the “New BSD License” or “Modified BSD License”. See also the [2-clause BSD License](https://opensource.org/license/bsd-2-clause/).

Copyright <YEAR> <COPYRIGHT HOLDER>

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

**翻译：**

注意：此许可证也称为“新 BSD 许可证”或“修改版 BSD 许可证”。另请参阅[2 条款 BSD 许可证](https://opensource.org/license/bsd-2-clause/)。

版权所有 <年份> <版权所有者>

只要满足以下条件，就可以以源代码和二进制形式重新分发和使用（无论是否经过修改）：

1. 源代码的重新分发必须保留上述版权声明、本条件列表和以下免责声明。

2. 以二进制形式重新分发时，必须在分发时提供的文档和/或其他材料中复制上述版权声明、本条件列表和以下免责声明。

3. 未经事先书面许可，不得使用版权持有人的名称或其贡献者的名称来认可或推广源自该软件的产品。

本软件由版权所有者和贡献者“按原样”提供，不提供任何明示或暗示的保证，包括但不限于适销性和针对特定用途的适用性的暗示保证。在任何情况下，版权所有者或贡献者均不对任何直接、间接、偶然、特殊、惩戒性或后果性损害（包括但不限于采购替代货物或服务；使用、数据或利润损失；或业务中断）负责，无论该损害是如何造成的，也不论是基于何种责任理论，无论是合同、严格责任还是侵权（包括疏忽或其他），即使已被告知有此类损害的可能性，该损害也是因使用本软件而引起的。

###### 知识共享（CC）

参考网址：https://chooser-beta.creativecommons.org/

##### 公共领域/CC0

进入公共领域的作品有时被称为“无版权保留”——它们不受版权保护，可以在未经许可且无需履行任何许可条件的情况下使用。作品可以因为版权到期或特定放弃权利等方式进入公共领域。

将作品置于公共领域的最有效方法之一是将其许可为 [CC0](https://creativecommons.org/public-domain/cc0/)，这是一种特定的创作共用许可，为此目的提供了清晰明确的法律工具。

在使用公共领域图像时，请获取证明该图像属于公共领域的证据，并将该证据保存记录。例如，使用截图记录原始来源（该来源需要清晰显示许可状态），并考虑在你的网站上添加一个页面，列出所获得的图像及其许可要求。
