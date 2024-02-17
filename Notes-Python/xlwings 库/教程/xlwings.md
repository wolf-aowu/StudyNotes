# xlwings 库

官方文档网址：

https://docs.xlwings.org/zh_CN/latest/quickstart.html

## 介绍

可以处理 Excel 文件的 Python 模块有很多，如 XlsxWriter、xlrd、xlwt、xlutils、openpyxl 和 xlwings 等。下表对各个模块的功能进行了简单对比。

| 模块\功能  | 读   | 写   | 修改 | 支持 xls 格式 | 支持 xlsx 格式 | 支持批量操作 |
| ---------- | ---- | ---- | ---- | ------------- | -------------- | ------------ |
| XlsxWriter | ×    | ✔    | ×    | ×             | ✔              | ×            |
| xlrd       | ✔    | ×    | ×    | ✔             | ✔              | ×            |
| xlwt       | ×    | ✔    | ×    | ✔             | ✔              | ×            |
| xlutils    | ✔    | ✔    | ✔    | ✔             | ×              | ×            |
| openpyxl   | ✔    | ✔    | ✔    | ×             | ✔              | ×            |
| xlwings    | ✔    | ✔    | ✔    | ✔             | ✔              | ✔            |

通过上表的对比可以发现，xlwings 模块的功能是最齐全的。它不仅能读、写和修改两种格式的 Excel 文件（xls 和 xlsx），而且能批量处理多个 Excel 文件。此外，xlwings 模块还能与 Excel VBA 结合使用，实现更加强大的数据输入和分析功能。

## 方法

### 创建工作簿

```python
import xlwings as xw
app = xw.App(visible=True, add_book=False)
workbook = app.books.add()
```

第 2 行代码启动 Excel 程序窗口，但不新建工作簿。

App()：

入参：

1. visible：用于设置 Excel 程序窗口的可见性。True，表示显示 Excel 程序窗口；False，表示隐藏 Excel 程序窗口。
2. add_book：用于设置启动 Excel 程序窗口后是否新建工作簿。True，表示新建一个工作簿；False，表示不新建工作簿。

第 3 行代码新建一个工作簿。其中的 add() 为 books 对象的函数，用于新建工作簿。

### 保存工作簿

```python
import xlwings as xw
app = xw.App(visible=False, add_book=False)
workbook = app.books.add()
workbook.save('D:\\用 Python 让 Excel 飞起来\\基本操作\\分公司.xlsx')
workbook.close()
app.quit()
```

第 4 行代码中的 save() 函数用于保存前面创建的空白工作簿，括号里的参数为工作簿的保存路径和文件名。该路径可以是绝对路径，也可以时相对路径。如果不提供保存路径且打开的文件时以前未保存过的，将以当前文件名保存在当前工作目录中。如果不提供保存路径且打开的文件是现有的文件，将在不提示的情况下被覆盖。

第 5 行代码中的 close() 函数用于关闭创建的工作簿。 

第 6 行代码中的 quit() 函数用于退出 Excel 程序。

### 打开工作簿

```python
import xlwings as xw
app = xw.App(visible=True, add_book=False)
workbook = app.books.open('D:\\用 Python 让 Excel 飞起来\\基本操作\\分公司.xlsx')
```

### 重命名工作簿

```python
file_list = os.listdir(file_path)
for i in file_list:
    new_file = i.replace(old_book_name, new_book_name)
```

### 打印工作簿

因为 xlwings 模块没有提供打印工作簿的函数，所以工作簿对象的 api 属性调用 VBA 的 `PrintOut()` 函数来打印工作簿。

查看 `PrintOut()` 接口网址：https://learn.microsoft.com/en-us/office/vba/api/excel.workbook.printout

Microsoft Learn 网址：https://learn.microsoft.com/en-us/

搜索关键字：Office VBA Reference

左侧 Content area 分类选择 All 或者 Documentation。

Microsoft 官网上分类路径：Learn -> Office VBA Reference -> Excel -> Object model -> Workbook object -> Methods

常用参数说明：

1. From：可选参数，指定打印的开始页码。默认从头开始打印。
2. To：可选参数，指定打印的终止页码。默认打印至最后一页。
3. Copies：可选参数，指定打印份数。默认只打印一份。
4. Preview：可选参数，如果为True，Excel 会在打印之前显示打印预览界面。如果为 False，则会立即打印。默认为 False。
5. ActivePrinter：可选参数，设置要使用的打印机的名称。默认使用操作系统的默认打印机。
6. PrintToFile：可选参数，如果为 True，则表示不打印到打印机，而是打印成一个 prn 文件。如果没有指定 PrToFileName，Excel 将提示用户输入文件名。
7. Collate：可选参数，如果为 True，则逐份打印多个副本。
8. PrToFileName：可选参数，如果将 PrintToFile 设置为 True，则用该参数指定 prn 文件的文件名。
9. IgnorePrintAreas：可选参数，如果为 True 忽略打印区域并打印整个对象。

```python
workbook = app.books.open(file_paths)
workbook.api.PrintOut()
```

### 获取工作表

``` python
worksheet = workbook.sheets['Sheet1']
```

### 新增工作表

`workbook.sheets.add` 方法有三个参数：

1. name：新工作表的名称，如果没有，将使用 Excel 默认的名称。
2. before：指定新工作表的之前的工作表对象，可以理解为新工作表插入的位置。
3. after：指定新工作表之后的工作表对象，可以理解为新工作表插入的位置。

``` python
worksheet = workbook.sheets.add('产品统计表')
```

### 读取工作表数据

#### 直接读取数据

先使用 `range()` 和 `expand()` 函数选取范围，在使用 value 属性获取数据。

如果没有获取到数据，就会返回 None。如果获取到的数据只有一行，就会返回一个一维列表。如果获取到的数据有多行，就会返回一个二维列表。

```python
values = worksheet['A2'].expand('table').value
```

#### 读取整张表的数据

```python
contents = workbook.range('A1').expand('table').value
```

#### 使用转换器转换容器类型

`options` 允许用户设定转换器和相关的选项。转换器定义了 Excel 的区域及其值在读写过程中如何转换。如果没有明确指定转换器，会使用基转换器（base converter）。

参数：

1. convert： (object, default None) – 转换器名称，例如：`dict`, `np.array`, `pd.DataFrame`, `pd.Series` 等, 缺省时使用缺省转换器。
2. ndim：关键字参数，int 型，指定维数。
3. numbers：指定数字类型，如 int。
4. dates：例如 datetime.date，默认为 datetime.datetime。
5. empty：空白单元格转换。
6. transpose：是否转置。
7. expand：可以取 `'table'`，`'down'`，`'right'`。

参考网址：https://docs.xlwings.org/zh_CN/latest/api/range.html#xlwings.Range.options

Pandas DataFrame 转换器

参数：

1. index：默认为 1。读的时候，指 Excel 中的索引列的列数。写的时候，如果需要包含索引，则为 True，否则为 False。
2. header：默认为 1。读的时候，值 Excel 中表头的行数。写的时候，如果需要包含索引和序列名，则为 True，否则为 False。

参考网址：https://docs.xlwings.org/zh_CN/latest/converters.html#pandas-dataframe-converter

```python
# 此处的 index 代表是否将行号作为索引，index 为 True 则不将行号作为索引
value = worksheet.range('A1').options(pd.DataFrame, header=1, index=False, expand='table').value
```

### 复制工作表

xlwings 模块没有提供复制工作表的函数，所以使用工作表对象的 api 属性调用 VBA 的 `Copy()` 函数来复制工作表。

参数有两个：

1. Before：可选的。将在指定的工作表之前放置复制的工作表。如果指定了参数 After，则该参数无法生效。
2. After：可选的。将在指定的工作表之前放置复制的工作表。如果指定了参数 Before，则该参数无法生效。

如果你没有指定 Before 或 After，Microsoft Excel 会创建一个新的工作簿，其中包含复制的工作表对象。新创建的工作簿持有 Application.ActiveWorkbook 属性并包含一个工作表。该单个工作表保留了源工作表的名称和代码名称属性。如果复制的工作表在 VBA 项目中持有一个工作表代码表，那么它也会被带入新的工作簿中。多个工作表的数组选择可以用类似的方式复制到一个新的空白工作簿对象中。

参考网址：[Worksheet.Copy method (Excel) | Microsoft Learn](https://learn.microsoft.com/en-us/office/vba/api/excel.worksheet.copy)

```python
for i in workbook.sheets:
    new_workbook = app.books.add()
    new_worksheet = new_workbook.sheets[0]
    i.api.Copy(Before=new_worksheet.api)
```

### 删除工作表

```python
workbook = app.books.open(file_paths)
    for j in workbook.sheets:
        j.delete()
```

### 重命名工作表

``` python
worksheets = workbook.sheets
for i in range(len(worksheets))[:3]:
    worksheets[i].name = worksheets[i].name.replace('Sheet', '销售')
```

### 打印工作表

```python
for j in workbook.sheets:
	j.api.PrintOut()
```

### 单元格赋值

```python
workbook.range('A1').value = '编号'
```

### 赋值多个单元格

`expand()` 是 xlwings 模块中的函数，用于扩展选择范围。

常用参数：

1. model：默认值为 table，表示向整个工作表扩展选择范围。down，表示向表的下方扩展选择范围。right，表示向表的右方扩展选择范围。

```python
# contents 中存储多个单元格数据，contents 是一个二维列表，索引从 0 开始，contents[i] 代表获取第 i + 1 行数据，contents[i][j] 代表获取第 i + 1 行第 j + 1 列单元格的数据
contents = workbook.range('A1').expand('table').value
workbook.sheets[name].range('A1').value = contents
```

### 判断获取数据的维度

使用 `len()` 函数和 numpy 库中的 shape 属性获取维度。如果 values 为 None，返回 0。如果 values 为一维列表，返回 1。如果 values 为二维列表，返回 2。

```python
import numpy as np
values = worksheet['A2'].expand('table').value
ndim = len(np.array(values).shape)
```

### 获取选中区域的结束单元格

```python
# 选中区域
source_area = source_sheet.range('A1').expand('table')
# 行号
row = source_area.shape[0]
# 列号
col = source_area.shape[1]
```

### 插入图片

使用 `pictures.add()` 函数将 Matplotlib 模块绘制的图表写入工作簿。

常用参数说明：

1. image：图片路径或者一个 Matplotlib 模块绘制的图表。
2. name：用于指定图表的名称，这个名称并不显示在图表上，它是在绘制多个图表时使用的，如果要在同一个工作表里绘制第二个图表，则需要把 name 设置成另一个名称。
3. update：默认值为 False。设置为 True，则在后续通过 `pictures.add()` 函数调用具有相同名称的图表时，可以只更新图表数据而不更改其位置或大小。
4. left：用于设置图表与左侧边界的距离，这里设置 left 为 100，表示让图表距离左侧边界 100 像素。
5. top：用于设置图表与顶部边界的距离，这里设置 top 为 100，表示让图表距离顶部边界 100 像素。

```python
import xlwings as xw
import matplotlib.pyplot as plt

figure = plt.figure()
x = [1, 2, 3, 4, 5]
y = [2, 4, 6, 8, 10]
plt.plot(x, y)
app = xw.App(visible=False)
workbook = app.books.add()
worksheet = workbook.sheets.add('figure')
worksheet.pictures.add(figure, name='图片1', update=True, left=100)
workbook.save('D:\\用 Python 让 Excel 飞起来\\基本操作\\figure.xlsx')
workbook.close()
app.quit()
```

### 调整工作表的列宽和行高

#### worksheet.autofit()

`autofit()` 是 xlwings 模块中工作表对象的函数，用于自动适应调整整个工作表的列宽和行高。

参数：

1. axis：默认值为 None，即不传入参数，表示同时自适应调整列宽和行高。`'rows'` 或 `'r'` 表示自适应调整行高。`'columns'` 或 `'c'` 表示自适应调整列宽。

```python
worksheet.autofit()
```

