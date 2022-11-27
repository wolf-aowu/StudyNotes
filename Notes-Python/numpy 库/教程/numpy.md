# numpy

## 创建数组

### np.array()

```python
import numpy as np
# 创建一维数组
a = np.array([1, 2, 3, 4])
# 创建二维数组
b = np.array([[1, 2], [3, 4], [5, 6]])
print(a)
print(type(a))
print(b)
```

输出：

```python
[1 2 3 4]
<class 'numpy.ndarray'>
[[1 2]
 [3 4]
 [5 6]]
```

### np.arange()

`np.arange()` 创建左闭右开区间的数组，常用的参数有三个：start、stop、step。三个参数都支持整数或实数。三个参数中任意多个为浮点数时创建的数组以浮点数显示。

```python
import numpy as np
x = np.arange(3)
print(x)
y = np.arange(3, 7)
print(y)
z = np.arange(3, 7, 2)
print(z)
# 浮点数
x = np.arange(3.0)
print(x)
y = np.arange(3.0, 7)
print(y)
z = np.arange(3.0, 7, 0.5)
print(z)
```

输出：

```python
[0 1 2]
[3 4 5 6]
[3 5]
# 浮点数
[0. 1. 2.]
[3. 4. 5. 6.]
[3.  3.5 4.  4.5 5.  5.5 6.  6.5]
```

### np.random.randn()

`np.random.randn()` 创建随机一维数组，创建的数组服从正态分布（均值为 0，标准差为 1 的分布）。参数的个数代表创建数组的维数。

```python
import numpy as np
a = np.random.randn(3)
print(a)
b = np.random.randn(2, 4)
print(b)
```

输出：

``` python
[ 0.80177827 -2.15268581  1.50172079]
[[-0.51635023 -0.16747034  1.45016209 -0.21040806]
 [ 0.18899445  0.25069488  0.44675072 -1.1738797 ]]
```

### np.random.randint()

`np.random.randint` 创建随机整数数组。左闭右开。

low：指定随机数下界，可以是一个数字，也可以是一个列表。

high：指定随机数的上界，可以是一个数字，也可以是一个列表。

size：输出的形状。例如：(m, n, k)，则绘制 m * n * k 的形状。

dtype：元素的数据类型，默认为 int。

```python
import numpy as np
a = np.random.randint(2, size=10)
print(a)

b = np.random.randint(5, size=(2, 4))
print(b)

# 生成一个 1 × 3 的数组，每一个位置的下界为 1，上界为对应位置的数字（不包含该数字），即左闭右开
# [1 到 2 随机一个数，1 到 4 随机一个数，1 到 9 随机一个数]
c = np.random.randint(1, [3, 5, 10])
print(c)

# 生成一个 1 × 3 的数组，每一个位置的下界为 1，上界为对应位置的数字（不包含该数字），即左闭右开
# [1 到 9 随机一个数，5 到 9 随机一个数，7 到 9 随机一个数]
d = np.random.randint([1, 5, 7], 10)
print(d)

# 生成一个 2 × 4 的数组
# [[1 到 9 随机一个数，3 到 9 随机一个数，5 到 9 随机一个数，7 到 9 随机一个数]
#  [1 到 19 随机一个数，3 到 19 随机一个数，5 到 19 随机一个数，7 到 19 随机一个数]]
# 数组中元素的数据类型均为 uint8
e = np.random.randint([1, 3, 5, 7], [[10], [20]], dtype=np.uint8)
print(e)
```

输出：

```python
[0 0 0 0 1 0 1 0 0 0]
[[0 3 4 4]
 [0 1 3 2]]
[2 4 6]
[3 8 9]
[[ 5  7  7  8]
 [ 7 16 19 17]]
```

## 数组维数转换

`np.reshape(a, newshape, order)` 在不改变数组数据情况下为数组提供新形状，即<font color = skyblue>先将数组拉伸成一维数组，再按 order 的顺序重组数组维度。</font>

newshape 是新数组的形状，必须是整数或整数元组。重组后的数组元素数量必须保证与重组前的元素数量完全相等，否则会报错。如 `np.arange(13).reshape(3, 4)` 会报错。newshape 允许使用 -1 的特殊参数，表示将剩余元素都分配到那个轴，如 (-1, 5) ，再这种情况下，值是根据数组长度和剩余维度推断。

order 参数允许使用 `'C'`、`'A'`、`'F'`，`'C'` 为 order 的默认值。

官方文档中对于 `'C'` 参数的解释：C-like index ordering。意思为：像 C 语言那样顺序读取 / 写入元素。

官方文档中对于 `'F'` 参数的解释：Fortran-like index ordering。意思为：像 Fortran 语言那样顺序读取 / 写入元素。

官方文档中对于 `'A'` 参数的解释：按照数据在内存中存储的顺序来拉伸成一维数组后再按内存的顺序重新分配。如果数据在内存中是 Fortran 连续，则以像 Fortran 语言那样顺序读取 / 写入元素，否则以像 C 语言那样顺序读取 / 写入元素。

Fortran 语言是一个很古老的编程语言，是 IBM 公司的约翰·贝克斯（John Backus）于 1951 年针对汇编语言的缺点研究开发的高级语言，也是世界上第一个计算机高级语言，用于科学和工程计算领域，至今仍然有一些程序员在使用 Fortran 语言编程，实际上他就像梵文一样是古老而又不可或缺的语言，只是现在已经被边缘化了，连计算机教学中都很少被提到。

Fortran 语言的数组与 C 语言等现在编程语言的排列方式不同，它是按列的顺序排列，而且数组下标是从 1 开始，例如：一个 (3, 2) 的数组 A：

```python
源数组：
[[0 1]
 [2 3]
 [4 5]]
C 语言拉伸：
A[0][1], A[0][2], A[1][0], A[1][1], A[2][0], A[2][1]
[0 1 2 3 4 5]
重组数组维度（先填充行）：
A[0][1], A[0][2], A[1][0]
A[1][1], A[2][0], A[2][1]
[[0 1 2]
 [3 4 5]]
Fortran 语言拉伸：
A[1][1], A[2][1], A[3][1], A[1][2], A[2][2], A[3][2]
[0 2 4 1 3 5]
重组数组维度（先填充列）：
A[1][1], A[3][1], A[2][2]
A[2][1], A[1][2], A[3][2]
[[0 4 3]
 [2 1 5]]
```

例子：

``` python
import numpy as np
a = np.arange(12).reshape(3, 4)
print(a)

b = np.arange(12)
print(b)
b = np.reshape(b, (3, 4))
print(b)

c = np.arange(12).reshape(-1, 6)
print(c)
```

输出：

```python
[[ 0  1  2  3]
 [ 4  5  6  7]
 [ 8  9 10 11]]

[ 0  1  2  3  4  5  6  7  8  9 10 11]
[[ 0  1  2  3]
 [ 4  5  6  7]
 [ 8  9 10 11]]

[[ 0  1  2  3  4  5]
 [ 6  7  8  9 10 11]]
```

order 参数的例子：

```python
import numpy as np
a = np.arange(6).reshape(3, 2)
print("源数组：")
print(a)
c = np.reshape(a, 6)
print("C 拉伸：")
print(c)
c = np.reshape(a, (2, 3))
print("C 重组数组维度：")
print(c)
f = np.reshape(a, 6, order='F')
print("Frotran 拉伸：")
print(f)
f = np.reshape(a, (2, 3), order='F')
print("Fortran 重组数组维度：")
print(f)
```

输出：

```python
源数组：
[[0 1]
 [2 3]
 [4 5]]
C 拉伸：
[0 1 2 3 4 5]
C 重组数组维度：
[[0 1 2]
 [3 4 5]]
Frotran 拉伸：
[0 2 4 1 3 5]
Fortran 重组数组维度：
[[0 4 3]
 [2 1 5]]
```

## 数学运算

``` python
import numpy as np
a = np.array([1, 2, 3, 4])
c = a * 2
print(c)
```

输出：

```python
[2 4 6 8]
```

如果是列表进行 * 2 运算，则会像下面这样复制一遍元素。

```python
[1, 2, 3, 4, 1, 2, 3, 4]
```

