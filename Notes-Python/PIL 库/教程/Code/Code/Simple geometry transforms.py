import os

from PIL import Image

imageAbsPath = os.path.join(os.path.dirname(os.path.abspath(__file__)),
                            "..\Image\七龙珠.png")

image = Image.open(imageAbsPath)
out = image.resize((image.size[0] // 4, image.size[1] // 4))
out.save(os.path.join(os.path.dirname(imageAbsPath), "七龙珠缩小 4 倍后.png"), "PNG")
out = image.resize((image.size[0] * 4, image.size[1] * 4))
out.save(os.path.join(os.path.dirname(imageAbsPath), "七龙珠放大 4 倍后.png"), "PNG")
out = image.rotate(45)  # degrees counter-clockwise
out.save(os.path.join(os.path.dirname(imageAbsPath), "七龙珠逆时针旋转 45 度后.png"),
         "PNG")