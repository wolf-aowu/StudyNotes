# Chrome 键盘快捷键

官方网址：https://support.google.com/chrome/answer/157179?hl=zh-Hans&co=GENIE.Platform%3DDesktop

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

可以使用 `const` 申明常量，申明时必须初始化。

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

### 字符串

字符串可以使用 `""` 表示或者使用模板字符串（Template Literals，推荐使用模板字符串）表示。

模板字符串使用 `` ` `` 将字符串括起来，使用 `${}` 将变量括起来表示占位符（placehold）。当模板字符串中包含 `` ` `` 时，需要使用 `` \` `` 表示 `` ` ``；当模板字符串中包含 `${}` 时需要使用 `\${}` 表示占位符。

``` javascript
const firstName = "Jhon"
const jhonSay = `I'm ${firstName}`
```

#### 多行字符串

一般使用 `\n\` 表示换行。

```javascript
console.log('String with \n\
multiple \n\
lines');
```

模板字符串：

```javascript
console.log(`String
multible
lines`);
```

### 布尔值

只有 5 种值会被转换成 false，其他的值都会被转换成 true。这 5 种会被转换成 false 的值：

`0`、`''`、`undefined`、`null`、`NaN`

## 类型转换

控制台打印结果的颜色会不同用来区分不同的数据类型。

### 字符串数字互相转换

字符串强转数字

``` javascript
const inputYear = '1991';
console.log(Number(inputYear));
```

如果传入强转的参数是非法的则会得到 `NaN` 代表不是一个数字。但 `typeof NaN`，会得到 `number`。

``` javascript
Number('hello')  //NaN
typeof NaN  //number
```

数字强转字符串

``` javascript
const inputYear = 1991;
console.log(String(inputYear))
```

`-`、`*`、`/` 会自动将字符串转换成数字，`+` 则会自动将数字转换成字符串。

``` javascript
const inputYear = '1991'
console.log(inputYear + 18)  //199118
console.log(inputYear - 18)  //1973
console.log(inputYear * 2)  //3982
console.log(inputYear / 2)  //995.5
```

例子：

``` javascript
console.log(2 + 3 + 4 + '5')  //95
console.log('10' - '3' - '4' - '2' + '5')  //15
console.log('10' - '3' - '4' - '2' + 5)  //6
```

### 布尔值强转

``` javascript
console.log(Boolean(0));  //false
console.log(Boolean(undefined));  //false
console.log(Boolean(''));  //false
console.log(Boolean({}));  //true
```

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

### 相等

判断相等的符号有两种 `==` 和 `===`。`===` 是严格意义上的相等，`==` 会对两边数据类型进行强制转换。

``` javascript
let favourite = 23;
console.log(favourite === '23');  // false
console.log(favourite == '23');  // true
```

### 不相等

不相等的符号也有两种 `!=` 和 `!==`。`!==` 是严格意义上的不相等，`!=` 会将两边数据类型进行强制转换。

``` javascript
let favourite = 23;
console.log(favourite !== '23');  // true
console.log(favourite != '23');  // false
```

## if

具有作用域，不能写成如下所示：

``` javascript
// 会出现 century is not defined 的报错
const birthYear = 1991;
if (birthYear <= 2000) {
    let century = 20;
} else if (birthYear === 2001) {
    let century = 21;
} else {
    let century = 21;
}
console.log(century)
```

正确写法：

```javascript
let century;
const birthYear = 1991;
if (birthYear <= 2000) {
    century = 20;
} else if (birthYear === 2001) {
	century = 21;
} else {
    century = 21;
}
console.log(century)
```

