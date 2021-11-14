using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NFS.Commons.HttpRequest
{
    public class HttpExtend
    {
        /// <summary>
        /// 实体转成get参数
        /// </summary>
        /// <typeparam name="T">请求参数实体类型</typeparam>
        /// <typeparam name="K">返回结果实体类型</typeparam>
        /// <param name="url">请求url</param>
        /// <param name="param">请求参数实体</param>
        /// <returns></returns>
        public async Task<K> Get<T, K>(string url, T param)
        {
            HttpClient httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var paramStr = ModelToHttpParam<T>.ToGetParam(param);
            var requstResult = await httpClient.GetAsync(url + paramStr);
            var result = string.Empty;
            using (requstResult)
            {
                result = await requstResult.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<K>(result);
        }

        /// <summary>
        /// 实体转成Delete参数
        /// </summary>
        /// <typeparam name="T">请求参数实体类型</typeparam>
        /// <typeparam name="K">返回结果实体类型</typeparam>
        /// <param name="url">请求url</param>
        /// <param name="param">请求参数实体</param>
        /// <returns></returns>
        public async Task<K> Delete<T, K>(string url, T param)
        {
            HttpClient httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var paramStr = ModelToHttpParam<T>.ToGetParam(param);
            var requstResult = await httpClient.DeleteAsync(url + paramStr);
            var result = string.Empty;
            using (requstResult)
            {
                result = await requstResult.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<K>(result);
        }
        /// <summary>
        /// Post请求
        /// </summary>
        /// <typeparam name="T">请求参数实体类型</typeparam>
        /// <typeparam name="K">返回结果实体类型</typeparam>
        /// <param name="url">请求url</param>
        /// <param name="param">请求参数实体</param>
        ///  T param
        /// <returns></returns>
        public async Task<K> Post<T, K>(string url,string json,Dictionary<string,string> header=null)
        {
            HttpClient httpClient = new HttpClient();
            var strContent = new StringContent(json??"");
            strContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");// ("content-type", "application/json");
            if (header != null)
            {
                foreach (var item in header)
                {
                    strContent.Headers.Add(item.Key, item.Value);
                }
            } 
            var requstResult = await httpClient.PostAsync(url,strContent);
            var result = string.Empty;
            using (requstResult)
            {
                result = await requstResult.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<K>(result);          
        }
    }

    /// <summary>
    /// 实体转Http请求参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class ModelToHttpParam<T>
    {
        /// <summary>
        /// 当前实体属性列表
        /// </summary>
        public static PropertyInfo[] PropertyInfos { get; set; }

        /// <summary>
        /// 转成get请求参数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string ToGetParam(T model)
        {
            if (model == null) return "";
            if (PropertyInfos == null || PropertyInfos.Count() == 0)
            {
                PropertyInfos = typeof(T).GetProperties();
            }
            var paramList = PropertyInfos.Select(i =>
            {
                var name = i.Name;
                var value = i.GetValue(model);
                return value == null ? "" : $"{name}={value}";
            }).Where(i => !string.IsNullOrEmpty(i)).ToList();
            return "?" + string.Join("&", paramList);
        }

        /// <summary>
        /// 转成POST请求参数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string ToPostParam(T model)
        {
            if (model == null) return "{}";
            return JsonConvert.SerializeObject(model);
        }
    }
}
