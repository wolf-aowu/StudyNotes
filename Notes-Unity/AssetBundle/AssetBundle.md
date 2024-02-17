# AssetBundle

## 资产、对象和序列化

### 内部资产和对象

Asset 是磁盘上的一个文件，存储在 Unity 项目的 Assets 文件夹中。纹理、3D 模型或音频剪辑是常见的资产类型。某些资产包含 Unity 原生格式的数据，例如材质。其他 Assets 需要处理成原生格式，例如 FBX 文件。

UnityEngine.Object 或带有大写 “O” 的对象是一组序列化数据，共同描述资源的特定实例**。**这可以是 Unity 引擎使用的任何类型的资源，例如网格、精灵、AudioClip 或 AnimationClip。所有对象都是 UnityEngine.Object 基类的子类。

## 简介

AssetBundle 是一种存档文件，包含可在运行时由 Unity 加载的特定于平台的<font color=skyblue>非代码资源</font>（比如模型、纹理、预制件、音频剪辑甚至整个场景，<font color = cyan>包括 ScriptObject</font>）。AssetBundle 可以表示彼此之间的依赖关系。为了提高通过网络传输的效率，可以根据用例要求（LZMA 和 LZ4）选用内置算法选择来压缩 AssetBundle。

LZMA：默认压缩方式，优点将文件压缩的非常小，缺点是每次使用都需要将压缩文件全部解压，非常耗费时间，会造成游戏的卡顿。

LZ4：是 LZMA 和不压缩之间的折中方案，构建的 AssetBundle 资源文件会略大于 LZMA 压缩，但在加载资源时不需要将所有的资源都加载下来，所以速度比 LZMA 快。<font color=skyblue>建议使用。</font>

AssetBundle 可用于可下载内容（DLC），减小初始安装大小，加载针对最终用户平台优化的资源，以及减轻运行时内存压力。也就是热更。

<font color = skyblue>"AssetBundle"</font> 可以指两种不同但相关的东西。

首先是磁盘上的实际文件。这称为 AssetBundle 存档。AssetBundle 存档是一个容器，就像文件夹一样，可以在其中包含其他文件。这些附加的文件包含两种类型：

- 一个序列化文件，其中包含分解为各个对象并写入此单个文件的资源。
- 资源文件，这是为某些资源（纹理和音频）单独存储的二进制数据块，允许 Unity 高效地在另一个线程上从磁盘加载它们。

"AssetBundle" 也可以指代通过代码进行交互以便从特定 AssetBundle 存档加载资源的实际 AssetBundle 对象。该对象包含您添加到此存档文件的资源的所有文件路径的映射。

## AssetBundle 工作流程

### 为 AssetBundle 分配资源

1. 从 Project 视图中选择要为捆绑包分配的资源。
2. 在 Inspector 中检查对象。
3. 在 Inspector 底部，有一个用于分配 AssetBundle 和变体的部分。可使用左侧下拉选单分配 AssetBundle，而使用右侧下拉选单分配变量。
4. 单击左侧下拉选单的 None 以显示当前注册的 AssetBundle 名称。
5. 单击 New 以创建新的 AssetBundle。
6. 输入所需的 AssetBundle 名称。<font color = skyblue>注意：</font>AssetBundle 名称支持某种类型的文件夹结构，具体取决于您输入的内容。要添加子文件夹，请用 `/` 分隔文件夹名称。例如，使用 AssetBundle 名称 `environment/forest` 在 `environment` 子文件夹下创建名为 `forest` 的捆绑包。
7. 一旦选择或创建了 AssetBundle 名称，便可以重复此过程在右侧下拉选单中分配或创建变体名称（如果需要）。构建 AssetBundle 不需要变体名称。

<font color = orange>注意：</font>您可以为项目中的文件夹分配一个 AssetBundle 和标签。默认情况下，该文件夹中的所有资源都将分配给该 AssetBundle 并赋予与文件夹相同的标签。但是，单独为资源分配的 AssetBundle 优先级更高。

#### AssetBundle 打包分组策略

##### 按照逻辑实体分组

一个 UI 界面或者所有 UI 界面为一个包

一个角色或者所有角色为一个包

所有场景共享部分为一个包

##### 按照类型分类

所有声音资源为一个包

所有 Shader 为一个包

所有模型为一个包

所有材质为一个包

##### 按照使用分组

把在某一个时间内使用的所有资源打包成一个包

按照关卡分，一个关卡所需要的所有资源包括角色、声音、贴图等为一个包

按照场景分，一个场景需要的资源为一个包

##### 注意事项

把经常更新的资源放在一个单独包内，与不经常更新的包分离

把需要同时加载的资源放在一个包内

可以把其他包共享的资源放在一个单独的包中

如果同一个资源有两个版本，可以考虑使用后缀区分

如果有资源被其他 AssetBundle 引用但该资源没有 AssetBundle，则该资源会被每一个引用者复制一个副本在每一个 AssetBundle 中，这会造成内存浪费，所以公共的资源尽可能放入公共的 AssetBundle 中。

### 构建 AssetBundle

``` c#
using UnityEditor;
using System.IO;

public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        if(!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, 
                                        BuildAssetBundleOptions.None, 
                                        BuildTarget.StandaloneWindows);
    }
}
```

`BuildPipeline.BuildAssetBundles` 需要传入三个参数：

第一个是 AssetBundle 要输出到的目录。

第二个是指定具有各种效果的不同 `BuildAssetBundleOptions` 来处理 AssetBundle 压缩。

- `BuildAssetBundleOptions.None`：此捆绑包选项使用 LZMA 格式压缩，
  解压缩捆绑包后，将使用 LZ4 压缩技术在磁盘上重新压缩捆绑包，这不需要在使用捆绑包中的资源之前解压缩整个捆绑包。最好在包含资源时使用，这样，使用捆绑包中的一个资源意味着将加载所有资源。这种捆绑包的一些用例是打包角色或场景的所有资源。由于文件较小，<font color=skyblue>建议仅从异地主机初次下载 AssetBundle 时才使用 LZMA 压缩。</font>通过 UnityWebRequestAssetBundle 加载的 LZMA 压缩格式 Asset Bundle 会自动重新压缩为 LZ4 压缩格式并缓存在本地文件系统上。如果通过其他方式下载并存储捆绑包，则可以使用 AssetBundle.RecompressAssetBundleAsync API 对其进行重新压缩。
- `BuildAssetBundleOptions.UncompressedAssetBundle`：此捆绑包选项采用使数据完全未压缩的方式构建捆绑包。未压缩的缺点是文件下载大小增大。但是，下载后的加载时间会快得多。未压缩的 AssetBundles 是 16 字节对齐的。
- `BuildAssetBundleOptions.ChunkBasedCompression`：此捆绑包选项使用称为 LZ4 的压缩方法，因此压缩文件大小比 LZMA 更大，但不像 LZMA 那样需要解压缩整个包才能使用捆绑包。<font color=skyblue>LZ4 使用基于块的算法，允许按段或“块“加载 AssetBundle。</font>解压缩单个块即可使用包含的资源，即使 AssetBundle 的其他块未解压缩也不影响。使用 `ChunkBasedCompression` 时的加载时间与未压缩捆绑包大致相当，额外的优势是减小了占用的磁盘大小。

第三个是 `BuildTarget.Standalone`：这里我们告诉构建管线，我们要将这些 AssetBundle 用于哪些目标平台。可以在关于 [BuildTarget](https://docs.unity3d.com/cn/current/ScriptReference/BuildTarget.html) 的脚本 API 参考中找到可用显式构建目标的列表。但是，如果不想在构建目标中进行硬编码，请充分利用 `EditorUserBuildSettings.activeBuildTarget`，它将自动找到当前设置的目标构建平台，并根据该目标构建 AssetBundle。

现在已经成功构建了 AssetBundle，您可能会注意到 AssetBundles 目录包含的文件数量超出了最初的预期。确切地说，是多出了 2*(n+1) 个文件。对于在编辑器中指定的每个 AssetBundle，可以看到一个具有 AssetBundle 名称 + “.manifest” 的文件。

自定义的 AssetBundle：

![](图片\自定义的 AssetBundle 名称.png)

输出的 AssetBundleManifest 文件：

![](图片\输出的 AssetBundleManifest 文件.png)

随后会有一个额外捆绑包和清单的名称不同于先前创建的任何 AssetBundle。相反，此包以其所在的目录（构建 AssetBundle 的目录）命名。这就是清单捆绑包。

![](图片\额外的 AssetBundle.png)

#### AssetBundle 文件

缺少 .manifest 扩展名的文件，其中包含在运行时为了加载资源而需要加载的内容。AssetBundle 文件是一个存档，在内部包含多个文件。此存档的结构根据它是 AssetBundle 还是场景 AssetBundle 可能会略有不同。场景 AssetBundle 与普通 AssetBundle 的不同之处在于，它针对场景及其内容的串流加载进行了优化。以下是普通 AssetBundle 的结构：

![](图片\AssetBundles Building.png)

#### 清单文件

对于生成的每个捆绑包（包括附加的清单捆绑包），都会生成关联的清单文件。清单文件可以使用任何文本编辑器打开，并包含诸如循环冗余校验 (CRC) 数据和捆绑包的依赖性数据之类的信息。

普通 AssetBundle 的清单文件，其中显示了包含的资源、依赖项和其他信息。

![](图片\普通 AssetBundleManifest 内容.png)

生成的清单捆绑包将有一个清单，这将显示 AssetBundle 之间的关系以及它们的依赖项。就目前而言，只需要了解这个捆绑包中包含 AssetBundleManifest 对象，这对于确定在运行时加载哪些捆绑包依赖项非常有用。

![](图片\AssetBundle 关系清单.png)

### 加载 AssetBundle 资源

#### AssetBundle 的依赖关系

如果一个或多个对象包含对位于另一个捆绑包中的对象的引用，则 AssetBundle 依赖于其他 AssetBundle。如果对象引用不在任意一个 AssetBundle 中的对象，则不会发生依赖关系。在这种情况下，在构建 AssetBundle 时，AssetBundle 所依赖的对象的副本将复制到 AssetBundle 中。如果多个捆绑包中的多个对象包含对未分配给 AssetBundle 的同一对象的引用，则每个对该对象具有依赖关系的 AssetBundle 将创建其自己的对象副本并将其打包到构建的 AssetBundle 中。

实例化 AssetBundle 中资源时，需要在实例化之前将对象引用的所有 AssetBundle 先加载一遍。

#### 加载 AssetBundle

有三种 API 可以加载 AssetBundle。

##### AssetBundle.LoadFromMemoryAsync

此函数采用包含 AssetBundle 数据的字节数组。也可以根据需要传递 CRC 值。如果捆绑包采用的是 LZMA 压缩方式，将在加载时解压缩 AssetBundle。LZ4 压缩包则会以压缩状态加载。

通过协程异步加载方法。

```c#
using UnityEngine;
using System.Collections;
using System.IO;

public class Example : MonoBehaviour
{
    IEnumerator LoadFromMemoryAsync(string path)
    {
        AssetBundleCreateRequest createRequest = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));
        yield return createRequest;
        AssetBundle bundle = createRequest.assetBundle;
        var prefab = bundle.LoadAsset<GameObject>("MyObject");
        Instantiate(prefab);
    }
}
```

##### AssetBundle.LoadFromFile

从本地存储中加载未压缩的 AssetBundle 时，此 API 非常高效。如果 AssetBundle 未压缩或采用了数据块 (LZ4) 压缩方式，LoadFromFile 将直接从磁盘加载 AssetBundle。使用此方法加载完全压缩的 (LZMA) AssetBundle 将首先解压缩 AssetBundle，然后再将其加载到内存中。

在使用 Unity 5.3 或更早版本的 Android 设备上，尝试从流媒体资源 (Streaming Assets) 路径加载 AssetBundle 时，此 API 将失败。

```c#
public class LoadFromFileExample : MonoBehaviour {
    void Start() {
        //加载 AssetBundle
        var myLoadedAssetBundle 
            = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "myassetBundle"));
        if (myLoadedAssetBundle == null) {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        //加载 AssetBundle 中的资源
        var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("MyObject");
        //实例化
        Instantiate(prefab);
    }
}
```

##### UnityWebRequestAssetBundle

UnityWebRequestAssetBundle 有一个特定 API 调用来处理 AssetBundle。首先，需要使用 `UnityWebRequestAssetBundle.GetAssetBundle` 来创建 Web 请求。返回请求后，请将请求对象传递给 `DownloadHandlerAssetBundle.GetContent(UnityWebRequestAssetBundle)`。`GetContent` 调用将返回 AssetBundle 对象。

下载捆绑包后，还可以在 [DownloadHandlerAssetBundle](https://docs.unity3d.com/cn/current/ScriptReference/Networking.DownloadHandlerAssetBundle.html) 类上使用 `assetBundle` 属性，从而以 `AssetBundle.LoadFromFile` 的效率加载 AssetBundle。

以下示例说明了如何加载包含两个游戏对象的 AssetBundle 并实例化这些游戏对象。要开始这个过程，我们只需要调用 `StartCoroutine(InstantiateObject())`;

```c#
IEnumerator InstantiateObject()
{
    string uri = "file:///" + Application.dataPath + "/AssetBundles/" + assetBundleName; 
    UnityEngine.Networking.UnityWebRequestAssetBundle request 
        = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle(uri, 0);
    yield return request.SendWebRequest();
    AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
    GameObject cube = bundle.LoadAsset<GameObject>("Cube");
    GameObject sprite = bundle.LoadAsset<GameObject>("Sprite");
    Instantiate(cube);
    Instantiate(sprite);
}
```

#### 加载资源

加载资源的方式有四种。

##### LoadAsset

``` c
GameObject gameObject = loadedAssetBundle.LoadAsset<GameObject>(assetName);
```

##### LoadAllAssets

``` c#
Unity.Object[] objectArray = loadedAssetBundle.LoadAllAssets();
```

##### AssetBundleRequest

```c#
AssetBundleRequest request = loadedAssetBundleObject.LoadAssetAsync<GameObject>(assetName);
yield return request;
//可以通过 as 转成对应类型资源
var loadedAsset = request.asset;
```

##### LoadAllAssetsAsync

```c#
AssetBundleRequest request = loadedAssetBundle.LoadAllAssetsAsync();
yield return request;
var loadedAssets = request.allAssets;
```

加载 AssetBundleManifest

加载 AssetBundle 清单可能非常有用。特别是在处理 AssetBundle 依赖关系时。

要获得可用的 [AssetBundleManifest](https://docs.unity3d.com/cn/current/ScriptReference/AssetBundleManifest.html) 对象，需要加载另外的 AssetBundle（与其所在的文件夹名称相同的那个，也就是多出来的那一个文件）并从中加载 AssetBundleManifest 类型的对象。

加载清单本身的操作方法与 AssetBundle 中的任何其他资源完全相同：

```c#
AssetBundle assetBundle = AssetBundle.LoadFromFile(manifestFilePath);
AssetBundleManifest manifest = assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
```

现在，可以通过上面示例中的清单对象访问 `AssetBundleManifest` API 调用。从这里，可以使用清单获取所构建的 AssetBundle 的相关信息。此信息包括 AssetBundle 的依赖项数据、哈希数据和变体数据。

例如，我们想要加载名为 “assetBundle” 的所有依赖项，那么我们可以通过 `AssetBundleManifest.GetAllDependencies` 获取名为 “assetBundle” 的所有依赖项。

```c#
AssetBundle assetBundle = AssetBundle.LoadFromFile(manifestFilePath);
AssetBundleManifest manifest = assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
string[] dependencies = manifest.GetAllDependencies("assetBundle"); //传递想要依赖项的捆绑包的名称。
foreach(string dependency in dependencies)
{
    AssetBundle.LoadFromFile(Path.Combine(assetBundlePath, dependency));
}
```

#### 卸载 AssetBundle

从活动场景中删除对象时，Unity 不会自动卸载对象。资源清理在特定时间触发，也可以手动触发。不正确地卸载 AssetBundle 会导致在内存中复制对象或其他不良情况，如缺少纹理。

关于 AssetBundle 管理的最需要了解的是何时调用 AssetBundle.Unload(bool) – 或者 AssetBundle.UnloadAsync(bool) – 以及应该将 true 还是 false 传递到函数调用中。Unload 是一个非静态函数，可用于卸载 AssetBundle。此 API 会卸载正在调用的 AssetBundle 的标头信息。该参数指示是否还要卸载通过此 AssetBundle 实例化的所有对象。

`AssetBundle.Unload(true)` 卸载从 AssetBundle 加载的所有游戏对象（及其依赖项）。这不包括复制的游戏对象（例如实例化的游戏对象），因为它们不再属于 AssetBundle。发生这种情况时，从该 AssetBundle 加载的纹理（并且仍然属于它）会从场景中的游戏对象消失，因此 Unity 将它们视为缺少纹理。

#### 例子

名为 sprite 的 AssetBundle 中的资源：

预制体：

1. RedArrow
2. YellowArrow

图片：

1. Arrow

名为 common 的 AssetBundle 中的资源：

材质：

1. Red
2. Yellow

预制体 RedArrow 使用图片 Arrow 和材质 RedArrow。预制体 YellowArrow 使用图片 Arrow 和材质 YellowArrow。

##### 不加载依赖的 AssetBundle

如果在实例化 RedArrow 对象之前，没有加载名为 common 的 AssetBundle，则会出现<font  color = skyblue>材质丢失</font>的情况。

##### 加载所有依赖

加载 sprite AssetBundle 的所依赖的所有 AssetBundle。

```c#
using System.IO;
using UnityEngine;

public class Main : MonoBehaviour {

    public void Start() {
        //加载存储 AssetBundle 间依赖关系的 AssetBundle
        AssetBundle assetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, "AssetBundles/AssetBundles"));
        //获取 AssetBundle 间以来关系清单
        AssetBundleManifest manifest = assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        //得到 sprite AssetBundle 依赖的所有 AssetBundle
        string[] dependencies = manifest.GetAllDependencies("sprite");
        //加载 sprite AssetBundle 依赖的所有 AssetBundle
        foreach (string dependency in dependencies) {
            AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, "AssetBundles", dependency));
        }
        //加载 sprite AssetBundle
        AssetBundle spriteAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, "AssetBundles/sprite"));
        GameObject arrowGameObject = spriteAssetBundle.LoadAsset<GameObject>("RedArrow");
        Instantiate(arrowGameObject);
    }
}
```

![](图片\加载 sprite AssetBundle 依赖的所有 AssetBundle.png)

##### 卸载依赖的 AssetBundle，Unload(true)

成功加载 RedArrow 预制体后卸载 common AssetBundle。`commonAssetBudnle.Unload(true)` 时，<font color = skyblue>材质丢失</font>。

```c#
using System.IO;
using UnityEngine;

public class Main : MonoBehaviour {

    public bool isUnload;
    public AssetBundle commonAssetBudnle;
    public AssetBundle spriteAssetBundle;

    public void Start() {
        //加载存储 AssetBundle 间依赖关系的 AssetBundle
        AssetBundle assetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, "AssetBundles/AssetBundles"));
        //获取 AssetBundle 间以来关系清单
        AssetBundleManifest manifest = assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        //得到 sprite AssetBundle 依赖的所有 AssetBundle
        string[] dependencies = manifest.GetAllDependencies("sprite");
        //加载 sprite AssetBundle 依赖的所有 AssetBundle
        foreach (string dependency in dependencies) {
            commonAssetBudnle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, "AssetBundles", dependency));
        }
        //加载 sprite AssetBundle
        spriteAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, "AssetBundles/sprite"));
        GameObject arrowGameObject = spriteAssetBundle.LoadAsset<GameObject>("RedArrow");
        Instantiate(arrowGameObject);
    }

    public void Update() {
        if (!isUnload) {
            commonAssetBudnle.Unload(true);
            Debug.Log("common AssetBundle 已卸载");
            isUnload = true;
        }
    }
}
```

##### 卸载依赖的 AssetBundle，Unload(true)，加载资源

成功加载 RedArrow 预制体后卸载 common AssetBundle。`commonAssetBudnle.Unload(true)`，直接加载资源，新加载的资源<font color = skyblue>材质也丢失</font>。

```c#
using System.IO;
using UnityEngine;

public class Main : MonoBehaviour {

    public bool isUnload;
    public AssetBundle commonAssetBudnle;
    public AssetBundle spriteAssetBundle;
    public int timeCount;

    public void Start() {
        //加载存储 AssetBundle 间依赖关系的 AssetBundle
        AssetBundle assetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, "AssetBundles/AssetBundles"));
        //获取 AssetBundle 间以来关系清单
        AssetBundleManifest manifest = assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        //得到 sprite AssetBundle 依赖的所有 AssetBundle
        string[] dependencies = manifest.GetAllDependencies("sprite");
        //加载 sprite AssetBundle 依赖的所有 AssetBundle
        foreach (string dependency in dependencies) {
            commonAssetBudnle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, "AssetBundles", dependency));
        }
        //加载 sprite AssetBundle
        spriteAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, "AssetBundles/sprite"));
        GameObject arrowGameObject = spriteAssetBundle.LoadAsset<GameObject>("RedArrow");
        Instantiate(arrowGameObject);
    }

    public void Update() {
        if (!isUnload) {
            commonAssetBudnle.Unload(true);
            Debug.Log("sprite AssetBundle 已卸载");
            isUnload = true;
        }

        //再加载一个 RedArrow 预制体
        if (timeCount == 60) {
            GameObject arrowGameObject = spriteAssetBundle.LoadAsset<GameObject>("RedArrow");
            Instantiate(arrowGameObject, new Vector3(5, 0, 0), Quaternion.identity);
        }

        timeCount++;
    }
}
```

![](图片\材质丢失2.png)

##### 卸载资源的 AssetBundle，Unload(true)

成功加载 RedArrow 预制体后卸载 sprite AssetBundle。`spriteAssetBudnle.Unload(true)` 时，实例化的 RedArrow 对象还存在，名为 Red 的材质也存在，<font color = skyblue>但是 sprite AssetBundle 中的图片丢失</font>。

![](图片\图片引用丢失.png)

##### 卸载资源的 AssetBundle，Unload(true)，加载资源

成功加载 RedArrow 预制体后卸载 sprite AssetBundle。`spriteAssetBudnle.Unload(true)`，直接加载资源。<font color = skyblue>资源加载失败并报错，提示 AssetBundle  已销毁</font>。

如果创建一个全局 GameObject 类型变量 arrowGameObject 用于保存第一次加载的 RedArrow 预制体资源。<font color = skyblue>在卸载 AssetBundle 后直接实例化它（不再通过 AssetBundle 加载它）会报错，提示该对象为空</font>。

##### 卸载依赖的 AssetBundle，Unload(false)

成功加载 RedArrow 预制体后卸载 common AssetBundle。`commonAssetBudnle.Unload(false)`，AssetBundle 被卸载但不影响已实例化对象的显示。

##### 卸载依赖的 AssetBundle，Unload(false)，加载资源

成功加载 RedArrow 预制体后卸载 common AssetBundle。`commonAssetBudnle.Unload(false)`，再次加载 RedArrow 预制体，然后加载 YellowArrow 预制体。<font color = skyblue>RedArrow 正常显示，YellowArrow 材质丢失。</font>

##### 卸载资源的 AssetBundle，Unload(false)

成功加载 RedArrow 预制体后卸载 sprite AssetBundle。`spriteAssetBudnle.Unload(false)` 时，AssetBundle 被卸载但不影响已实例化对象的显示。

##### 卸载资源的 AssetBundle，Unload(false)，加载资源

成功加载 RedArrow 预制体后卸载 sprite AssetBundle。`spriteAssetBudnle.Unload(false)`，直接加载资源。

如果创建一个全局 GameObject 类型变量 arrowGameObject 用于保存第一次加载的 RedArrow 预制体资源。<font color = skyblue>在卸载 AssetBundle 后直接实例化它（不再通过 AssetBundle 加载它）会报错，提示该对象为空</font>。

