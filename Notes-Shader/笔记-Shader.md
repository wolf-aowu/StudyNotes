### 基础知识

#### 结构

```
// 与 Shader 的文件名无关，是对 Shader 的分类
Shader "MyShader/LearningShader1"
{
    // 定义一些需要通过 Unity 赋值的变量
    // 非必须的
    Properties{
        // 变量名("Unity Inspector 面板中显示的变量名",变量类型) = 值
        // 当 Unity Inspector 面板中的值改变过后，将以 Unity Inspector 面板中的值为准
        // 变量与变量之间通过换行区分
        _Color("Color",Color) = (1,1,1,1)
    }
    // 可以有多个 SubShader，用于适配不同的显卡
    // 当显卡不适配第一个 SubShader 时，会自动选择第二个 SubShader，如果还不适配时，会继续选择下一个 SubShader，以此类推
    // 必须的
    SubShader{
        // 一个 SubShader 中可以有许多的 Pass 块，但必须有一个 Pass 块
        // 一个 Pass 块相当于一个方法
        Pass{
            // 该块中可以使用 CG 语言编写 Shader 代码
            // 当需要使用 Properties 中的变量时，需要重新定义一下，但 Properties 中的变量的值会传过来
            // 新定义的变量名需与 Properties 的变量名一样
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
    // 非必须的
    Fallback "vertexLit"
}
```

#### 变量类型

##### Color

颜色类型，rgba 每一个方向都在 0 ~ 1 之间

```
// Properties 中
_Color("Color",Color) = (1,1,1,1)
// SubShader 中
float4 _Color;
```

##### Vector

四维向量

```
// Properties 中
_Vector("Vector",Vector) = (1,2,3,4)
// SubShader 中
float4 _Vector;
```

##### Int

整数

```
// Properties 中
_Int("Int",Int) = 1314
// SubShader 中
float _int;
```

##### Float、half、fixed

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

##### Range

范围，Range(a,b) 相当于 [a,b]

```
// Properties 中
_Range("Range",Range(1,11)) = 6
// SubShader 中
float _Range;
```

##### 2D

2D 纹理，white 代表当 Unity Inspector 面板中未指定任何纹理时，默认使用白色的贴图

```
// Properties 中
_2D("Texture",2D) = "white"{}
// SubShader 中
sampler2D _2D;
```

##### 3D

3D纹理

```
// Properties 中
_3D("Texture",3D) = "white"{}
// SubShader 中
sampler3D _3D;
```

##### Cube

立方体纹理，一般用于天空盒子

```
// Properties 中
_Cube("Cube",Cube) = "white"{}
// SubShader 中
samplerCube _Cube;
```

#### 特殊语义

##### 顶点坐标 POSITION

##### SV_POSITION

