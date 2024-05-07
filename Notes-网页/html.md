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

下面两个代码片段时等价的：

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

超链接除了可以链接到文档外，也可以链接到 HTML 文档的特定部分（被称为文档片段）。要做到这一点，必须首先给药链接到的元素分配一个 id 属性。通常情况下，链接到一个特定的标题是有意义的。为了链接到那个特定的 id，要将它放在 URL 的末尾，并在前面包含井号（`#`）。

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

##### title 属性

title 属性为链接补充信息，如页面包含什么样的信息或需要注意的事情。当鼠标指针悬停在链接上时，标题将作为提示信息出现。链接的标题仅当鼠标悬停在其上时才会显示，这意味着使用键盘来导航网页的人很难获取到标题信息。如果标题信息对于页面非常重要，应该使用所有用户能都方便获取的方式来呈现，例如放在常规文本中。
