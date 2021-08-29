import os
import sys

from PIL import Image

imagePath = os.path.join(os.path.dirname(os.path.abspath(__file__)),
                         "..\Image")
size = (128, 128)

for infile in os.listdir(imagePath):
    infile = os.path.join(imagePath, infile)
    if os.path.isfile(infile):
        outfile = os.path.splitext(infile)[0] + ".thumbnail"
        if infile != outfile:
            try:
                with Image.open(infile) as image:
                    image.thumbnail(size)
                    image.save(outfile, "JPEG")
            except OSError:
                print("cannot create thumbnail for", infile)
