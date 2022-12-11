# Python 基础

## 字符集

编码：将字符转换为二进制码的过程。

解码：将二进制码转换为字符的过程。

字符集：编码和解码时所采用的规则。

常见字符集：

1. ASCII

   美国人的编码，使用 7 位来对美国常用的字符进行编码。

   包含 128 个字符

2. ISO-8859-1

   欧洲的编码，使用 8 位

   包含 256 个字符

3. GB2312

   国标码，中国的编码，但只包含了常用的中文

4. GBK

   国标码，中国的编码，但只包含了常用的中文

5. Unicode

   万国码，包含世界上所有语言和符号

   Unicode 编码有多种实现：UTF-8、UTF-16、UTF-32

   UTF-8：使用 1 到 5 个字节表示字符，编程时常用

   UTF-16：使用 2 到 4 个字节表示字符

   UTF-32：统一使用 4 个字节表示字符

如果出现乱码，需要去检查字符集是否正确。

## 注释

### 文档字符串

使用文档字符串的函数，可以使用 `help()` 方法查看说明。用 `"""` 表示。一般写在函数的第一行。

函数中的入参和返回值时没有类型限制的，但函数中代码可能会对类型进行限制。为了避免以后忘记这些限制，可以在入参的后面使用 `: 参数类型` 进行标记，<font color = skyblue>此处设定的参数类型并不真正作用于参数，只是起到提示作用。</font>返回值的标记只需要在函数头的末尾的 `:` 前面加上 `-> 参数类型`即可。

例如：

```
def resource_path(relative_path: str) -> str:
    """由于 python 程序打包后生成 exe 可执行文件会改变数据目录，
    判断是否为打包程序启动，生成相应绝对路径

    Args:
        relative_path (str): 相对路径

    Returns:
        str: 绝对路径
    """
    # 判断是否为打包后的程序启动
    # 打包后的程序启动
    if getattr(sys, 'frozen', False):
        # C 盘下运行进程后的临时目录
        base_path = sys._MEIPASS
    # 非打包
    else:
        base_path = os.path.abspath(".")
    return os.path.join(base_path, relative_path)
```

使用 `help(resource_path)`：

```python
Help on function resource_path in module __main__:

resource_path(relative_path: str) -> str
    由于 python 程序打包后生成 exe 可执行文件会改变数据目录，
    判断是否为打包程序启动，生成相应绝对路径
    
    Args:
        relative_path (str): 相对路径
    
    Returns:
        str: 绝对路径
```

## 函数形参的排序方法

位置参数 -> 关键字参数 -> `*` -> `**`

## 装包

### 作为变量

在变量前加上 `*` 可以接收任意多个值，会将这些值保存为一个列表。

```python
a, *b, c = (1, 2, 3, 4, 5)
print(f'a={a}')
print(f'b={b}')
print(f'c={c}')
print(f'b_type={type(b)}')
```

输出：

```python
a=1
b=[2, 3, 4]
c=5
b_type=<class 'list'>
```

### 函数中接收位置参数

在形参前加上 `*` 可以接收任意多个值，会将这些值保存为一个元组。

``` python
def fn(*a):
    print(f'a={a}')
    print(f'a_type={type(a)}')

fn(1, 2, 3, 4, 5)
```

输出：

```python
a=(1, 2, 3, 4, 5)
a_type=<class 'tuple'>
```

作为形参有以下规则：

1. 只能有一个

2. 可以与其他参数配合使用，当它后面有其他参数时，后面的参数必须以关键字参数进行传递。

   ```python
   def fn(a, *b, c):
       print(f'a={a}')
       print(f'b={b}')
       print(f'c={c}')
   
   fn(1, 2, 3, 4, 5)
   ```

   输出：

   ```python
   # 报错
   line 6, in <module> 
       fn(1, 2, 3, 4, 5)
   TypeError: fn() missing 1 required keyword-only argument: 'c'
   ```

   在调用函数时，后面的参数 c 必须以关键字参数进行传递：

   ```python
   def fn(a, *b, c):
       print(f'a={a}')
       print(f'b={b}')
       print(f'c={c}')
   
   fn(1, 2, 3, 4, c=5)
   ```

   输出：

   ```python
   a=1
   b=(2, 3, 4)
   c=5
   ```

3. 如果在入参的开头只写一个 `*` ，则要求所有的参数必须以关键字参数传递：

   ```python
   def fn(*, a, b, c):
       print(f'a={a}')
       print(f'b={b}')
       print(f'c={c}')
   
   fn(a=3, b=4, c=5)
   ```

   输出：

   ```python
   a=3
   b=4
   c=5
   ```

4. 只能怪接收位置参数，不能接收关键字参数

   ```python
   def fn(*a):
       print(f'a={a}')
   
   fn(a=3)
   ```

   输出：

   ```python
   # 报错
   line 4, in <module> 
       fn(a=3)
   TypeError: fn() got an unexpected keyword argument 'a'
   ```

   使用位置参数传递：

   ```python
   def fn(*a):
       print(f'a={a}')
   
   fn(3)
   ```

   输出：

   ```python
   a=(3,)
   ```

### 函数中接收关键字参数

在形参前加 `**`。

```python
def fn(**a):
    print(f'a={a}')
    print(f'a_type={type(a)}')

fn(a=3, b=4, c=5)
```

输出：

```python
a={'a': 3, 'b': 4, 'c': 5}
a_type=<class 'dict'>
```

另一个例子：

```python
def fn(a, b, **c):
    print(f'a={a}')
    print(f'b={b}')
    print(f'c={c}')
    print(f'c_type={type(c)}')

fn(3, b=4, c=5, d=6)
```

输出：

```python
a=3
b=4
c={'c': 5, 'd': 6}
c_type=<class 'dict'>
```

<font color = orange>注意</font>：位置参数必须在关键字参数的前面。否则会出现如下报错：

```python
Positional argument cannot appear after keyword arguments
```

## 解包

### 元组、列表解包

传递实参时使用 `*` 将序列中的元素依次作为参数传递。

<font color = orange>注意</font>：序列中的元素个数必须和形参的个数一致。

```python
def fn(a, b, c):
    print(a)
    print(b)
    print(c)

t = (1, 2, 3)
fn(*t)
```

输出：

```python
1
2
3
```

### 字典解包

对字典解包传递实参时，键名必须与形参名一致，且元素个数必须和形参个数一致。

```python
def fn(a, b, c):
    print(a)
    print(b)
    print(c)

t = {'a': 1, 'b': 2, 'c': 3, 'e': 4, 'f': 5, 'g': 6}
fn(**t)
```

输出：

```python
# 报错
line 7, in <module>
    fn(**t)
TypeError: fn() got an unexpected keyword argument 'e'
```

键名、个数与形参一致：

```python
def fn(a, b, c):
    print(a)
    print(b)
    print(c)

t = {'a': 1, 'b': 2, 'c': 3}
fn(**t)
```

输出：

```python
1
2
3
```

## 作用域

一共有两种作用域：

1. 全局作用域：一般在程序执行时创建，在程序结束时销毁。在全局作用域中定义的变量都是全局变量，可以在程序的任意位置被访问。
2. 函数作用域：在函数调用时创建，在调用结束时销毁。函数没调用一次就会产生一个新的函数作用域。在函数作用域中定义的变量都是局部变量，只能在函数内部被访问。

当使用变量时，会优先在作用域中寻找该变量，如果没有，则继续去上一级作用域中寻找，如果有则使用。如果一直找到全局作用域，依然没有，则会抛出异常。

```python
# 报错
NameError: name 'a' is not defined
```

例子1：

```python
a = 0

def fn1():
    a = 10
    print(f'fn1 中，执行 fn2 之前，a={a}')

    def fn2():
        a = 20
        print(f'fn2 中，a={a}')
    fn2()
    print(f'fn1 中，执行 fn2 之后，a={a}')

fn1()
print(f'全局中，执行 fn1 之后，a={a}')
```

输出：

```python
fn1 中，执行 fn2 之前，a=10
fn2 中，a=20
fn1 中，执行 fn2 之后，a=10
全局中，执行 fn1 之后，a=0
```

例子2：

```python
a = 0

def fn1():
    print(f'fn1 中，执行 fn2 之前，a={a}')

    def fn2():
        print(f'fn2 中，a={a}')
    fn2()
    print(f'fn1 中，执行 fn2 之后，a={a}')

fn1()
print(f'全局中，执行 fn1 之后，a={a}')
```

输出：

```python
fn1 中，执行 fn2 之前，a=0
fn2 中，a=0
fn1 中，执行 fn2 之后，a=0
全局中，执行 fn1 之后，a=0
```

如果希望在函数内部修改全局变量，则需要使用 `global` 关键字来声明变量。

```python
a = 0

def fn1():
    print(f'fn1 中，执行 fn2 之前，a={a}')

    def fn2():
        global a
        a = 10
        print(f'fn2 中，a={a}')
    fn2()
    print(f'fn1 中，执行 fn2 之后，a={a}')

fn1()
print(f'全局中，执行 fn1 之后，a={a}')
```

输出：

```python
fn1 中，执行 fn2 之前，a=0
fn2 中，a=10
fn1 中，执行 fn2 之后，a=10
全局中，执行 fn1 之后，a=10
```

例子3：

```python
def fn1():
    a = 10
    print(f'fn1 中，执行 fn2 之前，a={a}')

    def fn2():
        a = 20
        print(f'fn2 中，a={a}')
    fn2()
    print(f'fn1 中，执行 fn2 之后，a={a}')

fn1()
```

输出：

```python
fn1 中，执行 fn2 之前，a=10
fn2 中，a=20
fn1 中，执行 fn2 之后，a=10
```

执行 fn2 后，fn1 中的 a 的值并没有改变，想要在 fn2 中直接改变 fn1 的值，需要使用 `nonlocal` 关键字。

```python
def fn1():
    a = 10
    print(f'fn1 中，执行 fn2 之前，a={a}')

    def fn2():
        nonlocal a
        a = 20
        print(f'fn2 中，a={a}')
    fn2()
    print(f'fn1 中，执行 fn2 之后，a={a}')

fn1()
```

输出：

```python
fn1 中，执行 fn2 之前，a=10
fn2 中，a=20
fn1 中，执行 fn2 之后，a=20
```

## 命名空间

命名空间指的是变量存储的位置，每一个变量都需要存储到指定的命名空间中。每一个作用域都会有一个对应的命名空间。全局命名空间用来保存全局变量，函数命名空间用来保存函数中的变量。命名空间实际是一个用来存储变量的字典。不要通过向字典中添加键值对的形式创建变量，因为在函数中会报如下错误。

```python
name 'c' is not defined
```

### locals()

使用 `locals()` 方法来获取当前命名空间，返回一个字典。

```python
a = 10

def fn():
    a = 20
    b = 30

print(locals())
```

输出：

```python
{'__name__': '__main__', '__doc__': None, '__package__': None, '__loader__': <_frozen_importlib_external.SourceFileLoader object at 0x0000012719E44A30>, '__spec__': None, '__annotations__': {}, '__builtins__': <module 'builtins' (built-in)>, '__file__': 'd:\\Git 仓库\\小工具\\Little-Tools\\键盘发声\\test.py', '__cached__': None, 'a': 10, 'fn': <function fn at 0x0000012719EB29E0>}
```

### globals()

可以在任意位置获取全局命名空间。

```python
a = 10

def fn():
    a = 20
    b = 30
    print(globals())

fn()
```

输出：

```python
{'__name__': '__main__', '__doc__': None, '__package__': None, '__loader__': <_frozen_importlib_external.SourceFileLoader object at 0x0000012D055F4A30>, '__spec__': None, '__annotations__': {}, '__builtins__': <module 'builtins' (built-in)>, '__file__': 'd:\\Git 仓库\\小工具\\Little-Tools\\键盘发声\\test.py', '__cached__': None, 'a': 10, 'fn': <function fn at 0x0000012D056629E0>}
```

