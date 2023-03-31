## 批处理脚本 bat

批处理脚本英文译为 BATCH，批处理文件后缀 bat 就取的前三个字母。批处理命令常与 Dos 命令混合使用。

### 基础命令

#### @

让执行窗口中不显示它后面这一行的命令本身。

#### echo

它是一个开关命令，有两种状态：打开和关闭。

`echo on` 打开回显，就是后面所有命令会显示命令本身。

`echo off` 关闭回显，后面所有命令都不显示命令本身。

#### ::

它是注释命令，与 `rem` 命令等效。它后面的内容在执行时不显示也不起作用。

#### pause

让当前程序进程暂停一下，并显示一行信息：请按任意键继续...。

#### : 和 goto

`:` 和 `goto` 是不可分开的。`:` 是一个标签，`goto` 是跳转命令。当程序运行到 `goto` 时将自动跳转到 `:` 定义的部分执行。

```shell
::此处省略其他代码
goto end
::此处省略其他代码
:end
```

#### %

它是批处理中的参数，也就是执行 bat 脚本时传入的参数。

```shell
::假设有一个脚本 test.bat
::则执行该脚本命令
test 参数1 参数2 参数3

::test.bat 内容
net use \%1\ipc$ %3 /u:"%2"
copy 11.BAT \%1\admin$\system32 /y
copy 13.BAT \%1\admin$\system32 /y
copy ipc2.BAT \%1\admin$\system32 /y
copy NWZI.EXE \%1\admin$\system32 /y
attrib \%1\admin$\system32\10.bat -r -h -s
```

#### if

它有三种用法。

##### 输入判断

```shell
::如果如参为空，则跳转到 usage
if "%1"=="" goto usage
::如果如参为 /?，则跳转到 usage
if "%1"=="/?" goto usage
::如果如参为 help，则跳转到 usage
if "%1"=="help" goto usage
```

##### 存在判断

```shell
::如果存在 AD.gif 则删除 AD.gif
if exist C:\Progra~1\Tencent\AD.gif del C:\Progra~1\Tencent\AD.gif

::判断不存在
if not exist C:\Progra~1\Tencent\AD.gif del C:\Progra~1\Tencent\AD.gif
```

##### 结果判断

```shell
::对源代码进行汇编
masm %1.asm
::判断前一个指令执行后的返回码，Dos 程序执行后都会返回返回码，如果返回码为 1，则执行 pause 和 edit 操作。如果返回码为 0，代表执行成功
if errorlevel 1 pause & edit %1.asm
::否则用 link 程序连接生成的 obj 文件
link %1.obj

::表示否定
masm %1.asm
if not errorlevel 1 link %1.obj
pause & edit %1.asm
```

也使用 `if...else...` 可改写成：

```shell
masm %1.asm
if exist %1.obj link %1.obj
else pause & edit %1.asm
```

#### call

用来从一个批处理脚本中调用另一个批处理脚本，也可以调用自身。

```shell
::假设与三个脚本名分别为 start.bat、10.bat 和 ipc.bat
::start.bat
::执行 10.bat 并传入参数 0
call 10.bat 0
::10.bat
echo %IPA%.%1 >HFIND.TMP
call ipc.bat IPCFind.txt
::ipc.bat
::用 ipc.bat 中的每一行的三个变量，对应代换 %%i、%%j 和 %%k。
for /f "tokens=1,2,3 delims= " %%i in (%1) do call HACK.bat %%i %%j %%k
```

#### find

用来在文件中搜索特定字符串，通常也作为条件判断的铺垫程序。

```shell
@echo off
::检查是否有冰河病毒的默认端口 7626 在活动中，并将结果写入 a.txt
netstat -a -n > a.txt
::使用 type 命令列出 a.txt 的内容，然受搜索 7626，如果存在则提示中了冰河病毒
type a.txt | find "7626" && echo "Congratulations! You have infected GLACIER!"
del a.txt
pause & exit
```



