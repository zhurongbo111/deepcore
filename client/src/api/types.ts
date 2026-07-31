/** 适用于后端返回的 RFC 7807 标准校验错误响应 */
export interface HttpValidationError {
  type: string;
  title: string;
  status: number;
  /** 错误信息字典：key 为字段名，value 为该字段的错误消息列表 */
  errors: Record<string, string[]>;
  traceId: string;
}
