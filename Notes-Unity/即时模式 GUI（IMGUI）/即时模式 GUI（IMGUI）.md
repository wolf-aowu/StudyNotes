# 即时模式 GUI（IMGUI）

## IMGUI

IMGUI 系统通常不适合用于玩家可能使用和交互的普通游戏内用户界面。对于此类用途，应使用 Unity 基于游戏对象的主 UI 系统，因为该系统提供了基于游戏对象的编辑和定位 UI 元素的方法，并有更好的工具可用于处理 UI 的可视化设计和布局。

“立即模式”指的是创建和绘制 IMGUI 的方式。要创建 IMGUI 元素，<font color=skyblue>必须编写进入名为 OnGUI 的特殊函数的代码。</font>显示界面的代码将在每帧执行，并绘制到屏幕上。除了 OnGUI 代码附加到的对象，或者层级视图中与绘制的可视元素相关的其他类型对象之外，没有其他持久性游戏对象。

IMGUI 允许使用代码创建各种功能 GUI。通过该系统，<font color=skyblue>无需创建游戏对象</font>，手动定位这些对象，然后编写一个处理对象功能的脚本，而只需几行代码即可立即执行所有操作。该代码将生成通过单个函数调用进行绘制和处理的 GUI 控件。

<font color=skyblue>常见场景：</font>

1. 有些代码已经写完，需要测试，但是美术资源还没有给到，但又不想写入工程中影响工程的连贯性，引发不必要的 bug，可以创建一个 IMGUI 按钮调试代码
2. 美术需要反复调整动画、特效等，但不想通过经历完整的游戏流程再弹出对应效果，此时可以通过 IGUI 直接触发效果
3. 测试需要通过某些指令快速得到需要的效果，类似作弊器的功能，比如金币太少，又不想耗费时间去赚，直接通过命令发送给服务端获取相应金币，然后测试再用金币去测别的东西。

### 基础知识

Unity 的 IMGUI 控件使用一个名为 OnGUI() 的特殊函数。只要启用包含脚本，就会在每帧调用 OnGUI() 函数，就像 Update() 函数一样。

```c#
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUITest : MonoBehaviour {

    void OnGUI() {
        // 创建背景框，显示一个标题文本为 “Loader Menu” 的 Box 控件。
        GUI.Box(new Rect(10, 10, 100, 90), "Loader Menu");

        // 创建第一个按钮。如果按下此按钮，则会执行 SceneManager.LoadScene(0)
        // 整个 Button 声明都位于 if 语句内。当游戏运行并单击 Button 时，此 if 语句返回 true，并执行 if 代码块中的所有代码。
        if (GUI.Button(new Rect(20, 40, 80, 20), "Scene 0")) {
            SceneManager.LoadScene(0);
        }

        // 创建第二个按钮。
        if (GUI.Button(new Rect(20, 70, 80, 20), "Scene 1")) {
            SceneManager.LoadScene(1);
        }
    }
}
```

输出：

![](图片\IMGUI.png)

#### GUI 控件

声明 GUI 控件时，需要三段关键信息：

**Type** (**Position**, **Content**)

可以看到，此结构是一个带有两个参数的函数。我们现在将探讨此结构的细节。

##### Type

Type 是指 Control Type（控件类型）；通过调用 Unity 的 GUI 类或 GUILayout 类中的函数来声明该类型（在本指南的布局模式部分对此进行了详细讨论）。例如，GUI.Label() 将创建非交互式标签。本指南稍后的控件部分将介绍所有不同的控件类型。

##### Position

Position 是所有 GUI 控件函数中的第一个参数。此参数本身随附一个 Rect() 函数。Rect() 定义四个属性：最左侧位置、最顶部位置、总宽度、总高度。所有这些值都以<font color = skyblue>整数</font>提供，对应于像素值。所有 UnityGUI 控件均在屏幕空间 (Screen Space) 中工作，此空间表示已发布的播放器的分辨率（以像素为单位）。

坐标系基于左上角。Rect(10, 20, 300, 100) 定义一个从坐标 (10,20) 开始到坐标 (310,120) 结束的矩形。值得再次强调的是，Rect() 中的第二对值是总宽度和高度，而不是控件结束的坐标。这就是为什么上面提到的例子结束于 (310,120) 而不是 (300,100)。

<font color = skyblue>可使用 Screen.width 和 Screen.height 属性来获取播放器中可用的屏幕空间的总尺寸。</font>以下示例可能有助于解释如何完成此操作：

```c#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour 
{
            
    void OnGUI()
    {
        GUI.Box (new Rect (0,0,100,50), "Top-left");
        GUI.Box (new Rect (Screen.width - 100,0,100,50), "Top-right");
        GUI.Box (new Rect (0,Screen.height - 50,100,50), "Bottom-left");
        GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Bottom-right");
    }

}
```

输出：

<img src="图片\Screen Width Height.png"  />

##### Content

GUI 控件的第二个参数是要与控件一起显示的实际内容。通常会希望在控件上显示一些文本或图像。要显示文本，请将字符串作为 Content 参数传递。

要显示图像，请声明 Texture2D 公共变量，并将变量名称作为 Content 参数传递，如下所示：

```c#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour
{
    public Texture2D icon;
    
    void OnGUI () 
    {
        if (GUI.Button (new Rect (10,10, 100, 50), icon)) 
        {
            print ("you clicked the icon");
        }
    
        if (GUI.Button (new Rect (10,70, 100, 20), "This is text")) 
        {
            print ("you clicked the text button");
        }
    }
}
```

输出：

![](图片\Icon String Content.png)

此外还可通过第三个选项在 GUI 控件中一起显示图像和文本。为此，可提供 GUIContent 对象作为 Content 参数，并定义要在 GUIContent 中显示的字符串和图像。

```c#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour
{
    public Texture2D icon;

    void OnGUI () 
    {
        GUI.Box (new Rect (10,10,100,50), new GUIContent("This is text", icon));
    }
}
```

此外，还可在 GUIContent 中定义<font color=skyblue>工具提示 (Tooltip)</font>，当鼠标悬停在 GUI 上时将工具提示显示在 GUI 中的其他位置。

```c#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour 
{
    void OnGUI () 
    {
        // 此行将 "This is the tooltip" 传入 GUI.tooltip
        GUI.Button (new Rect (10,10,100,20), new GUIContent ("Click me", "This is the tooltip"));
        
        // 此行读取并显示 GUI.tooltip 的内容
        GUI.Label (new Rect (10,40,100,20), GUI.tooltip);
    }
}
```

也可以使用 GUIContent 来显示字符串、图标和工具提示。

```c#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour 
{
    public Texture2D icon;
    
    void OnGUI () 
    {
        GUI.Button (new Rect (10,10,100,20), new GUIContent ("Click me", icon, "This is the tooltip"));
        GUI.Label (new Rect (10,40,100,20), GUI.tooltip);
    }
}
```

#### 控件类型

官方文档：https://docs.unity3d.com/cn/current/Manual/gui-Controls.html

| 类型                | 详情                                                         | 代码示例                                                     |
| ------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| Label               | 标签                                                         | GUI.Label (new Rect (25, 25, 100, 30), "Label");             |
| Button              | 按钮                                                         | if (GUI.Button (new Rect (25, 25, 100, 30), "Button"){ }     |
| RepeatButton        | Button 的变体，响应鼠标按键保持按下状态的每一帧，点击 RepeatButton 的每一帧都将返回 true | if (GUI.RepeatButton (new Rect (25, 25, 100, 30), "RepeatButton")){ } |
| TextField           | 单行文本编辑                                                 | textFieldString = GUI.TextField (new Rect (25, 25, 100, 30), textFieldString); |
| TextArea            | 多行文本编辑                                                 | textAreaString = GUI.TextArea (new Rect (25, 25, 100, 30), textAreaString); |
| Toggle              | 具有持久开/关状态的复选框，必须提供布尔值作为参数来使 Toggle 表示实际状态，返回开关状态 | toggleBool = GUI.Toggle (new Rect (25, 25, 100, 30), toggleBool, "Toggle"); |
| VerticalSlider      | 垂直滑钮                                                     | hSliderValue = GUI.HorizontalSlider (new Rect (25, 25, 100, 30), hSliderValue, 0.0f, 10.0f); |
| HorizontalSlider    | 水平滑钮                                                     | hSliderValue = GUI.HorizontalSlider (new Rect (25, 25, 100, 30), hSliderValue, 0.0f, 10.0f); |
| VerticalScrollbar   | 还有一个参数用于控制滚动条滑钮本身的高度                     | vScrollbarValue = GUI. VerticalScrollbar (new Rect (25, 25, 100, 30), vScrollbarValue, 1.0f, 10.0f, 0.0f); |
| HorizontalScrollbar | 有一个参数用于控制滚动条滑钮本身的宽度。                     | hScrollbarValue = GUI.HorizontalScrollbar (new Rect (25, 25, 100, 30), hScrollbarValue, 1.0f, 0.0f, 10.0f); |

##### Toolbar

Toolbar 控件本质上是一行 Button。在 Toolbar 上，一次只能有一个 Button 处于激活状态，并且此 Button 将一直保持激活状态，直到点击其他 Button。此行为模拟典型 Toolbar 的行为。在 Toolbar 上可以定义任意数量的 Button。Toolbar 中处于激活状态的 Button 通过整数加以跟踪。必须在函数中提供整数作为参数。要使 Toolbar 具有交互性，必须将整数分配给函数的返回值。提供的内容数组中的元素数将决定 Toolbar 中显示的 Button 数。

``` c#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour 
{                    
    private int toolbarInt = 0;
    private string[] toolbarStrings = {"Toolbar1", "Toolbar2", "Toolbar3"};
    
    void OnGUI () 
    {
        // toolbarInt 代表所选按钮的索引
        toolbarInt = GUI.Toolbar (new Rect (25, 25, 250, 30), toolbarInt, toolbarStrings);
    }
}
```

输出：

![](图片\Toolbar Example.png)

##### SelectionGrid

SelectionGrid 控件是一种多行 Toolbar。您可以决定网格中的列数和行数。一次只能激活一个 Button。SelectionGrid 中处于激活状态的 Button 通过整数加以跟踪。必须在函数中提供整数作为参数。要使 SelectionGrid 具有交互性，必须将整数分配给函数的返回值。提供的内容数组中的元素数将决定 SelectionGrid 中显示的 Button 数。还可以通过函数参数指定列数。

``` c#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour 
{             
    private int selectionGridInt = 0;
    private string[] selectionStrings = {"Grid 1", "Grid 2", "Grid 3", "Grid 4"};
    
    void OnGUI () 
    {
        // 2 代表在水平方向上放置的元素个数。除非样式定义了要使用的 fixedWidth，否则将缩放控件以适合显示。
        selectionGridInt = GUI.SelectionGrid (new Rect (25, 25, 300, 60), selectionGridInt, selectionStrings, 2);
    
    }
}
```

##### ScrollView

ScrollView 控件可显示一个包含更大控件集合的可视区域。ScrollView 需要两个 Rec 作为参数。第一个 Rect 定义 ScrollView 可视区域在屏幕上的位置和大小。第二个 Rect 定义可视区域内包含的空间大小。如果可视区域内的空间大于可视区域，则会根据需要显示滚动条。还必须分配并提供 2D 矢量，该矢量用于存储显示的可视区域的位置。

```c#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour 
{                    
    private Vector2 scrollViewVector = Vector2.zero;
    private string innerText = "I am inside the ScrollView";
    
    void OnGUI () 
    {
        // 开始 ScrollView
        scrollViewVector = GUI.BeginScrollView (new Rect (25, 25, 100, 100), scrollViewVector, new Rect (0, 0, 400, 400));
    
        // 在 ScrollView 中放入一些内容
        innerText = GUI.TextArea (new Rect (0, 0, 400, 400), innerText);
    
        // 结束 ScrollView
        GUI.EndScrollView();
    }
}
```

##### Window

Window 是可拖动的控件容器。点击时，Window 可获得和失去焦点。因此，实现方式与其他控件略有不同。每个 Window 都有一个 id 编号，并且其内容在一个单独的函数内声明，该函数在 Window 获得焦点时调用。Window 是唯一需要额外函数才能正常工作的控件。必须为 Window 提供 id 编号和要执行的函数名称。在 Window 函数中，可以创建实际行为或包含的控件。

``` c#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour 
{                    
    private Rect windowRect = new Rect (20, 20, 120, 50);
    
    void OnGUI ()
    {
        windowRect = GUI.Window (0, windowRect, WindowFunction, "My Window");
    }
    
    void WindowFunction (int windowID) 
    {
        // 该函数使窗口可拖动，传入 Rect 代表窗口的 Rect 范围内可以被拖动
        GUI.DragWindow();
    }
}
```

##### GUI.changed

要检测用户是否在 GUI 中执行了任何操作（点击按钮、拖动滑动条等），应从脚本中读取 GUI.changed 值。当用户执行了操作时，结果将获得 true，因此可以轻松验证用户输入。常见的情况是 Toolbar，这种情况下会希望根据 Toolbar 中已点击的 Button 来更改特定值。通常不希望在每次的调用 OnGUI() 中都分配该值，而只在点击其中一个 Button 时才分配该值。

``` c#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour
{                    
    private int selectedToolbar = 0;
    private string[] toolbarStrings = {"One", "Two"};
    
    void OnGUI () 
    {
        // 确定哪个按钮处于激活状态，是否在此帧进行了点击
        selectedToolbar = GUI.Toolbar (new Rect (50, 10, Screen.width - 100, 30), selectedToolbar, toolbarStrings);
    
        // 如果用户在此帧点击了新的工具栏按钮，我们将处理他们的输入
        if (GUI.changed)
        {
            Debug.Log("The toolbar was clicked");
    
            if (0 == selectedToolbar)
            {
                Debug.Log("First button was clicked");
            }
            else
            {
                Debug.Log("Second button was clicked");
            }
        }
    }
}
```

#### 自定义控件

在 Unity 的 IMGUI 系统中，可微调控件的外观，为控件添加大量细节。控件外观由 GUIStyle 决定。默认情况下，如果创建控件时未定义 GUIStyle，则会应用 Unity 的默认 GUIStyle。此样式是 Unity 的内部样式，可在已发布的游戏中将此样式用于快速原型设计，或者如果选择不对控件进行样式设置，则会采用此样式。当有大量不同的 GUIStyle 可供使用时，可在单个 GUISkin 中定义这些样式。GUISkin 只不过是 GUIStyle 的集合。

##### 样式

GUIStyle 旨在模仿 Web 浏览器的层叠样式表 (CSS)。不过，许多不同的 CSS 方法经过了改编，包括对用于样式设置的各个状态属性进行划分，在内容和外观之间进行分离，等等。控件定义内容，而样式定义外观。通过这种机制可以创建外观像普通按钮 (Button) 但功能为 开关 (Toggle) 的组合控件。

##### 皮肤与样式的区别

GUISkin 是 GUIStyle 的集合。样式定义了 GUI 控件的外观。如果要使用样式，则不必使用皮肤。

GUIStyle：

![](图片\Gui Style Inspector.png)

GUISkin：

![](图片\GUI Skin.png)

<font color = skyblue>也就是样式是针对某一种控件定义的，而皮肤可以定义多种控件。皮肤与样式的关系是一对多的关系。</font>

##### 使用样式

所有 GUI 控件函数都有可选的最后一个参数：用于显示控件的 GUIStyle。如果忽略此参数，则会使用 Unity 的默认 GUIStyle。函数内部会将控件类型的名称作为字符串应用，因此 GUI.Button() 使用“button”样式，GUI.Toggle() 使用“toggle”样式，等等。若要覆盖控件的默认 GUIStyle，可将其指定为最后一个参数。

```c#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {                   
    void OnGUI () {
        // 创建使用 "box" GUIStyle 的标签。
        GUI.Label (new Rect (0,0,200,100), "Hi - I'm a label looking like a box", "box");
    
        // 创建使用 "toggle" GUIStyle 的按钮
        GUI.Button (new Rect (10,140,180,20), "This is a button", "toggle");
    }
}
```

输出：

![](图片\Different Default Styles.png)

声明 GUIStyle 公共变量时，样式的所有元素都将显示在 Inspector 中。在该面板中可以编辑所有不同的值。

```c#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {              
    public GUIStyle customButton;
    
    void OnGUI () {
        // 创建按钮。将上面定义的 GUIStyle 作为要使用的样式传入
        GUI.Button (new Rect (10,10,150,20), "I am a Custom Button", customButton);
    }
}
```

声明 GUIStyle 后，可在 Inspector 中修改该样式。可以定义大量状态，并应用于任何类型的控件。必须先为控件状态分配 Background 颜色，然后再应用指定的 Text Color。

![](图片\Modifying Style InInspector.png)

##### 使用皮肤

对于较复杂的 GUI 系统，将一系列样式集中保存在一个位置是很有意义的。这就是 GUISkin 的作用。GUISkin 包含多种不同的样式，基本上能为所有 GUI 控件提供完整的外观修改。

要创建 GUISkin，请从菜单栏中选择 Assets > Create > GUI Skin。随后将在 Project 文件夹中创建一个 GUI Skin。选择该 GUI Skin 即可在 Inspector 中查看其定义的所有 GUIStyle。要使用已创建的皮肤，请将其分配给 OnGUI() 函数中的 GUI.skin。

```c#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {                    
    public GUISkin mySkin;
    
    void OnGUI () {
        // 将该皮肤指定为当前使用的皮肤。
        GUI.skin = mySkin;
    
        // 创建按钮。此时将从分配给 mySkin 的皮肤获得默认的 "button" 样式。
        GUI.Button (new Rect (10,10,150,20), "Skinned Button");
    }        
}
```

通过单个 OnGUI() 调用即可按需多次切换皮肤。

``` c#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {                    
    public GUISkin mySkin;
    private bool toggle = true;
    
    void OnGUI () {
        // 将该皮肤指定为当前使用的皮肤。
        GUI.skin = mySkin;
    
        // 创建开关。此时将从分配给 mySkin 的皮肤获得 "button" 样式。
        toggle = GUI.Toggle (new Rect (10,10,150,20), toggle, "Skinned Button", "button");
    
        // 将当前皮肤指定为 Unity 的默认值。
        GUI.skin = null;
    
        // 创建按钮。此时将从内置皮肤获得默认的 "button" 样式。
        GUI.Button (new Rect (10,35,150,20), "Built-in Button");
    }        
}
```

##### 更改 GUI 字体大小

此示例将展示如何通过代码来动态更改字体大小。单击播放以查看字体的大小随时间循环增大和减小的行为。此时可能会注意到字体不能平滑地改变大小，这是因为字体大小不是无限数量的。此特定示例要求加载默认字体 (Arial) 并将其标记为动态。无法更改未标记为动态的任何字体的大小。

``` c#
using UnityEngine;    
using System.Collections;
    
public class Fontsize : MonoBehaviour
{
    void OnGUI ()
    {
        //将 GUIStyle 样式设置为标签
        GUIStyle style = GUI.skin.GetStyle ("label");
        
        //将样式字体大小设置为随时间增大和减小
        style.fontSize = (int)(20.0f + 10.0f * Mathf.Sin (Time.time));
        
        //创建一个标签并使用当前设置来显示
        GUI.Label (new Rect (10, 10, 200, 80), "Hello World!");
    }        
}
```

#### 布局大小

使用 IMGUI 系统时，可使用两种不同的模式来排列和组织 UI：固定布局模式和自动布局模式。到目前为止，本指南中提供的每个 IMGUI 示例都使用了固定布局。要使用自动布局，应在调用控件函数时写入 GUILayout 而不是 GUI。不必使用一种布局模式来替代另一种布局模式，可在同一 OnGUI() 函数中同时使用这两种模式。

当有预先设计好的界面可供使用时，采用固定布局比较合理。如果预先不知道需要多少元素，或者不想费心进行每个控件的手动定位，则采用自动布局比较合适。例如，如果要基于保存游戏文件创建大量不同的按钮，但无法准确知道要绘制多少按钮，这种情况下采用自动布局可能会更加合理。具体实际上取决于游戏设计以及所需的界面呈现方式。

使用自动布局时有两个主要的不同之处：

- 使用 GUILayout 而不是 GUI
- 自动布局控件不需要 Rect() 函数

根据使用的布局模式，可通过不同的挂钩来控制控件的位置以及控件如何组合在一起。在固定布局中，可将不同的控件放入组中。在自动布局中，可将不同的控件放入区域、水平组和垂直组中。

##### 固定布局 - 组

组是固定布局模式中的布局规则。使用组可以定义包含多个控件的屏幕区域。为定义组中包含的控件，需要使用 GUI.BeginGroup() 和 GUI.EndGroup() 函数。组内的所有控件将根据组的左上角而不是屏幕的左上角进行定位。因此，如果在运行时重新定位组，则将保持组中所有控件的相对位置。

例如，在屏幕上使多个控件居中非常容易。

```c#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
    void OnGUI () {
        // 在屏幕中央创建一个组
        GUI.BeginGroup (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100));
        // 现在所有矩形都调整到该组。(0,0) 是该组的左上角。
    
        //我们将创建一个框形，以便能看到该组在屏幕上的位置。
        GUI.Box (new Rect (0,0,100,100),"Group is here");
        GUI.Button (new Rect (10,40,80,30), "Click me");
    
        // 结束我们上面开始的组。记住这一点非常重要！
        GUI.EndGroup ();
    }
}
```

输出：

![](图片\Group Centered Controls.png)

还可以将多个组嵌套在一起。这样做时，每个组的内容都会裁剪到其父项空间。

```c#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {    
    // 256 x 32 的背景图像
    public Texture2D bgImage; 
    
    // 256 x 32 的前景图像
    public Texture2D fgImage; 
    
    // 介于 0.0 和 1.0 之间的浮点数
    public float playerEnergy = 1.0f; 
    
    void OnGUI () {
        // 创建一个组来包含这两个图像
        // 调整前 2 个坐标以将其放在屏幕上的其他位置
        GUI.BeginGroup (new Rect (0,0,256,32));
    
        // 绘制背景图像
        GUI.Box (new Rect (0,0,256,32), bgImage);
    
            // 创建将被裁剪的第二个组
            // 我们想要裁剪图像而不是缩放图像，这就是我们需要第二个组的原因
            GUI.BeginGroup (new Rect (0,0,playerEnergy * 256, 32));
        
            // 绘制前景图像
            GUI.Box (new Rect (0,0,256,32), fgImage);
        
            // 结束这两个组
            GUI.EndGroup ();
        
        GUI.EndGroup ();
    }
}
```

输出：

![](图片\Nested Groups Clipping.png)

##### 自动布局 - 区域

区域仅用于自动布局模式。区域定义了有限的屏幕区域来包含 GUILayout 控件，因此在功能上类似于固定布局组。由于自动布局的性质，几乎始终要用到区域。

在自动布局模式下，不需要在控制级别定义绘制控件的屏幕区域。控件将自动放置在包含该控件的区域的最左上角。此区域可能是指屏幕。此外也可以创建手动定位的区域。一个区域内的 GUILayout 控件将放置在该区域的最左上角。

请注意，在一个区域内，具有可见元素（如按钮和框形）的控件会将宽度拉伸到该区域的整个长度。

```c#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
    void OnGUI () {
        GUILayout.Button ("I am not inside an Area");
        GUILayout.BeginArea (new Rect (Screen.width/2, Screen.height/2, 300, 300));
        GUILayout.Button ("I am completely inside an Area");
        GUILayout.EndArea ();
    }
}
```

##### 自动布局 - 水平和垂直组

使用自动布局时，默认情况下控件将从上到下依次出现。在很多情况下，需要更精确控制控件的放置位置以及排列方式。如果使用自动布局模式，则可以选择水平和垂直组。

与其他布局控件一样，可以调用单独的函数来开始或结束这些组。这些函数为 GUILayout.BeginHorizontal()、GUILayout.EndHorizontal()、GUILayout.BeginVertical() 和 GUILayout.EndVertical()。

水平组内的所有控件都将始终采用水平布局方式。垂直组内的所有控件都将始终采用垂直布局方式。这听起来很简单，但若要将组嵌套在彼此内部，就不那么简单了。通过嵌套的方式可在任何能够想象的配置中排列任意数量的控件。

```c#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {
    private float sliderValue = 1.0f;
    private float maxSliderValue = 10.0f;
    
    void OnGUI()
    {
        // 将所有控件包裹在指定的 GUI 区域中
        GUILayout.BeginArea (new Rect (0,0,200,60));
    
        // 开始单个水平组
        GUILayout.BeginHorizontal();
    
        // 正常放置按钮
        if (GUILayout.RepeatButton ("Increase max\nSlider Value"))
        {
            maxSliderValue += 3.0f * Time.deltaTime;
        }
    
        // 在按钮旁边垂直排列另外两个控件
        GUILayout.BeginVertical();
        GUILayout.Box("Slider Value: " + Mathf.Round(sliderValue));
        sliderValue = GUILayout.HorizontalSlider (sliderValue, 0.0f, maxSliderValue);
    
        // 结束这些组和区域
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }
}
```

##### 使用 GUILayoutOption 定义一些控件

可使用 GUILayoutOption 覆盖某些自动布局参数。要执行此操作，可提供相应的选项作为 GUILayout 控件的最终参数。在上面的区域示例中，是否还记得按钮的宽度扩展到区域宽度的 100%？如果愿意，我们可以覆盖这种行为。

``` c#
using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {        
    void OnGUI () {
        GUILayout.BeginArea (new Rect (100, 50, Screen.width-200, Screen.height-100));
        GUILayout.Button ("I am a regular Automatic Layout Button");
        GUILayout.Button ("My width has been overridden", GUILayout.Width (95));
        GUILayout.EndArea ();
    }
}
```

#### GUIStyle

GUI Style 是与 UnityGUI 结合使用的自定义属性的集合。单个 GUI Style 定义了单个 UnityGUI 控件的外观。

<font color = skyblue>如果要将样式添加到多个控件，请使用 GUI Skin 而不是 GUI Style。</font>

GUIStyle 在脚本中进行声明并基于每个实例进行修改。如果要使用具有自定义样式的单个或几个控件，可在脚本中声明此自定义样式，并将此样式作为控件函数的参数。这样就会以定义的样式显示这些控件。首先，必须在脚本中声明 GUI Style。

``` c#
var customGuiStyle : GUIStyle;
```

将此脚本附加到游戏对象时，Inspector 中将显示可修改的自定义样式。

![](图片\Modifying Style InInspector.png)

现在，希望特定的控件使用此样式时，可将此样式的名称作为控件函数中的最后一个参数。

```javascript
function OnGUI () {
    // 提供样式的名称作为最后一个参数以便使用该样式
    GUILayout.Button ("I am a custom-styled Button", customGuiStyle);

    // 如果不想应用该样式，请不要提供名称
    GUILayout.Button ("I am a normal UnityGUI Button without custom style");
}
```

输出：

![](图片\Two Buttons One Is Styled.png)

##### 属性

| 属性           | 功能                                                       |
| :------------- | :--------------------------------------------------------- |
| Name           | 可用于指代此特定样式的文本字符串                           |
| Normal         | 控件在默认状态下显示的背景图像和文本颜色                   |
| Hover          | 当鼠标位于控件上方时显示的背景图像和文本颜色               |
| Active         | 当鼠标主动单击控件时显示的背景图像和文本颜色               |
| Focused        | 控件获得键盘焦点时显示的背景图像和文本颜色                 |
| On Normal      | 控件在启用状态下显示的背景图像和文本颜色                   |
| On Hover       | 当鼠标位于已启用的控件上方时显示的背景图像和文本颜色       |
| On Active      | 当鼠标主动单击已启用的控件时显示的属性                     |
| On Focused     | 已启用的控件获得键盘焦点时显示的背景图像和文本颜色         |
| Border         | 背景图像每条边的像素数（不受控件形状比例影响）             |
| Padding        | 从控件每个边缘到内容起始位置的空间（以像素为单位）。       |
| Margin         | 以此样式渲染的元素与任何其他 GUI 控件之间的边距。          |
| Overflow       | 要添加到背景图像的额外空间。                               |
| Font           | 用于此样式中所有文本的字体                                 |
| Image Position | 背景图像和文本的组合方式。                                 |
| Alignment      | 标准文本对齐选项。                                         |
| Word Wrap      | 如果启用此属性，到达控件边界的文本将换到下一行             |
| Text Clipping  | 如果启用了 Word Wrap，选择超出控件边界的文本的处理方式     |
| Overflow       | 任何超出控件边界的文本都将继续超出边界                     |
| Clip           | 任何超出控件边界的文本都将隐藏起来                         |
| Content Offset | 除了所有其他属性之外，内容在 X 和 Y 轴上移位的像素数       |
| X              | 左/右偏移                                                  |
| Y              | 上/下偏移                                                  |
| Fixed Width    | 控件宽度的像素数，此值将覆盖任何提供的 Rect() 值           |
| Fixed Height   | 控件高度的像素数，此值将覆盖任何提供的 Rect() 值           |
| Stretch Width  | 如果启用此属性，则可以水平拉伸使用此样式的控件来改善布局。 |
| Stretch Height | 如果启用此属性，则可以垂直拉伸使用此样式的控件来改善布局。 |

#### GUISkin

GUISkin 是可应用于 GUI 的 GUIStyle 的集合。每种控件 (Control) 类型都有自己的样式定义。皮肤 (Skin) 的主要目的将样式应用于整个 UI，而不是应用于单独的控件本身。

要创建 GUISkin，请从菜单栏中选择 Assets > Create > GUI Skin。

请注意：本页面适用于 IMGUI 系统的一部分；该系统是一个仅限于脚本的 UI 系统。Unity 有一个完整的基于游戏对象的 UI 系统，您可能更希望使用该系统。该系统允许在 Scene 视图中以可见对象的形式设计和编辑用户界面元素。

在为游戏创建整个 GUI 时，可能需要为每种不同的控件类型进行大量自定义。在许多不同的游戏类型中，例如实时策略或角色扮演类游戏，实际上需要定义每种单一的控件类型。

因为每个单独的控件都使用特定的样式，所以创建十几个单独的样式并手动分配样式是不合理的做法。GUI Skin 能解决这一问题。通过创建 GUI Skin，可为每个单独的控件设置预定义的样式集合。然后，只需使用一行代码即可应用皮肤 (Skin)，因此无需手动指定每个单独控件的样式。

##### 使用 GUISkin

要将 GUISkin 应用于 GUI，必须使用简单的脚本来读取皮肤并将其应用于控件。

```c#
/ 创建一个公共变量，我们稍后可向其中分配 GUISkin
var customSkin : GUISkin;

// 在 OnGUI() 函数中应用皮肤
function OnGUI () {
    GUI.skin = customSkin;

    // 现在创建喜欢的任何控件，这些控件将与自定义皮肤一起显示
    GUILayout.Button ("I am a re-Skinned Button");

    // 可为某些控件（但并非所有控件）更改或移除皮肤
    GUI.skin = null;

    // 此处创建的所有控件都将使用默认皮肤而不是自定义皮肤
    GUILayout.Button ("This Button uses the default UnityGUI Skin");
}
```

##### 属性

GUI Skin 中的所有属性都是单独的 GUIStyle。全局修改。

下面是部分属性：

| 属性                      | 功能                                         |
| :------------------------ | :------------------------------------------- |
| Custom 1–20               | 可应用于任何控件的其他自定义样式             |
| Custom Styles             | 一组可应用于任何控件的其他自定义样式         |
| Settings                  | 整个 GUI 的其他设置                          |
| Double Click Selects Word | 如果启用此选项，则双击某个单词将选中该单词   |
| Triple Click Selects Line | 如果启用此选项，则单击三次某个单词将选中该行 |
| Cursor Color              | 键盘光标的颜色                               |
| Cursor Flash Speed        | 编辑文本控件时文本光标的闪烁速度             |
| Selection Color           | 文本所选区域的颜色                           |

## 扩展编辑器

### 编辑器窗口

为了创建编辑器窗口，必须将脚本存储在 Editor 文件夹中，且脚本派生自 Editor Window 类。在 OnGUI 函数中编写 GUI 控件。要在屏幕上显示窗口需要创建一个菜单项来显示该窗口，所以需要创建一个由 MenuItem 属性激活的函数。

```c#
using UnityEngine;
using UnityEditor;
using System.Collections;

class AssetBundleNameManager : EditorWindow {
    [MenuItem ("AssetBundle/AssetBundleNameManager")]

    public static void  ShowWindow () {
        // 创建一个标准、可停靠的编辑器窗口，该窗口可以在调用之间保存自己的位置，可以用在自定义布局中等等。
        EditorWindow.GetWindow(typeof(AssetBundleNameManager));
    }
    
    void OnGUI () {
        // 此处为实际窗口代码
    }
}
```

输出：

<img src="图片\GetWindow.png" style="zoom: 33%;" />

`GetWindow` 将创建一个标准、可停靠的编辑器窗口。该窗口可以在调用之间保存自己的位置，可以用在自定义布局中等等。为了更好地控制创建的内容，可以使用 [GetWindowWithRect](https://docs.unity3d.com/cn/current/ScriptReference/EditorWindow.GetWindowWithRect.html)，此方法创建的窗口不能在浮动状态下随意改变窗口大小。

<font color = skyblue>应通过实现 OnGUI 函数来渲染窗口的实际内容。</font>可以使用与游戏内 GUI 相同的 UnityGUI 类（GUI 和 GUILayout）。此外，我们提供了一些额外 GUI 控件，这些控件位于仅用于编辑器的EditorGUI 和 EditorGUILayout 类中。这些类将添加到普通类中已有的控件，因此您可以随意混合和搭配。

以下 C# 代码显示了将 GUI 元素添加到自定义 EditorWindow 的方式：

```c#
using UnityEditor;
using UnityEngine;

public class AssetBundleNameManager : EditorWindow
{
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    
    // 将名为"AssetBundleNameManager"的菜单项添加到 AssetBundle 菜单
    [MenuItem("AssetBundle/AssetBundleNameManager")]
    public static void ShowWindow()
    {
        //显示现有窗口实例。如果没有，请创建一个。
        EditorWindow.GetWindow(typeof(AssetBundleNameManager));
    }
    
    void OnGUI()
    {
        GUILayout.Label ("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField ("Text Field", myString);
        
        groupEnabled = EditorGUILayout.BeginToggleGroup ("Optional Settings", groupEnabled);
            myBool = EditorGUILayout.Toggle ("Toggle", myBool);
            myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup ();
    }
}
```

输出：

<img src="图片\OnGUI 显示.png" style="zoom:33%;" />
