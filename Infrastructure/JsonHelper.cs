using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Infrastructure
{
    /// <summary>
    /// Json序列化帮助类
    /// </summary>
    public class JsonHelper
    {
        private static JsonHelper jsonHelper = new JsonHelper();

        /// <summary>
        /// 实例化类
        /// </summary>
        public static JsonHelper Instance { get { return jsonHelper; } }

        /// <summary>
        /// Json序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
        }

        /// <summary>
        /// Json反序列化
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="str">json字符串</param>
        /// <returns></returns>
        public T Deserialize<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}