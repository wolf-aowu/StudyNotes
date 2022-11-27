# matplotlib

## 介绍

Matplotlib 是一个非常出色的数据可视化模块，其导入代码通常写 成：

``` python
import matplotlib.pyplot as plt
```

将模块名简写为 plt，之后以 plt 为前缀 调用函数即可绘制图表。例如，plt.plot()函数用于绘制折线图，plt.bar() 函数用于绘制柱形图，plt.pie()函数用于绘制饼图，等等。

## 安装

在命令提示符中输入

``` shell
pip install matplotlib
```

## 折线图

```python
import matplotlib.pyplot as plt
x = [1, 2, 3, 4, 5]
y = [2, 4, 6, 8, 10]
plt.plot(x, y)
plt.show()
```

输出：

![](图片\折线图.png)

## 柱形图

```python
import matplotlib.pyplot as plt
x = [1, 2, 3, 4, 5, 6]
y = [6, 5, 4, 3, 2, 1]
plt.bar(x, y)
plt.show()
```

输出：

![](图片\柱形图.png)

