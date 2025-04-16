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

### typeof

用来查看值的类型。

``` javascript
console.log(typeof true);  //boolean
console.log(typeof 23);  //number
console.log(typeof 'Jonas')  //string
```

### 数字

虽然数字是原始类型，但 JavaScript 会为数字创建临时的包装器，所以数字会有属性和函数。可以通过 `new Number(5)` 将数字变成 object 类型。

#### 属性

##### 数字的最大值（Number.MAX_VALUE）

``` javascript
console.log(Number.MAX_VALUE);  //1.7976931348623157e+308
```

##### 数字的最小值（Number.MIN_VALUE）

``` javascript
console.log(Number.MIN_VALUE);  //5e-324
```

#### 函数

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

虽然字符串是原始类型，但 JavaScript 会为字符串创建临时的包装器，所以字符串会有属性和函数。当我们调用 `s.length` 时，JavaScript 会 `const s = new String('Hello World');`。此时类型会变成 object。

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

##### 获取字符串内置属性和函数（s.proto）

与 `console.log(new String('Hello World'));` 中的 [[Prototype]] 是一样的。

``` javascript
const s = 'Hello World';
console.log(s.__proto__);
```

#### 函数

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

`0`、`''`、`undefined`、`null`、`NaN`。

由于 0 会被判断为 false，所以当需要判断一个变量是否有值，可以通过下面两种方式判断：

``` javascript
const children = 3;

// 方法一
if (children !== undefined) {
    console.log(`You have ${children} children`);
} else {
   console.log('Please enter number of children'); 
}

// 方法二
if (children) {
    console.log(`You have ${children} children`);
} else {
   console.log('Please enter number of children'); 
}
```

由于空数组和空对象都被认为是 true，所以需要通过以下方法分别区分是否为空数组和对象。

检查空数组：

``` javascript
const posts = ['Post One', 'Post Two'];

if (posts.length > 0) {
    consle.log('List Posts');
} else {
    console.log('No Posts To List');
}
```

检查空对象：

``` javascript
const user = {
    name: 'Brad'
};

if (Object.keys(user).length > 0) {
    console.log('List User');
} else {
    console.log('No User');
}
```

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

// Destructure arrays 解构数组
const [first, second, ...rest] = numbers;
console.log(first, second, rest);  //12 45 [33, 29, 39]
```

##### 属性

###### 数组长度

``` javascript
const numbers = [12, 45, 33, 29, 39];
console.log(numbers.length);  //5
numbers.length = 2
console.log(numbers);  //[12, 45]
```

##### 函数

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

对象可以嵌套对象，函数也可以作为对象的属性。如下所示，name、age、isAdmin、address、hobbies 都是 person 对象的属性。创建对象时，变量名与对象的属性名相同，可以只传入变量而不写出属性名。

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

// Destructuring 解构
const { address: { street }, isAdmin } = person;
console.log(street, isAdmin);  //123 Main st true
// 也可以为取出的值的变量名重命名
const { name: alias } = person;
console.log(alias);  //John

person.name = 'Jane';
console.log(person.name);
person['isAdmin'] = false;
console.log(person.isAdmin);

// 也可以这样创建一个对象
const todo = new Object();
todo.id = 1;
todo.name = 'Buy Milk';
todo.completed = false;
console.log(todo); 

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

const firstName = 'John';
const lastName = 'Doe';
const age = 30;

// 创建对象时，变量名与对象的属性名相同，可以只传入变量而不写出属性名
const customer = {
    firstName,
    lastName,
    age,
};
console.log(customer.age);
```

##### 函数

###### 对象连接（... 或 Object.assign）

`Object.assign` 用于将一个或多个源对象的可枚举自有属性复制到目标对象中，会自动跳过 null 和 undefined，是浅复制。

``` javascript
const obj1 = { a: 1, b: 2 };
const obj2 = { c: 3, d: 4 };
const obj3 = { ...obj1, ...obj2 };
console.log(obj3);  //{a: 1, b: 2, c: 3, d: 4}

const obj4 = Object.assign({}, obj1, obj2);
console.log(obj4);  //{a: 1, b: 2, c: 3, d: 4}
// Object.assign 是浅复制
const obj5 = Object.assign({}, {...obj1, obj2});
console.log(obj5);  //{a: 1, b: 2, obj2: {c: 3, d: 4}}
obj5.obj2.d = 5;
console.log(obj5);  //{a: 1, b: 2, obj2: {c: 3, d: 5}}
console.log(obj2);  //{c: 3, d: 5}
```

###### 获取对象所有的属性名数组（Object.keys）

``` javascript
const todo = new Object();
todo.id = 1;
todo.name = 'Buy Milk';
todo.completed = false;
console.log(todo); 
console.log(Object.keys(todo));  //['id', 'name', 'completed']

// 获取对象的属性个数
console.log(Object.keys(todo).length);  //3
```

###### 获取对象所有属性值数组（Object.values）

``` javascript
const todo = new Object();
todo.id = 1;
todo.name = 'Buy Milk';
todo.completed = false;
console.log(todo); 
console.log(Object.values(todo));  //[1, 'Buy Milk', false]
```

###### 获取对象所有属性键值对数组（Object.entries）

``` javascript
const todo = new Object();
todo.id = 1;
todo.name = 'Buy Milk';
todo.completed = false;
console.log(todo); 
console.log(Object.entries(todo));  //[['id', 1], ['name', 'Buy Milk'], ['completed', false]]
```

###### 对象是否包含指定属性（hasOwnProperty）

``` javascript
const todo = new Object();
todo.id = 1;
todo.name = 'Buy Milk';
todo.completed = false;

console.log(todo.hasOwnProperty('name'));  //true
console.log(todo.hasOwnProperty('age'));  //false
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

### 对象 JSON 互相转换

#### 对象转字符串类型的 JSON

``` javascript
const post = {
    id: 1,
    title: 'Post One',
    body: 'This is the body',
};

const str = JSON.stringify(post);
console.log(str);  //{"id":1,"title":"Post One","body":"This is the body"}
console.log(typeof(str));  //string
```

#### 字符串类型的 JSON 转对象

``` javascript
const str = '{"id":1,"title":"Post One","body":"This is the body"}';
const obj = JSON.parse(str);
console.log(obj);  //{id: 1, title: 'Post One', body: 'This is the body'}
console.log(typeof (obj));  //object
```

## 作用域

作用域可分为：全局和块级（block）。在 `if`、`for`、`function` 中使用 `let`、`const` 创建的变量都是块级变量。在 `if`、`for` 中使用 `var` 创建的变量是全局变量，在 `function` 中使用 `var` 创建的变量是块级变量。

在全局中使用 `var` 创建的变量，会作为 `Window` 对象的属性。

``` javascript
if (true) {
    const x = 100;
    let y = 200;
    var z = 300;
}
console.log(x);  //会报错，Uncaught ReferenceError: x is not defined
console.log(y);  //会报错，Uncaught ReferenceError: y is not defined
console.log(z);  //300

for (let i = 0; i <= 3; i++) {
    console.log(`i: ${i} in for`);
}
console.log(`i: ${i} out for`);  //会报错，Uncaught ReferenceError: i is not defined

for (var j = 0; j <= 3; j++) {
    console.log(`j: ${j} in for`)
}
console.log(`j: ${j} out for`);  //j: 4 out for

const a = 1;
let b = 2;
var c = 3;
console.log(window.a);  //undefined
console.log(window.b);  //undefined
console.log(window.c);  //3
```

嵌套：

``` javascript
function first() {
    const x = 100;
    function second() {
        const y = 200;
        console.log(x + y);  //300
    }
    second();
    console.log(y);  //会报错，Uncaught ReferenceError: y is not defined
}
first();

if(true) {
    const x = 100;
    if(x === 100) {
        const y = 200;
        cosole.log(x + y);  //300
    }
    console.log(y);  //会报错，Uncaught ReferenceError: y is not defined
}
```

## 函数

如果入参没有设置默认值，且调用函数时没有传入参数时参数会被赋值为 `undefined`。

`...` 可以接收无数个入参，以数组形式传入。

``` javascript
// Function Declaration 函数声明
function subtract(num1 = 2, num2 = 1) {  //设置了默认值
    return num1 - num2;
}
const result = subtract(10, 2);
console.log(result, subtract(20, 5));  //8 15

function printNum(num1) {
    console.log(num1);
}
printNum();  //undefined

// Rest Params 自动获取余下的参数，以数组形式传入
function sum(...numbers) {
    console.log(numbers, typeof numbers);  //[1, 2, 3, 4, 5] 'object'
    let total = 0;
    
    for (const num of numbers) {
        total += num;
    }
    
    return total;
}
console.log(sum(1, 2, 3, 4, 5));  //15
```

### 函数声明和函数表达式

声明和调用函数有两种写法：函数声明和函数表达式。

调用函数可以在函数声明之前，而调用不能在函数表达式之前。

``` javascript
// Function Declaration
console.log(addDollarSign(100));  //$100
function addDollarSign(value) {
    return '$' + value;
}

// Function Expression
console.log(addPlusSign(200));  //会报错，Uncaught ReferenceError: Cannot access 'addPlusSign' before initialization
const addPlusSign = function (value) {
    return '+' + value;
};
console.log(addPlusSign(200));  //+200
```

### 箭头函数（Arrow Function）

``` javascript
// function add(a, b) {
//     return a + b;
// }

// Arrow function syntax
// 可以把上面的函数写成
const add = (a, b) => {
    return a + b;
};

// Implicit Return
// 当函数体只有一行时，可以写成
const subtract = (a, b) => a - b;

// 当只有一个入参时，可以写成
const double = a => a * 2;

// 当想要返回一个对象时，需要用 () 括起来（指 {name: 'Brad'} 的括号）
const createObj = () => ({
    name: 'Brad',
});

console.log(add(2, 3));
console.log(subtract(10, 5));
console.log(double(a));
console.log(createObj());

// Arrow function in a callback
const numbers = [1, 2, 3]
// numbers.forEach(function (n) {
// 	console.log(n);
// });
// 可以写成
numbers.forEach(n => console.log(n));
```

### 立即调用函数表达式（Immediately Invoked Function Expression）

Immediately Invoked Function Expression 的简称为 IIFE。<font color=skyblue>应该尽量避免这种写法，因为这种写法会污染全局变量。</font>这种写法在声明函数时，会立即调用该函数。

假设有两个 javascript 脚本，文件名分别为 script.js 和 otherscript.js。

先执行 script.js 后执行 otherscript.js

script.js 内容：

``` javascript
const user = 'Brad';
console.log(user);  //Brad
```

otherscript.js 内容：

``` javascript
const user = 'John';  //会报错，SyntaxError: Identifier 'user' has already been declared
// 只是将 function 用 () 括起来了，结尾的括号表调用
(function(){
    const user = 'John';
    console.log(user);  //John，这里 user 的作用域其实也只在当前的 IIFE 中
    const hello = () => console.log('Hello from the IIFE');
    hello();  //Hello from the IIFE
})();

hello();  //会报错，Uncaught ReferenceError: hello is not defined，因为作用域只在申明的 IIFE 中

//有入参的函数
(function (name) {
    console.log('Hello ' + name);  //Hello Shawn
})('Shawn');

//也可以给函数取名，用于递归等
(function hello(count) {
    console.log('Hello ' + count);
    if (count === 0) {
        return
    }
    count -= 1;
    hello(count);
})(3);
//Hello 3
//Hello 2
//Hello 1
//Hello 0
```

## 执行上下文（Execution Context）

运行任何 JavaScript 代码时，都会创建一个特殊环境来处理代码的转换和执行，这就叫执行上下文（execution context）。该环境包含了当前正在执行的代码以及所有支持其运行的资源。加载 JavaScript 时创建的执行上下文是全局执行上下文。每个被调用的函数都会有一个自己的函数执行上下文。当函数完成时，自己的函数执行上下文也就完成了。<font color=skyblue>JavaScript 是同步的，一行接着一行执行的。</font>

执行上下文分为两个阶段，内存创建阶段和执行阶段。

内存创建阶段：

1. 创建全局对象（浏览器：window，Node.js：global）。
2. 创建 `this` 对象并将它与全局对象绑在一起。
3. 设置用于存储变量和函数引用的内存堆。
4. 在全局执行上下文中存储变量和函数，并将变量设置为 `undefined`，存储函数所有的代码。

执行阶段：

1. 一行一行执行代码。
2. 每一个函数执行时，创建一个新的执行上下文。

例如：

``` javascript
let x = 100
let y = 50
function getSum(n1, n2) {
    let sum = n1 + n2
    return sum
}
let sum1 = getSum(x, y)
let sum2 = getSum(10, 5)
```

创建阶段：

1. line1：为变量 `x` 分配（allocated）内存并将它存储为 `undefined`。
2. line2：为变量 `y` 分配内存并将它存储为 `undefined`。
3. line3：为 `getSum` 函数分配内存并存储它的所有代码。
4. line7：为变量 `sum1` 分配内存并将它存储为 `undefined`。
5. line8：为变量 `sum2` 分配内存并将它存储为 `undefined`。

执行阶段：

1. line1：将 100 放入变量 `x`。
2. line2：将 50 放入变量 `y`。
3. line3：跳过 `getSum` 函数，因为它没有执行。
4. line7：调用 `getSum` 函数并创建一个新的函数执行上下文。

函数执行上下文创建阶段：

1. 为变量 `n1` 和 `n2` 分配内存并存储为 `undefined`。
2. 为变量 `sum` 分配内存并存储为 `undefined`。

函数执行上下文执行阶段：

1. 变量 `n1` 和 `n2` 分别赋值（assigned）为 100 和 50。
2. 计算得到 150 并将它放入变量 `sum` 中。
3. `return` 告诉函数执行上下文将 `sum` 的值返回给全局执行上下文。
4. 将返回的 `sum` 的值放入变量 `sum1` 中。
5. 开启另一个函数执行上下文，并且使用不同的参数执行相同的操作。

### 调用堆栈（Call Stack）

执行上下文会被放入调用堆栈中进行管理。堆栈（stacks）具有后进先出的特点（LIFO，last in first out）。堆栈的底部是全局执行上下文。函数执行上下文会被压入堆栈中，执行完成后弹出。

## 注释

单行注释可以使用 `//`，多行注释使用 `/*...*/`

## 运算符

支持的运算符：`+`、`-`、`*`、`/`、`%`、`++`、`--`、`**`（`2 ** 3`，2 的 3 次方）、`+=`、`-=`、`*=`、`/=`、`%=`、`%=`、`**=`、`==`（不会判断类型是否相等，只检查值）、`===`（类型和值都相等才为 true）、`!=`（不会判断类型是否相等，只检查值）、`!==`（类型和值都相等才为 false）、`>`、`<`、`>=`、`<=`。逻辑运算符：`&&`（与）、`||`（或）、`??`。赋值运算符：`&&=`、`||=`、`??=`，用法与 `+=` 同理。三元运算符（ternary operator）：`判断条件?(语句,语句):(语句,语句)`。

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

### &&

`&&` 会返回第一个为 false 的值或者最后一个为 true 的值。

``` javascript
let a;
a = 10 && 20;
console.log(a);  //20
a = 10 && 20 && 30;
console.log(a);  //30
a = 10 && 0 && 30;
console.log(a);  //0
a = 10 && '' && 0 && 30;
console.log(a);  //''
// 一般用于不符合条件时不希望执行某些代码
const posts = [];
posts.length > 0 && console.log(posts[0]);  //不会有输出
```

### ||

`||` 会返回第一个为 true 的值或者最后一个值

``` javascript
let b;
b = 10 || 20;
console.log(b);  //10
b = 0 || 20;
console.log(b);  //20
b = 0 || null || '';
console.log(b);  //''
b = 0 || null || '' || undefined;
console.log(b);  //undefined
```

### ??

当左边是 `null` 或者 `undefined` 时，返回右边的操作数（operand）。

``` javascript
let c;
c = 10 ?? 20;
console.log(c);  //10
c = null ?? 20;
console.log(c);  //20
c = undefined ?? 30;
console.log(c);  //30
c = 0 ?? 30;
console.log(c);  //0
c = '' ?? 30;
console.log(c);  //''
```

### 三元运算符

可以理解为简写 `if-else`

``` javascript
let age = 14;
age >= 18 ? console.log('You can vote!') : console.log('You can not vote');

const auth = false;
const redirect = auth ? (alert('Welcome to the dashboard'), '/dashboard') : (alert('Access Denied'), '/login');
```

当只有一个 `if` 没有 `else` 时，可以写成：

```javascript
// auth 为 true 时执行 console.log，为 false 时什么都不执行
auth ? console.log('Welcome to the dashboard') : null;

// 可以利用 && 两者都为 true 就返回最后一个的值的原理，简写成
auth && console.log('Welcome to the dashboard');
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
console.log(century);
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
console.log(century);
```

代码块可以省略大括号，当有多条语句时使用逗号分割

``` javascript
let century;
const birthYear = 1991;
if (birthYear)
    century = 20,
        console.log(century);
else century = 21;
console.log(century);
```

## switch

``` javascript
const d = new Date(2022, 1, 10, 19, 0, 0);
const month = d.getMonth();
const hour = d.getHours();

switch (month) {
    case 1:
        console.log("It is January");  //输出
        break;
    case 2:
        console.log("It is February");
        break;
    case 3:
        console.log("Ite is March");
        break;
    default:
        console.log("It is not Jan, Feb or March");
}

switch (true) {
    case hour < 12:
        console.log("Good Morning");
        break;
    case hour < 18:
        console.log("Good Afternoon");
        break;
    default:
        console.log("Good Night");  //输出
}

function calculator(num1, num2, operator) {
    let result;

    switch (operator) {
        case "+":
            result = num1 + num2;
            break;
        case "-":
            result = num1 - num2;
            break;
        case "*":
            result = num1 * num2;
            break;
        case "/":
            result = num1 / num2;
            break;
        default:
            result = "Invalid Operator";
    }

    console.log(result);
    return result;
}

calculator(5, 2, "+");  //7
calculator(5, 2, "&");  //Invalid Operator
```

## 内置对象

### Math

`console.log(Math);` 可以打印出 `Math` 对象，查看它的属性和函数。

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
