# Chrome 键盘快捷键

官方网址：https://support.google.com/chrome/answer/157179?hl=zh-Hans&co=GENIE.Platform%3DDesktop

# JavaScript 基础

JavaScript 是一种动态语言，这意味着它不需要定义变量的类型。

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

允许一行同时申明多个变量：

``` javascript
let a, b, c;
const d = 20, e = 30, f = 40;
```

## 常量

常量的命名规则为全部字母大写。

可以使用 `const` 申明常量，申明时必须初始化。

``` javascript
const PI = 3.1415926;
```

可以使用 const 初始化一个数组或者对象，虽热不能改变给const重新赋值，但依然可以改变数组或对象中的内容。
```javascript
const arr = [1, 2, 3, 4];
// 不可以这样做，会报错
arr = [1, 2, 3, 4, 5];
console.log(arr);
// 可以这样做
arr.push(5);
console.log(arr);

const person = {
    name: 'Brad'
};
// 可以这样做
person.name = 'John';
person.email = 'brad@gmail.com';
console.log(person);
```

## 数据类型

原始类型和引用类型都是对象。

参考链接：https://262.ecma-international.org/5.1/#sec-11.4.3

有七种原始类型（primitive data type）：Number、String、Boolean、Undefined、Null、Symbol、BigInt。

**Number**：浮点数，所有数字都是 Number 类型。`let age = 23;`

**String**：字符序列，双引号、单引号都支持。`let firstName = "Jonas";`

**Boolean**：逻辑类型，只能是 `true` 或 `false`。`let fullAge = true;`

**Undefined**：当变量的值还未定义时（空值）。 `let children; `

```javascript
let children;
console.log(children);  //undefined
console.log(typeof children);  //undefined
```

**Null**：空值。

``` javascript
console.log(typeof null);  //object
```

返回值为 object 的原因：

在 JavaScript 最初的实现中，JavaScript 中的值是由一个表示类型的标签和实际数据值表示的。对象的类型标签是 0。由于 `null` 代表的是空指针（大多数平台下值为 0x00），因此，null 的类型标签是 0，`typeof null` 也因此返回 `"object"`。

参考链接：https://developer.mozilla.org/zh-CN/docs/Web/JavaScript/Reference/Operators/typeof#typeof_null

**Symbol**：ES2015 时定义的。它的值是唯一的且不可被改变的。

``` javascript
const id = Symbol('id');
console.log(typeof id);  //symbol
```

**BigInt**：很大的整数。

``` javascript
const n = 9007199254740991n;
console.log(typeof n);  //bigint
```

引用类型

``` javascript
const numbers = [1, 2, 3, 4];
console.log(typeof numbers);  //object

const person = {
    name: 'Brad'
};
console.log(typeof person);  //object

function sayHello() {
    console.log('Hello');
}
console.log(typeof sayHello);  //function
```

### 数字

虽然数字是原始类型，但 JavaScript 会为数字创建临时的包装器，所以数字会有属性和方法。可以通过 `new Number(5)` 将数字变成 object 类型。

#### 属性

##### 数字的最大值（Number.MAX_VALUE）

``` javascript
console.log(Number.MAX_VALUE);  //1.7976931348623157e+308
```

##### 数字的最小值（Number.MIN_VALUE）

``` javascript
console.log(Number.MIN_VALUE);  //5e-324
```

#### 方法

##### 数字转换成字符串（num.toString）

``` javascript
const num = 5;
console.log(num.toString(), typeof num.toString());
```

##### 指定小数位数（num.toFixed）

四舍五入。

``` javascript
const num = 5;
console.log(num.toSFixed(2));  //5.00
```

##### 指定数字总数（num.toPrecision）

四舍五入。

``` javascript
const num = 55.4567;
console.log(num.toPrecision(4)); //55.46
```

##### 转成科学计数显示（num.toExponential）

指定保留几位小数，四舍五入。

``` javascript
const num = 55.4567;
console.log(num.toExponential(3));  //5.546e+1
```

##### 将数字转换成国家语言（num.toLocaleString）

``` javascript
const num = 55.4567;
console.log(num.toLocaleString('en-US'));  //55.457
//中文简体
console.log(num.toLocaleString('zh-CN'));  //55.457
//中文繁体
console.log(num.toLocaleString('zh-TW'));  //55.457
//阿拉伯语在埃及
console.log(num.toLocaleString('ar-EG'));  //٥٥٫٤٥٧
```

##### 获取变量原始值（num.valueOf）

``` javascript
const num = new Number(55.4567);
console.log(typeof num);  //object
console.log(num.valueOf(), typeof num.valueOf());  //55.4567 'number'
```

### 字符串

字符串可以使用 `""` 表示或者使用模板字符串（Template Literals，推荐使用模板字符串）表示。

模板字符串使用 `` ` `` 将字符串括起来，使用 `${}` 将变量括起来表示占位符（placehold）。当模板字符串中包含 `` ` `` 时，需要使用 `` \` `` 表示 `` ` ``；当模板字符串中包含 `${}` 时需要使用 `\${}` 表示占位符。

``` javascript
const firstName = "Jhon"
const jhonSay = `I'm ${firstName}`
```

#### 属性

虽然字符串是原始类型，但 JavaScript 会为字符串创建临时的包装器，所以字符串会有属性和方法。当我们调用 `s.length` 时，JavaScript 会 `const s = new String('Hello World');`。此时类型会变成 object。

##### 字符串长度（`s.length`）

``` javascript
const s = 'Hello World';
console.log(s.length); 11
```

##### 根据下标访问字符串的字符（s[0]）

从 0 开始。

``` javascript
const s = 'Hello World';
console.log(s[0]);  //H
```

##### 获取字符串内置属性和方法（s.proto）

与 `console.log(new String('Hello World'));` 中的 [[Prototype]] 是一样的。

``` javascript
const s = 'Hello World';
console.log(s.__proto__);
```

#### 方法

##### 字符串全部大写（s.toUpperCase）

``` javascript
const s = 'Hello World';
console.log(s.toUpperCase());
```

##### 字符串全部小写（s.toLowerCase）

``` javascript
const s = 'Hello World';
console.log(s.toLowerCase());
```

##### 返回指定索引处字符（s.charAt）

``` javascript
const s = 'Hello World';
console.log(s.charAt(0));  //H
```

##### 返回第一个指定字符索引（s.indexOf）

```javascript
const s = 'Hello World';
console.log(s.indexOf('o'));  //4
```

##### 获取子字符串（s.substring）

``` javascript
const s = 'Hello World';
console.log(s.substring(0, 2));  //He
// 从下标 7 开始到字符串结尾
console.log(s.substring(7));  //orld
// 不支持负索引
console.log(s.substring(-1));  //Hello World
console.log(s.substring(0, -1));  //''
```

##### 字符串切片（s.slice）

支持负索引

``` javascript
const s = 'Hello World';
console.log(s.slice(0, 2));  //He
// 从下标 7 开始到字符串结尾
console.log(s.slice(7));  //orld
console.log(s.slice(-1));  //d
console.log(s.slice(-11, -1));  //Hello Worl
```

##### 字符串分割（s.split）

``` javascript
const s = 'Hello World';
console.log(s.split());  //['Hello World']
console.log(s.split(' '));  //['Hello', 'World']
// 分割字符串的每个字符
console.log(s.split(''));  //['H', 'e', 'l', 'l', 'o', 'W', 'o', 'r', 'l', 'd']
```

##### 去除开头空白字符串（s.trim）

``` javascript
const s = '     Hello World';
console.log(s.trim());  //Hello World
```

##### 字符串替换（s.replace）

``` javascript
const s = 'Hello World';
console.log(s.replace('World', 'Bob'));  //Hello Bob
```

##### 判断字符串包含（s.includes）

``` javascript
const s = 'Hello World';
console.log(s.includes('Hell'));  //true
console.log(s.includes('Hi'));  //false
```

##### 获取变量原始值（s.valueOf）

``` javascript
const s = new String('Hello World');
console.log(s.valueOf(), typeof s.valueOf());  //Hello World string
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

### 引用类型

#### 数组

索引从 0 开始。一个数组中可以同时存在不通类型的元素。<font color=skyblue>注意：</font>当使用构造函数构造数组，只传入 1 个参数且该参数为整型时，此参数会被视作数组长度，从而创建 n 个元素为空的数组。

``` javascript
// Array Literal
const numbers = [12, 45, 33, 29, 39];
console.log(numbers);
const mixed = [12, 'Hello', true, null];
console.log(mixed);
// Array Constructor 构造函数
const fruits = new Array('apple', 'grape', 'orange');
console.log(fruits);
console.log(numbers[0]);  //12
fruits[2] = 'pear';
console.log(fruits);
// 构造函数入参为 1 个时
const words = new Array('hello');
console.log(words);  //['hello']
let guess = new Array(1);
console.log(guess);  //[undefined]
guess = new Array(3);
console.log(guess);  //[undefined, undefined, undefined]
const record = new Array(1, 'hello');
console.log(record);  //[1, 'hello']
const count = new Array(1.2);
console.log(count);  //报错，Invalid array length
// Nesting Array 嵌套数组
const foods = ['apple', 'pear', 'orange', ['strawberry', 'blueberry', 'rasberry']];
console.log(foods[3][1]);  //blueberry
```

##### 属性

###### 数组长度

``` javascript
const numbers = [12, 45, 33, 29, 39];
console.log(numbers.length);  //5
numbers.length = 2
console.log(numbers);  //[12, 45]
```

##### 方法

###### 添加元素（索引 或 push 或 unshift）

``` javascript
const numbers = [12, 45, 33, 29, 39];
// 向末尾添加元素
numbers[5] = 40;
console.log(numbers);  //[12, 45, 33, 29, 39, 40]
numbers[numbers.length] = 89;
console.log(numbers);  //[12, 45, 33, 29, 39, 40, 89]
numbers.push(100);
console.log(numbers);  //[12, 45, 33, 29, 39, 40, 89, 100]
// 向首位添加元素
numbers.unshift(1);
console.log(numbers);  //[1, 12, 45, 33, 29, 39, 40, 89, 100]
```

###### 移除元素（pop 或 shift）

``` javascript
const numbers = [12, 45, 33, 29, 39];
// 移除末尾元素
numbers.pop();
console.log(numbers);  //[12, 45, 33, 29]
// 移除首位元素
numbers.shift();
console.log(numbers);  //[45, 33, 29]
```

###### 反转数组（reverse）

``` javascript
const numbers = [12, 45, 33, 29, 39];
numbers.reverse();
console.log(numbers);  //[39, 29, 33, 45, 12]
```

###### 数组是否包含指定元素（includes）

``` javascript
const numbers = [12, 45, 33, 29, 39];
console.log(numbers.includes(1));  //false
```

###### 获取数组指定元素索引（indexOf）

如果指定元素不存在，则返回 -1。

``` javascript
const numbers = [12, 45, 33, 29, 39];
console.log(numbers.indexOf(12));  //0
console.log(numbers.indexOf(1));  //-1
```

###### 数组切片（slice）

不会改变数组本身。

``` javascript
const numbers = [12, 45, 33, 29, 39];
console.log(numbers.slice(1));  //[45, 33, 29, 39]
// [startIndex, endIndex)
console.log(numbers.slice(1,3));  //[45, 33]
```

###### 数组拼接（splice）

会改变数组本身。从数组中取出指定长度的元素。

``` javascript
const numbers = [12, 45, 33, 29, 39];
// startIndex, deleteCount
x = numbers.splice(1, 3);
console.log(x);  //[45, 33, 29]
console.log(numbers);  //[12, 39]
```

###### 数组连接（concat 或 ...）

不会改变数组本身。

``` javascript
const fruits = ['apple', 'pear', 'orange'];
const berries = ['strawberry', 'blueberry', 'rasberry'];
console.log(fruits);  //['apple', 'pear', 'orange']
console.log(berries);  //['strawberry', 'blueberry', 'rasberry']
console.log(fruits.concat(berries));  //['apple', 'pear', 'orange', 'strawberry', 'blueberry', 'rasberry']
// ... 是扩展运算符（spread operator）
let x = [...fruits, berries];
console.log(x);  //['apple', 'pear', 'orange', ['strawberry', 'blueberry', 'rasberry']]
x = [...fruits, ...berries];
console.log(x);  //['apple', 'pear', 'orange', 'strawberry', 'blueberry', 'rasberry']
```

###### 展平数组（flat）

不会改变数组本身。

``` javascript
// Flatten Arrays 展平数组
const arr = [1, 2, [3, 4], 5, [6, 7], 8];
let x = arr.flat();
console.log(arr);  //[1, 2, [3, 4], 5, [6, 7], 8]
console.log(x);  //[1, 2, 3, 4, 5, 6, 7, 8]
```

###### 是否是数组（Array.isArray）

``` javascript
const fruits = ['apple', 'pear', 'orange'];
console.log(Array.isArray(fruits));  //true
console.log(Array.isArray('Hello'));  //false
```

###### 可迭代对象转换成数组（Array.from）

``` javascript
console.log(Array.from('Hello'));  //['H', 'e', 'l', 'l', 'o']
```

###### 创建一个新的数组实例（Array.of）

``` javascript
const a = 1;
const b = 2;
const c = 3;
console.log(Array.of(a, b, c));  //[1, 2, 3]
```

#### 对象

对象可以嵌套对象，函数也可以作为对象的属性。如下所示，name、age、isAdmin、address、hobbies 都是 person 对象的属性。

``` javascript
const person = {
    name: 'John',
    age: 30,
    isAdmin: true,
    address: {
        street: '123 Main st',
        city: 'Boston',
        state: 'MA',
    },
    hobbies: ['music', 'sports'],
    'first name': 'Brad',  //这样写也可以但不推荐
    'last name': 'Traversy',
};
console.log(person);
console.log(person.name);
console.log(person['age']);
console.log(person.address.state);
console.log(person.hobbies[0]);
console.log(person['first name']);  //Brad
console.log(person.first name);  //会报错，missing ) after argument list

person.name = 'Jane';
console.log(person.name);
person['isAdmin'] = false;
console.log(person.isAdmin);

// 函数作为对象的属性
person.greet = function () {
    console.log(`Hello, my name is ${this.name}`)
}

person.greet();

// 删除属性
delete person.age;
console.log(person);

// 添加属性
person.hasChildren = true;
console.log(person);
```



## 类型转换

控制台打印结果的颜色会不同用来区分不同的数据类型。

### 字符串数字互相转换

字符串强转数字

``` javascript
// 整型
const inputYear = '1991';
console.log(Number(inputYear), typeof Number(inputYear));
console.log(+inputYear, typeof +inputYear);
console.log(parseInt(inputYear), typeof parseInt(inputYear));

// 小数
const inputYear = '1991.5';
console.log(Number(inputYear), typeof Number(inputYear));
console.log(+inputYear, typeof +inputYear);
console.log(parseFloat(inputYear), typeof parseFloat(inputYear));
```

如果传入强转的参数是非法的则会得到 `NaN` 代表不是一个数字，`not a number`。但 `typeof NaN`，会得到 `number`。

``` javascript
Number('hello')  //NaN
typeof NaN  //number
console.log(Math.sqrt(-1), typeof Math.sqrt(-1));  //NaN number
console.log(1 + NaN, typeof (1 + NaN));  //NaN number
console.log(undefined + undefined, typeof (undefined + undefined));  //NaN number
console.log('food' / 3, typeof ('food' / 3));  //NaN number
```

数字强转字符串

``` javascript
const inputYear = 1991;
console.log(String(inputYear), typeof String(inputYear));
// 虽然 inputYear 是原始类型，不是一个 object，但当我们使用 toString 时，JavaScript 会创建适当对象类型的临时包装器。
console.log(inputYear.toString(), typeof inputYear.toString());
```

`-`、`*`、`/` 会自动将字符串转换成数字，`+` 则会自动将数字转换成字符串。但如果 `+` 两侧都不是字符串时，不会将数字转换成字符串。

``` javascript
const inputYear = '1991'
console.log(inputYear + 18)  //199118
console.log(1991 + null)  //1991，null 会被自动强转成 number，即 0
console.log(1991 + true)  //1992，true 会被自动强转成 number，即 1
console.log(1991 + false)  //1992
console.log(1991 + undefined)  //NaN
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

支持的运算符：`+`、`-`、`*`、`/`、`%`、`++`、`--`、`**`（`2 ** 3`，2 的 3 次方）、`+=`、`-=`、`*=`、`/=`、`%=`、`%=`、`**=`、`==`（不会判断类型是否相等，只检查值）、`===`（类型和值都相等才为 true）、`!=`（不会判断类型是否相等，只检查值）、`!==`（类型和值都相等才为 false）、`>`、`<`、`>=`、`<=`

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

## 内置对象

### Math

`console.log(Math);` 可以打印出 `Math` 对象，查看它的属性和方法。

#### 平方根（sqrt）

``` javascript
console.log(Math.sqrt(9));  //3
```

#### 绝对值（abs）

``` javascript
console.log(Math.abs(-5));  //5
```

#### 四舍五入（round）

``` javascript
console.log(Math.round(0.333));  //0
```

#### 向上取整（ceil）

``` javascript
console.log(Math.ceil(4.2));  //5
```

#### 向下取整（floor）

``` javascript
console.log(Math.floor(4.9));  //4
```

#### 幂值（pow）

``` javascript
//2 的 3 次方
console.log(Math.pow(2, 3));  //8
```

#### 最小值（min）

``` javascript
console.log(Math.min(4, 5, 3));  //3
```

#### 最大值（max）

``` javascript
console.log(Math.max(4, 5, 3));  //5
```

#### 随机数（random）

随机 0 到 1 之间包含 0 但不包含 1 的小数。

``` javascript
console.log(Math.random());  //0.23900904985398075
```

### Date（日期时间）

`console.log(new Date())` 能够得到当前日期时间和所在的时区 `Fri Jan 31 2025 19:04:35 GMT+0800 (GMT+08:00)`。

#### 转成字符串（toString）

```javascript
let d = new Date();
console.log(d.toString());
```

#### 得到指定日期时间对象（new Date）

月份是从 0 开始的。

``` javascript
let d = new Date(2025, 0, 1);
console.log(d);  //Wed Jan 01 2025 00:00:00 GMT+0800 (GMT+08:00)
d = new Date(2025, 0, 1, 12, 30, 1);
console.log(d);  //Wed Jan 01 2025 12:30:01 GMT+0800 (GMT+08:00)
// 也可以传入字符串
d = new Date('2025-1-1');
console.log(d);  //Wed Jan 01 2025 00:00:00 GMT+0800 (GMT+08:00)
d = new Date('2025-1-1 12:30:1');
console.log(d);  //Wed Jan 01 2025 12:30:01 GMT+0800 (GMT+08:00)
d = new Date('2025-01-01T12:30:01');
console.log(d);  //Wed Jan 01 2025 12:30:01 GMT+0800 (GMT+08:00)
d = new Date('2025/01/01 12:30:01');
console.log(d);  //Wed Jan 01 2025 12:30:01 GMT+0800 (GMT+08:00)
d = new Date('01/01/2025 12:30:01');
console.log(d);  //Wed Jan 01 2025 12:30:01 GMT+0800 (GMT+08:00)
// 获取当前日期时间对象
d = new Date();
console.log(d);  //Sun Feb 02 2025 22:11:53 GMT+0800 (GMT+08:00)
// 也可以传入时间戳
d = new Date(1735705801000);
console.log(d);  //Wed Jan 01 2025 12:30:01 GMT+0800 (GMT+08:00)
```

#### 获取当前时间戳（now）

单位是毫秒。

``` javascript
let d = Date.now();
console.log(d);  //1738503576206
```

#### 获取指定日期时间戳（getTime 或 valueOf）

``` javascript
let d = new Date('2025/01/01 12:30:01');
d = d.getTime();
console.log(d);  //1735705801000
d = d.valueOf();
console.log(d);  //1735705801000
```

#### 时间戳转换为秒为单位

``` javascript
let d = Math.floor(Date.now() / 1000);
console.log(d);  //1738505790
```

#### 获取日期时间对象年份（getFullYear）

``` javascript
let d = new Date();
d = d.getFullYear();
console.log(d);  //2025
```

#### 获取日期时间对象月份（getMonth）

获取的月份是实际月份 - 1，也就是从 0 开始算月份。

``` javascript
let d = new Date();
console.log(d);  //Mon Feb 03 2025 23:14:44 GMT+0800 (GMT+08:00)
d = d.getMonth();
console.log(d);  //1
```

#### 获取日期时间对象的日（getDate）

``` javascript
let d = new Date();
console.log(d);  //Mon Feb 03 2025 23:18:42 GMT+0800 (GMT+08:00)
d = d.getDate();
console.log(d);  //3
```

#### 获取日期时间对象几点（getHours）

``` javascript
let d = new Date();
console.log(d);  //Mon Feb 03 2025 23:24:59 GMT+0800 (GMT+08:00)
d = d.getHours();
console.log(d);  //23
```

#### 获取日期时间对象几分（getMinutes）

``` javascript
let d = new Date();
console.log(d);  //Mon Feb 03 2025 23:27:16 GMT+0800 (GMT+08:00)
d = d.getMinutes();
console.log(d);  //16
```

#### 获取日期时间对象几毫秒（getMilliseconds）

``` javascript
let d = new Date();
console.log(d);  //Mon Feb 03 2025 23:28:41 GMT+0800 (GMT+08:00)
d = d.getMinutes();
console.log(d);  //28
```

#### 获取日期时间对象几秒（getSeconds）

``` javascript
let d = new Date();
console.log(d);  //Mon Feb 03 2025 23:26:08 GMT+0800 (GMT+08:00)
d = d.getSeconds();
console.log(d);  //26
```

#### 获取日期时间对象是周几（getDay）

周日返回 0。

``` javascript
let d = new Date();
console.log(d);  //Mon Feb 03 2025 23:21:30 GMT+0800 (GMT+08:00)
d = d.getDay();
console.log(d);  //1
d = new Date('2025/2/2');
console.log(d);  //Sun Feb 02 2025 00:00:00 GMT+0800 (GMT+08:00)
d = d.getDay();
console.log(d);  //0
```

#### 根据地区格式化日期时间对象（toLocaleString 或 Intl.DateTimeFormat）

toLocaleString：

``` javascript
let d = new Date();
console.log(d);  //Tue Feb 04 2025 00:03:24 GMT+0800 (GMT+08:00)
x = d.toLocaleString('default', { year: "2-digit", month: "2-digit", day: "2-digit" });
console.log(x);  //25/02/04
x = d.toLocaleString('default', { year: "numeric", month: "numeric", day: "numeric" });
console.log(x);  //2025/2/4
x = d.toLocaleString('default', { month: "narrow" });
console.log(x);  //2
x = d.toLocaleString('default', { month: "long" });
console.log(x);  //二月
x = d.toLocaleString('default', { month: "short" });
console.log(x);  //2月
x = d.toLocaleString('default', {
    weekday: 'long',
    year: 'numeric',
    month: 'long',
    day: 'numeric',
    hour: 'numeric',
    minute: 'numeric',
    second: 'numeric',
    timeZone: 'America/New_York',
});
// 设置了 timeZone 的原因，当前时间在美国的时间
console.log(x);  //2025年2月3日星期一 11:03:24
// 不设置 timeZone 后
x = d.toLocaleString('default', {
    weekday: 'long',
    year: 'numeric',
    month: 'long',
    day: 'numeric',
    hour: 'numeric',
    minute: 'numeric',
    second: 'numeric',
});
console.log(x);  //2025年2月4日星期二 00:03:24
```

Intl.DateTimeFormat：

``` javascript
let d = new Date();
console.log(d);  //Tue Feb 04 2025 00:03:24 GMT+0800 (GMT+08:00)
// 美国
x = Intl.DateTimeFormat('en-US').format(d);
console.log(x);  //2/4/2025
// 英国
x = Intl.DateTimeFormat('en-GB').format(d);
console.log(x)  //04/02/2025
x = Intl.DateTimeFormat('default').format(d);
console.log(x)  //2025/2/4
// 修改格式，也可以得到一部分
x = Intl.DateTimeFormat('default', { year: "2-digit", month: "2-digit", day: "2-digit" }).format(d);
console.log(x);  //25/02/04
x = Intl.DateTimeFormat('default', { year: "numeric", month: "numeric", day: "numeric" }).format(d);
console.log(x);  //2025/2/4
x = Intl.DateTimeFormat('default', { month: "narrow" }).format(d);
console.log(x);  //2
x = Intl.DateTimeFormat('default', { month: "long" }).format(d);
console.log(x);  //二月
x = Intl.DateTimeFormat('default', { month: "short" }).format(d);
console.log(x);  //2月
```

# console 打日志方法

```javascript
const x=100;
console.log(x);
console.warn('Warning');
console.error('Alert');

console.table({ name: 'Brad', email: 'brad@gmail.com'});

console.group('sample');
console.log(x);
console.warning('Warning');
console.error('Alert');
console.groupEnd();
```

![](图片\console 打日志方法.png)

打印带 css 样式的日志

```javascript
const styles = 'padding 10px; background-color: black; color: skyblue';
console.log('%cHello World', styles);
```

![](图片\console 打印带 css 样式的日志.png)
