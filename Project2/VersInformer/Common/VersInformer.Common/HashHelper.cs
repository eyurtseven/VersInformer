using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace VersInformer.Common
{
    public static class HashHelper
    {
        private static readonly MD5 MD5;

        /// <summary>
        /// Initializes the <see cref="HashHelper"/> class.
        /// </summary>
        static HashHelper()
        {
            MD5 = MD5.Create();
        }


        public static byte[] CalculateMd5(this string value)
        {
            return value == null ? null : MD5.ComputeHash(Encoding.UTF8.GetBytes(value));
        }

        /// <summary>
        /// Calculates the MD5.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static byte[] CalculateMd5(this object value)
        {
            if (value == null) return null;

            var s = value as string;

            return MD5.ComputeHash(s != null ? Encoding.UTF8.GetBytes(s) : value.BinarySerialize());
        }
    }

    public static class SerializationHelper
    {
        private static readonly BinaryFormatter BinaryFormatter;

        static SerializationHelper()
        {
            BinaryFormatter = new BinaryFormatter();
        }

        /// <summary>
        /// Binaries the serialize.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static byte[] BinarySerialize(this object value)
        {
            byte[] bd;
            using (var ms = new MemoryStream())
            {
                BinaryFormatter.Serialize(ms, value);
                bd = ms.ToArray();
            }
            return bd;
        }

        /// <summary>
        /// Binaries the deserialize.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static T BinaryDeserialize<T>(this byte[] value)
        {
            using (var ms = new MemoryStream(value))
            {
                var a = BinaryFormatter.Deserialize(ms);
                if (a is T)
                {
                    return (T)a;
                }
                return default(T);
            }
        }

        /// <summary>
        /// To the json.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string ToJson(this object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        /// <summary>
        /// Froms the json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static T FromJson<T>(this string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }


        /// <summary>
        /// The json serializer instance
        /// </summary>
        public static readonly JsonSerializer JsonSerializerInstance = new JsonSerializer();

        /// <summary>
        /// To the bson.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static byte[] ToBson(this object value)
        {
            using(var ms = new MemoryStream())
            using (var bw = new BsonWriter(ms))
            {
                JsonSerializerInstance.Serialize(bw, value);
                bw.Flush();
                return ms.ToArray();
            }
        }


        /// <summary>
        /// Froms the bson.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static T FromBson<T>(this byte[] value)
        {
            using (var ms = new MemoryStream(value))
            using (var br = new BsonReader(ms))
            {
                return JsonSerializerInstance.Deserialize<T>(br);
            }
        }





        /// <summary>
        /// To the base64 string.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns></returns>
        public static string ToBase64String(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// To the bytes from base64 string.
        /// </summary>
        /// <param name="base64String">The base64 string.</param>
        /// <returns></returns>
        public static byte[] ToBytesFromBase64String(this string base64String)
        {
            return Convert.FromBase64String(base64String);
        }
    }
}
