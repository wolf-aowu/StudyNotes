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

