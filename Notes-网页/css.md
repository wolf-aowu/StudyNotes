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

![](图片\选择器优先级.jpg)

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
    text-align: center;  /* 文本对齐 */
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

### button 标签

`:hover`

``` css
button:hover {
    color: #000;
    background-color: #fff;
}
```

