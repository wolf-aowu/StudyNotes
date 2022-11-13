import os

from PIL import Image

imageAbsPath = os.path.join(os.path.dirname(os.path.abspath(__file__)),
                            "..\Image\七龙珠.png")

image = Image.open(imageAbsPath)
# transpose() 只能填写以下 7 种参数
# 将图像从左至右翻转
out = image.transpose(Image.FLIP_LEFT_RIGHT)
out.show()
# 将图像从上至下翻转
out = image.transpose(Image.FLIP_TOP_BOTTOM)
out.show()
# 将图像逆时针旋转 90 度
out = image.transpose(Image.ROTATE_90)
out.show()
# 将图像逆时针旋转 180 度
out = image.transpose(Image.ROTATE_180)
out.show()
# 将图像逆时针旋转 270 度
out = image.transpose(Image.ROTATE_270)
out.show()
# 先将图片从左至右翻转后，逆时针旋转 90 度
out = image.transpose(Image.TRANSPOSE)
out.show()
# 先将图片从左至右翻转后，逆时针旋转 270度
out = image.transpose(Image.TRANSVERSE)
out.show()