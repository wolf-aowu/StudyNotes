## Jenkins

官方网址：https://www.jenkins.io/

### 安装

#### 前置条件

需要安装 Java 11 或 17

可以通过 `java --version` 查看当前安装的 Java 版本

下载地址：https://www.oracle.com/cn/java/technologies/downloads/

#### 安装

1. next

2. 选择安装位置 -> next

3. 选择服务登录凭据 -> 自己用的话选择 Run Service as LocalSystem 即可

4. 设置端口 -> 如果被占了换一个即可

   端口号范围：https://www.cnblogs.com/happykoukou/p/6655852.html

5. 设置安装的 java 位置，一般会自动识别

6. 自定义设置 -> next

7. Install

8. Finish

可以搜索服务（Services）找到 Jenkins 来验证是否安装成功。

#### 修改 Jenkins 主目录

<font color = orange>注意：</font>修改主目录会导致需要重新创建管理员账户。

打开 Jenkins 安装位置，找到 jenkins.xml 文件

修改 `<env name="JENKINS_HOME" value="%ProgramData%\Jenkins"/>`

#### 创建管理员账户

1. 打开浏览器，输入 `http://localhost:安装时的端口号`，如：`http://localhost:8080`
2. 根据出现的提示打开对应的文件夹路径，打开 initialAdminPassword 文件，复制其中的内容，粘贴到文本框中。
3. 安装插件，一般选择安装推荐的插件
4. 设置管理员账户和密码
5. 设置 URL，默认即可
6. 完成

### 插件

#### version Number

这个插件可以设置版本号自增。在创建任务 -> 构建环境 -> Create a formatted version number 中进行设置。

### 创建任务

1. 新建 Item -> Freestyle project

2. 勾选 Discard old builds 定期清理构建

3. 勾选 This project is parameterized 创建变量，如在命令行中需要用到的变量

4. 勾选 Build periodically 可以使项目定期构建

5. 勾选 Create a formatted version number 使项目的版本号进行自增（需要安装 version Number 插件）

6. 设置构建步骤 -> Execute Windows batch command（执行 Windows 批处理命令）

   也就是执行用来出包的脚本。

   ```shell
   ::进入 bat 文件目录
   D:
   cd D:\GameMadeInMe\Flappy Bird
   ::执行 bat 文件 并传入设置的变量
   build.bat %exeName% %version%
   ```

7. 构建后操作 -> Archive the artifacts（归档工件）可以在 Jenkins 上下载构建出来的文件。

#### 配置

##### 构建触发器

###### Build periodically

共有五个值，分别代表：

- 一小时中的分中（0-59）
- 一天中的小时（0-23）
- 一个月中的天数（1-31）
- 一年中的月份（1-12）
- 一周中的星期几（0-7，0 和 7 都代表周日）

使用 `#` 开头作为注释。

正则表达式：

* `*` 代表所有值

* `M-N` 代表 M 到 N 的值

* `M-N/X` 或 `*/X` 代表 M 到 N 的值以 X 为间隔

* `A,B,……,Z` 代表 A、B、…… 和 Z

* `H` 代表不会同时构建所有作业，更好地利用有限资源。

  `H H(0-7) * * *` 代表 12:00 AM 到 7:59 AM 某个时间构建一次作业。

`*/3` 与 `H/3` 的区别：`*/3` 代表假设一个长月的第 1、4、……、31 天运行，然后下个月第二天再次运行。`H/3` 则代表一个月总在 1-28 范围内选择，也就是在月底时会产生 3 到 6 天的间隔是不构建作业的。

还支持别名：`@yearly`、`@annually`、`monthly`、`weekly`、`daily`、`midnight`。

例子：

```shell
# 每十五分钟（可能在 :07, :22, :37, :52）：
H/15 * * * * 
# 在每个小时的前半段每十分钟一次（三次，可能在 :04, :14, :24): 
H(0-29)/10 * * * * 
# 每个工作日每两个小时一次，从上午 9 点 45 分开始到下午 3 点 45 分结束，时间过后 45 分钟：
45 9-16/2 * * 1-5 
# 每个工作日上午 8 点到下午 4 点之间的每两个小时时段一次（可能是上午 9 点 38 分、上午 11 点 38 分、下午 1 点 38 分、下午 3 点 38 分）：HH(8-15) 
/ 2 * * 1-5 
# 每个月的 1 日和 15 日每天一次，12 月除外：
H H 1,15 1-11 *
```

##### 构建环境

###### Create a formatted version number

**Environment Variable Name**

设置变量名

**Version Number Format String**

版本号格式

`${variable_name,argument}` 通过此格式设置变量长度，如果变量的数字长度不足则使用左侧补 0 法补足长度。如果找不到对应的环境变量名，则使用空字符串填充。`${variable_name,"N"}` 可以通过这个形式设置取字符串的前几位或者倒数几位，前几位使用正数表示，倒数使用负数表示。

特殊的的变量：

BUILD_DATE_FORMATTED：如果此参数是用引号括起来的 java 日期格式字符串，那么它将替换为使用该字符串格式化的构建日期。如果没有参数，那么这将是标准的简单日期格式。例如，`$ {BUILD_DATE_FORMATTED，"yyyy-MM-dd"}` 会返回日期（而不是时间），如 2009-10-01。

BUILD_DAY：没有参数，它只是返回构建的一天作为一个整数。如果有一个参数，它需要参数中的字符数，并使用填充日期字符串。例如，如果是本月的第三天，`${BUILD_DAY}` 将返回 3，`${BUILD_DAY，X}` 将返回 3，`${BUILD_DAY，XX}` 将返回 03。

BUILD_WEEK：在一年之中构建的日期的周数

BUILD_MONTH：构建的月份

BUILD_YEAR：构建的年份

BUILDS_TODAY：在构建这一天完成的构建数，包括当前的这个

BUILDS_THIS_WEEK：本周完成的构建数，包括当前的这个

BUILDS_THIS_MONTH：本月完成的构建数，包括当前的这个

BUILDS_THIS_YEAR：构建的这一年完成的构建数，包括当前的这个

BUILDS_ALL_TIME：自项目开始以来发生的构建数量

MONTHS_SINCE_PROJECT_START：自项目开始日期以来经过的日历月数

YEARS_SINCE_PROJECT_START：自项目开始日期以来经过的日历年数

**Prefix Variable**

前缀变量名称是此处指定的环境变量，以允许对所有发布标签使用相同的内部版本号。

请注意，与 pipeline jobs 不同，前缀变量不会自动添加到生成版本的前面。它必须手动添加到版本号格式字符串的前面。这种行为将来可能会改变！

**Skip Builds worse than**

跳过构建差于……

如果前一次构建运行的结果比此处选择的差，这不会导致今天/本周/本月/今年/所有时间的构建编号为下一个构建递增。基本上，这可以防止“不成功”的构建“吃掉”构建号。其他规则适用；例如，如果在第二天的第一个构建中修复了失败的构建，那么 BUILDS_TODAY 将为已修复的构建设置 1。

**Build Display NameUse the formatted version number for build display name.**

使用格式化版本号作为构建显示名称

**Project Start Date**

项目开始的日期，格式为 yyyy-MM-dd。这用于计算自项目开始以来的月数和年数。

**Number of builds today**

今天的构建数

**Number of builds this week**

本周的构建数

**Number of builds this month**

本月的构建数

**Number of builds this year**

今年的构建数

**Number of builds since the start of the project**

自项目开始以来的构建数

## 出包

通过执行 bat 文件启动 Unity 进程，并调用 Unity 中的一个静态函数进行出包。

### bat 文件

主要内容：

1. 删除以前的出包文件夹
2. 判断 Unity 是否在运行中，如果是，则杀掉进程
3. 启动 Unity 进程，并调用 Unity 中的静态函数，该静态函数的作用就是出包
4. 删除冗余文件
5. 对 Unity 出出来的文件打进压缩中，并放在 Jenkins 的工作目录中

虽然 `::` 代表注释，但执行时可能会受到 `，` 等影响报错，所以在创建 bat 文件时可以去掉注释。

```shell
@echo off
::初始化变量
::等号后面就是变量的值，双引号不代表字符串，是字符串的一部分，所以 UNITY_BUILD_LOG 只有一个双引号
::被%%包含代表使用该变量，%OUTPUT_PATH:~0,-1% 代表截取字符串变量 OUTPUT_PATH 从开头到倒数第二个字符，也就是不包含最有一个字符
SET OUTPUT_PATH="D:\Jenkins\Workspace\workspace\Flappy Bird\Output"
SET UNITY_PATH="C:\Program Files\Unity 2019.4.40f1c1\Editor\Unity.exe"
SET PROJECT_PATH="D:\GameMadeInMe\Flappy Bird"
SET UNITY_BUILD_LOG=%OUTPUT_PATH:~0,-1%\output.log"
SET COMPRESS_PATH=%OUTPUT_PATH:~0,-1%\*"
SET COMPRESS_PACKAGE_PATH="D:\Jenkins\Workspace\workspace\Flappy Bird\Release\Flappy Bird-%2.zip"

::删除之前生成的 Output 文件夹
IF EXIST %OUTPUT_PATH% (GOTO DEL_OUTPUT)

:DEL_OUTPUT
RD /S /Q %OUTPUT_PATH%

::判断 Unity 是否运行中
::获取当前运行中的进程列表，并写入 ProcessList.txt 文件中
TASKLIST /V /S localhost /U %username%>ProcessList.txt
::读取 ProcessList.txt 内容，并搜索 Unity.exe
TYPE ProcessList.txt | FIND “Unity.exe”

::如果搜索到 Unity 正在运行中，则跳到 UNITY_IS_RUNNING 标记，否则跳到 START_UNITY 标记
IF ERRORLEVEL 0 (GOTO UNITY_IS_RUNNING)
ELSE (GOTO START_UNITY)

::此处就是 UNITY_IS_RUNNING 标记
:UNITY_IS_RUNNING
::杀掉 Unity 进程
TASKKILL /F /IM Unity.exe
::停 1 秒
PING 127.0.0.1 -N 1 >NUL
GOTO START_UNITY

::此处就是 START_UNITY 标记
:START_UNITY

::执行 Unity 打包
::^ 符号是将太长的命令可以分成多行，方便阅读
%UNITY_PATH% ^

::执行命令完毕后退出 Unity 编辑器
-quit ^

::在批处理模式下运行 Unity 不会弹出窗口，当脚本代码在执行过程中发生异常或其他操作失败时 Unity 将立即退出，并返回代码为 1
-batchmode ^

::打开指定路径的项目
-projectPath %PROJECT_PATH% ^

::在 Unity 启动的同时会执行静态方法，也就是使用 executeMethod 需要在项目中有一个 Editor 文件夹，且里面有一个脚本，且类中有一个静态函数
-executeMethod BuildTools.BuildEXE ^

::指定输出的日志文件
-logFile %UNITY_BUILD_LOG% ^

::通过 executeMethod 传入执行脚本的静态函数的参数 1
::设置 EXE 的名字
--productName:%1 ^

::通过 executeMethod 传入执行脚本的静态函数的参数 2
::设置版本号
--version:%2

::删除之前判断是否 Unity 进程运行中时所生成的文件
DEL ProcessList.txt

::将 Unity 生成的程序打包压缩
::7z 是需要在电脑上安装 7-zip 软件并配置系统环境变量 Path 后才可使用，配置完成后需要重启 Jenkins 才会生效
7z a %COMPRESS_PACKAGE_PATH% %COMPRESS_PATH%
::删除压缩包中的 output.log 文件
7z d %COMPRESS_PACKAGE_PATH% "output.log"
```

### Unity 中出包代码

```c#
using Boo.Lang;
using UnityEditor;
using UnityEngine;

public class BuildTools {
    [MenuItem("Build/Build EXE")]
    public static void BuildEXE() {
        // 解析命令行参数
        string[] args = System.Environment.GetCommandLineArgs();
        foreach (string arg in args) {
            if (arg.Contains("--productName:")) {
                string productName = arg.Split(':')[1];
                PlayerSettings.productName = productName;
            }

            if (arg.Contains("--version:")) {
                string version = arg.Split(':')[1];
                PlayerSettings.bundleVersion = version;
            }
        }

        // 获取工程中的场景文件
        List<string> scenes = new List<string>();
        foreach (UnityEditor.EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
            if (scene.enabled) {
                if (System.IO.File.Exists(scene.path)) {
                    scenes.Add(scene.path);
                }
            }
        }

        // 打包配置
        BuildPlayerOptions options = new BuildPlayerOptions();
        options.scenes = scenes.ToArray();
        //options.locationPathName = $Application.dataPath + "/../Output/{PlayerSettings.productName}.exe";
        options.locationPathName = $"D:/Jenkins/Workspace/workspace/Flappy Bird/Output/{PlayerSettings.productName}.exe";
        Debug.Log("locationPathName" + options.locationPathName);
        options.target = BuildTarget.StandaloneWindows64;
        options.options = BuildOptions.None;

        BuildPipeline.BuildPlayer(options);
        Debug.Log("Build EXE Done");
    }
}
```

