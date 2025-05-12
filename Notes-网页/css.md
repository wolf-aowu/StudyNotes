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

