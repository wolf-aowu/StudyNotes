## Events（事件）

事件分成两部分：发布者（publisher）和订阅者（subscribers）。发布者拥有一个事件，订阅者订阅事件。多个订阅者可以订阅同一个事件。当某些事发生时，发布者触发该事件并且所有订阅该事件的订阅者会受到通知该事件已被触发。关键是发布者不知道订阅该事件的订阅者有谁，可能有很多订阅者也可能没有。订阅者可能会处理该事件或者完全忽略该事件。发布者不知道且不关心谁在监听该事件，也不关心他们对该事件做了什么。因此，这允许你在发布者中编写代码，该代码与您还想运行的任何其他代码分离，而这些代码不是必需的。

例子：

发布者与订阅者在同一个类中。

TestingEvents.cs

``` c#
using System;
using UnityEngine;

public class TestingEvents : MonoBehaviour {
    // 通常事件的名称定义以 On 开头
    // 事件的定义
    public event EventHandler OnSpacePressed;
    
    private void Start() {
        // 订阅事件
        OnSpacePressed += Testing_OnSpacePressed;
    }
    
    // 传参和返回类型必须与事件定义相同
    private void Testing_OnSpacePressed(object sender, EventArgs e) {
        Debug.Log("Space!");
    }
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            // 触发事件
            if（OnSpacePressed != null) {
                OnSpacePressed(this, EventArgs.Empty);
            }
            // 更简单的写法
            OnSpacePressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
```

发布者与订阅者在不同的类中。

TestingEvents.cs

``` c#
using System;
using UnityEngine;

public class TestingEvents : MonoBehaviour {
    // event 是关键字，通常事件的名称定义以 On 开头
    // 事件的定义
    public event EventHandler<OnSpacePressedEventArgs> OnSpacePressed;
    // 为事件的入参创建一个类，事件只传这个类即可，继承 EventArgs
    public class OnSpacePressedEventArgs : EventArgs {
        // 这里可以自定义入参
        public int spaceCount;
    }
    
    private int spaceCount;
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            spaceCount++;
            OnSpacePressed?.Invoke(this, new OnSpacePressedEventArgs { spaceCount = spaceCount });
        }
    }
}
```

TestingEventSubscriber.cs

``` c#
using UnityEngine;

public class TestingEventSubscriber : MonoBehaviour {
    private void Start() {
        TestingEvents testingEvents = GetComponent<TestingEvents>();
        // 订阅事件
        testingEvents.OnSpacePressed += TestingEvents_OnSpacePressed;
    }
    
    private void TestingEvents_OnSpacePressed(object sender, TestingEvents.OnSpacePressedEventArgs e) {
        Debug.Log("Space!" + e.spaceCount);
        TestingEvents testingEvents = GetComponent<TestingEvents>();
        // 取消订阅事件
        testingEvents.OnSpacePressed -= TestingEvents_OnSpacePressed;
    }
}
```

也可以不使用 EventHandler 定义，因为 EventHandler 是给 .Net 用的。

TestingEvents.cs

``` c#
using System;
using UnityEngine;

public class TestingEvents : MonoBehaviour {
    public delegate void TestEventDelegate(float f);
    public event TestEventDelegate OnFloatEvent;
    
    private int spaceCount;
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            spaceCount++;
            OnFloatEvent?.Invoke(this, 5.5f});
        }
    }
}
```

TestingEventSubscriber.cs

``` c#
using UnityEngine;

public class TestingEventSubscriber : MonoBehaviour {
    private void Start() {
        TestingEvents testingEvents = GetComponent<TestingEvents>();
        // 订阅事件
        testingEvents.OnFloatEvent += TestingEvents_OnFloatEvent;
    }
    
    private void TestingEvents_OnFloatEvent(float f) {
        Debug.Log("Float:" + f);
    }
}
```

使用 Action。

TestingEvents.cs

``` c#
using System;
using UnityEngine;

public class TestingEvents : MonoBehaviour {
    public event Action<bool, int> OnSpacePressed;
    
    private int spaceCount;
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            spaceCount++;
            OnSpacePressed?.Invoke(true, 56});
        }
    }
}
```

TestingEventSubscriber.cs

``` c#
using UnityEngine;

public class TestingEventSubscriber : MonoBehaviour {
    private void Start() {
        TestingEvents testingEvents = GetComponent<TestingEvents>();
        // 订阅事件
        testingEvents.OnActionEvent += TestingEvents_OnActionEvent;
    }
    
    private void TestingEvents_OnActionEvent(bool arg1, int arg2) {
        Debug.Log(arg1 + " " + arg2);
    }
}
```

UnityEvent 可以在 Unity 中可视化，去 Unity 中配置。

TestingEvents.cs

``` c#
using System;
using UnityEngine;
using unityEngine.Events;

public class TestingEvents : MonoBehaviour {
    public UnityEvent OnUnityEvent;
    
    private int spaceCount;
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            spaceCount++;
            OnUnityEvent?.Invoke(});
        }
    }
}
```

TestingEventSubscriber.cs

``` c#
using UnityEngine;

public class TestingEventSubscriber : MonoBehaviour {
    public void TestingUnityEvent() {
        Debug.Log("TestingUnityEvent");
    }
}
```

总结：发布者决定事件的定义，事件在何时执行。订阅者决定事件执行的内容。

## Delegate（委托）

单播委托

Testing.cs

``` c#
using UnityEngine;

public class Testing : MonoBehaviour {
    // delegate 是关键字，void 是返回值
    public delegate void TestDelegate();
    
    private TestDelegate testDelegateFunction;
    
    private void Start() {
        testDelegateFunction = MyTestDelegateFunction;
        testDelegateFunction();
    }
    
    private void MyTestDelegateFunction() {
        Debug.Log("MyTestDelegateFunction");
    }
}
```

多播委托

Testing.cs

``` c#
using UnityEngine;

public class Testing : MonoBehaviour {
    // delegate 是关键字，void 是返回值
    public delegate void TestDelegate();
    
    private TestDelegate testDelegateFunction;
    
    private void Start() {
        testDelegateFunction = MyTestDelegateFunction;
        testDelegateFunction += MyTestDelegateFunction;        
        testDelegateFunction();
        
        // 取消委托
        testDelegateFunction -= MyTestDelegateFunction；        
        testDelegateFunction();
    }
    
    private void MyTestDelegateFunction() {
        Debug.Log("MyTestDelegateFunction");
    }
    
    private void MySecondTestDelegateFunction() {
		Debug.Log("MySecondTestDelegateFunction")
    }
}
```

带返回值和参数的委托

Testing.cs

``` c#
using UnityEngine;

public class Testing : MonoBehaviour {
    public delegate bool TestBoolDelegate(int i);
    
    private TestBoolDelegate testBoolDelegateFunction;
    
    private void Start() {
        testBoolDelegateFunction = MyTestBoolDelegateFunction;
        Debug.Log(testBoolDelegateFunction(1));
    }
    
    // 入参名字不需要与委托定义的入参名相同
    private bool MyTestBoolDelegateFunction(int i) {
        return i < 5;
    }
}
```

使用匿名函数

<font color=skyblue>缺点：无法取消委托</font>

Testing.cs

``` c#
using UnityEngine;

public class Testing : MonoBehaviour {
    // delegate 是关键字，void 是返回值
    public delegate void TestDelegate();
    
    private void Start() {
        testDelegateFunction = delegate () { Debug.Log("Anonymous method"); };
        testDelegateFunction();
    }
}
```

使用 lambda 表达式

<font color=skyblue>缺点：无法取消委托</font>

Testing.cs

``` c#
using UnityEngine;

public class Testing : MonoBehaviour {
    // delegate 是关键字，void 是返回值
    public delegate void TestDelegate();
    
    private void Start() {
        testDelegateFunction = () => { Debug.Log("Lambda expression"); };
        testDelegateFunction();
        // 带返回值和参数的 lambda 表达式
        testDelegateFunction = (int i) => { return i < 5; };
        // 简化上面语句，前提是大括号中的语句只有一句
        testDelegateFunction = (int i) => return i < 5;
    }
}
```

### 内置函数

#### Action

需要引用 System 命名空间，没有返回值。

Testing.cs

``` c#
using System
using UnityEngine;

public class Testing : MonoBehaviour {
    private Action testAction;
    private Action<int, float> testIntFloatAction;
    
    private void Start() {
        testIntFloatAction = (int i, float f) => { Debug.Log() };
    }
}
```

#### Func

需要引用 System 命名空间。

Testing.cs

``` c#
using System
using UnityEngine;

public class Testing : MonoBehaviour {
    // 只有返回值
    private Func<bool> testFunc;
    // 有入参，也有返回值，返回值的数据类型写在最后
    private Func<int, bool> testIntBoolFunc;
    
    private void Start() {
        testFunc = () => false;
        testIntBoolFunc = (int i) => { return i < 5; };
    }
}
```

### 实际运用

一个有关计时器的例子。

ActionOnTimer.cs

``` c#
using UnityEngine;

public class ActionOnTimer : MonoBehaviour{
    private float timer;
    
    public void SetTimer(float timer) {
        this.timer = timer;
    }
    
    private void Update() {
        timer -= Time.deltaTime;
    }
    
    public bool IsTimerComplete() {
        return timer <= 0f;
    }
}
```

Testing.cs

``` c#
using UnityEngine;

public class Testing : MonoBehaviour {
    [SerializedField] private ActionOnTimer actionOnTimer;
    private bool hasTimerElapsed;
    
    private void Start() {
        actionOnTimer.SetTimer(1f);
    }
    
    private void Update() {
        if(!hasTimerElapsed && actionOnTimer.IsTimerComplete()) {
            Debug.Log("Timer complete");
            hasTimerElapsed = true;
        }
    }
}
```

改进

ActionOnTimer.cs

``` c#
using UnityEngine;

public class ActionOnTimer : MonoBehaviour{
    private Action timerCallback;
    private float timer;
    
    public void SetTimer(float timer, Action timerCallback) {
        this.timer = timer;
        this.timerCallback = timerCallback;
    }
    
    private void Update() {
        if (timer > 0f) {
            timer -= Time.deltaTime;
        
            if (IsTimerComplete()) {
                timerCallback();
            }
        }
    }
    
    public bool IsTimerComplete() {
        return timer <= 0f;
    }
}
```

Testing.cs

``` c#
using UnityEngine;

public class Testing : MonoBehaviour {
    [SerializedField] private ActionOnTimer actionOnTimer;
    
    private void Start() {
        actionOnTimer.SetTimer(1f, () => { Debug.Log("Timer complete!"); });
    }
}
```

一个关于角色有多种攻击形式的例子。这个例子代码不全，主要理解如何将代码改成使用委托。

PlayerDelegates.cs

``` c#
public class PlayerDelegates : MonoBehaviour {
    private void Update() {
        switch (state) {
            default:
            case State.Idle:
                HandleMovement();
                HandleAttack();
                break;
            case State.Busy:
                HandleAttack():
                break;
        }
    }
    
    private void SetUseSword() {
        isUsingSword = true;
    }
    
    private void HandleAttack() {
        if (Input.GetMouseButtonDown(0)) {
            if (isUsingSword) {
                SwordAttack();
            }
            else {
                PunchAttack();
            }
        }
    }
}
```

改进

不再需要使用 isUsingSword 的 bool 值来判断。

PlayerDelegates.cs

``` c#
public class PlayerDelegates : MonoBehaviour {
    private Action attackFunction;
    
    private void Start() {
    	attackFunction = PunchAttack;
    }
    
    private void Update() {
        switch (state) {
            default:
            case State.Idle:
                HandleMovement();
                HandleAttack();
                break;
            case State.Busy:
                HandleAttack():
                break;
        }
        
        if (Input.GetKeyDown(KeyCode.M)) {
            SetUseSword();
        }
    }
    
    private void SetUseSword() {
        attackFunction = SwordAttack;
    }
    
    private void HandleAttack() {
        if (Input.GetMouseButtonDown(0)) {
            attackFunction();
        }
    }
}
```

## Generics（泛型）

它允许函数、类型不定义传入类型。

例子

TestingGenerics.cs

``` c#
using UnityEngine;
public class TestingGenerics : MonoBehaviour {
    private void Start() {
        int[] intArray = CreateArray(5, 6);
        Debug.Log(intArray.Length + " " + intArray[0] + " " + intArray[1]);
        
        CreateArray("asdf", "qwerty")
    }
    
    private int[] CreateArray(int firstElement, int secondElement) {
        return new int[] { firstElement, secondElement };
    }
    
    private string[] CreateArray(string firstElement, string secondElement) {
        return new string[] { firstElement, secondElement };
    }
}
```

改进

在上面的例子里重载了 CreateArray 方法，但是方法逻辑上没有本质上不同，只是改变了返回值和入参的数据类型。这就可以用到泛型，泛型能够适用于任何数据类型，我们只需要写一遍 CreateArray 方法。

TestingGenerics.cs

``` c#
using UnityEngine;
public class TestingGenerics : MonoBehaviour {
    private void Start() {
        int[] intArray = CreateArray<T>(5, 6);
        Debug.Log(intArray.Length + " " + intArray[0] + " " + intArray[1]);
        
        CreateArray<string>("asdf", "qwerty")
    }
    
    // T 可以更改为任何名字，但是一般用 T 来表示，或者以 T 开头
    private T[] CreateArray<T>(T firstElement, T secondElement) {
        return new string[] { firstElement, secondElement };
    }
}
```

多个泛型

TestingGenerics.cs

``` c#
using UnityEngine;
public class TestingGenerics : MonoBehaviour {
    private void Start() {
        TestMultiGenerics<int, string>(56, "asdf");
    }
    
    // T 可以更改为任何名字，但是一般用 T 来表示，或者以 T 开头
    private void TestMultiGenerics<T1，T2>(T1 t1,T2 t2) {
        Debug.Log(t1.GetType());
        Debut.Log(t2.GetType());
    }
}
```

内置委托 Action 和 Func 就是使用泛型定义的。

转到 Action 定义可以发现：

``` c#
namespace System {
    public delegate void Action();
}
// 带参数的 Action
namespace System {
    public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);
}
```

转到 Func 定义：

``` c#
namespace System {
    public delegate TResult Func<out TResult>();
}
```

所以，可以将委托定义成：

TestingGenerics.cs

```c#
public class TestingGenerics : MonoBehaviour {
    private delegate void MyActionDelegate<T1, T2>(T1 t1, T2 t2);
    private delegate TResult MyFuncDelegate<T1, TResult>(T1 t1);
}
```

具有泛型的类

TestingGenerics.cs

``` c#
public class TestingGenerics : MonoBehaviour {
    MyClass<int> myClass = new myClass<int>();
}

public class MyClass<T> {
    public T value;
    
    // 由于在定义类时定义了 T，所以此处不需要定义 T
    private T[] CreateArray(T firstElement, T secondElement) {
        return new string[] { firstElement, secondElement };
    }
}
```

具有泛型的接口

TestingGenerics.cs

``` c#
public class TestingGenerics : MonoBehaviour {
    MyClass<EnemyMinion> myClass = new myClass<EnemyMinion>(new EnemyMinion());
    MyClass<EnemyArcher> myClassArcher = new myClass<EnemyArcher>(new EnemyArcher());
}

// 约束 T 必须是实现 IEnemy 接口的类
public class MyClass<T> where T : class, IEnemy<int>, new() {
    public T value;
    
    public MyClass(T value) {
        value.Damage(0);
    }
    
    // 由于在定义类时定义了 T，所以此处不需要定义 T
    private T[] CreateArray(T firstElement, T secondElement) {
        return new string[] { firstElement, secondElement };
    }
}

public interface IEnemy<T> {
    void Damage(T t);
}

public class EnemyMinion ：IEnemy<int> {
    public void Damage(int i) {
        Debug.Log("EnemyMinion.Damage()");
    }
}

public class EnemyArcher : IEnemy<int> {
    public void Damage(int i) {
        Debug.Log("EnemyArcher.Damage()");
    }
}
```

为泛型添加约束

TestingGenerics.cs

``` c#
public class TestingGenerics : MonoBehaviour {
    MyClass<EnemyMinion> myClass = new myClass<EnemyMinion>(new EnemyMinion());
    MyClass<EnemyArcher> myClassArcher = new myClass<EnemyArcher>(new EnemyArcher());
}

// 约束 T 必须是实现 IEnemy 接口的类
public class MyClass<T> where T : IEnemy {
    public T value;
    
    public MyClass(T value) {
        value.Damage();
    }
    
    // 由于在定义类时定义了 T，所以此处不需要定义 T
    private T[] CreateArray(T firstElement, T secondElement) {
        return new string[] { firstElement, secondElement };
    }
}

public interface IEnemy {
    void Damage();
}

public class EnemyMinion ：IEnemy {
    public void Damage() {
        Debug.Log("EnemyMinion.Damage()");
    }
}

public class EnemyArcher : IEnemy {
    public void Damage() {
        Debug.Log("EnemyArcher.Damage()");
    }
}
```

其他约束：

参考网址：https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters

搜索关键字：约束

C# 编程指南 -> 泛型 -> 类型参数的约束

| 约束                     | 描述                                                         |
| :----------------------- | :----------------------------------------------------------- |
| `where T : struct`       | 类型参数必须是不可为 null 的[值类型](https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/value-types)。 有关可为 null 的值类型的信息，请参阅[可为 null 的值类型](https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/nullable-value-types)。 由于所有值类型都具有可访问的无参数构造函数，因此 `struct` 约束表示 `new()` 约束，并且不能与 `new()` 约束结合使用。 `struct` 约束也不能与 `unmanaged` 约束结合使用。 |
| `where T : class`        | 类型参数必须是引用类型。 此约束还应用于任何类、接口、委托或数组类型。 在可为 null 的上下文中，`T` 必须是不可为 null 的引用类型。 |
| `where T : class?`       | 类型参数必须是可为 null 或不可为 null 的引用类型。 此约束还应用于任何类、接口、委托或数组类型。 |
| `where T : notnull`      | 类型参数必须是不可为 null 的类型。 参数可以是不可为 null 的引用类型，也可以是不可为 null 的值类型。 |
| `where T : default`      | 重写方法或提供显式接口实现时，如果需要指定不受约束的类型参数，此约束可解决歧义。 `default` 约束表示基方法，但不包含 `class` 或 `struct` 约束。 有关详细信息，请参阅[`default`约束](https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/proposals/csharp-9.0/unconstrained-type-parameter-annotations#default-constraint)规范建议。 |
| `where T : unmanaged`    | 类型参数必须是不可为 null 的[非托管类型](https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/unmanaged-types)。 `unmanaged` 约束表示 `struct` 约束，且不能与 `struct` 约束或 `new()` 约束结合使用。 |
| `where T : new()`        | 类型参数必须具有公共无参数构造函数。 与其他约束一起使用时，`new()` 约束必须最后指定。 `new()` 约束不能与 `struct` 和 `unmanaged` 约束结合使用。 |
| `where T :`*<基类名>*    | 类型参数必须是指定的基类或派生自指定的基类。 在可为 null 的上下文中，`T` 必须是从指定基类派生的不可为 null 的引用类型。 |
| `where T :`*<基类名>?*   | 类型参数必须是指定的基类或派生自指定的基类。 在可为 null 的上下文中，`T` 可以是从指定基类派生的可为 null 或不可为 null 的类型。 |
| `where T :`*<接口名称>*  | 类型参数必须是指定的接口或实现指定的接口。 可指定多个接口约束。 约束接口也可以是泛型。 在的可为 null 的上下文中，`T` 必须是实现指定接口的不可为 null 的类型。 |
| `where T :`*<接口名称>?* | 类型参数必须是指定的接口或实现指定的接口。 可指定多个接口约束。 约束接口也可以是泛型。 在可为 null 的上下文中，`T` 可以是可为 null 的引用类型、不可为 null 的引用类型或值类型。 `T` 不能是可为 null 的值类型。 |
| `where T : U`            | 为 `T` 提供的类型参数必须是为 `U` 提供的参数或派生自为 `U` 提供的参数。 在可为 null 的上下文中，如果 `U` 是不可为 null 的引用类型，`T` 必须是不可为 null 的引用类型。 如果 `U` 是可为 null 的引用类型，则 `T` 可以是可为 null 的引用类型，也可以是不可为 null 的引用类型。 |

约束可以组合使用，以 `,` 分割：

``` c#
// T 必须是一个类，且实现了 IEnemy 接口，拥有公共无参数构造函数
public class MyClass<T> where T : class, IEnemy, new() {
}
```

## 宏

### 自定义宏

如果有需求在条件 A 情况下执行代码段 m，在条件 B 情况下执行代码段 n，那么可以定义一个宏来代表条件，在代码中判断条件是否满足。常用于有多个渠道且需求不同时使用。

设置使用的宏 Project Settings -> Player -> Other Settings -> Configuration -> Scriptiong Define Symbols 中输入定义的宏，如果有多个宏，需要用分号隔开。

定义宏：

```c#
public class Test : MonoBehaviour {
    string str = "";  
    void Start()
    {
    #if CONDITION_1
        str = "Hello";
    #elif CONDITION_2
        str = "Hello world";
    #endif
        Debug.Log(str);
    }
}
```

``` c#
// 宏文本文档路径
private readonly string DEFINES_TXT_PATH = Application.dataPath + "/defines.txt";

// 方法
public TemporaryRegexReplaceInDefinesTxt(string pattern, string replacement, bool rebuild = true) {
    // System.IO.File.ReadAllText 打开一个文本文件，将文件中的所有文本读取到一个字符串中，然后关闭此文件。
	m_old_defines_txt = System.IO.File.ReadAllText(DEFINES_TXT_PATH);
	var defines_txt = m_old_defines_txt;
    // System.Text.RegularExpressions.Regex.Replace 在指定的输入字符串内，使用指定的替换字符串替换与指定正则表达式匹配的所有字符串。
    // input 要搜索匹配项的字符串。
    // pattern 要匹配的正则表达式模式。
    // replacement 替换字符串。
	defines_txt = System.Text.RegularExpressions.Regex.Replace(defines_txt, pattern, replacement);
    // 创建一个新文件，在其中写入指定的字符串，然后关闭文件。 如果目标文件已存在，则覆盖该文件。
	System.IO.File.WriteAllText(DEFINES_TXT_PATH, defines_txt, System.Text.Encoding.Unicode);
	if (rebuild) {
        // EditorApplication.ExecuteMenuItem 调用指定路径的菜单项。
		EditorApplication.ExecuteMenuItem("DeveloperTools/BuildTools/RebuildScripts/Development");
	}
}

public void Dispose() {
	System.IO.File.WriteAllText(DEFINES_TXT_PATH, m_old_defines_txt, System.Text.Encoding.Unicode);
}
```

```c#
private class TemporaryAddScriptingDefineSymbols : System.IDisposable 
{
	public TemporaryAddScriptingDefineSymbols(BuildTargetGroup target_group, string define_symbol) 
	{
		m_target_group = target_group;
        // 为给定构建目标组获取用户指定的脚本编译符号。每个平台可以都以一个目标组，例如：BuildTargetGroup.Android
		m_old_scripting_define_symbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(m_target_group);
		PlayerSettings.SetScriptingDefineSymbolsForGroup(m_target_group, m_old_scripting_define_symbols + " " + define_symbol);
	}
    
	public void Dispose() 
	{
		PlayerSettings.SetScriptingDefineSymbolsForGroup(m_target_group, m_old_scripting_define_symbols);
	}
    
	private BuildTargetGroup m_target_group;
	private string m_old_scripting_define_symbols;
}
```

## Reflection（反射）

反射是可以在不知道程序集中定义的类型的信息（如[类](https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/common-type-system#classes)、[接口](https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/common-type-system#interfaces)和值类型（即[结构](https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/common-type-system#structures)和[枚举](https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/common-type-system#enumerations)））的情况下获取它们并使用它们。 可以使用反射在运行时创建、调用和访问类型实例。

在 Unity 官方文档中写明了 C# 反射的开销，不建议在游戏运行时使用它：

Mono 和 IL2CPP 在内部缓存所有 C# 反射 （System.Reflection） 对象，并且根据设计，Unity 不会对它们进行垃圾回收。此行为的结果是垃圾回收器在应用程序的生存期内持续扫描缓存的 C# 反射对象，这会导致不必要且可能显著的垃圾回收器开销。

要最大程度减少垃圾回收器开销，请在应用程序中避免使用诸如 Assembly.GetTypes 和 Type.GetMethods() 等方法，这些方法会在运行时创建许多 C# 反射对象。 而是应该在编辑器中扫描程序集以获取所需数据，并进行序列化和/或代码生成以在运行时使用。

<font color = skyblue>反射的效率远小于直接写代码，所以一般用在拓展编辑器上而不是用在游戏中。</font>

### 原理

每一个类的中的成员变量、方法是不同的，反射的功能却是要能够适应任何一种类，所以有了 TypeInfo 这个类，它能够描述任何一种类。对于成员变量它们的声明特征是作用域、类型、变量名以及地址偏移等，所以有了 FieldInfo 这个类用于存储这些信息。同理成员方法使用 MethodInfo 存储关于成员方法相关的信息。那么一个类中不可能只有一个成员变量或方法，所以在 TypeInfo 中使用 IEnumerable 存储多个成员变量或方法。IEnumerable 是公开枚举数，它支持在指定类型的集合上进行简单的迭代。

上面提到的信息是指类尚未实例化的信息，也就是定义类时所具有的信息。比如场景中有许多树，对于树有一个 Tree 的类型，但是每一棵树都有自己的一个 Tree 脚本，每棵树上的 Tree 脚本就是 Tree 的实例化。每棵树上的 Tree 脚本中的值是互不影响的。上面的信息存储的不是每棵上 Tree 脚本中保存的值，而是 Tree 这个类型声明本身的内容。所以，在使用 `FieldInfo.GetValue()` 这种方法时需要传入实例化的对象。即便 FieldInfo 中存储的是 Tree 类中所有的字段，但是通过 `GetValue` 获取的值是对于实例化出来的对象而言的。一个场景有十棵树，那么就有十个树的成长进度

TypeInfo 类结构如下所示：

![](图片\TypeInfo 结构1.png)

Main.cs

```c#
using System;
using System.Reflection;
using UnityEngine;

public class Main : MonoBehaviour {
    void Start() {
        Type t = Type.GetType("Student");
        var student1 = Activator.CreateInstance(t);

        FieldInfo[] fields = t.GetFields();
        FieldInfo fieldInfo = t.GetField("age");
        fieldInfo.SetValue(student1, 20);

        Debug.Log((student1 as Student).age);
    }
}
```

Student.cs

```c#
using UnityEngine;

public class Student {
    public string name;
    public int age;
    public Id id;

    public void ShowInfo() {
        Debug.Log($"{name}\t{age}\t{id}");
    }
}

public class Id {
    public int id;
}
```

![](D:\Git 仓库\笔记\StudyNotes\Notes-Unity\C#\图片\TypeInfo 结构2.png)

TypeInfo 表示类型定义本身，而 Type 表示对类型定义的引用。TypeInfo 获取对象会强制加载包含该类型的程序集。 相比之下，可以操作 Type 对象，而无需运行时加载它们引用的程序集。

Type 与 TypeInfo 的区别：https://devblogs.microsoft.com/dotnet/evolving-the-reflection-api/

### 使用

由于反射不常用且内容过多，直接查看官方文档即可。

官方文档：https://learn.microsoft.com/zh-cn/dotnet/framework/reflection-and-codedom/reflection

### 应用场景

需要对多种类型进行某种操作，这些类型用不同点但也有相同点，而需要操作的对象是它们的相同点，此时可以使用反射。

例 1：游戏中有多个英雄，每个英雄都有一个类，他们有相同的字段也有不同的字段，想要为他们相同的字段进行批量赋值，如在 Unity 中可以 Copy Component，但是由于他们的类型不同，不能对他们相同字段使用 Copy Component，此时就可以写一个类似 Copy Component 的方法，使用反射获取一个类型的所有字段，再用反射获取另一个类型的所有字段并进行一一比较，相同字段进行赋值。

例 2：用于存档方法，比如想要保存英雄的数据，随着开发的推进，英雄拥有的字段可能不断增多，而在写存档方法时不可能预知未来会出现的字段，此时就可以使用反射遍历类的所有字段进行保存。

例 3：在为某些程序写插件时，可能无法得知程序内部具体由什么类、类中又有什么字段、方法等，此时可以先通过反射对程序代码有一个初步的了解。

例 4：Unity 扩展的组件在 Inspector 窗口中可以动态编辑、显示就是使用了反射。当脚本被挂载到场景的某个物体上时，Unity 会根据脚本名称在项目的程序集中查找对应的类型，并使用反射的方法判断此类型是否继承于 Monobehaviour。如果是，则通过反射方法创建这个类型的实例并加入到该场景物体的组件列表中。脚本中的变量在 Inspector 窗口中显示也是同样的道理，通过反射扫描类的所有成员，得到可编辑的成员，将他们显示在窗口中，当值发生改变时，通过反射将值设置到组件实例上。

例 1：

Hero.cs

```C#
using System.Reflection;
using UnityEngine;

public class Hero : MonoBehaviour {
    public string name;
    public int hp;
    public float moveSpeed;

    private static FieldInfo[] copyFieldInfos;
    private static System.Object copyObject;

    [ContextMenu("Copy By Reflection")]
    public void CopyByReflection() {
        copyObject = this;
        //Object.GetType() 当前实例的准确运行时类型。如果时 HouYi 组件调用，它就会返回 HouYi 类型
        //Debug.Log($"this type is: {this.GetType()}");
        copyFieldInfos = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
    }

    [ContextMenu("Paste By Reflection")]
    public void PasteByReflection() {
        //先判断是否使用了 Copye By Reflection 功能，如果没有使用过会报错，所以需要先判断一下
        if (copyFieldInfos == null) {
            Debug.LogWarning("请先 Copy！！！");
            return;
        }

        foreach (FieldInfo field in copyFieldInfos) {
            //获取粘贴的对象与复制对象字段同名的字段
            var pasteFieldInfo = GetType().GetField(field.Name);
            if (pasteFieldInfo != null) {
                //获取复制对象的字段的值
                var value = field.GetValue(copyObject);
                pasteFieldInfo.SetValue(this, value);
            }
        }
    }
}
```

HouYi.cs

```c#
public class HouYi : Hero {
    public float coinCount;
}
```

BaiLi.cs

```c#
using System.Collections.Generic;

public class BaiLi : Hero {
    public List<Skill> skills;
    public float coinCount;
}

public class Skill {
    public float damage;
    public float cd;
}
```

## Attribute（特性）

使用特性，可以声明的方式将信息与代码相关联。特性还可以提供能够应用于各种目标的可重用元素。它可以应用于程序集、类、构造函数、委托、枚举、事件、字段、接口、方法、可移植可执行文件模块、参数、属性、返回值、结构或其他特性。例如 ObsoleteAttribute，它声明该元素已过时，然后由 C# 编译器查找此属性，并执行一些操作作为响应。

特性提供的信息也称为元数据。应用程序可以在运行时检查元数据以控制程序处理数据的方式，或者在运行时由外部工具在运行时检查元数据，以控制应用程序本身的处理或维护方式。例如，.NET 预定义和使用特性类型来控制运行时行为，而某些编程语言使用特性类型来表示 .NET 通用类型系统不直接支持的语言功能。

特性需要继承 Attribute 类，将特性应用于类需使用方括号。类名为 ObsoleteAttribute，只需在代码中使用 [Obsolete]，也就是可以省略 Attribute 后缀，当然写全也是可以的。特性可以应用于任何目标元素；多个特性可以应用于同一目标元素；特性可由派生自目标元素的元素继承。使用 AttributeTargets 类指定要应用特性的目标元素。只能向特性构造函数传递以下简单类型/文本类型参数：`bool, int, double, string, Type, enums, etc` 和这些类型的数组。不能使用表达式或变量。可以使用任何位置参数或已命名参数。在创建特性类型时，C# 编译器不会阻止创建错误的参数，但是将错误的构造函数与特性结合，这会导致报错：`Attribute constructor parameter 'myClass' has type 'Foo', which is not a valid attribute parameter type`。

```c#
//不会报错
public class GotchaAttribute : Attribute
{
    public GotchaAttribute(Foo myClass, string str)
    {
    }
}
//会报错
[Gotcha(new Foo(), "test")] // does not compile
public class AttributeFail
{
}
```

创建特性类时，C# 默认允许对所有可能的特性目标使用此特性。如果要将特性限制为只能用于特定目标，可以对特性类使用 `AttributeUsageAttribute` 来实现。没错，就是将特性应用于特性！如果尝试将特性应用到错误的对象时，会得到类似 `Attribute 'MyAttributeForClassAndStructOnly' is not valid on this declaration type. It is only valid on 'class, struct' declarations` 的报错。

```
//限制特性作用对象
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class MyAttributeForClassAndStructOnly : Attribute
{
}
```

特性通常与反射一起使用。

官方文档：

1. https://learn.microsoft.com/zh-cn/dotnet/csharp/advanced-topics/reflection-and-attributes/attribute-tutorial
2. https://learn.microsoft.com/zh-cn/dotnet/csharp/advanced-topics/reflection-and-attributes/

<font color = orange>注意：</font>.NET 库中 ThreadStatic 特性将其添加至 Unity 脚本会导致崩溃。Unity 也提供了大量特性。

对于 UnityEngine 特性，可参阅脚本 API -> UnityEngine -> Attributes

对于 UnityEditor 特性，可参阅脚本 API -> UnityEditor -> Attributes

### 应用场景

检查资源编号与路径映射是否由同名存在。可以定义一个特性，存储资源编号和资源路径，然后通过反射获取程序集中代码拥有该特性的类，对特性中的字段值进行比对，如果存在相同的进行提示等操作。
