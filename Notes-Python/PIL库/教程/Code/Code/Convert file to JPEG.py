import os
import sys

from PIL import Image

imagePath = os.path.join(os.path.dirname(os.path.abspath(__file__)),
                         "..\Image")

for infile in os.listdir(imagePath):
    infile = os.path.join(imagePath, infile)
    # 先判断 infile 是否是文件路径，如果不是，直接 pass 掉
    if os.path.isfile(infile):
        filePathWithOutSuffixName, suffixName = os.path.splitext(infile)
        outfile = filePathWithOutSuffixName + ".jpg"
        if infile != outfile:
            try:
                # with 表达式 [as var] 相当于 var = 表达式的返回值
                with Image.open(infile) as image:
                    image.save(outfile)
            except OSError:
                print("cannot convert", infile)
