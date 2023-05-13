## Events（事件）

事件分成两部分：发布者（publisher）和订阅者（subscribers）。发布者拥有一个事件，订阅者订阅事件。多个订阅者可以订阅同一个事件。当某些事发生时，发布者触发该事件并且所有订阅该事件的订阅者会受到通知该事件已被触发。关键是发布者不知道订阅该事件的订阅者有谁，可能有很多订阅者也可能没有。订阅者可能会处理该事件或者完全忽略该事件。发布者不知道且不关心谁在监听该事件，也不关心他们对该事件做了什么。因此，者允许你在发布者中编写代码，该代码与您还还想运行的任何其他代码分离，而这些代码不是必需的。

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

如果有需求在条件 A 情况下执行代码端 m，在条件 B 情况下执行代码端 n，那么可以定义一个宏来代表条件，在代码中判断条件是否满足。常用于有多个渠道且需求不同时使用。

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

## 反射
