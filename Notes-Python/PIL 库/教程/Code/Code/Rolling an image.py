import os
from PIL import Image

imageAbsPath = os.path.join(os.path.dirname(os.path.abspath(__file__)),
                            "..\Image\七龙珠.png")


def roll(image, delta):
    """Roll an image sideways."""
    length, width = image.size

    delta = delta % length
    if delta == 0: return image

    # 将图片分为左右两部分，左边为 part1，右边为 part2
    part1 = image.crop((0, 0, delta, width))
    part2 = image.crop((delta, 0, length, width))
    # 将图像分为左右两部分，右边为 part1，左边为 part2，同时将本次分的两部分覆盖上一次分的对应部分
    # image.paste 只能接收整数
    image.paste(part1, (length - delta, 0, length, width))
    image.paste(part2, (0, 0, length - delta, width))
    return image


if __name__ == "__main__":
    image = Image.open(imageAbsPath)
    # 显示原图
    image.show()
    # 显示横向滚动后的图片并保存
    imageAfterRoll = roll(image, image.size[0] // 2)
    imageAfterRoll.show()
    imageAfterRoll.save(
        os.path.join(os.path.dirname(imageAbsPath), "七龙珠横向滚动 delta 像素点后.png"),
        "PNG")
