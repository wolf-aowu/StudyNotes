import os

from PIL import Image
from PIL import ImageFilter

imageAbsPath = os.path.join(os.path.dirname(os.path.abspath(__file__)),
                            "..\Image\七龙珠.png")

image = Image.open(imageAbsPath)
out = image.filter(ImageFilter.DETAIL)
out.show()