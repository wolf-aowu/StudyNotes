# pandas

## 介绍

pandas 官方网站：

http://pandas.pydata.org/

pandas 模块是基于 NumPy 模块的一个开源 Python 模块，广泛应用于完成数据快速分析、数据清洗和准备等工作，它的名字来源于 “panel data”（面板数据）。pandas 模块提供了非常直观的数据结构及强大的数据管理和数据处理功能，某种程度上可以把 pandas 模块看成 Python 版的 Excel。

与 NumPy 模块相比，pandas 模块更擅长处理二维数据，其主要有 Series 和 DataFrame 两种数据结构。

## 安装

在命令提示符中：

```shell
pip install pandas
```

如果需要读取 Excel 工作簿，需要在命令提示符中安装 openpyxl 模块。

```shell
pip install openpyxl
```

## 数据结构

### Series

Series 类似于通过 NumPy 模块创建的一维数组，不同的是 Series 对象不仅包含数值，还包含一组索引。

``` python
import pandas as pd
s = pd.Series(['丁一', '王二', '张三'])
print(s)
print(s[0])
```

输出：

```python
0    丁一
1    王二
2    张三
dtype: object
丁一
```

### DataFrame

DataFrame 是一种二维表格数据结构，可以将其看成一个 Excel 表格。它有行索引和列索引，可以自定义。默认索引序号是从 0 开始的。

`pd.DataFrame()` 共有 5 个参数：data、index、columns、dtype、copy。

index 用于指定行索引名称。columns 用于指定列索引名称。

```python
import pandas as pd
d = pd.DataFrame([[1, 2], [3, 4], [5, 6]])
print(d)
d = pd.DataFrame([[1, 2], [3, 4], [5, 6]], index=['A', 'B', 'C'], columns=['date', 'score'])
print(d)
```

输出：

```python
   0  1
0  1  2
1  3  4
2  5  6

   date  score
A     1      2
B     3      4
C     5      6
```

另一种 DataFrame 创建方式。必须保证列表 date 和 score 的长度一致，否则会报错。

```python
import pandas as pd
d = pd.DataFrame()
date = [1, 3, 5]
score = [2, 4, 6]
d['date'] = date
d['score'] = score
print(d)
```

输出：

```python
   date  score
0     1      2
1     3      4
2     5      6
```

#### 通过字典创建 DataFrame

通过字典创建 DataFrame，默认以字典的键名作为列索引。可以使用 `from_dict()` 设置参数 orient 的值为 'index'，以字典键名作为行索引。参数 orient 用于指定以字典的键名作为列索引还是行索引，默认值为 'columns'，即以字典的键名作为列索引，如果设置成 'index'，则表示以字典的键名作为行索引。字典的每一列都是一个 Series。

```python
import pandas as pd
d = pd.DataFrame({'a': [1, 3, 5], 'b': [2, 4, 6]}, index=['x', 'y', 'z'])
print(d)

d = pd.DataFrame.from_dict({'a': [1, 3, 5], 'b': [2, 4, 6]}, orient='index')
print(d)
```

输出：

```python
   a  b
x  1  2
y  3  4
z  5  6

   0  1  2
a  1  3  5
b  2  4  6
```

#### 通过二维数组创建 DataFrame

```python
import numpy as np
import pandas as pd
a = np.arange(12).reshape(3, 4)
d = pd.DataFrame(a, index=[1, 2, 3], columns=['A', 'B', 'C', 'D'])
print(d)
```

输出：

```python
   A  B   C   D
1  0  1   2   3
2  4  5   6   7
3  8  9  10  11
```

## DataFrame 索引修改

### 修改索引那一列名称

使用 `index.name` 属性。

```python
import pandas as pd
a = np.arange(12).reshape(3, 4)
d = pd.DataFrame(a, index=[1, 2, 3], columns=['A', 'B', 'C', 'D'])
d.index.name = '公司'
print(d)
```

输出：

``` python
    A  B   C   D
公司
1   0  1   2   3
2   4  5   6   7
3   8  9  10  11
```

### 重命名索引

使用 `rename()` 函数，该函数会用新索引名创建一个新的 DataFrame，并不会改变 d 的内容，所以这里将重命名索引之后得到的新 DataFrame 赋给 d，以便在后续代码中使用。也可以通过设置参数 inplace 为 True 来一步到位地完成索引的重命名。

```python
import pandas as pd
a = np.arange(6).reshape(3, 2)
d = pd.DataFrame(a, index=['A', 'B', 'C'], columns=['date', 'score'])
print(d)
print(id(d))
d = d.rename(index={'A': '万科', 'B': '阿里', 'C': '百度'},
             columns={'date': '日期', 'score': '分数'})
print(d)
print(id(d))
d.rename(index={'万科': '爸爸', '阿里': '妈妈', '百度': '老王'}, inplace=True)
print(d)
print(id(d))
```

输出：

```python
   date  score
A     0      1
B     2      3
C     4      5
1507889511872
    日期  分数
万科   0   1
阿里   2   3
百度   4   5
1507889512304
    日期  分数
爸爸   0   1
妈妈   2   3
老王   4   5
1507889512304
```

### 行索引转换为常规列

使用 `reset_index()` 函数重置索引，也是得到一个新的 DataFrame。也可以通过设置参数 inplace 为 True 来一步到位地完成索引转换为常规列。

```python
import pandas as pd
a = np.arange(6).reshape(3, 2)
d = pd.DataFrame(a, index=['A', 'B', 'C'], columns=['date', 'score'])
d = d.rename(index={'A': '万科', 'B': '阿里', 'C': '百度'},
             columns={'date': '日期', 'score': '分数'})
d.index.name = '公司'
print(d)
print(id(d))
d = d.reset_index()
print(d)
print(id(d))
d.reset_index(inplace=True)
print(d)
print(id(d))
```

输出：

```python
    日期  分数
公司
万科   0   1
阿里   2   3
百度   4   5
2340460531712
   公司  日期  分数
0  万科   0   1
1  阿里   2   3
2  百度   4   5
2340460531904
   index  公司  日期  分数
0      0  万科   0   1
1      1  阿里   2   3
2      2  百度   4   5
2340460531904
```

### 将常规列转换为行索引

使用 `set_index()` 函数，也是得到一个新的 DataFrame。也可以通过设置参数 inplace 为 True 来一步到位地完成索引转换为常规列。如果已经存在行索引，它会替换掉行索引，也就是旧的行索引被删除掉了。

```python
import pandas as pd
a = np.arange(6).reshape(3, 2)
d = pd.DataFrame(a, index=['A', 'B', 'C'], columns=['date', 'score'])
d = d.rename(index={'A': '万科', 'B': '阿里', 'C': '百度'},
             columns={'date': '日期', 'score': '分数'})
d.index.name = '公司'
d = d.reset_index()
print(d)
print(id(d))
d = d.set_index('公司')
print(d)
print(id(d))
d.set_index('日期', inplace=True)
print(d)
print(id(d))
```

输出：

```python
   公司  日期  分数
0  万科   0   1
1  阿里   2   3
2  百度   4   5
2243967935168
    日期  分数
公司
万科   0   1
阿里   2   3
百度   4   5
2243966050576
    分数
日期
0    1
2    3
4    5
2243966050576
```

## 文件的读取和写入

通过 pandas 模块可以从多种格式的数据文件中读取数据，也可以将处理后的数据写入这些文件中。

### Excel 文件读取

使用 `pd.read_excel()` 函数，该函数有需要多参数可以使用。

常用的参数：

1. *sheet_name*：用于指定工作表，可以是工作表名称，也可以是数字（默认为0，即第1个工作表）。
2. index_col：用于设置索引列。

```python
import pandas as pd
data = pd.read_excel('基本操作\分公司.xlsx', sheet_name=0)
print(data)
```

输出：

```python
   编号 子公司
0   1  华为
1   2  百度
2   3  腾讯
```

### 写入 Excel 文件

使用 `to_excel` 函数。会将工作簿中原有的 sheet 替换掉。

常用的参数：

1. sheet_name：用于指定工作表名称。
2. index：用于指定是否写入行索引信息，默认为 True，即将行索引信息存储在输出文件的第 1 列；若设置为 False，则忽略行索引信息。
3. columns：用于指定要写入的列。

```python
import pandas as pd
data = pd.DataFrame([[1, 2], [3, 4], [5, 6]], columns=['A列', 'B列'])
data.to_excel('基本操作\分公司.xlsx', sheet_name='练习', columns=['A列'], index=False)
print()
```

输出：

![](图片\写入 Excel.png)

### CSV 文件读取

CSV 文件本质上是一个文本文件，它仅存储数据，不能像 Excel 工作簿那样存储格式、公式、宏等信息，所以所占存储空间通常较小。CSV 文件一般用逗号分隔一系列值，既可以用 Excel 打开，也可以用文本编辑器（如记事本）打开。

使用 `pd.read_csv()` 函数。

常用的参数：

1. delimiter：用于指定 CSV 文件的数据分隔符，默认为逗号。与字符串的 `split()` 函数一个道理。不要理解错了，是把指定字符切掉，不是增加分割符。
2. encoding：用于指定文件的编码方式，一般设置为 UTF-8 或 GBK 编码，以避免中文乱码。
3. index_col：用于设置索引列。

```python
import pandas as pd
data = pd.read_csv('基本操作\分公司.csv', delimiter='为',
                   engine='python', encoding='utf-8')
print(data)
```

输出：

```python
      编号,子公司
1,华      NaN
2,百度     NaN
3,腾讯     NaN
```

### 写入 csv 文件

`to_csv()` 函数与 `to_excel()` 函数类似，也可以设置 index、columns、encoding 等参数。

```python
import pandas as pd
data = pd.DataFrame([[1, 2], [3, 4], [5, 6]], columns=['A列', 'B列'])
data.to_csv('基本操作\分公司.csv', columns=['A列'], index=False)
print()
```

输出：

![](图片\写入 csv.png)

## 数据选取和处理

### 按列选取数据

选取的数据不包含列索引信息，这是因为通过 `data['A列']` 选取一列时返回的是一个一维的 Series 类型的数据。

```python
import pandas as pd
data = pd.DataFrame([[1, 2], [3, 4], [5, 6]], index=['r1', 'r2', 'r3'], columns=['A列', 'B列'])
a = data['A列']
print(a)
```

输出：

```python
r1    1
r2    3
r3    5
Name: A列, dtype: int64
```

获取一个二维表格数据。如果要选取多列，则需在中括号 `[]` 中以列表的形式给出列索引。

```python
import pandas as pd
data = pd.DataFrame([[1, 2], [3, 4], [5, 6]], index=['r1', 'r2', 'r3'], columns=['A列', 'B列'])
a = data[['A列', 'B列']]
print(a)
```

输出：

```python
    A列  B列
r1   1   2
r2   3   4
r3   5   6
```

### 按行选取数据

#### 根据行序号选取数据

pandas 模块的官方推荐使用 iloc 方法来根据行序号选取数据。

选取单行。

``` python
import pandas as pd
data = pd.DataFrame([[1, 2], [3, 4], [5, 6]], index=['r1', 'r2', 'r3'], columns=['A列', 'B列'])
a = data.iloc[1]
print(a)
```

输出：

``` python
A列    3
B列    4
Name: r2, dtype: int64
```

选取多行。

``` python
import pandas as pd
data = pd.DataFrame([[1, 2], [3, 4], [5, 6]], index=['r1', 'r2', 'r3'], columns=['A列', 'B列'])
a = data.iloc[1:3]
print(a)
```

输出：

``` python
    A列  B列
r2   3   4
r3   5   6
```

选取倒数第一行。

```python
import pandas as pd
data = pd.DataFrame([[1, 2], [3, 4], [5, 6]], index=['r1', 'r2', 'r3'], columns=['A列', 'B列'])
a = data.iloc[-1]
print(a)
```

输出：

``` python
A列    5
B列    6
Name: r3, dtype: int64
```

#### 根据行的名称选取数据

使用 `loc` 方法。

```python
import pandas as pd
data = pd.DataFrame([[1, 2], [3, 4], [5, 6]], index=['r1', 'r2', 'r3'], columns=['A列', 'B列'])
a = data.loc[['r2','r1']]
print(a)
```

输出：

``` python
    A列  B列
r2   3   4
r1   1   2
```

#### 获取前 n 行数据

使用 `head()` 方法。参数只有一个 n，默认值为 5。当传入为正数时，表示获取前 n 行数据。当传入为负数时，表示获取从第一行开始到倒数第 n + 1 行为止的数据。如果 n 大于 DataFrame 的行数，会选取全部数据。

```python
import pandas as pd
data = pd.DataFrame([[1, 2], [3, 4], [5, 6]], index=['r1', 'r2', 'r3'], columns=['A列', 'B列'])
print(data)
a = data.head()
print(a)

a = data.head(1)
print(a)

a = data.head(-1)
print(a)
```

输出：

```python
    A列  B列
r1   1   2
r2   3   4
r3   5   6

    A列  B列
r1   1   2
r2   3   4
r3   5   6

    A列  B列
r1   1   2

    A列  B列
r1   1   2
r2   3   4
```

### 按区块选取数据

通常先用 `iloc` 方法选取行，再选取列。这也是 pandas 模块官方推荐的方法。

``` python
import pandas as pd
data = pd.DataFrame([[1, 2], [3, 4], [5, 6]], index=['r1', 'r2', 'r3'], columns=['A列', 'B列'])
a = data.iloc[0:2][['A列']]
print(a)
```

输出：

```python
    A列
r1   1
r2   3
```

也可以使用 `iloc` 或 `loc` 方法同时选取行和列。<font color = skyblue>注意：`loc` 方法使用字符串作为索引，`iloc` 方法使用数字作为索引。不可以搞混，也不能行使用数字后列使用字符串，也不能行使用字符串后列使用数字。</font>

```python
import pandas as pd
data = pd.DataFrame([[1, 2], [3, 4], [5, 6]], index=['r1', 'r2', 'r3'], columns=['A列', 'B列'])
a = data.iloc[0:2, [0, 1]]
print(a)
a = data.loc[['r1', 'r2'], ['A列', 'B列']]
print(a)
```

输出：

```python
    A列  B列
r1   1   2
r2   3   4

    A列  B列
r1   1   2
r2   3   4
```

### 数据筛选

通过在中括号里设定筛选条件可以过滤行。如果有多个筛选条件，可以用 “&”（表示 “且”）或 “|”（表示 “或”） 连接起来。注意要用小括号将筛选条件括起来。

```python
import pandas as pd
data = pd.DataFrame([[1, 2], [3, 4], [5, 6]], index=['r1', 'r2', 'r3'], columns=['A列', 'B列'])
a = data[(data['A列'] > 1) & (data['B列'] == 5)]
print(a)
```

输出：

```python
Empty DataFrame
Columns: [A列, B列]
Index: []
```

### 数据排序

#### 按列排序

使用 `sort_values()` 函数可以按列对数据进行排序。

常用参数说明：

1. by：指定按哪一列来排序，可以指定字符串表示单列，也可以时一个字符串列表来指定多列。
2. ascending：“上升” 的意思，默认值为 True，表示升序排序。若设置为 False，表示降序排序。

```python
import pandas as pd
data = pd.DataFrame([[1, 2], [3, 4], [5, 6]], index=['r1', 'r2', 'r3'], columns=['A列', 'B列'])
a = data.sort_values(by='B列', ascending=False)
print(a)
```

输出：

```python
    A列  B列
r3   5   6
r2   3   4
r1   1   2
```

#### 按索引排序

使用 `sort_index()` 函数可以按索引排序。`sort_index()` 也可以通过设置参数 ascending 为 False 来进行降序排序。

```python
import pandas as pd
data = pd.DataFrame([[1, 2], [3, 4], [5, 6]], index=['r1', 'r2', 'r3'], columns=['A列', 'B列'])
a = data.sort_values(by='B列', ascending=False)
a = data.sort_index()
print(a)
```

输出：

```python
    A列  B列
r1   1   2
r2   3   4
r3   5   6
```

### 数据运算

通过数据运算可以基于已有的列生成新的一列。

```python
import pandas as pd
data = pd.DataFrame([[1, 2], [3, 4], [5, 6]], index=['r1', 'r2', 'r3'], columns=['A列', 'B列'])
data['C列'] = data['B列'] - data['A列']
print(data)
```

输出：

``` python
    A列  B列  C列
r1   1   2   1
r2   3   4   1
r3   5   6   1
```

### 数据分组

参考网址：https://pandas.pydata.org/docs/reference/api/pandas.DataFrame.groupby.html?highlight=groupby#pandas.DataFrame.groupby

```python
import pandas as pd
df = pd.DataFrame(
    [
        ("bird", "Falconiformes", 389.0),
        ("bird", "Psittaciformes", 24.0),
        ("mammal", "Carnivora", 80.2),
        ("mammal", "Carnivora", 58),
    ],
    index=["falcon", "parrot", "lion", "leopard"],
    columns=("class", "order", "max_speed"),
)
print(df)
grouped = df.groupby("class")
print(grouped.groups)
```

输出：

```python
          class           order  max_speed
falcon     bird   Falconiformes      389.0
parrot     bird  Psittaciformes       24.0
lion     mammal       Carnivora       80.2
leopard  mammal       Carnivora       58.0
{'bird': ['falcon', 'parrot'], 'mammal': ['lion', 'leopard']}
```

### 数据删除

使用 `drop()` 函数可以删除 DataFrame 中的指定数据。

常用参数说明：

1. index：用于指定要删除的行。
2. columns：用于指定要删除的列。
3. inplace：默认值为 False，表示该删除操作不改变原DataFrame，而是返回一个执行删除操作后的新DataFrame，如果设置为 True，则会直接在原 DataFrame 中进行删除操作。

```python
import pandas as pd
data = pd.DataFrame([[1, 2], [3, 4], [5, 6]], index=['r1', 'r2', 'r3'], columns=['A列', 'B列'])
data['C列'] = data['B列'] - data['A列']
a = data.drop(columns='C列')
print(a)
```

输出：

```python
    A列  B列
r1   1   2
r2   3   4
r3   5   6
```

删除多列数据时，要以列表的形式给出列索引。

```python
import pandas as pd
data = pd.DataFrame([[1, 2], [3, 4], [5, 6]], index=['r1', 'r2', 'r3'], columns=['A列', 'B列'])
data['C列'] = data['B列'] - data['A列']
a = data.drop(columns=['A列', 'C列'])
print(a)
```

输出：

```python
    B列
r1   2
r2   4
r3   6
```

删除行时，要输入行索引名称而不是序号。

```python
import pandas as pd
data = pd.DataFrame([[1, 2], [3, 4], [5, 6]], index=['r1', 'r2', 'r3'], columns=['A列', 'B列'])
data.drop(index=['r1', 'r2'], inplace=True)
print(data)
```

输出：

```python
    A列  B列
r3   5   6
```

## 数据表拼接

### 合并 pd.merge()

`pd.merge()` 函数可以根据一个或多个同名的列将不同数表中的行连接起来。

常用参数说明：

1. on：如果同名的列不止一个，指定按照哪一列进行合并。

2. left_on：左边 DataFrame 中要连接的列或索引级名称。也可以是一个数组或数组列表，其长度为左侧 DataFrame 的长度。这些数组被当作列来处理。

3. right_on：右边 DataFrame 中要连接的列或索引级名称。也可以是一个数组或数组列表，其长度为右侧 DataFrame 的长度。这些数组被当作列来处理。

4. left_index：使用左边 DataFrame 的索引作为连接键。如果它是一个多重索引，另一个数据框架中的键的数量（无论是索引还是列的数量）必须与层次的数量相匹配。它可以与 left_on、right_on 和 right_index 混合使用。当指定了其中一个 DataFrame 的连接列时，必须同时指定另一个 DataFrame 的连接列，否则会报错。

5. right_index：使用右边 DataFrame 的索引作为连接键。如果它是一个多重索引，另一个数据框架中的键的数量（无论是索引还是列的数量）必须与层次的数量相匹配。它可以与 left_on、right_on 和 left_index 混合使用。当指定了其中一个 DataFrame 的连接列时，必须同时指定另一个 DataFrame 的连接列，否则会报错。

6. how：共有五个可选项，默认值为 'inner'。原来没有的内容则用空值 NaN 填充。

   left：只使用左表格中的键，类似于 SQL 的左外连接，保留键的顺序。

   right：只使用右表格中的键，类似于 SQL 的右外连接，保留键的顺序。

   outer：使用来自两个表格的键的联合，类似于 SQL 的全外连接。按字母顺序排列键。

   inner：使用来自两个表格的键的交集，类似于 SQL 的内连接，保留左键的顺序。

   cross：从两个表格框架中创建笛卡尔乘积，保留左键的顺序。

```python
import pandas as pd
df1 = pd.DataFrame({'公司': ['恒盛', '创锐', '快学'], '分数': [90, 95, 85]})
df2 = pd.DataFrame({'公司': ['恒盛', '创锐', '京西'], '股价': [20, 180, 30]})
print(df1)
print(df2)

df3 = pd.merge(df1, df2)
print(df3)
df3 = pd.merge(df1, df2, on='公司')
print(df3)
df3 = pd.merge(df1, df2, how='outer')
print(df3)
df3 = pd.merge(df1, df2, left_index=True, right_index=True)
print(df3)
```

输出：

```python
   公司  分数
0  恒盛  90
1  创锐  95
2  快学  85
   公司   股价
0  恒盛   20
1  创锐  180
2  京西   30

   公司  分数   股价
0  恒盛  90   20
1  创锐  95  180

   公司  分数   股价
0  恒盛  90   20
1  创锐  95  180

   公司    分数     股价
0  恒盛  90.0   20.0
1  创锐  95.0  180.0
2  快学  85.0    NaN
3  京西   NaN   30.0

  公司_x  分数 公司_y   股价
0   恒盛  90   恒盛   20
1   创锐  95   创锐  180
2   快学  85   京西   30
```

### concat()

`pd.concat()` 函数使用全连接（UNION ALL）方式完成拼接，它不需要对齐，而是直接进行合并，即不需要两个表有相同的列或索引，只是把数据整合到一起。因此，该函数没有参数 how 和 on，而是用参数 axis 指定连接的轴向。

常用参数说明：

1. axis：指定连接的轴向。默认值为 0，代表纵向拼接。值为 1，代表横向拼接。
2. ignore_index：设置是否忽略原有索引。默认值为 True，生成新的数字序列作为索引。

``` python
import pandas as pd
df1 = pd.DataFrame({'公司': ['恒盛', '创锐', '快学'], '分数': [90, 95, 85]})
df2 = pd.DataFrame({'公司': ['恒盛', '创锐', '京西'], '股价': [20, 180, 30]})
print(df1)
print(df2)

df3 = pd.concat([df1, df2], axis=0)
print(df3)
df3 = pd.concat([df1, df2], axis=0, ignore_index=True)
print(df3)
```

输出：

```python
   公司  分数
0  恒盛  90
1  创锐  95
2  快学  85
   公司   股价
0  恒盛   20
1  创锐  180
2  京西   30

   公司    分数     股价
0  恒盛  90.0    NaN
1  创锐  95.0    NaN
2  快学  85.0    NaN
0  恒盛   NaN   20.0
1  创锐   NaN  180.0
2  京西   NaN   30.0

   公司    分数     股价
0  恒盛  90.0    NaN
1  创锐  95.0    NaN
2  快学  85.0    NaN
3  恒盛   NaN   20.0
4  创锐   NaN  180.0
5  京西   NaN   30.0
```



