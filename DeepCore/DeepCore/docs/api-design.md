### 1. 认证管理 (Auth)

* **`POST /api/v1/auth/login`**
  * **说明**：用户登录验证。
  * **业务**：接收 `UserName` 和 `PasswordHash`（前端加密后的密文），验证通过后返回 Token 及用户信息。
* **`POST /api/v1/auth/me`**
  * **说明**：获取当前用户基本信息。
  * **业务**：返回用户信息。
* **`PUT /api/v1/auth/password`**
  * **说明**：修改密码。
  * **业务**：接收 `UserName` 和 `PasswordHash`（前端加密后的密文），验证通过后返回 Token 及用户信息。



### 2. 商品管理 (Product)

* **`POST /api/v1/products`**
  * **说明**：添加商品。
  * **业务**：校验商品编码 `Code` 是否唯一（支持手动输入或条形码自动生成）。
* **`PUT /api/v1/products/{id}`**
  * **说明**：修改商品信息。
  * **业务**：修改商品名称、单位、价格等。
* **`PATCH /api/v1/products/{id}/status`**
  * **说明**：商品上下架/启停用。
* **`GET /api/v1/products`**
  * **说明**：商品列表查询（支持按 `Name`、`Code` 模糊搜索，按 `Status` 筛选，支持分页）。
* **`GET /api/v1/products/{id}`**
  * **说明**：获取单个商品详情。



### 3. 客户管理 (Customer )

* **`POST /api/v1/customers`** 
  * **说明**：创建客户。
* **`PUT /api/v1/customers/{id}`** 
  * **说明**：修改客户信息。
* **`GET /api/v1/customers`** 
  * **说明**：分页列表查询（支持名称、联系人、手机号模糊筛选）。
* **`GET /api/v1/customers/{id}`**
  * **说明**：获取客户信息。
* **`PUT /api/v1/customers/{id}/status   `** 
  * **说明**：启停客户。



### 4. 供应商管理 (Supplier)

*  **`POST /api/v1/suppliers`**
  * **说明**：创建供应商。
*  **`PUT /api/v1/suppliers/{id}`**
  * **说明**：修改供应商信息。
*  **`GET /api/v1/suppliers`**
  * **说明**：分页列表查询（支持名称、联系人、手机号模糊筛选）。
* **`PUT /api/v1/suppliers/{id}`**
  * **说明**：获取供应商信息。
* **`PUT /api/v1/suppliers/{id}/status   `**
  * **说明**：启停供应商。

### 5. 采购订单接口

* **`POST /api/v1/purchase-orders`**
  * **说明**：创建采购订单。
  * **业务**：同时写入主表（`PurchaseOrder`）和明细表（`PurchaseOrderItem`）。可选择保存为草稿（`Status=0`）或直接生效（`Status=1`）。自动计算 `TotalAmount` 和明细的 `Amount`。
* **`PUT /api/v1/purchase-orders/{id}`**
  * **说明**：修改采购订单。
  * **业务**：**仅允许在草稿（`Status=0`）状态下修改**。
* **`GET /api/v1/purchase-orders`**
  * **说明**：分页查询采购单列表（可按单号、供应商、状态、订单日期范围筛选）。
* **`GET /api/v1/purchase-orders/{id}`**
  * **说明**：获取采购单详情（**需联合查询返回明细列表**）。
* **`POST /api/v1/purchase-orders/{id}/cancel`**
  * **说明**：取消采购订单。
  * **业务**：仅非入库状态下可取消，状态变更为 `3-已取消`。
* **`POST /api/v1/purchase-orders/{id}/submit`**
  * **说明**：提交采购订单。
  * **业务**：仅草稿下可提交，状态变更为 `1-已生效`。
* **`POST /api/v1/purchase-orders/{id}/stock-in`**
  * **说明**：**确认采购入库（核心业务）**。
  * **核心逻辑（需事务控制）**：
    1. 校验当前订单状态必须为 `1-已生效`。
    2. 修改订单状态为 `2-已入库`。
    3. **更新库存表 (`Inventory`)**：遍历明细中的商品，增加对应商品的实际库存（`Quantity`）和可用库存（`AvailableQuantity`）。如果库存表无该商品记录，则初始化新增。

## 状态

  状态   说明

------ --------

  0      草稿
  1      已生效
  2      已入库
  3      已取消



### 6. 销售订单接口

* **`POST /api/v1/sales-orders`**
  * **说明**：创建销售订单。
  * **核心逻辑（需事务控制 - 预扣库存）**：
    1. 遍历订单明细，校验 `Inventory` 表中对应商品的 `AvailableQuantity` 是否足额。
    2. 若库存充足，锁定库存：`LockedQuantity = LockedQuantity + 销售数量`，同时 `AvailableQuantity = AvailableQuantity - 销售数量`。
    3. 写入销售订单及明细，初始状态为 `1-已生效`（或 `0-草稿`，草稿状态不预扣库存，生效时再扣）。
* **`POST /api/v1/sales-orders/{id}/submit`**
  * **说明**：提交销售订单，仅当状态为草稿时才可以提交。
* **`GET /api/v1/sales-orders`**
  * **说明**：分页查询销售单列表。
* **`GET /api/v1/sales-orders/{id}`**
  * **说明**：获取销售单详情（包含明细）。
* **`POST /api/v1/sales-orders/{id}/cancel`**
  * **说明**：取消销售订单。
  * **核心逻辑（需事务控制 - 释放库存）**：
    1. 状态变更为 `3-已取消`。
    2. **回滚锁定库存**：`LockedQuantity = LockedQuantity - 销售数量`，`AvailableQuantity = AvailableQuantity + 销售数量`。
* **`POST /api/v1/sales-orders/{id}/stock-out`**
  * **说明**：**确认销售出库（核心业务）**。
  * **核心逻辑（需事务控制）**：
    1. 校验订单状态为 `1-已生效`。
    2. 修改订单状态为 `2-已出库`。
    3. **扣减实际库存**：将预扣的锁定库存真正消耗掉。更新库存表：`Quantity = Quantity - 销售数量`，`LockedQuantity = LockedQuantity - 销售数量`。



### 7. 库存核心接口

* **`GET /api/v1/inventories`**
  * **说明**：全量/分页查询当前仓储库存。
  * **业务**：支持按商品名称、编码筛选，返回当前商品的 `Quantity`（总库存）、`LockedQuantity`（锁定）、`AvailableQuantity`（可用）。
* **`GET /api/v1/inventories/product/{productId}`**
  * **说明**：查询单个商品的实时库存。
* **`POST /api/v1/inventories/adjust`**
  * **说明**：**库存盘点与手动调整（MVP选配）**。
  * **业务**：供管理员在系统数据与现实仓库不符时，手动输入差值调整 `Quantity` 和 `AvailableQuantity`，记录盘点日志。



### 8. 用户管理 (User)

* **`POST /api/v1/users`**
  * **说明**：创建新用户。
  * **业务**：校验 `UserName` 是否唯一，初始化状态 `Status = 1`。
* **`PUT /api/v1/users/{id}`**
  * **说明**：修改用户信息。
  * **业务**：更新姓名、手机、邮箱等。
* **`PATCH /api/v1/users/{id}/status`**
  * **说明**：启停用用户。
  * **业务**：修改 `Status` 字段（`1`-启用，`0`-停用）。
* **`GET /api/v1/users`**
  * **说明**：条件分页查询用户列表。