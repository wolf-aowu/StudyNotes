# PySide6

## 初识

### 创建空白窗口

下面这段代码会创建一个空白窗口。

```python
from PySide6.QtWidgets import QApplication, QWidget
# 导入 sys 模块是为了处理命令行传入的参数
import sys

# 创建一个应用程序对象，在使用 python 语句执行该文件时可以接受其他命令行参数
app = QApplication(sys.argv)
# Qt 窗口默认是隐藏的，所以需要使用 show 来显示
window = QWidget()
window.show()
# 启动事件循环，它会疯狂循环以捕捉事件
# 与 app.exec_() 一致，但 exec_ 方法不推荐使用，在之后的版本中会被舍弃
app.exec()
```

输出：

![](图片\PySide6\创建一个空白窗口.png)

### 设置窗口标题

```python
from PySide6.QtWidgets import QApplication, QMainWindow
import sys

app = QApplication(sys.argv)
window = QMainWindow()
# 设置窗口标题
window.setWindowTitle("This is window title")
window.show()
app.exec()
```

输出：

![](图片\PySide6\设置窗口标题.png)

### 创建按钮

``` python
from PySide6.QtWidgets import QApplication, QMainWindow, QPushButton
import sys

app = QApplication(sys.argv)
window = QMainWindow()
# 创建一个 button 对象
button = QPushButton()
# 也可以不使用 setText() 方法，直接在创建 QPushButton 时传入
# 例如：button = QPushButton("Press Me")
button.setText("Press Me")
# window 代表 button 会在这个 window 里
# 在窗口的中间创建 button
window.setCentralWidget(button)
window.show()
app.exec()
```

输出：

![](图片\PySide6\创建按钮.png)