# 官方 PySide6 视频笔记

视频网址：

https://www.bilibili.com/video/BV16d4y1s73t/?spm_id_from=333.999.0.0&vd_source=4137720edced5cb595fbae555e2d840f

## 创建一个窗口

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
app.exec()
```

输出：

![](图片\PySide6\创建一个空白窗口.png)

## 窗口中创建一个按钮

```python
from PySide6.QtWidgets import QApplication, QMainWindow, QPushButton
import sys

app = QApplication(sys.argv)
window = QMainWindow()
# 有了一个 button 对象
button = QPushButton()
button.setText("Press Me")
# window 代表 button 会在这个 window 里
window.setCentralWidget(button)
window.show()
app.exec()
```

输出：

![](图片\PySide6\ButtonHolder.png)

改进代码，将窗口和按钮整合到一个新的类（ButtonHolder）中：

```python
from PySide6.QtWidgets import QApplication, QMainWindow, QPushButton
import sys

# 创建一个名为 ButtonHoldeer 的类，继承于 QMainWindow
class ButtonHolder(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Button Holder app")
        button = QPushButton("Press Me!")
        self.setCentralWidget(button)

app = QApplication(sys.argv)
window = ButtonHolder()
window.show()
app.exec()
```

继续改进，将 ButtonHolder 类与主代码分开在不同的文件中：

button_holder.py

```python
from PySide6.QtWidgets import QMainWindow, QPushButton


class ButtonHolder(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Button Holder app")
        button = QPushButton("Press Me!")
        self.setCentralWidget(button)
```

main.py

```python
import sys
from PySide6.QtWidgets import QApplication
from button_holder import ButtonHolder

app = QApplication(sys.argv)
window = ButtonHolder()
window.show()
app.exec()
```

## 信号与响应

