# 安装

GLFW 官网：https://www.glfw.org/

下载一定要选择 Source package，否则在使用 CMake 编译时会报错，提示缺少一个文件。这个文件在 Source package 里才有。

<img src="图片\OpenGL\GLFW 下载.png" style="zoom: 80%;" />

其余步骤按照 实验：搭建OpenGL环境&&绘制窗口.pdf 文件来即可。

GLAD 生成网站：https://glad.dav1d.de/

# 概念

## EBO、VBO、VAO

### EBO

EBO（Element Buffer Object），也叫 IBO（Index Buffer Object）索引缓冲区对象，主要用来存储顶点的索引信息。

例子

一个平行四边形可以被分成两个三角形，将两个三角形分开看一共有 6 个顶点，但是对于整个平行四边形来说只有 4 个顶点。两个三角形中 6 个顶点有 2 组顶点是重复的。索引存储顶点顺序就是存储 4 个顶点的信息，使用索引标记这四个顶点，在两个三角形存储顶点位置信息时直接存储对应索引。

![](图片\OpenGL\EBO.png)

### VBO

VBO（Vertex Buffer Object）顶点缓冲区对象，主要用来存储顶点的各种信息。

好处：模型的顶点信息放进VBO，这样每次画模型时，数据不用再从 CPU 的势力范围内存里取，而是直接从 GPU 的显存里取，从而提高效率。

### VAO

VAO（Vertex Array Object）顶点数组对象。VAO 是一个保存了所有顶点数据属性的状态结合，它存储了顶点数据的格式以及顶点数据所需的VBO对象的引用。也就是，VAO 本身不存储数据，它将多个 VBO 按顶点整合起来作为一个对象统一管理。

### VAO 与 VBO 之间的关系

![](图片\OpenGL\VAO 和 VBO 之间关系.png)

# 练习

## 绘制一个窗口并更改背景颜色

文件：HelloOpenGL.cpp

```cpp
// glad 头文件必须写在 GLFW 头文件之前，因为 GLFW 头文件依赖 glad
#include <glad/glad.h>
#include <GLFW/glfw3.h>
#include <stdio.h>
#include <iostream>

void framebuffer_size_callback(GLFWwindow* window, int width, int height);

int main()
{
	// 初始化 GLFW
	glfwInit();
	// glfwWindowHint 可以进行一些配置
	// Major 主版本号 Minor 次版本号
	// Core-profile 核心模式
	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
	glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
	// 如果是 Mac OS X 系统需要加上下面这句
	// glfwWindowHint(GLFW_OPENGL_FORWARD_COMPAT, GL_TRUE);


	// 获取当前使用的 GLFW 版本
	int Major, Minor, Rev;
	glfwGetVersion(&Major, &Minor, &Rev);
	printf("GLFW %d.%d.%d initialized\n", Major, Minor, Rev);

	// 创建一个窗口对象
	// glfwCreateWindow 函数需要窗口的宽和高作为它的前两个参数。
	// 第三个参数表示这个窗口的名称（标题），这里我们使用"window"，当然你也可以使用你喜欢的名称。
	// 最后两个参数我们暂时忽略。这个函数将会返回一个 GLFWwindow 对象，我们会在其它的 GLFW 操作中使用到。
	GLFWwindow* window = glfwCreateWindow(800, 600, "Hello OpenGL", NULL, NULL);
	// 判断窗口是否创建失败
	if (window == NULL)
	{
		std::cout << "Failed to create GLFW window" << std::endl;
		glfwTerminate();
		return -1;
	}
	// 将窗口的上下文设置当前线程的主上下文
	// 上下文：OpenGL 是一个打的状态机，OpenGL 的状态被称为上下文
	glfwMakeContextCurrent(window);

	// GLAD 是用来管理 OpenGL 的函数指针的。在调用任何 OpenGL 的函数之前我们需要初始化 GLAD。
	// 我们给 GLAD 传入了用来加载系统相关的 OpenGL 函数指针地址的函数。
	// GLFW 给我们的是 glfwGetProcAddress，它根据我们编译的系统定义了正确的函数。
	if (!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
	{
		std::cout << "Failed to initialize GLAD" << std::endl;
		return -1;
	}

	// 在我们开始渲染之前，我们必须告诉 OpenGL 渲染窗口的尺寸大小，即视口(Viewport)，
	// 这样 OpenGL 才只能知道怎样根据窗口大小显示数据和坐标
	// glViewport 函数前两个参数控制窗口左下角的位置。
	// 第三个和第四个参数控制渲染窗口的宽度和高度（像素）。
	glViewport(0, 0, 800, 600);
	// 当窗口被第一次显示的时候 framebuffer_size_callback 也会被调用。
	// 对于视网膜(Retina)显示屏，width 和 height 都会明显比原输入值更高一点。
	glfwSetFramebufferSizeCallback(window, framebuffer_size_callback);

	// 渲染循环，它能在我们让 GLFW 退出前一直保持运行。
	// glfwWindowShouldClose 函数检查 GLFW 是否被要求退出，如果是的话该函数返回 true。
	while (!glfwWindowShouldClose(window))
	{
		// 输入（会报错，不知道原因）
		// processInput(window);
		// 渲染指令
		//  glClearColor 来设置清空屏幕所用的颜色。
		// 当调用 glClear 函数，清除颜色缓冲之后，整个颜色缓冲都会被填充为 glClearColor 里所设置的颜色。
		// 在这里，我们将屏幕设置为了一种好看的蓝色。
		glClearColor(0.0f, 0.34f, 0.57f, 1.0f);
		// 通过调用 glClear 函数来清空屏幕的颜色缓冲，
		// 它接受一个缓冲位(Buffer Bit)来指定要清空的缓冲，
		// 可能的缓冲位有 GL_COLOR_BUFFER_BIT，GL_DEPTH_BUFFER_BIT 和 GL_STENCIL_BUFFER_BIT。
		glClear(GL_COLOR_BUFFER_BIT);

		// glfwSwapBuffers 函数会交换颜色缓冲（它是一个储存着 GLFW 窗口每一个像素颜色值的大缓冲），
		// 它在这一迭代中被用来绘制，并且将会作为输出显示在屏幕上。
		glfwSwapBuffers(window);
		// glfwPollEvents 函数检查有没有触发什么事件（比如键盘输入、鼠标移动等）、
		// 更新窗口状态，并调用对应的回调函数（可以通过回调方法手动设置）。
		glfwPollEvents();
	}

	// 释放/删除之前的分配的所有资源
	glfwTerminate();

	return 0;
}

/// <summary>
/// 这是一个回调函数，它会在每次窗口大小被调整的时候被调用。
/// </summary>
/// <param name="window"></param>
/// <param name="width"></param>
/// <param name="height"></param>
void framebuffer_size_callback(GLFWwindow* window, int width, int height)
{
	glViewport(0, 0, width, height);
}
```

## 绘制三角形

目的：绘制三角形
步骤：

1. 初始化 GLFW 和 GLAD
2. 数据处理：生成和绑定 VBO 和 VAO、设置属性指针
3. 着色器：
   1. 生成顶点着色器
   2. 生成片段着色器】
   3. 生成程序
   4. 将顶点和片段着色器链接到程序
   5. 删除着色器
4. 渲染：
   1. 清空颜色缓冲
   2. 使用着色器程序
   3. 绑定 VAO
   4. 绘制三角形
   5. 解除绑定
   6. 交换缓冲并检查是否触发事件
5. 善后工作：删除 VAO 和 VBO、删除所有资源

```cpp
#include<glad/glad.h>
#include<GLFW/glfw3.h>
#include <iostream>

int main()
{
	glfwInit();
	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
	glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
	// 设置是否可改变窗口大小
	glfwWindowHint(GLFW_RESIZABLE, false);

	int screen_width = 1280;
	int screen_height = 720;
	auto window = glfwCreateWindow(screen_width, screen_height, "Draw Triangle", nullptr, nullptr);
	if (window == nullptr)
	{
		std::cout << "Failed to Create OpenGL Context" << std::endl;
		glfwTerminate();
		return-1;
	}
	glfwMakeContextCurrent(window);

	if (!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
	{
		std::cout << "Failed to initialize GLAD" << std::endl;
		return -1;
	}

	glViewport(0, 0, screen_width, screen_height);

	// 三角形的顶点数据,这里的顶点数据是标准化的设备坐标，
	// 也就是 x, y, z 轴坐标均映射到 [- 1, 1]之间。
	const float triangle[] = {
		-0.5f,-0.5f,0.0f, // 左下
		0.5f,-0.5f,0.0f, // 右下
		0.0f,0.5f,0.0f // 正上
	};

	// 生成一个 VBO
	GLuint vertex_buffer_object;
	glGenBuffers(1, &vertex_buffer_object);
	// 将 VBO 绑定到顶点缓冲对象上，这样我们不用将顶点数据一个一个的发送到显卡
	glBindBuffer(GL_ARRAY_BUFFER, vertex_buffer_object);
	// 将顶点数据绑定至当前默认的缓冲中，GL_STATIC_DRAW 表示三角形位置数据不会被改变
	glBufferData(GL_ARRAY_BUFFER, sizeof(triangle), triangle, GL_STATIC_DRAW);
	// 生成一个顶点对象数组 VAO
	// 好处：核心模式要求我们需要使用 VAO，并且在渲染的时候只需要调用一次 VAO 就可以了，
	// 之前的数据都对应存储在了 VAO 中，不用再调用 VBO。
	GLuint vertex_array_object;
	glGenVertexArrays(1, &vertex_array_object);
	// 绑定
	glBindVertexArray(vertex_array_object);

	// 我们需要告诉 GPU 如何解释这些顶点数据
	// 设置顶点属性指针
	// 这个函数第一个参数是我们后面会用到的顶点着色器的位置值，
	// 3 表示的是顶点属性是一个三分量的向量，
	// 第三个参数表示的是我们顶点的类型，
	// 第四个是我们是否希望数据被标准化，就是映射到 0 - 1 之间，
	// 第五个参数叫做步长，它表示连续顶点属性之间的间隔，因为我们这里只有顶点的位置，
	// 所以我们将步长设置为这个，表示下组数据在 3 个 float 之后。
	// 最后一个是数据的偏移量，这里我们的位置属性是在数组的开头，因此是 0，由于参数类型的限制，将其进行强制类型转换。
	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 3 * sizeof(float), (void*)0);
	// glEnableVertexAttribArray 表明开启了 0 的这个通道，默认状态下是关闭的，因此我们在这里要开启一下。
	glEnableVertexAttribArray(0);

	// 顶点着色器源码
	const char* vertex_shader_source =
		// GLSL 语言
		// 使用的 OpenGL3.3 的核心模式
		"#version 330 core\n"
		// 位置的值
		"layout (location = 0) in vec3 aPos;\n"
		"void main()\n"
		"{\n"
		// 将之前的顶点数据直接输出到 GLSL 已经定义好的一个内建变量 gl_Position 中
		// 这个就是我们顶点着色器的输出
		" gl_Position = vec4(aPos, 1.0);\n"
		"}\n\0";

	// 片段着色器源码
	const char* fragment_shader_source =
		"#version 330 core\n"
		// out 表示输出变量。 FragColor 三角形的颜色。
		"out vec4 FragColor;\n"
		"void main()\n"
		"{\n"
		" FragColor = vec4(1.0f, 0.5f, 0.2f, 1.0f);\n"
		"}\n\0";

	// 生成顶点着色器
	int vertex_shader = glCreateShader(GL_VERTEX_SHADER);
	glShaderSource(vertex_shader, 1, &vertex_shader_source, NULL);
	glCompileShader(vertex_shader);
	int success;
	char info_log[512];
	// 检查着色器是否成功编译，如果编译失败，打印错误信息
	glGetShaderiv(vertex_shader, GL_COMPILE_STATUS, &success);
	if (!success)
	{
		glGetShaderInfoLog(vertex_shader, 512, NULL, info_log);
		std::cout << "ERROR::SHADER::VERTEX::COMPILATION_FAILED\n" << info_log << std::endl;
	}

	// 生成片段着色器
	int fragment_shader = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(fragment_shader, 1, &fragment_shader_source, NULL);
	glCompileShader(fragment_shader);
	// 检查着色器是否成功编译，如果编译失败，打印错误信息
	glGetShaderiv(fragment_shader, GL_COMPILE_STATUS, &success);
	if (!success)
	{
		glGetShaderInfoLog(fragment_shader, 512, NULL, info_log);
		std::cout << "ERROR::SHADER::FRAGMENT::COMPILATION_FAILED\n" << info_log << std::endl;
	}

	// 连接顶点和片段着色器至一个着色器程序
	int shader_program = glCreateProgram();
	glAttachShader(shader_program, vertex_shader);
	glAttachShader(shader_program, fragment_shader);
	glLinkProgram(shader_program);
	// 检查着色器是否成功链接，如果链接失败，打印错误信息
	glGetProgramiv(shader_program, GL_LINK_STATUS, &success);
	if (!success)
	{
		glGetProgramInfoLog(shader_program, 512, NULL, info_log);
		std::cout << "ERROR::SHADER::PROGRAM::LINKING_FAILED\n" << info_log << std::endl;
	}

	// 删除着色器，因为在后面渲染的时候我们只需要用之前链接好的着色器程序就可以了，
	// 不需要再使用顶点和片段着色器了。
	glDeleteShader(vertex_shader);
	glDeleteShader(fragment_shader);

	// 线框模式
	//glPolygonMode(GL_FRONT_AND_BACK, GL_LINE);

	// 渲染
	while (!glfwWindowShouldClose(window))
	{
		// 清空颜色缓冲
		glClearColor(0.0f, 0.34f, 0.57f, 1.0f);
		glClear(GL_COLOR_BUFFER_BIT);

		// 使用着色器程序
		glUseProgram(shader_program);

		// 绘制三角形
		// 绑定 VAO
		glBindVertexArray(vertex_array_object);
		// 绘制三角形
		// 这里的第一个参数表示我们是要绘制三角形，
		// 第二个参数表示我们顶点数组的起始索引值，
		// 第三个参数表示我们要绘制的顶点数量，这里绘制三角形我们要绘制三个顶点。
		glDrawArrays(GL_TRIANGLES, 0, 3);
		// 解除绑定
		glBindVertexArray(0);

		// 交换缓冲并检查是否触发事件（如：键盘输入、鼠标移动等）
		glfwSwapBuffers(window);
		glfwPollEvents();
	}

	// 删除 VAO 和 VBO
	glDeleteVertexArrays(1, &vertex_array_object);
	glDeleteBuffers(1, &vertex_buffer_object);

	// 清理所有的资源并正确退出程序
	glfwTerminate();
	return 0;
}
```

