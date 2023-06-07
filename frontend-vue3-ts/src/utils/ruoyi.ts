import lodash from "lodash";
/**
 * 通用ts方法封装处理
 * Copyright (c) 2019 ruoyi
 */
const baseURL = import.meta.env.VITE_APP_BASE_API;

/**
 * 日期格式化
 *
 * @param {string} time 日期
 * @param {string} pattern 格式化类型
 * @returns
 */
export const parseTime = (time: string | number | Date, pattern: string) => {
  if (!time) {
    return null;
  }
  const format = pattern || "{y}-{m}-{d} {h}:{i}:{s}";
  let date;
  if (typeof time === "object") {
    date = time;
  } else {
    if (typeof time === "string" && /^[0-9]+$/.test(time)) {
      time = parseInt(time);
    } else if (typeof time === "string") {
      time = time.replace(new RegExp(/-/gm), "/");
    }
    // prettier-ignore
    if (typeof time === "number" && time.toString().length === 10) {
      time = time * 1000;
    }
    date = new Date(time);
  }
  const formatObj: any = {
    y: date.getFullYear(),
    m: date.getMonth() + 1,
    d: date.getDate(),
    h: date.getHours(),
    i: date.getMinutes(),
    s: date.getSeconds(),
    a: date.getDay(),
  };
  // prettier-ignore
  const time_str = format.replace(/{(y|m|d|h|i|s|a)+}/g, (result: string | any[], key: string) => {
    let value = formatObj[key];
    // Note: getDay() returns 0 on Sunday
    if (key === "a") {
      return ["日", "一", "二", "三", "四", "五", "六"][value];
    }
    if (result.length > 0 && value < 10) {
      value = "0" + value;
    }
    return value || 0;
  });
  return time_str;
};

/**
 * 日期时间截取
 *
 * @param dateTime 日期时间
 * @returns
 */
export const dateTimeSub = (dateTime: any) => {
  if (!dateTime) {
    return "";
  }
  if (dateTime instanceof String) {
    if (dateTime.length > 10) {
      return dateTime.substring(0, 10);
    } else {
      return dateTime;
    }
  } else {
    const str = dateTime.toString();
    if (dateTime.length > 10) {
      return str.substring(0, 10);
    } else {
      return str;
    }
  }
};

/**
 * 表单重置
 *
 * @param {string} formRef
 */
export const resetForm = (formRef: any) => {
  formRef.value?.resetFields();
};

/**
 * 清除表格选中
 *
 * @param tableRef 表格ref
 */
export const cleanTableSelection = (tableRef: any) => {
  tableRef.value?.clearSelection();
};

/**
 * 设置表格行是否为选中状态
 *
 * @param tableRef  表格ref
 * @param row       表格行
 * @param selected  是否选中
 */
// prettier-ignore
export const setTableRowSelected = (tableRef: any, row: any, selected: boolean) => {
  // 设置当前行被选中
  tableRef.value?.toggleRowSelection(row, selected);
};


// 添加日期范围
// prettier-ignore
export const addDateRange = (params: any, dateRange: any[], propName: string) => {
  let search = params;
  search.params = typeof (search.params) === 'object' && search.params !== null && !Array.isArray(search.params) ? search.params : {};
  dateRange = Array.isArray(dateRange) ? dateRange : [];
  if (dateRange) {
    if (typeof propName !== "undefined") {
      const firstCode = propName.substring(0, 1);
      if (!isUpCase(firstCode)) {
        propName = firstCode.toUpperCase() + propName.substring(1);
      } else {
        propName = firstCode + propName.substring(1);
      }
      search.params["begin" + propName] = dateRange[0];
      search.params["end" + propName] = dateRange[1];
    } else {
      search.params["beginTime"] = dateRange[0];
      search.params["endTime"] = dateRange[1];
    }
  }
  return search;
};

// 回显数据字典
export const selectDictLabel = (
  datas: any,
  value: string | undefined,
  separator: undefined
) => {
  if (!value || !datas) {
    return "";
  }
  let actions: any = [];
  Object.keys(datas).some((key) => {
    if (datas[key].dictValue == "" + value) {
      actions.push(datas[key].dictLabel);
      return true;
    }
  });
  if (actions.length === 0) {
    actions.push(value);
  }
  return actions.join("");
};

// 回显数据字典（字符串数组）
export const selectDictLabels = (
  datas: any,
  value: string | undefined,
  separator: undefined
) => {
  if (value === undefined || !datas) {
    return "";
  }
  let actions: any = [];
  var currentSeparator = undefined === separator ? "," : separator;
  var temp: any = value.split(currentSeparator);
  Object.keys(value.split(currentSeparator)).some((val) => {
    Object.keys(datas).some((key) => {
      if (datas[key].dictValue == "" + temp[val]) {
        actions.push(datas[key].dictLabel + currentSeparator);
      }
    });
  });
  return actions.join("").substring(0, actions.join("").length - 1);
};

// 通用下载方法
export const download = (fileName: string) => {
  // prettier-ignore
  console.log("通用下载方法，文件名", fileName);
  // prettier-ignore
  window.location.href = baseURL + "/common/download?fileName=" + encodeURI(fileName) + "&delete=" + true;
};

// 字符串格式化(%s )
export const sprintf = (str: string) => {
  let args: any[];
  let flag = true;
  let i = 1;
  str = str.replace(/%s/g, function () {
    var arg = args[i++];
    if (typeof arg === "undefined") {
      flag = false;
      return "";
    }
    return arg;
  });
  return flag ? str : "";
};

// 转换字符串，undefined,null等转化为""
export function praseStrEmpty(str: string) {
  if (!str || str == "undefined" || str == "null") {
    return "";
  }
  return str;
}

// 数据合并
// prettier-ignore
export const mergeRecursive = (source: { [x: string]: any; }, target: { [x: string]: any; }) => {
  for (var p in target) {
    try {
      if (target[p].constructor == Object) {
        source[p] = mergeRecursive(source[p], target[p]);
      } else {
        source[p] = target[p];
      }
    } catch (e) {
      source[p] = target[p];
    }
  }
  return source;
};

/**
 * 构造树型结构数据
 * @param {*} data 数据源
 * @param {*} id id字段 默认 'id'
 * @param {*} parentId 父节点字段 默认 'parentId'
 * @param {*} children 孩子节点字段 默认 'children'
 */
// prettier-ignore
export const handleTree = (data: any, id: any, parentId: any, children: any) => {
  let config = {
    id: id || "id",
    parentId: parentId || "parentId",
    childrenList: children || "children",
  };

  var childrenListMap: any = {};
  var nodeIds: any = {};
  var tree = [];

  for (let d of data) {
    let parentId = d[config.parentId];
    if (childrenListMap[parentId] == null) {
      childrenListMap[parentId] = [];
    }
    nodeIds[d[config.id]] = d;
    childrenListMap[parentId].push(d);
  }

  for (let d of data) {
    let parentId = d[config.parentId];
    if (nodeIds[parentId] == null) {
      tree.push(d);
    }
  }

  for (let t of tree) {
    adaptToChildrenList(t);
  }

  function adaptToChildrenList(o: { [x: string]: any; }) {
    if (childrenListMap[o[config.id]] !== null) {
      o[config.childrenList] = childrenListMap[o[config.id]];
    }
    if (o[config.childrenList]) {
      for (let c of o[config.childrenList]) {
        adaptToChildrenList(c);
      }
    }
  }
  return tree;
};

/**
 * 参数处理
 *
 * @param {*} params  参数
 */
export function tansParams(params: { [x: string]: any }) {
  let result = "";
  for (const propName of Object.keys(params)) {
    const value = params[propName];
    var part = encodeURIComponent(propName) + "=";
    if (value !== null && value !== "" && typeof value !== "undefined") {
      if (typeof value === "object") {
        for (const key of Object.keys(value)) {
          // prettier-ignore
          if (value[key] !== null && value !== "" && typeof value[key] !== "undefined") {
            let params = propName + "[" + key + "]";
            var subPart = encodeURIComponent(params) + "=";
            result += subPart + encodeURIComponent(value[key]) + "&";
          }
        }
      } else {
        result += part + encodeURIComponent(value) + "&";
      }
    }
  }
  return result;
}

// 验证是否为blob格式
export const blobValidate = async (data: any) => {
  let b = false;
  try {
    const text = await data.text();
    JSON.parse(text);
    b = false;
  } catch (error) {
    b = true;
  }
  return b;
};

/**
 * 判断字母是否是大写
 *
 * @param {string} str
 * @returns
 */
export const isUpCase = (str: any) => {
  if (!str) {
    return false;
  }
  let bool = false;
  const strCode = str.charCodeAt();
  // 大写
  if (strCode >= 65 && strCode <= 90) {
    bool = false;
  } else if (strCode >= 97 && strCode <= 122) {
    // 小写
    bool = true;
  } else {
    console.error(`不是字母`);
    throw new Error(`不是字母`);
  }
  return bool;
};

// 返回项目路径
export const getNormalPath = (p: string) => {
  if (p.length === 0 || !p || p == "undefined") {
    return p;
  }
  let res = p.replace("//", "/");
  if (res[res.length - 1] === "/") {
    return res.slice(0, res.length - 1);
  }
  return res;
};

/**
 * 通用防抖
 *
 * @param callback 回调函数
 * @param wait     等待毫秒数
 * @param type     回调函数额外参数
 * @param options  防抖额外参数
 * @returns
 */
// prettier-ignore
export const lodashFunc = (callback: Function, wait: number, type?: any, options?: any) => {
  return lodash.debounce(function () {
    type ? callback(type) : callback();
  }, wait, options);
};

/**
 * 随机返回数组中的某个元素
 *
 * @param arr 数组
 * @returns
 */
export const getRadomForArr = <T>(arr: Array<T>) => {
  return arr[Math.floor(Math.random() * arr.length)];
};
