# JavaScript 基础

## Html 文件中添加 JavaScript 代码

在 Html 文件的 style 标签下方添加 script 标签及代码

```html
<!DOCTYPE html>
<html lang="en">

<head>
  <!-- 此处省略 -->
  ...
  <style>
    /* 此处省略 */
    ...
  </style>
  <script>alert("Hello World!")</script>
</head>

<body>
  <h1>JavaScript Fundamentals – Part 1</h1>
</body>

</html>
```

## Html 文件中引用 JavaScript 文件

在 Html 文件的 body 标签中添加 script 标签

Html 文件支持引用多个 JavaScript 文件

``` html
<!DOCTYPE html>
<html lang="en">

<head>
  <!-- 此处省略 -->
  ...
</head>

<body>
  <h1>JavaScript Fundamentals – Part 1</h1>
  <script src="script.js"></script>
</body>

</html>
```

## 变量

变量的命名规则为驼峰命名法。

句末的 `;` 可写可不写。

不可以数字开头，但可以以 `_`、`$` 开头，特殊符号也仅支持这两个。一部分关键字不可以作为变量名，如：`function`、`new`；但也有一部分关键字可以使用，但不推荐使用，如：`name`。

使用 `let` 申明变量，但在再次调用变量时不需要再次申明。

<font color=skyblue>在定义变量时不需要指定值的类型，因为 JavaScript 中的变量仅是用来存储值的，值的类型是自动定义的。Value has type, Not variable!</font>

``` javascript
let javascriptIsFun = true;
javascriptIsFun = "YES!"
```

## 常量

常量的命名规则为全部字母大写。

``` javascript
let PI = 3.1415926;
```

## 数据类型

有七种原始类型（primitive data type）：Number、String、Boolean、Undefined、Null、Symbol、BigInt。

Number：浮点数，所有数字都是 Number 类型。`let age = 23;`

String：字符序列，双引号、单引号都支持。`let firstName = "Jonas";`

Boolean：逻辑类型，只能是 `true` 或 `false`。`let fullAge = true;`

Undefined：当变量的值还未定义时（空值）。 `let children; `

```javascript
let children;
console.log(children)  //undefined
console.log(typeof children)  //undefined
```

Null：空值。

``` javascript
console.log(typeof null)  //object
```

Symbol：ES2015 时定义的。它的值是唯一的且不可被改变的。

BigInt：很大的整数。

## 注释

单行注释可以使用 `//`，多行注释使用 `/*...*/`

## 运算符

### typeof

用来查看值的类型。

``` javascript
console.log(typeof true);
console.log(typeof 23);
console.log(typeof 'Jonas')
```

