# Lua 基础

官方网址：http://www.lua.org/

## 与 C# 的不同

lua 像 Python 一样，代码是从上到下一次执行的。

lua 中末尾可以不用写分号。

lua 中所有的变量声明都不需要声明变量类型，它会自动判断类型。

lua 中的变量可以赋值不同的数据类型。

lua 中使用没有声明过的变量不会报错，默认值为 nil。

lua 中没有自增自减，也没有 `+=`、`-=`、`*=`、`/=`、`%=`。

lua 中`~=` 代表不等于，`!=` 不是不等于。

lua 中不支持位运算符和三目运算符，但有第三方的库。

lua 中没有 switch。

lua 中索引从 1 开始。

## 注释

### 单行注释

```lua
--单行注释
```

### 多行注释

有三种：

```lua
--[[
多行注释
]]

--[[
多行注释
]]--

--[[
多行注释
--]]
```

## 数据类型

### nil

空，类似 C# 中的 null。没有声明过的变量的值都为 nil。

### number

所有数值都是 number

```lua
a = 1
a = 1.2
```

### string

使用单引号或者双引号包裹

```lua
a = '123'
a = "123"
```

### boolean

true 和 false

### function

有两种写法：

```lua
--函数声明
function 函数名(参数名)
    return 返回值1, 返回值2
end
--函数调用，函数调用不可以在函数声明之前
返回值1, 返回值2 = 函数名(参数)

--函数声明
变量名 = function()
end
--函数调用
变量名()
```

<font color=skyblue>如果声明了参数，但是调用时未传入，则该参数为 nil。如果传入的参数个数大于声明的参数个数，则会直接丢弃多的参数。如果接收返回值的变量个数不足，则会自动丢弃多出的返回值。如果接收返回值的变量多出，则多出的变量为 nil。</font>

函数其实是一种类型。

```lua
F5 = function()
	print("123")
end
print(type(F5))  --function
```

<font color = skyblue>不支持重载。默认调用最后一个声明的函数。</font>

#### 变长参数

```lua
--...代表变长参数
function F7(...)
    --变长参数需要用一个表存起来
    arg = { ... }
    for i = 1, #arg do
        print(arg[i])
    end
end

--支持不同数据类型作为参数
F7(2, "123", true, 4)
```

#### 嵌套函数

``` lua
function F8()
    F9 = function()
        print(123)
    end
    return F9
end
f9 = F8()

function F8()
    --不能取函数名
    return function()
        print(123)
    end
end

--闭包
function F9(x)
    return function(y)
        return x + y
    end
end
--[[
f10 中存储着函数的地址：
function(y)
	return x + y
end
执行 F9(10) 时并不会调用上面这个函数，但是会将上面这个函数的地址返回。
同时由于上面这个函数使用了 x 变量，所以 F9 这个函数不会在返回上面这个函数后消失，也就形成了闭包。
f10(5) 相当于将 5 传入上面这个函数，而 x 的值来源于 f10 = F9(10) 中的 10
所以最后 f10(5) = 10 + 5 = 15
]]
f10 = F9(10)
print(f10)    --function: 00E4BF98
print(f10(5)) --15
```

#### 多返回值

如果返回值有多个，使用 `,` 分割，如果接收的变量少了，则多出部分自动省略，如果多了，则自动不空。

### table

可以将任意数据类型放入表中。索引从 1 开始。

``` lua
a = { 1, 2, 3, "123", true, nil }
--二维表
a = { { 1, 2, 3 }, { 4, 5, 6 } }
print(a[1][1])  --1

--自定义索引，不建议使用
--如果 table 中既存在自定义索引，也存在非自定义索引，非自定义索引部分均从 1 开始。
--如果自定义索引与非自定义索引相同时，以非自定义索引的值为准
a = { [0] = 1, 2, 3, [-1] = 4, 5 }
--[[
(global) a: {
    [0]: integer = 1,
    [1]: integer = 2,
    [2]: integer = 3,
    [-1]: integer = 4,
    [3]: integer = 5,
}
]]
a = { [1] = 1, 2, 3, [-1] = 4, 5 }
--[[
(global) a: {
    [-1]: integer = 4,
    [1]: integer = 1|2,
    [2]: integer = 3,
    [3]: integer = 5,
}
]]
```

#### 遍历

##### for 循环遍历

使用 for 循环即可遍历。如果遍历索引超出 table 本身的索引或者对应索引的值未定义也不会报错，得到的元素值为 nil。

```lua
a = { 1, 2, 3, "123", true, nil }
for i = 1, #a do
    print(a[i])
end

--二维表
a = { { 1, 2, 3 }, { 4, 5, 6 } }
for i = 1, #a do
    for j = 1, #a[i] do
        print(a[i][j])
    end
end
```

##### ipairs 迭代器遍历

使用 `ipairs` 迭代器遍历。只能从 1 开始找，一旦索引断开就跳出循环。

```lua
--[[
ipairs 遍历键值对：[1]=2
ipairs 遍历键值对：[2]=3
]]
a = { [1] = 1, 2, 3, [-1] = 4, [5] = 5 }

for i, k in ipairs(a) do
    print("ipairs 遍历键值对：[" .. i .. "]" .. "=" .. k)
end

--[[
没有输出
]]
a = { [2] = 2, [5] = 5 }
for i, k in ipairs(a) do
    print("ipairs 遍历键值对：[" .. i .. "]" .. "=" .. k)
end
```

##### pairs 迭代器遍历

使用 `pairs` 迭代器遍历，可以遍历所有的元素。

```lua
--[[
ipairs 遍历键值对：[1]=2
ipairs 遍历键值对：[2]=3
ipairs 遍历键值对：[5]=5
ipairs 遍历键值对：[-1]=4
]]
a = { [1] = 1, 2, 3, [-1] = 4, [5] = 5 }

for i, k in pairs(a) do
    print("ipairs 遍历键值对：[" .. i .. "]" .. "=" .. k)
end

--[[
ipairs 遍历键值对：[2]=2
ipairs 遍历键值对：[5]=5
]]
a = { [2] = 2, [5] = 5 }
for i, k in pairs(a) do
    print("ipairs 遍历键值对：[" .. i .. "]" .. "=" .. k)
end
```

#### table 长度

当 table 中不存在 nil 时可以通过 `#` 获取 table 的长度。否则不稳定。

```lua
a = { 1, 2, 3, "123", true, nil }
print(#a) --5
a = { 1, 2, nil, 3, "123", true, nil }
print(#a) --2
a = { 1, 2, nil, 3, "123", true }
print(#a) --6
```

#### 字典

```lua
a = { ["name"] = "tangnade", ["age"] = 41, ["hp"] = 100 }
print(a["name"]) --tangnade
--只有字符串的键才可以以成员变量的形势得到值
print(a.name)    --tangnade
--直接赋值即可新增
a["exp"] = 1000
--遍历使用 pairs 遍历
```

#### 类

lua 中默认没有面向对象，需要自己来实现。

```lua
Student = {
    --成员变量
    age = 1,
    sex = true,
    --成员函数
    Up = function()
        print("成长函数")
        --此处 age 为全局变量
        print(age)         --nil
        --想要在表中调用表的属性或方法一定要指定是谁的
        print(Student.age) --1
    end,
    Learn = function(t)
        print(t.age)
    end
}

--成员函数的调用
Student.Up()
Student.Learn(Student)
--也可以写成下面这种，: 调用会默认把调用者作为第一个参数传入
Student:Learn()

--添加成员变量或函数
Student.name = "zhangsan"
Student.Speak = function()
    print("说话")
end
--或者
function Student.Take()
    print("拿起")
end

--或者
function Student:Talk()
    --self 表示默认传入的第一个参数
    print(self.name .. " Talk")
end

Student:Talk()
--与上面一条语句等价
Student.Talk(Student)
```

#### 表的插入

``` lua
--将 t2 表插入 t1 中
t1 = { { age = 1, name = "123" }, { age = 2, name = "345" } }
t2 = { name = "678" }
table.insert(t1, t2)
for k, v in pairs(t1) do
    for k2, v2 in pairs(v) do
        print(k2, v2)
    end
end

t1 = { 1, 2 }
t2 = { 3 }
table.insert(t1, t2)
for k, v in pairs(t1) do
    print(k, v)
end
```

输出：

``` lua
age	1
name	123
age	2
name	345
name	678

1	1
2	2
3	table: 00E89A88
```

#### 删除指定元素

```lua
t1 = { { age = 1, name = "123" }, { age = 2, name = "345" } }
--移除最后一个元素
table.remove(t1)
--移出指定索引的元素
table.remove(t1, 1)
```

#### 排序

```lua
t1 = {5, 2, 7, 9, 5}
--默认升序排序
table.sort(t1)
--降序排序
table.sort(t1, function(a, b)
    if a > b then
        return true
    end
end)
```

#### 拼接

将表中的元素以字符串的形式拼接在一起，可以自定义分隔符。默认连接符为空字符串

```lua
t1 = { "123", "456", "789", "10101" }
str = table.concat(t1, ",") --123,456,789,10101
```

#### 大 G 表

`_G` 是一个总表，它将声明的所有全局变量都存储其中，但不会存储局部变量。

### userdata

### thread

#### 状态

协程有三种状态：dead（结束）、suspended（暂停）、running（进行中）。使用 `coroutine.status()` 获取协程的状态。当协程挂起时，协程状态为暂停；当协程执行完成时，协程状态为结束；当协程内部执行时，状态为进行中。

#### 创建

```lua
fun = function()
    print(123)
end
--协程的本事是一个线程对象
co1 = coroutine.create(fun)
print(co1) --thread: 00E6C98
--返回一个函数
co2 = coroutine.wrap(fun)
print(co2) --function: 00E67EC0
```

#### 执行

```lua
--通过 create 创建的协程
coroutine.resume(co1)
--通过 wrap 创建的协程，因为它返回的是一个函数，所以可以用函数的方式调用
co2()
```

#### 挂起

```lua
fun = function()
    local i = 1
    while true do
        print(i)
        i = i + 1
        --挂起协程，会 i 将作为返回值返回
        coroutine.yield(i)
    end
end

--这种方法的创建协程，第一个返回值是协程是否启动成功，第二个将 i 作为返回值返回
co1 = coroutine.create(fun)
--只有每次是用 resume 执行才会执行下一次
coroutine.resume(co) --1
coroutine.resume(co) --2

--这种方法的创建协程有返回值，但是没有协程是否启动成功的返回值了
co2 = coroutine.wrap(fun)
co2()
co2()
```

#### 协程号

`coroutine.running()` 能够获取当前正在执行的协程号。

### 获取数据类型

``` lua
a = nil
print(type(a))
--type 函数返回值的数据类型是 string
print(type(type(a)))
```

## 字符串

### 字符串长度

英文字符占 1 个长度，中文字符占 3 个长度，使用 `#` 获取字符串长度。

``` lua
s = "abcd字符串"
print(#s)
```

### 多行打印

使用 `[[]]`。

```lua
s = [[
多行
打印
]]
print(s)
```

### 字符串拼接

使用 `..`。无论什么数据类型都可以自动转换为字符串进行拼接。

```lua
print("123" .. "456")
```

使用 `string.format` 拼接。

```lua
--转义码添加参数的顺序：%[指定参数][标示符][宽度][.精度]指示符
--%c 接收一个数字，并将其转化为 ASCII 码表中对应的字符
print(string.format("%c", 65))   --A
--%d、%i 接收一个数字，并将其转化为有符号的证书格式
print(string.format("%d", -666)) ---666
print(string.format("%i", -666)) ---666
--%e、%E 接收一个数字，并将其转化为科学计数法格式
print(string.format("%e", -666)) ---6.660000e+002
print(string.format("%E", -666)) ---6.660000E+002
--%f 接收一个数字，并将其转化为浮点数格式
print(string.format("%f", -666)) ---666.000000
--%g、%G 接收一个数字，并将其转化为 %e、%E 和 %f 中较短的一种格式
print(string.format("%g", -666)) ---666
print(string.format("%g", -666)) ---666
--%o 接收一个数字，并将其转化为八进制格式
print(string.format("%o", 10))   --12
--%x、%X 接收一个数字，并将其转化为十六进制格式
print(string.format("%x", 17))   --11
--%q 接收一个字符串，并将其转化为可安全被 Lua 编译器读入的格式
print(string.format("%q", 'Hello \n "wrold"!'))
--[[
"Hello \
 \"wrold\"!"
]]
--%s 接收一个字符串，并按照给定参数格式化参数
print(string.format("Hello %s!", "wrold")) --Hello wrold!
--%u 接收一个数字，并将其转化为无符号整数格式
print(string.format("%u", -666))           --4294966630
--+，使正数显示正号
print(string.format("%+d", 666))           --+666
--0，指定字符串宽度时的占位符，默认为空格
print(string.format("%5d", 666))           --  666
print(string.format("%05d", 666))          --00666
---，指定字符串宽度时的对齐方式，默认为右对齐，增加 - 改为左对齐
print(string.format("%5d", 666))           --  666
print(string.format("%-5d", 666))          --666
--.，转义码为 %f 时，保留 n 为小数，转义码为 %s 时，显示前 n 位
print(string.format("%f", 6.66))           --6.660000
print(string.format("%.1f", 6.65))         --6.7
print(string.format("%.1f", 6.64))         --6.6
print(string.format("%s", 666))            --666
print(string.format("%.2s", 666))          --66
--%%，输出 %
print(string.format("%d%%", 50))           --50%
```

### 转字符串

使用 `tostring` 函数

```lua
a = true
tostring(a)
```

### 大小写转换

返回都是一个新的字符串，不会改变原字符串

```lua
str = "abCdefg"
--转大写
print(string.upper(str))
--转小写
print(string.lower(str))
```

### 反转字符串

返回是一个新的字符串，不会改变原字符串

```lua
str = "abCdefg"
print(string.reverse(str))
```

### 字符串索引查找

使用 `string.find`，返回找到的第一个匹配字符串的起始位置和结束位置，没有找到则返回 nil。字符串索引从 1 开始。

```lua
str = "abCdefg"
print(string.find(str, "Cde")) --3	5
str = "abCdeCde"
print(string.find(str, "Cde")) --3	5
str = "abc"
print(string.find(str, "Cde")) --nil
```

### 截取字符串

```lua
str = "abCdefg"
print(string.sub(str, 3))    --Cdefg
print(string.sub(str, 3, 5)) --Cde
```

### 字符串重复

```lua
str = "abCdefg"
print(string.rep(str, 2))
```

### 字符串替换

最后一个参数代表替换前 n 个，返回替换后的新字符串和替换的次数。

```lua
str = "abCdefgCdeCd"
print(string.gsub(str, "Cd", "**"))    --ab**efg**e**	3
print(string.gsub(str, "Cd", "**", 2)) --ab**efg**eCd	2
print(string.gsub(66676, 66, "**"))    --**676	1
```

### 字符转 ASCII 码

``` lua
str = "abCdefgCdeCd"
print(string.byte(str, 1, 3)) --97	98	67
print(string.byte(str, 2))    --98
print(string.byte(str))       --97
```

### ASCII 码转字符

```lua
print(string.char(97, 98))  --ab
```

## 运算符

### 算数运算符

`+`、`-`、`*`、`/`、`%` 都与 C# 相同。没有自增自减，也没有 `+=`、`-=`、`*=`、`/=`、`%=`。

字符串与数字运算也可以计算。

```lua
print("124.3" + 1)  --125.3
```

`^` 幂运算

```lua
print(2 ^ 2)  --4
```

### 条件运算符

`>`、`<`、`>=`、`<=`、`==` 都与 C# 相同，<font color = skyblue>`~=` 代表不等于，`!=` 不是不等于。</font>

### 逻辑运算符

`and` 代表与，`or` 代表或，`not` 代表非。任何东西都可以用来连接，只有 nil 和 false 认为是假，其它按最后一个判断的原值返回。

```lua
print(1 and 2)     --2
print(0 and 1)     --1
print(true and 3)  --3
--短路原则
print(nil and 1)   --nil
print(false and 2) --false

print(false or 1)  --1
print(nil or 2)    --2
--短路原则
print(true or 1)   --true
print(0 or nil)    --0
```

#### 实现类似于三目运算符的功能

```lua
x = 1
y = 2
res = (x > y) and x or y
```

## 全局变量与局部变量

lua 中不加 local 关键字的变量都是全局变量，即使在分支语句、循环、函数中创建的变量都是全局变量。所以，局部变量前面必须要加 local。但是循环中创建递增的变量是局部变量。

在全局中使用 local 声明变量代表在其它脚本中不能调用这个变量。

``` lua
for i = 1, 3 do
    a = "Hello world"
end
print("a", a) --a	Hello world
print(i)      --nil

for i = 1, 3 do
    local b = "Hello world"
    print(b)  --Hello world
end
print("b", b) --b	nil

fun = function()
    local c = "Hello world"
end
print("c", c) --c	nil
```

## 多变量赋值

```lua
a, b = 1, 2
print(a) --1
print(b) --2
--如果后面的值不够，会自动补 nil
a, b = 1
print(a) --1
print(b) --nil
--如果后面的值多了，会自动省略
a, b = 1, 2, 3
print(a) --1
print(b) --2
```

## 条件分支语句

`if ... then ... elseif ... then ... else ... end`

```lua
if a > 5 then
	print("if")
elseif a == 9 then
	print("elseif")
else
	print("else")
end
```

## 循环语句

### while ... do

```lua
while num < 5 do
	print(num)
	num = num + 1
end
```

### repeat ... until

类似于 C# 中的 `do ... while` 语句

```lua
repeat
	print(num)
	num = num + 1
until num > 5
```

### for ... do

```lua
--i 默认递增 +1
for i = 1, 5 do
	print(i)
end

--第三个参数代表递增步数，如果想递减，使用负数即可
for i = 1, 5, 2 do
    print(i)
end
```

## 多脚本执行

使用 `require(脚本名字字符串)` 执行脚本。执行后不会再次执行。可以通过 `package.loaded[脚本名字字符串]` 获取脚本是否被执行过，还可以通过为它赋值为 nil，使脚本可以再次通过 require 执行。

对于脚本中的局部变量，也可以在脚本最后使用 return 返回局部变量，在其他脚本中使用一个变量接收 require 返回的值。
