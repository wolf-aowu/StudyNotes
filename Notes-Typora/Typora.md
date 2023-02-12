### 数学符号

#### LaTex 语法

##### 换行

``` latex
% \\ 与 \newline 效果相同，都为换行
\\
\newline
```

##### 加减乘除

``` latex
+
-
*
\div
% 点乘
\cdot
% 叉乘
\times
```

输出：
$$
+
\\
-
\\
*
\\
\div
\\
% 点乘
\cdot
\\
% 叉乘
\times
$$

##### 分式

``` latex
\frac{a}{b}
```

输出：
$$
\frac{a}{b}
$$

##### 根号

``` latex
\sqrt{a}
```

输出：
$$
\sqrt{a}
$$

##### 上下标

``` latex
% 上标
x^2
% 下标
x_1
```

输出：
$$
% 上标
x^2
\\
% 下标
x_1
$$

##### 无穷

``` latex
% 正无穷
\infty
% 负无穷
-\infty
```

输出：
$$
% 正无穷
\infty
\\
% 负无穷
-\infty
$$

##### 大于等于、小于等于、不等于

``` latex
% 小于等于
\leq
% 大于等于
\geq
% 不等于
\neq
```

输出：
$$
% 小于等于
a \leq b
\\
% 大于等于
b \geq a
\\
% 不等于
b \neq a
$$

##### 集合相关

``` latex
% 包含于
A \subseteq B
% 真子集
A \subsetneqq B
A \subset B
% 包含
A \supset B
A \supseteq B
A \supsetneqq B
% 属于
\in
% 不属于
\notin
% 交集
A\cap B
% 并集
A\cup B
% 空集
\varnothing
% 描述法中的 |
\mid
% 补集
\complement_UA
```

$$
% 包含于
A \subseteq B
\\
% 真子集
A \subsetneqq B
\\
A \subset B
\\
% 包含
A \supset B
\\
A \supseteq B
\\
A \supsetneqq B
\\
% 属于
\in
\\
% 不属于
\notin
\\
% 交集
A\cap B
\\
% 并集
A\cup B
\\
% 空集
\varnothing
\\
% 描述法中的 |
\mid
\\
% 补集
\complement_UA
$$

##### 任意存在

``` latex
% 任意
\forall
% 存在
\exists
```

输出：
$$
% 任意
\forall
\\
% 存在
\exists
$$

##### 希腊字母

| latex 代码    | 显示          |
| ------------- | ------------- |
| `\alpha`      | $\alpha$      |
| `\beta`       | $\beta$       |
| `\gamma`      | $\gamma$      |
| `\delta`      | $\delta$      |
| `\epsilon`    | $\epsilon$    |
| `\varepsilon` | $\varepsilon$ |
| `\eta`        | $\eta$        |
| `\theta`      | $\theta$      |
| `\kappa`      | $\kappa$      |
| `\iota`       | $\iota$       |
| `\zeta`       | $\zeta$       |
| `\lambda`     | $\lambda$     |
| `\mu`         | $\mu$         |
| `\phi`        | $\phi$        |
| `\pi`         | $\pi$         |
| `\rho`        | $\rho$        |
| `\xi`         | $\xi$         |
| `\nu`         | $\nu$         |
| `\upsilon`    | $\upsilon$    |
| `\varphi`     | $\varphi$     |
| `\chi`        | $\chi$        |
| `\psi`        | $\psi$        |
| `\omega`      | $\omega$      |

##### 省略号

``` latex
% 行省略号
\cdots
% 列省略号
\vdots
% 斜向省略号，左上至右下
\ddots
```

输出：
$$
% 行省略号
\cdots
\\
% 列省略号
\vdots
\\
% 斜向省略号，左上至右下
\ddots
$$

##### 空格

``` latex
% 紧贴
a\!b
% 小空格
a\,b
% 中空格
a\;b
% 大空格
a\ b
% 真空格
a\quad b
% 双真空格
a\qquad b
```


$$
% 紧贴
a\!b
\\
% 小空格
a\,b
\\
% 中空格
a\;b
\\
% 大空格
a\ b
\\
% 真空格
a\quad b
\\
% 双真空格
a\qquad b
$$

##### 函数

``` latex
\sin{\theta}
\cos{\theta}
\tan{\theta}
\cot{\theta}
```

输出：
$$
\sin{\theta}
\\
\cos{\theta}
\\
\tan{\theta}
\\
\cot{\theta}
$$

##### 矢量

``` latex
\vec{a}
```

输出：
$$
\vec{a}
$$

##### 累加累乘

``` latex
% 累加
\sum_{i=1}^{n}{a_i}
% 累乘
\prod_{i=1}^{n}{a_i}
```

输出：
$$
% 累加
\sum_{i=1}^{n}{a_i}
\\
% 累乘
\prod_{i=1}^{n}{a_i}
$$

##### 极限

```latex
\lim_{a\rightarrow+\infty}{a+b}
```

输出：
$$
\lim_{a\rightarrow+\infty}{a+b}
$$

##### 矩阵

使用 `\begin{matrix} ... \end{matrix}` 生成矩阵，元素使用 `&` 分开。使用 `\tag{序号}` 设置右侧序号。

###### 普通矩阵

``` latex
\begin{matrix}
1 & 2 & 3 \\
4 & 5 & 6 \\
7 & 8 & 9
\end{matrix} \tag{1}
```

输出：
$$
\begin{matrix}
1 & 2 & 3 \\
4 & 5 & 6 \\
7 & 8 & 9
\end{matrix} \tag{1}
$$

###### 带左右大括号的矩阵

方法一：

```latex
\left\{
\begin{matrix}
1 & 2 & 3 \\
4 & 5 & 6 \\
7 & 8 & 9
\end{matrix}
\right\} \tag{2}
```

输出：
$$
\left\{
\begin{matrix}
1 & 2 & 3 \\
4 & 5 & 6 \\
7 & 8 & 9
\end{matrix}
\right\} \tag{2}
$$
方法二：

``` latex
\begin{Bmatrix}
1 & 2 & 3 \\
4 & 5 & 6 \\
7 & 8 & 9
\end{Bmatrix} \tag{3}
```

输出：
$$
\begin{Bmatrix}
1 & 2 & 3 \\
4 & 5 & 6 \\
7 & 8 & 9
\end{Bmatrix} \tag{3}
$$

###### 带左右中括号的矩阵

方法一：

``` latex
\left[
\begin{matrix}
1 & 2 & 3 \\
4 & 5 & 6 \\
7 & 8 & 9
\end{matrix}
\right] \tag{4}
```

输出：
$$
\left[
\begin{matrix}
1 & 2 & 3 \\
4 & 5 & 6 \\
7 & 8 & 9
\end{matrix}
\right] \tag{4}
$$
方法二：

``` latex
\begin{bmatrix}
1 & 2 & 3 \\
4 & 5 & 6 \\
7 & 8 & 9
\end{bmatrix} \tag{5}
```

输出：
$$
\begin{bmatrix}
1 & 2 & 3 \\
4 & 5 & 6 \\
7 & 8 & 9
\end{bmatrix} \tag{5}
$$

###### 带左右小括号的矩阵

``` latex
\left(
\begin{matrix}
1 & 2 & 3 \\
4 & 5 & 6 \\
7 & 8 & 9
\end{matrix}
\right) \tag{6}
```

输出：
$$
\left(
\begin{matrix}
1 & 2 & 3 \\
4 & 5 & 6 \\
7 & 8 & 9
\end{matrix}
\right) \tag{6}
$$

##### 行列式

``` latex
\begin{vmatrix}
1 & 2 & 3 \\
4 & 5 & 6 \\
7 & 8 & 9
\end{vmatrix}
```

输出：
$$
\begin{vmatrix}
1 & 2 & 3 \\
4 & 5 & 6 \\
7 & 8 & 9
\end{vmatrix}
$$

##### 真值表

``` latex
\begin{array}{cc|c}
A & B & F \\
\hline 0 & 0 & 0 \\
0 & 1 & 1 \\
1 & 0 & 1 \\
1 & 1 & 1 \\
\end{array}
```

输出：
$$
\begin{array}{cc|c}
A & B & F \\
\hline 0 & 0 & 0 \\
0 & 1 & 1 \\
1 & 0 & 1 \\
1 & 1 & 1 \\
\end{array}
$$

##### 多行等式对齐

``` latex
\begin{aligned}
a &= b + c \\
&= d + e + f
\end{aligned}
```

输出：
$$
\begin{aligned}
a &= b + c \\
&= d + e + f
\end{aligned}
$$

##### 方程组

``` latex
\begin{cases}
3x + 5y + z = 0 \\
7x - 2y + 4z = 0 \\
-6x + 3y + 2z = 0
\end{cases}
```

输出：
$$
\begin{cases}
3x + 5y + z = 0 \\
7x - 2y + 4z = 0 \\
-6x + 3y + 2z = 0
\end{cases}
$$

##### 条件表达式

``` latex
f(n) = 
\begin{cases}
n/2, & \text{if} n \text{is even}
3n+1, & \text{if} n \text{is odd}
\end{cases}
```

输出：
$$
f(n) = 
\begin{cases}
n/2, & \text{if } n \text{ is even} \\
3n+1, & \text{if } n \text{ is odd}
\end{cases}
$$

##### 箭头

###### 上下左右

``` latex
\uparrow
\downarrow
\leftarrow
\rightarrow
\Uparrow
\Downarrow
\Leftarrow
\Rightarrow
```

$$
\uparrow
\\
\downarrow
\\
\leftarrow
\\
\rightarrow
\\
\Uparrow
\\
\Downarrow
\\
\Leftarrow
\\
\Rightarrow
$$

###### 双向

``` latex
\updownarrow
\leftrightarrow
\Updownarrow
\Leftrightarrow
```

$$
\updownarrow
\\
\leftrightarrow
\\
\Updownarrow
\\
\Leftrightarrow
$$

###### 长箭头

``` latex
\longleftarrow
\longrightarrow
\Longleftarrow
\Longrightarrow
\longleftrightarrow
\Longleftrightarrow
```

$$
\longleftarrow
\\
\longrightarrow
\\
\Longleftarrow
\\
\Longrightarrow
\\
\longleftrightarrow
\\
\Longleftrightarrow
$$

###### 半箭头

``` latex
\upharpoonleft
\downharpoonleft
\leftharpoonup
\rightharpoonup
\upharpoonright
\downharpoonright
\leftharpoondown
\rightharpoondown
\rightleftharpoons
```

$$
\upharpoonleft
\\
\downharpoonleft
\\
\leftharpoonup
\\
\rightharpoonup
\\
\upharpoonright
\\
\downharpoonright
\\
\leftharpoondown
\\
\rightharpoondown
\\
\rightleftharpoons
$$

###### 斜箭头

``` latex
\nearrow
\searrow
\swarrow
\nwarrow
```

$$
\nearrow
\\
\searrow
\\
\swarrow
\\
\nwarrow
$$

###### 其他

```latex
\mapsto
\longmapsto
\hookleftarrow
\hookrightarrow
\leadsto
\nleftarrow
\nrightarrow
\nLeftarrow
\nRightarrow
\nleftrightarrow
\nLeftrightarrow
\dashrightarrow
\dashleftarrow
\leftleftarrows
\rightrightarrows
\leftrightarrows
\Lleftarrow
\twoheadleftarrow
\twoheadrightarrow
\leftarrowtail
\rightarrowtail
\looparrowleft
\looparrowright
\curvearrowleft
\curvearrowright
\circlearrowleft
\circlearrowright
\Lsh
\Rsh
\upuparrows
\downdownarrows
\multimap
\leftrightsquigarrow
\rightsquigarrow
```

$$
\mapsto
\longmapsto
\\
\hookleftarrow
\hookrightarrow
\\
\leadsto
\leftrightsquigarrow
\rightsquigarrow
\\
\nleftarrow
\nrightarrow
\nLeftarrow
\nRightarrow
\nleftrightarrow
\nLeftrightarrow
\\
\dashrightarrow
\dashleftarrow
\\
\leftleftarrows
\rightrightarrows
\leftrightarrows
\\
\Lleftarrow
\\
\twoheadleftarrow
\twoheadrightarrow
\\
\leftarrowtail
\rightarrowtail
\\
\looparrowleft
\looparrowright
\\
\curvearrowleft
\curvearrowright
\\
\circlearrowleft
\circlearrowright
\\
\Lsh
\Rsh
\\
\upuparrows
\downdownarrows
\\
\multimap
$$

### 图的画法

有 3 种语法可以画图，分别是：mermaid、flow、sequence

但是任然不推荐使用代码画图，mermaid 太丑，flow 画出来的线有问题，所以还是建议使用工具画图后截图。

#### mermaid 语法

官网：https://mermaid-js.github.io/mermaid/#/

##### 流程图

声明：`graph LR` 代表横向，`graph TD` 代表竖向

方形：`键名[方形的内容]`

圆角：`键名(圆角的内容)`

条件：`键名{条件的内容}`

带箭头的实线：`-->`

线上的说名内容：`|线上的说明内容|`

###### 例子

横向的

```mermaid
graph LR
    A[方形] --> B(圆角)
    B --> |线上说明内容|C{条件a}
    C --> |a==1| D[结果1]
    C --> |a==2| E[结果2]
    A --> F[横向流程图]
    G[横向流程图]
```

竖向的

```mermaid
graph TD
    A[方形] --> B(圆角)
    B --> C{条件a}
    C --> |a=1| D[结果1]
    C --> |a=2| E[结果2]
    A --> F[竖向流程图]
```

##### 时序图

申明： `sequenceDiagram`

参与者：`participant 键名`

循环：`loop` 开始，`end` 结束，中间写循环体

说明标签：`Note right of 键名: 内容` 标签显示在右侧，`Note right of 键名: 内容` 标签显示在左侧

换行：`<br/>`

实线：`->`，例子：`键名->键名: 内容`

带箭头的实线：`->>`

带箭头的虚线：`-->>`

虚线：-->

注释：%%

###### 例子

```mermaid
sequenceDiagram
    participant Alice
    participant Bob
    Alice->>John: Hello John, how are you?
    loop Healthcheck
        John->>John: Fight against hypochondria
    end
    Note right of John: Rational thoughts <br/>prevail!
    John-->>Alice: Great!
    John->>Bob: How about you?
    Bob-->>John: Jolly good!
```

##### 甘特图

申明：`gantt`

日期格式：`dateFormat	YYYY-MM-DD`

台头：`title 台头内容`

其他见例子

###### 例子

```mermaid
gantt
dateFormat  YYYY-MM-DD
title Adding GANTT diagram to mermaid
excludes weekdays 2014-01-10

section A section
Completed task            :done,    des1, 2014-01-06,2014-01-08
Active task               :active,  des2, 2014-01-09, 3d
Future task               :         des3, after des2, 5d
Future task2               :         des4, after des3, 5d
```

##### 类图

声明：`classDiagram`

其他见例子

###### 例子

```mermaid
classDiagram
Class01 <|-- AveryLongClass : Cool
Class03 *-- Class04
Class05 o-- Class06
Class07 .. Class08
Class09 --> C2 : Where am i?
Class09 --* C3
Class09 --|> Class07
Class07 : equals()
Class07 : Object[] elementData
Class01 : size()
Class01 : int chimp
Class01 : int gorilla
Class08 <--> C2: Cool label
```

##### 实体关系图

声明：`erDiagram`

其他见例子

###### 例子

```mermaid
erDiagram
    CUSTOMER ||--o{ ORDER : places
    ORDER ||--|{ LINE-ITEM : contains
    CUSTOMER }|..|{ DELIVERY-ADDRESS : uses
```

##### 用户旅程图

申明：journey

其他见例子

##### 例子

```mermaid
journey
    title My working day
    section Go to work
      Make tea: 5: Me
      Go upstairs: 3: Me
      Do work: 1: Me, Cat
    section Go home
      Go downstairs: 5: Me
      Sit down: 5: Me
```

#### flow 语法

官网：http://flowchart.js.org/

##### 流程图

开始：`键名=>start: 内容`

结束：`键名=>end: 内容`

处理过程，方形：`键名=>operation: 内容`

预设处理，双边矩形：`键名=>subroutine: 内容`

判断，菱形：`键名=>condition: 内容`

数据输入输出，平行四边形：`键名=>inputoutput: 内容`

超链接：`:>链接地址` ，地址末尾加 `[blank]` 是新建窗口打开

其他见例子

###### 例子

例一

```flow
st=>start: Improve your
l10n process!
e=>end: Continue to have fun!:>https://youtu.be/YQryHo1iHb8[blank]
op1=>operation: Go to locize.com:>https://locize.com[blank]
sub1=>subroutine: Read the awesomeness
cond(align-next=no)=>condition: Interested to
getting started?
io=>inputoutput: Register:>https://www.locize.app/register[blank]
sub2=>subroutine: Read about improving
your localization workflow
or another source:>https://medium.com/@adrai/8-signs-you-should-improve-your-localization-process-3dc075d53998[blank]
op2=>operation: Login:>https://www.locize.app/login[blank]
cond2=>condition: valid password?
cond3=>condition: reset password?
op3=>operation: send email
sub3=>subroutine: Create a demo project
sub4=>subroutine: Start your real project
io2=>inputoutput: Subscribe

st->op1->sub1->cond
cond(yes)->io->op2->cond2
cond2(no)->cond3
cond3(no,bottom)->op2
cond3(yes)->op3
op3(right)->op2
cond2(yes)->sub3
sub3->sub4->io2->e
cond(no)->sub2(right)->op1

st@>op1({"stroke":"Red"})@>sub1({"stroke":"Red"})@>cond({"stroke":"Red"})@>io({"stroke":"Red"})@>op2({"stroke":"Red"})@>cond2({"stroke":"Red"})@>sub3({"stroke":"Red"})@>sub4({"stroke":"Red"})@>io2({"stroke":"Red"})@>e({"stroke":"Red","stroke-width":6,"arrow-end":"classic-wide-long"})
```

例二

```flow
st=>start: Start|past:>http://www.google.com[blank]
e=>end: End|future:>http://www.google.com
op1=>operation: My Operation|past
op2=>operation: Stuff|current
sub1=>subroutine: My Subroutine|invalid
cond=>condition: Yes
or No?|approved:>http://www.google.com
c2=>condition: Good idea|rejected
io=>inputoutput: catch something...|future

st->op1(right)->cond
cond(yes, right)->c2
cond(no)->sub1(left)->op1
c2(yes)->io->e
c2(no)->op2->e
```

#### sequence 语法

见例子

###### 例子

```sequence
李雷 -> 韩梅梅: Hello 梅梅, How are you?
Note right of 韩梅梅: 韩梅梅心想
韩梅梅 --> 李雷: I'm fine, thanks, and you?
```





