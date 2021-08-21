### 分析器 UI 部分的使用

#### 打开 UI 分析器

Window -> Analysis -> Profiler 或快捷键 `Ctrl + 7` 打开

![](Profiler.png)

如上图选择分析器模块：UI 和 UI Details Profiler 模块

#### 图表类别

UI 和 UI Details Profiler 模块的图表被分为五个类别。要更改图表中类别的顺序，可以在图表的图例中拖放这些类别。还可以单击某个类别的有色图例以切换是否显示。

##### UI Profiler 模块

- Layout

  Unity 在执行 UI 的布局通道方面花费的时间。这包括 HorizontalLayoutGroup、VerticalLayoutGroup 和 GridLayoutGroup 进行的计算。

- Render

  UI 在完成渲染部分中花费的时间。这是直接渲染到图形设备的成本，或者是渲染到主渲染队列的成本。

##### UI Details Profile 模块

- Batches

  显示一起批处理的绘制调用的总数。

- Vertices

  用于渲染 UI 某个部分的顶点总数。

- Markers

  显示事件标记。用户与 UI 交互（例如，单击按钮或更改滑动条值）时，Unity 将记录标记，然后将它们绘制为图表上的垂线和标签。

#### 模块详细信息面板

<font color = orange>注意: </font> 不用调整信息面板，每次运行都会重置信息面板，至少我没找到保存的地方。

选择 UI 或 UI Details Profiler 模块时，Profiler 窗口底部的模块详细信息面板会显示应用程序中 UI 的更多相关详细信息。据此可以检查应用程序中 UI 对象的相关性能分析信息。该面板被分为以下几列：

- Object

  应用程序在性能分析期间使用的 UI 画布的列表。双击一行可以突出显示场景中的匹配对象。

- Self Batch Count

  Unity 为画布生成的批次数量。

- Cumulative Batch Count

  Unity 为画布及其所有嵌套画布生成的批次数量。

- Self Vertex Count

  此画布渲染的顶点数量。

- Cumulative Vertex Count

  此画布和嵌套的画布渲染的顶点数量。

- Batch Breaking Reason

  Unity 拆分此批次的原因。有时 Unity 可能无法对对象同时进行批处理。常见原因包括：

  - 不与画布共面 (Not Coplanar With Canvas)：批处理需要对象的矩形变换与画布共面（未旋转）
  - 画布注入索引 (CanvasInjectionIndex)：CanvasGroup 组件存在并强制新建批次，例如在其余部分上显示一个组合框的下拉列表时。
  - 不同的材质实例、矩形裁剪、纹理、A8 纹理用法 (Different Material Instance, Rect clipping, Texture, or A8TextureUsage)：Unity 只能将具有相同材质、遮罩、纹理和纹理 Alpha 通道用法的对象一起进行处理。

- GameObject Count

  此批次中包含的游戏对象数量。

- GameObjects

  批次中的游戏对象的列表。

从列表中选择 UI 对象时，对象的预览将显示在面板右侧。预览上方的工具栏中有以下选项：

- Detach

  选择此按钮可在单独的窗口中打开 UI 画布。要重新连接该窗口，请将其关闭。

- Preview background

  使用下拉选单来更改预览背景的颜色。可以选择 Checkerboard、Black 或 White。如果 UI 具有特别浅色或深色的方案，这将很有用。

- Preview type

  使用下拉选单来选择 Standard、Overdraw 或 Composite Overdraw。

#### Rendering 分析器

Rendering Profiler 显示渲染统计信息。时间轴显示渲染的批次 (Batches)、SetPass 调用 (SetPass Calls)、三角形 (Triangles) 和顶点 (Vertices) 的数量。下方面板将显示更多渲染统计信息，这些统计信息与 GameView Rendering Statistics 窗口中显示的统计信息非常接近。

- SetPass Calls

  渲染 pass 的数量。每个 pass 都需要 Unity 运行时绑定一个新的着色器（新的材质、渲染状态、渲染顶点批次），这可能会带来 CPU 开销。

### 绘制调用 (Draw call)

在 Unity 中，每次 CPU 准备数据并通知 GPU 的过程称之为一个 Draw call。

过程：设置颜色 -> 绘图方式 -> 顶点坐标 -> 绘制 -> 结束。

因此，如果能一次 DrawCall 完成所有绘制就会大大提高运行效率，进而达到优化的目的。

在 2017 的 Unity 中，已将 Draw call 改为 Batches。

### 绘制调用批处理 (Draw call batching)

<font color = skyblue>原文翻译</font>

为了在屏幕上绘制一个 GameObject 在屏幕上，引擎必须向图形 API（如 OpenGL 或 Direct3D）发出一个绘制调用。绘制调用通常是资源密集型的，图形 API 为每次绘制调用做了大量工作，导致 CPU 方面的性能开销。这主要是由绘制调用之间的状态变化造成的（比如 切换到不同的材料），这导致图形驱动中资源密集型的验证和转换步骤。

### Canvas 优化

<font color = teal>情况说明及优化依据</font>

一个 Canvas 下的所有 UI 元素都是合在一个网格 (Mesh) 中的，过大的 网格 在更新时开销很大。每次渲染一个 Canvas，Unity 会尽可能的合并 Canvas 中的 UI 元素为一个批次。当该 Canvas 内有一个 UI 元素发生<font color = #9c88ff>位置、颜色改变？（反正就是有改变了）</font>，Unity 就要重新对该 Canvas 进行合批。

每一个 Canvas 都是可以作为一个单独渲染的存在，即一个 Canvas 下面 GameObject 发生改变，只有该 Canvas 需要重建，其他 Canvas 不受影响。

<font color = teal>优化要点</font>

- 每个较复杂的 UI 界面，都自成一个 Canvas（可以时子 Canvas）。在 UI 界面很复杂时，要划分更多的子 Canvas。
- 动静分离。
- Canvas 也不能细分的太多，因为会导致 Draw Call 的上升。因为 一个 Canvas 至少会有一个渲染批次。一般 Canvas 分几十个即可，千万不要分 上百个 。
- 把一个面板的 UI 资源放到一个图集里，这样只需要加载一个图集。如果一个面板的 UI 资源来自于多个图集，Unity 要将所有该面板用到的 图集 都加载一遍，这会造成显卡的卡顿。
- 背景大图不要和小图放在一个图集里。背景大图应该是指该面板用不到的大图。

### 半透明优化 Overdraw（GPU）

<font color = teal>情况说明及优化依据</font>

如果一个 UI 界面上有许多半透明的 UI 元素，这会导致这些半透明的 UI 元素所在的位置的像素点会被绘制多次，会造成GPU的性能开销。没有半透明的 UI 元素所在的位置的像素点会保留靠近屏幕位置的像素点，剔除远离屏幕位置的像素点。而有半透明的 UI 元素所在的位置的 距离屏幕远的 像素点不能被剔除。这会造成 <font color = #9c88ff>光栅化阶段</font> 的填充像素过多。

在 UGUI 中使用 Alpha = 0 的不可见 Image 参与 Raycast，譬如在屏幕空白处点击的相应等虽然这些元素在屏幕上不可见但依然参与了绘制。

<font color = teal>优化要点</font>

- 禁用不可见的 UI。比如当打开一个系统是如果完全挡住了另外一个系统，则可以将被遮挡住的系统禁用。
- 不要使用空的 Image。在 Unity 中，RayCast 使用 Graphic 作为基本元素来检测 touch ，使用空的 Image 并将 alpha 设置为 0 来接受 touch 事件会产生不必要的 overdraw。
- <font color = #9c88ff>无图 UI 遮罩点击优化。</font>

### ScrollView 问题

- 背包内只有几十个物品的时候问题不大，上百个物品的时候会有大问题。
- 每次拖动 ScrollView 时都会引发 OnValueChanged 事件。
- 每当 ScrollView 滚动整个 Canvas 时，它就会变脏，会引起 Canvas 重新合批。所以，将每隔 ScrollView 放在单独的 Canvas 上。
- EventSystem.Update() 处理会处理场景中的输入检测，使光线投射过滤层次结构以查找接受此输入的组件。从图形和文本中删除不必要的 RaycastTarget 属性将缩短处理时间。所以，如果物品不能点击就千万不要挂 Graphics Raycaster 。
- 不要使用个人和类型的蒙版组件，包括 RectMask2D。Mask 组件 虽然可以使不需要显示的部分不显示，但是该不显示的部分任然参与渲染。每次拖动 ScrollView ，Canvas 都会重新合批，而这些不显示的部分也会进行重新合批。
- <font color = #9c88ff>ScrollRect 不会关闭不在可视范围内的 物品。</font>
- 当 ScrollView 中有很多元素时，使用对象池解决方案。

当有物体在滚动时不可见了，那么必有一个物体可见了，所以只需要使用这个不可见的物体显示可见的物体就可以了。

方法一：

初始化或滚动时：

- 计算可视范围
- 遍历每一格，判断其是否位于可视范围内
- 若可见，则显示
- 不可见，则隐藏

滚动时：

- 重新计算可见的格子
- 若有格子移出，则将其栏位用于新的移入的格子的显示

### UGUI 其他优化要点

<font color = teal>优化要点</font>

- 不处理点击的 GameObject 不要挂 Graphics Raycaster。因为，一旦挂上 Unity 会在每一帧检查该 UI 元素是否被点击。
- 少用 LayoutGroup 或者 Content Size Fitter。因为，用户一旦进行点击、滚动滚动条等操作，会造成整个 UI 界面重新绘制，LayoutGroup 和 Content Size Fitter 会进行重新布局运算，从而消耗大量计算时间。如背包中存放 1000 个物品，其实际开销是十分巨大的。<font color = #9c88ff>可以自己写算法实现</font>
- <font color = #9c88ff>遍历 SetDirty对象会消耗性能</font>

### 合批

合批过程是指 Canvas 合并 UI 元素的网格，并且生成发送给 Unity 渲染管线的命令。 Canvas 使用的网格都是从绑定在 Canvas 上的 CanvasRenderer 获得，但是不包含子 Canvas 的网格。UGUI 的层叠顺序是按照 Hierarchy 中的顺序从上往下进行的，也就是越靠上的组件，就会被绘制在越底部。<font color = orange>所有相邻层的可合批的 UI 元素（具有相同材质和纹理），就会在一个 DrawCall 中完成。</font>

#### Depth 计算算法

<font color = orange>注意: </font> CurrentUI.depth 指的是层，相等的为同一批层，符合material instance id 和 texture instance id 相同的条件就能够合并。相交指两个 UI 之间在 Game 窗口中有重叠的地方。<font color = #9c88ff>重叠是对的。网上没有说只要显示重叠就可以，但我的测试结果与 Z 轴无关。</font>

1. 遍历所有 UI 元素（已深度优先排序），对当前每一个 UI 元素 CurrentUI ，如果不渲染，CurrentUI.depth = -1，如果渲染该UI且底下没有其他 UI 元素与其相交（rect Intersects），其 CurrentUI.depth = 0;

2. 如果 CurrentUI 下面只有一个需要渲染的 UI 元素 LowerUI 与其相交，且可以Batch（material instance id 和 texture instance id 相同，即与 CurrentUI 具有相同的 Material 和 Texture），CurrentUI.depth = LowerUI.depth；否则，CurrentUI.depth = LowerUI.depth + 1;

3. 如果 CurrentUI 下面叠了多个元素，这些元素的最大层是 MaxLowerDepth ，判断 CurrentUI 是否与所有为 MaxLowerDepth 的 UI 元素中的任意一个具有相同的 Material 和 Texture，如果有那么它们就能合批。也就是按照前两条规则遍历计算所有的层级号，其中最大的那个作为自己的层级号。

4. Unity 以 Canvas 为单位进行绘制，按照前两条规则，当遍历 Hierarchy  进行处理时，如果列表中有 X 元素 Z 轴不为 0，则处理会被打断，X 元素之前的归为一个处理批次，X 元素以及 X 元素之后的元素归为一个处理批次。

   <font color = #9c88ff>没看懂，自己测试 Z 轴不同不影响。</font>

5. 不同图集会影响 Texture id ，导致图片不在同一批次。

6. Mask 会独自占用一个批并导致同时挂载的 Image 也占用一个批，所以占两个批

<font color = teal>例子</font>

例1：

![](Depth 计算方法-例1.png)

从上至下看 Hierarchy 窗口

绿色 下面没有东西，按照规则 1， `green.Depth = 0`

黄色 叠在 绿色上面，按照规则 2， `yellow.Depth = green.Depth`，所以 `yellow.Depth = 0`

Text0 叠在 黄色上面，按照规则 2，不是同一种 Texture， `Text0.Depth = yellow.Depth + 1` ，所以 `Text0.Depth = 1`

红色 下面没有东西，按照规则 1， `red.Depth = 0` 

Text1 叠在 红色上面，按照规则 2，不是同一种 Texture， `Text0.Depth = yellow.Depth + 1` ，所以 `Text1.Depth = 1`

蓝色 叠在 Text1 上面，按照规则 2，不是同一种 Texture， `blue.Depth = Text1.Depth + 1`，所以 `blue.Depth = 2`

Text2 叠在 蓝色上面，按照规则 2，不是同一种 Texture， `Text2.Depth = blue.Depth + 1` ，所以 `Text2.Depth = 3`

相同 `Depth` 且 `Texture` 和 `Material` 的在同一批，所以：

- Batch0：green, yellow, red
- Batch1：Text0, Text1
- Batch2：blue
- Batch3：Text2

例2：

使用 1 个图集：

![](Depth 计算方法-例2-使用一个图集.png)

![](使用一个图集的 Texture id.png)

可以看出 Texture id 是相同的

使用 2 个图集后：

![](Depth 计算方法-例2-分开图集后.png)

![](分开图集后的 Texture id.png)

可以发现不同图集 Texture id 不同

#### DrawCall 合批(Batch)

