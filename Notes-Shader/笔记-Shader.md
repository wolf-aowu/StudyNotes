# 数学基础知识

## 笛卡尔坐标系

笛卡尔坐标系就是生活中常说的坐标系。

### 二维笛卡尔坐标系

必须满足以下两个条件

- 有一个原点
- 有两条过原点互相垂直的矢量，x 轴和 y 轴

因此，笛卡尔坐标系并不是唯一的，如 OpenGL 进行屏幕映射时使用的笛卡尔坐标系 与 DirectX 进行屏幕映射时使用的笛卡尔坐标系 不同。

![笛卡尔二维坐标系](图片\Shader\笛卡尔二维坐标系.jpg)

### 三维笛卡尔坐标系

- 有一个原点

- 有三个坐标轴，这 3 个坐标轴被称为 <font color=skyblue>基矢量</font>。

  3 个坐标间互相垂直且长度为 1，被称为 <font color=skyblue>标准正交基</font>。

  3 个坐标间互相垂直，但长度不为 1，被称为 <font color=skyblue>正交基</font>。

<font color=skyblue>正交：</font>互相垂直。

三维笛卡尔坐标系可分为 左手坐标系 和 右手坐标系。

#### 左手坐标系 和 右手坐标系

左手坐标系

<img src="图片\Shader\左手坐标系.png" alt="左手坐标系" style="zoom: 67%;" />

<center>左手坐标系</center>

右手坐标系

<img src="图片\Shader\右手坐标系.png" alt="右手坐标系" style="zoom: 67%;" />

<center>右手坐标系</center>

#### 左手法则 和 右手法则

左手法则：定义左手坐标系旋转的正方向

右手法则：定义右手坐标系旋转的正方向

大拇指朝向旋转轴，其余手指就是旋转的正方向

<img src="图片\Shader\左手法则 和 右手法则.png" alt="左手法则 和 右手法则"  />

#### 左手坐标系 和 右手坐标系的区别

使用左手坐标系 和 右手坐标系 描述同一件事，描述是不同的。

![左手坐标系 和 右手坐标系的区别](图片\Shader\左手坐标系 和 右手坐标系的区别.png)

<center>左手坐标系&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp右手坐标系</center>

Unity 中，模型空间 和 世界空间 都使用 <font color = skyblue>左手坐标系</font>。观察空间 使用 <font color = skyblue>右手坐标系</font>。

观察空间：也叫摄像机空间。以摄像机为原点的坐标系，+z 轴指向相机后，+y 轴向上。

<font color = cyan>猜测：</font>观察空间为右手坐标系是因为摄像机就像镜子，z 轴原本向前为正方向，透过镜子后向后为正方向。 

<img src="图片\Shader\观察空间.png" alt="观差空间" style="zoom: 33%;" />

## 矢量

### 矢量加法的三角形定则

就是矢量加法。

### 矢量减法

某段向量 = 原点到某段向量的终点 - 原点到某段向量的起点

### 矢量的模

矢量的模 = 每个分量的平方相加后开根号

### 单位矢量 归一化

模为 1 的矢量就是单位矢量，也叫 被归一化的矢量。

单位矢量 = 矢量 / 矢量的模

<font color = skyblue>零矢量</font> 是不可被归一化的。零矢量：每个分量的值都为 0 。

通常在使用法线方向、光源方向时会对其归一化。

### 矢量的点积

矢量的点积又叫内积，$ \vec{a} \cdot \vec{b}$ （ $\cdot$ 是不能省略的），其最后结果是一个 <font color=skyblue>标量</font>。

$$
\vec{a} \cdot \vec{b} = (a_x,\ a_y,\ a_z) \cdot (b_x,\ b_y,\ b_z) = a_xb_x + a_yb_y + a_zb_z
\\
\vec{a} \cdot \vec{b} = \vec{b} \cdot \vec{a}
$$

例子：
$$
(1,2,3) \cdot (5,-1,7) = 1 * 5 + 2 * (-1) + 3 * 7 = 5 - 2 + 21 = 24
$$
#### 几何意义

点积的几何意义是投影。单位向量 $\vec{a} \cdot \vec{b}$ 的几何意义是：向量 $\vec{b}$ 在<font color = skyblue>单位向量 $\vec{a}$ </font>方向上的投影。

![矢量 b 在单位矢量 a 方向上的投影](图片\Shader\矢量 b 在单位矢量 a 方向上的投影.jpg)

<center>向量 b 在单位向量 a 方向上的投影</center>

点积结果可能是一个负数，点积结果的正负号与两个向量的方向有关，如果它们方向相反（夹角大于 90°），结果小于 0；如果它们互相垂直（夹角为 90°），结果为 0；如果它们方向相同（夹角小于 90°），结果大于 0。

![点积的符号](图片\Shader\点积的符号.jpg)

<center>点积的符号</center>

如果 $\vec{a}$ 不是单位向量，那么只需在 $\vec{a} \cdot \vec{b}$ 的基础上乘以 a 的长度即可。

#### 性质

性质一
$$
(k \vec{a}) \cdot \vec{b} = k (\vec{a} \cdot \vec{b})
$$
性质二
$$
\vec{a} \cdot (\vec{b} + \vec{c}) = \vec{a} \cdot \vec{b} + \vec{a} \cdot \vec{c}
\\
\vec{a} \cdot (\vec{b} - \vec{c}) = \vec{a} \cdot \vec{b} - \vec{a} \cdot \vec{c}
$$
性质三
$$
\vec{v} \cdot \vec{v} = v_xv_x + v_yv_y + v_zv_z = |v|^2
$$
这意味着<font color = skyblue>可以直接利用点积来求向量的模，当我们需要比较两个向量的长度大小时，可以直接使用点积来获得结果，这比 通过开方来计算向量长度 再比较 更省性能。</font>

#### 公式

公式一
$$
\vec{a} \cdot \vec{b} = |\vec{a}| \  |\vec{b}| \ cos\theta
\\
\theta = arcos(\vec{a}\ 的单位向量\  \cdot \  \vec{b}\ 的单位向量)
$$
<img src="图片\Shader\点积公式一.jpg" style="zoom:25%;" />

解释：

$\vec{a} \cdot \vec{b}$ 的几何意义是三角形邻边的模长，如果 $\theta > 90°$，即 $-邻边边长$ 。而  $cos\theta = 邻边 / 斜边$，又因为是单位向量，所以斜边的长为 1，则 $cos\theta = 邻边$ 且 $cos\theta$ 的正负也符合 。所以有 $\vec{a} \cdot \vec{b} = cos \theta$。延长 $\vec{a}$ 和 $\vec{b}$ 则有 $(|\vec{a}| \  \vec{a}) \cdot ( |\vec{b}| \  \vec{b}) = |\vec{a}| \  |\vec{b}| \ (\vec{a} \cdot \vec{b}) = |\vec{a}| \  |\vec{b}| \ cos\theta$ 。

### 矢量的叉积

矢量的叉积又称外积，$\vec{a} \times \vec{b}$ （$\times$ 是不能省略的），其最后结果仍是一个矢量。
$$
\vec{a} \times \vec{b} = (a_x,\ a_y,\ a_z) \times (b_x,\ b_y,\ b_z) = (a_yb_z - a_zb_y,\ a_zb_x - a_xb_z,\ a_xb_y - a_yb_x)
$$

<img src="图片\Shader\叉积的计算规律.jpg" style="zoom:25%;" />

例子：
$$
\begin{aligned}
(1,2,3) \times (-2, -1, 4) &= (2 * 4 - 3 * (-1), 3 * (-2) - 1 * 4, 1 * (-1) - 2 * (-2)) 
\\
&= (8 + 3, -6 - 4, -1 + 4)
\\
&= (11, -10, 3)
\end{aligned}
$$
<font color = skyblue>注意：</font>$$\vec{a} \times \vec{b} \neq \vec{b} \times \vec{a}$$ ，$\vec{a} \times \vec{b} \times \vec{c} \neq \vec{a} \times (\vec{b} \times \vec{c})$，但是满足 $\vec{a} \times \vec{b} = -(\vec{b} \times \vec{a})$。

#### 几何意义

两个矢量的叉积会得到一个同时垂直于两个矢量的新矢量。新矢量的模：$|\vec{a} \times \vec{b}| = |\vec{a}| \times |\vec{b}| \  sin \theta$。该公式也是平行四边形的面积公式。平行四边形面积 = 底 × 高。平行四边形高 = $|\vec{a}| sin \theta$。

![平行四边形面积公式](图片\Shader\平行四边形面积公式.jpg)

<center>平行四边形面积公式</center>

新矢量的方向：可以使用 右手法则 或 左手法则 旋转获得。两种方法都是先摊开手心，手指朝向 $\vec{a}$ 的方向，将手指朝着 $\vec{b}$ 的方向握紧，大拇指的方向即新矢量的方向。虽然左手和右手法则得到的方向是相反的，但是叉乘的结果始终不变。也就是说如果叉乘的结果大于 0，那么，在左手坐标系中，其方向是左手坐标系中的正方向；在右手坐标系中，其方向是右手坐标系中的正方向。小于 0，同理其方向都是在左、右手坐标系中的反方向。

#### 作用

用于计算垂直于一个平面、三角形的矢量，还可以判断三角面片的朝向。<font color = skyblue>也就是说使用法则获得的方向就是三角面的朝向。</font>

如下图，三角形的三个顶点都位于 xy 平面上，人眼位于 z 轴的负方向，向 z 轴的正方向观察。可以通过叉乘判断人眼观察到的是三角面片的正面还是背面，3 个点的顺序是顺时针还是逆时针。

![三角面片的朝向](图片\Shader\三角面片的朝向.jpg)

图片中的点只是举例，不要被图片迷惑。<font color = skyblue>想象 $p_1$、$p_3$换位置。就是小于 0 的情况</font>

<img src="图片\Shader\三角面片的朝向判断.jpg" alt="三角面片的朝向判断" style="zoom: 33%;" />

## 矩阵

矩阵可以把一个矢量从一个坐标空间转换到另一个坐标空间。

以下两种矩阵写法都可。

<font color = skyblue>在本笔记中以后都使用 `[]` 来包裹矩阵，矩阵名使用大写英文字母表示，矩阵的元素都以矩阵名的小写字母表示，这样好看一点。</font>
$$
\left[
\begin{matrix}
1 & 2 & 3 \\
4 & 5 & 6 \\
7 & 8 & 9
\end{matrix}
\right]
\qquad\qquad
\left(
\begin{matrix}
1 & 2 & 3 \\
4 & 5 & 6 \\
7 & 8 & 9
\end{matrix}
\right)
$$
矩阵的一般表达式。
$$
M = 
\left[
\begin{matrix}
m_{11} & m_{12} & m_{13} \\
m_{21} & m_{22} & m_{23} \\
m_{31} & m_{32} & m_{33}
\end{matrix}
\right]
$$

### 矩阵的乘法

#### 矩阵与标量

$$
\begin{align}
kM &= Mk
\\\\

&=k 
\left[
\begin{matrix}
m_{11} & m_{12} & m_{13} \\
m_{21} & m_{22} & m_{23} \\
m_{31} & m_{32} & m_{33}
\end{matrix}
\right]
\\\\

&=
\left[
\begin{matrix}
km_{11} & km_{12} & km_{13} \\
km_{21} & km_{22} & km_{23} \\
km_{31} & km_{32} & km_{33}
\end{matrix}
\right]
\end{align}
$$

#### 矩阵与矩阵

一个 $r \times n$ 的矩阵 A 和一个 $r \times c$ 的矩阵 B 相乘，它们的结果是一个 $r \times c$ 大小的矩阵。

矩阵与矩阵相乘，前一个矩阵的列数 必须和 后一个矩阵的行数 相等。<font color = skyblue> 这个条规定必须满足，否则两个矩阵无法相乘。</font>

$矩阵 A \times 矩阵 B = 矩阵 C$，$矩阵C$ 中的每一元素 c 的计算公式如下。
$$
\begin{aligned}
c_{ij} &= a_{i1}b_{1j} + a_{i2}b_{2j} + \cdots + a_{in}b_{nj}
\\
&= \sum_{k = 1}^{n}{a_{ik}b_{kj}}
\end{aligned}
$$

$c_{ij}$ 其实就是 矩阵 A 的第 i 行向量 与矩阵 B 的第 j 列向量的点乘。

##### 性质

性质一

通常情况下：
$$
AB \neq BA
$$
性质二

矩阵乘法满足结合律
$$
(AB)C = A(BC)
\\
ABCDE = ((A(BC))D)E = (AB)(CD)E
$$

### 特殊的矩阵

#### 方块矩阵

方块矩阵（square matrix），简称方阵，指 行 和 列 数目相等的矩阵，常用的是 $ 3 \times 3 $ 和 $ 4 \times 4 $ 的方阵。

##### 对角元素

对角元素是只有方阵才具有的。方阵的对角元素是 行号 和 列号 相等的元素，如 $ m_{11} 、 m_{22} $等。

##### 对角矩阵

一个 除了对角元素外所有的元素都为 0 的矩阵。
$$
\left[
\begin{matrix}
5 & 0 & 0 & 0 & 0 \\
0 & 9 & 0 & 0 & 0 \\
0 & 0 & -6 & 0 & 0 \\
0 & 0 & 0 & 20 & 0 \\
0 & 0 & 0 & 0 & 8 
\end{matrix}
\right]
$$

##### 单位矩阵

一种特殊的对角矩阵。一种对角元素都为 1 的对角矩阵，一般用 $ I_n $ 来表示。
$$
I_4 = 
\left[
\begin{matrix}
1 & 0 & 0 & 0 \\
0 & 1 & 0 & 0 \\
0 & 0 & 1 & 0 \\
0 & 0 & 0 & 1
\end{matrix}
\right]
$$
<font color = skyblue>任何矩阵与单位矩阵相乘的结果都还是原来的矩阵。</font>
$$
MI = IM = M
$$

##### 逆矩阵

逆矩阵必须是一个方阵，但不是所有方阵都有逆矩阵（例如所有元素都是 0 的方阵）。用 $M^{-1}$ 来表示逆矩阵。

如果一个矩阵有对应的逆矩阵，我们就说这个矩阵是可逆的（invertible） 或者 是非奇异的（nonsingular）；相反，我们就说这个矩阵是不可逆的（noninvertible） 或者 是奇异的（singular）。

我们可以通过判断矩阵的行列式是否为 0 来得知其是否可逆，Shader 中一般通过调用第三方库（如 C++ 数学库 Eigen）。

###### 性质

性质一

原矩阵与逆矩阵相乘的结果是单位矩阵。
$$
MM^{-1} = M^{-1}M = I
$$
性质二

逆矩阵的逆矩阵是原矩阵本身。
$$
(M^{-1})^{-1} = M
$$
性质三

单位矩阵的逆矩阵是它本身。
$$
I^{-1} = I
$$
性质四

矩阵串接相乘后的逆矩阵等于反向串接各个矩阵的逆矩阵。
$$
(AB)^{-1} = B^{-1}A^{-1}
$$
该性质可以扩展到更多矩阵。
$$
(ABCD)^{-1} = D^{-1}C^{-1}B^{-1}A^{-1}
$$

###### 几何意义

一个矩阵可以表示一个变换，逆矩阵可以还原这个变换，也就是计算这个变换的反向变换。例如，如果我们使用变换矩阵 M 对矢量 v 进行了一次变换，然后再使用它的逆矩阵 $M^{-1}$ 进行另一次变换，那么我们会得到原来的矢量。
$$
M^{-1}(Mv) = (M^{-1}M)v = Iv = v
$$

###### 求逆矩阵方法

有三种求逆矩阵的方法，分别是：待定系数法、伴随矩阵法、初等变换法。

例子：

有一个矩阵 A，求其逆矩阵。
$$
A = 
\left[
\begin{matrix}
1 & -4 & -3 \\
1 & -5 & -3 \\
-1 & 6 & 4
\end{matrix}
\right]
$$
**待定系数法**

设 A 的逆矩阵为
$$
A^{-1} = 
\left[
\begin{matrix}
a & b & c \\
d & e & f \\
g & h & i
\end{matrix}
\right]
$$
根据性质 $AA^{-1} = I$ ，可以得到三组 三元一次方程组
$$
a - 4d - 3g = 1 \\
b - 4e - 3h = 0 \\
c - 4f - 3i = 0 \\
a - 5d - 3g = 0 \\
b - 5e - 3h = 1 \\
c - 5f - 3i = 0 \\
-a + 6d + 4g = 0 \\
-b + 6e + 4h = 0 \\
-c + 6f + 4i = 1
$$
整理后：

第一组
$$
a - 4d - 3g = 1 \\
a - 5d - 3g = 0 \\
-a + 6d + 4g = 0
$$
求得 a = 2，d = 1，g = -1

第二组
$$
b - 4e - 3h = 0 \\
b - 5e - 3h = 1 \\
-b + 6e + 4h = 0
$$
求得 b = 2，e = -1，h = 2

第三组
$$
c - 4f - 3i = 0 \\
c - 5f - 3i = 0 \\
-c + 6f + 4i = 1
$$
求得 c = 3，f = 0，i = 1

所以，
$$
\left[
\begin{matrix}
2 & 2 & 3 \\
1 & -1 & 0 \\
-1 & 2 & 1
\end{matrix}
\right]
$$
**伴随矩阵法**

有一个公式：$A^{-1} = \frac{1}{|A|}A^*$ ，|A| 表示 A 的行列式，即所有三条对角线的对角元素相乘之和减去三条反向对角线的对角元素之和，$A^*$ 表示伴随矩阵，即代数余子式的转置。
$$
\begin{aligned}
|A| &= 1 * (-5) * 4 + (-4) * (-3) * (-1) + (-3) * 1 * 6 - (-3) * (-5) * (-1) - 1 * (-3) * 6 - (-4) * 1 * 4
\\
&= -20 - 12 - 18 + 15 + 18 + 16
\\
&= -1
\\
\\
A^* &= 
\left[
\begin{matrix}
|A_{11}| & |A_{21}| & |A_{31}| \\
|A_{12}| & |A_{22}| & |A_{32}| \\
|A_{13}| & |A_{23}| & |A_{33}| \\
\end{matrix}
\right]
\\
\\
A_{11} &= 
(-1)^{1 + 1} * 
\left|
\begin{matrix}
-5 & -3 \\
6 & 4
\end{matrix}
\right|
\\
&= 1 * ((-5) * 4 - (-3) * 6) \\
&= -2
\\
A_{21} &= 
(-1)^{2 + 1} * 
\left|
\begin{matrix}
-4 & -3 \\
6 & 4
\end{matrix}
\right|
\\
&= -1 * ((-4) * 4 - (-3) * 6) \\
&= -2
\\
A_{31} &= 
(-1)^{3 + 1} * 
\left|
\begin{matrix}
-4 & -3 \\
-5 & -3
\end{matrix}
\right|
\\
&= 1 * ((-4) * (-3) - (-3) * (-5)) \\
&= -3
\\
A_{12} &= 
(-1)^{1 + 2} * 
\left|
\begin{matrix}
1 & -3 \\
-1 & 4
\end{matrix}
\right|
\\
&= -1 * (1 * 4 - (-3) * (-1)) \\
&= -1
\\
A_{22} &= 
(-1)^{2 + 2} * 
\left|
\begin{matrix}
1 & -3 \\
-1 & 4
\end{matrix}
\right|
\\
&= 1 * (1 * 4 - (-3) * (-1)) \\
&= 1
\\
A_{32} &= 
(-1)^{3 + 2} * 
\left|
\begin{matrix}
1 & -3 \\
1 & -3
\end{matrix}
\right|
\\
&= -1 * (1 * (-3) - (-3) * 1) \\
&= 0
\\
A_{13} &= 
(-1)^{1 + 3} * 
\left|
\begin{matrix}
1 & -5 \\
-1 & 6
\end{matrix}
\right|
\\
&= 1 * (1 * (-5) - (-1) * 6) \\
&= 1
\\
A_{23} &= 
(-1)^{2 + 3} * 
\left|
\begin{matrix}
1 & -4 \\
-1 & 6
\end{matrix}
\right|
\\
&= -1 * (1 * (-4)) - (-1) * 6)) \\
&= -2
\\
A_{33} &= 
(-1)^{3 + 3} * 
\left|
\begin{matrix}
1 & -4 \\
1 & -5
\end{matrix}
\right|
\\
&= 1 * (1 * (-5) - 1 * (-4)) \\
&= -1
\\
\\
A^* &= 
\left[
\begin{matrix}
-2 & -2 & -3 \\
-1 & 1 & 0 \\
1 & -2 & -1
\end{matrix}
\right]
\\
\\
A^{-1} &=
-1 * 
\left[
\begin{matrix}
-2 & -2 & -3 \\
-1 & 1 & 0 \\
1 & -2 & -1
\end{matrix}
\right]
\\
&= 
\left[
\begin{matrix}
2 & 2 & 3 \\
1 & -1 & 0 \\
-1 & 2 & 1
\end{matrix}
\right]
\end{aligned}
$$
**初等变换法**

有一个进行初等行变换的公式：$[A | I] \longrightarrow [I | A^{-1}]$ 。
$$
\begin{aligned}
\left[
\begin{matrix}
1 & -4 & -3 \\
1 & -5 & -3 \\
-1 & 6 & 4
\end{matrix}
\middle|
\begin{matrix}
1 & 0 & 0 \\
0 & 1 & 0 \\
0 & 0 & 1
\end{matrix}
\right]
\end{aligned}
$$
第二行 = 第一行 - 第二行

第三行 = 第一行 + 第三行

得到：
$$
\begin{aligned}
\left[
\begin{matrix}
1 & -4 & -3 \\
0 & 1 & 0 \\
0 & 2 & 1
\end{matrix}
\middle|
\begin{matrix}
1 & 0 & 0 \\
1 & -1 & 0 \\
1 & 0 & 1
\end{matrix}
\right]
\end{aligned}
$$
第一行 = 第一行 + 4 * 第二行

第三行 = 第三行 - 2 * 第二行

得到：
$$
\begin{aligned}
\left[
\begin{matrix}
1 & 0 & -3 \\
0 & 1 & 0 \\
0 & 0 & 1
\end{matrix}
\middle|
\begin{matrix}
5 & -4 & 0 \\
1 & -1 & 0 \\
-1 & 2 & 1
\end{matrix}
\right]
\end{aligned}
$$
第一行 = 第一行 + 3 * 第三行

得到：
$$
\begin{aligned}
\left[
\begin{matrix}
1 & 0 & 0 \\
0 & 1 & 0 \\
0 & 0 & 1
\end{matrix}
\middle|
\begin{matrix}
2 & 2 & 3 \\
1 & -1 & 0 \\
-1 & 2 & 1
\end{matrix}
\right]
\end{aligned}
$$

##### 正交矩阵

正交矩阵是一种特殊的方阵。正交是一种属性。

正交：一个方阵 M 和它的转置矩阵的乘积是单位矩阵称为正交。
$$
MM^T = M^TM = I
$$
如果一个矩阵是正交的，那么其转置矩阵和逆矩阵是一样的。
$$
M^T = M^{-1}
$$
###### 几何意义

$$
\begin{aligned}
M^TM &= 
\left[
\begin{matrix}
- & c_1 & - \\
- & c_2 & - \\
- & c_3 & -
\end{matrix}
\right]
\left[
\begin{matrix}
| & | & | \\
c_1 & c_2 & c_3 \\
| & | & |
\end{matrix}
\right]
\\
&=
\left[
\begin{matrix}
c_1 \cdot c_1 & c_1 \cdot c_2 & c_1 \cdot c_3 \\
c_2 \cdot c_1 & c_2 \cdot c_2 & c_2 \cdot c_3 \\
c_3 \cdot c_1 & c_3 \cdot c_2 & c_3 \cdot c_3
\end{matrix}
\right]
\\
&=
\left[
\begin{matrix}
1 & 0 & 0 \\
0 & 1 & 0 \\
0 & 0 & 1
\end{matrix}
\right]
\\
&= I
\end{aligned}
$$

可以得到：
$$
c_1 \cdot c_1 = 1 & c_1 \cdot c_2 = 0 & c_1 \cdot c_3 = 0 \\
c_2 \cdot c_1 = 0 & c_2 \cdot c_2 = 1 & c_2 \cdot c_3 = 0 \\
c_3 \cdot c_1 = 0 & c_3 \cdot c_2 = 0 & c_3 \cdot c_3 = 1
$$

可以得到一下结论：

矩阵的每一行，即 $c_1$、$c_2$ 和 $c_3$ 是单位矢量，因为只有这样它们与自己的点积才能是 1。

矩阵的每一行，即 $c_1$、$c_2$ 和 $c_3$ 之间互相垂直，因为只有这样它们之间的点积才能是 0。

如果 M 是正交矩阵，则 $M^T$ 也是正交矩阵。一组标准正交基可以满足上述条件。我们会使用坐标空间的基矢量来构建用于空间变换的矩阵。如果这些基矢量是一组标准正交基的话（例如只存在旋转变换），那么我们可以直接使用转置矩阵来球的该变换的逆变换。

解释：

$c_1 \cdot c_1 = 1$ ：$c_1$ 和 $c_1$ 夹角必为 0，则 $cos0° = 1$ ，所以 $c_1  = 1$ 。

$c_1 \cdot c_2 = 0$ ：由于上面已得出 $c_1$ 、$c_2$ 和 $c_3$ 长度必为 1，所以只有 $cos\theta$ 为 0 才能使等式成立。则 $c_1$ 和 $c_2$ 互相垂直。

###### 补充

基矢量：坐标轴。

一组正交基：一组基矢量互相垂直。

一组标准正交基：长度为 1，且互相垂直的一组基矢量。例如长度为 1 的坐标轴。

正交矩阵的行和列之间分别构成了一组标准正交基，但是一组正交基来不一定能构建处正交矩阵，因为不是一组标准正交基。

#### 转置矩阵

一种对原矩阵的转置运算，就是第 i 行变成了第 i 列，第 j 列变成了第 j 行。矩阵 M 的转置可以用 $M^T$ 来表示。
$$
\left[
\begin{matrix}
x & y & z \\
\end{matrix}
\right]^T = 
\left[
\begin{matrix}
x \\
y \\
z
\end{matrix}
\right]
$$

##### 性质

性质一：

矩阵转置的转置等于原矩阵。
$$
(M^T)^T = M
$$
性质二：

矩阵串接的转置，等于反向串接个矩阵的转置。
$$
(AB)^T = B^TA^T
$$

### 行矩阵和列矩阵

假设有一个矢量 $v = (x,y,z)$ ，可以把它转换成行矩阵 $v = \left[ \begin{matrix} x & y & z \end{matrix} \right]$ ，也可以转换成列矩阵 $v = \left[ \begin{matrix} x \\ y \\ z\end{matrix} \right]$。

假设有一个矩阵 M：
$$
M =
\left[
\begin{matrix}
m_{11} & m_{12} & m_{13} \\
m_{21} & m_{22} & m_{23} \\
m_{31} & m_{32} & m_{33}
\end{matrix}
\right]
$$
如果矢量 v 在 M 的左边与 M 相乘，则需要将矢量 v 转换成行矩阵。
$$
vM =
\left[
\begin{matrix}
xm_{11} + ym_{21} + zm{31} & xm_{12} + ym_{22} + zm{32} & xm_{13} + ym_{23} + zm{33}
\end{matrix}
\right]
$$
如果矢量 v 在 M 的右边边与 M 相乘，则需要将矢量 v 转换成列矩阵。
$$
Mv = 
\left[
\begin{matrix}
m_{11}x + m_{12}y + m_{13}z \\
m_{21}x + m_{22}y + m_{23}z \\
m_{31}x + m_{32}y + m_{33}z
\end{matrix}
\right]
$$
<font color = skyblue>一般会把矢量放在矩阵的右侧，也就是矢量会被转换成列矩阵。</font>
$$
CBAv = C(B(Av))
$$
当矢量是行矩阵时，上面的式子等价于：
$$
v 是列矩阵时 \\
(C(B(Av)))^T = (B(Av))^TC^T = (Av)^TB^TC^T = v^TA^TB^TC^T \\
v是行矩阵时 \\
vA^TB^TC^T = ((vA^T)B^T)C^T
$$

### 矩阵的变换

变换（transform）：把一些数据，如点、方向矢量甚至是颜色等，通过某种方式进行转换的过程。

变换类型：

线性变换（linear transform）：可以保留矢量加和标量乘的变换。

仿射变换（affine transform）：合并线性变换和平移变换。

#### 变换类型

##### 线性变换

线性变换（linear transform）指的是可以保留矢量加和标量乘的变换。
$$
f(x) + f(y) = f(x + y)
\\
kf(x) = f(kx)
$$
线性变换包括：缩放（scale）、旋转（rotation）、错切（shear）、镜像（mirroring，又称 reflection）、正交投影（orthographic projection）等。

<font color = skyblue>平移不是线性变换。</font>假设 $f(x) = x + (1,2,3)$ 。令 $x = (1,1,1)$ 。那么：
$$
f(x) + f(x) = x + (1,2,3) + x + (1,2,3) = (1,1,1) + (1,2,3) + (1,1,1) + (1,2,3) = (4,6,8) \\
f(x + x) = x + x + (1,2,3) = (1,1,1) + (1,1,1) + (1,2,3) = (3,4,5) \\
所以，f(x) + f(x) \neq f(x + x)
$$
当我们对一个三维矢量进行变换时，只需使用 $3 \times 3$ 的矩阵即可。

##### 仿射变换

仿射变换（affine transform）指的是合并线性变换和平移变换。仿射变换需要把矢量扩展到四维空间下。

齐次坐标空间（homogeneous space）：四维空间。

##### 常见变换总结

| 变换名称               | 是线性变换吗 | 是仿射变换吗 | 是可逆矩阵吗 | 是正交矩阵吗 |
| ---------------------- | ------------ | ------------ | ------------ | ------------ |
| 平移矩阵               | N            | Y            | Y            | N            |
| 绕坐标轴旋转的旋转矩阵 | Y            | Y            | Y            | Y            |
| 绕任意轴旋转的旋转矩阵 | Y            | Y            | Y            | Y            |
| 按坐标缩放的缩放矩阵   | Y            | Y            | Y            | N            |
| 错切矩阵               | Y            | Y            | Y            | N            |
| 镜像矩阵               | Y            | Y            | Y            | Y            |
| 正交投影矩阵           | Y            | Y            | N            | N            |
| 透视投影矩阵           | N            | N            | N            | N            |

#### 齐次坐标

齐次坐标（homogeneous coodinate）泛指四维坐标，但齐次坐标的维度可以超过四维。

三维坐标转换成齐次坐标是把 w 分量设为 1，方向矢量转换成齐次坐标是把 w 分量设为 0。这样的设置会导致，当使用一个 $4 \times 4$ 的矩阵对一个点进行变换时，平移、旋转、缩放都会施加于该点。但用于方向矢量变换时，平移效果将会被忽略。

#### 变换矩阵

基础变换矩阵：纯平移、纯旋转、纯缩放的变换矩阵。

基础变换矩阵的共通点：
$$
\left[
\begin{matrix}
M_{3 \times 3} & t_{3 \times 3} \\
0_{1 \times 3} & 1
\end{matrix}
\right]
$$
左上角的矩阵 $M_{3 \times 3}$ 用于表示旋转和缩放，$t_{3 \times 1}$ 用于表示平移，$0_{1 \times 3}$ 是零矩阵，即 $0_{1 \times 3} = \left[ \begin{matrix} 0 & 0 & 0 \end{matrix} \right]$ ，右下角的元素就是标量 1。

##### 平移矩阵

对一个点进行平移变换：
$$
\left[
\begin{matrix}
1 & 0 & 0 & t_x \\
0 & 1 & 0 & t_y \\
0 & 0 & 1 & t_z \\
0 & 0 & 0 & 1
\end{matrix}
\right]
\left[
\begin{matrix}
x \\
y \\
z \\
1
\end{matrix}
\right]
=
\left[
\begin{matrix}
x + t_x \\
y + t_y\\
z + t_z\\
1
\end{matrix}
\right]
$$
对一个方向矢量进行平移变换：
$$
\left[
\begin{matrix}
1 & 0 & 0 & t_x \\
0 & 1 & 0 & t_y \\
0 & 0 & 1 & t_z \\
0 & 0 & 0 & 1
\end{matrix}
\right]
\left[
\begin{matrix}
x \\
y \\
z \\
0
\end{matrix}
\right]
=
\left[
\begin{matrix}
x \\
y \\
z \\
0
\end{matrix}
\right]
$$
方向矢量经过平移后还是原方向矢量，因为其方向和长度都没有改变。

构建一个平移矩阵的方法：基础变换矩阵中的 $M_{3 \times 3}$ 为单位矩阵 $I_3$ ，$t_{3 \times 1}$ 矢量为平移矢量。

平移矩阵的<font color = skyblue>逆矩阵就是反向平移</font>得到的矩阵：
$$
\left[
\begin{matrix}
1 & 0 & 0 & -t_x \\
0 & 1 & 0 & -t_y \\
0 & 0 & 1 & -t_z \\
0 & 0 & 0 & 1
\end{matrix}
\right]
$$
平移矩阵<font color = skyblue>不是正交矩阵。</font>

##### 缩放矩阵

对一个模型沿空间的 x 轴、y 轴、z 轴 进行缩放变换：
$$
\left[
\begin{matrix}
k_x & 0 & 0 & 0 \\
0 & k_y & 0 & 0 \\
0 & 0 & k_z & 0 \\
0 & 0 & 0 & 1
\end{matrix}
\right]
\left[
\begin{matrix}
x \\
y \\
z \\
1
\end{matrix}
\right]
=
\left[
\begin{matrix}
k_xx \\
k_yy \\
k_zz \\
1
\end{matrix}
\right]
$$
对一个矢量进行缩放变换：
$$
\left[
\begin{matrix}
k_x & 0 & 0 & 0 \\
0 & k_y & 0 & 0 \\
0 & 0 & k_z & 0 \\
0 & 0 & 0 & 1
\end{matrix}
\right]
\left[
\begin{matrix}
x \\
y \\
z \\
0
\end{matrix}
\right]
=
\left[
\begin{matrix}
k_xx \\
k_yy \\
k_zz \\
0
\end{matrix}
\right]
$$
统一缩放（uniform scale）：缩放系数 $k_x = k_y = k_z$ 。扩大整个模型，不会改变角度和比例信息。

非统一缩放（nonuniform scale）：缩放系数至少有一个不相等。拉伸或挤压模型，会改变与模型相关的角度和比例。

在对法线变换时，使用非统一缩放对顶点进行变换时会得到错误的结果。

缩放矩阵的<font color = skyblue>逆矩阵是原缩放系数的倒数 </font>来对点或方向矢量进行缩放：
$$
\left[
\begin{matrix}
\frac{1}{k_x} & 0 & 0 & 0 \\
0 & \frac{1}{k_y} & 0 & 0 \\
0 & 0 & \frac{1}{k_z} & 0 \\
0 & 0 & 0 & 1
\end{matrix}
\right]
$$
缩放矩阵<font color = skyblue>一般不是正交矩阵。</font>

上面的矩阵值适用于沿坐标轴方向进行缩放，如果希望在任意方向上进行缩放，就需要使用复合变换。<font color = glass>思想：现将缩放轴变换成标准坐标轴，然后进行沿坐标轴的缩放，再使用逆变换得到原来的缩放轴朝向。</font>

##### 旋转矩阵

绕着空间中 x 轴旋转：
$$
R_x(\theta) = 
\left[
\begin{matrix}
1 & 0 & 0 & 0 \\
0 & cos\theta & -sin\theta & 0 \\
0 & sin\theta & cos\theta & 0 \\
0 & 0 & 0 & 1 \\
\end{matrix}
\right]
$$
绕着空间中 y 轴旋转：
$$
R_y(\theta) = 
\left[
\begin{matrix}
cos\theta & 0 & sin\theta & 0 \\
0 & 1 & 0 & 0 \\
-sin\theta & 0 & cos\theta & 0 \\
0 & 0 & 0 & 1 \\
\end{matrix}
\right]
$$
绕着空间中 z 轴旋转：
$$
R_x(\theta) = 
\left[
\begin{matrix}
cos\theta & -sin\theta & 0 & 0 \\
sin\theta & cos\theta & 0 & 0 \\
0 & 0 & 1 & 0 \\
0 & 0 & 0 & 1 \\
\end{matrix}
\right]
$$
旋转矩阵的<font color = skyblue>逆矩阵是旋转反向角度</font>得到的变换矩阵。<font color = skyblue>旋转矩阵是正交矩阵</font>，而且多个旋转矩阵之间的串联同样是正交的。

##### 复合变换

复合变换可以通过矩阵的串联实现。对于列矩阵变换而言，阅读顺序是从右向左。<font color = skyblue>一般先进行缩放变换，再进行旋转变换，最后进行平移变换。</font>由于矩阵乘法不满足交换律，所以矩阵的乘法顺序不同，结果肯能也不同。例如：先左转再向前一步和先向前一步再左转的结果是不同的。
$$
P_{new} = M_{translation}(M_{rotation}(M_{scale}P_{old}))
$$
例子：

先缩放、再绕 y 轴旋转、最后平移：
$$
\begin{aligned}
M_{translation}(M_{rotation}M_{scale}) &= 
\left[
\begin{matrix}
1 & 0 & 0 & t_x \\
0 & 1 & 0 & t_y \\
0 & 0 & 1 & t_z \\
0 & 0 & 0 & 1
\end{matrix}
\right]
\left[
\begin{matrix}
cos\theta & 0 & sin\theta & 0 \\
0 & 1 & 0 & 0 \\
-sin\theta & 0 & cos\theta & 0 \\
0 & 0 & 0 & 1
\end{matrix}
\right]
\left[
\begin{matrix}
k_x & 0 & 0 & 0 \\
0 & k_y & 0 & 0 \\
0 & 0 & k_z & 0 \\
0 & 0 & 0 & 1
\end{matrix}
\right]
\\
&=
\left[
\begin{matrix}
k_xcos\theta & 0 & kzsin\theta & t_x \\
0 & k_y & 0 & t_y \\
-k_xsin\theta & 0 & k_zcos\theta & t_z \\
0 & 0 & 0 & 1
\end{matrix}
\right]
\end{aligned}
$$
先平移、再缩放，最后绕 y 轴旋转：
$$
\begin{aligned}
M_{translation}(M_{rotation}M_{scale}) &= 
\left[
\begin{matrix}
cos\theta & 0 & sin\theta & 0 \\
0 & 1 & 0 & 0 \\
-sin\theta & 0 & cos\theta & 0 \\
0 & 0 & 0 & 1
\end{matrix}
\right]
\left[
\begin{matrix}
k_x & 0 & 0 & 0 \\
0 & k_y & 0 & 0 \\
0 & 0 & k_z & 0 \\
0 & 0 & 0 & 1
\end{matrix}
\right]
\left[
\begin{matrix}
1 & 0 & 0 & t_x \\
0 & 1 & 0 & t_y \\
0 & 0 & 1 & t_z \\
0 & 0 & 0 & 1
\end{matrix}
\right]
\\
&=
\left[
\begin{matrix}
k_xcos\theta & 0 & kzsin\theta & t_xk_xcos\theta + t_zk_zsin\theta \\
0 & k_y & 0 & t_yk_y \\
-k_xsin\theta & 0 & k_zcos\theta & -t_zk_zsin\theta + t_zk_zcos\theta \\
0 & 0 & 0 & 1
\end{matrix}
\right]
\end{aligned}
$$
同时，我们还要小心各轴的旋转顺序。在 Unity 中，旋转顺序是 zxy。但是这个顺序是 Unity 按照绕坐标系 E 下的 z 轴旋转 $\theta_z$ ，绕坐标系 E 下的 x 轴旋转 $\theta_x$ ，绕坐标系 E 下的 z 轴旋转 $\theta_y$ 得到的。想要像上面一样，则需要将顺序颠倒一下，<font color = skyblue>变成 yxz</font> 。这样则是按照绕坐标系 E 下的 z 轴旋转 $\theta_z$ ，在坐标系 E 下绕 z 轴旋转 $\theta_z$ 后的新坐标系 $E'$ 下的 x 轴旋转 $\theta_x$ ，在坐标系 $E'$ 下绕 y 轴旋转 $\theta_x$ 后的新坐标系 $E''$ 下的 y 轴旋转 $\theta_y$ 。

得到的组合旋转变换矩阵是：
$$
M_{rotatez}(M_{rotatex}M_{rotatey}) = 
\left[
\begin{matrix}
cos\theta & -sin\theta & 0 & 0 \\
sin\theta & cos\theta & 0 & 0 \\
0 & 0 & 1 & 0 \\
0 & 0 & 0 & 1 \\
\end{matrix}
\right]
\left[
\begin{matrix}
1 & 0 & 0 & 0 \\
0 & cos\theta & -sin\theta & 0 \\
0 & sin\theta & cos\theta & 0 \\
0 & 0 & 0 & 1 \\
\end{matrix}
\right]
\left[
\begin{matrix}
cos\theta & 0 & sin\theta & 0 \\
0 & 1 & 0 & 0 \\
-sin\theta & 0 & cos\theta & 0 \\
0 & 0 & 0 & 1 \\
\end{matrix}
\right]
$$

## 坐标空间

### 坐标空间的变换

在渲染流水线中，我们通常需要把一个点或一个方向矢量从一个坐标空间转换到另一个空间。

实现流程：

想要定义一个坐标空间，必须指明其原点位置和 3 个坐标轴的方向。而这些数值实际上是相对于另一个坐标空间的。也就是，坐标空间会形成一个层次结构——每个坐标空间都是另一个坐标空间的子空间，反过来说，每个空间都有一个父坐标空间。对坐标空间的变换实际是父空间和子空间之间对点和矢量进行变换。

现有父坐标空间 P 和 子坐标空间 C。已知：父坐标空间中子坐标空间的原点位置和 3 个单位坐标轴。一般有两种需求：

1. 把子坐标空间下表示的点或矢量 $A_c$ 转换到父坐标空间下的表示 $A_p$ ，公式表示：$A_p = M_{c \rightarrow p} A_c$ 
2. 把父坐标空间下表示的点或矢量 $B_p$ 转换到子坐标空间下的表示 $B_c$ ，公式表示：$B_c = M_{p \rightarrow c} B_p$

其中 $M_{p \rightarrow c}$ 是 $M_{c \rightarrow p}$ 的逆矩阵。

子坐标空间转换到父坐标空间流程：

已知：子坐标空间 C 的 3 个坐标轴在父坐标空间 P 下表示 $x_c$ 、$y_c$ 、$z_c$ ，以及其原点位置 $O_c$ 。给定一个子坐标空间中的一个点 $A_c = (a,b,c)$ 。

目标：确定其父坐标空间下的位置 $A_p$ ：

解：

1. 从坐标空间的原点开始

   已知子坐标空间的原点 $O_c$

2. 向 x 轴方向移动 a 个单位

   $O_c + ax_c$

3. 向 y 轴方向移动 b 个单位

   $O_c + ax_c + by_c$

4. 向 z 轴方向移动 c 个单位

   $O_c + ax_c + by_c + cz_c$

5. 
   $$
   \begin{aligned}
   A_p &= O_c + ax_c + by_c + cz_c
   \\
   &= (x_{O_c},y_{O_c},z_{O_c}) + a(x_{x_c},y_{y_c},z_{z_c}) + b(x_{x_c},y_{y_c},z_{z_c}) + c(x_{x_c},y_{y_c},z_{z_c})
   \\
   &= (x_{O_c},y_{O_c},z_{O_c}) + 
   \left[
   \begin{matrix}
   x_{x_c} & x_{y_c} & x_{z_c} \\
   y_{x_c} & y_{y_c} & y_{z_c} \\
   z_{x_c} & z_{y_c} & z_{z_c}
   \end{matrix}
   \right]
   \left[
   \begin{matrix}
   a \\
   b \\
   c
   \end{matrix}
   \right]
   \\
   &= (x_{O_c},y_{O_c},z_{O_c}) + 
   \left[
   \begin{matrix}
   | & | & | \\
   x_c & y_c & z_c \\
   | & | & |
   \end{matrix}
   \right]
   \left[
   \begin{matrix}
   a \\
   b \\
   c
   \end{matrix}
   \right]
   \end{aligned}
   $$
   $x_{x_c}$ 代表子坐标空间下 x 轴的 x 分量，其中下标 $x_c$ 就代表子坐标空间下的 x 轴，其他同理

   "|" 表示按列展开。“+“ 代表平移变换，由于 $3 \times 3$ 的矩阵无法表示平移变换，所以需要把式子扩展到齐次坐标空间中。
   $$
   \begin{aligned}
   A_p &= (x_{O_c},y_{O_c},z_{O_c},1) + 
   \left[
   \begin{matrix}
   | & | & | & 0\\
   x_c & y_c & z_c & 0\\
   | & | & | & 0 \\
   0 & 0 & 0 & 1
   \end{matrix}
   \right]
   \left[
   \begin{matrix}
   a \\
   b \\
   c \\
   1
   \end{matrix}
   \right]
   \\
   &= 
   \left[
   \begin{matrix}
   1 & 0 & 0 & x_{O_c} \\
   0 & 1 & 0 & y_{O_c} \\
   0 & 0 & 1 & z_{O_c} \\
   0 & 0 & 0 & 1
   \end{matrix}
   \right]
   \left[
   \begin{matrix}
   | & | & | & 0\\
   x_c & y_c & z_c & 0\\
   | & | & | & 0 \\
   0 & 0 & 0 & 1
   \end{matrix}
   \right]
   \left[
   \begin{matrix}
   a \\
   b \\
   c \\
   1
   \end{matrix}
   \right]
   \\
   &= 
   \left[
   \begin{matrix}
   x_{x_c} & x_{y_c} & x_{z_c} & x_{O_c} \\
   y_{x_c} & y_{y_c} & y_{z_c} & y_{O_c} \\
   z_{x_c} & z_{y_c} & z_{z_c} & z_{O_c} \\
   0 & 0 & 0 & 1
   \end{matrix}
   \right]
   \left[
   \begin{matrix}
   a \\
   b \\
   c \\
   1
   \end{matrix}
   \right]
   \\
   &= 
   \left[
   \begin{matrix}
   | & | & | & | \\
   x_c & y_c & z_c & O_c \\
   | & | & | & | \\
   0 & 0 & 0 & 1
   \end{matrix}
   \right]
   \left[
   \begin{matrix}
   a \\
   b \\
   c \\
   1
   \end{matrix}
   \right]
   \end{aligned}
   $$
   所以，$M_{c \rightarrow p}$ 出现了：
   $$
   M_{c \rightarrow p} = 
   \left[
   \begin{matrix}
   | & | & | & | \\
   x_c & y_c & z_c & O_c \\
   | & | & | & | \\
   0 & 0 & 0 & 1
   \end{matrix}
   \right]
   $$
   

<font color = skyblue>注意：</font> 3 个坐标轴 $x_c$ 、$y_c$ 和 $z_c$ 可以不是单位向量，可以存在缩放。

我们可以通过这个变换矩阵反推来获取子坐标空间的原点和坐标轴方向。我们可以提取第一列再进行归一化后（消除缩放带来的影响）来得到模型空间的 x 轴在世界空间下的单位矢量表示。或者，因为矩阵 $M_{c \rightarrow p}$ 可以把一个方向矢量从坐标空间 C 变换到坐标空间 P 中，那么，我们只需要用它来变换坐标空间 C 中的 x 轴（1，0，0，0），即使用矩阵乘法 $M_{c \rightarrow p} \left[ \begin{matrix} 1 & 0 & 0 & 0 \end{matrix}\right]^T$ ，得到的结果正是 $M_{c \rightarrow p}$ 的第一列。

对于方向矢量的坐标空间变换，矢量是不会受到平移影响的，所以坐标系的原点是不会对矢量造成影响的。这一也是在 Shader 中，我们常常会看到截取变换矩阵的前 3 行前 3 列来对法线方向、光照方向来进行空间变换。
$$
M_{c \rightarrow p} = 
\left[
\begin{matrix}
| & | & | \\
x_c & y_c & z_c \\
| & | & | 
\end{matrix}
\right]
$$
父坐标空间转换到子坐标空间：

一种方法是求 子坐标空间转换到父坐标空间的变换矩阵的逆矩阵，还有一种方法是 当我们知道子坐标空间转换到父坐标空间的变换矩阵是正交矩阵时，直接求其转置即可。

如果我们知道坐标空间 B 的 x 轴、y 轴、z 轴（必须是单位矢量，否则构建不出正交矩阵）在坐标空间 A 下的表示，就可以把它们一次放在矩阵的每一行就可以得到从 A 到 B 的变换矩阵了。

验证变换矩阵：

如果我们无法确定变换矩阵的对错：

假设现在需要把一个矢量从坐标空间 A 变换到坐标空间 B，而且我们已经知道坐标空间 B 的 x 轴、y 轴、z 轴在空间 A 下的表示，即 $x_B$ 、$y_B$ 和 $z_B$。

可以先假设：
$$
M_{A \rightarrow B} = 
\left[
\begin{matrix}
| & | & | \\
x_B & y_B & z_B \\
| & | & |
\end{matrix}
\right]
$$
假设我们用变换矩阵来变换 B 的 x 轴，那么结果应该是（1，0，0），我们验证一下。
$$
M_{A \rightarrow B}x_B = 
\left[
\begin{matrix}
| & | & | \\
x_B & y_B & z_B \\
| & | & |
\end{matrix}
\right]
x_B
$$
此时我们无法确定结果，那么这就是错的。此时我们换成按行来摆放。
$$
\begin{aligned}
M_{A \rightarrow B}x_B &= 
\left[
\begin{matrix}
- & x_B & - \\
- & y_B & - \\
- & z_B & -
\end{matrix}
\right]
x_B
\\
&=
\left[
\begin{matrix}
x_B \cdot x_B \\
y_B \cdot x_B \\
z_B \cdot x_B
\end{matrix}
\right]
\\
&=
\left[
\begin{matrix}
1 \\
0 \\
0
\end{matrix}
\right]
\end{aligned}
$$
因为已知 x 轴与 y 轴和 z 轴互相垂直所以它们的点乘结果为 0，而 x 轴的单位向量自乘等于模的平方，又是单位向量所以是 1。所以按行来摆放正确。

### 顶点的坐标空间变换过程

在渲染流水线中，一个顶点最开始是在模型空间，最后会被变换到屏幕空间中。

#### 模型空间

模型空间（model space）：也被称为对象空间（object space）或局部空间（local space）。每个模型都有自己独立的坐标空间，当他移动或旋转时候，模型空间也会跟着它移动和旋转。在 Unity 中一般使用左手坐标系。

模型空间的原点和坐标轴通常是由美术人员在建模软件里确定好的。当导入 Unity 后，我们可以在顶点着色器中访问到模型的顶点信息，其中包含每个顶点的坐标，这些坐标都是相对于模型空间中的原点（通常位于模型重心）定义的。

#### 世界空间

世界空间（world space）：是我们所关心的最外层的坐标空间。例如：农场游戏，那么世界空间指的是农场。世界空间可以被用于描述绝对位置。通常原点在游戏空间的中心。在 Unity 中一般使用左手坐标系。它的 x 轴、y 轴和 z 轴是固定不变的。我们可以通过 Transform 组件中的 Position 属性来改变模型的父节点的位置。

#### 观察空间

观察空间（view space）：也被称为摄像机空间（camera space）。观察空间可以认为是模型空间的一个特例。Unity 中，观察空间是右手坐标系。观察空间与屏幕空间不是同一个概念。观察空间是三维空间，屏幕空间是二维的。从观察空间到屏幕空间需要通过投影转换。

#### 裁剪空间

裁剪空间（clip space）：也被称为齐次裁剪空间。用于变换的矩阵被称为裁剪矩阵（clip matrix），也被称为投影矩阵（projection matrix）。裁剪空间上的目标是对图元进行裁剪，将空间外部的图元剔除。该空间是由视锥体（view frustum）来决定的。

视锥体（view frustum）：空间中的一块区域 ，这块区域决定了摄像机可以看到的空间。视锥体由六个平面包围而成，平面也被称为裁剪平面（clip planes）。其中由两块裁剪平面比较特殊，分别被称为近裁剪平面（near clip plane）和远裁剪平面（far clip plane）。视锥体由两种投影类型：正交投影（orthographic projection）和透视投影（perspective projection）。

透视投影（perspective projection）：平行线不会保持平行，离摄像机越近网格越大。模拟了人眼看世界的方式。一般用于 3D 游戏。

正交投影（orthographic projection）：平行线保持平行，网格大小一样。保留了物体之间的距离和角度。一般用于 2D 游戏或渲染小地图等 HUD 元素。

投影：可以理解为一个空间的降维，例如：四维空间投影到三维空间中。投影在屏幕映射时发生。

投影矩阵（clip matrix）：投影矩阵不会进行真正的投影，而是为投影所准备。w 分量作为一个范围值，如果 x、y、z分量位于该范围内，就说明该顶点位于剪裁空间内。

![](图片\Shader\透视投影 和 正交投影.png)

<center>左侧图片为透视投影，右侧图片为正交投影</center>

![](图片\Shader\透视投影视锥体 和 正交投影视锥体.png)

<center>左侧图片为透视投影视锥体，右侧图片为正交投影视锥体</center>

1. 透视投影

   6 个裁剪平面由 Camera 组件中的参数和 Game 视图的纵横比共同决定的。Field of View（简称 FOV）改变视锥体数值方向的张开角度，Clipping Planes 中的 Near 和 Far 参数控制视锥体的近裁剪平面和远裁剪平面距离摄像机的远近。这样可以求出视锥体近裁剪平面和远裁剪平面的高度：
   $$
   nearClipPaneHeight = 2 \cdot Near \cdot tan{\frac{FOV}{2}} \\
   farClipPlaneHeight = 2 \cdot Far \cdot tan{\frac{FOV}{2}}
   $$
   ![](图片\Shader\组件对透视视锥体的影响.png)
   
   <center>组件对透视视锥体的影响</center>

   摄像机的横向值可以通过摄像机的横纵比得到。摄像机的横纵比由 Game 视图的横纵比和 Viewport Rect 中的 W 和 H 属性共同决定（Unity 允许我们在脚本里通过 `Camera.aspect` 进行更改）。
   $$
   Aspect = \frac{nearClipPlaneWith}{nearClipPlaneHeight} \\
   Aspect = \frac{farClipPlaneWith}{farClipPlaneHeight}
   $$
   由 Near、Far、FOV 和 Aspect 得到透视投影矩阵：
   $$
   M_{frustum} = 
   \left[
   \begin{matrix}
   \frac{cot{\frac{FOV}{2}}}{Aspect} & 0 & 0 & 0 \\
   0 & cot{\frac{FOV}{2}} & 0 & 0 \\
   0 & 0 & -\frac{Far + Near}{Far - Near} & -\frac{2 \cdot Near \cdot Far}{Far - Near} \\
   0 & 0 & -1 & 0
   \end{matrix}
   \right]
   $$
   
2. 正交投影

   6 个裁剪平面也是由 Camera 组件中的参数和 Game 视图的纵横比共同决定的。Size 改变视锥体竖直方向上的一般高度，Clipping Planes 中的 Near 和 Far 参数可以控制视锥体的近裁剪平面和远裁剪平面距离摄像机的远近。这样可以求出视锥体近裁剪平面和远裁剪平面的高度：
   $$
   nearClipPlaneHeight = 2 \cdot Size \\
   farClipPlaneHeight = nearClipPlaneHeight
   $$
   摄像机的横向值可以通过摄像机的横纵比得到，假设摄像机的横纵比为 Aspect：
   $$
   nearClipPlaneWidth = Aspect \cdot nearCliptPlaneHeight \\
   farCLipPlaneWidth = nearClipPlaneWidth
   $$
   

   ![](图片\Shader\组件对正交视锥体的影响.png)

   <center>组件对正交视锥体的影响</center>

   由 Near、Far、FOV 和 Aspect 得到透视投影矩阵：
   $$
   M_{ortho} = 
   \left[
   \begin{matrix}
   \frac{1}{Aspect \cdot Size} & 0 & 0 & 0 \\
   0 & \frac{1}{Size} & 0 & 0 \\
   0 & 0 & -\frac{2}{Far - Near} & -\frac{Far + Near}{Far - Near} \\
   0 & 0 & 0 & 1
   \end{matrix}
   \right]
   $$

#### 屏幕空间

屏幕空间（screen space）：屏幕空间是一个二维空间。在完成了所有剪裁工作后，进行真正的投影，得到真正的像素位置。

顶点从裁剪空间转换到屏幕空间可分为两个步骤。

首先，进行标准齐次除法（homogenous division），也称透视除法（perspective division）。用齐次坐标系的 w 分量去除 x、y、z 分量。在 OpenGL 中，把这一步得到的坐标称为归一化的设备坐标（Normalized Device Coordinates，NDC）。经过透视投影变换后的裁剪空间，经过齐次除法后会变换到一个立方体内。在 OpenGL 中，立方体的 x、y、z 分量的范围都是 [-1，1]。在 DirectX 中，z 的分量范围是 [0，1]。Unity 使用的是 OpenGL。正交投影矩阵变换后的顶点分量 w 是 1，所以齐次除法不会对 x、y、z 坐标产生影响。经过齐次除法后，透视投影和正交投影的视锥体都会变换到一个相同的立方体内。我们可以根据变换后的 x 和 y 坐标来映射输出窗口的对应像素坐标。

然后，进行屏幕映射。Unity 中，屏幕空间左下角的像素坐标是（0，0），右上角的像素坐标是（pixelWidth，pixelHeght）。由于当前 x 和 y 坐标都是 [-1，1]，因此该映射过程就是一个缩放过程。
$$
screen_x = \frac{clip_x \cdot pixelWidth}{2 \cdot clip} + \frac{pixelWidth}{2} \\
screen_y = \frac{clip_y \cdot pixelHeight}{2 \cdot clip} + \frac{pixelHeight}{2}
$$
z 分量通常被用于深度缓冲。一个传统方式是把 $\frac{clip_z}{clip_w}$ 的值直接存进深度缓冲中，但这并不是必须的。通常驱动生产商会根据硬件来选择最好的存储格式。此时 $clip_w$ 也不会被抛弃，虽然它已经完成了在齐次除法中作为分母来得到 NDC，但它任然会在后续的工作中起到重要作用，例如：进行透视校正插值。

在 Unity 中，从裁剪空间到屏幕空间的转换是由底层帮我们完成的，我们的顶点着色器只需要把顶点转换到裁剪空间即可。

#### 顶点变换过程

模型空间（左手坐标系） -> 世界空间（左手坐标系） -> 观察空间（右手坐标系） -> 剪裁空间（左手坐标系） -> 屏幕空间（左手坐标系）

![](图片\Shader\顶点变换过程.png)

<center>渲染流水线中顶点的空间变换过程</center>

1. 顶点坐标从模型空间变换到世界空间中。该步变换通常 称为模型变换（model transform）。

也就是，prefab 内的子对象的坐标被转换为世界坐标，不再是相对根节点的位置。

![](图片\Shader\世界空间和模型空间位置.jpg)

![](图片\Shader\模型空间变换到世界空间.jpg)

根据 Transform 组件，可以得到牛牛进行了（2，2，2）的缩放，（0，150，0）的旋转和（5，0，25）的平移。

所以模型变换的变换矩阵是：
$$
\begin{aligned}
M_{model} &=
\left[
\begin{matrix}
1 & 0 & 0 & 5 \\
0 & 1 & 0 & 0 \\
0 & 0 & 1 & 25 \\
0 & 0 & 0 & 1
\end{matrix}
\right]
\left[
\begin{matrix}
cos150° & 0 & sin150° & 0 \\
0 & 1 & 0 & 0 \\
-sin150° & 0 & cos150° & 0 \\
0 & 0 & 0 & 1
\end{matrix}
\right]
\left[
\begin{matrix}
2 & 0 & 0 & 0 \\
0 & 2 & 0 & 0 \\
0 & 0 & 2 & 0 \\
0 & 0 & 0 & 1
\end{matrix}
\right]
\\
&= 
\left[
\begin{matrix}
-1.732 & 0 & 1 & 5 \\
0 & 2 & 0 & 0 \\
-1 & 0 & -1.732 & 25 \\
0 & 0 & 0 & 1
\end{matrix}
\right]
\end{aligned}
$$
对牛牛的鼻子进行模型变换：
$$
\begin{aligned}
P_{world} &= M_{model}P_{model} \\
&=
\left[
\begin{matrix}
-1.732 & 0 & 1 & 5 \\
0 & 2 & 0 & 0 \\
-1 & 0 & -1.732 & 25 \\
0 & 0 & 0 & 1
\end{matrix}
\right]
\left[
\begin{matrix}
0 \\
2 \\
4 \\
1
\end{matrix}
\right]
\\
&=
\left[
\begin{matrix}
9 \\
4 \\
18.072 \\
1
\end{matrix}
\right]
\end{aligned}
$$

2. 顶点坐标从世界空间变换到观察空间。该步通常被称为观察变换（view transform）。

   ![](图片\Shader\世界空间转换到观察空间.png)

   得到顶点在观察空间中的位置有两种方法。一种是计算观察空间的三个坐标轴在世界空间下的表示，然后构建出从观察空间变换到世界空间的变换矩阵，再对该矩阵求逆得到从世界空间变换到观察空间的变换矩阵。另一种方法是，想象平移整个观察空间，让摄像机原点位于世界坐标原点，坐标轴与世界空间中的坐标轴重合即可。

   第二种方法：

   由 Transform 组件可以知道，摄像机在世界空间中的变换是先按（30，0，0）进行旋转，然后按（0，10，-10）进行平移。那么，为了把摄像机重新移回到初始状态（摄像机原点位于世界坐标的原点、坐标轴与世界空间中的坐标轴重合），需要进行逆向变换，即先按（0，-10，10）平移，再按（-30，0，0）进行旋转，使坐标轴重合。所以变换矩阵是：
   $$
   \begin{aligned}
   M_{view} &= 
   \left[
   \begin{matrix}
   1 & 0 & 0 & 0 \\
   0 & cos(-30°) & -sin(-30°) & 0 \\
   0 & sin(-30°) & cos(-30°) & 0 \\
   0 & 0 & 0 & 1
   \end{matrix}
   \right]
   \left[
   \begin{matrix}
   1 & 0 & 0 & 0 \\
   0 & 1 & 0 & -10 \\
   0 & 0 & 1 & 10 \\
   0 & 0 & 0 & 1
   \end{matrix}
   \right]
   \\
   &=
   \left[
   \begin{matrix}
   1 & 0 & 0 & 0 \\
   0 & 0.866 & 0.5 & -3.66 \\
   0 & -0.5 & 0.866 & 13.66 \\
   0 & 0 & 0 & 1
   \end{matrix}
   \right]
   \end{aligned}
   $$
   由于观察空间是右手坐标系，所以需要对 z 轴分量进行取反操作。我们可以通过乘以另一个特殊的矩阵来的到最终的观察变换矩阵：
   $$
   \begin{aligned}
   M_{view} &= M_{negatez}M_{view} \\
   &= 
   \left[
   \begin{matrix}
   1 & 0 & 0 & 0 \\
   0 & 1 & 0 & 0 \\
   0 & 0 & -1 & 0 \\
   0 & 0 & 0 & 1
   \end{matrix}
   \right]
   \left[
   \begin{matrix}
   1 & 0 & 0 & 0 \\
   0 & 0.866 & 0.5 & -3.66 \\
   0 & -0.5 & 0.866 & 13.66 \\
   0 & 0 & 0 & 1
   \end{matrix}
   \right]
   \\
   &=
   \left[
   \begin{matrix}
   1 & 0 & 0 & 0 \\
   0 & 0.866 & 0.5 & -3.66 \\
   0 & 0.5 & -0.866 & -13.66 \\
   0 & 0 & 0 & 1
   \end{matrix}
   \right]
   \end{aligned}
   $$
   现在可以对牛牛的鼻子进行观察空间变换：
   $$
   \begin{aligned}
   P_{view} &= M_{negatez}M_{view} \\
   &=
   \left[
   \begin{matrix}
   1 & 0 & 0 & 0 \\
   0 & 0.866 & 0.5 & -3.66 \\
   0 & 0.5 & -0.866 & -13.66 \\
   0 & 0 & 0 & 1
   \end{matrix}
   \right]
   \left[
   \begin{matrix}
   9 \\
   4 \\
   18.072 \\
   1
   \end{matrix}
   \right]
   \\
   &=
   \left[
   \begin{matrix}
   9 \\
   8.84 \\
   -27.31 \\
   1
   \end{matrix}
   \right]
   \end{aligned}
   $$
   
3. 观察空间转换到裁剪空间，使用投影矩阵进行变换：

   1. 透视投影
   
      透视投影矩阵为（针对的是观察空间，右手坐标系），变换后 z 分量范围将在 [-w，w] 之间：
      $$
      M_{frustum} = 
      \left[
      \begin{matrix}
      \frac{cot{\frac{FOV}{2}}}{Aspect} & 0 & 0 & 0 \\
      0 & cot{\frac{FOV}{2}} & 0 & 0 \\
      0 & 0 & -\frac{Far + Near}{Far - Near} & -\frac{2 \cdot Near \cdot Far}{Far - Near} \\
      0 & 0 & -1 & 0
      \end{matrix}
      \right]
      $$
      顶点与透视投影矩阵相乘：
      $$
      \begin{aligned}
      P_{clip} &= M_{frustum}P_{view} \\
      &=
      \left[
      \begin{matrix}
      \frac{cot{\frac{FOV}{2}}}{Aspect} & 0 & 0 & 0 \\
      0 & cot{\frac{FOV}{2}} & 0 & 0 \\
      0 & 0 & -\frac{Far + Near}{Far - Near} & -\frac{2 \cdot Near \cdot Far}{Far - Near} \\
      0 & 0 & -1 & 0
      \end{matrix}
      \right]
      \left[
      \begin{matrix}
      x \\
      y \\
      z \\
      1
      \end{matrix}
      \right]
      \\
      &=
      \left[
      \begin{matrix}
      x\frac{cot\frac{FOV}{2}}{Aspect} \\
      ycot\frac{FOV}{2}
      -z\frac{Far + Near}{Far - Near} - \frac{2 \cdot Far \cdot Near}{Far - Near} \\
      -z
      \end{matrix}
      \right]
      \end{aligned}
      $$
      由此可以看出投影矩阵的本质是对 x、y 和 z分量进行了不同程度的缩放，z 分量还做了一个平移。
   
      判断变换后的顶点坐标是否在视锥体内：
      $$
      -w \leq x \leq w \\
      -w \leq y \leq w \\
      -w \leq z \leq w
      $$
      ![](图片\Shader\顶点通过透视投影矩阵变换.png)
      
      <center>顶点通过透视投影矩阵变换</center>
      由上图可得，裁剪矩阵会改变空间得旋向性，空间从右手坐标系变换到了左手坐标系。离摄像机越远，z 值越大。
      
   2. 正交投影
   
      正交投影矩阵为：
      $$
      \left[
      \begin{matrix}
      \frac{1}{Aspect \cdot Size} & 0 & 0 & 0 \\
      0 & \frac{1}{Size} & 0 & 0 \\
      0 & 0 & -\frac{2}{Far - Near} & -\frac{Far + Near}{Far - Near} \\
      0 & 0 & 0 & 1
      \end{matrix}
      \right]
      $$
      顶点与正交投影矩阵相乘：
      $$
      \begin{aligned}
      P_{clip} &= M_{ortho}P_{view} \\
      &=
      \left[
      \begin{matrix}
      \frac{1}{Aspect \cdot Size} & 0 & 0 & 0 \\
      0 & \frac{1}{Size} & 0 & 0 \\
      0 & 0 & -\frac{2}{Far - Near} & -\frac{Far + Near}{Far - Near} \\
      0 & 0 & 0 & 1
      \end{matrix}
      \right]
      \left[
      \begin{matrix}
      x \\
      y \\
      z \\
      1
      \end{matrix}
      \right]
      \\
      &=
      \left[
      \begin{matrix}
      \frac{x}{Aspect \cdot Size} \\
      \frac{y}{Size} \\
      -\frac{2z}{Far - Near} - \frac{Far + Near}{Far - Near} \\
      1
      \end{matrix}
      \right]
      \end{aligned}
      $$
      判断变换后的顶点坐标是否在视锥体内方法同透视投影。
      
      
      
      ![](图片\Shader\顶点通过正交投影矩阵变换.png)
      
      由上图可得，裁剪矩阵会改变空间得旋向性，空间从右手坐标系变换到了左手坐标系。离摄像机越远，z 值越大。
      
      ![](图片\Shader\农场游戏的摄像机参数和横纵比.png)
      
      据图可知透视投影参数：FOV 为 60°，Near 为 5，Far 为 40，Aspect 为 4：3。所以，投影矩阵为：
      $$
      \begin{aligned}
      M_{frustum} &= 
      \left[
      \begin{matrix}
      \frac{cot{\frac{FOV}{2}}}{Aspect} & 0 & 0 & 0 \\
      0 & cot{\frac{FOV}{2}} & 0 & 0 \\
      0 & 0 & -\frac{Far + Near}{Far - Near} & -\frac{2 \cdot Near \cdot Far}{Far - Near} \\
      0 & 0 & -1 & 0
      \end{matrix}
      \right]
      \\
      &=
      \left[
      \begin{matrix}
      1.299 & 0 & 0 & 0 \\
      0 & 1.732 & 0 & 0 \\
      0 & 0 & 01.286 & -11.429 \\
      0 & 0 & -1 & 0
      \end{matrix}
      \right]
      \end{aligned}
      $$
      则牛牛的鼻子从观察空间转换到剪裁空间为：
      $$
      \begin{aligned}
      P_{clip} &= M_{frustum}P_{view} \\
      &=
      \left[
      \begin{matrix}
      1.299 & 0 & 0 & 0 \\
      0 & 1.732 & 0 & 0 \\
      0 & 0 & 01.286 & -11.429 \\
      0 & 0 & -1 & 0
      \end{matrix}
      \right]
      \left[
      \begin{matrix}
      9 \\
      8.84 \\
      -27.31 \\
      1
      \end{matrix}
      \right]
      \\
      &=
      \left[
      \begin{matrix}
      11.691 \\
      15.311 \\
      23.692 \\
      27.31
      \end{matrix}
      \right]
      \end{aligned}
      $$
      判断牛牛的鼻子是否在视锥体内：
      $$
      -27.31 \leq 11.691 \leq 27.31 \\
      -27.31 \leq 15.311 \leq 27.31 \\
      -27.31 \leq 23.692 \leq 27.31
      $$
      即牛牛的鼻子位于视锥体内不需要被裁剪。
   
4. 从剪裁空间到屏幕空间

   假设当前屏幕的像素坐标为 400，高度为 300。首先，我们需要进行齐次除法，把裁剪空间的坐标投影到 NDC 中，然后映射到屏幕空间中。
   $$
   \begin{aligned}
   screen_x &= \frac{clip_x \cdot pixelWidth}{2 \cdot clip_w} + \frac{pixelWidth}{2} \\
   &= \frac{11.691 \cdot 400}{2 \cdot 27.31} + \frac{400}{2} \\
   &= 285.617 \\
   screen_y &= \frac{clip_y \cdot pixelHeight}{2 \cdot clip_w} + \frac{pixelHeight}{2} \\
   &= \frac{15.311 \cdot 300}{2 \cdot 27.31} + \frac{300}{2} \\
   &= 234.096
   \end{aligned}
   $$
   所以，牛牛的鼻子子在屏幕空间上的位置是（285.617，234.096）。

### 法线变换

法线（normal）：又被称为法矢量（normal vector）。法线是一种需要特殊处理的法矢量。当我们变换一个模型时，不仅需要变换顶点，还要变换顶点法线，一般用于后续处理（如片元着色器）中光照的计算等。

切线（tangent）：又被称为切矢量（tangentvector）。它通常与纹理空间对齐，且与法线方向垂直。

在变换法线时，不能使用与变换顶点的变换矩阵相同的变换矩阵，因为这样可能无法保持法线的垂直性。由于切线时是两个顶点之间的差值计算得到的，所以我们可以直接使用用于变换顶点的变换矩阵来变换切线。

使用的变换矩阵 M 是 $3 \times 3$ 的矩阵，因为法线和切线都是方向向量不受平移影响，变换公式：
$$
T_B = M_{A \rightarrow B}T_A
$$
$T_A$ 和 $T_B$ 分别表示坐标空间 A 和坐标空间 B 下的切线方向。假设法线为 $N_A$。

已知：$T_A \cdot N_A$ = 0。此时我们需要找到一个法线变换矩阵 G，使得法线变换后仍与变换后的切线垂直。
$$
T_B \cdot N_B = (M_{A \rightarrow B}T_A) \cdot (G_{A \rightarrow B}N_A) = 0
$$
由于 $T_A \cdot N_A = 0$ ，所以假设 $M_{A \rightarrow B}^TG_{A \rightarrow B} = I$ ，即 $G_{A \rightarrow B} = {M_{A \rightarrow B}^T}^{-1} = {M_{A \rightarrow B}^{-1}}^T$ ，使用原变换矩阵的逆转置矩阵来变换法线就可以得到正确结果：
$$
\begin{aligned}
(M_{A \rightarrow B}T_A) \cdot (G_{A \rightarrow B}N_A) &= (M_{A \rightarrow B}T_A)^T \cdot (G_{A \rightarrow B}N_A) \\
&= T_A^TM_{A \rightarrow B}^TG_{A \rightarrow B}N_A \\
&= T_A^T(M_{A \rightarrow B}^TG_{A \rightarrow B})N_A \\
\end{aligned}
$$
如果 $M_{A \rightarrow B}$ 是正交矩阵，那么 $M_{A \rightarrow B}^{-1} = M_{A \rightarrow B}^T$ ，所以 $(M_{A \rightarrow B}^{T})^{-1} = M_{A \rightarrow B}$ ，可以使用用于变换顶点的变换矩阵来直接变换法线。如果变换只包括旋转变换，那么这个变换矩阵就是正交矩阵。如果变换只包括旋转和统一缩放，而不包含非统一变换，那么必须要求解逆矩阵来得到变换法线的矩阵。

<font color = grass>这一块没有看懂。</font>

# 基础知识

## 渲染流水线

由CPU流水线和GPU流水线共同构成

### 用自己的话概括

渲染流水线分 3 个阶段：应用阶段 -> 几何阶段 -> 光栅化阶段。

<img src="图片\Shader\渲染流水线总结.jpg" style="zoom:150%;" />

### CPU流水线

1. 把数据加载到内存

   将数据从硬盘（HDD）中加载到系统内存（RAM）中。然后，将网格和纹理等数据加载到显存（VRAM）中。这是因为显卡对显存的访问速度更快。同时，硬盘加载到内存的过程十分耗时，所以一些 CPU 可以访问的网格数据尽量不要移除。

2. 设置渲染状态

   渲染状态：定义了场景中网格是如何被渲染的。例如：使用哪个顶点着色器（Vertex Shader）/片元着色器（Fragment Shader）、光源属性、材质等。

   网格：可以看成形状不同的容器。

   纹理：可以看成物体表面的花纹。

   Draw Call：是一个 CPU 告诉 GPU 一切就绪的渲染命令。

3. 调用 Draw Call

   Draw Call 这个命令仅仅指向一个需要被渲染的图元（primitives）列表，不包含任何材质信息。因为，上一流程——设置渲染状态 已经给容器添上花纹了。这个流程就是通过 Draw Call 告诉 GPU 可以开始渲染了，并且 Draw Call 会执行本次需要调用渲染的图元列表。

### GPU流水线<font color=grass>（学习完顶点着色器、几何着色器、片元着色器再回来看看）</font>

GPU 接收到 Draw Call 命令后，进行的一系列流水线操作，最终把图元渲染到屏幕上。

GPU 流水线分为 几何阶段 和 光栅化阶段。

GPU 流水线中有一些流程是不可配置和编程的。

![](图片\Shader\GPU 流水线流程.png)

<center>绿色表示该阶段流水线阶段是完全可编程控制的；黄色表示该流水线阶段可以配置但不可编程的；蓝色表示该流水线阶段是由 GPU 固定实现的，开发者没有任何控制权。实现表示该 Shader 必须由开发者实现，虚线表示该 Shader 是可选的</center>

#### 流程

​		顶点数据 -> 几何阶段 -> 光栅化阶段 -> 屏幕图像

#### 概念

顶点数据是 GPU 流水线的输入，这些顶点数据是在 CPU 流水线的第一步加载到显存中，在由 Draw Call 指定，然后传递给顶点着色器。

顶点着色器（Vertex Shader）：用于实现顶点的空间变换、顶点着色等功能。

曲面细分着色器（Tessellation Shader）：用于细分图元。

几何着色器（Geometry Shader）：用于执行逐图元（Per-Primitive）的着色操作 或 用于产生更多的图元。

裁剪（Clipping）：将那些不在摄像机视野内的顶点裁剪掉，并提出某些三角图元的面片。

屏幕映射（Screen Mapping）：把每个图元的坐标转换到屏幕坐标系中。

三角形设置（Triangle Setup）和 三角形遍历（Triangle Traversal）阶段都是固定函数（Fixed Function）的阶段。

片元着色器（Fragment Shader）：用于实现逐片元（Per-Fragment）的着色操作。

逐片元操作（Per-Fragment Operations）：执行喝多重要的操作，例如修改颜色、深度缓冲、进行混合等。

#### 几何阶段

主要是对顶点进行位置变换、着色操作。

流程：

​		顶点着色器 -> 曲面细分着色器 -> 几何着色器 -> 裁剪 -> 屏幕映射

##### 顶点着色器

输入进来的每个顶点都会调用一次顶点着色器。顶点着色器本身不可以创建或这销毁任何顶点，且无法得到顶点与顶点之间的关系。也就是说，无法直到两个顶点是否属于同一个三角网格。

流程：

--> 为非必须流程

​		顶点输入 -> 顶点坐标变换 --> 计算顶点颜色 --> 输出后续阶段所需数据

顶点坐标变换：是一个必须进行的过程。其必须完成的工作是把顶点坐标从模型空间转换到齐次裁剪空间。例如下面代码：

```
o.pos = mul(UNITY_MVP, v.position)
```

该代码的功能是把顶点坐标转换到齐次裁剪坐标系下，然后通过硬件做透视除法后，得到归一化的设备坐标（Nomalized Device Coordinates，NDC）。NDC 的 z 分两范围在 [-1, 1]。

顶点着色器可以有不同的输出方式。经过光栅化后交给片元着色器 或者 把数据发送给曲面细分着色器 或者 几何着色器。

##### 裁剪

一个图元和摄像机视野的关系有 3 种：完全在视野内、部分在是视野内、完全在视野外。完全在视野内的图元就继续传递给下一个流水线阶段，完全在视野外的图元不会继续向下传递，而部分在视野内的图元需要进行一下处理。例如，一条线段的一个顶点在不在视野内，那么这个顶点应该用新顶点来代替，这个新顶点位于这条线段和视野边界交点。

##### 屏幕映射

把每个图元的 x 和 y 坐标转换到屏幕坐标系（Screen Coordinates）下。屏幕坐标系是一个二维坐标系，它和我们用于显示画面的分辨率有很大关系。这是一个缩放的过程。屏幕坐标系 和 z 坐标构成了窗口坐标系（Window Coordinates），这些值会一起被传递到光栅化阶段。

屏幕映射得到的屏幕坐标决定了顶点对应屏幕上哪个像素以及距离这个像素有多远。

OpenGL把屏幕的左下角做为最小的窗口坐标值。

#### 光栅化阶段

该阶段的两个重要目标：计算每个图元覆盖了哪些像素，以及为这些像素计算它们的颜色。

从上一阶段输出的信息是屏幕坐标系下的顶点位置和相关的额外信息，如深度（z坐标）、法线方向、视角方向等。

##### 三角形设置

三角形设置（Triangle Setup）：通过上一阶段传入的三角形顶点信息计算三角网格表示的数据。

##### 三角形遍历

三角形遍历（Triangle Traversal）：检查每个像素是否被一个三角网格所覆盖。如果被覆盖，生成一个片元（fragment）。这个阶段也称扫描变换（Scan Conversion）。

片元不是像素，而是包含了很多状态的集合。包括：屏幕坐标、深度信息、法线、纹理坐标等。这些数据可以用于计算像素的最终颜色。

##### 片元着色器

片元着色器（Fragment Shader）：纹理采样。通过三角网格的三个顶点对应的纹理坐标进行插值，得到其覆盖片元的纹理坐标。片元之间是独立的，片元无法得到它相邻片元的片元信息。<font color = skyblue>有一个例外情况是可以访问到导数信息。</font>

该步骤是数据处理，对像素着色是在逐片元操作实现。

##### 逐片元操作

逐片元操作（Per-Fragment Operations）：主要目的是合并。

下面的测试顺序并不是唯一的。因为，如果 GPU 在片元着色器阶段花了很大力气终于计算出片元颜色后，却发现这个片元根本通不过测试，被舍弃了，这会造成很大的性能浪费。

Unity 中，深度测试是在片元着色器之前，将深度测试提前执行的技术称为 Early-Z技术。

但是，如果将有些测试提前的话，其检测结果可能会与片元着色器的一些操作冲突。例如，如果我们在片元着色器进行了透明度测试，而这个片元没有通过透明度测试，我们会在着色器中调用 API（例如 clip 函数）来手动将其舍掉。这会导致 GPU 无法提前执行各种测试。因此，现代 GPU 会判断片元着色器中的操作是否和提前测试发生冲突，如果有冲突，就会禁用提前测试。这会导致更多的片元需要被处理，也就是透明度测试会导致性能下降的原因。<font color = grass>没有看懂。</font>

流程：

​		片元 -> 模板测试 -> 深度测试 -> 混合 -> 颜色缓冲区

主要任务：

1. 决定每个片元的可见性。进行深度测试、模板测试等。
2. 如果一个片元通过了测试，就把这个片元的颜色值和已经存储在颜色缓冲区中的颜色进行合并。如果过该片元没有通过测试，就会被舍弃掉（Poor fragment）。

模板测试与深度测试流程：

![](图片\Shader\模板测试和深度测试流程图.jpg)



###### 模板测试

模板测试（Stencil Test）：开启模板测试后，GPU会首先读取（使用读取掩码）模板缓冲区中该片元位置的模板值，然后将该值和读取（使用读取掩码）到的参考值进行比较，这个比较函数可以由开发者指定，例如小于时舍弃该片元，只要没有通过测试的片元都会被舍弃。无论片元是否被舍弃，我们都可以根据模板测试和深度测试结果来修改模板缓冲区，该修改也时可以由开发者指定的。开发者可以设置不同结果下的修改操作，如失败是模板缓冲区保持不变。

模板测试通常用于限制渲染区域，还有一些更高级的用法，如渲染阴影、轮廓渲染等。

###### 深度测试

深度测试（Depth Test）：开启深度测试后，GPU会把该片元的深度值和已经存在与深度缓冲区中的深度值进行比较。这个比较函数也可以由开发者设置，一般设置为小于等于关系，因为我们总想显示出里摄像机最近的物体，而那些被其他物体遮挡住的不需要出现在屏幕上。<font color=skyblue>与模板测试不同的是，如果一个片元没有通过深度测试，它就没有权力更改深度缓冲区中的值；如果通过测试，开发者可以指定是否要用这个片元的深度值覆盖掉原有的深度值，这是通过开启/关闭深度写入来做到的。</font>

透明效果与深度测试和深度写入关系密切。

###### 混合

首先，我们需要知道：每个像素的颜色信息会被存储在一个名为颜色缓冲池的地方。当我们执行渲染（即一个物体接着一个物体画到屏幕上时），颜色缓冲池种往往已经有上次渲染后的颜色结果。那么，时覆盖上次的结果还是对上次结果进行处理是合并需要解决的问题。

对于不透明物体，开发者可以关闭混合（Blend）操作。这样，片元着色器计算得到的颜色值就会直接覆盖掉颜色缓冲区种的像素值。对于半透明物体，我们需要使用混合操作来使这个物体看起来透明。

混合与 Photoshop 种对图层的操作很像：每一层图层可以选择混合模式，混合模式决定了该图层和下层图层的混合结果，而我们看到的图片就是混合后的图片。通常是根据透明通道的值进行相加、相减、相乘等。

混合流程：

![](图片\Shader\混合流程图.jpg)

混合结束后，就会显示到我们的屏幕上。屏幕上显示的就是颜色缓冲区中的颜色值。但是为了避免我们看到那些正在进行光栅化的图元，GPU 会使用双缓冲（Double Buffering）的策略。也就是，对场景的渲染是在幕后发生的，即后置缓冲（Back Buffer）中。一旦场景已经被渲染到后置缓冲中，GPU 就会交换后置缓冲区和前置缓冲区中的内容。由此，保证了我们看到的图像总是连续的。

双缓冲解说：https://www.bilibili.com/video/BV1FK4y1x7bk

## Unity 中屏幕坐标：ComputeScreenPos / VPos / WPos

在顶点 / 片元着色器中，有两种方式来获得片元的屏幕坐标。一种是在片元着色器的输入中声明 VPOS 或 WPOS 语义。另一种是通过 Unity 提供的 ComputeScreenPos 函数。

VPOS 是 HLSL 中对屏幕坐标的语义，而 WPOS 是 Cg 中对屏幕坐标的语义。两者在 Unity Shader 中式等价的。我们可以在 HLSL / Cg 中通过语义的方式来定义顶点 / 片元着色器的默认输入，而不需要自己定义输入输出的数据结构，如下。

```
fixed4 frag(float4 sp:VPOS): SV_Target{
	// 用屏幕坐标除以屏幕分辨率 _ScreenParams.xy，得到视口空间中的坐标
	return fixed4(sp.xy/_ScreenParams.xy, 0.0, 1.0);
}
```

效果：

![](图片\Shader\由片元的像素位置得到的图像.png)

VPOS / WPOS 语义定义的输入是一个 float4 类型的变量。如果屏幕分辨率为 $400 \times 300$ ，那么 x 的范围是 [0.5, 400.5]，y 的范围是 [0.5, 300.5]。在 Unity 中，VPOS / WPOS 的 z 分量范围是 [0, 1]，在摄像机的近裁剪平面处，z 值为 0，在远裁剪平面处，z 值为 1。对于 w 分量，我们需要考虑摄像机的投影类型。如果过使用的是透视投影，那么 w 的分量范围是 $[\frac{1}{Near}, \frac{1}{Far}]$，Near 和 Far 对应了在 Carmera 组件中设置的近裁剪平面和远裁剪平面距离摄像机的远近；如果使用的是正交投影，那么 w 分量值恒为 1。这些值是通过对经过投影矩阵变换后的 w 分量取倒数后得到的。代码最后，通过把屏幕空间除以屏幕分辨率来得到视口空间（viewport space）中的坐标。视口坐标，就是把屏幕坐标归一化，这样屏幕左下角就是（0，0），右上角是（1，1）。如果已知屏幕坐标，只需要把 xy 值除以屏幕分辨率即可。

ComputeScreenPos 函数在 UnityCG.cginc 里被定义。通常用法需要两个步骤，首先在顶点着色器中将 ComputeScreenPos 的结果保存在输出结构体中，然后在片元着色器中进行一个齐次除法运算后得到视口空间下坐标。

例如：

```
struct vertOut {
	float4 pos: SV_POSITION;
	float4 scrPos: TEXCOORD0;
};

vertOut vert(appdata_base v) {
	vertOut o;
	o.pos = mul(UNITY_MATRIX_MVP,v.vertex);
	// 第一步：把 ComputeScreenPos 的结果保存到 scrPos 中
	o.scrPos = ComputeScreenPos(o.pos);
	return o;
}

fixed4 frag(vertOut i): SV_Target {
	// 第二步：用 scrPos.xy 除以 scrPos.w 得到视口空间中的坐标
	float2 wcoord = (i,scrPos.xy / i.scrPos.w);
	return fixed4(wcoord,0.0,1.0);
}
```

上面代码实现效果与使用 VPos / WPos 一样。这个方法手动实现了屏幕映射的过程，而且它得到的坐标直接就是视口空间中的坐标。得到视口空间的坐标公式：
$$
viewport_x = \frac{clip_x}{2 \cdot clip_w} + \frac{1}{2} \\
viewport_y = \frac{clip_y}{2 \cdot clip_w} + \frac{1}{2}
$$
上面公式的思想：对裁剪空间下的坐标进行齐次除法，得到范围在[-1, 1] 的 NDC，然后再将其映射到范围在 [0, 1] 的视口空间下的坐标。ComputeScreenPos 函数的定义：

```
inline float4 ComputeScreenPos(float4 pos) {
	float4 o = pos * 0.5f;
	#if defined(UNITY_HALF_TEXEL_OFFSET)
	o.xy = float2(o.x,o.y * _ProjectionParams.x) + o.w * _ScreenParams.zw;
	#else
	o.xy = float2(o.x,o.y * _ProjectionParams.x) + o.w;
	#endif
	o.zw = pos.zw
	return o;
}
```

ComputeScreenPos 的输入参数 pos 是经过 MVP 矩阵变换后在裁剪空间中的顶点坐标。UNITY_HALF_TEXEL_OFFSET 是 Unity 在某些 DirectX 平台上使用的宏，在这里可以忽略它。只需关注 #else 部分。_ProjectionParams.x 在默认情况下是 1，如果我们使用了一个翻转的投影矩阵话就是 -1。上述代码的过程实际输出：
$$
Output_x = \frac{clip_x}{2} + \frac{clip_w}{2} \\
Output_y = \frac{clip_y}{2} + \frac{clip_w}{2} \\
Output_z = clip_z \\
Output_w = clip_w
$$
这里的 xy 不是真正的视口空间下的坐标。所以，需要对片元着色器进行进一步的处理，除以裁剪坐标的 w 分量。为什么 Unity 不直接在 ComputeScreenPos 中进行除以 w 分量这个步骤呢？因为从顶点着色器到片元着色器的过程会有一个插值过程，如果在顶点着色器中那么做的话会破坏插值结果。如果不在顶点着色器中进行这个除法，保留 x、y 和 w 分量，在插值后进行除法，得到的 $\frac{x}{w}$ 和 $\frac{y}{w}$ 就是正确的。我们不可以在投影空间中进行插值，因为着不是一个线性空间，而插值往往是线性的。

对于 zw 的值，在顶点着色器中直接把裁剪空间的 zw 值存进了输出结构体中，所以片元着色器的输入就是这些插值后的裁剪空间中的 zw 值。即，如果是透视摄像机，那么 z 的值范围是 [-Near, Far]，w 的值范围是 [Near, Far]；如果是正交摄像机，那么 z 的值范围是 [-1, 1]，而 w 值恒为 1。

## Unity shader 使用

Unity shader 需要与材质（Material）配合来使用。Unity 材质需要结合 GameObject 的 Mesh 或 Particle Systems 组件来工作。Unity Shader 定义了渲染所需的各种代码（如顶点着色器 和 片元着色器）、属性（如使用哪些纹理等）和指令（渲染和标签设置等），而材质这允许我们调节这些属性，并将其赋给相应的模型。

Unity shader 使用 ShaderLab 来编写。

步骤：

1. 创建一个材质
2. 创建一个 Unity Shader，并把它赋给上一步创建的材质
3. 把材质赋给需要渲染的对象
4. 在材质面板中调整 Unity Shader 的属性，以得到满意的效果

## Unity 内置 Shader

- Standard Surface Shader：会产生一个包含了标准光照模型的<font color = skyblue>表面着色器模板</font>，提供了典型的表面着色器。

- Unlit Shader：会产生一个不包含光照（但包含雾效）的基本的 <font color = skyblue>顶点 / 片元着色器</font>。

- Image Effect Shader：实现各种屏幕后处理效果，提供了一个基本模板。

- Compute Shader：会产生一种特殊的 Shader 文件，这类 Shader 旨在利用 GPU 的并行性来进行一些与常规渲染流水线无关的计算。

  更多介绍：https://docs.unity3d.com/Manual/class-ComputeShader.html

## Inspector 面板

Unity Shader 本质上就是一个文本文件，也有导入设置。

<img src="图片\Shader\Unity Shader 的 Inspector 面板.jpg" style="zoom: 80%;" />

### Default Maps

指定该 Unity Shader使用的默认纹理，当任何材质第一次使用该 Unity Shader 时，这些纹理就会自动被赋予到相应的属性上。

### Surface Shader

是否是一个表面着色器。

Show generated code：打开一个新的文件，在这个文件里将显示 Unity 在背后为该 <font color=skyblue>表面着色器</font> 生成的顶点/片元着色器。这可以方便我们对这些生成的代码进行修改和保存，但需要复制到一个新的 Unity Shader 中才可保存。

### Fixed function

是否是一个固定函数着色器。

Show generated code：打开一个新的文件，在这个文件里将显示 Unity 在背后为该 <font color=skyblue>固定函数着色器</font> 生成的顶点/片元着色器。这可以方便我们对这些生成的代码进行修改和保存，但需要复制到一个新的 Unity Shader 中才可保存。

### Compiled code

可以检查 Unity Shader 针对不同图像编程接口（例如 OpenGL、D3D9、D3D11等）最终编译成的 Shader 代码。直接单击该按钮可以查看生成的底层的汇编指令。我们可以利用这些代码来分析和优化着色器。

### Render queue

使用的渲染队列

### Disable batching

是否关闭批处理

### Properties

属性列表

# ShaderLab 语法

<font color = grass>这是没有 Unity 编辑器的情况下的流水线伪代码。</font>

```
// 初始化渲染设置
void Initialization() {
　　// 从硬盘上加载顶点着色器的代码
　　string vertexShaderCode = LoadShaderFromFile(VertexShader.shader);
　　// 从硬盘上加载片元着色器的代码
　　string fragmentShaderCode = LoadShaderFromFile(FragmentShader.shader);
　　// 把顶点着色器加载到GPU中
　　LoadVertexShaderFromString(vertexShaderCode);
　　// 把片元着色器加载到GPU中
　　LoadFragmentShaderFromString(fragmentShaderCode);
　　// 设置名为"vertexPosition"的属性的输入，即模型顶点坐标
　　SetVertexShaderProperty("vertexPosition"，vertices);
　　// 设置名为"MainTex"的属性的输入，someTexture是某张已加载的纹理
　　SetVertexShaderProperty("MainTex"，someTexture);
　　// 设置名为"MVP"的属性的输入，MVP是之前由开发者计算好的变换矩阵
　　SetVertexShaderProperty("MVP"，MVP);
　　// 关闭混合
　　Disable(Blend);
　　// 设置深度测试
　　Enable(ZText);
　　SetZTestFunction(LessOrEqual);
　　// 其他设置
　　…
}
// 每一帧进行渲染
void OnRendering() {
　　// 调用渲染命令
　　DrawCall();
　　// 当涉及多种渲染设置时，我们可能还需要在这里改变各种渲染设置
　　……
}
VertexShader.shader：
// 输入：顶点位置、纹理、MVP变换矩阵
in float3 vertexPosition;
in sampler2D MainTex;
in Matrix4x4 MVP;
// 输出：顶点经过MVP变换后的位置
out float4 position;
void main() {
　　// 使用MVP对模型顶点坐标进行变换
　　position = MVP * vertexPosition;
}
FragmentShader.shader：
// 输入：VertexShader输出的position、经过光栅化程序插值后的该片元对应的position
in float4 position;
// 输出：该片元的颜色值
out float4 fragColor;
void main() {
　　// 将片元颜色设为白色
　　fragColor = float4(1.0，1.0，1.0，1.0);
}
```

## 结构

```
// 与 Shader 的文件名无关，是对 Shader 的分类
Shader "MyShader/LearningShader1"
{
    // 定义了着色器所需的各种属性
    // 非必须的，主要是属性在 Unity 材质的 Inspector 面板中可视化，暴露出来方便调整
    Properties{
        // 属性名("Unity Inspector 面板中显示的属性名",属性类型) = 值
        // 当 Unity Inspector 面板中的值改变过后，将以 Unity Inspector 面板中的值为准
        // 属性与属性之间通过换行区分
        // 属性名通常以下划线开始
        _Color("Color",Color) = (1,1,1,1)
    }
    
    // 一个 Shader 文件中可以有多个 SubShader，但至少有一个。
    // 多个 SubShader 用于适配不同的显卡，一些旧的显卡仅能支持一定数目的操作指令，当我们希望在旧的显卡上使用计算复杂度较低的着色器时，就可以再写一个 SubShader
    // 当显卡不适配第一个 SubShader 时，会自动选择第二个 SubShader，如果还不适配时，会继续选择下一个 SubShader，以此类推
    // 必须的
    SubShader{
    
        // 用于告诉 Unity 渲染引擎：如何以及何时渲染当前对象
        // 全局的，会用于所有 Pass 块
        // 非必须的
        Tags{
        	// "标签类型" = "标签值"
        }
        
        // 渲染状态，设置显卡的各种状态
        // 全局的，会用于所有 Pass 块
        // 非必须的
        
        // 一个 SubShader 中可以有许多的 Pass 块，但必须有一个 Pass 块
        // 每个 Pass 块定义了一次完整的渲染流程，如果 Pass 的数目过多，会造成渲染性能下降，因此应尽量使用最小数目的 Pass 块
        // 一个 Pass 块相当于一个方法
        Pass{
            // 该 Pass 块的名称
            // 通过这个名称，可以使用 ShaderLab 的 UsePass 命令来直接调用其他 Unity Shader 中的 Pass 块，可以提高代码的复用性
            // Unity 中会把所有 Pass 的名称转换成大写字母表示，所以在使用 UsePass 命令时必须将 Pass 的名称转换成大写形式
            Name "MyPassName"
            
            // Pass块中可以使用 CG 语言编写 Shader 代码
            // 当需要使用 Properties 中的属性时，需要重新定义一下，但 Properties 中的属性的值会传过来
            // 新定义的属性名需与 Properties 的属性名一样
            // 同时注意 Properties 中支持的类型，在 SubShader 中不一定支持，因此需要改变一下
            // 如 Color 要变成 float4
            CGPROGRAM           
            float4 _Color;
            
            // pragma vertex 顶点函数申明，函数名 vert 可以自定义
            #pragma vertex vert
            
            // pragma fragment 片元函数申明，函数名 frag 可以自定义
            #pragma fragment frag
            
            // 返回值 vert(形式参数)
            // float4 vector4 : POSITION 意思是将 POSITION 赋值给 vector4
            // float4 vert() : SV_POSITION 意思是 vert 函数的返回值将赋值给 SV_POSITION
            float4 vert(float4 vector4 : POSITION) : SV_POSITION {
            }
            
            ENDCG
        }
    }
    
    // 当以上所有 SubShader 都不支持时，会使用 Fallback 调用已经存在的 Shader
    // 也可以任性地关闭 Fallback 功能，Fallback Off
    // Fallback 在渲染阴影纹理时，会影响阴影的投射
    // 非必须的
    Fallback "vertexLit"
}
```

更多参考：https://docs.unity3d.com/2020.2/Documentation/Manual/SL-CustomShaderGUI.html

### SubShader

#### 标签 Tags

以下标签仅能用于 SubShader 中声明，不可用于 Pass 块中声明。

| 标签类型             | 说明                                                         | 例子                                   |
| -------------------- | ------------------------------------------------------------ | -------------------------------------- |
| Queue                | 控制渲染顺序，指定该物体属于哪一个渲染队列，通过这种方式可以保证所有的透明物体可以在所有不透明物体后面被渲染，也可以自定义使用的渲染队列来控制物体的渲染顺序 | Tags {"Queue" = "Transparent"}         |
| RenderType           | 对着色器进行分类，例如这是一个不透明的着色器，或是一个透明的着色器等。这可以被用于着色器替换（Shader Replacement）功能 | Tags {"RenderType" = "Opaque"}         |
| DisableBatching      | 一些 SubShader 在使用 Unity 的批处理功能时会出现问题，例如使用了模型空间下的坐标进行顶点动画。这时可以通过标签来直接指明是否对该 SubShader 使用处理 | Tags {"DisableBatching" = "True"}      |
| ForceNoShadowCasting | 控制使用该 SubShader 的物体受否会投射阴影                    | Tags {"ForceNoShadowCasting" = "True"} |
| IgnoreProjector      | 如果该标签值为 "Ture"，那么使用该 SubShader 的物体将不会受到 Projector 的影响。通常用于半透明物体 | Tags {"IgnoreProjector" = "True"}      |
| CanUseSpriteAtlas    | 当该 SubShader 是用于精灵（Sprite）时，将该标签设置为 "False" | Tags {"CanUseSpriteAtlas" = "False"}   |
| PreviewType          | 指明材质面板将如何预览该材质。默认情况下，材质将显示为一个球形，通过把该标签的值设为 "Plane" "SkyBox" 来改变预览类型 | Tags {"PreviewType" = "Plane"}         |

以下标签用于 Pass 块

| 标签类型       | 说明                                                         | 例子                                       |
| -------------- | ------------------------------------------------------------ | ------------------------------------------ |
| LightMode      | 定义该 Pass 在 Unity 的渲染流水线中的角色                    | Tags {"LightMode" = "ForwardBase"}         |
| RequireOptions | 用于指定当满足某些条件时才渲染该 Pass，它的值是一个有空格分隔的字符串。Unity 支持的选项有：SoftVegetation。<font color = grass>（待去官网上查看是否已更新）</font> | Tags {"RequireOptions" = "SoftVegetation"} |

#### 渲染状态 RenderSetup

以下渲染状态既可用于 SubShader 中，也可用于 Pass 块中。

| 状态名称 | 设置指令                                                     | 解释                                     |
| -------- | ------------------------------------------------------------ | ---------------------------------------- |
| Cull     | Cull Back \| Front \| Off                                    | 设置剔除模式：提出背面 / 正面 / 关闭剔除 |
| ZTest    | ZTest Less Greater \| Lequal \| GEqual \| Equal \| NotEqual \| Always | 设置深度测试时使用的函数                 |
| ZWrite   | ZWrite On \| Off                                             | 开启 / 关闭深度写入                      |
| Blend    | Blend SrcFactor DetFactor                                    | 开启并设置混合模式                       |

#### Pass 块

Unity Shader 支持一些特殊的 Pass。

UsePass：可以使用该命令复用其他 Unity Shader 中的 Pass。

GrabPass：该 Pass 负责抓取屏幕并将结果存储在一张纹理中，以用于后续的 Pass 处理。

## 属性类型

### Color

颜色类型，rgba 每一个方向都在 0 ~ 1 之间

```
// Properties 中
_Color("Color",Color) = (1,1,1,1)
// SubShader 中
float4 _Color;
```

### Vector

四维向量

```
// Properties 中
_Vector("Vector",Vector) = (1,2,3,4)
// SubShader 中
float4 _Vector;
```

### Int

整数

```
// Properties 中
_Int("Int",Int) = 1314
// SubShader 中
float _int;
```

### Float、half、fixed

小数，没有 double 类型，所以数值不需要加 f

half、fixed 与 float 除范围不同，其他相同

范围：

- float：32 位二进制，32 位高精度浮点数，精确到小数点后 6 位。一般用于世界坐标、纹理坐标

- half：16 位二进制，16 位中精度浮点数，[-60000, 60000]，精确到小数点后 3 位。一般用于短向量、方向、本地坐标、高动态范围颜色

- fixed：11 位二进制，11 位低精度浮点数，[-2, 2]，精度为 1 / 256，一般用于普通颜色

float2、half2、fixed2：二维向量

float3、half3、fixed3：三维向量

float4、half4、fixed4：四维向量

```
// Properties 中
_Float("Float",Float) = 4.5
// SubShader 中
float _Float;
```

### Range

范围，Range(a,b) 相当于 [a,b]

```
// Properties 中
_Range("Range",Range(1,11)) = 6
// SubShader 中
float _Range;
```

### 2D

2D 纹理。`""` 中要么是空的，要么是内置的纹理名称，如 `"white"`、`"black"`、`"gray"`、`"bump"`。white 代表当 Unity Inspector 面板中未指定任何纹理时，默认使用白色的贴图。花括号的作用在 Unity 5.0 以后的版本中被 <font color = skyblue>移除</font> 了，如果我们需要类似的功能，需要自己在顶点着色器中编写计算相应纹理坐标的代码。在 Unity 5.0 以前的版本中，花括号的用处是用于指定一些纹理属性的，我们可以通过 TexGen CubeReflect、TexGen CubeNormal 等选项来控制固定管线的纹理坐标的生成。

3D、Cube 同理。

```
// Properties 中
_2D("Texture",2D) = "white"{}
// SubShader 中
sampler2D _2D;
```

### 3D

3D纹理

```
// Properties 中
_3D("Texture",3D) = "white"{}
// SubShader 中
sampler3D _3D;
```

### Cube

立方体纹理，一般用于天空盒子

```
// Properties 中
_Cube("Cube",Cube) = "white"{}
// SubShader 中
samplerCube _Cube;
```

## Unity Shader 内置变量

### 变换矩阵

下面所有矩阵都是 float $4 \times 4$ 类型的。

Unity 5.2 版本的。

| 变量名             |                                                              |
| ------------------ | ------------------------------------------------------------ |
| UNITY_MATRIX_MVP   | 当前的模型观察投影矩阵，用于将顶点 / 方向矢量从模型空间变换到裁剪空间 |
| UNITY_MATRIX_MV    | 当前的模型观察矩阵，用于将顶点 / 方向矢量从模型空间变换到观察空间 |
| UNITY_MATRIX_V     | 当前的观察矩阵，用于将顶点 / 方向矢量从世界空间变换到观察空间 |
| UNITY_MATRIX_P     | 当前的投影矩阵，用于将顶点 / 方向矢量从观察空间变换到裁剪空间 |
| UNITY_MATRIX_VP    | 当前的观察投影矩阵，用于将顶点 / 方向矢量从世界空间变换到裁剪空间 |
| UNITY_MATRIX_T_MV  | UNITY_MATRIX_MV的转置矩阵                                    |
| UNITY_MATRIX_IT_MV | UNITY_MATRIX_MV的逆转置矩阵，用于将法线从模型空间变换到观察空间，也可用于得到UNITY_MATRIX_MV的逆矩阵 |
| _Object2World      | 当前的模型矩阵，用于将顶点 / 方向矢量从模型空间变换到世界空间 |
| _World2Object      | _Object2World 的逆矩阵，用于将顶点 / 方向矢量从世界空间变换到模型空间 |

<center>Unity 内置的变换矩阵</center>

UNITY_MATRIX_T_MV：

如果 UNITY_MATRIX_MV 是正交矩阵，也就是模型的变换只包含旋转，那么 UNITY_MATRIX_T_MV 是 UNITY_MATRIX_MV 的逆矩阵。我们就可以使用 UNITY_MATRIX_T_MV 把顶点 / 反向矢量从观察空间变换到模型空间。如果模型的变换包含旋转和统一缩放（缩放系数为k），那么 $\frac{1}{k}$ UNITY_MATRIX_T_MV 是 UNITY_MATRIX_MV 的逆矩阵。我们就可以使用 $\frac{1}{k}$ UNITY_MATRIX_T_MV  把顶点 / 反向矢量从观察空间变换到模型空间。如果对反向矢量进行变换，我们可以截取 UNITY_MATRIX_T_MV 的前 3 行前 3 列把反向矢量从观察空间变换到模型空间（前提是只存在旋转和统一缩放）。同样也进行归一化处理，消除统一缩放的影响。

UNITY_MATRIX_IT_MV：

UNITY_MATRIX_IT_MV 可以把法线从模型空间变换到观察空间，我们只需要对它进行转置就可以得到 UNITY_MATRIX_MV 的逆矩阵，把顶点 / 方向矢量从观察空间变换到模型空间。

方法 1：

```
// 使用 transpose 函数对 UNITY_MATRIX_IT_MV 进行转置
// 得到 UNITY_MATRIX_MV 的逆矩阵，然后进行列矩阵乘法
// 观察空间中的点或方向矢量变换到模型空间中
float4 modelPos = mul(transpose(UNITY_MATRIX_IT_MV),viewPos);
```

方法 2：

```
// 不直接使用转置函数 transpose，而是交换 mul 参数的位置，使用行矩阵乘法
float4 modelPos = mul(viewPos,UNITY_MATRIX_IT_MV);
```

### 摄像机和屏幕参数

| 变量名                          | 类型              | 描述                                                         |
| ------------------------------- | ----------------- | ------------------------------------------------------------ |
| _WorldSpaceCameraPos            | float3            | 该摄像机在世界空间中的位置                                   |
| _ProjectionParams               | float4            | x = 1.0（或 -1.0，如果正在使用一个翻转的投影矩阵进行渲染），y = Near，z = Far，w = 1.0 + 1.0 / Far，其中 Near 和 Far 分别是近裁剪平面和远裁剪平面和摄像机的距离 |
| _ScreenParams                   | float4            | x = width，y = height，z = 1.0 + 1.0 / width，w = 1.0 + 1.0 / height，其中 width 和 height 分别是该摄像机的渲染目标（render target）的像素宽度和高度 |
| _ZBufferParams                  | float4            | x = 1 - Far / Near，y = Far / Near，z = x / Far，w = y / Far，该变量用于线性化 Z 缓存中的深度值 |
| unity_OrthoParams               | float4            | x = width，y = height，z 没有定义，w = 1.0（该摄像机是正交摄像机）或 w = 0.0（该摄像机是透视摄像机），其中 width 和 height 是正交投影摄像机的宽度和高度 |
| unity_CameraProjection          | float$4 \times 4$ | 该摄像机的投影矩阵                                           |
| unity_CameraInvProjection       | float$4 \times 4$ | 该摄像机的投影矩阵的逆矩阵                                   |
| unity_CameraWorldClipPlanes [6] | float4            | 该摄像机的 6 个裁剪平面在世界空间下的等式，按如下顺序，左、右、下、上、近、远裁剪平面 |

## 特殊语义

### 顶点坐标 POSITION

### SV_POSITION

# 简单的例子

## 表面着色器

表面着色器（Surface Shader）是 Unity 自己创造的一种着色器代码类型，最后仍旧会被转换成对应的顶点/片元着色器。它被定义在 SubShader 语义块中的 CGPROGRAM 和 ENDCG 之间，中间的代码使用 Cg/HLSL 编写的。这能使我们不必关心使用多少个 Pass 块、每个 Pass 块如何渲染等问题，我们只需关心使用什么纹理填充颜色，使用什么法线纹理填充法线，使用 Lambert 光照模型等。一般被用来处理光照细节。

```
Shader "Learning/简单的表面着色器"
{
    SubShader
    {
        Tags
		{
			"RenderType" = "Opaque"
		}
		
		CGPROGRAM
			// 使用 Lamber 光照模型
			#pragma surface surf Lambert
			
			struct Input {
				float4 color: COLOR;
			};
			
			void surf(Input IN,inout SurfaceOutput o) {
				o.Albedo = 1;
			}
		ENDCG
	}
	
    Fallback "Diffuse"
}
```

## 顶点 / 片元着色器

顶点 / 片元着色器的代码也需要定义在 CGPROGRAM 和 ENDCG 之间，但顶点 / 片元着色器是写在 Pass 语义块内，需要我们自己定义每个 Pass 块需要使用的代码。灵活性更高，能控制更多的渲染的实现细节。

```
Shader "Learning/简单的顶点片元着色器"
{
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            float4 vert(float4 v : POSITION) : SV_POSITION
            {
                return UnityObjectToClipPos(v);
            }
            
            fixed4 frag() : SV_Target
            {
                return fixed4(1.0,0.0,0.0,1.0);
            }
            ENDCG
        }
    }
}
```

## 固定函数着色器

不支持可编程管线着色器，对于一些较旧的设备（GPU仅支持 DirectX 7.0、OpenGL 1.5 或 OpenGL ES 1.1）如 iPhone 3。固定函数着色器一般可以完成一些非常简单的效果。 在 Unity 5.2 之后，所有固定函数着色器都会在背后被 Unity 编译成对应的顶点 / 片元着色器，因此真正意义上的固定函数着色器已经不存在了。固定函数着色器的代码被定义在 Pass 块中，这些代码相当于 Pass 块中的一些渲染设置，需要完全使用 ShaderLab 的语法来编写。

```
Shader "Learning/固定函数着色器"
{
    Properties
    {
        _Color("Main Color",Color) = (1,0.5,0.5,1)
    }
    SubShader
    {
        Pass
        {
            Material
			{
				Diffuse [_Color]
			}

			Lighting On
        }
    }
}
```

![Unity Shader 的三种形式例子](图片\Shader\Unity Shader 的三种形式例子.jpg)

<center>从左至右：表面着色器、顶点 / 片元着色器、固定函数着色器</center>

## 着色器的选择

- 如果需要与各种光源打交道，需要使用表面着色器，但需要小心它在移动平台的性能
- 如果需要使用的光照数目非常少 或者 需要很多自定义渲染效果，使用顶点 / 片元着色器是一个更好的选择
- 需要在非常旧的设备上运行游戏的，选择固定函数着色器

 