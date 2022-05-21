## Settings

File -> Settings

### 每行长度多少时，自动换行

Editor -> Code Style -> Hard wrap at ...

![](每行多少长度时自动换行.png)

### 脚本修改标志符显示

Editor -> General -> Editor Tabs -> Mark modifled (*)

![](脚本修改标志符显示.png)

### 自动保存

Apperance & Behavior -> System Settings -> Autosave

![](自动保存.png)

- Save files when switching to a different application or a built-in terminal

  在切换到不同的应用程序或内置终端时保存文件

- Synchronize external changes when switching to the IDE window or opening an editor tab

  在切换到IDE窗口或打开一个编辑器标签时，同步外部变化

### 命名规则

#### 单个设置

光标移至 有下划线的单词，点击行前的灯泡，Inspection: "Field can be made readonly" -> Configure inspection severity -> Do not show（由于使用了统一设置，没试过）

#### 统一设置

Editor -> Code Style -> C#

![](命名规则.png)

左上角 Enable ‘Inconsistent Naming’ Inspection，取消勾选，可以关闭脚本里有关命名不符合设置的规范提示。

常用格式选项：

- UpperCamelCase：首字符大写驼峰
- lowerCamelCase：首字符小写驼峰
- ALL_UPPER：全部大写
- Prefix：头部规则
- Suffix：尾部规则

常用选项：

- Instance field(private)：类的私有变量

例子：

想改类的私有变量命名规则，如 mCount。选中 Instance field(private)，在右下角 Prefix 处设置 m，Style 处设置 lowerCamelCase。

### 脚本保存后，Unity 后台是否自动刷新

Languages & Frameworks -> Unity Engine -> Automatically refresh assets in Unity

![](脚本保存后 Unity 自动刷新.png)