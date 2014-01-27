using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DianChe
{
    public class ModelUtil
    {
        /// <summary>
        /// 将EntityItemTask本地实体转化为WebService实体
        /// </summary>
        public static DianCheWebService.EntityItemTask ConvertLocalToWs(Model.EntityItemTask localModel)
        {
            DianCheWebService.EntityItemTask wsModel = new DianCheWebService.EntityItemTask();
            wsModel.local_item_task_id = localModel.local_item_task_id;
            wsModel.nick = localModel.nick;
            wsModel.item_id = localModel.item_id;
            wsModel.item_title = localModel.item_title;
            wsModel.img_url = localModel.img_url;
            wsModel.price = localModel.price;
            wsModel.creative_one_title = localModel.creative_one_title;
            wsModel.creative_two_title = localModel.creative_two_title;
            wsModel.keyword = localModel.keyword;
            wsModel.effect_start_time = localModel.effect_start_time;
            wsModel.effect_end_time = localModel.effect_end_time;
            wsModel.max_click = localModel.max_click;
            wsModel.run_days = localModel.run_days;
            wsModel.create_time = localModel.create_time;
            wsModel.update_time = localModel.update_time;
            wsModel.remark = localModel.remark;
            wsModel.is_enable = localModel.is_enable;

            return wsModel;
        }

        /// <summary>
        /// 将EntityItemClick，WebService实体转化为本地实体
        /// </summary>
        public static List<Model.EntityItemClick> ConvertWsToLocal(List<DianCheWebService.EntityItemClick> lstWsModel)
        {
            //List<Model.EntityItemClick> lstLocalModel = new List<Model.EntityItemClick>();
            return lstWsModel.Select(o => new Model.EntityItemClick() { item_id = o.item_id, item_title = o.item_title, 
                creative_one_title = o.creative_one_title, creative_two_title = o.creative_two_title, 
                keyword = o.keyword, create_time = DateTime.Now, update_time = DateTime.Now }).ToList();
        }

        /// <summary>
        /// 将EntityItemTask，WebService实体转化为本地实体
        /// </summary>
        public static Model.EntityItemTask ConvertWsToLocal(DianCheWebService.EntityItemTask wsModel)
        {
            Model.EntityItemTask localModel = new Model.EntityItemTask();
            localModel.item_id = wsModel.item_id;
            localModel.item_title = wsModel.item_title;
            localModel.nick = wsModel.nick;
            localModel.img_url = wsModel.img_url;
            localModel.price = wsModel.price;

            return localModel;
        }

        /// <summary>
        /// 将EntityItemRank，WebService实体转化为本地实体
        /// </summary>
        public static Model.EntityItemRank ConvertWsLocal(DianCheWebService.EntityItemRank wsModel)
        {
            Model.EntityItemRank localModel = new Model.EntityItemRank();
            localModel.item_id = wsModel.item_id;
            localModel.item_title = wsModel.item_title;
            localModel.nick = wsModel.nick;
            localModel.img_url = wsModel.img_url;
            localModel.price = wsModel.price;

            return localModel;
        }
    }
}
