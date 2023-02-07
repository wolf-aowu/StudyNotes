# PySide6

## 文档查询

官方文档网站：

1. 首页：https://doc.qt.io/

   可以通过 All Qt Documentation -> References and manuals -> Qt for Python 6.4 进入下方链接。

2. PySide6 首页：https://doc.qt.io/qtforpython-6/

3. PySide6 的 QtWidgets 模块首页：https://doc.qt.io/qtforpython-6/PySide6/QtWidgets/index.html#module-PySide6.QtWidgets

   谷歌快速搜索：PySide6 模块名

4. 如果 PySide6 的 Python 文档写的不够详细，可以看 PySide6 的 C++ 文档：https://doc.qt.io/qt-6/classes.html

   谷歌快速搜索：模块名 qt6

## QtWidgets

### QtWidgets.QWidget

一个普通的窗口，窗口上方没有菜单栏和工具栏，下方也没有状态栏。

#### 创建空白窗口

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

#### 设置窗口标题

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

#### 创建滑条

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

```python
slider moved to: 26
slider moved to: 27
slider moved to: 28
slider moved to: 29
slider moved to: 30
```

#### 设置滑条事件

参考网站：https://doc.qt.io/qtforpython-6/PySide6/QtWidgets/QAbstractSlider.html

![](图片\PySide6\Slider Signals.png)

##### valueChanged

![](图片\PySide6\QSlider valueChanged.png)

#### 组件布局

```python
from PySide6.QtWidgets import QApplication, QPushButton, QWidget, QHBoxLayout, QVBoxLayout
import sys

def button1_clicked(self):
    print("Button1 clicked")

def button2_clicked(self):
    print("Button2 clicked")

app = QApplication(sys.argv)
widget = QWidget()
widget.setWindowTitle("RockWidget")

button1 = QPushButton("Button 1")
button1.clicked.connect(button1_clicked)
button2 = QPushButton("Button 2")
button2.clicked.connect(button2_clicked)

# 创建水平布局
widget_layout = QHBoxLayout()
# 创建垂直布局
# widget_layout = QVBoxLayout()
widget_layout.addWidget(button1)
widget_layout.addWidget(button2)
# 窗口设置布局
widget.setLayout(widget_layout)
widget.show()

app.exec()
```

输出：

水平布局

![](图片\PySide6\水平布局.png)

垂直布局

![](图片\PySide6\垂直布局.png)

### QtWidgets.QMainWindow

一个可以设置菜单栏、工具栏、状态栏的窗口。

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

### QtWidgets.QPushButton

#### 创建按钮

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

#### 设置按钮事件

按钮的事件可以通过查询 PySide6.QtWidgets 官方文档的 QPushButton -> QtWidgets.QAbstractButton -> Signals 得到。

参考链接：https://doc.qt.io/qtforpython-6/PySide6/QtWidgets/QAbstractButton.html

![](图片\PySide6\QPushButton Signals.png)

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

#### 设置按钮区分按下和弹起两个状态

``` python
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

#### 设置按钮拉伸后长度倍数

Widget.py

```python
from PySide6.QtWidgets import (
    QWidget,
    QPushButton,
    QHBoxLayout
)

class Widget(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("Size policies and stretches"
        
        button_1 = QPushButton("One")
        button_2 = QPushButton("Two")
        button_3 = QPushButton("Three")

        h_layout = QHBoxLayout()
        # 设置拉伸后按钮长度为 2 倍
        h_layout.addWidget(button_1, 2)
        h_layout.addWidget(button_2, 1)
        h_layout.addWidget(button_3, 1)

        self.setLayout(v_layout)
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

![](D:\Git 仓库\笔记\StudyNotes\Notes-Python\PyQt6 和 PySide6 库\图片\PySide6\QPushButton-设置按钮拉伸后长度倍数.png)

#### 按钮设置图标

使用 `QPushButton.setIcon()` 方法设置 `QIcon` 类型的图标。

Widget.ui

``` xml
<?xml version="1.0" encoding="UTF-8"?>
<ui version="4.0">
 <class>Widget</class>
 <widget class="QWidget" name="Widget">
  <property name="geometry">
   <rect>
    <x>0</x>
    <y>0</y>
    <width>400</width>
    <height>42</height>
   </rect>
  </property>
  <property name="windowTitle">
   <string>Form</string>
  </property>
  <layout class="QHBoxLayout" name="horizontalLayout">
   <item>
    <widget class="QPushButton" name="minus_button">
     <property name="text">
      <string>Minus</string>
     </property>
    </widget>
   </item>
   <item>
    <widget class="QSpinBox" name="spin_box"/>
   </item>
   <item>
    <widget class="QPushButton" name="plus_button">
     <property name="text">
      <string>Plus</string>
     </property>
    </widget>
   </item>
  </layout>
 </widget>
 <resources>
  <include location="resource.qrc"/>
 </resources>
 <connections/>
</ui>
```

resource.qrc

``` xml
<RCC>
  <qresource prefix="images">
    <file>minus.png</file>
    <file>plus.png</file>
  </qresource>
</RCC>
```

Widget.py

``` python
from PySide6.QtWidgets import QWidget
from PySide6.QtGui import QIcon
from ui_widget import Ui_Widget

class Widget(QWidget, Ui_Widget):
    def __init__(self):
        super().__init__()
        self.setupUi(self)
        self.setWindowTitle("User data")
        self.spin_box.setValue(50)
        self.plus_button.clicked.connect(self.plus)
        self.minus_button.clicked.connect(self.minus)

        # 加载图标
        plus_icon = QIcon(":/images/plus.png")
        minus_icon = QIcon(":/images/minus.png")

        # 为按钮设置图标
        self.plus_button.setIcon(plus_icon)
        self.minus_button.setIcon(minus_icon)

    def plus(self):
        value = self.spin_box.value()
        self.spin_box.setValue(value + 1)

    def minus(self):
        value = self.spin_box.value()
        self.spin_box.setValue(value - 1)
```

main.py

``` python
from PySide6.QtWidgets import QApplication
from UserInterface import Widget
import sys

app = QApplication(sys.argv)

widget = Widget()
widget.show()

app.exec()
```

输出：

![](图片\PySide6\创建和编译 qrc 文件.png)

改进：图标也不再在 Widget 类中设置了，而是直接在 Qt Designer 中设置。

选中 Qt Designer 中 Minus/Plus 按钮，在属性编辑器（Property Editor）中搜索 icon，在下拉菜单中，选择资源...，即可设置图标。<font color = orange>改完后需要重新编译 .ui 文件。</font>

### QtWidgets.QMessageBox

弹出消息框，消息框的类型可以分为：critical、question、information、warning、about。

QMessageBox 官方文档：https://doc.qt.io/qtforpython/PySide6/QtWidgets/QMessageBox.html

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

![](D:\Git 仓库\笔记\StudyNotes\Notes-Python\PyQt6 和 PySide6 库\图片\PySide6\消息框应用的主界面.png)

自定义消息框

![](D:\Git 仓库\笔记\StudyNotes\Notes-Python\PyQt6 和 PySide6 库\图片\PySide6\自定义消息框.png)

Critical

![](D:\Git 仓库\笔记\StudyNotes\Notes-Python\PyQt6 和 PySide6 库\图片\PySide6\Critical.png)

Question

![](D:\Git 仓库\笔记\StudyNotes\Notes-Python\PyQt6 和 PySide6 库\图片\PySide6\Question.png)

Information

![](D:\Git 仓库\笔记\StudyNotes\Notes-Python\PyQt6 和 PySide6 库\图片\PySide6\Information.png)

Warning

![](D:\Git 仓库\笔记\StudyNotes\Notes-Python\PyQt6 和 PySide6 库\图片\PySide6\Warning.png)

About

![](D:\Git 仓库\笔记\StudyNotes\Notes-Python\PyQt6 和 PySide6 库\图片\PySide6\About.png)

### QtWidgets.QLabel

QLabel 官方文档：https://doc.qt.io/qtforpython/PySide6/QtWidgets/QLabel.html

#### 创建 label

Widget.py

```python
from PySide6.QtWidgets import (
    QWidget,
    QLabel,
    QHBoxLayout
)

class Widget(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("QLabel and QLineEdit")

        label = QLabel("Fullname:")

        layout = QHBoxLayout()
        layout.addWidget(label)

        self.setLayout(layout)
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

![](图片\PySide6\创建 label.png)

#### 重新设置 label

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
        print("Fullname:", self.line_edit.text())
        # 重新设置 label
        self.text_holder_label.setText(self.line_edit.text())
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

![](图片\PySide6\重新设置 label.png)

#### 显示图片

此方法不支持 jpg 格式的图片，不能直接修改后缀名，需要使用专业软件将 jpg 格式转为 png 格式，路径支持中文。

Widget.py

``` python
from PySide6.QtGui import QPixmap
from PySide6.QtWidgets import QWidget, QLabel, QVBoxLayout


class Widget(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("QLabel Image")

        image_label = QLabel()
        # 可以使用中文路径，但不能使用 jpg
        image_label.setPixmap(QPixmap("图片\皮卡丘.png"))

        layout = QVBoxLayout()
        layout.addWidget(image_label)

        self.setLayout(layout)
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

![](图片\PySide6\QLabel 显示图片.png)

#### 设置拓展模式

通过 `label.setSizePolicy()` 方法设置 label 横向或纵向的拓展。`QSizePolicy.Fixed` 代表不随窗口拉伸变化大小。`QSizePolicy.Expanding` 代表跟随窗口拉伸变化大小。

`label.setSizePolicy()` 方法的默认值为 QSizePolicy.Fixed, QSizePolicy.Fixed。

Widget.py

```python
from PySide6.QtWidgets import (
    QWidget,
    QLabel,
    QLineEdit,
    QHBoxLayout,
    QSizePolicy,
)

class Widget(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("Size policies and stretches")

        label = QLabel("Some text: ")
        line_edit = QLineEdit()

        # QSizePolicy.Fixed 代表固定长度，不会跟随窗口大小变化
        # QSizePolicy.Expanding 代表跟随窗口大小变化
        # label.setSizePolicy 默认设置为 QSizePolicy.Fixed, QSizePolicy.Fixed
        # label.setSizePolicy(QSizePolicy.Fixed, QSizePolicy.Fixed)
        label.setSizePolicy(QSizePolicy.Expanding, QSizePolicy.Fixed)

        h_layout_1 = QHBoxLayout()
        h_layout_1.addWidget(label)
        h_layout_1.addWidget(line_edit)

        self.setLayout(h_layout_1)
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

默认：

![](图片\PySide6\QLabel-默认拓展.png)

水平拓展：

![](图片\PySide6\QLabel-水平拓展.png)

### QtWidgets.QEditLine

QEditLine 官方文档：https://doc.qt.io/qtforpython/PySide6/QtWidgets/QLineEdit.html

#### 创建单行输入框

Widget.py

```python
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
        button = QPushButton("Grab Data")
        button.clicked.connect(self.button_clicked)

        # 水平布局
        h_layout = QHBoxLayout()
        h_layout.addWidget(label)
        h_layout.addWidget(self.line_edit)

        # 垂直布局
        v_layout = QVBoxLayout()
        v_layout.addLayout(h_layout)
        v_layout.addWidget(button)

        self.setLayout(v_layout)

    def button_clicked(self):
        print("Fullname:", self.line_edit.text())
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

![](图片\PySide6\创建输入框.png)

```python
Fullname: 妈妈
```

#### 设置单行输入框事件

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

![](动图\QLineEdit-textChanged 事件.gif)

cursorPositionChanged：

![](动图\QLineEdit-cursorPositionChanged 事件.gif)

editingFinished：

![](动图\QLineEdit-editingFinished 事件.gif)

returnPressed：

![](动图\QLineEdit-returnPressed 事件.gif)

selectionChanged：

![](动图\QLineEdit-selectionChanged 事件.gif)

textEdited：

![](动图\QLineEdit-textEdited 事件.gif)

#### 设置拓展模式

Widget.py

```python
from PySide6.QtWidgets import (
    QWidget,
    QLabel,
    QLineEdit,
    QHBoxLayout,
    QSizePolicy
)

class Widget(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("Size policies and stretches")

        label = QLabel("Some text: ")
        line_edit = QLineEdit()
        # line_edit.setSizePolicy 默认设置为 QSizePolicy.Expanding, QSizePolicy.Fixed
        # QSizePolicy.Fixed 代表固定长度，不会跟随窗口大小变化
        # QSizePolicy.Expanding 代表跟随窗口大小变化
        # line_edit.setSizePolicy(QSizePolicy.Expanding, QSizePolicy.Fixed)
        # 水平与纵向都固定长度
        line_edit.setSizePolicy(QSizePolicy.Fixed, QSizePolicy.Fixed)
        # 水平与纵向都拓展
        # line_edit.setSizePolicy(QSizePolicy.Expanding, QSizePolicy.Expanding)

        h_layout_1 = QHBoxLayout()
        h_layout_1.addWidget(label)
        h_layout_1.addWidget(line_edit)

        self.setLayout(h_layout_1)
```

mian.py

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

默认：

![](图片\PySide6\QLineEdit-默认拓展.png)

固定长度：

![](图片\PySide6\QLineEdit-固定长度.png)

全拓展：

![](图片\PySide6\QLineEdit-全拓展.png)

### QtWidgets.QTextEdit

QTextEdit 官方文档：https://doc.qt.io/qtforpython/PySide6/QtWidgets/QTextEdit.html

#### 获取文本编辑器的内容作为纯文本

QTextEdit.toPlainText()

将文本编辑器的内容作为纯文本保存。当该属性被设置时，以前的内容被删除，撤销/重做历史被刷新。currentCharFormat() 也被重置，除非 textCursor() 已经在文档的开头。如果文本编辑有其他内容类型，如果你调用 toPlainText()，它将不会被替换成纯文本。唯一的例外是非断裂空间，`nbsp;`，它将被转换为标准空格。默认情况下，对于一个没有内容的编辑器，这个属性包含一个空字符串。

```python
class Widget(QWidget):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("QTextEdit")
        self.text_edit = QTextEdit()
        current_text_button = QPushButton("当前文本")
        current_text_button.clicked.connect(self.current_text_button_clicked)
        h_layout = QHBoxLayout()
        h_layout.addWidget(current_text_button)
        self.setLayout(h_layout)

	def current_text_button_clicked(self):
        print(self.text_edit.toPlainText())
```

输出：

![获取文本编辑器的内容作为纯文本](图片\PySide6\获取文本编辑器的内容作为纯文本.png)

输出：

```python
Today is a nice day.
I'm so happy.
```

#### 文本编辑器内置事件

Widget.py

``` python
from PySide6.QtWidgets import (
    QWidget,
    QTextEdit,
    QPushButton,
    QHBoxLayout,
    QVBoxLayout,
)

class Widget(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("QTextEdit")

        self.text_edit = QTextEdit()

        current_text_button = QPushButton("当前文本")
        current_text_button.clicked.connect(self.current_text_button_clicked)

        copy_button = QPushButton("复制")
        # 在官网的文档中 Slots 代表内置的事件，可以直接拿来用
        # 复制文本编辑器中选中的文本
        copy_button.clicked.connect(self.text_edit.copy)

        cut_button = QPushButton("剪切")
        cut_button.clicked.connect(self.text_edit.cut)

        paste_button = QPushButton("粘贴")
        paste_button.clicked.connect(self.text_edit.paste)

        undo_button = QPushButton("撤销")
        undo_button.clicked.connect(self.text_edit.undo)

        redo_button = QPushButton("恢复")
        redo_button.clicked.connect(self.text_edit.redo)

        # 显示自定义的纯文本内容
        set_plain_text_button = QPushButton("设置纯文本")
        set_plain_text_button.clicked.connect(self.set_plain_text)

        # 显示自定义的 html 格式内容
        set_html_button = QPushButton("设置 html")
        set_html_button.clicked.connect(self.set_html)

        clear_button = QPushButton("清空")
        # 删除文本编辑器中的所有文本，撤销于恢复操作的历史记录也会被删除
        clear_button.clicked.connect(self.text_edit.clear)

        h_layout = QHBoxLayout()
        h_layout.addWidget(current_text_button)
        h_layout.addWidget(copy_button)
        h_layout.addWidget(cut_button)
        h_layout.addWidget(paste_button)
        h_layout.addWidget(undo_button)
        h_layout.addWidget(redo_button)
        h_layout.addWidget(set_plain_text_button)
        h_layout.addWidget(set_html_button)
        h_layout.addWidget(clear_button)

        v_layout = QVBoxLayout()
        v_layout.addLayout(h_layout)
        v_layout.addWidget(self.text_edit)

        self.setLayout(v_layout)

    def current_text_button_clicked(self):
        # 将文本编辑器的内容作为纯文本保存
        # 当该属性被设置时，以前的内容被删除，撤销/重做历史被重置。
        # currentCharFormat() 也被重置，除非 textCursor() 已经在文档的开头。
        # 如果文本编辑有其他内容类型，如果你调用 toPlainText()，它将不会被替换成纯文本。
        # 唯一的例外是非断裂空间，nbsp;，它将被转换为标准空间。
        # 默认情况下，对于一个没有内容的编辑器，这个属性包含一个空字符串。
        print(self.text_edit.toPlainText())

    def set_plain_text(self):
        self.text_edit.setPlainText("Today is a nice day.\nI'm so happy.")

    def set_html(self):
        self.text_edit.setHtml(
            "<h1>daily</h1><p>Today is a nice day.\nI'm so happy.</p><ul><li>happy</li><li>wonderful</li></ul>"
        )
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

复制、粘贴、剪切:

![](动图\QTextEdit-复制粘贴剪切.gif)

撤销与恢复：

![](动图\QTextEdit-撤销恢复.gif)

设置纯文本：

![](图片\PySide6\QTextEdit-设置纯文本.png)

设置 html：

![](图片\PySide6\QTextEdit-设置html.png)

清空：

![](动图\QTextEdit-清空.gif)

### QtWidgets.QGridLayout

设置网格布局

可以将下面例子看成三行的三列的表格，行与列的索引都是从 0 开始。`grid_layout.addWidget(button_2, 0, 1, 1, 2)` 代表 button_2 从 (0,1) 开始，占用 1 行 2 列。

网格布局只设置控件的布局，但不影响控件本身的大小，控件的大小受控件的拓展设置影响。

Widget.py

``` python
from PySide6.QtWidgets import QWidget, QPushButton, QSizePolicy, QGridLayout


class Widget(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("QGridLayout Demo")

        button_1 = QPushButton("One")
        button_2 = QPushButton("Two")
        button_3 = QPushButton("Three")
        button_3.setSizePolicy(QSizePolicy.Expanding, QSizePolicy.Expanding)
        button_4 = QPushButton("Four")
        button_5 = QPushButton("Five")
        button_6 = QPushButton("Six")
        button_7 = QPushButton("Seven")

        grid_layout = QGridLayout()
        grid_layout.addWidget(button_1, 0, 0)
        grid_layout.addWidget(button_2, 0, 1, 1, 2)
        grid_layout.addWidget(button_3, 1, 0, 2, 1)
        grid_layout.addWidget(button_4, 1, 1)
        grid_layout.addWidget(button_5, 1, 2)
        grid_layout.addWidget(button_6, 2, 1)
        grid_layout.addWidget(button_7, 2, 2)

        self.setLayout(grid_layout)
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

如果不设置按钮拓展：

![](图片\PySide6\QGridLayout-不设置按钮拓展.png)

设置按钮拓展：

![](图片\PySide6\QGridLayout-设置按钮拓展.png)

### QtWidgets.QCheckBox

`QtWidgets.QCheckBox` 是复选框。它继承与 `QtWidgets.QAbstractButton`。

复选框可以设置单选也可以多选。

官方文档网址：https://doc.qt.io/qtforpython/PySide6/QtWidgets/QCheckBox.html

#### 创建多选复选框

使用 `QtWidgets.QGroupBox` 对复选框进行分组。`QtWidgets.QGroupBox` 接收 `QtWidgets.QVBoxLayout` 类型，不能将 `QtWidgets.QCheckBox` 作为 `Widget` 设置。

Widget.py

```python
from PySide6.QtWidgets import (
    QWidget,
    QGroupBox,
    QCheckBox,
    QHBoxLayout,
    QVBoxLayout,
)


class Widget(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("QCheckBox and QRadioButton")

        # 创建分组结构
        # 复选框
        os = QGroupBox("Choose operating system")
        windows = QCheckBox("Windows")
        windows.toggled.connect(self.windows_box_toggled)
        linux = QCheckBox("Linux")
        linux.toggled.connect(self.linux_box_toggled)
        mac = QCheckBox("Mac")
        mac.toggled.connect(self.mac_box_toggled)

        os_layout = QVBoxLayout()
        os_layout.addWidget(windows)
        os_layout.addWidget(linux)
        os_layout.addWidget(mac)
        os.setLayout(os_layout)

        h_layout = QHBoxLayout()
        h_layout.addWidget(os)

        v_layout = QVBoxLayout()
        v_layout.addLayout(h_layout)

        self.setLayout(v_layout)

    def windows_box_toggled(self, checked):
        if checked:
            print("Windows box checked")
        else:
            print("Windows box unchecked")

    def linux_box_toggled(self, checked):
        if checked:
            print("Linux box checked")
        else:
            print("Linux box unchecked")

    def mac_box_toggled(self, checked):
        if checked:
            print("Mac box checked")
        else:
            print("Mac box unchecked")
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

![](图片\PySide6\创建多选复选框.png)

#### 创建单选框

使用 `QtWidgets.QButtonGroup` 对复选框进行分组，并限制其只能单选。

使用 `QButtonGroup.setExclusive` 设置单选，True 为单选。当单选框被选择后，不能清空选择只能切换选择。

使用 `QCheckBox.setChecked` 设置是否为选中状态。

Widget.py

``` python
from PySide6.QtWidgets import (
    QWidget,
    QGroupBox,
    QCheckBox,
    QButtonGroup,
    QHBoxLayout,
    QVBoxLayout
)

class Widget(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("QCheckBox and QRadioButton")

        # 单选框
        drinks = QGroupBox("Choose your drink")
        beer = QCheckBox("Beer")
        juice = QCheckBox("juice")
        coffe = QCheckBox("coffe")
        beer.setChecked(True)

        exclusive_button_group = QButtonGroup(self)
        exclusive_button_group.addButton(beer)
        exclusive_button_group.addButton(juice)
        exclusive_button_group.addButton(coffe)
        exclusive_button_group.setExclusive(True)

        drink_layout = QVBoxLayout()
        drink_layout.addWidget(beer)
        drink_layout.addWidget(juice)
        drink_layout.addWidget(coffe)
        drinks.setLayout(drink_layout)

        h_layout = QHBoxLayout()
        h_layout.addWidget(drinks)

        v_layout = QVBoxLayout()
        v_layout.addLayout(h_layout)

        self.setLayout(v_layout)
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

![](图片\PySide6\创建单选复选框.png)

### QtWidgets.QRadioButton

官方文档网址：https://doc.qt.io/qtforpython/PySide6/QtWidgets/QRadioButton.html

#### 创建单选按钮

```python
from PySide6.QtWidgets import (
    QWidget,
    QGroupBox,
    QRadioButton,
    QVBoxLayout
)

class Widget(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("QCheckBox and QRadioButton")

        # 单选，圆点形式
        answers = QGroupBox("Choose Answer")
        answer_a = QRadioButton("A")
        answer_b = QRadioButton("B")
        answer_c = QRadioButton("C")
        answer_a.setChecked(True)

        answer_layout = QVBoxLayout()
        answer_layout.addWidget(answer_a)
        answer_layout.addWidget(answer_b)
        answer_layout.addWidget(answer_c)
        answers.setLayout(answer_layout)

        v_layout = QVBoxLayout()
        v_layout.addWidget(answers)

        self.setLayout(v_layout)
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

![](图片\PySide6\创建单选按钮.png)

### QtWidgets.QGroupBox

一种框架，顶部标题，支持快捷键，在其内部显示各种小部件。

官方文档网址：https://doc.qt.io/qtforpython/PySide6/QtWidgets/QGroupBox.html

### QtWidgets.QButtonGroup

`QtWidgets.QButtonGroup` 提供一个抽象容器，可以将按钮小部件放入其中。它不提供此容器的可视化表示，而是管理组中每个按钮的状态。

官方文档地址：https://doc.qt.io/qtforpython/PySide6/QtWidgets/QButtonGroup.html

### QtWidgets.QListWidget

#### 创建列表

使用 `QListWidget.setSelectionMode()` 方法可以设置选择模式，`QAbstractItemView.MultiSelection` 为可以同时选中多个。

使用 `QListWidget.addItem()` 可以向列表添加元素，如：`self.list_widget.addItem("One")`。使用 `QlistWidget.addItems()` 可以向列表添加多个元素，如：`self.list_widget.addItems(["Two", "Three"])`。

Widget.py

```python
from PySide6.QtWidgets import (
    QWidget,
    QListWidget,
    QAbstractItemView,
    QVBoxLayout
)

class Widget(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("QListWidget Demo")

        self.list_widget = QListWidget(self)
        # 可以选择多个
        self.list_widget.setSelectionMode(QAbstractItemView.MultiSelection)
        # 为列表添加元素
        self.list_widget.addItem("One")
        self.list_widget.addItems(["Two", "Three"])

        v_layout = QVBoxLayout()
        v_layout.addWidget(self.list_widget)
        
        self.setLayout(v_layout)
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

![](图片\PySide6\创建列表.png)

#### 设置列表事件

Widget.py

``` python
from PySide6.QtWidgets import (
    QWidget,
    QListWidget,
    QAbstractItemView,
    QVBoxLayout,
    QPushButton,
)

class Widget(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("QListWidget Demo")

        self.list_widget = QListWidget(self)
        # 可以选择多个
        self.list_widget.setSelectionMode(QAbstractItemView.MultiSelection)
        # 为列表添加元素
        self.list_widget.addItem("One")
        self.list_widget.addItems(["Two", "Three"])

        self.list_widget.currentItemChanged.connect(self.current_item_changed)
        self.list_widget.currentTextChanged.connect(self.current_text_changed)

        # 添加元素
        button_add_item = QPushButton("Add Item")
        button_add_item.clicked.connect(self.add_item)
		# 删除元素
        button_delete_item = QPushButton("Delete Item")
        button_delete_item.clicked.connect(self.delete_item)
		# 获取元素个数
        button_item_count = QPushButton("Item count")
        button_item_count.clicked.connect(self.item_count)
		# 获取选中的元素
        button_selected_items = QPushButton("Selected Items")
        button_selected_items.clicked.connect(self.selected_items)

        v_layout = QVBoxLayout()
        v_layout.addWidget(self.list_widget)
        v_layout.addWidget(button_add_item)
        v_layout.addWidget(button_delete_item)
        v_layout.addWidget(button_item_count)
        v_layout.addWidget(button_selected_items)

        self.setLayout(v_layout)

    def current_item_changed(self, item):
        if item is None:
            print("Current item is None")
        else:
            print("Current item:", item.text())

    def current_text_changed(self, text):
        print("Current text changed:", text)

    def add_item(self):
        self.list_widget.addItem("New Item")

    def delete_item(self):
        self.list_widget.takeItem(self.list_widget.currentRow())

    def item_count(self):
        print("Item count:", self.list_widget.count())

    def selected_items(self):
        list = self.list_widget.selectedItems()
        for i in list:
            print(i.text())
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

添加元素：

![](动图\QListWidget-添加元素.gif)

删除元素

![](动图\QListWidget-删除元素.gif)

获取选中的元素

![](动图\QListWidget-获取选中元素.gif)

### QtWidgets.QTabWidget

#### 创建页签窗口

Widget.py

``` python
from PySide6.QtWidgets import (
    QWidget,
    QTabWidget,
    QLabel,
    QLineEdit,
    QHBoxLayout,
    QVBoxLayout,
    QPushButton
)

class Widget(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("QTabWidget Demo")

        # 创建一个 Tab，并设定其父窗口
        tab_Widget = QTabWidget(self)

        # Information
        widget_form = QWidget()
        label_full_name = QLabel("Full name: ")
        line_edit_full_name = QLineEdit()
        form_layout = QHBoxLayout()
        form_layout.addWidget(label_full_name)
        form_layout.addWidget(line_edit_full_name)
        widget_form.setLayout(form_layout)

        # Buttons
        widget_buttons = QWidget()
        button_1 = QPushButton("One")
        button_1.clicked.connect(self.button_1_clicked)
        button_2 = QPushButton("Two")
        button_3 = QPushButton("Three")
        buttons_layout = QVBoxLayout()
        buttons_layout.addWidget(button_1)
        buttons_layout.addWidget(button_2)
        buttons_layout.addWidget(button_3)
        widget_buttons.setLayout(buttons_layout)

        tab_Widget.addTab(widget_form, "Information")
        tab_Widget.addTab(widget_buttons, "Button")

        layout = QVBoxLayout()
        layout.addWidget(tab_Widget)

        self.setLayout(layout)

    def button_1_clicked(self):
        print("Button clicked")
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

Information：

![创建页签窗口-Information](图片\PySide6\创建页签窗口-Information.png)

Button：

![](图片\PySide6\创建页签窗口-Button.png)

### QtWidgets.QComboBox

#### 创建下拉框

Widget.py

``` python
from PySide6.QtWidgets import QWidget, QComboBox, QVBoxLayout, QPushButton

class Widget(QWidget):
    def __init__(self):
        super().__init__()

        self.setWindowTitle("QComboBox Demo")

        self.combo_box = QComboBox(self)
        self.combo_box.addItem("Earth")
        self.combo_box.addItem("Venus")
        self.combo_box.addItem("Mars")
        self.combo_box.addItem("Pluton")
        self.combo_box.addItem("Saturn")

        button_current_value = QPushButton("Current value")
        button_current_value.clicked.connect(self.current_value)
        button_set_current = QPushButton("Set value")
        button_set_current.clicked.connect(self.set_current)
        button_get_values = QPushButton("Get values")
        button_get_values.clicked.connect(self.get_values)

        v_layout = QVBoxLayout()
        v_layout.addWidget(self.combo_box)
        v_layout.addWidget(button_current_value)
        v_layout.addWidget(button_set_current)
        v_layout.addWidget(button_get_values)

        self.setLayout(v_layout)

    def current_value(self):
        print(
            "Current item:",
            self.combo_box.currentText(),
            "- current index:",
            self.combo_box.currentIndex(),
        )

    def set_current(self):
        self.combo_box.setCurrentIndex(2)

    def get_values(self):
        for i in range(self.combo_box.count()):
            print("index [", i, "]:", self.combo_box.itemText(i))
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

![](图片\PySide6\创建下拉框1.png)

![](图片\PySide6\创建下拉框2.png)

``` python
# 按了 Current value 按钮
Current item: Earth - current index: 0
# 选择 Saturn 后，按了 Current value 按钮
Current item: Saturn - current index: 4
# 按了 Set value 按钮后，下拉框的值变为 Mars
# 按了 Get values 按钮后
index [ 0 ]: Earth
index [ 1 ]: Venus
index [ 2 ]: Mars
index [ 3 ]: Pluton
index [ 4 ]: Saturn
```

## QtUiTools

### QtUiTools.QUiLoader

加载用 Qt Designer 创建的 .ui 文件。

#### 加载 .ui 文件

.ui 文件是使用 Qt Designer 编辑器编辑窗口布局保存后产生的文件。使用 `QUiLoader.load()` 函数可以加载 .ui 文件。此函数会在每次程序运行时将 .ui 文件转换为 .py 文件，很耗性能，所以不推荐这么做。

main.py

``` python
import sys
from PySide6 import QtWidgets
from PySide6.QtUiTools import QUiLoader

def do_something():
    print(window.full_name_line_edit.text(), "is a", window.occupation_line_edit.text())

# 创建一个加载对象
loader = QUiLoader()

app = QtWidgets.QApplication(sys.argv)
# 加载使用 Qt designer 编辑器创建的 .ui 文件
window = loader.load("Widget.ui", None)

window.setWindowTitle("User data")

window.submit_button.clicked.connect(do_something)
window.show()
app.exec()
```

Widget.ui

```xml
<?xml version="1.0" encoding="UTF-8"?>
<ui version="4.0">
 <class>Form</class>
 <widget class="QWidget" name="Form">
  <property name="geometry">
   <rect>
    <x>0</x>
    <y>0</y>
    <width>477</width>
    <height>127</height>
   </rect>
  </property>
  <property name="windowTitle">
   <string>Form</string>
  </property>
  <layout class="QVBoxLayout" name="verticalLayout">
   <item>
    <layout class="QHBoxLayout" name="horizontalLayout">
     <property name="spacing">
      <number>6</number>
     </property>
     <item>
      <widget class="QLabel" name="full_name">
       <property name="text">
        <string>Full name: </string>
       </property>
      </widget>
     </item>
     <item>
      <widget class="QLineEdit" name="full_name_line_edit">
       <property name="layoutDirection">
        <enum>Qt::RightToLeft</enum>
       </property>
      </widget>
     </item>
    </layout>
   </item>
   <item>
    <layout class="QHBoxLayout" name="horizontalLayout_2">
     <property name="spacing">
      <number>6</number>
     </property>
     <item>
      <widget class="QLabel" name="occupation">
       <property name="text">
        <string>Occupation: </string>
       </property>
      </widget>
     </item>
     <item>
      <widget class="QLineEdit" name="occupation_line_edit">
       <property name="layoutDirection">
        <enum>Qt::RightToLeft</enum>
       </property>
       <property name="autoFillBackground">
        <bool>false</bool>
       </property>
       <property name="text">
        <string/>
       </property>
       <property name="alignment">
        <set>Qt::AlignLeading|Qt::AlignLeft|Qt::AlignVCenter</set>
       </property>
      </widget>
     </item>
    </layout>
   </item>
   <item>
    <widget class="QPushButton" name="submit_button">
     <property name="text">
      <string>Submit</string>
     </property>
    </widget>
   </item>
  </layout>
 </widget>
 <resources/>
 <connections/>
</ui>
```

输出：

![](图片\PySide6\加载 ui 文件.png)

改进代码：

将加载 .ui 文件重新封装一个类。

UserInterface.py

``` python
from PySide6 import QtCore
from PySide6.QtUiTools import QUiLoader

loader = QUiLoader()

# 继承 QtCore.QObject，为了能够使用 Signal 和 Slot
class UserInterface(QtCore.QObject):
    def __init__(self):
        super().__init__()
        self.ui = loader.load("Widget.ui", None)
        self.ui.setWindowTitle("User Data")
        self.ui.submit_button.clicked.connect(self.do_something)

    def show(self):
        self.ui.show()

    def do_something(self):
        print(
            self.ui.full_name_line_edit.text(),
            "is a",
            self.ui.occupation_line_edit.text(),
        )
```

main.py

``` python
import sys
from PySide6 import QtWidgets
from UserInterface import UserInterface

app = QtWidgets.QApplication(sys.argv)
window = UserInterface()
window.show()
app.exec()
```

## 编译 .ui 文件

在 Terminal 中输入 `pyside6-uic Widget.ui > ui_Widget.py`，即 `pyside6-uic .ui文件名 > .py文件名`，可将 .ui 文件转换为 .py 文件。

生成的 .py 文件使用的字符集是 UTF-16，而我们代码通常是 UTF-8 的，这会导致出现报错 `ValueError: source code string cannot contain null bytes`。

解决方法：

将生成的 .py 文件另存为 UTF-8 的字符集。

Visual Studio Code 另存方法：

单击下面状态栏 UTF-16 -> Save with Encoding（通过编码保存）-> UTF-8

![](图片\PySide6\UTF-16 转 UTF-8.png)

生成的 .py 文件中的类名由 Qt Designer 编辑器中根节点的 objectName 来决定：Ui_根节点的 objectName

如果想要调用生成 .py 文件，参考下面例子：

Widget.ui

``` xml
<?xml version="1.0" encoding="UTF-8"?>
<ui version="4.0">
 <class>Widget</class>
 <widget class="QWidget" name="Widget">
  <property name="geometry">
   <rect>
    <x>0</x>
    <y>0</y>
    <width>477</width>
    <height>127</height>
   </rect>
  </property>
  <property name="windowTitle">
   <string>Form</string>
  </property>
  <layout class="QVBoxLayout" name="verticalLayout">
   <item>
    <layout class="QHBoxLayout" name="horizontalLayout">
     <property name="spacing">
      <number>6</number>
     </property>
     <item>
      <widget class="QLabel" name="full_name">
       <property name="text">
        <string>Full name: </string>
       </property>
      </widget>
     </item>
     <item>
      <widget class="QLineEdit" name="full_name_line_edit">
       <property name="layoutDirection">
        <enum>Qt::RightToLeft</enum>
       </property>
      </widget>
     </item>
    </layout>
   </item>
   <item>
    <layout class="QHBoxLayout" name="horizontalLayout_2">
     <property name="spacing">
      <number>6</number>
     </property>
     <item>
      <widget class="QLabel" name="occupation">
       <property name="text">
        <string>Occupation: </string>
       </property>
      </widget>
     </item>
     <item>
      <widget class="QLineEdit" name="occupation_line_edit">
       <property name="layoutDirection">
        <enum>Qt::RightToLeft</enum>
       </property>
       <property name="autoFillBackground">
        <bool>false</bool>
       </property>
       <property name="text">
        <string/>
       </property>
       <property name="alignment">
        <set>Qt::AlignLeading|Qt::AlignLeft|Qt::AlignVCenter</set>
       </property>
      </widget>
     </item>
    </layout>
   </item>
   <item>
    <widget class="QPushButton" name="submit_button">
     <property name="text">
      <string>Submit</string>
     </property>
    </widget>
   </item>
  </layout>
 </widget>
 <resources/>
 <connections/>
</ui>
```

生成的 ui_Widget.py

``` python
# -*- coding: utf-8 -*-

################################################################################
## Form generated from reading UI file 'Widget.ui'
##
## Created by: Qt User Interface Compiler version 6.4.1
##
## WARNING! All changes made in this file will be lost when recompiling UI file!
################################################################################

from PySide6.QtCore import (QCoreApplication, QDate, QDateTime, QLocale,
    QMetaObject, QObject, QPoint, QRect,
    QSize, QTime, QUrl, Qt)
from PySide6.QtGui import (QBrush, QColor, QConicalGradient, QCursor,
    QFont, QFontDatabase, QGradient, QIcon,
    QImage, QKeySequence, QLinearGradient, QPainter,
    QPalette, QPixmap, QRadialGradient, QTransform)
from PySide6.QtWidgets import (QApplication, QHBoxLayout, QLabel, QLineEdit,
    QPushButton, QSizePolicy, QVBoxLayout, QWidget)

class Ui_Widget(object):
    def setupUi(self, Widget):
        if not Widget.objectName():
            Widget.setObjectName(u"Widget")
        Widget.resize(477, 127)
        self.verticalLayout = QVBoxLayout(Widget)
        self.verticalLayout.setObjectName(u"verticalLayout")
        self.horizontalLayout = QHBoxLayout()
        self.horizontalLayout.setSpacing(6)
        self.horizontalLayout.setObjectName(u"horizontalLayout")
        self.full_name = QLabel(Widget)
        self.full_name.setObjectName(u"full_name")

        self.horizontalLayout.addWidget(self.full_name)

        self.full_name_line_edit = QLineEdit(Widget)
        self.full_name_line_edit.setObjectName(u"full_name_line_edit")
        self.full_name_line_edit.setLayoutDirection(Qt.RightToLeft)

        self.horizontalLayout.addWidget(self.full_name_line_edit)


        self.verticalLayout.addLayout(self.horizontalLayout)

        self.horizontalLayout_2 = QHBoxLayout()
        self.horizontalLayout_2.setSpacing(6)
        self.horizontalLayout_2.setObjectName(u"horizontalLayout_2")
        self.occupation = QLabel(Widget)
        self.occupation.setObjectName(u"occupation")

        self.horizontalLayout_2.addWidget(self.occupation)

        self.occupation_line_edit = QLineEdit(Widget)
        self.occupation_line_edit.setObjectName(u"occupation_line_edit")
        self.occupation_line_edit.setLayoutDirection(Qt.RightToLeft)
        self.occupation_line_edit.setAutoFillBackground(False)
        self.occupation_line_edit.setAlignment(Qt.AlignLeading|Qt.AlignLeft|Qt.AlignVCenter)

        self.horizontalLayout_2.addWidget(self.occupation_line_edit)


        self.verticalLayout.addLayout(self.horizontalLayout_2)

        self.submit_button = QPushButton(Widget)
        self.submit_button.setObjectName(u"submit_button")

        self.verticalLayout.addWidget(self.submit_button)


        self.retranslateUi(Widget)

        QMetaObject.connectSlotsByName(Widget)
    # setupUi

    def retranslateUi(self, Widget):
        Widget.setWindowTitle(QCoreApplication.translate("Widget", u"Form", None))
        self.full_name.setText(QCoreApplication.translate("Widget", u"Full name: ", None))
        self.occupation.setText(QCoreApplication.translate("Widget", u"Occupation: ", None))
        self.occupation_line_edit.setText("")
        self.submit_button.setText(QCoreApplication.translate("Widget", u"Submit", None))
    # retranslateUi
```

Widget.py

除了需要继承 QWidget 类，还要多继承一个 Ui_Widget 类，也就是刚转换出来的 .py 文件中的类。通过调用 `setupUi()` 方法初始化布局。

``` python
from PySide6.QtCore import Qt
from PySide6.QtWidgets import QWidget
from ui_Widget import Ui_Widget

class Widget(QWidget, Ui_Widget):
    def __init__(self):
        super().__init__()
        self.setupUi(self)
        self.setWindowTitle("User data")
        self.submit_button.clicked.connect(self.do_something)

    def do_something(self):
        print(self.full_name_line_edit.text(), "is a", self.occupation_line_edit.text())
```

main.py

``` python
import sys
from PySide6 import QtWidgets
from Widget import Widget

app = QtWidgets.QApplication(sys.argv)
window = Widget()
window.show()
app.exec()
```

输出：

![](图片\PySide6\加载 ui 文件.png)

## 创建 .qrc 文件

.qrc 文件中存放这项目中用到的图片，将它们作为资源保存。

在 Qt Designer 右下角的资源浏览器（Resource Browser）中，单击编辑资源图标 <img src="图片\PySide6\编辑资源.png" style="zoom: 67%;" />。

在打开的编辑资源窗口中，单击新建资源图标 <img src="图片\PySide6\新建资源文件.png" style="zoom:67%;" />。

单击添加前缀图标 <img src="图片\PySide6\添加前缀.png" style="zoom: 67%;" />。<font color = grass>作用应该是为资源分类？</font>

选中前缀，再单击添加文件图标 <img src="图片\PySide6\添加文件.png" style="zoom:67%;" />，导入项目中需要用到的资源。<font color = orange>注意</font>：资源路径不支持中文。

最后单击确定即可。

导入的图片路径可以直接通过选中资源浏览器中的资源右键 -> 复制路径。

## 编译 .qrc 文件

使用 `pyside6-rcc resource.qrc -o resource_rc.py` 命令可以将资源文件 .qrc 格式转换为 .py 文件，即 `pyside6-rcc .qrc文件名 -o 生成的.py文件名`。同样，也需要注意生成的 .py 文件是否是 UTF-16 的字符集，如果是需要将其改为 UTF-8。

