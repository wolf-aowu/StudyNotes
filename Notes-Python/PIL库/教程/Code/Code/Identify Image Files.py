import os
import sys

from PIL import Image

imagePath = os.path.join(os.path.dirname(os.path.abspath(__file__)),
                         "..\Image")

infile = os.path.join(imagePath, "七龙珠.png")
try:
    with Image.open(infile) as image:
        # f"" 的作用类似于 str.format，格式化字符串，与 C# 中的 $ 作用相同
        print(os.path.abspath(infile), image.format, f"{image.size}x{image.mode}")
except OSError:
    pass
