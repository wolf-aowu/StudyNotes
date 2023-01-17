# PySide6

## 文档查询

官方文档网站：

1. 首页：https://doc.qt.io/

   可以通过 All Qt Documentation -> References and manuals -> Qt for Python 6.4 进入下方链接。

2. PySide6 首页：https://doc.qt.io/qtforpython-6/

3. PySide6 的 QtWidgets 模块首页：https://doc.qt.io/qtforpython-6/PySide6/QtWidgets/index.html#module-PySide6.QtWidgets

## QtWidgets.QWidget

一个普通的窗口，窗口上方没有菜单栏和工具栏，下方也没有状态栏。

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

### 创建滑条

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

### 设置滑条事件

参考网站：https://doc.qt.io/qtforpython-6/PySide6/QtWidgets/QAbstractSlider.html

![](图片\PySide6\Slider Signals.png)

#### valueChanged

![](图片\PySide6\QSlider valueChanged.png)

### 组件布局

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

## QtWidgets.QMainWindow

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

## QtWidgets.QPushButton

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

### 设置按钮事件

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

### 设置按钮区分按下和弹起两个状态

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

## QtWidgets.QMessageBox

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

## QtWidgets.QLabel

QLabel 官方文档：https://doc.qt.io/qtforpython/PySide6/QtWidgets/QLabel.html

### 创建 label

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

### 重新设置 label

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

### 显示图片

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

## QtWidgets.QEditLine

QEditLine 官方文档：https://doc.qt.io/qtforpython/PySide6/QtWidgets/QLineEdit.html

### 创建单行输入框

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

### 设置单行输入框事件

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

## QtWidgets.QTextEdit

QTextEdit 官方文档：https://doc.qt.io/qtforpython/PySide6/QtWidgets/QTextEdit.html

### 获取文本编辑器的内容作为纯文本

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

### 文本编辑器内置事件

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

