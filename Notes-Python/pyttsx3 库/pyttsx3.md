# pyttsx3

## 介绍

应用程序调用 `pyttsx3.init()` 函数获取对 `pyttsx3.Engine` 实例的引用。在构造期间，引擎初始化一个 `pyttsx3.driver.DriverProxy` 对象，该对象负责从 `pyttsx3.driver` 模块加载语音引擎驱动程序实现。构造完成后，应用程序使用引擎对象来注册和取消注册事件回调；产生和停止语音；获取和设置语音引擎属性；启动和停止事件循环。

## The Engine factory

`pyttsx3.init`([*driverName : string*, *debug : bool*]) → pyttsx3.Engine

获取一个引擎实例，该实例将使用给定的驱动程序。如果所请求的驱动程序已被另一个引擎实例使用，则返回该引擎。否则，将创建一个新的引擎。

参数:

1. driverName：`pyttsx3.drivers` 模块的名称，用于加载和使用。默认为当前平台上最佳可用驱动程序：
   - sapi5：Windows 平台的一个应用程序编程接口（API），用于语音识别和文本转语音。
   - nsss：Mac OS X 平台上将文本转换成语音的 API。
   - espeak - 是一个可以在其他平台上将文本转语音的系统。
2. debug：是否启用调试输出。

Raises

1. ImportError：当找不到请求的驱动程序。
2. RuntimeError：当驱动程序初始化失败时。

## 引擎接口（The Engine interface）

### pyttsx3.engine.Engine 类

提供应用程序对文本到语音合成的访问。

#### connect

`connect`(*topic : string*, *cb : callable*) → dict

注册给定主题的通知回调。

参数:

1. topic：事件名称。
2. cb：当事件触发时要调用的函数。

返回：

1. 调用者可以使用的令牌，以便稍后取消订阅回调。

以下是有效的 topic 及其回调定义。

1. `started-utterance`：当引擎开始说一句话时触发。回调函数必须具有以下定义。

   `onStartUtterance`(*name : string*) → None:

   参数：

   - name：与发言相关的名称。

2. `started-word`：当引擎开始说一个单词时触发。回调函数必须具有以下定义。

   `onStartWord`(*name : string*, *location : integer*, *length : integer*)

   参数：

   - name：与发言相关的名称。

3. `finished-utterance`：当引擎完成说话时触发。回调函数必须具有以下定义。

   `onFinishUtterance`(*name : string*, *completed : bool*) → None

   参数：

   - name：与发言相关的名称。
   - completed：如果话语完整输出，则为真。

4. `error`：当引擎遇到错误时触发。回调函数必须具有以下定义。

   `onError`(*name : string*, *exception : Exception*) → None

   参数：

   - name：与导致错误的话语相关的名称。
   - exception：引发的异常。

#### disconnect

`disconnect`(*token : dict*)

取消注册一个通知回调。

参数：

1. token：`connect()` 返回的与要断开连接的回调相关联的令牌。

#### endLoop

`endLoop`() → None

结束一个正在运行的事件循环。如果 `startLoop()` 使用 useDriverLoop 设置为  True，此方法将停止引擎命令的处理并立即退出事件循环。如果它被设置为 False，此方法将停止引擎命令的处理，但调用者必须结束它开始的外部事件循环。

Raises:

1. RuntimeError：当循环不运行时。

#### getProperty

`getProperty`(*name : string*) → object

获取引擎属性的当前值。

参数：

1. name：查询的属性名称。

返回：

此次调用时属性的值。

以下属性名对所有驱动程序都有效。

1. `rate`：每分钟说话的词数，默认为每分钟200个词。
2. `voice`：活跃语音的字符串标识符。
3. `voices`：`pyttsx3.voice.Voice` 描述对象列表。
4. `volume`：浮点音量范围从 0.0 到 1.0（包括1.0），默认值为 1.0。

#### isBusy

`isBusy`() → bool

获取引擎当前是否正忙于说出一句话。

返回：

如果在说话，则为 True，如果不说话，则为 False。

#### runAndWait

`runAndWait`() → None

处理当前排队的所有命令时阻塞。适当地调用引擎通知的回调。当此调用之前排队的所有命令从队列中清空时返回。

#### say

`say`(*text : unicode*, *name : string*) → None

将一个命令排队以说出一句话。根据在此命令之前在队列中设置的属性输出语音。

参数:

1. text：朗读文本。
2. name：与发音关联的名称。包括关于此发音的通知。

#### setProperty

`setProperty`(*name*, *value*) → None

将一个命令排队设置一个引擎属性。新的属性值会影响在此命令之后排队的所有句子。

参数：

1. name：要更改的属性名称。
2. value：设置的值。

以下属性名称对所有驱动程序都有效。

1. `rate`：分钟词数的整数语速。
2. `voice`：活跃语音的字符串标识符。
3. `volume`：浮点音量范围从 0.0 到 1.0（包括 1.0）。

#### startLoop

`startLoop`([*useDriverLoop : bool*]) → None

启动事件循环，在此期间处理排队的命令并触发通知。

参数：

1. useDriverLoop：True 表示使用所选驱动程序提供的循环。False 表示调用者在调用此方法后将进入自己的循环。调用者的循环必须为所使用的驱动程序抽取事件，以便正确传递 pyttsx3通知（例如，SAPI5 需要 COM 消息泵）。默认为 True。

`stop`() → None

停止当前的话语并清空命令队列。

## 语音元数据（The Voice metadata）

### pyttsx3.voice.Voice 类

包含有关语音合成器语音的信息。

1. `age`：声音的年龄（以整数表示）。如果未知，默认为 None。
2. `gender`：声音的性别字符串：male（男）、female（女）或 neutral（中性）。如果未知，默认为 None。
3. `id`：语音的字符串标识符。用于通过 `pyttsx3.engine.Engine.setPropertyValue()` 设置活动语音。此属性始终定义。
4. `languages`：支持此语音的字符串语言列表。默认为未知的空列表。
5. `name`：声音的人类可读名称。如果未知，默认为 None。

## Examples

### 朗读文本

```python
import pyttsx3
engine = pyttsx3.init()
engine.say('Sally sells seashells by the seashore.')
engine.say('The quick brown fox jumped over the lazy dog.')
engine.runAndWait()
```

### 将语音保存到文件

```python
import pyttsx3
engine = pyttsx3.init()
engine.save_to_file('Hello World' , 'test.mp3')
engine.runAndWait()
```

### 监听事件

```python
import pyttsx3

def onStart(name):
    print('starting', name)

def onWord(name, location, length):
    print('word', name, location, length)

def onEnd(name, completed):
    print('finishing', name, completed)

engine = pyttsx3.init()
engine.connect('started-utterance', onStart)
engine.connect('started-word', onWord)
engine.connect('finished-utterance', onEnd)
engine.say('The quick brown fox jumped over the lazy dog.')
engine.runAndWait()
```

输出：

```python
starting None
word None 1 0
finishing None True
```

### 打断一句话

```python
import pyttsx3

def onWord(name, location, length):
    print('word', name, location, length)
    if location > 10:
        engine.stop()

engine = pyttsx3.init()
engine.connect('started-word', onWord)
engine.say('The quick brown fox jumped over the lazy dog.')
engine.runAndWait()
```

### 改变声音

```python
import pyttsx3
engine = pyttsx3.init()
voices = engine.getProperty('voices')
for voice in voices:
    engine.setProperty('voice', voice.id)
    engine.say('The quick brown fox jumped over the lazy dog.')
engine.runAndWait()
```

### 改变语速

```python
import pyttsx3
engine = pyttsx3.init()
rate = engine.getProperty('rate')
engine.setProperty('rate', rate + 50)
engine.say('The quick brown fox jumped over the lazy dog.')
engine.runAndWait()
```

### 改变音量

```python
engine = pyttsx3.init()
volume = engine.getProperty('volume')
engine.setProperty('volume', volume - 0.25)
engine.say('The quick brown fox jumped over the lazy dog.')
engine.runAndWait()
```

### 运行驱动程序事件循环

```python
import pyttsx3

def onStart(name):
    print('starting', name)

def onWord(name, location, length):
    print('word', name, location, length)

def onEnd(name, completed):
    print('finishing', name, completed)
    if name == 'fox':
        engine.say('What a lazy dog!', 'dog')
    elif name == 'dog':
        engine.endLoop()

engine = pyttsx3.init()
engine.connect('started-utterance', onStart)
engine.connect('started-word', onWord)
engine.connect('finished-utterance', onEnd)
engine.say('The quick brown fox jumped over the lazy dog.', 'fox')
engine.startLoop()
```

### 使用外部事件循环

```python
import pyttsx3
engine = pyttsx3.init()
engine.say('The quick brown fox jumped over the lazy dog.', 'fox')
engine.startLoop(False)
# engine.iterate() must be called inside externalLoop()
externalLoop()
engine.endLoop()
```

