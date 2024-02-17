# matplotlib

## 介绍

Matplotlib 是一个非常出色的数据可视化模块，其导入代码通常写 成：

``` python
import matplotlib.pyplot as plt
```

将模块名简写为 plt，之后以 plt 为前缀 调用函数即可绘制图表。例如，plt.plot()函数用于绘制折线图，plt.bar() 函数用于绘制柱形图，plt.pie()函数用于绘制饼图，等等。

官方 Github：https://github.com/matplotlib/matplotlib

官方文档：https://matplotlib.org/stable/users/index

## 安装

在命令提示符中输入

``` shell
pip install matplotlib
```

## 导入包

``` python
# 在 Jupyter Notebook 中需要添加下面两句，且在 import matplotlib.pyplot 之前
import matplotlib
%matplotlib ipympl
import matplotlib.pyplot as plt
```

可能会出现 `Matplotlib is currently using module://matplotlib_inline.backend_inline, which is a non-GUI backend, so cannot show the figure.` 的报错。

出现这个报错是因为默认的后端配置不支持 jupyter 显示生成的图片。

**什么是后端？**

Matplotlib 针对许多不同的用例和输出格式。有些人在 python shell 中交互地使用 matplotlib，当他们输入命令时会弹出绘图窗口。有些人跑 Jupyter 笔记本和绘制内联绘图，以便快速进行数据分析。其他人将 matplotlib 嵌入到图形用户界面中，比如 wxpython 或 pygtk，以构建丰富的应用程序。有些人在批处理脚本中使用 matplotlib 从数值模拟中生成 PostScript 图像，还有一些人运行 Web 应用服务器来动态地提供图形。

为了支持所有这些用例，matplotlib 可以针对不同的输出，这些功能中的每一个都称为后端；“前端”是面向用户的代码，即绘图代码，而“后端”则在幕后完成了所有繁重的工作来生成数字。有两种后端：用户界面后端（用于 pygtk、wxpython、tkinter、qt4 或 macosx；也称为“交互后端”）和硬拷贝后端以生成图像文件（png、svg、pdf、ps；也称为“非交互后端”）。

有三种配置后端的方法：

- 这个 `rcParams["backend"]` (default: `'agg'`) 您的 `matplotlibrc` 文件
- 这个 MPLBACKEND 环境变量
- 函数 matplotlib.use()

如果存在多个配置，则列表中的最后一个配置优先；例如调用 matplotlib.use() 将覆盖您的 matplotlibrc.

如果没有显式设置后端，Matplotlib 会根据系统上可用的内容以及 GUI 事件循环是否已在运行来自动检测可用的后端。在 Linux 上，如果环境变量 DISPLAY 如果未设置，“事件循环”将标识为 “headless”，这将导致回退到非交互后端（agg）。

以下是配置方法的详细说明：

1. 设置 `rcParams["backend"]` (default: `'agg'`) 在你 `matplotlibrc` 文件：

   ```
   backend : qt5agg   # use pyqt5 with antigrain (agg) rendering
   ```

   也见[使用样式表和 RCPARAM 自定义 Matplotlib](https://www.osgeo.cn/matplotlib/tutorials/introductory/customizing.html).

2. 设置 [`MPLBACKEND`](https://www.osgeo.cn/matplotlib/faq/environment_variables_faq.html#envvar-MPLBACKEND) 环境变量：

   可以为当前 shell 或单个脚本设置环境变量。

   在 Unix 上：

   ```shell
   export MPLBACKEND=qt5agg
   python simple_plot.py
   
   MPLBACKEND=qt5agg python simple_plot.py
   ```

   在 Windows 上，只有前者是可能的：

   ```shell
   set MPLBACKEND=qt5agg
   python simple_plot.py
   ```

   设置此环境变量将重写 `backend` 参数在 *any* `matplotlibrc` ，即使有 `matplotlibrc` 在当前工作目录中。因此，设置 [`MPLBACKEND`](https://www.osgeo.cn/matplotlib/faq/environment_variables_faq.html#envvar-MPLBACKEND) 全局范围内，例如 `.bashrc` 或 `.profile` 不鼓励，因为这可能导致违反直觉的行为。

3. 如果脚本依赖于特定的后端，则可以使用该函数 [matplotlib.use()`](https://www.osgeo.cn/matplotlib/api/matplotlib_configuration_api.html#matplotlib.use)：

   ```python
   import matplotlib
   matplotlib.use('qt5agg')
   ```

   这应该在创建任何图形之前完成；否则Matplotlib可能无法切换后端并引发 ImportError。

   使用 [`use`](https://www.osgeo.cn/matplotlib/api/matplotlib_configuration_api.html#matplotlib.use) 如果用户要使用不同的后端，则需要更改代码。因此，您应该避免显式地调用 [`use`](https://www.osgeo.cn/matplotlib/api/matplotlib_configuration_api.html#matplotlib.use) 除非绝对必要。

jupyter 小部件生态系统移动太快，无法直接在 Matplotlib 中支持。<font color=skyblue>需要安装 IPYMPL。</font>

``` python
pip install ipympl
jupyter nbextension enable --py --sys-prefix ipympl
# anconda 使用下面这句
conda install ipympl -c conda-forge
```

可能没有安装 nbextension 这个插件，由于 最新版本的 jupyter 不支持安装插件，所以需要先卸载当前 jupyter。

``` shell
pip uninstall notebook
pip install notebook==6.4.12
```

安装 nbextension 和 nbextensions_configurator。

nbextensions_configurator 扩展作为此存储库的依赖项安装，可用于启用和禁用各个 nbextensions 以及配置其选项。然后，您可以打开 `nbextensions` 树（仪表板/文件浏览器）笔记本页面上的选项卡来配置 nbextensions。您将可以访问仪表板，其中可以通过复选框启用/禁用扩展。此外，还会显示每个扩展的简短文档，并提供配置选项。

nbextension 官方 github：https://github.com/ipython-contrib/jupyter_contrib_nbextensions/blob/master/README.md

nbextensions_configurator 官方 github：https://github.com/Jupyter-contrib/jupyter_nbextensions_configurator

``` shell
pip install jupyter_contrib_nbextensions
# 执行这条命令可能会报错，解决方案见下面
jupyter contrib nbextension install --user
pip install jupyter_nbextensions_configurator
```

如果出现 `TypeError: warn() missing 1 required keyword-only argument: 'stacklevel'` 报错，需要改变 traitlets 的版本。

可以参考：https://github.com/microsoft/azuredatastudio/issues/24436

```shell
pip uninstall traitlets
pip install traitlets==5.9.0
```

或者，尝试将 `$(Python)\Python38\site-packages\notebook\notebookapp.py` 文件 1411 行中的 `jupyter_server.contents.services.managers.ContentsManager` 改为 `jupyter_server.services.contents.manager.ContentsManager`。<font color=grass>此方法未尝试。</font>

或者，尝试导入 jupyter_server。<font color=grass>此方法未尝试。</font>

``` shell
pip install jupyter_server
```

## 创建图片

在 matplotlib 中有两个重要的对象，图像（Figure）和子图（Subplot，也称为 Axes）。图是所有图形元素的顶层容器，也是子图的容器。一幅图可以有许多个子图，每个子图属于某幅图，包含着许多元素。下列代码生成了一幅图像（不可见），具有一个空的子图：

``` python
import matplotlib.pyplot as plt
fig, ax = plt.subplots()
ax.plot()
```

输出：

<img src="图片\具有一个空的子图的图像.png" style="zoom:50%;" />

生成一幅包含 4 个空子图的图像

``` python
import matplotlib.pyplot as plt
fig, ax = plt.subplots(ncols=2, nrows=2)
plt.show()
```

![](图片\4个空子图的图像.png)

Matplotlib 有两种使用接口，一种是 pyplot 和 面向对象的接口（Object Oriented Interface, OOI）。

使用 pyplot：

``` python
import numpy as np
titles = ['upper left', 'upper right', 'lower left', 'lower right']
fig, axes = plt.subplots(ncols=2, nrows=2)
for title, ax in zip(titles, axes.flatten()):
    ax.set_title(title)
    # np.arange 代表 x 轴的数据，np.random.randint(0, 10, 10) 代表 y 轴的数据
    ax.plot(np.arange(10), np.random.randint(0, 10, 10))
    ax.set_yticks([0, 5, 10])
# 这会使子图之间有一个很好的空隙
fig.tight_layout()
```

![](图片\4 个子图（pyplot）.png)

使用面向对象：

``` python
import numpy as np
fig, axes = plt.subplots(ncols=2, nrows=2)
axes[0, 0].set_title('upper left')
axes[0, 0].plot(np.arange(10), np.random.randint(0, 10, 10))
axes[0, 1].set_title('upper right')
axes[0, 1].plot(np.arange(10), np.random.randint(0, 10, 10))
axes[1, 0].set_title('lower left')
axes[1, 0].plot(np.arange(10), np.random.randint(0, 10, 10))
axes[1, 1].set_title('lower right')
axes[1, 1].plot(np.arange(10), np.random.randint(0, 10, 10))
fig.tight_layout()
```

## 折线图

```python
import matplotlib.pyplot as plt
x = [1, 2, 3, 4, 5]
y = [2, 4, 6, 8, 10]
plt.plot(x, y)
plt.title('Minimal pyplot example')
plt.ylabel('some numbers')
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

