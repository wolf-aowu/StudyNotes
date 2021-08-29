import os

from PIL import Image

# 图片的绝对路径，可随 Code-教程 文件夹路径改变而改变
# os.path.abspath(__file__) 获取当前文件的绝对路径
# os.path.dirname 获取文件所在文件夹路径名
# os.path.join 智能地连接一个或多个路径
imageAbsPath = os.path.join(os.path.dirname(os.path.abspath(__file__)),
                            "..\Image\七龙珠.png")

# 打开图片
# Image.open(相对路径或绝对路径)
image = Image.open(imageAbsPath)

print("图片格式：", image.format)
print("图片大小：", image.size)
print("图片模式：", image.mode)

image.show()