import os

from PIL import Image

imageAbsPath = os.path.join(os.path.dirname(os.path.abspath(__file__)),
                            "..\Image\七龙珠.png")

image = Image.open(imageAbsPath)
# 获得的 r，g，b 都是灰度图像
r, g, b = image.split()
print(f"r: {r}\ng: {g}\nb: {b}")
# 将红色通道和蓝色通道的值互相交换
# Image.merge 必须每个颜色通道尺寸相同
image = Image.merge("RGB", (b, g, r))
print(image)
image.show()