### 官方网站

官方网站（可能需要翻墙）

https://go.dev/

官方教程地址

https://go.dev/tour/welcome/1

中文网站

https://studygolang.com/

官方标准库中文版

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

3. int  int8  int16  int32  int64

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
