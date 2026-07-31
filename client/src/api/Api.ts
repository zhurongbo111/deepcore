/* eslint-disable */
/* tslint:disable */
// @ts-nocheck
/*
 * ---------------------------------------------------------------
 * ## THIS FILE WAS GENERATED VIA SWAGGER-TYPESCRIPT-API        ##
 * ##                                                           ##
 * ## AUTHOR: acacode                                           ##
 * ## SOURCE: https://github.com/acacode/swagger-typescript-api ##
 * ---------------------------------------------------------------
 */

/** @format int32 */
export enum SalesOrderStatus {
  Value0 = 0,
  Value1 = 1,
  Value2 = 2,
  Value3 = 3,
}

/** @format int32 */
export enum PurchaseOrderStatus {
  Value0 = 0,
  Value1 = 1,
  Value2 = 2,
  Value3 = 3,
}

export interface AdjustInventoryRequest {
  /** @format int64 */
  productId?: number;
  /** @format double */
  quantityDifference?: number;
  /** @maxLength 500 */
  reason?: string | null;
}

export interface AdjustInventoryResponse {
  success?: boolean;
  message?: string | null;
}

export interface AuthLoginRequest {
  /** @maxLength 50 */
  userName: string;
  /** @maxLength 100 */
  password: string;
}

export interface AuthLoginResponse {
  success?: boolean;
  message?: string | null;
  token?: string | null;
}

export interface AuthMeResponse {
  success?: boolean;
  message?: string | null;
  userName?: string | null;
  fullName?: string | null;
  /** @format int32 */
  status?: number;
}

export interface AuthPasswordChangeRequest {
  /** @maxLength 50 */
  userName: string;
  /** @maxLength 200 */
  passwordHash: string;
}

export interface AuthPasswordChangeResponse {
  success?: boolean;
}

export interface AuthRefreshRequest {
  token: string;
}

export interface AuthRefreshResponse {
  success?: boolean;
  message?: string | null;
  token?: string | null;
}

export interface CancelPurchaseOrderResponse {
  success?: boolean;
  message?: string | null;
  /** @format int64 */
  id?: number;
}

export interface CancelSalesOrderResponse {
  /** @format int64 */
  id?: number;
}

export interface CreateCustomerRequest {
  /** @maxLength 100 */
  name: string;
  /** @maxLength 50 */
  contact: string;
  /** @maxLength 20 */
  phone: string;
  /** @maxLength 200 */
  address: string;
  /** @maxLength 500 */
  remark?: string | null;
}

export interface CreateCustomerResponse {
  success?: boolean;
  message?: string | null;
  /** @format int64 */
  id?: number;
}

export interface CreateProductRequest {
  /** @maxLength 50 */
  code: string;
  /** @maxLength 100 */
  name: string;
  /** @maxLength 20 */
  unit: string;
  /**
   * @format double
   * @min 0
   */
  purchasePrice: number;
  /**
   * @format double
   * @min 0
   */
  salePrice: number;
  /**
   * @format int32
   * @min 0
   * @max 1
   */
  status: number;
}

export interface CreateProductResponse {
  success?: boolean;
  message?: string | null;
  /** @format int64 */
  id?: number;
  codeExist?: boolean;
}

export interface CreatePurchaseOrderRequest {
  /** @format int64 */
  supplierId?: number;
  /**
   * @format int32
   * @min 0
   * @max 1
   */
  status?: number;
  items?: PurchaseOrderItemDto[] | null;
}

export interface CreatePurchaseOrderResponse {
  success?: boolean;
  message?: string | null;
  /** @format int64 */
  id?: number;
}

export interface CreateSalesOrderRequest {
  /** @format int64 */
  customerId?: number;
  /**
   * @format int32
   * @min 0
   * @max 1
   */
  status?: number;
  items?: SalesOrderItemDto[] | null;
}

export interface CreateSalesOrderResponse {
  success?: boolean;
  message?: string | null;
}

export interface CreateSupplierRequest {
  /** @maxLength 100 */
  name: string;
  /** @maxLength 50 */
  contact: string;
  /** @maxLength 20 */
  phone: string;
  /** @maxLength 200 */
  address: string;
  /** @maxLength 500 */
  remark?: string | null;
}

export interface CreateSupplierResponse {
  success?: boolean;
  message?: string | null;
  /** @format int64 */
  id?: number;
}

export interface CreateUserRequest {
  /** @maxLength 50 */
  userName: string;
  /** @maxLength 100 */
  fullName?: string | null;
  /** @maxLength 20 */
  phone?: string | null;
  /** @maxLength 100 */
  email?: string | null;
}

export interface CreateUserResponse {
  success?: boolean;
  message?: string | null;
  /** @format int64 */
  id?: number;
}

export interface CustomerDto {
  /** @format int64 */
  id?: number;
  name?: string | null;
  contact?: string | null;
  phone?: string | null;
}

export interface CustomerListResponse {
  success?: boolean;
  message?: string | null;
  items?: CustomerDto[] | null;
  /** @format int64 */
  totalCount?: number;
}

export interface GetCustomerByIdResponse {
  success?: boolean;
  message?: string | null;
  name?: string | null;
  contact?: string | null;
  phone?: string | null;
  address?: string | null;
  remark?: string | null;
}

export interface GetInventoryByProductResponse {
  success?: boolean;
  message?: string | null;
  /** @format int64 */
  productId?: number;
  productName?: string | null;
  /** @format double */
  quantity?: number;
  /** @format double */
  lockedQuantity?: number;
  /** @format double */
  availableQuantity?: number;
}

export interface GetProductByIdResponse {
  success?: boolean;
  message?: string | null;
  /** @format int64 */
  id?: number;
  code?: string | null;
  name?: string | null;
  unit?: string | null;
  /** @format double */
  salePrice?: number | null;
  /** @format double */
  purchasePrice?: number | null;
  /** @format int32 */
  status?: number;
}

export interface GetPurchaseOrderByIdResponse {
  success?: boolean;
  message?: string | null;
  /** @format int64 */
  id?: number;
  orderNumber?: string | null;
  status?: PurchaseOrderStatus;
  /** @format double */
  totalAmount?: number;
  items?: PurchaseOrderDetailItemDto[] | null;
}

export interface GetSalesOrderByIdResponse {
  success?: boolean;
  message?: string | null;
  /** @format int64 */
  id?: number;
  orderNumber?: string | null;
  status?: SalesOrderStatus;
  /** @format double */
  totalAmount?: number;
  items?: SalesOrderDetailItemDto[] | null;
}

export interface GetSupplierByIdResponse {
  success?: boolean;
  message?: string | null;
  name?: string | null;
  contact?: string | null;
  phone?: string | null;
  address?: string | null;
  remark?: string | null;
  /** @format int32 */
  status?: number;
}

export interface GetUserByIdResponse {
  success?: boolean;
  message?: string | null;
  /** @format uuid */
  publicUserId?: string;
  userName?: string | null;
  fullName?: string | null;
  phone?: string | null;
  email?: string | null;
  /** @format int32 */
  status?: number;
}

export interface InventoryItemDto {
  /** @format int64 */
  productId?: number;
  productName?: string | null;
  productCode?: string | null;
  /** @format double */
  quantity?: number;
  /** @format double */
  lockedQuantity?: number;
  /** @format double */
  availableQuantity?: number;
}

export interface InventoryListResponse {
  success?: boolean;
  message?: string | null;
  items?: InventoryItemDto[] | null;
  /** @format int64 */
  totalCount?: number;
}

export interface PatchCustomerStatusRequest {
  /**
   * @format int32
   * @min 0
   * @max 1
   */
  status: number;
}

export interface PatchCustomerStatusResponse {
  success?: boolean;
  message?: string | null;
  /** @format int64 */
  id?: number;
  /** @format int32 */
  status?: number;
}

export interface PatchProductStatusRequest {
  /**
   * @format int32
   * @min 0
   * @max 1
   */
  status: number;
}

export interface PatchProductStatusResponse {
  success?: boolean;
  message?: string | null;
}

export interface PatchSupplierStatusRequest {
  /** @format int32 */
  status?: number;
}

export interface PatchSupplierStatusResponse {
  success?: boolean;
  message?: string | null;
  /** @format int64 */
  id?: number;
  /** @format int32 */
  status?: number;
}

export interface PatchUserStatusRequest {
  /** @format int64 */
  id?: number;
  /** @format int32 */
  status?: number;
}

export interface PatchUserStatusResponse {
  success?: boolean;
  message?: string | null;
  /** @format int64 */
  id?: number;
  /** @format int32 */
  status?: number;
}

export interface ProductDto {
  /** @format int64 */
  id?: number;
  code?: string | null;
  name?: string | null;
  unit?: string | null;
  /** @format double */
  purchasePrice?: number;
  /** @format double */
  salePrice?: number;
  /** @format int32 */
  status?: number;
}

export interface ProductListResponse {
  success?: boolean;
  message?: string | null;
  items?: ProductDto[] | null;
  /** @format int64 */
  totalCount?: number;
}

export interface PurchaseOrderDetailItemDto {
  /** @format int64 */
  productId?: number;
  productName?: string | null;
  /** @format int32 */
  quantity?: number;
  /** @format double */
  unitPrice?: number;
  /** @format double */
  amount?: number;
}

export interface PurchaseOrderItemDto {
  /** @format int64 */
  productId: number;
  /**
   * @format double
   * @min 0
   */
  unitPrice?: number;
  /**
   * @format int32
   * @min 1
   * @max 2147483647
   */
  quantity?: number;
  /**
   * @format double
   * @min 0
   */
  amount?: number;
}

export interface PurchaseOrderListItemDto {
  /** @format int64 */
  id?: number;
  orderNumber?: string | null;
  status?: PurchaseOrderStatus;
  /** @format double */
  totalAmount?: number;
}

export interface PurchaseOrderListResponse {
  success?: boolean;
  message?: string | null;
  items?: PurchaseOrderListItemDto[] | null;
  /** @format int64 */
  totalCount?: number;
}

export interface SalesOrderDetailItemDto {
  /** @format int64 */
  productId?: number;
  productName?: string | null;
  /** @format int32 */
  quantity?: number;
  /** @format double */
  unitPrice?: number;
  /** @format double */
  amount?: number;
}

export interface SalesOrderItemDto {
  /** @format int64 */
  productId: number;
  /**
   * @format int32
   * @min 1
   * @max 2147483647
   */
  quantity?: number;
  /**
   * @format double
   * @min 0
   */
  unitPrice?: number;
  /**
   * @format double
   * @min 0
   */
  amount?: number;
}

export interface SalesOrderListItemDto {
  /** @format int64 */
  id?: number;
  orderNumber?: string | null;
  status?: SalesOrderStatus;
  /** @format double */
  totalAmount?: number;
}

export interface SalesOrderListResponse {
  success?: boolean;
  message?: string | null;
  items?: SalesOrderListItemDto[] | null;
  /** @format int64 */
  totalCount?: number;
}

export interface StockInPurchaseOrderResponse {
  success?: boolean;
  message?: string | null;
}

export interface StockOutSalesOrderResponse {
  success?: boolean;
  message?: string | null;
}

export interface SubmitPurchaseOrderResponse {
  success?: boolean;
  message?: string | null;
  /** @format int64 */
  id?: number;
}

export interface SubmitSalesOrderResponse {
  success?: boolean;
  message?: string | null;
}

export interface SupplierDto {
  /** @format int64 */
  id?: number;
  name?: string | null;
  contact?: string | null;
  phone?: string | null;
  /** @format int32 */
  status?: number;
}

export interface SupplierListResponse {
  success?: boolean;
  message?: string | null;
  items?: SupplierDto[] | null;
  /** @format int64 */
  totalCount?: number;
}

export interface UpdateCustomerRequest {
  /** @maxLength 100 */
  name?: string | null;
  /** @maxLength 50 */
  contact?: string | null;
  /** @maxLength 20 */
  phone?: string | null;
  /** @maxLength 200 */
  address?: string | null;
  /** @maxLength 500 */
  remark?: string | null;
}

export interface UpdateCustomerResponse {
  success?: boolean;
  message?: string | null;
}

export interface UpdateProductRequest {
  /** @maxLength 100 */
  name?: string | null;
  /** @maxLength 20 */
  unit?: string | null;
  /**
   * @format double
   * @min 0
   */
  salePrice?: number | null;
  /**
   * @format double
   * @min 0
   */
  purchasePrice?: number | null;
}

export interface UpdateProductResponse {
  success?: boolean;
  message?: string | null;
}

export interface UpdatePurchaseOrderRequest {
  /** @format int64 */
  supplierId?: number;
  items?: PurchaseOrderItemDto[] | null;
}

export interface UpdatePurchaseOrderResponse {
  success?: boolean;
  message?: string | null;
}

export interface UpdateSupplierRequest {
  /** @maxLength 100 */
  name?: string | null;
  /** @maxLength 50 */
  contact?: string | null;
  /** @maxLength 20 */
  phone?: string | null;
  /** @maxLength 200 */
  address?: string | null;
  /** @maxLength 500 */
  remark?: string | null;
}

export interface UpdateSupplierResponse {
  success?: boolean;
  message?: string | null;
}

export interface UpdateUserRequest {
  /** @maxLength 100 */
  fullName?: string | null;
  /** @maxLength 20 */
  phone?: string | null;
  /** @maxLength 100 */
  email?: string | null;
}

export interface UpdateUserResponse {
  success?: boolean;
  message?: string | null;
}

export interface UserListItemDto {
  /** @format int64 */
  id?: number;
  userName?: string | null;
  realName?: string | null;
  phone?: string | null;
  email?: string | null;
  /** @format int32 */
  status?: number;
}

export interface UserListResponse {
  success?: boolean;
  message?: string | null;
  items?: UserListItemDto[] | null;
  /** @format int64 */
  totalCount?: number;
}

import type {
  AxiosInstance,
  AxiosRequestConfig,
  HeadersDefaults,
  ResponseType,
} from "axios";
import axios from "axios";

export type QueryParamsType = Record<string | number, any>;

export interface FullRequestParams
  extends Omit<AxiosRequestConfig, "data" | "params" | "url" | "responseType"> {
  /** set parameter to `true` for call `securityWorker` for this request */
  secure?: boolean;
  /** request path */
  path: string;
  /** content type of request body */
  type?: ContentType;
  /** query params */
  query?: QueryParamsType;
  /** format of response (i.e. response.json() -> format: "json") */
  format?: ResponseType;
  /** request body */
  body?: unknown;
}

export type RequestParams = Omit<
  FullRequestParams,
  "body" | "method" | "query" | "path"
>;

export interface ApiConfig<SecurityDataType = unknown>
  extends Omit<AxiosRequestConfig, "data" | "cancelToken"> {
  securityWorker?: (
    securityData: SecurityDataType | null,
  ) => Promise<AxiosRequestConfig | void> | AxiosRequestConfig | void;
  secure?: boolean;
  format?: ResponseType;
}

export enum ContentType {
  Json = "application/json",
  JsonApi = "application/vnd.api+json",
  FormData = "multipart/form-data",
  UrlEncoded = "application/x-www-form-urlencoded",
  Text = "text/plain",
}

export class HttpClient<SecurityDataType = unknown> {
  public instance: AxiosInstance;
  private securityData: SecurityDataType | null = null;
  private securityWorker?: ApiConfig<SecurityDataType>["securityWorker"];
  private secure?: boolean;
  private format?: ResponseType;

  constructor({
    securityWorker,
    secure,
    format,
    ...axiosConfig
  }: ApiConfig<SecurityDataType> = {}) {
    this.instance = axios.create({
      ...axiosConfig,
      baseURL: axiosConfig.baseURL || "",
    });
    this.secure = secure;
    this.format = format;
    this.securityWorker = securityWorker;
  }

  public setSecurityData = (data: SecurityDataType | null) => {
    this.securityData = data;
  };

  protected mergeRequestParams(
    params1: AxiosRequestConfig,
    params2?: AxiosRequestConfig,
  ): AxiosRequestConfig {
    const method = params1.method || (params2 && params2.method);

    return {
      ...this.instance.defaults,
      ...params1,
      ...(params2 || {}),
      headers: {
        ...((method &&
          this.instance.defaults.headers[
            method.toLowerCase() as keyof HeadersDefaults
          ]) ||
          {}),
        ...(params1.headers || {}),
        ...((params2 && params2.headers) || {}),
      },
    };
  }

  protected stringifyFormItem(formItem: unknown) {
    if (typeof formItem === "object" && formItem !== null) {
      return JSON.stringify(formItem);
    } else {
      return `${formItem}`;
    }
  }

  protected createFormData(input: Record<string, unknown>): FormData {
    if (input instanceof FormData) {
      return input;
    }
    return Object.keys(input || {}).reduce((formData, key) => {
      const property = input[key];
      const propertyContent: any[] =
        property instanceof Array ? property : [property];

      for (const formItem of propertyContent) {
        const isFileType = formItem instanceof Blob || formItem instanceof File;
        formData.append(
          key,
          isFileType ? formItem : this.stringifyFormItem(formItem),
        );
      }

      return formData;
    }, new FormData());
  }

  public request = async <T = any, _E = any>({
    secure,
    path,
    type,
    query,
    format,
    body,
    ...params
  }: FullRequestParams): Promise<T> => {
    const secureParams =
      ((typeof secure === "boolean" ? secure : this.secure) &&
        this.securityWorker &&
        (await this.securityWorker(this.securityData))) ||
      {};
    const requestParams = this.mergeRequestParams(params, secureParams);
    const responseFormat = format || this.format || undefined;

    if (
      type === ContentType.FormData &&
      body &&
      body !== null &&
      typeof body === "object"
    ) {
      body = this.createFormData(body as Record<string, unknown>);
    }

    if (
      type === ContentType.Text &&
      body &&
      body !== null &&
      typeof body !== "string"
    ) {
      body = JSON.stringify(body);
    }

    return this.instance
      .request({
        ...requestParams,
        headers: {
          ...(requestParams.headers || {}),
          ...(type ? { "Content-Type": type } : {}),
        },
        params: query,
        responseType: responseFormat,
        data: body,
        url: path,
      })
      .then((response) => response.data);
  };
}

/**
 * @title DeepCore
 * @version 1.0
 */
export class Api<
  SecurityDataType extends unknown,
> extends HttpClient<SecurityDataType> {
  api = {
    /**
     * No description
     *
     * @tags Auth
     * @name V1AuthLoginCreate
     * @request POST:/api/v1/auth/login
     */
    v1AuthLoginCreate: (data: AuthLoginRequest, params: RequestParams = {}) =>
      this.request<AuthLoginResponse, any>({
        path: `/api/v1/auth/login`,
        method: "POST",
        body: data,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Auth
     * @name V1AuthRefreshCreate
     * @request POST:/api/v1/auth/refresh
     * @secure
     */
    v1AuthRefreshCreate: (
      data: AuthRefreshRequest,
      params: RequestParams = {},
    ) =>
      this.request<AuthRefreshResponse, any>({
        path: `/api/v1/auth/refresh`,
        method: "POST",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Auth
     * @name V1AuthMeList
     * @request GET:/api/v1/auth/me
     * @secure
     */
    v1AuthMeList: (params: RequestParams = {}) =>
      this.request<AuthMeResponse, any>({
        path: `/api/v1/auth/me`,
        method: "GET",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Auth
     * @name V1AuthPasswordUpdate
     * @request PUT:/api/v1/auth/password
     * @secure
     */
    v1AuthPasswordUpdate: (
      data: AuthPasswordChangeRequest,
      params: RequestParams = {},
    ) =>
      this.request<AuthPasswordChangeResponse, any>({
        path: `/api/v1/auth/password`,
        method: "PUT",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Customers
     * @name V1CustomersCreate
     * @request POST:/api/v1/customers
     * @secure
     */
    v1CustomersCreate: (
      data: CreateCustomerRequest,
      params: RequestParams = {},
    ) =>
      this.request<CreateCustomerResponse, any>({
        path: `/api/v1/customers`,
        method: "POST",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Customers
     * @name V1CustomersList
     * @request GET:/api/v1/customers
     * @secure
     */
    v1CustomersList: (
      query?: {
        Name?: string;
        Contact?: string;
        Phone?: string;
        /** @format int32 */
        Page?: number;
        /** @format int32 */
        PageSize?: number;
      },
      params: RequestParams = {},
    ) =>
      this.request<CustomerListResponse, any>({
        path: `/api/v1/customers`,
        method: "GET",
        query: query,
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Customers
     * @name V1CustomersUpdate
     * @request PUT:/api/v1/customers/{id}
     * @secure
     */
    v1CustomersUpdate: (
      id: number,
      data: UpdateCustomerRequest,
      params: RequestParams = {},
    ) =>
      this.request<UpdateCustomerResponse, any>({
        path: `/api/v1/customers/${id}`,
        method: "PUT",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Customers
     * @name V1CustomersDetail
     * @request GET:/api/v1/customers/{id}
     * @secure
     */
    v1CustomersDetail: (id: number, params: RequestParams = {}) =>
      this.request<GetCustomerByIdResponse, any>({
        path: `/api/v1/customers/${id}`,
        method: "GET",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Customers
     * @name V1CustomersStatusUpdate
     * @request PUT:/api/v1/customers/{id}/status
     * @secure
     */
    v1CustomersStatusUpdate: (
      id: number,
      data: PatchCustomerStatusRequest,
      params: RequestParams = {},
    ) =>
      this.request<PatchCustomerStatusResponse, any>({
        path: `/api/v1/customers/${id}/status`,
        method: "PUT",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Inventories
     * @name V1InventoriesList
     * @request GET:/api/v1/inventories
     * @secure
     */
    v1InventoriesList: (
      query?: {
        Name?: string;
        Code?: string;
        /** @format int32 */
        Page?: number;
        /** @format int32 */
        PageSize?: number;
      },
      params: RequestParams = {},
    ) =>
      this.request<InventoryListResponse, any>({
        path: `/api/v1/inventories`,
        method: "GET",
        query: query,
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Inventories
     * @name V1InventoriesProductDetail
     * @request GET:/api/v1/inventories/product/{productId}
     * @secure
     */
    v1InventoriesProductDetail: (
      productId: number,
      params: RequestParams = {},
    ) =>
      this.request<GetInventoryByProductResponse, any>({
        path: `/api/v1/inventories/product/${productId}`,
        method: "GET",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Inventories
     * @name V1InventoriesAdjustCreate
     * @request POST:/api/v1/inventories/adjust
     * @secure
     */
    v1InventoriesAdjustCreate: (
      data: AdjustInventoryRequest,
      params: RequestParams = {},
    ) =>
      this.request<AdjustInventoryResponse, any>({
        path: `/api/v1/inventories/adjust`,
        method: "POST",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Products
     * @name V1ProductsCreate
     * @request POST:/api/v1/products
     * @secure
     */
    v1ProductsCreate: (
      data: CreateProductRequest,
      params: RequestParams = {},
    ) =>
      this.request<CreateProductResponse, any>({
        path: `/api/v1/products`,
        method: "POST",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Products
     * @name V1ProductsList
     * @request GET:/api/v1/products
     * @secure
     */
    v1ProductsList: (
      query?: {
        KeyWord?: string;
        Code?: string;
        /** @format int32 */
        Status?: number;
        /** @format int32 */
        Page?: number;
        /** @format int32 */
        PageSize?: number;
      },
      params: RequestParams = {},
    ) =>
      this.request<ProductListResponse, any>({
        path: `/api/v1/products`,
        method: "GET",
        query: query,
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Products
     * @name V1ProductsUpdate
     * @request PUT:/api/v1/products/{id}
     * @secure
     */
    v1ProductsUpdate: (
      id: number,
      data: UpdateProductRequest,
      params: RequestParams = {},
    ) =>
      this.request<UpdateProductResponse, any>({
        path: `/api/v1/products/${id}`,
        method: "PUT",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Products
     * @name V1ProductsDetail
     * @request GET:/api/v1/products/{id}
     * @secure
     */
    v1ProductsDetail: (id: number, params: RequestParams = {}) =>
      this.request<GetProductByIdResponse, any>({
        path: `/api/v1/products/${id}`,
        method: "GET",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Products
     * @name V1ProductsStatusPartialUpdate
     * @request PATCH:/api/v1/products/{id}/status
     * @secure
     */
    v1ProductsStatusPartialUpdate: (
      id: number,
      data: PatchProductStatusRequest,
      params: RequestParams = {},
    ) =>
      this.request<PatchProductStatusResponse, any>({
        path: `/api/v1/products/${id}/status`,
        method: "PATCH",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags PurchaseOrders
     * @name V1PurchaseOrdersCreate
     * @request POST:/api/v1/purchase-orders
     * @secure
     */
    v1PurchaseOrdersCreate: (
      data: CreatePurchaseOrderRequest,
      params: RequestParams = {},
    ) =>
      this.request<CreatePurchaseOrderResponse, any>({
        path: `/api/v1/purchase-orders`,
        method: "POST",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags PurchaseOrders
     * @name V1PurchaseOrdersList
     * @request GET:/api/v1/purchase-orders
     * @secure
     */
    v1PurchaseOrdersList: (
      query?: {
        OrderNumber?: string;
        /** @format int64 */
        SupplierId?: number;
        /** @format int32 */
        Status?: number;
        /** @format date-time */
        From?: string;
        /** @format date-time */
        To?: string;
        /** @format int32 */
        Page?: number;
        /** @format int32 */
        PageSize?: number;
      },
      params: RequestParams = {},
    ) =>
      this.request<PurchaseOrderListResponse, any>({
        path: `/api/v1/purchase-orders`,
        method: "GET",
        query: query,
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags PurchaseOrders
     * @name V1PurchaseOrdersUpdate
     * @request PUT:/api/v1/purchase-orders/{id}
     * @secure
     */
    v1PurchaseOrdersUpdate: (
      id: number,
      data: UpdatePurchaseOrderRequest,
      params: RequestParams = {},
    ) =>
      this.request<UpdatePurchaseOrderResponse, any>({
        path: `/api/v1/purchase-orders/${id}`,
        method: "PUT",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags PurchaseOrders
     * @name V1PurchaseOrdersDetail
     * @request GET:/api/v1/purchase-orders/{id}
     * @secure
     */
    v1PurchaseOrdersDetail: (id: number, params: RequestParams = {}) =>
      this.request<GetPurchaseOrderByIdResponse, any>({
        path: `/api/v1/purchase-orders/${id}`,
        method: "GET",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags PurchaseOrders
     * @name V1PurchaseOrdersCancelCreate
     * @request POST:/api/v1/purchase-orders/{id}/cancel
     * @secure
     */
    v1PurchaseOrdersCancelCreate: (id: number, params: RequestParams = {}) =>
      this.request<CancelPurchaseOrderResponse, any>({
        path: `/api/v1/purchase-orders/${id}/cancel`,
        method: "POST",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags PurchaseOrders
     * @name V1PurchaseOrdersSubmitCreate
     * @request POST:/api/v1/purchase-orders/{id}/submit
     * @secure
     */
    v1PurchaseOrdersSubmitCreate: (id: number, params: RequestParams = {}) =>
      this.request<SubmitPurchaseOrderResponse, any>({
        path: `/api/v1/purchase-orders/${id}/submit`,
        method: "POST",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags PurchaseOrders
     * @name V1PurchaseOrdersStockInCreate
     * @request POST:/api/v1/purchase-orders/{id}/stock-in
     * @secure
     */
    v1PurchaseOrdersStockInCreate: (id: number, params: RequestParams = {}) =>
      this.request<StockInPurchaseOrderResponse, any>({
        path: `/api/v1/purchase-orders/${id}/stock-in`,
        method: "POST",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags SalesOrders
     * @name V1SalesOrdersCreate
     * @request POST:/api/v1/sales-orders
     * @secure
     */
    v1SalesOrdersCreate: (
      data: CreateSalesOrderRequest,
      params: RequestParams = {},
    ) =>
      this.request<CreateSalesOrderResponse, any>({
        path: `/api/v1/sales-orders`,
        method: "POST",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags SalesOrders
     * @name V1SalesOrdersList
     * @request GET:/api/v1/sales-orders
     * @secure
     */
    v1SalesOrdersList: (
      query?: {
        OrderNumber?: string;
        /** @format int64 */
        CustomerId?: number;
        /** @format int32 */
        Status?: number;
        /** @format int32 */
        Page?: number;
        /** @format int32 */
        PageSize?: number;
      },
      params: RequestParams = {},
    ) =>
      this.request<SalesOrderListResponse, any>({
        path: `/api/v1/sales-orders`,
        method: "GET",
        query: query,
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags SalesOrders
     * @name V1SalesOrdersSubmitCreate
     * @request POST:/api/v1/sales-orders/{id}/submit
     * @secure
     */
    v1SalesOrdersSubmitCreate: (id: number, params: RequestParams = {}) =>
      this.request<SubmitSalesOrderResponse, any>({
        path: `/api/v1/sales-orders/${id}/submit`,
        method: "POST",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags SalesOrders
     * @name V1SalesOrdersDetail
     * @request GET:/api/v1/sales-orders/{id}
     * @secure
     */
    v1SalesOrdersDetail: (id: number, params: RequestParams = {}) =>
      this.request<GetSalesOrderByIdResponse, any>({
        path: `/api/v1/sales-orders/${id}`,
        method: "GET",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags SalesOrders
     * @name V1SalesOrdersCancelCreate
     * @request POST:/api/v1/sales-orders/{id}/cancel
     * @secure
     */
    v1SalesOrdersCancelCreate: (id: number, params: RequestParams = {}) =>
      this.request<CancelSalesOrderResponse, any>({
        path: `/api/v1/sales-orders/${id}/cancel`,
        method: "POST",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags SalesOrders
     * @name V1SalesOrdersStockOutCreate
     * @request POST:/api/v1/sales-orders/{id}/stock-out
     * @secure
     */
    v1SalesOrdersStockOutCreate: (id: number, params: RequestParams = {}) =>
      this.request<StockOutSalesOrderResponse, any>({
        path: `/api/v1/sales-orders/${id}/stock-out`,
        method: "POST",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Suppliers
     * @name V1SuppliersCreate
     * @request POST:/api/v1/suppliers
     * @secure
     */
    v1SuppliersCreate: (
      data: CreateSupplierRequest,
      params: RequestParams = {},
    ) =>
      this.request<CreateSupplierResponse, any>({
        path: `/api/v1/suppliers`,
        method: "POST",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Suppliers
     * @name V1SuppliersList
     * @request GET:/api/v1/suppliers
     * @secure
     */
    v1SuppliersList: (
      query?: {
        Name?: string;
        Contact?: string;
        Phone?: string;
        /** @format int32 */
        Page?: number;
        /** @format int32 */
        PageSize?: number;
      },
      params: RequestParams = {},
    ) =>
      this.request<SupplierListResponse, any>({
        path: `/api/v1/suppliers`,
        method: "GET",
        query: query,
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Suppliers
     * @name V1SuppliersUpdate
     * @request PUT:/api/v1/suppliers/{id}
     * @secure
     */
    v1SuppliersUpdate: (
      id: number,
      data: UpdateSupplierRequest,
      params: RequestParams = {},
    ) =>
      this.request<UpdateSupplierResponse, any>({
        path: `/api/v1/suppliers/${id}`,
        method: "PUT",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Suppliers
     * @name V1SuppliersDetail
     * @request GET:/api/v1/suppliers/{id}
     * @secure
     */
    v1SuppliersDetail: (id: number, params: RequestParams = {}) =>
      this.request<GetSupplierByIdResponse, any>({
        path: `/api/v1/suppliers/${id}`,
        method: "GET",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Suppliers
     * @name V1SuppliersStatusUpdate
     * @request PUT:/api/v1/suppliers/{id}/status
     * @secure
     */
    v1SuppliersStatusUpdate: (
      id: number,
      data: PatchSupplierStatusRequest,
      params: RequestParams = {},
    ) =>
      this.request<PatchSupplierStatusResponse, any>({
        path: `/api/v1/suppliers/${id}/status`,
        method: "PUT",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Users
     * @name V1UsersCreate
     * @request POST:/api/v1/users
     * @secure
     */
    v1UsersCreate: (data: CreateUserRequest, params: RequestParams = {}) =>
      this.request<CreateUserResponse, any>({
        path: `/api/v1/users`,
        method: "POST",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Users
     * @name V1UsersList
     * @request GET:/api/v1/users
     * @secure
     */
    v1UsersList: (
      query?: {
        Name?: string;
        Phone?: string;
        /** @format int32 */
        Page?: number;
        /** @format int32 */
        PageSize?: number;
      },
      params: RequestParams = {},
    ) =>
      this.request<UserListResponse, any>({
        path: `/api/v1/users`,
        method: "GET",
        query: query,
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Users
     * @name V1UsersUpdate
     * @request PUT:/api/v1/users/{id}
     * @secure
     */
    v1UsersUpdate: (
      id: number,
      data: UpdateUserRequest,
      params: RequestParams = {},
    ) =>
      this.request<UpdateUserResponse, any>({
        path: `/api/v1/users/${id}`,
        method: "PUT",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Users
     * @name V1UsersDetail
     * @request GET:/api/v1/users/{id}
     * @secure
     */
    v1UsersDetail: (id: number, params: RequestParams = {}) =>
      this.request<GetUserByIdResponse, any>({
        path: `/api/v1/users/${id}`,
        method: "GET",
        secure: true,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags Users
     * @name V1UsersStatusPartialUpdate
     * @request PATCH:/api/v1/users/{id}/status
     * @secure
     */
    v1UsersStatusPartialUpdate: (
      id: number,
      data: PatchUserStatusRequest,
      params: RequestParams = {},
    ) =>
      this.request<PatchUserStatusResponse, any>({
        path: `/api/v1/users/${id}/status`,
        method: "PATCH",
        body: data,
        secure: true,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),
  };
}
