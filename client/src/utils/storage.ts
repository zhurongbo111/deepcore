/**
 * 存储项包装接口（用于支持 TTL 过期时间）
 */
interface StorageData<T> {
  value: T;
  /** 过期绝对时间戳 (毫秒)，undefined 表示永不过期 */
  expiry?: number;
}

/**
 * Storage 配置选项
 */
export interface StorageOptions {
  /** 存储类型，默认为 'local' */
  type?: 'local' | 'session';
  /** Key 前缀（防止不同项目或模块间键名冲突） */
  prefix?: string;
  /** 默认过期时间（秒） */
  defaultTTL?: number;
}

/**
 * 通用 WebStorage 管理类
 */
export class StorageManager {
  private storage: Storage | null = null;
  private prefix: string;
  private defaultTTL?: number;

  constructor(options: StorageOptions = {}) {
    const { type = 'local', prefix = '', defaultTTL } = options;
    this.prefix = prefix;
    this.defaultTTL = defaultTTL;

    // SSR 兼容性检查
    if (typeof window !== 'undefined') {
      this.storage = type === 'local' ? window.localStorage : window.sessionStorage;
    }
  }

  /**
   * 拼接包含前缀的完整 Key
   */
  private getKey(key: string): string {
    return `${this.prefix}${key}`;
  }

  /**
   * 检查当前环境是否支持 Storage
   */
  public isSupported(): boolean {
    return this.storage !== null;
  }

  /**
   * 设置存储项
   * @param key 键名
   * @param value 存储值（支持任意可序列化对象）
   * @param ttl 过期时间（单位：秒）。不传则使用默认配置或永不过期
   */
  public set<T = unknown>(key: string, value: T, ttl?: number): boolean {
    if (!this.storage) return false;

    try {
      const actualTTL = ttl ?? this.defaultTTL;
      const data: StorageData<T> = { value };

      if (actualTTL && actualTTL > 0) {
        data.expiry = Date.now() + actualTTL * 1000;
      }

      const serialized = JSON.stringify(data);
      this.storage.setItem(this.getKey(key), serialized);
      return true;
    } catch (error) {
      console.error(`[StorageManager] Error setting key "${key}":`, error);
      return false;
    }
  }

  /**
   * 获取存储项
   * @param key 键名
   * @param defaultValue 当值不存在或已过期时的默认返回值
   */
  public get<T = unknown>(key: string, defaultValue: T | null = null): T | null {
    if (!this.storage) return defaultValue;

    const fullKey = this.getKey(key);
    const itemStr = this.storage.getItem(fullKey);

    if (!itemStr) return defaultValue;

    try {
      const data: StorageData<T> = JSON.parse(itemStr);

      // 过期检查
      if (data.expiry && Date.now() > data.expiry) {
        this.remove(key); // 已过期，自动清理
        return defaultValue;
      }

      return data.value;
    } catch (error) {
      console.error(`[StorageManager] Error parsing key "${key}":`, error);
      return defaultValue;
    }
  }

  /**
   * 移除指定存储项
   */
  public remove(key: string): void {
    if (!this.storage) return;
    this.storage.removeItem(this.getKey(key));
  }

  /**
   * 判断是否存在指定的 Key 且未过期
   */
  public has(key: string): boolean {
    return this.get(key) !== null;
  }

  /**
   * 清空当前实例命名空间下的所有存储项
   */
  public clear(): void {
    if (!this.storage) return;

    if (!this.prefix) {
      this.storage.clear();
      return;
    }

    const keysToRemove: string[] = [];
    for (let i = 0; i < this.storage.length; i++) {
      const fullKey = this.storage.key(i);
      if (fullKey && fullKey.startsWith(this.prefix)) {
        keysToRemove.push(fullKey);
      }
    }

    keysToRemove.forEach((key) => this.storage?.removeItem(key));
  }

  /**
   * 获取当前前缀下的所有非过期 Key 列表
   */
  public keys(): string[] {
    if (!this.storage) return [];

    const result: string[] = [];
    for (let i = 0; i < this.storage.length; i++) {
      const fullKey = this.storage.key(i);
      if (fullKey && fullKey.startsWith(this.prefix)) {
        const rawKey = fullKey.slice(this.prefix.length);
        if (this.has(rawKey)) {
          result.push(rawKey);
        }
      }
    }
    return result;
  }
}

// 预创建单例导出
export const localStore = new StorageManager({ type: 'local', prefix: 'dpcore_' });
export const sessionStore = new StorageManager({ type: 'session', prefix: 'dpcore_' });
