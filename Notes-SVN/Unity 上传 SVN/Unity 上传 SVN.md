# Unity 上传 SVN

## 新建 Unity 项目生成的文件结构

新建 Unity 项目后一般会产生三个文件夹：

1. Assets
2. Library
3. ProjectSettings

## 使用 VS 或 MonoDevelop 生成的文件

使用 VS 或 MonoDevelop 打开编辑脚本会产生一些工具配置文件。

文件夹：

1. Temp

文件：

1. 项目名.CSharp.csproj

## Unity 配置

Edit -> Project Settings

1. Editor -> Asset Serialization -> Mode -> Force Text

   因为场景和 prefab 都是用二进制保存的，而如果多个人同时操作场景或修改 prefab，那么因为 SVN 无法合并二进制文件而产生冲突。而事实上，Unity 是可以强制把所有文件都保存成文本的。Asset Serialization（资源序列化）选项就是序列化方式，默认是 mix（混合），这里强制改成 Force Text（强制文本）。这样 SVN 就可以对齐合并。

2. Version Control -> Mode -> Visible Meta Files

## 需要上传的文件

文件夹

1. Assets
2. ProjectSettings

## 注意

1. 尽量保存场景并关闭 Unity 后提交

