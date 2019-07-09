import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
export interface HeaderParam {
  key: string;
  value: string;
}

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  base: string;
  constructor(
    private http: HttpClient
  ) {
    this.base = '';
  }

  /**
   * Get request
   * @param  url         请求地址
   * @param  params      请求参数
   * @param  credentials 请求是否携带cookie
   */
  get<T>(url: string, params: any, credentials: boolean = false): Observable<any> {
    if (params) {
      let parameter = '?';
      Object.keys(params).forEach((i) => {
        parameter += i + '=' + params[i] + '&';
      });
      url += parameter.substring(0, parameter.length - 1);
    }
    return this._http.get<T>(this.base + url, { withCredentials: credentials });
  }

  /**
   * Post request
   * @param  url         请求地址
   * @param  params      请求参数
   * @param  headers     请求头
   * @param  credentials 请求是否携带cookie
   */
  post<T>(url: string, params: any, headers?: Array<HeaderParam>, credentials: boolean = false): Observable<any> {
    const param = {
      'Content-Type': 'text/plain'
    };
    if (headers !== undefined) {
      headers.forEach((val) => {
        param[val.key] = val.value;
      });
    }
    const httpHeaders: HttpHeaders = new HttpHeaders(param);
    return this.http.post<T>(
      this.base + url,
      JSON.stringify(params),
      {
        headers: httpHeaders,
        // set cookie to the request header
        withCredentials: credentials
      }
    );
  }

  /**
   * 通用请求
   * @param  method 请求方法
   * @param  url    请求地址
   * @param  params 请求参数
   * @param  header 请求头
   */
  request(method: 'GET' | 'POST', url: string, params: any, header?: HttpHeaders): Observable<any> {
    const req = new HttpRequest(method, this.base + url, params, {
      headers: header
    });
    return this.http.request(req);
  }

  /**
   * 获取二进制流
   * @param  method      请求方式
   * @param  url         请求地址
   * @param  params      请求参数
   * @param  credentials 请求是否携带cookie
   */
  requestStream(method: string = 'get', url: string, params: any, credentials: boolean = false): Observable<any> {
    return this.http.request(method, this.base + url, {
      params,
      responseType: 'blob',
      observe: 'response',
      withCredentials: credentials
    });
  }
}
