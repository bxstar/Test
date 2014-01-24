using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using DianChe.Model;
using NetServ.Net.Json;
using Common;
using System.IO;

namespace DianChe.WebServices.BLL
{
    public class BllTopApi
    {
        public static string url = "http://gw.api.taobao.com/router/rest";
        public static string appkey = "12275855";
        public static string appSecret = "7403d27fac0286727a4976ab18610b13";

        static ITopClient client = new DefaultTopClient(url, appkey, appSecret, "json");

        /// <summary>
        /// 淘宝在线获取宝贝信息
        /// </summary>
        public static string GetItemOnline(long item_id)
        {
            ItemGetRequest req = new ItemGetRequest();
            req.Fields = "detail_url,num_iid,title,nick,props_name,price,cid,seller_cids,pic_url,num,location";
            req.NumIid = item_id;
            ItemGetResponse response = client.Execute(req);

            return response.Body;
        }

        /// <summary>
        /// 从宝贝的Json数据中，获取结构化的宝贝对象
        /// </summary>
        public static EntityItemTask GetItemTaskFromJson(string jsonItem)
        {
            EntityItemTask model = new EntityItemTask();
            JsonObject data;
            using (JsonParser parser = new JsonParser(new StringReader(jsonItem), true))
            {
                data = parser.ParseObject();
            }
            JsonObject item_get_response = (JsonObject)data["item_get_response"];
            JsonObject item = (JsonObject)item_get_response["item"];

            if (item.ContainsKey("num_iid"))
            {
                model.item_id = Helper.JsonObjectToLong(item["num_iid"]);
            }
            if (item.ContainsKey("title"))
            {
                model.item_title = Helper.JsonObjectToString(item["title"]);
            }
            if (item.ContainsKey("nick"))
            {
                model.nick = item["nick"].ToString();
            }
            if (item.ContainsKey("pic_url"))
            {
                model.img_url = Helper.JsonObjectToString(item["pic_url"]);
            }

            if (item.ContainsKey("price"))
            {
                model.price = Helper.JsonObjectToDecimal(item["price"]);
            }

            return model;

        }

        /// <summary>
        /// 从宝贝的Json数据中，获取结构化的宝贝对象
        /// </summary>
        public static EntityItemRank GetItemRankFromJson(string jsonItem)
        {
            EntityItemRank model = new EntityItemRank();
            JsonObject data;
            using (JsonParser parser = new JsonParser(new StringReader(jsonItem), true))
            {
                data = parser.ParseObject();
            }
            JsonObject item_get_response = (JsonObject)data["item_get_response"];
            JsonObject item = (JsonObject)item_get_response["item"];

            if (item.ContainsKey("num_iid"))
            {
                model.item_id = Helper.JsonObjectToLong(item["num_iid"]);
            }
            if (item.ContainsKey("title"))
            {
                model.item_title = Helper.JsonObjectToString(item["title"]);
            }
            if (item.ContainsKey("nick"))
            {
                model.nick = item["nick"].ToString();
            }
            if (item.ContainsKey("pic_url"))
            {
                model.img_url = Helper.JsonObjectToString(item["pic_url"]);
            }

            if (item.ContainsKey("price"))
            {
                model.price = Helper.JsonObjectToDecimal(item["price"]);
            }

            return model;

        }
    }
}