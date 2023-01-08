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

## 信号与信号槽(signals and slots)

例如有一个按钮。当被按下时，它会发送一次信号。与此信号对应的信号槽每接收到一次该信号就会触发一次信号槽中的方法。

```python
from PySide6.QtWidgets import QApplication, QPushButton

def button_colicked():
    print("You clicked the button, didn't you!")

app = QApplication()
button = QPushButton("Press Me")
# clicked 是 QPushButton 的一个信号，当点击按钮时会发送 clicked 信号
# 其他信号可以通过查询 PySide6 QPushButton -> QtWidgets.QAbstractButton -> Signals
button.clicked.connect(button_colicked)
button.show()
app.exec()
```

设置获取按钮是否按下的状态

```python
from PySide6.QtWidgets import QApplication, QPushButton

# 不需要检查按钮是否被按下时，可以不设置传入参数 data
def button_colicked(data):
    print("You clicked the button, didn't you! checked:", data)

app = QApplication()
button = QPushButton("Press Me")
# 设置获取按钮状态，按下为 True，未按下为 False
button.setCheckable(True)
# 其他信号可以通过查询 PySide6 QPushButton -> QtWidgets.QAbstractButton -> Signals
button.clicked.connect(button_colicked)
button.show()
app.exec()
```

输出：

当按钮被按下时，data 为 True，当按钮被再次按下后复原后 data 为 False

```python
You clicked the button, didn't you! checked: True
You clicked the button, didn't you! checked: False
You clicked the button, didn't you! checked: True
You clicked the button, didn't you! checked: False
```

滑条相关信号与信号槽

```python
from PySide6.QtCore import Qt
from PySide6.QtWidgets import QApplication,QSlider

def respond_to_slider(data):
    print("slider moved to:",data)

app = QApplication()
# 设置横向滑条
slider = QSlider(Qt.Horizontal)
# 设置滑条的最小值和最大值
slider.setMinimum(1)
slider.setMaximum(100)
# 设置滑条的值
slider.setValue(25)
# 设置滑条滑动事件
slider.valueChanged.connect(respond_to_slider)
slider.show()
app.exec()
```

输出：

![](图片\PySide6\创建滑条.png)

## 水平和垂直组件布局

rock_widget.py

```python
from PySide6.QtWidgets import QPushButton, QWidget, QHBoxLayout, QVBoxLayout

class RockWidget(QWidget):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("RockWidget")

        button1 = QPushButton("Button 1")
        button1.clicked.connect(self.button1_clicked)
        button2 = QPushButton("Button 2")
        button2.clicked.connect(self.button2_clicked)

        # 创建水平布局
        widget_layout = QHBoxLayout()
        # 创建垂直布局
        # widget_layout = QVBoxLayout()
        widget_layout.addWidget(button1)
        widget_layout.addWidget(button2)

        # 窗口设置布局
        self.setLayout(widget_layout)

    def button1_clicked(self):
        print("Button1 clicked")

    def button2_clicked(self):
        print("Button2 clicked")
```

main.py

```python
from PySide6.QtWidgets import QApplication
from rock_widget import RockWidget
import sys

app = QApplication(sys.argv)

widget = RockWidget()
widget.show()

app.exec()
```

输出：

水平布局

![](图片\PySide6\水平布局.png)

垂直布局

![](图片\PySide6\垂直布局.png)

## 创建一个有菜单栏、工具栏和状态栏的窗口

main_window.py

```python
from PySide6.QtCore import QSize
from PySide6.QtGui import QAction, QIcon
from PySide6.QtWidgets import QMainWindow, QToolBar, QPushButton, QStatusBar

class MainWindow(QMainWindow):
    def __init__(self, app):
        super().__init__()
        self.app = app
        self.setWindowTitle("Custom MainWindow")

        # 创建菜单栏
        menu_bar = self.menuBar()
        # 在菜单栏中创建一个名为 File 的菜单
        file_menu = menu_bar.addMenu("&File")
        # 在 File 菜单下创建一个名为 Quit 的动作
        quit_action = file_menu.addAction("Quit")
        quit_action.triggered.connect(self.quit)

        edit_menu = menu_bar.addMenu("&Edit")
        edit_menu.addAction("Copy")
        edit_menu.addAction("Cut")
        edit_menu.addAction("Paste")
        edit_menu.addAction("Undo")
        edit_menu.addAction("Redo")

        menu_bar.addMenu("&Window")
        menu_bar.addMenu("&Setting")
        menu_bar.addMenu("&Help")

        # 创建工具栏
        toolBar = QToolBar("My Main toolbar")
        toolBar.setIconSize(QSize(16,16))
        self.addToolBar(toolBar)

        toolBar.addAction(quit_action)

        # 创建一个名为 Some Action 的动作
        action1 = QAction("Some Action",self)
        # 当鼠标悬停在工具栏的动作上时会在状态栏上显示
        action1.setStatusTip("Status message for some action")
        action1.triggered.connect(self.toolbar_button_click)
        toolBar.addAction(action1)

        # Some other action 在鼠标悬浮于动作上时显示
        action2 = QAction(QIcon("start.png"), "Some other action", self)
        action2.setStatusTip("Status message for some other action")
        action2.triggered.connect(self.toolbar_button_click)
        # 按下后不会自动弹起，需要再次点击
        action2.setCheckable(True)
        toolBar.addAction(action2)

        # 创建分割线
        toolBar.addSeparator()
        toolBar.addWidget(QPushButton("Click here"))

        # 状态栏
        self.setStatusBar(QStatusBar(self))

        button1 = QPushButton("Button 1")
        button1.clicked.connect(self.button1_clicked)
        self.setCentralWidget(button1)

    def button1_clicked(self):
        print("Clicked on button1")
    
    def toolbar_button_click(self):
        # 3 秒后消失
        self.statusBar().showMessage(f"Some message ...", 3000)

    def quit(self):
        self.app.quit() 
```

main.py

```python
from PySide6.QtWidgets import QApplication
from main_window import MainWindow
import sys

app = QApplication(sys.argv)

widget = MainWindow(app)
widget.show()

app.exec()
```

输出：

![](图片\PySide6\MainWindow.png)

## 消息框

Widget.py

```python
from PySide6.QtWidgets import QWidget, QPushButton, QVBoxLayout, QMessageBox

class Widget(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("QMessageBox")
        # 消息框类型：critical、question、information、warning、about
        button_hard = QPushButton("Hard")
        # 创建对应消息框按钮，并触发
        button_hard = QPushButton("Hard")
        button_hard.clicked.connect(self.button_clicked_hard)
        button_critical = QPushButton("Critical")
        button_critical.clicked.connect(self.button_clicked_critical)
        button_question = QPushButton("Question")
        button_question.clicked.connect(self.button_clicked_question)
        button_information = QPushButton("Information")
        button_information.clicked.connect(self.button_clicked_information)
        button_warning = QPushButton("Warning")
        button_warning.clicked.connect(self.button_clicked_warning)
        button_about = QPushButton("About")
        button_about.clicked.connect(self.button_clicked_about)

        # 设置布局，否则看不见上面设置的按钮
        layout = QVBoxLayout()
        layout.addWidget(button_hard)
        layout.addWidget(button_critical)
        layout.addWidget(button_question)
        layout.addWidget(button_information)
        layout.addWidget(button_warning)
        layout.addWidget(button_about)
        self.setLayout(layout)

    # 可自定义的部分更多的写法
    def button_clicked_hard(self):
        message = QMessageBox()
        # 设置消息框最小尺寸
        message.setMinimumSize(700, 200)
        message.setWindowTitle("Message Title")
        # 设置文字
        message.setText("Something happened!")
        # 设置信息性文字
        message.setInformativeText("Do you want to do something about it?")
        # 控制消息框类型以改变图标
        message.setIcon(QMessageBox.Critical)
        message.setStandardButtons(QMessageBox.Ok | QMessageBox.Cancel)
        # 设置默认按钮，会被默认打开或突出显示
        message.setDefaultButton(QMessageBox.Ok)
        # 将消息框弹出，返回用户的选择
        ret = message.exec()
        if ret == QMessageBox.Ok:
            print("User chose OK")
        else:
            print("User chose Cancel")

    # 更方便的写法
    def button_clicked_critical(self):
        # 创建重要级别的消息框
        ret = QMessageBox.critical(
            self,
            "Message Title",
            "Critical Message!",
            QMessageBox.Ok | QMessageBox.Cancel,
        )
        if ret == QMessageBox.Ok:
            print("User chose OK")
        else:
            print("User chose Cancel")

    def button_clicked_question(self):
        # 创建重要级别的消息框
        ret = QMessageBox.question(
            self,
            "Message Title",
            "Question Message!",
            QMessageBox.Ok | QMessageBox.Cancel,
        )
        if ret == QMessageBox.Ok:
            print("User chose OK")
        else:
            print("User chose Cancel")

    def button_clicked_information(self):
        # 创建重要级别的消息框
        ret = QMessageBox.information(
            self,
            "Message Title",
            "Some information!",
            QMessageBox.Ok | QMessageBox.Cancel,
        )
        if ret == QMessageBox.Ok:
            print("User chose OK")
        else:
            print("User chose Cancel")

    def button_clicked_warning(self):
        # 创建重要级别的消息框
        ret = QMessageBox.warning(
            self,
            "Message Title",
            "Some Warning!",
            QMessageBox.Ok | QMessageBox.Cancel,
        )
        if ret == QMessageBox.Ok:
            print("User chose OK")
        else:
            print("User chose Cancel")

    def button_clicked_about(self):
        # 创建重要级别的消息框
        ret = QMessageBox.about(self, "Message Title", "Some about message!")
        if ret == QMessageBox.Ok:
            print("User chose OK")
        else:
            print("User chose Cancel")
```

main.py

```python
from PySide6.QtWidgets import QApplication
from Widget import Widget
import sys

app = QApplication(sys.argv)

widget = Widget()
widget.show()

app.exec()
```

输出：

主界面

![](图片\PySide6\消息框应用的主界面.png)

自定义消息框

![](图片\PySide6\自定义消息框.png)

Critical

![](图片\PySide6\Critical.png)

Question

![](图片\PySide6\Question.png)

Information

![](图片\PySide6\Information.png)

Warning

![](图片\PySide6\Warning.png)

About

![](图片\PySide6\About.png)

## 按钮的各种事件

Widget.py

```python
from PySide6.QtWidgets import QWidget, QPushButton, QVBoxLayout, QMessageBox

class Widget(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("Custom MainWindow")

        button = QPushButton("Click")
        # 按钮被按下后释放且释放时鼠标在按钮区域内时触发
        button.clicked.connect(self.button_clicked)
        # 按钮被按下时触发
        button.pressed.connect(self.button_pressed)
        # 按钮被释放时触发
        button.released.connect(self.button_released)

        layout = QVBoxLayout()
        layout.addWidget(button)

        self.setLayout(layout)

    def button_clicked(self):
        print("Clicked")

    def button_pressed(self):
        print("Pressed")

    def button_released(self):
        print("Released")
```

main.py

``` python
from PySide6.QtWidgets import QApplication
from Widget import Widget
import sys

app = QApplication(sys.argv)

widget = Widget()
widget.show()

app.exec()
```

输出：

![](图片\PySide6\QPushButton.png)

## 标签和单行输入框的各种事件

Widget.py

``` python
from PySide6.QtWidgets import (
    QWidget,
    QLabel,
    QLineEdit,
    QPushButton,
    QHBoxLayout,
    QVBoxLayout,
)

class Widget(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("QLabel and QLineEdit")

        label = QLabel("Fullname:")
        # line_edit 设置为成员变量，因为想要在实例化 Widget 对象时能够被访问
        self.line_edit = QLineEdit()
        # 文本发生变动时触发
        self.line_edit.textChanged.connect(self.text_changed)
        # 光标位置发生变动时触发
        self.line_edit.cursorPositionChanged.connect(self.cursor_position_changed)
        # 当用户按下回车 或者 行编辑失去焦点且自上次发出此信号后内容已更改 会触发
        # 所以，editingFinished 一般用的比 returnPressed 更多
        self.line_edit.editingFinished.connect(self.editing_finished)
        # 当用户按下回车时触发
        self.line_edit.returnPressed.connect(self.return_pressed)
        # 选中文本时触发,只要在鼠标聚焦于文本框且发生移动就会触发
        self.line_edit.selectionChanged.connect(self.selection_changed)
        # 当编辑文本时触发,如果通过程序改变文本则不会触发
        self.line_edit.textEdited.connect(self.text_edited)
        button = QPushButton("Grab Data")
        button.clicked.connect(self.button_clicked)
        self.text_holder_label = QLabel("I AM HERE")

        h_layout = QHBoxLayout()
        h_layout.addWidget(label)
        h_layout.addWidget(self.line_edit)

        v_layout = QVBoxLayout()
        v_layout.addLayout(h_layout)
        v_layout.addWidget(button)
        v_layout.addWidget(self.text_holder_label)

        self.setLayout(v_layout)

    def button_clicked(self):
        # 重新设置 label
        self.text_holder_label.setText(self.line_edit.text())

    def text_changed(self):
        self.text_holder_label.setText(self.line_edit.text())

    def cursor_position_changed(self, old, new):
        print("cursor old position:", old)
        print("cursor new position:", new)

    def editing_finished(slef):
        print("Editing finished")

    def return_pressed(self):
        print("Return pressed")

    def selection_changed(self):
        # 获取选中的文本内容
        print("Selection Changed:", self.line_edit.selectedText())

    def text_edited(self, new_text):
        print("Text edited. New text:", new_text)
```

main.py

``` python
from PySide6.QtWidgets import QApplication
from Widget import Widget
import sys

app = QApplication(sys.argv)

widget = Widget()
widget.show()

app.exec()
```

输出：

textChanged：

![](D:\Git 仓库\笔记\StudyNotes\Notes-Python\PyQt6 和 PySide6 库\动图\QLineEdit-textChanged 事件.gif)

cursorPositionChanged：

![](D:\Git 仓库\笔记\StudyNotes\Notes-Python\PyQt6 和 PySide6 库\动图\QLineEdit-cursorPositionChanged 事件.gif)

editingFinished：

![](D:\Git 仓库\笔记\StudyNotes\Notes-Python\PyQt6 和 PySide6 库\动图\QLineEdit-editingFinished 事件.gif)

returnPressed：

![](D:\Git 仓库\笔记\StudyNotes\Notes-Python\PyQt6 和 PySide6 库\动图\QLineEdit-returnPressed 事件.gif)

selectionChanged：

![](D:\Git 仓库\笔记\StudyNotes\Notes-Python\PyQt6 和 PySide6 库\动图\QLineEdit-selectionChanged 事件.gif)

textEdited：

![](D:\Git 仓库\笔记\StudyNotes\Notes-Python\PyQt6 和 PySide6 库\动图\QLineEdit-textEdited 事件.gif)

