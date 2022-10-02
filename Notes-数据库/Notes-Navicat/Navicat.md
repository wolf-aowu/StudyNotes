# Navicat 安装

## 官网

http://www.navicat.com.cn/products

## 破解

### 方法一

#### 简介

通过编写脚本删除注册表中的值，实现试用期重置。

需要删除的值的路径：

1. 计算机 -> HKEY_CURRENT_USER -> Software -> PremiumSoft -> NavicatPremium -> Registration 16XCS（后 5 位可能不一样，但代码不影响，代码中以 Registration 作为关键字查找）下面所有的值都删除

2. 计算机 -> HKEY_CURRENT_USER -> Software -> Classes -> CSLID -> 不固定路径 -> Info

   很显然 不固定路径 大大加大了我们查找的难度，但是代码可以很快找到：

   创建一个 .bat 后缀的文件，文件名可以随便取，使用的是 dos 批命令语言

```shell
@echo off
for /f %%i in ('"REG QUERY "HKEY_CURRENT_USER\Software\Classes\CLSID" /s | findstr /e Info"') do (
    echo %%i
)
pause
```

#### 查看注册表

快捷键 `Win + R` ，输入 `regedit` 找到简介中的对应路径即可。

#### 破解

1. 创建一个 .bat 后缀的文件，文件名随意

2. 编辑 .bat 文件

   ```shell
   @echo off
   for /f %%i in ('"reg query "HKEY_CURRENT_USER\Software\Classes\CLSID" /s | findstr /e Info"') do (
       echo %%i
   )
   pause
   ```

   查看的路径输出是否符合且只有一条：HKEY_CURRENT_USER -> Software -> Classes -> CSLID -> 不固定路径 -> Info

3. 如果步骤 2 符合，则再次修改 .bat 文件。<font color = orange>如果不符合，请另寻他法。</font>

   ```shell
   @echo off
   for /f %%i in ('"reg query "HKEY_CURRENT_USER\Software\PremiumSoft\NavicatPremium" /s | findstr /l Registration"') do (
       reg delete %%i /va /f
   )
   
   for /f %%i in ('"reg query "HKEY_CURRENT_USER\Software\Classes\CLSID" /s | findstr /e Info"') do (
       reg delete %%i /va /f
   )
   ```

4. 保存 .bat 文件，双击执行。

5. 由于试用期只有 14 天，所以需要每隔 14 天执行一次，或者需要用时执行一下

#### 自动化（未经测试，还没到 14 天）

每 14 天都要手动执行一次，我个人觉得很麻烦，所以需要有一种方法能够在每次开机时或每隔 14 天自动执行。

搜索 计算机管理 -> 点击任务计划程序 -> 创建任务

可以看到一共有五个页签：常规、触发器、操作、条件、设置，我们一个个来设置：

常规：

名称：任务计划的名字，可以随意取名

下方 安全选项 -> 设置用户或组：默认应该是当前用户，如果就是在当前账户下运行 Navicat，就不需要改

选 只在用户登录时运行 即可，当然选下面一个选项也是可以的

触发器：

左下角 新建 -> 选择 每天 -> 右侧设置 每隔 13 天发生一次 -> 确定

操作：

左下角 新建 -> 操作 就选启动程序 -> 程序或脚本 就是破解的那个 .bat 脚本 -> 确定

条件不用动

设置：

勾选：

1. 允许按需运行任务
2. 如果过了计划开始时间，立即启动任务
3. 如果运行时间超过以下时间，停止任务（我改成了 1 小时）
4. 如果请求后任务还在运行，强行将其停止

点击确定，就完成啦！！！

如果不小心设置错了，可以在中间的 任务活动 那一栏，找到刚刚设置的任务名，双击，单击右边栏中的属性。

## 扩展

### dos 批命令语言

#### 学习网站

dos 批命令学习网站：https://blog.csdn.net/qq_26226375/article/details/122882619

官方文档：https://learn.microsoft.com/zh-cn/windows-server/administration/windows-commands/windows-commands

如果网址变更，可以在微软官网上部或最底部找 开发人员与 IT -> `Microsoft Learn` -> 文档 -> 产品目录 -> Windows -> 适用于 IT 专业人员的 Windows Server -> 下方 参考 -> Windows 内置命令

或者 搜索 reg 看到条目详情中有 windows-commands 的可以点击进入

微软官网网址：https://www.microsoft.com/zh-cn/

#### 破解脚本解读

注意：本解读需要有编程基础-循环，看不懂的朋友请自行网上查找资料。

---

`@` ：不显示 `@` 所在行的命令

`echo`：打印 `echo` 后的内容

`echo off`：不显示命令，但 `echo` 所打印的内容会显示

官方文档：https://learn.microsoft.com/zh-cn/windows-server/administration/windows-commands/echo

`pause`：停住命令行，按任意键后关闭命令行

不打开 echo off：

```shell
echo Hello World
pause
```

![](图片\不打开 echo off.png)

打开 echo off 后：

```shell
echo off
echo Hello World
pause
```

![](图片\打开 echo off.png)

可以发现除了命令 `echo off` 被输出了，其他命令都没有被输出，只有执行每条命令后的打印，如果执行的命令没有打印，就不会有任何输出。

在 `echo off` 前添加 `@` 看可以将 `echo off` 这条命令也不输出：

```shell
@echo off
echo Hello World
pause
```

![](图片\不打印 echo off.png)

`echo.`：显示空白行，`.` 前面不要加空格，否则显示的是 `.` 而不是空白行

```shell
@echo off
echo Hello World
echo.
pause
```

![](图片\echo 显示空白行.png)

for 循环框架：`for %%i in (命令 1) do (命令 2)`

官方文档：https://learn.microsoft.com/zh-cn/windows-server/administration/windows-commands/for

`%%i` ：变量，是命令 1 执行后的结果的一部分，通过 for 循环将所有结果取出。`%%i` 可以使用其他 25 个英文字母替换，区分大小写。

`命令 2`：可以不用到 `%%i`，需要通过循环重复执行的命令

获取某一路径下所有子项和条目

`reg query` 命令：返回下一层子项和项的列表，这些子项和项位于注册表中的指定子项下。

`reg query` 的参数 `/s`：指定以递归查询所有子项和值名称。

`reg query` 命令官方文档：https://learn.microsoft.com/zh-cn/windows-server/administration/windows-commands/reg-query

```shell
@echo off
for /f %%i in ('"reg query "HKEY_CURRENT_USER\Software\PremiumSoft\NavicatPremium" /s "') do (
    echo %%i
)
pause
```

![](图片\获取注册子项和条目.png)

`命令 1|命令 2`：管道，`|` 的左边命令 1 的输出结果将作为 `|` 右边命令 2 的输入

`findstr`：搜索文件中的文本模式。

`findstr` 的参数 `/l`：按字面处理搜索字符串。

`findstr` 的参数 `/e`：如果文本模式位于行尾，则匹配它。

```shell
@echo off

for /f %%i in ('"reg query "HKEY_CURRENT_USER\Software\PremiumSoft\NavicatPremium" /s | findstr /l Registration"') do (
    echo %%i
)
echo.
echo ====================

for /f %%i in ('"reg query "HKEY_CURRENT_USER\Software\Classes\CLSID" /s | findstr /e Info"') do (
    echo %%i
)
echo.
pause
```

查找 Info 时使用的是 `/e` 有两个原因：

1. 找的目标类型是子项。通过上张图不难看出项的输出是整个路径
2. 我们的搜索范围是所有子项和条目，但是条目中很有可能存在许多带 Info 的条目（可以将 `/e` 替换为 `/l` 试试）

所以使用行尾 `/e` 来匹配，大大减少错删的可能

![](图片\findstr.png)

事实得到的确实是我们需要的。

`reg delete`：删除注册表中的一个或一些项。

`reg delete` 的参数 `/va`：删除指定子项下的所有条目。 不会删除指定子项下的子项。

`reg delete` 的参数 `/f`：删除现有的注册表子项或条目，而不要求确认。

`reg delete` 命令官方文档：https://learn.microsoft.com/zh-cn/windows-server/administration/windows-commands/reg-delete

# 连接 MySQL

## 查看 MySQL 端口号

MySQL 安装时，有一个端口号。

默认 Port：3306；默认 X Protocol Port：330060

Windows Service Name：MySQL80

打开命令行，进入 MySQL 安装位置\bin 目录下，输入如下命令：

```shell
mysql -uroot -p
```

输入安装时设置的密码：1234

输入：

```mysql
show global variables like 'port';
```

## 新建连接

左上角连接 -> MySQL

一共有六个页签：常规、高级、数据库、SSL、SSH、HTTP

高级中可以设置位置，数据库应该可以添加数据库

常规：

连接名：随意取

主机：localhost

端口：MySQL 的端口号，默认 3306

用户名：MySQL 的用户名，默认 root

密码：MySQL 的密码，1234

