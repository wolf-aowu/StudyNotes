## 命名准则

<font color=orange>Spend time deciding on a proper name!</font>

<font color=orange>为起一个恰当的名字多花些时间！</font>

<font color=orange>Don't be afraid to rename things</font>

<font color=orange>不用害怕重命名</font>

<font color=orange>Don't use single letter names</font>

<font color=orange>不要使用单一的字母来作为名字</font>

<font color=orange>Don't use acronyms or abbreviations</font>

<font color=orange>不要使用缩写或缩写词</font>

## 命名法

### 匈牙利命名法（Hungarian）

基本原则：变量名=属性+类型+对象描述。

如：int g_int_age;

<font color=orange>太过复杂，不采用。</font>

属性部分：

| 标记 | 含义     |
| ---- | -------- |
| g_   | 全局变量 |
| c_   | 常量     |
| m_   | 成员变量 |
| s_   | 静态变量 |

所以，Unity 官方代码中会有以 m_ 开头的变量名。🤣原来是代表成员变量的意思。

类型部分：

下面只是举个例子。

| 标记 | 含义 |
| ---- | ---- |
| a    | 数组 |
| p    | 指针 |
| b    | 布尔 |

### 下划线命名法（SnakeCase）

基本原则：单词与单词之间用下划线隔开。

如：int my_age;

### 驼峰命名法（Camel）

第一个单词以小写字母开始，后续单词首字母都采用大写字母。

如：int myAge;

### 帕斯卡命名法（Pascal）

基本原则：每个单词首字母大写。也叫大驼峰式命名法。

如：int MyAge;

### 全部大写法（UpperCase）

基本原则：所有字母都是大写。

如：int MY_AGE;

## 代码中命名法的应用

```c#
public class MyCodeStyle : MonoBehaviour {
	// Constants: UpperCase SnakeCase
	public const int CONSTANT_FIELD = 56;
	
	// Properties: PascalCase
	public static MyCodeStyle Instatce { get; private set; }
	// Events: PascalCase
	public event EventHandler OnSomethingHappened;
	
	// Fields: camelCase
	private float memberVariable;
	
	// Function Names: PascalCase
	private void Awake() {
		Instance = this;
		
		DoSomething(10f);
	}
	
	// Function Params: camelCase
	private void DoSomething(float time) {
		//Do something...
		memberVariable = time + Time.deltaTime;
		if (memberVariable > 0) {
			//Do someting else...
		}
	}
}
```

