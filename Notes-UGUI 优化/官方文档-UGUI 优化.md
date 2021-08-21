### Unity UI 优化常见问题

- GPU 片段着色器使用率过高（即填充率过度使用）
- 重建 Canvas 批处理所用的 CPU 时间过长
- Canvas 批次的重建数量过多（过度污染）
- 花费过多的 CPU 时间来生成顶点（通常来自文本）

### Unity UI 基础

#### 术语

画布是 Unity 的原生代码组件，被 Unity 的渲染系统用来对几何图形分层，这些几何图形将被绘制在游戏的世界空间中，或在其上面。

画布负责将其组成的几何图形组合成批次，生成适当的渲染命令，并将其发送到 Unity 的图形系统。所有这些都是在本地 C++ 代码中完成的，被称为一次重批 或 一次批量构建。当一个 Canvas 被标记为包含需要重新批处理的几何图形时，该 Canvas 被认为是脏的。

几何图形是由 Canvas Renderer 组件提供给 Canvas 的。

子画布只是一个嵌套在另一个画布组件中的画布组件。子画布将其子女与父画布隔离开来；一个肮脏的子画布不会迫使父画布重建其几何图形，反之亦然。<font color = #10ac84>在某些边缘情况下这是不正确的，例如，当父画布的变化导致子画布的大小调整时。</font>

形是由 Unity UI C# 库提供的一个基类。它是所有 Unity UI C# 类的基类，为Canvas 系统提供可绘制的几何图形。大多数内置的 Unity UI 图形是通过MaskableGraphic 子类实现的，它允许通过 IMaskable 接口对其进行屏蔽。Drawable 的主要子类是 Image 和 Text，它们提供同名的组件。

布局组件控制 RectTransforms 的大小和定位，通常用于创建需要相对大小或相对定位其内容的复杂布局。布局组件只依赖于 RectTransforms ，并且只影响其相关的 RectTransforms 的属性。它们不依赖于 Graphic 类，可以独立于 Unity UI 的图形组件使用。

图形和布局组件都依赖于 CanvasUpdateRegistry 类，该类在 Unity Editor 的界面中没有公开。这个类跟踪必须更新的 Layout 组件和 Graphic 组件的集合，并在它们相关的 Canvas 调用 willRenderCanvases 事件时根据需要触发更新。

