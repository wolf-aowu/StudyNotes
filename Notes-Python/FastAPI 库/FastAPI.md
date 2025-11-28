# FastAPI

官方网址：https://fastapi.tiangolo.com/zh/

FastAPI 是一个用于构建 API 的现代、快速（高性能）的 web 框架，使用 Python 并基于标准的 Python 类型提示。

可与 **NodeJS** 和 **Go** 并肩的极高性能（归功于 Starlette 和 Pydantic）。仅次于 Starlette 和 Pydantic，FastAPI 本身也用了 Starlette 和 Pydantic。

## 安装

``` shell
# 附带一些默认的可选标准依赖项，会安装 uvicorn
pip install "fastapi[standard]"
# 不带可选标准依赖项
pip install fastapi
```

uvicorn 官方网址：https://uvicorn.dev/

## 查看文档

自动生成的文档

http://127.0.0.1:8000/docs

备选文档

http://127.0.0.1:8000/redoc

## 创建应用

main.py

``` python
from fastapi import FastAPI

app = FastAPI()

@app.get("/")
def read_root():
    return {"Hello": "World"}
```

**启动服务**

通过命令：

``` shell
# --reload 代码有更改时刷新网页即可
uvicorn filename:appname --reload
# 以上面为例
uvicorn main:app --reload
```

通过调试：

需要安装 fastapi[standard]

``` shell
fastapi dev filename.py
```

通过 python 运行：

代码中需要添加：

``` python
import uvicorn

if __name__ == "__main__":
    # 不加 reload
    uvicorn.run(app, host="127.0.0.1", port=8000)
    # 加 reload
    uvicorn.run("filename:appname", host="127.0.0.1", port=8000, reload=True)
```

终端中执行：

``` shell
python main.py
```

## 路径参数

路径参数是 URL 路径中用于捕获动态值的部分，通常用于标识特定资源。

例如：在 URL /users/123 中，123 就是代表 用户ID 的路径参数。

匹配路径参数会从上到下依次匹配。

FastAPI 中会利用 Pydantic 特性对路径参数作校验，会自动进行类型转换。

``` python
from fastapi import FastAPI

app = FastAPI()

@app.get("/items/{item_id}")
async def read_item(item_id: int):
    return {"item_id": item_id}

# 访问 http://127.0.0.1:8000/items/foo，会提示 value is not a valid
# 访问 http://127.0.0.1:8000/items/3，成功访问
```

路径参数是枚举

```python
from enum import Enum
from fastapi import FastAPI

class ModelName(str, Enum):
    alexnet = "alexnet"
    resnet = "resnet"
    lenet = "lenet"

app = FastAPI()

@app.get("/models/{model_name}")
async def get_model(model_name: ModelName):
    ...
```

路径参数是路径

直接使用 Starlette 的选项声明包含路径的路径参数

``` python
from fastapi import FastAPI

app = FastAPI()

@app.get("/files/{file_path:path}")
async def read_file(file_path: str):
    return {"file_path": file_path}
```

## 查询参数

查询参数是键值对的集合，这些键值对位于 URL 的 `?` 之后，已 `&` 分隔。

例如：`http://127.0.0.1:8000/items/?skip=0&limit=10`。

查询参数是支持设置默认值的。假如上例的默认值为：skip=0、limit=10，则 `http://127.0.0.1:8000/items/?skip=0&limit=10` 与 `http://127.0.0.1:8000/items/` 等价。当访问 `http://127.0.0.1:8000/items/skip=20` 时，则 skip=20、limit=10。

会利用 Pydantic 特性对路径参数作校验，会自动进行类型转换。

支持路径参数与查询参数混合使用。

设有默认值代表可选，下例中 `limit` 是可选的，`skip` 是必须要有的。

``` python
from fastapi import FastAPI

app = FastAPI()

@app.get("/items/{item_id}")
async def read_item(item_id: int, skip: int, limit: int = 10):
    return {"item_id": item_id, "skip": skip, "limit": limit}
```

## 请求体

发送数据一般使用 `POST`、`PUT`、`DELETE`、`PATCH` 等操作。

请求体一般格式为 `{key: value}`。

``` python
from fastapi import FastAPI
from pydantic import BaseModel

class Item(BaseModel):
    name: str
    description: str | None = None
    price: float
    tax: float | None = None

app = FastAPI()

@app.post("/items/")
async def create_item(item: Item):
    return item
```

支持 请求体 + 路径参数 + 查询参数。

- 路径中声明了相同参数的参数，是路径参数
- 类型是（`int`、`float`、`str`、`bool` 等）单类型的参数，是查询参数
- 类型是 Pydantic 模型的参数，是请求体

路径参数与查询参数声明没有先后顺序，但是有默认值的必须放在最后，否则 Python 会报错。

## 表单

表单一般格式为 `{key=value}`。`Content-Type` 为 `application/x-www-form-urlencoded`，包含文件的表单编码为 `multipart/form-data`。

需要安装 `python-multipart` 模块，使用 `standard` 安装时会自动安装。

例如，OAuth2 规范的 "密码流" 模式规定要通过表单字段发送 `username` 和 `password`。

该规范要求字段必须命名为 `username` 和 `password`，并通过表单字段发送，不能用 JSON。

`Form` 是直接继承自 `Body` 的类。声明表单体要显式使用 `Form` ，否则，FastAPI 会把该参数当作查询参数或请求体（JSON）参数。可在一个路径操作中声明多个 `Form` 参数，但不能同时声明要接收 JSON 的 `Body` 字段。因为此时请求体的编码是 `application/x-www-form-urlencoded`，不是 `application/json`。这不是 FastAPI 的问题，而是 HTTP 协议的规定。

``` python
from fastapi import FastAPI, Form

app = FastAPI()

@app.post("/login/")
async def login(username: str = Form(), password: str = Form()):
    return {"username": username}
```

表单是个模型

``` python
from typing import Annotated
from fastapi import FastAPI, Form
from pydantic import BaseModel

app = FastAPI()

class FormData(BaseModel):
    username: str
    password: str

@app.post("/login/")
async def login(data: Annotated[FormData, Form()]):
    return data
```

禁止额外的表单字段

``` python
from typing import Annotated
from fastapi import FastAPI, Form
from pydantic import BaseModel

app = FastAPI()

class FormData(BaseModel):
    username: str
    password: str
    model_config = {"extra": "forbid"}

@app.post("/login/")
async def login(data: Annotated[FormData, Form()]):
    return data
```

添加 `model_config = {"extra": "forbid"}` 后发送额外的字段，会收到错误响应：

``` python
{
    "detail": [
        {
            "type": "extra_forbidden",
            "loc": ["body", "extra"],
            "msg": "Extra inputs are not permitted",
            "input": "Mr. Poopybutthole"
        }
    ]
}
```

## 路径参数校验

需要导入 `Path`

``` python
from fastapi import FastAPI, Path

app = FastAPI()

# 使用 ... 代表必填
# max_length 字符串最大长度
# min_length 字符串最小长度
# gt 参数必须大于某个值
# lt 参数必须小于某个值
# ge 大于等于
# le 小于等于
# pattern 正则表达式匹配法则
# alias 为参数起别名，此别名将作用于 url
# description 参数的描述
# deprecated 弃用 True 代表已弃用
# title 作用不详，备用文档中会显示
# example 设置样例
@app.get("/items/{item_id}")
async def read_items(q: str, item_id: int = Path(title="The ID of the item to get")):
    results = {"item_id": item_id}
    if q:
        results.update({"q": q})
    return results
```

**技术细节**

当从 `fastapi` 导入 `Query`、`Path` 和其他同类对象时，它们实际上是函数。

当被调用时，它们返回同名类的实例。

如此，导入 `Query` 这个函数。当调用它时，它将返回一个同样命名为 `Query` 的类的实例。

因为使用了这些函数（而不是直接使用类），所以你的编辑器不会标记有关其类型的错误。

这样，可以使用常规的编辑器和编码工具，而不必添加自定义配置来忽略这些错误。

## 查询参数校验

需要导入 `Query`

``` python
from typing import Union
from fastapi import FastAPI, Query

app = FastAPI()

# default 设置默认值，也是 Query 的第一个参数，不声明默认值就代表这个参数必须有值
# max_length 字符串最大长度
# min_length 字符串最小长度
# gt 参数必须大于某个值
# lt 参数必须小于某个值
# ge 大于等于
# le 小于等于
# pattern 正则表达式匹配法则
# alias 为参数起别名，此别名将作用于 url
# description 参数的描述
# deprecated 弃用 True 代表已弃用
# title 作用不详，备用文档中会显示
# example 设置样例
@app.get("/items/")
async def read_items(q: Union[str, None] = Query(default=None, max_length=50)):
    results = {"items": [{"item_id": "Foo"}, {"item_id": "Bar"}]}
    if q:
        results.update({"q": q})
    return results
```

查询参数是个模型时

``` python
from typing import Annotated, Literal
from fastapi import FastAPI, Query
from pydantic import BaseModel, Field

app = FastAPI()

class FilterParams(BaseModel):
    limit: int = Field(100, gt=0, le=100)
    offset: int = Field(0, ge=0)
    order_by: Literal["created_at", "updated_at"] = "created_at"
    tags: list[str] = []

@app.get("/items/")
async def read_items(filter_query: Annotated[FilterParams, Query()]):
    return filter_query
```

禁止额外的查询参数

``` python
from typing import Annotated, Literal
from fastapi import FastAPI, Query
from pydantic import BaseModel, Field

app = FastAPI()

class FilterParams(BaseModel):
    model_config = {"extra": "forbid"}

    limit: int = Field(100, gt=0, le=100)
    offset: int = Field(0, ge=0)
    order_by: Literal["created_at", "updated_at"] = "created_at"
    tags: list[str] = []

@app.get("/items/")
async def read_items(filter_query: Annotated[FilterParams, Query()]):
    return filter_query
```

假设有一个客户端尝试在查询参数中发送一些额外的数据，它将会收到一个错误响应。

例如，如果客户端尝试发送一个值为 `plumbus` 的 `tool` 查询参数，如：`https://example.com/items/?limit=10&tool=plumbus`，会收到一个错误响应：

``` python
{
    "detail": [
        {
            "type": "extra_forbidden",
            "loc": ["query", "tool"],
            "msg": "Extra inputs are not permitted",
            "input": "plumbus"
        }
    ]
}
```

## 请求体额外数据定义

需要导入 `Body`。

当请求体中存在单一值时，不能直接使用参数来接收，因为 `FastAPI` 会将其认为是一个查询参数。

请求体

``` python
{
    "item": {
        "name": "Foo",
        "description": "The pretender",
        "price": 42.0,
        "tax": 3.2
    },
    "user": {
        "username": "dave",
        "full_name": "Dave Grohl"
    },
    "importance": 5
}
```

代码定义

``` python
from typing import Annotated
from fastapi import Body, FastAPI
from pydantic import BaseModel

app = FastAPI()

class Item(BaseModel):
    name: str
    description: str | None = None
    price: float
    tax: float | None = None

class User(BaseModel):
    username: str
    full_name: str | None = None

@app.put("/items/{item_id}")
async def update_item(
    item_id: int, item: Item, user: User, importance: Annotated[int, Body()]
):
    results = {"item_id": item_id, "item": item, "user": user, "importance": importance}
    return results
```

`embed=True` 可以将单个参数包装在 `JSON` 对象中。

## 请求体中字段校验

需要导入 `Field`

`Field` 的工作方式和 `Query`、`Path`、`Body` 相同，参数也相同。

``` python
from typing import Annotated
from fastapi import Body, FastAPI
from pydantic import BaseModel, Field

app = FastAPI()

class Item(BaseModel):
    name: str
    description: str | None = Field(
        default=None, title="The description of the item", max_length=300
    )
    price: float = Field(gt=0, description="The price must be greater than zero")
    tax: float | None = None

@app.put("/items/{item_id}")
async def update_item(item_id: int, item: Annotated[Item, Body(embed=True)]):
    results = {"item_id": item_id, "item": item}
    return results
```

## 设置样例

方法一：

直接使用 `Field`、`Query`、`Path`、`Body` 中的 `example` 设置。

`Body` 写法如下：

``` python
from typing import Annotated
from fastapi import Body, FastAPI
from pydantic import BaseModel

app = FastAPI()

class Item(BaseModel):
    name: str
    description: str | None = None
    price: float
    tax: float | None = None

@app.put("/items/{item_id}")
async def update_item(
    item_id: int,
    item: Annotated[
        Item,
        Body(
            examples=[
                {
                    "name": "Foo",
                    "description": "A very nice Item",
                    "price": 35.4,
                    "tax": 3.2,
                }
            ],
        ),
    ],
):
    results = {"item_id": item_id, "item": item}
    return results
```

方法二：

使用 `Config` 和 `schema_extra` 为 Pydantic 模型声明一个示例。用于请求体。

``` python
from fastapi import FastAPI
from pydantic import BaseModel

app = FastAPI()

class Item(BaseModel):
    name: str
    description: str | None = None
    price: float
    tax: float | None = None

    model_config = {
        "json_schema_extra": {
            "examples": [
                {
                    "name": "Foo",
                    "description": "A very nice Item",
                    "price": 35.4,
                    "tax": 3.2,
                }
            ]
        }
    }

@app.put("/items/{item_id}")
async def update_item(item_id: int, item: Item):
    results = {"item_id": item_id, "item": item}
    return results
```

## 中间件

中间件会在每个请求对应特殊处理之前执行和每个响应返回之前执行。

![](图片\中间件工作原理.png)

创建中间件需要在函数顶部使用装饰器 `@app.middleware("http")`，中间件接收两个参数：`request` 和 `call_next`。`call_next` 是一个方法将接收 `request` 作为参数。

``` python
import time
from fastapi import FastAPI, Request

app = FastAPI()

@app.middleware("http")
async def add_process_time_header(request: Request, call_next):
    start_time = time.perf_counter()
    response = await call_next(request)
    process_time = time.perf_counter() - start_time
    response.headers["X-Process-Time"] = str(process_time)
    return response
```

当同时存在多个中间件时，按代码在文件中从下到上的顺序执行（也就是最后一个中间件最先执行）。

中间件的另一种写法（不推荐）

``` python
class LogMiddleware:
    def __init__(self, app):
        self.app = app
    
    async def __call__(self, scope, receive, send):
        print("中间件请求前")
        await self.app(scope, receive, send)
        print("中间件请求后")

app.add_middleware(LogMiddleware)
```

## CORS（跨域资源共享）

同源策略（SOP）是浏览器的一种安全机制，限制了一个源的网页如何与另一个源的资源进行交互。同源策略防止恶意网站通过脚本（如 JavaScript）未经授权访问其他网站的数据。

CORS（跨域资源共享）指浏览器中运行的前端拥有与后端通信的 JavaScript 代码，而后端处于与前端不同的源的情况。是一种基于 HTTP 的机制，它允许服务器指示哪些其他源可以访问其资源，从而绕过浏览器的同源策略限制。

官方参考网址：https://developer.mozilla.org/zh-CN/docs/Web/HTTP/Guides/CORS

源是协议（`http`，`https`）、域（`myapp.com`，`localhost`，`localhost.tiangolo.com`）以及端口（`80`、`443`、`8080`）的组合。

所以，以下时不同的源：

- `http://localhost`
- `https://localhost`
- `http://localhost:8080`

所以当来自不同源的前端和后端通信时，需要有一个允许的源列表。

可以使用 `*` 来声明这个列表，表示允许来自所有的源的通信请求。但这仅允许某些类型的通信，不包括所有涉及凭据的内容：像 Cookies 以及那些使用 Bearer 令牌的授权 headers 等。

因此，为了一切都能正常工作，最好显式地指定允许的源。

可以使用 `CORSMiddleware` 来配置允许的源列表。默认情况下，这个 `CORSMiddleware` 实现所使用的默认参数较为保守，所以需要显式地启用特定的源、方法或者 headers，以便浏览器能够在跨域上下文中使用它们。`CORSMiddleware` 是中间件中的一种。

``` python
from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware

app = FastAPI()

origins = [
    "http://localhost.tiangolo.com",
    "https://localhost.tiangolo.com",
    "http://localhost",
    "http://localhost:8080",
]

app.add_middleware(
    CORSMiddleware,
    allow_origins=origins,
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

@app.get("/")
async def main():
    return {"message": "Hello World"}
```

另一种方法（不推荐）

``` python
@app.middleware("http")
async def add_cors_headers(request, call_next):
    if request.method == "OPTIONS":
        headers = {
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Methods": "GET,POST,PUT,DELETE,OPTIONS",
            "Access-Control-Allow-Headers": "Content-Type,Authorization"
        }
        return Response(status_code=200, headers=headers)
    response = await call_next(request)
    response.headers["Access-Control-Allow-Origin"] = "*"
    return response
```

`allow_origins` 一个允许跨域请求的源列表。`["*"]` 表示允许所有的源。

`allow_origin_regex` 一个正则表达式字符串，匹配的源允许跨域请求。

`allow_methods` 一个允许跨域请求的 `HTTP` 方法列表，默认为 `["GET"]`。可以使用 `["*"]` 来允许所有标准方法。

`allow_headers` 一个允许跨域请求的 `HTTP` 请求头列表。默认为 `[]`。可以使用 `["*"]` 来允许所有的请求头。`Accdpt`、`Accept-Language`、`Content-Language` 以及 `Content-Type` 请求头总是允许 CORS 请求。

`allow_credentials` 跨域请求支持 cookies。默认是 `False`。允许凭证时 `allow_origins` 不能设定为 `["*"]`，必须指定源。

`expose_headers` 指示可以被浏览器访问的响应头。默认为 `[]`。

`max_age` 设定为浏览器缓存 CORS 响应的最长时间，单位为秒。默认为 600。

**CORS 预检请求**

这是些带有 `Origin` 和 `Access-Control-Request-Method` 请求头的 `OPTIONS` 请求。

在这种情况下，中间件将拦截传入的请求并进行响应，出于提供信息的目的返回一个使用了适当的 CORS headers 的 `200` 或 `400` 响应。

**简单请求**

任何带有 `Origin` 请求头的请求。在这种情况下，中间件将像平常一样传递请求，但是在响应中包含适当的 CORS headers。
