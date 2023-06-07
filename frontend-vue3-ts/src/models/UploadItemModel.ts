/**
 * 上传文件模型
 */
export interface UploadItemModel {
  /** id */
  id: string;
  /** 文件名称 */
  name: string;
  /** 文件大小（byte） */
  length: number;
  /** 文件全路径 */
  url: string;
}