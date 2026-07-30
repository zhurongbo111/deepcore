用户表 User

| 字段         | 类型          | 约束                     | 说明     |
| ------------ | ------------- | ------------------------ | -------- |
| Id           | bigint        | PK                       | 主键     |
| PublicUserId | uuid          | UNIQUE                   | Jwt sub  |
| UserName     | nvarchar(50)  | NOT NULL, UNIQUE         | 登录账号 |
| PasswordHash | nvarchar(200) | NOT NULL                 | 密码     |
| RealName     | nvarchar(50)  |                          | 姓名     |
| Phone        | nvarchar(20)  |                          | 手机号   |
| Email        | nvarchar(100) |                          | 邮箱     |
| Status       | int           | 状态：`1`-启用，`0`-停用 | 状态     |
| CreatedTime  | datetime      |                          | 创建时间 |
| CreatedBy    | bigint        |                          | 创建人   |
| UpdatedTime  | datetime      |                          | 更新时间 |
| UpdatedBy    | bigint        |                          | 修改人   |

商品 Product

| 字段          | 类型          | 约束                   | 说明                                         |
| ------------- | ------------- | ---------------------- | -------------------------------------------- |
| Id            | bigint        | PK                     | 主键                                         |
| Code          | nvarchar(50)  | NOT NULL, UNIQUE       | 商品编码（可手动输入或系统生成，支持条形码） |
| Name          | nvarchar(100) | NOT NULL               | 商品名称                                     |
| Unit          | nvarchar(20)  | NOT NULL               | 计量单位（如：个、箱、斤）                   |
| PurchasePrice | decimal(18,2) | NOT NULL, DEFAULT 0.00 | 采购价价                                     |
| SalePrice     | decimal(18,2) | NOT NULL, DEFAULT 0.00 | 销售价                                       |
| Status        | int           | NOT NULL, DEFAULT 1    | 状态：`1`-启用，`0`-停用                     |
| CreatedTime   | datetime      | NOT NULL               | 创建时间                                     |
| UpdatedTime   | datetime      | NOT NULL               | 更新时间                                     |

客户 Customer

| 字段        | 类型          | 约束                | 说明                     |
| ----------- | ------------- | ------------------- | ------------------------ |
| Id          | bigint        | PK                  | 主键                     |
| Name        | nvarchar(100) | NOT NULL            | 客户名称                 |
| ContactName | nvarchar(50)  | NOT NULL            | 联系人                   |
| Phone       | nvarchar(20)  | NOT NULL            | 电话                     |
| Address     | nvarchar(200) | NOT NULL            | 地址                     |
| Remark      | nvarchar(500) |                     | 备注                     |
| Status      | int           | NOT NULL, DEFAULT 1 | 状态：`1`-启用，`0`-停用 |
| CreatedTime | datetime      | NOT NULL            | 创建时间                 |
| UpdatedTime | datetime      | NOT NULL            | 更新时间                 |

供应商 Supplier

| 字段        | 类型          | 约束                | 说明                     |
| ----------- | ------------- | ------------------- | ------------------------ |
| Id          | bigint        | PK                  | 主键                     |
| Name        | nvarchar(100) | NOT NULL            | 客户名称                 |
| ContactName | nvarchar(50)  | NOT NULL            | 联系人                   |
| Phone       | nvarchar(20)  | NOT NULL            | 电话                     |
| Address     | nvarchar(200) | NOT NULL            | 地址                     |
| Remark      | nvarchar(500) |                     | 备注                     |
| Status      | int           | NOT NULL, DEFAULT 1 | 状态：`1`-启用，`0`-停用 |
| CreatedTime | datetime      | NOT NULL            | 创建时间                 |
| UpdatedTime | datetime      | NOT NULL            | 更新时间                 |

采购订单 PurchaseOrder

| 字段        | 类型          | 约束             | 说明                                                       |
| ----------- | ------------- | ---------------- | ---------------------------------------------------------- |
| Id          | bigint        | PK               | 主键                                                       |
| OrderNo     | nvarchar(50)  | NOT NULL, UNIQUE | 采购单号                                                   |
| SupplierId  | bigint        | NOT NULL         | 供应商                                                     |
| OrderDate   | datetime      | NOT NULL         | 订单日期                                                   |
| TotalAmount | decimal(18,2) | NOT NULL         | 总金额                                                     |
| Status      | int           | NOT NULL         | 订单状态：`2`-已入库，`3`-已取消，`0` - 草稿，`1` - 已生效 |
| Remark      | nvarchar(500) |                  | 备注                                                       |
| CreatedTime | datetime      | NOT NULL         | 创建时间                                                   |
| UpdatedTime | datetime      | NOT NULL         | 更新时间                                                   |

采购订单明细 PurchaseOrderItem

| 字段        | 类型          | 约束                             | 说明     |
| ----------- | ------------- | -------------------------------- | -------- |
| Id          | bigint        | PK                               | 主键     |
| OrderId     | bigint        | NOT NULL, FK -> PurchaseOrder.id | 订单ID   |
| ProductId   | bigint        | NOT NULL, FK -> Product.id       | 商品ID   |
| Quantity    | decimal(18,2) | NOT NULL                         | 采购数量 |
| Price       | decimal(18,2) | NOT NULL                         | 采购单价 |
| Amount      | decimal(18,2) | NOT NULL                         | 金额     |
| CreatedTime | datetime      | NOT NULL                         | 创建时间 |
| UpdatedTime | datetime      | NOT NULL                         | 更新时间 |

 销售订单SalesOrder

| 字段        | 类型          | 约束                        | 说明                                                       |
| ----------- | ------------- | --------------------------- | ---------------------------------------------------------- |
| Id          | bigint        | PK                          | 主键                                                       |
| OrderNo     | nvarchar(50)  | NOT NULL, UNIQUE            | 销售单号                                                   |
| CustomerId  | bigint        | NOT NULL, FK -> Customer.id | 客户                                                       |
| OrderDate   | datetime      | NOT NULL                    | 日期                                                       |
| TotalAmount | decimal(18,2) |                             | 金额                                                       |
| Status      | int           |                             | 订单状态：`2`-已出库，`3`-已取消，`0` - 草稿，`1` - 已生效 |
| Remark      | nvarchar(500) |                             | 备注                                                       |
| CreatedTime | datetime      | NOT NULL                    | 创建时间                                                   |
| UpdatedTime | datetime      | NOT NULL                    | 更新时间                                                   |

销售订单明细 SalesOrderItem

| 字段        | 类型          | 约束                          | 说明             |
| ----------- | ------------- | ----------------------------- | ---------------- |
| Id          | bigint        | PK                            | 主键             |
| OrderId     | bigint        | NOT NULL, FK -> SalesOrder.id | 关联出库单主表ID |
| ProductId   | bigint        | NOT NULL, FK -> Product.id    | 商品             |
| Quantity    | decimal(18,2) | NOT NULL                      | 出库数量         |
| Price       | decimal(18,2) | NOT NULL                      | 销售单价         |
| Amount      | decimal(18,2) |                               | 金额             |
| CreatedTime | datetime      | NOT NULL                      | 创建时间         |
| UpdatedTime | datetime      | NOT NULL                      | 更新时间         |

库存Inventory

| 字段              | 类型          | 约束                       | 说明     |
| ----------------- | ------------- | -------------------------- | -------- |
| Id                | bigint        | PK                         | 主键     |
| ProductId         | bigint        | NOT NULL, FK -> Product.id | 商品     |
| Quantity          | decimal(18,2) |                            | 库存数量 |
| LockedQuantity    | decimal(18,2) |                            | 锁定数量 |
| AvailableQuantity | decimal(18,2) |                            | 可用数量 |
| CreatedTime       | datetime      | NOT NULL                   | 创建时间 |
| UpdatedTime       | datetime      | NOT NULL                   | 更新时间 |
