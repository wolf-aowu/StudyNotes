# SQL

## 概念

SQL（sequel）：结构化查询语言。几乎所有重要的 DBMS 都支持 SQL。许多 DBMS 厂商通过增加语句或指令，对 SQL 进行了扩展。这种扩展的目的是提供执行特定操作的额外功能或简化方法。虽然这种扩展很有用，但一般都是针对个别 DBMS 的，很少有两个以上的供应商支持这种扩展。 标准 SQL 由 ANSI 标准委员会管理，从而称为 ANSI SQL。所有主要的 DBMS，即使有自己的扩展，也都支持 ANSI SQL。各个实现有自己的名称，如 PL/SQL、Transact-SQL 等。

数据库（database）：保存有组织的数据的容器（通常是一个文件或一组文件）。

数据库管理系统（DBMS）：数据库软件。

表（table）：某种特定类型数据的结构化清单。存储在表中的数据应为<font color = skyblue>同一种类型</font>的数据或清单，否则会使以后检索和访问很困难。在同一个数据库中表名应具有唯一性，但不同的数据库之间可以使用相同的表明。

模式（schema）：关于数据库和表的布局及特性的信息。表具有一些特性，这些特性定义了数据在表中如何存储，包含什么样的数据，数据如何分解，各部分信息如何命名等信息，这组信息被称为模式。模式可以用来描述数据库中特定的表，也可以用来描述整个数据库和其中表的关系。

关键字（keyword）：作为 SQL 组成部分的保留字。关键字不能用作表或列的名字。

子句（clause）：SQL 语句由子句构成，有些子句是必需的，有些则是可选的。一个子句通常由一个关键字加上所提供的数据组成。例如：SELECT 语句的 FROM 子句。

操作符（operator）：用来联结或改变 WHERE 子句中的子句的关键字，也称为<font  color = skyblue>逻辑操作符 （logical operator）</font>。

通配符（wildcard）：用来匹配值的一部分的特殊字符。通配符本身实际上是 SQL 的 WHERE 子句中有特殊含义的字符。在搜索子句中使用通配符，<font color = skyblue>必须使用 LIKE 操作符。</font><font color = skyblue>通配符搜索只能用于文本字段（字符串），非文本数据类型字段不能使用通配符搜索。</font>

搜索模式（search pattern）：由字面值、通配符或两者组合构成的搜索条件。

谓词（predicate）：操作符何时不是操作符？答案是，它作为谓词时。从技术上说，LIKE 是谓词而不是操作符。

### 表

#### 列（column）

<font color = skyblue>正确地将数据分成多列是极为重要的。</font>例如：城市、区、邮政编码应该总是彼此独立的列。通过分解这些数据，才能利用特定的列对数据进行分类和过滤。如果将城市和区组合在一列，则按区进行分类或过滤就会很困难。可以根据自己的具体需求来决定把数据分解到何种程度。例如：一般可以把门牌号和街道名一起存储在地址中，如果有按街道名排序的需求，最好将街道名和门牌号分开。

数据库中每隔列都有相应的数据类型（datatype），它定义了列可以存储哪些数据种类。数据类型限定了可存储在列中的数据种类，<font color = skyblue>防止在数值字段中录入字符值</font>。数据理性还能帮助<font color = skyblue>正确地分类数据</font>，并在<font color = skyblue>优化磁盘</font>使用方面起重要的作用。数据类型是 SQL 不兼容的主要原因。虽然大多数基本数据类型得到了一致的支持，但许多高级的数据类型却没有。更糟的是，偶然会有相同的数据类型在不同的 DBMS 中具有不同的名称。

#### 行（row）

表中的数据是按行存储的，所保存的每个记录存储在自己的行内。

#### 主键（primary key）

一列 或 一组列，其值能够唯一标识表中每一行。

虽然并不是总需要主键，但多数数据库设计者都会保证他们<font color = skyblue>创建的每个表具有一个主键</font>。因为没有主键，更新或删除表中特定行就极为困难，不能保证操作只涉及相关的行。

表中的作为主键的列需要满足以下条件：

1. 任意两行都不具有相同的主键值
2. 每一行都必须具有一个主键值（主键列不允许 NULL 值）
3. 主键列中的值不允许修改或更新
4. 主键值不能重用（如果某行从表中删除，它的主键不能赋给以后的新行）

主键通常定义在表的一列上，但也可以使用多个列一起作为主键。<font color = skyblue>使用多列作为主键时，上述条件必须应用到所有列，所有列值的组合必须时唯一，但单个列的值可以不唯一。</font>

#### 外键

<font color = grass>留坑，后面填</font>

## 语句

### SQL 语句

在处理 SQL 语句时，其中所有空格都被忽略。 SQL 语句可以写成长长的一行，也可以分写在多行。下面这三种写法的作用是一样的。多数 SQL 开发人员认为，将SQL语句分成多行更容易阅读和调试。

``` sql
SELECT prod_name
FROM Products;

SELECT prod_name FROM Products;

SELECT
prod_name
FROM
Products;
```

<font color = skyblue>多条 SQL 语句必须以分号 `;` 分隔。</font>多数 DBMS 不需要在单条 SQL 语句后加分号，但也有 DBMS 可能必须在单条 SQL 语句后加上分 号。当然，如果愿意可以总是加上分号。<font color = skyblue>推荐总是加上分号。</font>

<font color = skyblue>SQL 语句不区分大小写</font>，因此 SELECT 与 select 是相同的。同样，写成 Select 也没有 关系。许多 SQL 开发人员喜欢对 SQL 关键字使用大写，而对列名和表名使用小写，这样做使代码更易于阅读和调试。不过，一定要认识到虽然 SQL 是不区分大小写的，<font color = skyblue>但是表名、列名 和 值可能有所不同，这有赖于具体的 DBMS 及其如何配置。</font>

<font color = skyblue>SQL 语句一般返回原始的、无格式的数据</font>。数据的格式化是表示问题，而不是检索问题。

### 注释

#### 注释的原因

使用注释的原因有以下几点：

1. SQL 语句可能会变长，复杂性增加，就会想添加一些描述性的注释， 便于今后参考，或者供项目后续参与人员参考。这些注释需要嵌入在SQL脚本中，但不能进行实际的 DBMS 处理。 
2. 可能需要用在 SQL 文件开始处， 它可能包含程序员的联系方式、程序描述以及一些说明。
3. 暂时停止要执行的 SQL 代码。如果你碰到一个长 SQL 语句，而只想测试它的一部分，那么应该注释掉一些代码，以便 DBMS 将其视为注释而加以忽略

#### 行内注释

可以使用 `-- ` 或 `#` 进行注释。`-- ` 一般用于描述 CREATE TABLE 语句中的列。

```sql
SELECT prod_name -- 这是一条注释
FROM Products;
# 这是一条注释
SELECT prod_id
FROM Products;
```

#### 多行注释

`/* */` 注释从 `/*` 开始，到 `*/` 结束，`/*` 和 `*/` 之间的任何内容都是注释。这种方式常用于给代码加注释。

```sql
/* SELECT prod_name, vend_id
FROM Products; */
SELECT prod_name
FROM Products;
```

### 检索数据

#### Select

```sql
SELECT prod_name
FROM Products;
```

上述语句利用 SELECT 语句从 Products 表中检索一个名为 prod_name 的列。所需的列名写在 SELECT 关键字之后，FROM 关键字指出从哪个表中检索数据。

<font color = skyblue>在没有明确排序查询结果时，返回的数据没有特定的顺序。</font>返回数据的顺序可能是数据被添加到表中的顺序，也可能不是。数据一般将以它在底层表中出现的顺序显示，这有可能是数据最初添加到表中的顺序。但是，如果数据随后进行过更新或删除，那么这个顺序将会受到DBMS重用回收存储空间的方式的影响。所以只要与下面输出返回相同数目的行，就是正常的。

输出：

```sql
+---------------------+
| prod_name           |
+---------------------+
| Fish bean bag toy   |
| Bird bean bag toy   |
| Rabbit bean bag toy |
| 8 inch teddy bear   |
| 12 inch teddy bear  |
| 18 inch teddy bear  |
| Raggedy Ann         |
| King doll           |
| Queen doll          |
+---------------------+
9 rows in set (0.00 sec)
```

#### 检索多列

要想从一个表中检索多个列，仍然使用相同的 SELECT 语句。唯一的不同是必须在 SELECT 关键字后给出多个列名，<font color = skyblue>列名之间必须以逗号分隔，最有一个列名不能加逗号</font>。

``` sql
SELECT prod_id, prod_name, prod_price
FROM Products;
```

这条语句使用 SELECT 语句从表 Products 中选择数据。

输出：

```sql
+---------+---------------------+------------+
| prod_id | prod_name           | prod_price |
+---------+---------------------+------------+
| BNBG01  | Fish bean bag toy   |       3.49 |
| BNBG02  | Bird bean bag toy   |       3.49 |
| BNBG03  | Rabbit bean bag toy |       3.49 |
| BR01    | 8 inch teddy bear   |       5.99 |
| BR02    | 12 inch teddy bear  |       8.99 |
| BR03    | 18 inch teddy bear  |      11.99 |
| RGAN01  | Raggedy Ann         |       4.99 |
| RYL01   | King doll           |       9.49 |
| RYL02   | Queen doll          |       9.49 |
+---------+---------------------+------------+
9 rows in set (0.00 sec)
```

从上述输出可以看到，<font color = skyblue>SQL 语句一般返回原始的、无格式的数据</font>。数据的格式化是表示问题，而不是检索问题。因此，表示（如把上面的价格值显示为正确的十进制数值货币金额）一般在显示该数据的应用程序中规定。通常很少直接使用实际检索出的数据（没有应用程序提供的格式）。

#### 检索所有列

```sql
SELECT *
FROM Products;
```

如果给定一个通配符 `*`，则返回表中所有列。<font color = skyblue> 列的顺序一般是列在表定义中出现的物理顺序，但并不总是如此。</font>不过，SQL数据很少这样（通常，数据返回给应用程序，根据需要进行格式化，再表示出来）。因此，这不应该造成什么问题。

输出：

```sql
+---------+---------+---------------------+
| prod_id | vend_id | prod_name           |
+---------+---------+---------------------+
| BNBG01  | DLL01   | Fish bean bag toy   |
| BNBG02  | DLL01   | Bird bean bag toy   |
| BNBG03  | DLL01   | Rabbit bean bag toy |
| BR01    | BRS01   | 8 inch teddy bear   |
| BR02    | BRS01   | 12 inch teddy bear  |
| BR03    | BRS01   | 18 inch teddy bear  |
| RGAN01  | DLL01   | Raggedy Ann         |
| RYL01   | FNG01   | King doll           |
| RYL02   | FNG01   | Queen doll          |
+---------+---------+---------------------+

+------------+-----------------------------------------------------------------------+
| prod_price | prod_desc                                                             |
+------------+-----------------------------------------------------------------------+
|       3.49 | Fish bean bag toy, complete with bean bag worms with which to feed it |
|       3.49 | Bird bean bag toy, eggs are not included                              |
|       3.49 | Rabbit bean bag toy, comes with bean bag carrots                      |
|       5.99 | 8 inch teddy bear, comes with cap and jacket                          |
|       8.99 | 12 inch teddy bear, comes with cap and jacket                         |
|      11.99 | 18 inch teddy bear, comes with cap and jacket                         |
|       4.99 | 18 inch Raggedy Ann doll                                              |
|       9.49 | 12 inch king doll with royal garments and crown                       |
|       9.49 | 12 inch queen doll with royal garments and crown                      |
+------------+-----------------------------------------------------------------------+
9 rows in set (0.00 sec)
```

由于表太宽了，显示效果不好，将它分成了两张表，实际输出是一张表。

<font color = orange>注意</font>：一般，除非确实需要表中的每一列，否则<font color = skyblue>最好别使用 `*` 通配符</font>。虽然使用通配符能省事，不用明确列出所需列，但检索不需要的列通常会<font color = skyblue>降低检索和应用程序的性能</font>。

<font color = orange>优点</font>：使用通配符能<font color = skyblue>检索出名字未知的列</font>。因为不用明确指定列名，就能检索出所有列。

#### 检索不同的值

```sql
SELECT vend_id
FROM Products;
```

输出：

```sql
+---------+
| vend_id |
+---------+
| BRS01   |
| BRS01   |
| BRS01   |
| DLL01   |
| DLL01   |
| DLL01   |
| DLL01   |
| FNG01   |
| FNG01   |
+---------+
9 rows in set (0.06 sec)
```

检索 products 表中所有产品供应商的 ID，通过上方输出可以发现相同的供应商 ID 出现了多次，一共出现了 9 条结果，但实际只有 3 个不同的供应商。如果只希望提取不同的供应商 ID，<font color = skyblue>需要使用 DISTINCT 关键字。如果使用 DISTINCT 关键字，它必须直接放在列名的前面。</font><font color = skyblue>

```sql
SELECT DISTINCT vend_id
FROM Products;
```

输出：

```sql
+---------+
| vend_id |
+---------+
| BRS01   |
| DLL01   |
| FNG01   |
+---------+
3 rows in set (0.00 sec)
```

<font color = skyblue>DISTINCT 关键字作用于所有的列</font>，不仅仅是跟在其后的那一列。例如，你指定SELECT DISTINCT vend_id, prod_price，除非指定的两列完全相同，否则所有的行都会被检索出来。例如：vend_id = DLL01 且 prod_price = 3.49 的一共有 3 行，实际只输出了一行。而 vend_id  = BRS01 的行数一共有 3 行，由于 prod_price 都互不相同，所以都被输出了。

```sql
SELECT DISTINCT vend_id, prod_price
FROM Products;
```

输出：

```sql
+---------+------------+
| vend_id | prod_price |
+---------+------------+
| DLL01   |       3.49 |
| BRS01   |       5.99 |
| BRS01   |       8.99 |
| BRS01   |      11.99 |
| DLL01   |       4.99 |
| FNG01   |       9.49 |
+---------+------------+
6 rows in set (0.00 sec)
```

#### 限制结果（输出特定行数）

SELECT 语句返回指定表中所有匹配的行，很可能是每一行。如果只想<font color = skyblue>返回第一行或者一定数量的行</font>是可行的，但是<font color = skyblue>各种数据库中的这一 SQL 实现并不相同</font>。 在 SQL Server 和 Access 中使用 <font color = skyblue>SELECT</font> 时，可以 使用 TOP 关键字来限制最多返回多少行；在 DB2 中则应使用 <font color = skyblue>FETCH FRIST 5 ROWS ONLY</font> 关键字；使用 Oracle，需要基于 <font color = skyblue>ROWNUM</font>（行计数器）来计算行；使用用 MySQL、MariaDB、PostgreSQL 或者 SQLite，需要使用 <font color = skyblue>LIMIT</font> 子句。

在 SQL Server 和 Access 中：

```sql
SELECT TOP 5 prod_name
FROM Products;
```

在 DB2 中：

```sql
SELECT prod_name
FROM Products
FETCH FIRST 5 ROWS ONLY;
```

在 Oracle 中：

```sql
SELECT prod_name
FROM Products
WHERE ROWNUM <=5;
```

在 MySQL、MariaDB、PostgreSQL 或者 SQLite 中：

```sql
SELECT prod_name
FROM Products
LIMIT 5;
```

<font color = skyblue>如果需要指定从哪开始检索行数。</font>以得到第 6 行到第 10 行的数据举例。在  MySQL、MariaDB、PostgreSQL 或者 SQLite 中使用<font color = skyblue> LIMIT 5 OFFSET 5</font>，<font color = skyblue>第一个数字是指从哪儿开始，第二个数字是检索的行数。</font><font color = skyblue>第一个被检索的行是第 0 行</font>，而不是第 1 行。因此，LIMIT 1 OFFSET 1 会检索第 2 行，而不是第 1 行。

```sql
SELECT prod_name
FROM Products
LIMIT 5 OFFSET 5;
```

输出：

```sql
+--------------------+
| prod_name          |
+--------------------+
| 18 inch teddy bear |
| Raggedy Ann        |
| King doll          |
| Queen doll         |
+--------------------+
4 rows in set (0.00 sec)
```

Products 表中只有 9 种产品，所以 LIMIT 5 OFFSET 5 只返回了4行数据。

MySQL 和 MariaDB 支持简化版的 LIMIT 4 OFFSET 3 语句，即<font color = skyblue> LIMIT 3,4</font>。使用这个语法，`,`之前的值对应 LIMIT，` ,` 之后的值对应 OFFSET。

```sql
SELECT prod_name
FROM Products
LIMIT 3,4;
```

输出：

```sql
+--------------------+
| prod_name          |
+--------------------+
| 8 inch teddy bear  |
| 12 inch teddy bear |
| 18 inch teddy bear |
| Raggedy Ann        |
+--------------------+
4 rows in set (0.00 sec)
```

### 排序检索数据

#### 排序数据

我们可以使用 ORDER BY 子句排序检索出的数据。ORDER BY 子句取一个或多个列的名字，据此对输出进行排序。例如，根据 prod_name 列以字母顺序排序数据。

``` sql
SELECT prod_name
FROM Products
ORDER BY prod_name;
```

输出：

```sql
+---------------------+
| prod_name           |
+---------------------+
| 12 inch teddy bear  |
| 18 inch teddy bear  |
| 8 inch teddy bear   |
| Bird bean bag toy   |
| Fish bean bag toy   |
| King doll           |
| Queen doll          |
| Rabbit bean bag toy |
| Raggedy Ann         |
+---------------------+
9 rows in set (0.00 sec)
```

<font color = orange>注意</font>：在指定一条 ORDER BY 子句时，应该保证它是 SELECT 语句中最后一条子句。如果它不是最后的子句，将会出现错误消息。

通常，ORDER BY 子句中使用的列将是为显示而选择的列。但是，实际上并不一定要这样，<font color=skyblue>用非检索的列排序数据是完全合法的</font>。

#### 按多个列排序

经常需要按不止一个列进行数据排序。例如， 如果要显示雇员名单，可能希望按姓和名排序（首先按姓排序，然后在每个姓中再按名排序）。如果多个雇员有相同的姓，这样做很有用。 要按多个列排序，简单指定列名，列名之间用逗号分开即可（就像选择多个列时那样）。 下面的代码检索 3 个列，并按其中两个列对结果 进行排序——首先按价格，然后按名称排序。

``` sql
SELECT prod_id, prod_price, prod_name
FROM Products
ORDER BY prod_price, prod_name;
```

输出：

``` sql
+---------+------------+---------------------+
| prod_id | prod_price | prod_name           |
+---------+------------+---------------------+
| BNBG02  |       3.49 | Bird bean bag toy   |
| BNBG01  |       3.49 | Fish bean bag toy   |
| BNBG03  |       3.49 | Rabbit bean bag toy |
| RGAN01  |       4.99 | Raggedy Ann         |
| BR01    |       5.99 | 8 inch teddy bear   |
| BR02    |       8.99 | 12 inch teddy bear  |
| RYL01   |       9.49 | King doll           |
| RYL02   |       9.49 | Queen doll          |
| BR03    |      11.99 | 18 inch teddy bear  |
+---------+------------+---------------------+
9 rows in set (0.00 sec)
```

#### 按列位置排序

除了能用列名指出排序顺序外，ORDER BY 还支持按相对列位置进行排序。SELECT 清单中指定的是选择列的相对位置而不是列名。ORDER BY 2 表示 按 SELECT 清单中的第 2 列 prod_name 进行排序。ORDER BY 2，3 表示先按 prod_price，再按 prod_name 进行排序。所以，下面例子与上面 ORDER BY  prod_price, prod_name 的结果是相同的。

``` sql
SELECT prod_id, prod_price, prod_name
FROM Products
ORDER BY 2, 3;
```

输出：

``` sql
+---------+------------+---------------------+
| prod_id | prod_price | prod_name           |
+---------+------------+---------------------+
| BNBG02  |       3.49 | Bird bean bag toy   |
| BNBG01  |       3.49 | Fish bean bag toy   |
| BNBG03  |       3.49 | Rabbit bean bag toy |
| RGAN01  |       4.99 | Raggedy Ann         |
| BR01    |       5.99 | 8 inch teddy bear   |
| BR02    |       8.99 | 12 inch teddy bear  |
| RYL01   |       9.49 | King doll           |
| RYL02   |       9.49 | Queen doll          |
| BR03    |      11.99 | 18 inch teddy bear  |
+---------+------------+---------------------+
9 rows in set (0.00 sec)
```

这一技术的主要好处在于不用重新输入列名。 但它也有缺点。首先，不明确给出列名有可能造成错用列名排序。其次，在对 SELECT 清单进行更改时容易错误地对数据进行排序（忘记对 ORDER BY 子句做相应的改动）。最后，如果进行排序的列不在 SELECT 清单中，显然不能使用这项技术。但是，如果有必要，可以混合匹配使用实际列名和相对列位置。所以更推荐 ORDER BY 夹列名。

#### 指定排序方向

数据排序不限于升序排序（从 A 到 Z），这只是默认的排序顺序。还可以使用 ORDER BY 子句进行降序（从Z 到 A）排序。为了进行降序排序，必须指定 DESC 关键字。DESC 是 DESCENDING 的缩写，这两个关键字都可以使用。与 DESC 相对的是ASC（或 ASCENDING），在升序排序时可以指定它。如果不指定排序方向，默认是升序排序。

``` sql
SELECT prod_id, prod_price, prod_name
FROM Products
ORDER BY prod_price DESC;
```

输出：

```sql
+---------+------------+---------------------+
| prod_id | prod_price | prod_name           |
+---------+------------+---------------------+
| BR03    |      11.99 | 18 inch teddy bear  |
| RYL01   |       9.49 | King doll           |
| RYL02   |       9.49 | Queen doll          |
| BR02    |       8.99 | 12 inch teddy bear  |
| BR01    |       5.99 | 8 inch teddy bear   |
| RGAN01  |       4.99 | Raggedy Ann         |
| BNBG01  |       3.49 | Fish bean bag toy   |
| BNBG02  |       3.49 | Bird bean bag toy   |
| BNBG03  |       3.49 | Rabbit bean bag toy |
+---------+------------+---------------------+
9 rows in set (0.00 sec)
```

如果打算进行多列排序，<font color = skyblue>DESC 关键字只应用到直接位于其前面的列名。如果需要对多列进行降序排序，必须对每一个列指定 DESC 关键字。</font>例如：按 prod_price 降序，相同价格的按 prod_name 升序。

``` sql
SELECT prod_id, prod_price, prod_name
FROM Products
ORDER BY prod_price DESC, prod_name;
```

输出：

```sql
+---------+------------+---------------------+
| prod_id | prod_price | prod_name           |
+---------+------------+---------------------+
| BR03    |      11.99 | 18 inch teddy bear  |
| RYL01   |       9.49 | King doll           |
| RYL02   |       9.49 | Queen doll          |
| BR02    |       8.99 | 12 inch teddy bear  |
| BR01    |       5.99 | 8 inch teddy bear   |
| RGAN01  |       4.99 | Raggedy Ann         |
| BNBG02  |       3.49 | Bird bean bag toy   |
| BNBG01  |       3.49 | Fish bean bag toy   |
| BNBG03  |       3.49 | Rabbit bean bag toy |
+---------+------------+---------------------+
9 rows in set (0.00 sec)
```

<font color = skyblue>注意</font>：A 与 a 相同吗？a 位于 B 之前，还是 Z 之后？这些问题不是理论问题，其答案取决于数据库的设置方式。在字典（dictionary）排序顺序中，A 被视为与 a 相同，这是大多数数据库管理系统的默认行为。但是，许多 DBMS 允许数据库管理员在需要时改变这种行为（如果你的数据库包含大量外语字符，可能必须这样做）。 这里的关键问题是，如果确实需要改变这种排序顺序，<font color = orange>用简单的 ORDER BY 子句可能做不到。</font>你必须请求数据库管理员的帮助。

### 过滤数据

数据库表一般包含大量的数据，很少需要检索表中的所有行。通常只会根据特定操作或报告的需要提取表数据的子集。只检索所需数据需要指定搜索条件（search criteria），搜索条件也称为过滤条件（filter condition）。

#### Where 子句

在 SELECT 语句中，数据根据 WHERE 子句中指定的搜索条件进行过滤。WHERE 子句在表名（FROM 子句）之后给出。例如，从products 表中检索两个列，但不返回所有行，只返回 prod_price 值为 3.49 的行。

```sql
SELECT prod_name, prod_price
FROM Products
WHERE prod_price = 3.49;
```

输出：

```sql
+---------------------+------------+
| prod_name           | prod_price |
+---------------------+------------+
| Fish bean bag toy   |       3.49 |
| Bird bean bag toy   |       3.49 |
| Rabbit bean bag toy |       3.49 |
+---------------------+------------+
3 rows in set (0.04 sec)
```

<font color = skyblue>DBMS 指定了所使用的数据类型及其默认行为。所以，不同的 DBMS 返回的 prod_price 可能不同，</font>例如： 3.49、3.490、3.4900等。从数学角度上 3.49 和 3.4900 是一样的，所以不必焦虑。

数据也可以在应用层过滤。SQL 的 SELECT 语句会被客户端应用检索出超过实际所需的数据，然后客户端代码对返回数据进行循环，提取出需要的行。 例如，使用 SELECT 获取所有行，再通过 Python 循环读取每一行的数据判断筛选需要的行。通常，这种做法极其不妥。优化数据库后可以更快速有效地对数据进行过滤。而让客户端应用（或开发语言）处理数据库的工作将会极大地影响应用的性能，并且使所创建的应用完全不具备可伸缩性。此外，如果在客户端过滤数据，服务器不得不通过网络发送多余的数据，这将导致网络带宽的浪费。所以，<font color = skyblue>能通过 SQL 实现的过滤尽量用 SQL 过滤得到结果</font>。

<font color = orange>注意</font>：在同时使用 ORDER BY 和 WHERE 子句时，应该让 ORDER BY 位于 WHERE 之后，否则将会产生错误 。

#### Where 子句操作符

| 操作符  | 说明               |
| ------- | ------------------ |
| =       | 等于               |
| <>      | 不等于             |
| !=      | 不等于             |
| <       | 小于               |
| <=      | 小于等于           |
| !<      | 不小于             |
| >       | 大于               |
| >=      | 大于等于           |
| !>      | 不大于             |
| BETWEEN | 在指定的两个值之间 |
| IS NULL | 为 NULL 值         |

<font color = orange>注意</font>：上表中的某些操作符是冗余的（例如，<> 和 !=，!< 相当于 >=）

<font color = skyblue>许多 DBMS 扩展了标准的操作符集，提供了更高级的过滤选择。</font>更多信息请参阅相应的 DBMS 文档。

#### 检查单个值

列出所有价格小于 10 美元的产品

``` sql
SELECT prod_name, prod_price
FROM Products
WHERE prod_price < 10; 
```

输出：

``` sql
+---------------------+------------+
| prod_name           | prod_price |
+---------------------+------------+
| Fish bean bag toy   |       3.49 |
| Bird bean bag toy   |       3.49 |
| Rabbit bean bag toy |       3.49 |
| 8 inch teddy bear   |       5.99 |
| 12 inch teddy bear  |       8.99 |
| Raggedy Ann         |       4.99 |
| King doll           |       9.49 |
| Queen doll          |       9.49 |
+---------------------+------------+
8 rows in set (0.03 sec)
```

检索所有价格小于等研究 10 美元的产品，由于没有价格刚好是 10 美元的产品，所以结果与上一个例子相同

```sql
SELECT prod_name, prod_price
FROM Products
WHERE prod_price <= 10;
```

输出：

```sql
+---------------------+------------+
| prod_name           | prod_price |
+---------------------+------------+
| Fish bean bag toy   |       3.49 |
| Bird bean bag toy   |       3.49 |
| Rabbit bean bag toy |       3.49 |
| 8 inch teddy bear   |       5.99 |
| 12 inch teddy bear  |       8.99 |
| Raggedy Ann         |       4.99 |
| King doll           |       9.49 |
| Queen doll          |       9.49 |
+---------------------+------------+
8 rows in set (0.00 sec)
```

#### 不匹配检查

列出所有不是供应商 DLL01 制造的产品。由于 DLL01 是字符串类型，所以需要使用单引号括起来，数值类型不需要使用单引号。

``` sql
SELECT vend_id, prod_name
FROM Products
WHERE vend_id <> 'DLL01';
```

输出：

```sql
+---------+--------------------+
| vend_id | prod_name          |
+---------+--------------------+
| BRS01   | 8 inch teddy bear  |
| BRS01   | 12 inch teddy bear |
| BRS01   | 18 inch teddy bear |
| FNG01   | King doll          |
| FNG01   | Queen doll         |
+---------+--------------------+
5 rows in set (0.03 sec)
```

使用 != 的结果与 <> 的结果是相同的。<font color = skyblue>!= 和 <> 通常可以互换。</font>但是，并非所有  DBMS 都支持这两种不等于操作符。<font color = skyblue>使用前请参阅相应的 DBMS 文档。</font>MySQL 两者都支持。

```sql
SELECT vend_id, prod_name
FROM Products
WHERE vend_id != 'DLL01';
```

#### 范围值检查

要检查某个范围的值，可以使用 BETWEEN 操作符。它需要有两个值，开始值和结束值。这两个值必须用 AND 关键字分隔。BETWEEN 匹配范围中所有的值，包括指定的开始值和结束值。例如，BETWEEN 操作符可用来检索价格在 5 美元和 10 美元之间的所有产品，或在指定的开始日期和结束日期之间的所有日期。

```sql
SELECT prod_name, prod_price
FROM Products
WHERE prod_price BETWEEN 5 AND 10;
```

输出：

```sql
+--------------------+------------+
| prod_name          | prod_price |
+--------------------+------------+
| 8 inch teddy bear  |       5.99 |
| 12 inch teddy bear |       8.99 |
| King doll          |       9.49 |
| Queen doll         |       9.49 |
+--------------------+------------+
4 rows in set (0.00 sec)
```

#### 空值检查

在创建表时，表设计人员可以指定其中的列能否不包含值。在一个列不包含值时，称其包含空值 NULL。NULL，无值（no value），它与字段包含 0、空字符串或仅仅包含空格不同。<font color = orange>确定值是否为 NULL，不能简单地检查是否等于 NULL。</font>SELECT 语句有一个特殊的 WHERE 子句，可用来检查具有 NULL 值的列。<font color = skyblue>这个 WHERE 子句就是 IS NULL 子句。</font>

```sql
SELECT prod_name
FROM Products
WHERE prod_price IS NULL;
```

输出：

```sql
Empty set (0.00 sec)
```

这条语句返回所有没有价格（空 prod_price 字段，不是价格为 0）的产品，由于表中没有这样的行，所以没有返回数据。

但是，Customers 表确实包含具有 NULL 值的列：如果没有电子邮件地址，则  cust_email 列将包含 NULL 值。

```sql
SELECT cust_name
FROM Customers
WHERE cust_email IS NULL; 
```

输出：

```sql
+---------------+
| cust_name     |
+---------------+
| Kids Place    |
| The Toy Store |
+---------------+
2 rows in set (0.00 sec)
```

<font color = orange>通过过滤选择不包含指定值的所有行时，你可能希望返回含 NULL 值的行。但是这做不到。</font>因为 NULL 比较特殊，所以在进行匹配过滤或非匹配过滤时，不会返回这些结果。

### 高级数据过滤

#### 组合 WHERE 子句

为了进行更强的过滤控制，SQL 允许给出多个  WHERE 子句。这些子句有两种使用方式，即以  AND 子句或 OR 子句的方式使用。

##### AND 操作符

要通过不止一个列进行过滤，可以使用 AND 操作符给 WHERE 子句附加条件。<font color = skyblue>AND 是用在 WHERE 子句中的关键字</font>，用来指示检索满足所有给定条件的行。<font color = orange>如果需要用到 ORDER BY 子句，它应该放在 WHERE 子句之后。</font>

检索由供应商 DLL01 制造且价格小于等于 4 美元的所有产品的名称和价格。这条 SELECT 语句中的 WHERE 子句包含两个条件，用 AND 关键字联结在一起。AND 指示 DBMS 只返回满足所有给定条件的行。如果某个产品由供应商 DLL01 制造，但价格高于 4 美元，则不检索它。类似地，如果产品价格小于 4 美元，但不是由指定供应商制造的也不被检索。

``` sql
SELECT prod_id, prod_price, prod_name
FROM Products
WHERE vend_id = 'DLL01' AND prod_price <= 4;
```

输出：

```sql
+---------+------------+---------------------+
| prod_id | prod_price | prod_name           |
+---------+------------+---------------------+
| BNBG01  |       3.49 | Fish bean bag toy   |
| BNBG02  |       3.49 | Bird bean bag toy   |
| BNBG03  |       3.49 | Rabbit bean bag toy |
+---------+------------+---------------------+
3 rows in set (0.00 sec)
```

##### OR 操作符

OR 是 WHERE 子句中使用的关键字，OR 操作符指示 DBMS 检索匹配任一条件的行。许多 DBMS 在 OR WHERE 子句的第一个条件得到满足的情况下，就不再计算第二个条件了（在第一个条件满足时，不管第二个条 件是否满足，相应的行都将被检索出来）。

检索由任一个指定供应商制造的所有产品的产品名和价格。

```sql
SELECT prod_id, prod_price, prod_name
FROM Products
WHERE vend_id = 'DLL01' OR vend_id = 'BRS01';
```

输出：

```sql
+---------+------------+---------------------+
| prod_id | prod_price | prod_name           |
+---------+------------+---------------------+
| BR01    |       5.99 | 8 inch teddy bear   |
| BR02    |       8.99 | 12 inch teddy bear  |
| BR03    |      11.99 | 18 inch teddy bear  |
| BNBG01  |       3.49 | Fish bean bag toy   |
| BNBG02  |       3.49 | Bird bean bag toy   |
| BNBG03  |       3.49 | Rabbit bean bag toy |
| RGAN01  |       4.99 | Raggedy Ann         |
+---------+------------+---------------------+
7 rows in set (0.02 sec)
```

##### AND 与 OR 的求值顺序

WHERE 子句可以包含任意数目的 AND 和 OR 操作符。允许两者结合以进行复杂、高级的过滤。<font color = skyblue>SQL 在处理 OR 操作符前，优先处理 AND 操作符。可以使用圆括号改变操作符求值顺序，进行正确分组。</font>圆括号具有比 AND 或 OR 操作符更高的优先级。

列出由供应商 BRS01 制造的价格为 10 美元以上的所有产品，以及由供应商 DLL01 制造的所有产品。（可以与下一个例子对比就能发现不同）

```sql
SELECT prod_name, prod_price
FROM Products
WHERE vend_id = 'DLL01' OR vend_id = 'BRS01'
      AND prod_price >= 10;
```

输出：

```sql
+---------------------+------------+
| prod_name           | prod_price |
+---------------------+------------+
| 18 inch teddy bear  |      11.99 |
| Fish bean bag toy   |       3.49 |
| Bird bean bag toy   |       3.49 |
| Rabbit bean bag toy |       3.49 |
| Raggedy Ann         |       4.99 |
+---------------------+------------+
5 rows in set (0.00 sec)
```

列出价格为10 美元及以上，且由 DLL01 或 BRS01 制造的所有产品。使用圆括号改变了求值顺序。

```sql
SELECT prod_name, prod_price
FROM Products
WHERE (vend_id = 'DLL01' OR vend_id = 'BRS01')
      AND prod_price >= 10;
```

输出：

```sql
+--------------------+------------+
| prod_name          | prod_price |
+--------------------+------------+
| 18 inch teddy bear |      11.99 |
+--------------------+------------+
1 row in set (0.00 sec)
```

任何时候使用具有 AND 和 OR 操作符的 WHERE 子句，<font color = orange>都应该使用圆括号明确地分组操作符。</font>不要过分依赖默认求值顺序，即使它确实如你希望的那样。使用圆括号没有什么坏处，它能消除歧义。

#### IN 操作符

IN 操作符用来指定条件范围，范围中的每个条件都可以进行匹配。IN 取一组由逗号分隔、括在圆括号中的合法值。IN 操作符后跟由逗号分隔的合法值，这些值必须括在圆括号中。 IN 操作符功能与 OR 相当。

使用 IN 操作符的优点：

1. 在有很多合法选项时，IN 操作符的语法更清楚，更直观。
2. 在与其他 AND 和 OR 操作符组合使用 IN 时，求值顺序更容易管理。
3. <font color = orange>IN 操作符一般比一组 OR 操作符执行得更快</font>。
4. IN 的最大优点是可以包含其他 SELECT 语句，能够更动态地建立 WHERE 子句。

检索由供应商 DLL01 和 BRS01 制造的所有产品。

```sql
SELECT prod_name, prod_price
FROM Products
WHERE vend_id IN ('DLL01','BRS01')
ORDER BY prod_name;
```

输出：

```sql
+---------------------+------------+
| prod_name           | prod_price |
+---------------------+------------+
| 12 inch teddy bear  |       8.99 |
| 18 inch teddy bear  |      11.99 |
| 8 inch teddy bear   |       5.99 |
| Bird bean bag toy   |       3.49 |
| Fish bean bag toy   |       3.49 |
| Rabbit bean bag toy |       3.49 |
| Raggedy Ann         |       4.99 |
+---------------------+------------+
7 rows in set (0.00 sec)
```

使用 OR 花了 0.02 秒，而 IN 只花了 0.00 秒。

#### NOT 操作符

WHERE 子句中的 NOT 操作符有且只有一个功能，那就是否定其后所跟的任何条件。NOT 从不单独使用（它总是与其他操作符一起使用）。NOT 关键字可以用在要过滤的列前， 而不仅是在其后。

列出除 DLL01 之外的所有供应商制造的产品

```sql
SELECT prod_name
FROM Products
WHERE NOT vend_id = 'DLL01'
ORDER BY prod_name;
```

输出：

```sql
+--------------------+
| prod_name          |
+--------------------+
| 12 inch teddy bear |
| 18 inch teddy bear |
| 8 inch teddy bear  |
| King doll          |
| Queen doll         |
+--------------------+
5 rows in set (0.00 sec)
```

上面例子中的 NOT 可以替换为 <>，结果是相同的。

```sql
SELECT prod_name
FROM Products
WHERE vend_id <> 'DLL01'
ORDER BY prod_name;
```

输出：

```sql
+--------------------+
| prod_name          |
+--------------------+
| 12 inch teddy bear |
| 18 inch teddy bear |
| 8 inch teddy bear  |
| King doll          |
| Queen doll         |
+--------------------+
5 rows in set (0.00 sec)
```

NOT 在更复杂的子句中是非常有用的的。例如，在 与 IN 操作符联合使用时，NOT 可以非常简单地找出与条件列表不匹配的行。

<font color = orange>注意</font>：MariaDB 支持使用 NOT 否定 IN、BETWEEN 和 EXISTS 子句。大多数 DBMS  允许使用 NOT 否定任何条件。

### 通配符过滤

#### LIKE 操作符

利用通配符，可以创建比较特定数据的搜索模式。例如，找出名称包含 bean bag 的所有产品，可以构造一个通配符搜索模式，找出在产品名的任何位置出现 bean bag 的产品。在搜索子句中使用通配符，<font color = skyblue>必须使用 LIKE 操作符。</font>LIKE 指示 DBMS，后跟的搜索模式利用通配符匹配而不是简单的相等匹配进行比较。<font color = skyblue>通配符搜索只能用于文本字段（字符串），非文本数据类型字段不能使用通配符搜索。</font>

#### % 通配符

最常使用的通配符是百分号（%）。在搜索串中，%表示任何字符出现任意次数。% 除了能匹配一个或多个字符外，%还能匹配 0 个字符。

找出所有以词 Fish 起头的产品。%告诉 DBMS 接受 Fish 之后的任意字符，不管它有多少字符。

``` sql
SELECT prod_id, prod_name 
FROM Products 
WHERE prod_name LIKE 'Fish%';
```

输出：

```sql
+---------+-------------------+
| prod_id | prod_name         |
+---------+-------------------+
| BNBG01  | Fish bean bag toy |
+---------+-------------------+
1 row in set (0.00 sec)
```

<font color = orange>注意</font>：根据 DBMS 的不同及其配置，搜索可以是区分大小写的。如果区分大小写，则 fish% 与 Fish bean bag toy 就不匹配。

<font color = skyblue>通配符可在搜索模式中的任意位置使用，并且可以使用多个通配符。</font>下面的例子使用两个通配符，它们位于模式的两端。

找出名称包含 bean bag 的所有产品，可以构造一个通配符搜索模式，找出在产品名的任何位置出现 bean bag 的产品。

``` sql
SELECT prod_id, prod_name 
FROM Products 
WHERE prod_name LIKE '%bean bag%';
```

输出：

```sql
+---------+---------------------+
| prod_id | prod_name           |
+---------+---------------------+
| BNBG01  | Fish bean bag toy   |
| BNBG02  | Bird bean bag toy   |
| BNBG03  | Rabbit bean bag toy |
+---------+---------------------+
3 rows in set (0.00 sec)
```

<font color = skyblue>通配符也可以出现在搜索模式的中间</font>，虽然这样做不太有用。

找出以 F 起头、以 y 结尾的所有产品。

```sql
SELECT prod_name
FROM Products
WHERE prod_name LIKE 'F%y';
```

输出：

```sql
+-------------------+
| prod_name         |
+-------------------+
| Fish bean bag toy |
+-------------------+
1 row in set (0.00 sec)
```

<font color = orange>注意</font>：有些 DBMS 用空格来填补字段的内容。例如，<font color = skyblue>如果某列有 50 个字符， 而存储的文本为 Fish bean bag toy（17 个字符），则为填满该列需要在文本后附加 33 个空格。这样做一般对数据及其使用没有影响，但是可能对上述 SQL 语句有负面影响。子句 WHERE prod_name LIKE  'F%y' 只匹配以 F 开头、以 y 结尾的 prod_name。如果值后面跟空格， 则不是以 y 结尾，所以 Fish bean bag toy 就不会检索出来。</font>简单的解决办法是给搜索模式再增加一个 % 号：'F%y%' 还匹配 y 之后的字符（或空格）。<font color = skyblue>更好的解决办法是用函数去掉空格。</font>

<font color = orange>注意</font>：通配符 % 不会匹配 NULL。子句 WHERE prod_name LIKE '%'不会匹配产品名称为 NULL 的行。

<font color = orange>根据邮件地址的一部分来查找电子邮件时使用通配符是很有用的。</font>

```sql
WHERE email LIKE 'b%@forta.com'
```

####  _ 通配符

下划线的用途与 % 一样，但它只匹配单个字符，而不是多个字符。_ 总是刚好匹配一个字符，不能多也不能少。<font color = skyblue>DB2 不支持通配符_。</font>

```sql
SELECT prod_id, prod_name
FROM Products
WHERE prod_name LIKE '__ inch teddy bear';
```

输出：

``` sql
+---------+--------------------+
| prod_id | prod_name          |
+---------+--------------------+
| BR02    | 12 inch teddy bear |
| BR03    | 18 inch teddy bear |
+---------+--------------------+
2 rows in set (0.00 sec)
```

<font color = orange>注意</font>：与 % 通配符一样，要小心有些 DBMS 用空格来填补字段的内容。

#### [] 通配符

方括号（[]）通配符用来指定一个字符集，它必须匹配指定位置（通配符的位置）的一个字符。 <font color = orange>并不是所有 DBMS 都支持用来创建集合的 []。微软的 SQL Server 支持集合，但是 MySQL，Oracle，DB2，SQLite 都不支持。</font>为确定使用的 DBMS 是否支持集合，请参阅相应的文档。

找出所有名字以 J 或 M 起头的联系人。[JM] 匹配方括号中任意一个字符，它也只能匹配单个字符。[JM] 之后的%通配符匹配第 一个字符之后的任意数目的字符。

```sql
SELECT cust_contact 
FROM Customers 
WHERE cust_contact LIKE '[JM]%' 
ORDER BY cust_contact;
```

输出：

```sql
+-------------------+
| cust_contact      |
+-------------------+
| Jim Jones         |
| John Smith        |
| Michelle Green    |
+-------------------+
```

_ 通配符可以用前缀字符^ （脱字号）来否定。J 和 M 之外的任意字符起头的任意联系人名。

```sql
SELECT cust_contact
FROM Customers
WHERE cust_contact LIKE '[^JM]%'
ORDER BY cust_contact;
```

也可以使用 NOT 操作符得出类似的结果。^ 的唯一优点是在使用多个 WHERE 子句时可以简化语法。

```sql
SELECT cust_contact
FROM Customers
WHERE NOT cust_contact LIKE '[JM]%'
ORDER BY cust_contact;
```

#### 使用通配符的技巧

<font color = orange>缺点</font>：

1. 通配符搜 索一般比前面讨论的其他搜索要耗费更长的处理时间。

<font color = orange>技巧</font>：

1. 不要过度使用通配符。如果其他操作符能达到相同的目的，应该使用其他操作符。
2. 在确实需要使用通配符时，也尽量不要把它们用在搜索模式的开始处。把通配符置于开始处，搜索起来是最慢的。
3. 仔细注意通配符的位置。如果放错地方，可能不会返回想要的数据。

