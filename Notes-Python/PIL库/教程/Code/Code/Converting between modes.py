import os

from PIL import Image

imageAbsPath = os.path.join(os.path.dirname(os.path.abspath(__file__)),
                            "..\Image\七龙珠.png")

image = Image.open(imageAbsPath)
out = image.convert("L")
out.save(os.path.join(os.path.dirname(imageAbsPath), "七龙珠转换为灰度图像.png"), "PNG")
