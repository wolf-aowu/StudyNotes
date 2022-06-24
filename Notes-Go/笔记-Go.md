### 官方网站

官方网站（可能需要翻墙）

https://go.dev/

翻墙连接（要钱的）

下载链接（推荐使用浏览器访问）：https://bitbucket.org/letsgogo/letsgogo/src/master/

备用链接（推荐使用浏览器访问）：https://github.com/LetsGo666/LetsGo_2

安装后打开填写我的ID：179796047 你能多得3天会员！（好像得先买会员）

官方教程地址

https://go.dev/tour/welcome/1

中文网站

https://studygolang.com/

官方标准库中文版

https://go-zh.org/pkg/

https://studygolang.com/pkgdoc

### 注意事项

1. 每个语句后不需要分号（Go 语言会在每行后自动加分号）

2. Go 编译器是一行行进行编译的，所以每一行只能写一条语句，否则会报错

3. Go 语言定义的变量 或者 import 的包 如果没有使用到，会报错

4. 有 main 方法的文件 package 必须是 main

5. 一个文件夹下只能有一个 main 方法

6. Go 语言不允许 `{}` 的前一个括号换行

   不正确的写法：

   ```go
   func main()
   {
   	;
   }
   ```

   正确的写法：

   ```go
   func main() {
   	;
   }
   ```

7. 一行尽量不要超过 80 个字符

### 基础语法

#### 导入

有两种写法

写法一

```go
import "fmt"
import "math"
```

写法二

```go
import (
	"fmt"
	"math"
)
```

#### 导出名

在 Go 中，如果一个名字以大写字母开头，那么它就是已导出的。例如，`Pizza` 就是个已导出名，`Pi` 也同样，它导出自 `math` 包。

`pizza` 和 `pi` 并未以大写字母开头，所以它们是未导出的。

在导入一个包时，你只能引用其中已导出的名字。任何“未导出”的名字在该包外均无法访问。

与 C# 中的访问修饰符相似

#### 函数

```go
func 函数名(形参名 形参类型, ...) 返回类型 {
	函数体
}
```

函数可以没有参数或接受多个参数。

在本例中，`add` 接受两个 `int` 类型的参数。

注意类型在变量名 **之后**。（参考 [这篇关于 Go 语法声明的文章](http://blog.go-zh.org/gos-declaration-syntax)了解这种类型声明形式出现的原因。）

```go
func add(x int, y int) int {
	return x + y
}
```

当连续两个或多个函数的已命名形参类型相同时，除最后一个类型以外，其它都可以省略。

```go
func add(x,y int) int {
	return x + y
}
```

函数可以返回任意数量的返回值。

```go
func swap(x,y string) (string,string) {
	return y,x
}
```

Go 的返回值可被命名，它们会被视作定义在函数顶部的变量。

返回值的名称应当具有一定的意义，它可以作为文档使用。

没有参数的 `return` 语句返回已命名的返回值。也就是 `直接` 返回。

直接返回语句应当仅用在下面这样的短函数中。在长的函数中它们会影响代码的可读性

```go
func split(sum int) (x, y int) {
	x = sum * 4 / 9
	y = sum - x
	return
}
```

#### 变量

`var` 语句用于声明变量，跟函数的参数一样，类型在最后。

```go
var i int
var i, j int
```

变量声明可以包含初始值，每个变量对应一个。

```go
var i, j int = 1, 2
```

如果初始化值已存在，则可以省略类型；变量会从初始值中获得类型。

```go
var c, python = true, "no"
```

在函数中，简洁赋值语句 `:=` 可在类型明确的地方代替 `var` 声明。

函数外的每个语句都必须以关键字开始（`var`, `func` 等等），因此 `:=` 结构不能在函数外使用。所以，`var` 一般用来声明全局变量，函数内部使用 `:=` 初始化变量

```go
k := 3
c, python, java := true, false, "no"
```

多个全局变量

```go
var (
	i = 1
	k = 3
    python = false
    java = "no"
)
```

#### 常量

常量的声明与变量类似，只不过是使用 `const` 关键字。

常量可以是字符、字符串、布尔值或数值。

常量不能用 `:=` 语法声明。

```go
const Pi = 3.14
```

数值常量是高精度的 **值**。

一个未指定类型的常量由上下文来决定其类型。

```go
package main

import "fmt"

const (
	// 将 1 左移 100 位来创建一个非常大的数字
	// 即这个数的二进制是 1 后面跟着 100 个 0
	Big = 1 << 100
	// 再往右移 99 位，即 Small = 1 << 1，或者说 Small = 2
	Small = Big >> 99
)

func needInt(x int) int { return x*10 + 1 }
func needFloat(x float64) float64 {
	return x * 0.1
}

func main() {
	fmt.Println(needInt(Small))
	fmt.Println(needFloat(Small))
	fmt.Println(needFloat(Big))
}
```

#### 基本类型

1. bool

   默认值：false

2. string

   默认值：""

3. int

   int8 能表示 $-128$ ~ $127$

   int16 能表示 $-2^{15}$ ~ $2^{15} - 1$

   int32 能表示 $-2^{31}$ ~ $2^{31} - 1$

   int64 能表示 $-2^{63}$ ~ $2^{63} - 1$

4. uint uint8 uint16 uint32 uint64 uintptr

5. byte

   uint8 的别名

6. rune

   int32 的别名，表示一个 Unicode 码点

7. float32 float64

8. complex64 complex128

本例展示了几种类型的变量。 同导入语句一样，变量声明也可以“分组”成一个语法块。

`int`, `uint` 和 `uintptr` 在 32 位系统上通常为 32 位宽，在 64 位系统上则为 64 位宽。 当你需要一个整数值时应使用 `int` 类型，除非你有特殊的理由使用固定大小或无符号的整数类型。

#### 类型转换

表达式 `T(v)` 将值 `v` 转换为类型 `T`。

```go
var i int = 42
var f float64 = float64(i)
var u uint = uint(f)
```

或者

```go
i := 42
f := float64(i)
u := uint(f)
```

与 C 不同的是，Go 在不同类型的项之间赋值时需要<font color = skyblue>显式转换</font>。

在声明一个变量而不指定其类型时（即使用不带类型的 `:=` 语法或 `var =` 表达式语法），变量的类型由右值推导得出。

当右值声明了类型时，新变量的类型与其相同：

```go
var i int
j := i // j 也是一个 int
```

不过当右边包含未指明类型的数值常量时，新变量的类型就可能是 `int`, `float64` 或 `complex128` 了，这取决于常量的精度：

```go
i := 42           // int
f := 3.142        // float64
g := 0.867 + 0.5i // complex128
```

#### 循环

Go 只有一种循环结构：`for` 循环。

**注意**：和 C、Java、JavaScript 之类的语言不同，Go 的 for 语句后面的三个构成部分外没有小括号， 大括号 `{ }` 则是必须的。

```go
for i := 0; i < 10; i++ {
	sum += i
}
```

初始化语句和后置语句是可选的。

```go
for ; sum < 1000; {
	sum += sum
}
```

Go 中的 "while"，此时可以去掉分号

```go
for sum < 1000 {
	sum += sum
}
```

Go 中的无限循环

如果省略循环条件，该循环就不会结束。

```go
for {
}
```

#### 判断语句

```go
if x < 0 {
	判断后要执行的语句
} else {
    判断后要执行的语句
}
```

`if` 语句可以在条件表达式前执行一个简单的语句

```go
if v := math.Pow(x, n); v < lim {
	判断后要执行的语句
}
```

#### switch

`switch` 是编写一连串 `if - else` 语句的简便方法。它运行第一个值等于条件表达式的 case 语句。

Go 的 switch 语句类似于 C、C++、Java、JavaScript 和 PHP 中的，不过 Go 只运行选定的 case，而非之后所有的 case。 实际上，Go 自动提供了在这些语言中每个 case 后面所需的 `break` 语句。 除非以 `fallthrough` 语句结束，否则分支会自动终止。 Go 的另一点重要的不同在于 switch 的 case 无需为常量，且取值不必为整数。

switch 的 case 语句从上到下顺次执行，直到匹配成功时停止。

```go
switch os := runtime.GOOS; os {
case "darwin":
	fmt.Println("OS X.")
case "linux":
	fmt.Println("Linux.")
default:
    // freebsd, openbsd,
    // plan9, windows...
    fmt.Printf("%s.\n", os)
}
```

没有条件的 switch 同 `switch true` 一样。

```go
switch {
case 13 < 12:
	fmt.Println("Good morning!")
case 13 < 17:
	fmt.Println("Good afternoon.")
default:
    fmt.Println("Good evening.")
}
```

结果：

```go
Good afternoon.
```

#### 推迟语句 defer

defer 语句会将函数推迟到外层函数返回之后执行。

推迟调用的函数其参数会立即求值，但直到外层函数返回前该函数都不会被调用。

<font color = cyan>这句话的意思应该是：当程序执行到有 defer 的语句时，如果函数需要传入参数，则将此时的参数的值传入。但是函数不会被执行，也就是函数内非参数变量不会被传入。直到外层函数内所有语句都执行完成，此时会按照函数内部语句顺序掺入非参数变量。具体可以参考例一和例二的对比。</font>

```go
package main

import "fmt"

var a int = 0

func main() {
	defer fmt.Println("world")

	fmt.Println("hello")

	defer add()
	fmt.Println(a)
}

func add() {
	a := 1 + 2
	fmt.Println("add", a)
}
```

结果：

```go
hello
0
add 3
world
```

推迟的函数调用会被压入一个栈中。当外层函数返回时，被推迟的函数会按照后进先出的顺序调用。

更多关于 defer 语句的信息，请阅读[此博文](http://blog.go-zh.org/defer-panic-and-recover)。

```go
package main

import "fmt"

func main() {
	fmt.Println("counting")

	for i := 0; i < 10; i++ {
		defer fmt.Println(i)
	}

	fmt.Println("done")
}
```

##### 例子

例一：

```go
package main

import "fmt"

var a, b int = 0, 1

func main() {
	defer Add(a, b, "1")
	a = a + 1
	defer Add(a, b, "2")
}

func Add(x int, y int, tag string) {
	fmt.Println(x, y, tag)
	res := x + y
	fmt.Println(res)
}
```

结果：

```go
1 1 2
2
0 1 1
1
```

例二：

```go
package main

import "fmt"

var a, b int = 0, 1

func main() {
	defer Add("1")
	a = a + 1
	defer Add("2")
}

func Add(tag string) {
	fmt.Println(a, b, tag)
	res := a + b
	fmt.Println(res)
}
```

结果：

```go
1 1 2
2
1 1 1
2
```

##### 博文翻译

A **defer statement** pushes a function call onto a list. The list of saved calls is executed after the surrounding function returns. Defer is commonly used to simplify functions that perform various clean-up actions.

defer 语句将一个函数调用推到一个列表中。被保存的调用列表在周围的函数返回后被执行。defer通常被用来简化执行各种清理动作的函数。

For example, let's look at a function that opens two files and copies the contents of one file to the other:

例如，让我们看看一个打开两个文件并将一个文件的内容复制到另一个文件的函数。

```go
func CopyFile(dstName, srcName string) (written int64, err error) {
    src, err := os.Open(srcName)
    if err != nil {
        return
    }

    dst, err := os.Create(dstName)
    if err != nil {
        return
    }

    written, err = io.Copy(dst, src)
    dst.Close()
    src.Close()
    return
}
```

This works, but there is a bug. If the call to os.Create fails, the function will return without closing the source file. This can be easily remedied by putting a call to src.Close before the second return statement, but if the function were more complex the problem might not be so easily noticed and resolved. By introducing defer statements we can ensure that the files are always closed:

这可以工作，但有一个错误。如果对 `os.Create` 的调用失败，该函数将在没有关闭源文件的情况下返回。这可以通过在第二个返回语句之前调用  `src.Close` 来轻松解决，但如果这个函数更复杂，问题可能就不会那么容易被注意和解决了。通过引入 defer 语句，我们可以确保文件始终被关闭。

```go
func CopyFile(dstName, srcName string) (written int64, err error) {
    src, err := os.Open(srcName)
    if err != nil {
        return
    }
    defer src.Close()

    dst, err := os.Create(dstName)
    if err != nil {
        return
    }
    defer dst.Close()

    return io.Copy(dst, src)
}
```

Defer statements allow us to think about closing each file right after opening it, guaranteeing that, regardless of the number of return statements in the function, the files will be closed.

defer 语句允许我们在打开每个文件后立即考虑关闭它，保证无论函数中有多少条返回语句，文件都会被关闭。

The behavior of defer statements is straightforward and predictable. There are three simple rules:

defer 语句的行为是直截了当和可预测的。有三个简单的规则：

1. A deferred function's arguments are evaluated when the defer statement is evaluated.

   推迟函数的参数在推迟语句被评估时被传入。

   In this example, the expression "i" is evaluated when the Println call is deferred. The deferred call will print "0" after the function returns.

   在这个例子中，表达式 "i" 在推迟调用 Println 时被传入。在外层函数返回时，推迟函数被执行，打印 "0"。

   ```go
   func a() {
       i := 0
       defer fmt.Println(i)
       i++
       return
   }
   ```

   结果：

   ```
   0
   ```

2. Deferred function calls are executed in Last In First Out order after the surrounding function returns.

   外层函数返回时，推迟函数的调用是按照后进先出的顺序执行。

   This function prints "3210":

   这个函数打印 "3210"。

   ```go
   func b() {
       for i := 0; i < 4; i++ {
           defer fmt.Print(i)
       }
   }
   ```
   
3. Deferred functions may read and assign to the returning function's named return values.

   推迟函数可以读取和赋值给返回函数的命名返回值。

   In this example, a deferred function increments the return value i after the surrounding function returns. Thus, this function returns 2:

   在这个例子中，一个推迟函数在外层函数返回时增加了返回值 i。因此，这个函数返回 2。

   ```
   func c() (i int) {
       defer func() { i++ }()
       return 1
   }
   ```

   <font color = skyblue>返回的是 i 的值，原因请参考知识点：函数返回值起名</font>

This is convenient for modifying the error return value of a function; we will see an example of this shortly.

这对于修改一个函数的错误返回值是很方便的；我们很快就会看到这样一个例子。（<font color = "grass">从此处开始不理解</font>）

**Panic** is a built-in function that stops the ordinary flow of control and begins *panicking*. When the function F calls panic, execution of F stops, any deferred functions in F are executed normally, and then F returns to its caller. To the caller, F then behaves like a call to panic. The process continues up the stack until all functions in the current goroutine have returned, at which point the program crashes. Panics can be initiated by invoking panic directly. They can also be caused by runtime errors, such as out-of-bounds array accesses.

**Panic** 是一个内置函数，它可以停止普通的控制流并开始 *panicking*。当函数F 调用 panic 时，F 的执行会停止，F 中的任何推迟函数都会正常执行，然后F 会返回给它的调用者。对于调用者来说，F 的行为就像对 panic 的调用。这个过程继续在堆栈中进行，直到当前 goroutine 中的所有函数都返回，这时程序就会崩溃。Panics 可以通过直接调用 panic 来启动。它们也可以由运行时错误引起，如越界数组访问。

**Recover** is a built-in function that regains control of a panicking goroutine. Recover is only useful inside deferred functions. During normal execution, a call to recover will return nil and have no other effect. If the current goroutine is panicking, a call to recover will capture the value given to panic and resume normal execution.

**Recover** 是一个内置的函数，可以重新获得对一个 panicking 的 goroutine 的控制。恢复只在推迟函数中有用。在正常执行过程中，对 recover 的调用将返回 nil，没有其他影响。如果当前的 goroutine 处于 panicking 状态，对 recover 的调用将捕获给定的 panic 值并恢复正常执行。

Here's an example program that demonstrates the mechanics of panic and defer:

这里有一个示范程序，演示了 panic 和推迟的机制。

```go
package main

import "fmt"

func main() {
    f()
    fmt.Println("Returned normally from f.")
}

func f() {
    defer func() {
        if r := recover(); r != nil {
            fmt.Println("Recovered in f", r)
        }
    }()
    fmt.Println("Calling g.")
    g(0)
    fmt.Println("Returned normally from g.")
}

func g(i int) {
    if i > 3 {
        fmt.Println("Panicking!")
        panic(fmt.Sprintf("%v", i))
    }
    defer fmt.Println("Defer in g", i)
    fmt.Println("Printing in g", i)
    g(i + 1)
}
```

The function g takes the int i, and panics if i is greater than 3, or else it calls itself with the argument i+1. The function f defers a function that calls recover and prints the recovered value (if it is non-nil). Try to picture what the output of this program might be before reading on.

函数 g 接收 int i，如果 i 大于 3 就会 panic，否则就用参数 i+1 调用自己。函数 f 推迟调用 recover 的函数，并打印出恢复的值（如果它不是空的）。在继续阅读之前，请试着想象一下这个程序的输出可能是什么。

The program will output:

该程序将输出：

```go
Calling g.
Printing in g 0
Printing in g 1
Printing in g 2
Printing in g 3
Panicking!
Defer in g 3
Defer in g 2
Defer in g 1
Defer in g 0
Recovered in f 4
Returned normally from f.
```

If we remove the deferred function from f the panic is not recovered and reaches the top of the goroutine's call stack, terminating the program. This modified program will output: 

如果我们从 f 中删除推迟函数，panic 就不会恢复，并到达 goroutine 的调用堆栈顶部，终止程序。这个修改后的程序将输出：

```go
Calling g.
Printing in g 0
Printing in g 1
Printing in g 2
Printing in g 3
Panicking!
Defer in g 3
Defer in g 2
Defer in g 1
Defer in g 0
panic: 4
 
panic PC=0x2a9cd8
[stack trace omitted]
```

For a real-world example of **panic** and **recover**, see the [json package](https://golang.org/pkg/encoding/json/) from the Go standard library. It decodes JSON-encoded data with a set of recursive functions. When malformed JSON is encountered, the parser calls panic to unwind the stack to the top-level function call, which recovers from the panic and returns an appropriate error value (see the 'error' and 'unmarshal' methods of the decodeState type in [decode.go](https://golang.org/src/pkg/encoding/json/decode.go)).

关于 **panic** 和 **recover** 的实际例子，请看 Go 标准库中的 [json包](https://golang.org/pkg/encoding/json/)。它用一组递归函数对 JSON 编码的数据进行解码。当遇到畸形的 JSON 时，解析器会调用 panic 来解开堆栈，到顶层的函数调用，从 panic 中恢复，并返回一个适当的错误值（见 [decode.go](https://golang.org/src/pkg/encoding/json/decode.go) 中 decodeState 类型的 'error' 和 'unmarshal' 方法）。

The convention in the Go libraries is that even when a package uses panic internally, its external API still presents explicit error return values.

Go 库中的惯例是，即使一个包在内部使用 panic，其外部 API 仍会呈现明确的错误返回值。

Other uses of **defer** (beyond the file.Close example given earlier) include releasing a mutex:

**defer** 的其他用途（除了前面给出的 file.Close 例子之外）包括释放一个 mutex。

```go
mu.Lock()
defer mu.Unlock()
```

printing a footer:

打印一个页脚：

```go
printHeader()
defer printFooter()
```

and more.

以及更多

In summary, the defer statement (with or without panic and recover) provides an unusual and powerful mechanism for control flow. It can be used to model a number of features implemented by special-purpose structures in other programming languages. Try it out.

总之，defer 语句（无论是否有 panic 和 recover）为控制流提供了一种不寻常的强大机制。它可以用来模拟其他编程语言中由特殊目的结构实现的一些功能。试一试吧。

*Andrew Gerrand 编写*

#### 指针

Go 拥有指针。指针保存了值的内存地址。

类型 `*T` 是指向 `T` 类型值的指针。其零值为 `nil`。

```go
var p *int
```

`&` 操作符会生成一个指向其操作数的指针。

```go
i := 42
p = &i
```

`*` 操作符表示指针指向的底层值。

```go
fmt.Println(*p) // 通过指针 p 读取 i
*p = 21         // 通过指针 p 设置 i
```

这也就是通常所说的“间接引用”或“重定向”。

与 C 不同，Go 没有指针运算。

```go
i, j := 42, 2701

p := &i         // 指向 i
fmt.Println(*p) // 通过指针读取 i 的值
*p = 21         // 通过指针设置 i 的值
fmt.Println(i)  // 查看 i 的值

p = &j         // 指向 j
*p = *p / 37   // 通过指针对 j 进行除法运算
fmt.Println(j) // 查看 j 的值
```

结果：

```go
42
21
73
```

#### 结构体

一个结构体（`struct`）就是一组字段（field）。

结构体字段使用点号来访问。

```go
package main

import "fmt"

type Vertex struct {
	X int
	Y int
}

func main() {
	v := Vertex{1, 2}
	v.X = 4
	fmt.Println(v.X)
}
```

结构体文法通过直接列出字段的值来新分配一个结构体。

使用 `Name:` 语法可以仅列出部分字段。（字段名的顺序无关。）

特殊的前缀 `&` 返回一个指向结构体的指针。

```go
package main

import "fmt"

type Vertex struct {
	X, Y int
}

var (
	v1 = Vertex{1, 2}  // 创建一个 Vertex 类型的结构体
	v2 = Vertex{X: 1}  // Y:0 被隐式地赋予
	v3 = Vertex{}      // X:0 Y:0
	p  = &Vertex{1, 2} // 创建一个 *Vertex 类型的结构体（指针）
)

func main() {
	fmt.Println(v1, p, v2, v3)
}
```

结果：

```go
{1 2} &{1 2} {1 0} {0 0}
```

##### 结构体指针

结构体字段可以通过结构体指针来访问。

如果我们有一个指向结构体的指针 `p`，那么可以通过 `(*p).X` 来访问其字段 `X`。不过这么写太啰嗦了，所以语言也允许我们使用隐式间接引用，直接写 `p.X` 就可以。

```go
package main

import "fmt"

type Vertex struct {
	X int
	Y int
}

func main() {
	v := Vertex{1, 2}
	p := &v
	p.X = 1e9
	fmt.Println(v)
}
```

#### 数组

类型 `[n]T` 表示拥有 `n` 个 `T` 类型的值的数组。

表达式

```
var a [10]int
```

会将变量 `a` 声明为拥有 10 个整数的数组。

数组的长度是其类型的一部分，因此数组不能改变大小。这看起来是个限制，不过没关系，Go 提供了更加便利的方式来使用数组。

```go
var a [2]string
a[0] = "Hello"
a[1] = "World"
primes := [6]int{2, 3, 5, 7, 11, 13}
```

#### 切片

每个数组的大小都是固定的。而切片则为数组元素提供动态大小的、灵活的视角。在实践中，切片比数组更常用。

类型 `[]T` 表示一个元素类型为 `T` 的切片。

切片通过两个下标来界定，即一个上界和一个下界，二者以冒号分隔：

```go
a[low : high]
```

它会选择一个半开区间，包括第一个元素，但排除最后一个元素。

以下表达式创建了一个切片，它包含 `a` 中下标从 1 到 3 的元素：

```go
a[1:4]
```

```go
primes := [6]int{2, 3, 5, 7, 11, 13}

var s []int = primes[1:4]
fmt.Println(s)
```

结果：

```go
[3 5 7]
```

切片并不存储任何数据，它只是描述了底层数组中的一段。

更改切片的元素会修改其底层数组中对应的元素。

与它共享底层数组的切片都会观测到这些修改。

```go
names := [4]string{
    "John",
    "Paul",
    "George",
    "Ringo",
}

a := names[0:2]
b := names[1:3]
fmt.Println(a, b)
b[0] = "XXX"
fmt.Println(a, b)
fmt.Println(names)
```

结果：

```go
[John Paul] [Paul George]
[John XXX] [XXX George]
[John XXX George Ringo]
```

切片文法类似于没有长度的数组文法。

这是一个数组文法：

```
[3]bool{true, true, false}
```

下面这样则会创建一个和上面相同的数组，然后构建一个引用了它的切片：

```
[]bool{true, true, false}
```

```go
q := []int{2, 3, 5, 7, 11, 13}

r := []bool{true, false, true, true, false, true}

s := []struct {
    i int
    b bool
}{
    {2, true},
    {3, false},
    {5, true},
    {7, true},
    {11, false},
    {13, true},
}
```

结果：

```go
[2 3 5 7 11 13]
[true false true true false true]
[{2 true} {3 false} {5 true} {7 true} {11 false} {13 true}]
```

在进行切片时，你可以利用它的默认行为来忽略上下界。

切片下界的默认值为 `0`，上界则是该切片的长度。

对于数组

```go
var a [10]int
```

来说，以下切片是等价的：

```go
a[0:10]
a[:10]
a[0:]
a[:]
```

切片拥有 **长度** 和 **容量**。

切片的长度就是它所包含的元素个数。

切片的容量是从它的第一个元素开始数，到其底层数组元素末尾的个数。

切片 `s` 的长度和容量可通过表达式 `len(s)` 和 `cap(s)` 来获取。

你可以通过重新切片来扩展一个切片，给它提供足够的容量。试着修改示例程序中的切片操作，向外扩展它的容量，看看会发生什么。

```go
s := []int{2, 3, 5, 7, 11, 13}
printSlice(s)
s = s[:0] // 截取切片使其长度为 0
printSlice(s)
s = s[:4] // 拓展其长度
printSlice(s)
s = s[2:] // 舍弃前两个值
printSlice(s)

func printSlice(s []int) {
	fmt.Printf("len=%d cap=%d %v\n", len(s), cap(s), s)
}
```

结果：

```go
len=6 cap=6 [2 3 5 7 11 13]
len=0 cap=6 []
len=4 cap=6 [2 3 5 7]
len=2 cap=4 [5 7] // cap 的 4 就是指 5 7 11 13 四个数字
```

切片的零值是 `nil`。

nil 切片的长度和容量为 0 且没有底层数组。

```go
var s []int
fmt.Println(s, len(s), cap(s))
if s == nil {
    fmt.Println("nil!")
```

结果：

```go
[] 0 0
nil!
```

切片可以用内建函数 `make` 来创建，这也是你创建动态数组的方式。

`make` 函数会分配一个元素为零值的数组并返回一个引用了它的切片：

```go
a := make([]int, 5)  // len(a)=5
```

要指定它的容量，需向 `make` 传入第三个参数：

```go
b := make([]int, 0, 5) // len(b)=0, cap(b)=5

b = b[:cap(b)] // len(b)=5, cap(b)=5
b = b[1:]      // len(b)=4, cap(b)=4
```

```go
package main

import "fmt"

func main() {
	a := make([]int, 5)
	printSlice("a", a)

	b := make([]int, 0, 5)
	printSlice("b", b)
	if b == nil {
		fmt.Println("nil!")
    } else {
        fmt.Println("not nil!")
    }

	c := b[:2]
	printSlice("c", c)

	d := c[2:5]
	printSlice("d", d)
}

func printSlice(s string, x []int) {
	fmt.Printf("%s len=%d cap=%d %v\n",
		s, len(x), cap(x), x)
}
```

结果：

```go
a len=5 cap=5 [0 0 0 0 0]
b len=0 cap=5 []
not nil!
c len=2 cap=5 [0 0]
d len=3 cap=3 [0 0 0]
```

切片可包含任何类型，甚至包括其它的切片。

```go
board := [][]string{
	[]string{"_", "_", "_"},
	[]string{"_", "_", "_"},
	[]string{"_", "_", "_"},
}
```

为切片追加新的元素是种常用的操作，为此 Go 提供了内建的 `append` 函数。内建函数的[文档](https://go-zh.org/pkg/builtin/#append)对此函数有详细的介绍。

```
func append(s []T, vs ...T) []T
```

`append` 的第一个参数 `s` 是一个元素类型为 `T` 的切片，其余类型为 `T` 的值将会追加到该切片的末尾。

`append` 的结果是一个包含原切片所有元素加上新添加元素的切片。

当 `s` 的底层数组太小，不足以容纳所有给定的值时，它就会分配一个更大的数组。返回的切片会指向这个新分配的数组。

（要了解关于切片的更多内容，请阅读文章 [Go 切片：用法和本质](https://blog.go-zh.org/go-slices-usage-and-internals)。）

```go
package main

import "fmt"

func main() {
	var s []int
	printSlice(s)

	// 添加一个空切片
	s = append(s, 0)
	printSlice(s)

	// 这个切片会按需增长
	s = append(s, 1)
	printSlice(s)

	// 可以一次性添加多个元素
	s = append(s, 2, 3, 4)
	printSlice(s)
}

func printSlice(s []int) {
	fmt.Printf("len=%d cap=%d %v\n", len(s), cap(s), s)
}
```

结果：(<font color = grass>此处没有看懂：为什么最后一条 cap = 6</font>)

```go
len=0 cap=0 []
len=1 cap=1 [0]
len=2 cap=2 [0 1]
len=5 cap=6 [0 1 2 3 4]
```

