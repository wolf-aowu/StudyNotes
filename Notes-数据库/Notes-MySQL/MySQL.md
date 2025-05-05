# 下载安装

## 下载

官方网站：https://www.mysql.com/

DOWNLOADS -> MySQL Community (GPL) Downloads » -> MySQL Installer for Windows

占用内存小的是联网下载，大的是将安装包下载至本地

推荐选择将安装包下载至本地

弹出登录页面 -> No thanks, just start my download（在下方小字）

## 安装

开启比较慢，将其他窗口缩小就能看见

我选择的是自定义安装

Custom -> 安装 MySQL Server 即可

后面都默认选项即可

注意记住自己的端口、Server Name 和 用户名密码

Port：3306；X Protocol Port：330060

Windows Service Name：MySQL80

用户名：root；密码：1234

## 配置环境变量

为了能够在命令行中自由的打开 MySQL 而不是需要去到 MySQL 安装目录下打开，我们需要配置环境变量

打开环境变量 -> 系统变量 -> Path -> 编辑 -> MySQL 安装位置\bin -> 确定 -> 确定

## 数据库运行原理

MySQL 分为服务器程序和客户端程序。MySQL 服务器程序的进程被称为 MySQL 数据库实例。服务器程序与客户端程序之间通信使用 TCP 协议，需要向操作系统申请一个端口号（0 ~ 65535）。服务器程序启动时默认申请 3306 端口号。

1. 启动服务器程序
2. 启动客户端程序，连接到服务器程序。
3. 在客户端程序中输入命令语句，将其作为请求发送给服务器程序。服务器程序在收到请求后根据请求操作数据，并将结果返回给客户端程序

## 命令写法的常识

只有一个英文字母的参数称为短形式的参数，使用前面需要加 `-`，例如 `-u`。有多个字母组成的参数称为长形式的参数，使用前面需要加 `--`。

## 重要目录和文件

### bin

MySQL 安装位置下的 bin 目录中存放着许多可执行文件。Windows 系统中没有提供像 UNIX 中那么多启动脚本。

这些可执行文件可以在终端中执行。

``` shell
# UNIX 中
# 相对路径
./bin/mysqld
# 或者通过绝对路径
/usr/local/mysql/bin/mysqld

# Windows 中
# 相对/绝对路径 即可执行可执行文件，目录使用 '\' 符号分割
# 配置过环境变量则不需要路径，文件名就可以执行可执行文件，例如
mysqld
```

#### UNIX 系统中的文件

##### mysqld

MySQL 服务器程序，运行这个脚本可以启动服务器进程。

##### mysqld_safe

间接调用 mysqld 并持续监控服务器的运行状态。当服务器进程出现错误时，它可以帮助重启服务器程序。它会将服务器程序的出错信息和其他争端信息输出到错误日志。出错日志默认写到一个以 `.err` 为扩展名的文件中，该文件位于 MySQL 的数据目录中。

##### mysql.server

它会间接调用 mysqld_safe。执行 mysql.server 时，需要在后面添加 start 参数才可以启动服务器程序。mysql.server 是一个链接文件，它对应的实际是 `../supportfiles/mysql.server`。

``` shell
# 启动服务器程序
mysql.server start
# 关闭服务器程序
mysql.server stop
```

通过源码安装或使用没有自动安装 mysql.server 脚本的安装包来安装时，需要手动安装这个脚本。

##### mysqld_multi

一台计算机上可以运行多个服务器实例。mysql_multi 可以启动或停止多个服务器进程，也能报告它们的运行状态。

## 启动服务器程序

在终端中直接执行 bin 目录下的服务器启动脚本。

``` shell
mysqld
```

在 Windows 系统中可以以服务的方式启动。

``` shell
# 有 -manual 表示 Windows 系统启动的时候不自动启动该服务
# 服务名默认是 MySQL
# 把 mysqld 注册为 Windows 服务
"完整的可执行文件路径" --install [-manual] [服务名]
# 启动服务
net start MySQL
```

## 关闭服务器程序

``` shell
net stop MySQL
```

## 自定义服务器进程监听地端口号

``` shell
mysqld -P端口号
```

## 启动客户端程序

启动客户端程序需要执行以下命令：

``` shell
mysql -h主机名 -u用户名 -p密码
```

-h：服务器进程坐在计算机的域名或者 IP 地支。如果服务器进程运行在本机，可以省略这个参数，或者写成 localhost 或 127.0.0.1。也可以写成 `--host=主机名` 的形式

-u：用户名。可以写成 `--user=用户名` 的形式。Windows 中，省略后默认地用户名是 ODBC，可以通过设置环境变量 USER 来添加一个默认用户名。UNIX 中，默认用户名是登录操作系统地用户名。

-p：密码。可以写成 `--password=密码` 的形式。<font color=skyblue>注意：</font>`-p` 后不能有空白字符。

上面这种方法会显示地展示密码，如果不希望密码被看见，可以 `-p` 后回车然后输入密码。

``` shell
mysql -h主机名 -u用户名 -p
```

如果服务器程序自定义了端口号，启动客户端程序时也需要配置

``` shell
mysql -h主机名 -u用户名 -P端口号 -p密码
```

## 关闭客户端程序

`quit` 或 `exit` 或 `\q`

