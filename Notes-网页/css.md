# CSS

## 简介

Cascading Style Sheets（层叠样式表）

``` css
/* h1 代表 Selector（选择器） */
h1 {
    color: blue;
    text-align: center;
    font-size: 20px;  /* 这一整行是 Declaration（声明），也可以称为 Style */
}
/* font-size 是 Property（属性），20px 是 Value（值） */
/* 这一整块被称为 Declaration block */
```

## 基础知识

### User agent stylesheet

用户代理样式表，默认样式，例如：`h1` 元素就有默认样式。

## Html 中添加 CSS

有 3 种方式在 Html 种使用 CSS。

### inline css（内联 css）

与 html 元素写在一起。<font color=skyblue>不应该使用。</font>

``` html
<h1 style="color: blue">The Code Magazine</h1>
```

### internal css（内部 css）

写在 head 元素中。使用 style 元素包裹 css。<font color=skyblue>会使 html 文件行数增多，不建议使用。</font>

``` html
<head>
    <style>
        h1 {
            color: blue;
            text-align: center;
            font-size: 20px;
        }
    </style>
</head>
```

### external css（外部 css）

单独创建以 css 为后缀的文件，将声明块（Declaration block）写入文件。在 html 文件的 head 元素中添加链接。

``` html
<!-- rel 属性让浏览器知道有 CSS 文档的存在 -->
<head>
    <link href="css 文件路径" rel="stylesheet" />
</head>
```

## 选择器（Selector）

### 类型选择器（type selector）

类型选择器（type selector）有时也被称为标签名选择器（tag name selector）或元素选择器（element selector），因为它会匹配文档中的 HTML 标签/元素。

``` css
h1 {
	color: blue;
	text-align: center;
	font-size: 20px;
}
```

### 组合选择器（combining selector）

#### 列表选择器（list selector）

如果有多个使用相同样式的 CSS 选择器，它们可以被合并在一起。

合并前：

``` css
h1 {
    font-size: 26px;
    font-family: sans-serif;
    text-transform: uppercase;
    font-style: italic;
}

h2 {
    font-size: 40px;
    font-family: sans-serif;
}

h3 {
    font-size: 40px;
    font-family: sans-serif;
}

p {
    font-size: 22px;
    font-family: sans-serif;
    line-height: 1.5;
}
```

合并后：

``` css
h1, h2, h3, p {
    font-family: sans-serif;
}

h1 {
    font-size: 26px;
    text-transform: uppercase;
    font-style: italic;
}

h2 {
    font-size: 40px;
}

h3 {
    font-size: 40px;
}

p {
    font-size: 22px;
    line-height: 1.5;
}
```

#### 后代选择器（descendant selector）

``` css
/* 选择所有在 footer 中的 p 元素 */
footer p {
    font-size: 16px;
}

article header p {
    font-style: italic;
}
```

### ID 选择器（ID selector）

ID 选择器（ID selector）是 CSS 中一种区分大小写的选择器，以井号（`#`）开头，用于匹配文档中所有应用了指定 id 属性的元素。

<font color=skyblue>每个 id 在同一个文档中只能使用一次，不可以重复。</font>

当由多个单词组成一个 id 名时，通常使用 `-` 分割单词。

例如，有 html：

``` html
<body>
    <p id="hello">你好，世界</p>
    <p>再见，世界</p>
    <p id="bye">拜拜咯</p>
</body>
```

css：

``` css
#hello {
    color: orangered;
}

#bye {
    color: blue;
}
```

### 类选择器（class selector）

类选择器（class selector）是 CSS 中一种区分大小写的选择器，以点号（.）开头，用于匹配文档中所有应用了指定 class 属性的元素。

当由多个单词组成一个 class 名时，通常使用 `-` 分割单词。

可以同时应用多个类选择器，以空格分割，例如： `<p class="say hello">hello world!</p>`。

<font color=skyblue>通常使用 类选择器 而不是 ID选择器。</font>

例如，有 html：

``` html
<body>
    <p class="say">你好，世界</p>
    <p>再见，世界</p>
    <p class="say">拜拜咯</p>
</body>
```

css：

``` css
.say {
    font-size: 18px;
    font-weight: bold;
}
```

### 伪类（pseudo-classes）

伪类是添加到选择器的关键词，用于指定所选元素的特殊状态。

``` css
/* 指定列表的第一个 li 标签应用样式 */
li:first-child {
    font-weight: bold;
}

/* 等同与为每一个列表的第一个 li 添加属性 class="first-li" */
.first-li {
    font-weight: bold;
}

/* 指定列表的最后一个 li 标签应用样式 */
/* :last-child 代表一组兄弟元素的最后一个元素 */
li:last-child {
    font-style: italic;
}

/* 指定列表的第 n 个 li 标签应用的样式，这里是第 2 个 */
/* 2 也可以替换成 odd（奇数），even（偶数） */
li:nth-child(2) {
    color: red;
}
```

**当与后代选择器结合使用时**

html：

``` html
<header>
  <h1>Hello World!</h1>
  <p>Hello CSS!</p>
</header>
```

css：

``` css
/* 会选择 header 的子元素中为第一个元素的 p 元素，所以上面的 html 字体颜色是不会生效的 */
header p:first-child {
    color: red;
}
```

例如下面的 html 中，p 元素会根据 CSS 改变字体颜色：

``` html
<header>
  <article>
  	<p>Hello CSS!</p>
  </article>
</header>
```

### 伪元素（pseudo element）

伪元素本质上是 Html 中不存在的元素，但我们仍然可以在 CSS 中选择和设置样式。

伪元素是一个附加至选择器末的关键词，允许你对被选择元素的特定部分修改样式。

与伪元素比较，伪类能够根据状态改变元素样式。

``` css
h1::first-letter {
    font-style: normal;
    margin-right: 5px;
}
```

### 接续兄弟组合器（Next-sibling combinator）

接续兄弟选择器（`+`）介于两个选择器之间，当第二个元素紧跟在第一个元素之后，并且两个元素都是属于同一个父元素的子元素，则第二个元素将被选中。

``` css
/* 选中 h3 之后的 p 的第一行的样式 */
h3 + p::first-line {
    color: red;
}
```

### 通配选择器（universal selector）

在 CSS 中，一个星号 (`*`) 就是一个通配选择器。它可以匹配任意类型的 HTML 元素。在配合其他简单选择器的时候，省略掉通配选择器会有同样的效果。比如，`*.warning` 和`.warning` 的效果完全相同。

在 CSS3 中，星号 (`*`) 可以和命名空间组合使用：

- `ns|*` - 会匹配`ns`命名空间下的所有元素
- `*|*` - 会匹配所有命名空间下的所有元素
- `|*` - 会匹配所有没有命名空间的元素

``` css
* {
    margin: 0;
    padding: 0;
}
```

### !important

当在一个样式声明中使用一个 `!important` 规则时，此声明将覆盖任何其他声明。虽然，从技术上讲，`!important` 与优先级无关，但它与最终的结果直接相关。使用 `!important` 是一个**坏习惯**，应该尽量避免，因为这破坏了样式表中的固有的级联规则 使得调试找 bug 变得更加困难了。当两条相互冲突的带有 `!important` 规则的声明被应用到相同的元素上时，拥有更大优先级的声明将会被采用。

**一些经验法则：**

- **一定**要优先考虑使用样式规则的优先级来解决问题而不是 `!important`
- **不要**使用 `!important` 来覆盖外部 `CSS`，而是将第三方脚本直接导入到[级联层（cascade layers）](https://developer.mozilla.org/en-US/docs/Web/CSS/@layer)中。
- **永远不要**在你的插件中使用 `!important`
- **永远不要**在全站范围的 CSS 代码中使用 `!important`

如果必须使用 `!important` 请为其添加上注释！

``` css
footer p{
    color: green !important;
}
```

#### 避免使用 !important 的方法

1. 更好地利用 CSS 级联属性
2. 使用更具体的规则。在你选择的元素之前，增加一个或多个其他元素，使选择器变得更加具体，并获得更高的优先级。

#### 什么时候使用 !important

存在很差的内联样式又需要将其覆盖时，可以使用 `!important` 覆盖。

### 选择器优先级

从高到低的优先级，当同时存在多个同类的选择器且属性存在冲突时，会生效最后一个：

- 被 `!important` 标记的选择器
- 内联样式（在 HTML 中 的样式）
- ID 选择器
- 类选择器和伪类选择器
- 元素选择器
- 通用选择器（Universal selector *）

选择器优先级参考图

![](图片\css\选择器优先级.jpg)

## 继承（inheritance 或 inherity）

当元素的一个继承属性（inherited property）没有被指定时，会自动继承它的父元素的同属性样式。一般都是文本属性能够被继承。

常见具有继承属性的属性：

`font-family`、`font-size`、`font-weight`、`font-style`、`color`、`line-height`、`letter-spacing`、`text-align`、`text-transform`、`text-shadow`、`list-style` 等。

``` css
body {
    color: red;
    font-size: 16px;
    font-family: sans-serif;
}
```

## 定位

### 常规流（Normal Flow）

常规流中的任何一个盒子总是某个*格式区域*（*formatting context*）中的一部分。块级盒子是在*块格式区域*（*block formatting context*）中工作的盒子，而内联盒子是在*内联格式区域*（*inline formatting context*）中工作的盒子。任何一个盒子总是块级盒子或内联盒子中的一种。

规范中还规定了块格式区域与内联格式区域中的元素行为。对于块级格式环境，规范内规定：

在一个块格式区域中，盒子会从包含块的顶部开始，按序垂直排列。同级盒子间的垂直距离会由 `margin` 属性决定。相邻两个块级盒子之间的垂直间距会遵循外边距折叠原则被折叠（边缘收缩）。

在一个块格式区域中，每个盒子的左外边缘会与包含块左边缘重合（如果是从右到左的排版顺序，则盒子的右外边缘与包含块右边缘重合）。

对于内联格式区域中的元素：

在内联格式区域中，盒子会从包含块的顶部开始，按序水平排列。只有水平外边距、边框和内边距会被保留。这些盒子可以以不同的方式在垂直方向上对齐：可以底部对齐或顶部对其，或者按文字底部进行对齐。我们把包含一串盒子的矩形区域称为一个线条框。

需要注意的是，CSS 2.1 规范将文档的书写模式定义为从上到下横板排布，这从块级盒子的垂直间距这一属性就能看出来。在竖版书写模式工作时，块元素和内联元素的行为是相同的，关于这个我们将在未来的流布局与书写模式指南中进行探讨。

常规流只是元素在页面上的默认定位，或者也可以通过 `position: relative` 实现常规流。称元素为 "in flow"。这意味着元素依赖在 HTML 代码中它们的顺序。

<font color=grass>未完。</font>

参考网址：

https://developer.mozilla.org/zh-CN/docs/Web/CSS/CSS_display/Block_and_inline_layout_in_normal_flow

https://www.w3.org/TR/CSS2/visuren.html#normal-flow

#### 边缘收缩

当一块空间同时具有 `margin-top` 和 `margin-bottom` 的属性值时，会发生边缘收缩（collapsing margin），通常应用属性值大的那一个。

参考网址：

https://developer.mozilla.org/zh-CN/docs/Web/CSS/CSS_box_model/Mastering_margin_collapsing

### 绝对定位（Absolute Position）

元素会被从常规流中删除，称为 "out of flow"。元素将完全失去对周围元素的任何影响，甚至可能会重叠。通过 `top`、`bottom`、`left` 和 `right` 来偏移元素相对于一个 `position` 为 `relative` 的容器的位置。

如果没有为父容器设置 `position: relative`，则 `top`、`bottom`、`left`、`right` 会按视口来设置，例如 `bottom: 0;` 不会展示在页面所有内容的最底部，如果页面内容足够长出现了滚动条，则元素会被展示在页面内容的中部。

正确的绝对定位设置方式，粗体部分：

![](图片\css\绝对定位.png)

## 布局

布局主要分为两大类：页面布局和组件布局。

页面布局将页面分为多个大块，组件布局再将每个页面布局分为多个内容。

### 浮动布局（float Layout）

`float` CSS 属性指定一个元素应沿其容器的左侧或右侧放置，允许文本和内联元素环绕它。该元素从网页的正常流动（文档流）中移除，但是仍然保持部分的流动性（与绝对定位）相反）。

``` css
p {
    float: right;
}
```

如果父容器中没有其他元素撑起高度时，父容器的高度会消失。解决方案如下：

**方案一：**

在父容器中再创建一个空元素，如 `div`，使用 `clear` 属性清除 `float` 布局。(不推荐)

``` css
div {
    /* 
    	left: 清除左浮动
    	right: 清除右浮动
    	both: 同时存在左浮动和有浮动，两个同时清除
    */
    clear: both;
}
```

**方案二：**

在父容器中添加 `clearfix` 类，选择 `clearfix` 类选择器添加伪类。这种方法也被称为 `clearfix hack`。

``` css
.clearfix::after {
    clear: both;
    content: "";
    display: block;
}
```

如果同时存在 `float: left` 和 `float: right` 它们中间是没有缝隙的，此时需要缩小左右两边盒子的宽。

如果右两个 `float: left` 和 `float: left` 那么空隙会出现在最右侧。

### 弹性盒子布局（flexbox）

适合组件布局，是一维布局。它给 flexbox 的子元素之间提供了强大的空间分布和对齐能力。flexbox 在最初开发时的目的是为了能够自动划分父容器的空白空间。

flexbox 的定义：

![](图片\css\flexbox 的定义.png)

我们说 flexbox 是一种一维的布局，是因为一个 flexbox 一次只能处理一个维度上的元素布局，一行或者一列。

html：

``` html
<body>
    <div class="container">
        <!-- 这些被称为 flex item -->
        <div class="el el--1">HTML</div>
        <div class="el el--2">and</div>
        <div class="el el--3">CSS</div>
        <div class="el el--4">are</div>
        <div class="el el--5">amazing</div>
        <div class="el el--6">languages</div>
        <div class="el el--7">to</div>
        <div class="el el--8">learn</div>
    </div>
</body>
```

css：

``` css
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

.container {
    font-family: sans-serif;
    background-color: #ddd;
    font-size: 34px;
    margin: 40px;
    display: flex;
    /* 
    	stretch: 自动拉伸（以最高的高度来），是默认值
    	center: 垂直居中（除了设置了高度的绿色，其他元素的 height 都会采用内容的高度）
    	flex-start: 上对齐
    	flex-end: 下对齐
    */
    align-items: center;
    /*
    	center: 水平居中
    	space-between: 水平剩余空间均分作为空隙
    */
    justify-content: center;
}

.el--1 {
    align-self: flex-start;
}

.el--2 {
    background-color: blueviolet;
    align-self: stretch;
}

.el--3 {
    background-color: orangered;
}

.el--4 {
    background-color: green;
    height: 150px;
}

.el--5 {
    background-color: goldenrod;
}

.el--6 {
    background-color: palevioletred;
}

.el--7 {
    background-color: steelblue;
}

.el--8 {
    background-color: crimson;
}
```

默认情况下，`flex item` 都和最高的元素一样高。如行main例子所有元素的 `height` 都是 150px。

### css 网格布局（css grid）

适合大页面布局，是二维布局。将一个容器元素分成行和列，由它的子元素来填充这些行和列。

css 网格布局可以和弹性盒子布局（flexbox）很好地协同工作。不应该使用 css 网格布局替代弹性盒子布局（flexbox）！

css grid 的定义：

![](图片\css\css grid 的定义.png)

css grid 的 row axis 和 column axis 是不可以改变方向的。

![](图片\css\css grid 的定义2.png)

html：

``` html
<body>
    <div class="container--1">
        <div class="el el--1">(1) HTML</div>
        <div class="el el--2">(2) and</div>
        <div class="el el--3">(3) CSS</div>
        <div class="el el--4">(4) are</div>
        <div class="el el--5">(5) amazing</div>
        <div class="el el--6">(6) languages</div>
        <div class="el el--7">(7) to</div>
        <div class="el el--8">(8) learn</div>
    </div>
    
    <div class="container--2">
        <div class="el el--1">(1)</div>
        <div class="el el--3">(3)</div>
        <div class="el el--4">(4)</div>
        <div class="el el--5">(5)</div>
        <div class="el el--6">(6)</div>
        <div class="el el--7">(7)</div>
    </div>
</body>
```

css：

``` css
.el--1 {
    background-color: blueviolet;
}
.el--2 {
    background-color: orangered;
}
.el--3 {
    background-color: green;
    height: 150px;
}
.el--4 {
    background-color: goldenrod;
}
.el--5 {
    background-color: palevioletred;
}
.el--6 {
    background-color: steelblue;
}
.el--7 {
    background-color: yellow;
}
.el--8 {
    background-color: crimson;
}

.container--1 {
    /* STARTER */
    font-family: sans-serif;
    background-color: #ddd;
    font-size: 30px;
    margin: 40px;
    
    /* CSS GRID */
    display: grid;
    /* 定义每一列的宽度，会自动创建对应宽度的一列 */
    grid-template-columns: 200px 200px 100px 100px;
    /* 行同列理 */
    grid-template-rows: 300px 200px;
    /* 同时设置行和列的间隙（但不可以单独设置） */
    /* gap: 30px; */
    /* 单独设置列的间隙 */
    column-gap: 30px;
    /* 单独设置行的间隙 */
    row-gap: 60px;
}

.container--2 {
    font-family: sans-serif;
    background-color: black;
    font-size: 40px;
    margin: 100px;
    
    width: 1000px;
    height: 600px;
    
    /* CSS GRID */
    display: grid;
    grid-template-columns: 125px 200px 125px;
    grid-template-rows: 250px 100px;
}
```

在网格布局中可以使用一种新单位 `fr`。使用像素为单位时，网格大小时固定的当缩小浏览器窗口时，像素宽度不变，使得子元素会超过父元素的宽度，这看起来会很奇怪，`fr` 就不会有这方面的问题。`fr` 可以自动分配剩余空间，直到父容器大小不足以容纳正常显示的所有子元素时，子元素才会超出父容器。

``` css
grid-template-columns: 200px 200px 1fr 1fr;
```

可能会出现隐形的行，例如一共有12个子元素，最初设置的列数有 4 列，行数只有 3 行设置了高度，此时删去了一列列宽，那么它就变成有 4 行了，但第 4 行没有为它设置行高，此时会自动添加多出来的行，但是它们的行高一般按内容来设置。

## 属性

### 文本属性

``` css
h1 {
    color: blue;  /* 字体颜色 */
    font-size: 26px;  /* 字体大小 */
    font-weight: bold; /* 字体粗细 */
    font-family: sans-serif;  /* 字体。sans-serif 代表无衬线字体类型的字体集 */
    text-transform: uppercase;  /* 文本转换。uppercase 会将文本全部转换成大写字母 */
    font-style: italic;  /* 字体样式 */
    text-align: center;  /* 文本对齐，仅对块级元素生效 */
}

p {
    line-height: 1.5;  /* 行高。单位是字体大小。 */
}
```

### 列表属性

``` css
ul {
    list-style: none;  /* 列表左侧点状样式，square 方块 */
}
```

### background-color

``` css
header, aside, body {
    background-color: #f7f7f7;
}
```

### border

有 3 个值，分别是：边框粗细、边框样式、边框颜色。这种属性被称为简写属性（shortand property），是将多个属性合并为单一属性的高效写法。

``` css
aside {
    /* 
    	solid 实线
    	dotted 点状虚线
    	dashed 破折状虚线
    */
    border: 5px solid #1098ad;
    /* 代表只设置一边 */
    border-top: 5px solid #1098ad;
    border-bottom: 5px solid #1098ad;
    border-left: 5px solid #1098ad;
    border-right: 5px solid #1098ad;
}
```

### a

``` css
a:link {
    color: #1098ad;
    text-decoration: none;  /* 去除下划线 */
    /*
    	也可以是这样：
    	橙色点状下划线
    	text-decoration: underline dotted orangered;
        text-decoration: underline orangered;
    	等同于
    	text-decoration: underline solid orangered;
        wavy 波浪线
    */
}
```

### 按钮属性

``` css
button {
    background-color: black;  /* 背景色 */
    border: none;  /* 边框 */
    color: #fff;  /* 按钮内容颜色 */
    font-size: 20px;  /* 按钮内容字体大小 */
    text-transform: uppercase;  /* 按钮内容文本转换 */
    cursor: pointer;  /* 悬停时鼠标指针样式，pointer 一般会变成手指样式 */
}
```

### 块级元素属性

![](图片\css\css box 模型介绍.png)

final element width = left border + left padding + width + right padding + right border

final element height = top border + top padding + height + bottom padding + bottom border

综上所述，margin 不是元素内的空间，padding 是元素内的空间。

在 Google 浏览器的检查面板中（默认），当鼠标悬浮在某行元素上时，`padding` 是绿色的，`margin` 是橙色。

#### padding

``` css
.main-header {
    padding: 20px;  /* 将四边的 padding 都设置为 20px */
    padding: 20px 30px; /* 20px 代表 top 和 bottom，30px 代表 left 和 right，一般水平是垂直方向上的两倍 */
    /* 单边 */
    padding-left: 40px;
    padding-right: 40px;
    padding-top: 40px;
    padding-bottom: 40px;
}
```

#### margin

`margin` 通常被用来调整元素之间的间距。`margin` 写法与 `padding` 相同。`margin` 不是与文本相关的属性，所以它不可以被继承。尽量不要 `margin-top` 和 `margin-bottom` 混合使用，而是选择任意一个一直使用。

``` css
li {
    margin-bottom: 10px;
}

/* 去除最后一个 li 的下 margin，通常 0 不带单位 */
li:last-child {
    margin-bottom: 0;
}
```

通常会使用通用选择器将各元素自带的空间去掉。

``` css
* {
    margin: 0;
    padding: 0;
}
```

#### box-sizing

`box-sizing` 的默认值为 `content-box`，元素的 `width` 和 `height` 的计算方法如下所示：

element width = right border + right padding + width + left padding + left border

element height = top border + top padding + height + bottom padding + bottom border

![](图片\css\元素默认 width 和 height 计算方法.png)

当 `box-sizing` 设置为 `border-box` 时，元素的 `width` 和 `height` 的计算方式变为：

element width = width

element height = height

![](图片\css\元素设置为 border-box 的计算方法.png)

通常使用通用选择器配置。

``` css
* {
    box-sizing: border-box;
}
```

因为这个属性不是可继承的属性。

#### 内容居中

内容需要放在容器中，否则内容不会根据浏览器的变化自动居中，而是根据浏览器的变化一起变化。

子元素永远不能比父元素宽。

``` css
div {
    width: 700px;  /* 内部所有元素的宽度都会小于等于 700 px */
    /* 左右两边外边距自动计算成相等 */
    margin-left: auto;
    margin-right: auto;
    /* 与上面等价 */
    margin: 0 auto;
}
```

可以使用 `text-align` 居中块级元素的内容，但这不会对内联元素生效，因为内联元素本身会尽可能地占用位置。

#### 块级内联互相转换

<font color=skyblue>块级元素的 `height` 和 `width` 对于内联元素是没有用的。同时 `padding` 和 `margin` 也仅在水平方向应用（准确点是不会在垂直方向上创造出新的空间，padding 会拓宽盒子的大小但是内容在垂直方向的位置是不变的，如果它和块级元素同样是用 padding，块级元素内容会往下移动一点）。</font>

##### 内联转块级

``` css
nav a:link {
    margin: 20px; /* 可以发现垂直方向上的外边距没有增加 */
    padding: 20px;
    display: block;
}
```

##### 块级转内联

这样块级元素就可以并排了。

``` css
li {
    display: inline;
}
```

##### 内联块

继承了内联元素只会占用内容本身的大小的优点，同时也拥有块级元素的 `padding` 和 `margin`。

``` css
nav a:link {
    display: inline-block;
}
```

### img

当 html 中为图片设置了 `width` 和 `height` 时，

``` html
<img src="皮卡丘.png" alt="皮卡丘" height="50" width="50" class="pkq"/>
```

``` css
.pkq {
    width: 100px;
    height: auto;  /* 自动根据 width 按 html 中设置的 width 等比例缩放 height */
}
```

如果没有在 html 中为图片指定宽度和高度，在 css 中使用 width 和 height 则会根据图片的原始纵横比来自适应。

`width` 和 `height` 还可以以百分比为单位，它将以父容器的 `width` 和 `height` 为基数来计算最终大小。

### flexbox

#### flex container 中

##### gap

默认值为 0。为两个 flex items 的中间创建空白，不使用 margin。它比 `margin` 少了一个间隔，例如 `margin-right` 最后一个元素的后面还会有一个间隔，而 `gap` 没有。

##### justify-content

默认值为 flex-start。沿主轴（默认为水平方向）对齐 flex items。

可选值：

- flex-start：元素紧密地排列在弹性容器的主轴起始侧。仅应用于弹性布局的项目。对于不是弹性容器里的元素，此值将被视为 `start`。
- flex-end：元素紧密地排列在弹性容器的主轴结束侧。仅应用于弹性布局的元素。对于不是弹性容器里的元素，此值将被视为 `end`。
- center：伸缩元素向每行中点排列。每行第一个元素到行首的距离将与每行最后一个元素到行尾的距离相同。
- space-between：在每行上均匀分配弹性元素。相邻元素间距离相同。每行第一个元素与行首对齐，每行最后一个元素与行尾对齐。
- space-around：在每行上均匀分配弹性元素。相邻元素间距离相同。每行第一个元素到行首的距离和每行最后一个元素到行尾的距离将会是相邻元素之间距离的一半。
- space-evenly：flex items 都沿着主轴均匀分布在指定的对齐容器中。相邻 flex 项之间的间距，主轴起始位置到第一个 flex 项的间距，主轴结束位置到最后一个 flex items 的间距，都完全一样。

##### align-items

默认值为 stretch。沿交叉轴（默认为垂直方向）对齐 flex items。

可选值：

- stretch：如果（多个）元素的组合大小小于容器的大小，其中自动调整大小的元素将等量增大，以填满容器，同时这些元素仍然保持其宽高比例的约束。
- flex-start：将元素与容器的主轴起点或交叉轴起点对齐，轴起点的方向对应于元素的起始方向。
- flex-end：将元素与容器的主轴末端或交叉轴末端对齐，轴末端的方向对应于元素的结尾方向。
- center：flex 元素的外边距框在交叉轴上居中对齐。如果元素的交叉轴尺寸大于 flex 容器，它将在两个方向上等距溢出。
- baseline：所有 flex 元素都对齐，以使它们的 flex 容器基线对齐。距离其交叉轴起点和基线之间最远的元素与行的交叉轴起点对齐。

##### flex-direction

默认值为 row。定义主轴的方向。

可选值：

- row：flex 容器的主轴被定义为与文本方向相同。主轴起点和主轴终点与内容方向相同。
- row-reverse：表现和 row 相同，但是置换了主轴起点和主轴终点。
- column：flex 容器的主轴和块轴相同。主轴起点与主轴终点和书写模式的前后点相同。
- column-reverse：表现和 column 相同，但是置换了主轴起点和主轴终点。

##### flex-wrap

默认值为 nowrap。指定 flex 元素单行显示还是多行显示。

- nowrap：flex 的元素被摆放到到一行，这可能导致 flex 容器溢出。cross-start 会根据 flex-direction 的值等价于 start 或 before。

- wrap：flex 元素 被打断到多个行中。cross-start 会根据 flex-direction 的值等价于 start 或 before。cross-end 为确定的 cross-start 的另一端。
- wrap-reverse：和 wrap 的行为一样，但是 cross-start 和 cross-end 互换。

##### align-content

默认值为 stretch。只在有多行时生效。

- flex-start：所有行从容器的起始边缘开始填充。
- flex-end：所有行从容器的结束边缘开始填充。
- center：所有行朝向容器的中心填充。每行互相紧挨，相对于容器居中对齐。容器的垂直轴起点边和第一行的距离相等于容器的垂直轴终点边和最后一行的距离。
- space-between：所有行在容器中平均分布。相邻两行间距相等。容器的垂直轴起点边和终点边分别与第一行和最后一行的边对齐。
- space-around：所有行在容器中平均分布，相邻两行间距相等。容器的垂直轴起点边和终点边分别与第一行和最后一行的距离是相邻两行间距的一半。

#### flex items 中

##### align-self

默认值为 auto。为单个 flex items 覆盖 align-items 属性。

可选值：auto、stretch、flex-start、flex-end、center、baseline。

##### flex-grow

默认值为 0。使元素放大。如果为 1，当容器未被填满时，允许尽可能的放大元素。如果设置为2，意味着设置的元素将会得到比其他元素多一倍的平均剩余空间。当单独放大某个 `item` 时它会独自占据所有剩余空白空间。

##### flex-strink

默认值为 1。使元素缩小。当元素会超出容器大小时允许自动收缩元素以适应容器大小。如果为 0，则不会收缩元素。

##### flex-basis

默认值为 auto。不使用 width 属性来定义一个 flex items 的宽度。在为 flex items 设置 `flex-basis` 属性时需要将 `flex-strink` 设置为 0 才会生效。当父容器不够容纳 items 且 `flex-strink` 部位 0 时会自动收缩元素以适应容器大小，所以此时设置的 `flex-basis` 不会生效。

##### flex

默认值为 0 1 auto。flex-grow flex-strink flex-basis 的简写。

##### order

默认值为 0。控制 flex items 的顺序。-1 为第一，1 为最后一个。

### css grid

#### grid container 中

##### grid-template-rows

定义网格线的名称和网格轨道的尺寸大小。

``` css
/* 3行 */
grid-template-rows: 40px 4px 40px;
```

单位可以是 px 或 fr 等。在使用 fr 时，需要为父容器设置高度，否则会根据子元素的最大高度设置行高。也可以使用 auto 来自动获取行高。

##### grid-template-columns

定义网格线的名称和网格轨道的尺寸大小。

``` css
/* 2列 */
grid-template-columns: 60px 60px;
```

单位可以是 px 或 fr 等。也可以使用 auto 来自动获取列宽。

当有多列连续相等的列宽是，可以使用 `repeat(列数, 列宽)` 来快速设置，例如 `repeat(4, 1fr)`。

##### row-gap

设置行元素之间的间隙（gutter）大小。

规范的早期版本将此属性命名为 `grid-row-gap`，为了保持与旧网站的兼容性，浏览器仍然会将 `grid-row-gap` 视为 `row-gap` 的别名。

``` css
row-gap: 20px;
```

##### column-gap

设置列元素之间的间隙（gutter）大小。

规范的早期版本将此属性命名为 `grid-column-gap`，为了保持与旧网站的兼容性，浏览器仍然会将 `grid-column-gap` 视为 `column-gap` 的别名。

``` css
column-gap: 20px;
```

##### gap

同时设置行和列的间隙大小。

``` css
gap: 30px;
```

##### justify-items

默认值为 stretch。所有子元素在网格的水平方向上对齐。可以把这个认为是控制子元素在网格中的布局。

可选值：

stretch（拉伸）、start、center、end。

##### align-items

默认值为 stretch。所有子元素在网格的垂直方向上对齐上。可以把这个认为是控制子元素在网格中的布局。

可选值：

stretch（拉伸）、start、center、end。

##### justify-content

默认值为 start。每一行网格轨道在父容器中沿水平方向对齐。可以把这个认为是控制网格的布局。

可选值：

start、center、end、stretch、space-between（在每行上均匀分配弹性元素。相邻元素间距离相同。每行第一个元素与行首对齐，每行最后一个元素与行尾对齐。）。

##### align-content

默认值为 start。每一列网格轨道在父容器中沿垂直方向对齐。可以把这个认为是控制网格的布局。

可选值：

start、center、end、stretch、space-between。

#### grid items 中

##### grid-column

`grid-column` CSS 属性是 [`grid-column-start`](https://developer.mozilla.org/en-US/docs/Web/CSS/grid-column-start) 和 [`grid-column-end`](https://developer.mozilla.org/en-US/docs/Web/CSS/grid-column-end) 的简写属性。

将网格放置到特定单元格时，可通过行号定位。span 关键字可用于使项目跨越多列单元格。

start line / end line | span number

``` css
/* 将单元格移至第 2 列，2 和 3 代表第 2 列的起始网格线和结束网格线。如果没有指定行则会在该列的最后一行加一行来显示这个格子。 */
.el--8 {
    grid-column: 2 / 3;
}
```

如果要移动到的位置已经存在单元格，则存在的单元格顺序向后移动。

当 end line - start line = 1 时，可以省略 end line，`grid-column: 2;`。

如果 `grid-column: 1 / 3;` 时，则该单元格会跨列显示。

也可以写成 `grid-column: 1 / span 2;`，`span 2` 代表需要跨 2 个网格线，也就是单元格跨 2 列。

当不知道父容器被分成几列，但希望跨一整行时，可以写成 `grid-column: 1 / -1;`。也就是网格线既可以正着数也可以倒着数。

##### grid-row

**`grid-row`** 属性是一种 [`grid-row-start`](https://developer.mozilla.org/en-US/docs/Web/CSS/grid-row-start) 和 [`grid-row-end`](https://developer.mozilla.org/en-US/docs/Web/CSS/grid-row-end) 的缩写（shorthand）形式，它定义了网格单元与网格行（row）相关的尺寸和位置，可以通过在网格布局中的基线（line）、跨度（span），或者什么也不做（自动），从而指定网格区域)的行起始与行结束。

start line / end line | span number

``` css
.el--8 {
    grid-row: 1 / 2;
}
```

##### justify-self

默认值为 stretch。单独设置某一个子元素在网格中水平方向上的布局。

可选值：

stretch（拉伸）、start、center、end。

##### align-self

默认值为 stretch。单独设置某一个子元素在网格中垂直方向上的布局。

可选值：

stretch（拉伸）、start、center、end。

## 伪类（pseudo class）

### a 标签

#### `:link`

匹配每个具有 `href` 属性的未访问的 `a` 或 `area` 元素。

遵循 LVHA 顺序：`:link` — `:visited` — `:hover` — `:active`。

``` css
a:link {
    color: #1098ad;
}
```

#### `:visited`

在用户访问链接后生效，出于隐私保护的原因，使用该选择器可以修改的样式非常有限。`:visited` 伪类仅适用于带有 `href` 属性的 `a` 和 `area` 元素。

遵循 LVHA 顺序：`:link` — `:visited` — `:hover` — `:active`。

``` css
a:visited {
    color: #1098ad;
}
```

#### `:hover`

在用户使用指针设备与元素进行交互时匹配，但不一定激活它。通常情况下，用户将光标（鼠标指针）悬停在元素上时触发。

遵循 LVHA 顺序：`:link` — `:visited` — `:hover` — `:active`。

在触摸屏上，`:hover` 伪类可能存在问题。根据不同的浏览器，`:hover` 伪类可能永远不会匹配，只会在触摸一个元素后短暂匹配，或者即使用户停止触摸并且直到用户触摸另一个元素之前仍然匹配。Web 开发人员应确保内容可以在具有有限或不存在悬停功能的设备上访问。

``` css
a:hover {
    color: orangered;
    font-weight: bold;
    text-decoration: underline dotted orangered;
}
```

#### `:active`

匹配被用户激活的元素。它让页面能在浏览器监测到激活时给出反馈。当用鼠标交互时，它代表的是用户按下按键和松开按键之间的时间。

一般被用在 `a` 和 `button` 元素中。这个伪类的一些其他适用对象包括包含激活元素的元素，以及可以通过他们关联的 `label` 标签被激活的表格元素。

这个样式可能会被后声明的其他链接相关的伪类覆盖，这些伪类包括 `:link`，`:hover` 和 `:visited`。为保证样式生效，需要把 `:active` 的样式放在所有链接相关的样式之后。这种链接伪类先后顺序被称为 LVHA 顺序：`:link` — `:visited` — `:hover` — `:active`。

在有多键鼠标的系统中，CSS 3 规定 `:active` 伪类必须只匹配主按键；对于右手操作鼠标来说，就是左键。

``` css
a:active {
    background-color: black;
    font-style: italic;
}
```

#### `:last-child`

可以多个伪类叠加，下面例子就可以用于导航

``` css
nav a:link:last-child {
    margin-right: 0;
}
```

### button 标签

#### `:hover`

``` css
button:hover {
    color: #000;
    background-color: #fff;
}
```

## 伪元素（pseudo element）

### 文本元素

#### `::first_letter`

选择元素的一个字。

``` css
h1::first-letter {
    font-style: normal;
    margin-right: 5px;
}
```

#### `::first-line`

选择元素的第一行。

``` css
p::first-line {
    color: red;
}
```

#### `::after`

会创建一个伪元素，作为所选元素的最后一个子元素。它通常用于为具有 content 属性的元素添加修饰内容。它的 content 属性是必须的，如果不希望有内容就使用空字符串 `""`。默认情况下，它是内联布局的。

``` css
h2 {
    background-color: orange;
    position: relative;
}
h2::after {
    content: "TOP";
    background-color: #ffe70c;
    color: #444;
    font-size: 16px;
    font-weight: bold;
    display: inline-block;
    padding: 5px 10px;
    position: absolute;
    top: -10px;
    /* 值可以为负，向反方向移动 */
    right: -25px;
}
```

#### ::before

会创建一个伪元素，作为所选元素的第一个子元素。它的用法同 `::after`。如果将 `::after` 替换为 `::before` 在外观上并不会有不同，但是在浏览器的 `dev` 工具的 html中，`::before` 会在元素前面，`::after` 则会出现在元素后面。

