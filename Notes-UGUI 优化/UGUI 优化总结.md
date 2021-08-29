### 总结

- 一个 Canvas 一个图集
- 一个 Canvas 中，有一部分是动的，一部分是不动的时，动静分离，再建一个 Canvas 动的和动的放一起，静的和静的放一起
- 创建一个公用图集，当一张图被多个面板共同使用时，就将资源放入该图集
- 顶点不要超过 100,000 个。
- 减少 Prefab 的深度
- 对键盘、鼠标等输入检测的 Canvas 不要挂载 Graphic Raycaster 组件
- 不需要射线检测的 UI 也不要勾选 Raycast Target
- 禁用不可见的 UI
- 尽量避免将 alpha 设置为 0
- 尽量少用 Mask 之类的遮罩组件
- 少用 Scroll View，使用 对象池、循环列表 等方法实现

### 界面/控件隐藏的多种方案

1. SetActive 会产生 GC，会导致画布丢弃它的 VBO 数据，从而重建和重新批处理，操作频繁时 GC 导致 CPU 占用可能会卡顿。
2. enable Canvas，禁用画布，能降低 dc，避免 SetActive 的 GC 开销，但测试依旧会有 SendWillRenderCanvases 的开销。
3. 移出 RootCanvas，似乎没有多大优化，理论上会降低dc且不会引起重建。
4. 将单独界面使用 Canvas，绑定一个 Camera 在隐藏时设置 Layer 进行 CullingMask 屏蔽，同时禁用GraphicsRaycaster，能避免重建，但随着 canvas 增多 dc 会增多，同时界面较多时管理比较费力，注意动态 UI 的事件。
5. 设置 Canvas Group 的 alpha，依旧会被渲染，但能避免 setactive 带来的巨大开销，且容易操作。
6. 更改 Scale 的值为 0，顶点信息被清除，这样不会减少 dc 开销，同时还会引起重建，不采用。
7. 设置一个 Canvas 作为根节点，将其 Layer 设置为相机屏蔽的层级，同时禁用 GraphicsRaycaster，当需要隐藏某个界面时将其以该 Canvas 作为根节点移到其下，这样能避免重建同时减少 dc，但会有一些 SetParent 带来的消耗。目前采用该方案。
8. 如果只是隐藏某个 Graphic 类的，可以考虑获取 canvasRenderer.cull 设置为true (需要注意的是，在使用 RectMask2D 时，该属性会被修改，一般可在非使用 RectMask2D 的时候代码处理)。
   

<font color = orange>注意：   </font>在不适用 SetActive 的情况下，无法避免隐藏状态下继承自 MonoBehavior 中的周期函数被调用，特别是 Update 与 Lateupdate。要避免这一问题，以这种方式实现隐藏的 UI 上的 MonoBehaviour 不应该直接实现 Unity 的生命周期回调，而应该去接收它们的 UI 根节点的自定义的 “CallbackManager” 的回调。当UI被显示和隐藏是，这个 “CallbackManager” 应该收到通知，并决定是否传播生命周期事件。

### 一般原则

1. 将 UI 细分到很多子画布，但要画布系统同样不会为不同画布中的元素合并批处理。设计高效UI需要在最小化重建开销和最小化无用批处理之间权衡。
2. 因为画布会在其中的任意组件发生变化时进行重新批处理，所以最好将有用的(non-trivial)画布分成至少两部分。进一步将，最好将那些同时变化的元素放到同一画布上。例如，进度条和倒计时UI，它们都依靠相同的底层数据，因此会同时更新，所以它们应该放在同一画布上。
3. 修改 material 改颜色和直接改 color 属性在性能消耗要权衡,修改材质会增加drawcall，修改color属性会重建，根据测试结果来选择。

4. 优化策略通常是牺牲某一方面来提升另一方面的性能，例如几种避免重建的隐藏界面的方案，由于缓存的顶点数据不会被清除，因此必然带来内存的增加，而如果清除内存中顶点数据，又必然需要在显示时重建合批。
5. 粒子系统的渲染和UI是独立的，仅能通过Render Order来改变两者的渲染顺序，而粒子系统的变化并不会引起UI部分的重建。