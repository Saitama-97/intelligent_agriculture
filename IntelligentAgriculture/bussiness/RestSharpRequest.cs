
using IntelligentAgriculture.Bussiness;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace easy_fix.Bussiness
{
    public class RestSharpRequest
    {
        private string BaseUrl = System.Configuration.ConfigurationManager.AppSettings["Request_Url"]; //string BaseUrl = "http://58.220.234.147:8090/water/";

        //查询运企
        public List<operationEnAndLic> restsharp_operationEnterprise(string R_prov, string R_city)
        {
            ///// RestSharp post 请求 ///////
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("miniapp/company/query", Method.POST);
            request.AddParameter("prov", R_prov);
            request.AddParameter("city", R_city);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");


            MyLogHelper.Info("BaseUrl:" + BaseUrl);


            IRestResponse response = client.Execute(request);
            var content = response.Content;
            // JObject json1 = (JObject)JsonConvert.DeserializeObject(content);
            if (content.Equals("")) { return null; }
            else
            {


                //把拿到的进行反序列化
                try
                {
                    List<codeAndName> responseObj = JsonConvert.DeserializeObject<List<codeAndName>>(content);

                    //格式转换
                    List<operationEnAndLic> operationObj = new List<operationEnAndLic>();
                    for (int i = 0; i < responseObj.Count; i++)
                    {
                        operationEnAndLic s = new operationEnAndLic();
                        s.operationEnterpriseCode = responseObj[i].code;
                        s.operationEnterprise = responseObj[i].name;
                        operationObj.Add(s);

                    }
                    return operationObj;
                }
                catch (Exception)
                {

                    throw;
                }




            }
        }

        //查询车队
        public List<fleetAndCode> restsharp_fleet(string company)
        {
            ///// RestSharp post 请求 ///////
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("miniapp/busgroup/query", Method.POST);
            request.AddParameter("company", company);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");


            MyLogHelper.Info("BaseUrl:" + BaseUrl);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            // JObject json1 = (JObject)JsonConvert.DeserializeObject(content);
            if (content.Equals("")) { return null; }
            else
            {
                //把拿到的进行反序列化
                try
                {
                    List<codeAndName> responseObj = JsonConvert.DeserializeObject<List<codeAndName>>(content);

                    //格式转换
                    List<fleetAndCode> returnObj = new List<fleetAndCode>();
                    for (int i = 0; i < responseObj.Count; i++)
                    {
                        fleetAndCode s = new fleetAndCode();
                        s.fleetcode = responseObj[i].code;
                        s.fleet = responseObj[i].name;
                        returnObj.Add(s);

                    }
                    return returnObj;
                }
                catch (Exception)
                {

                    throw;
                }




            }
        }



        //设备和车绑定关系变更  (设备ID和注册车牌在后台库中不一致，或者该设备不存在)
        public string restsharp_devBind(string devId, string busNo)
        {
            ///// RestSharp post 请求 ///////
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("driverpl/dev/bind", Method.POST);
            request.AddParameter("devId", devId);
            request.AddParameter("busNo", busNo);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");


            MyLogHelper.Info("BaseUrl:" + BaseUrl);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            // JObject json1 = (JObject)JsonConvert.DeserializeObject(content);
            if (content.Equals("")) { return "没有数据"; }
            else
            {
                //把拿到的进行反序列化
                try
                {

                    successObj responseObj = JsonConvert.DeserializeObject<successObj>(content);
                    if (responseObj.success.Equals("false"))
                    {
                        failedObj failedObj = JsonConvert.DeserializeObject<failedObj>(content);

                        return failedObj.message;
                    }
                    else
                    {
                        return "ok";

                    }


                }
                catch (Exception)
                {

                    throw;
                }




            }
        }

      

        //	用户收益查询
        public successUserWallet restsharp_userWallet(string userId)
        {
            ///// RestSharp post 请求 ///////
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("miniapp/user/wallet", Method.POST);
            request.AddParameter("userId", userId);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");


            MyLogHelper.Info("BaseUrl:" + BaseUrl);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            // JObject json1 = (JObject)JsonConvert.DeserializeObject(content);
            if (content.Equals("")) { return null; }
            else
            {
                //把拿到的进行反序列化
                try
                {


                    if (content.Equals("{}"))
                    {


                        return null;
                    }
                    else
                    {
                        successUserWallet responseObj = JsonConvert.DeserializeObject<successUserWallet>(content);
                        return responseObj;

                    }


                }
                catch (Exception)
                {

                    throw;
                }




            }
        }

        //用户提现
        public string restsharp_userWithDraw(string userId, string money)
        {
            ///// RestSharp post 请求 ///////
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("driverpl/user/withdraw", Method.POST);
            request.AddParameter("userId", userId);
            request.AddParameter("money", money);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");


            MyLogHelper.Info("BaseUrl:" + BaseUrl);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            // JObject json1 = (JObject)JsonConvert.DeserializeObject(content);
            if (content.Equals("")) { return "没有数据"; }
            else
            {
                //把拿到的进行反序列化
                try
                {

                    successObj responseObj = JsonConvert.DeserializeObject<successObj>(content);
                    if (responseObj.success.Equals("false"))
                    {
                        failedErrObj failedObj = JsonConvert.DeserializeObject<failedErrObj>(content);

                        return failedObj.err;
                    }
                    else
                    {
                        return "ok";

                    }


                }
                catch (Exception)
                {

                    throw;
                }




            }
        }

        //收益排行榜
        public successUserRank restsharp_userRank(string prov, string city, string company, string startTime, string endTime, string pageSize, string pageNo, string userId)
        {
            ///// RestSharp post 请求 ///////
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("miniapp/user/rank", Method.POST);
            request.AddParameter("prov", prov);
            request.AddParameter("city", city);
            request.AddParameter("company", company);
            request.AddParameter("startTime", startTime);
            request.AddParameter("endTime", endTime);
            request.AddParameter("pageSize", pageSize);
            request.AddParameter("pageNo", pageNo);
            request.AddParameter("userId", userId);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");


            MyLogHelper.Info("BaseUrl:" + BaseUrl);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            // JObject json1 = (JObject)JsonConvert.DeserializeObject(content);
            if (content.Equals("")) { return null; }
            else
            {
                //把拿到的进行反序列化
                try
                {


                    if (content.Equals("{}"))
                    {


                        return null;
                    }
                    else
                    {
                        successUserRank responseObj = JsonConvert.DeserializeObject<successUserRank>(content);
                        return responseObj;

                    }


                }
                catch (Exception)
                {

                    throw;
                }




            }
        }

        //查询每日收益
        public List<successUserWalletDetail> restsharp_userWalletDetail(string userId, string startTime, string endTime)
        {
            ///// RestSharp post 请求 ///////
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("miniapp/user/wallet/detail", Method.POST);
            request.AddParameter("userId", userId);
            request.AddParameter("startTime", startTime);
            request.AddParameter("endTime", endTime);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");


            MyLogHelper.Info("BaseUrl:" + BaseUrl);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            // JObject json1 = (JObject)JsonConvert.DeserializeObject(content);
            if (content.Equals("")) { return null; }
            else
            {
                //把拿到的进行反序列化
                try
                {


                    if (content.Equals("{}"))
                    {


                        return null;
                    }
                    else
                    {
                        List<successUserWalletDetail> responseObj = JsonConvert.DeserializeObject<List<successUserWalletDetail>>(content);
                        return responseObj;

                    }


                }
                catch (Exception)
                {

                    throw;
                }




            }
        }

     

     

        //网络请求
        public string doRequest(string url, Dictionary<string, object> dicts)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);

            foreach (KeyValuePair<string, object> kv in dicts)
            {
                string pkey = kv.Key;
                var pvalue = kv.Value;
                request.AddParameter(pkey, pvalue);
            }

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return content;
        }

        //网络请求--去掉非空字段
        public string doRequest_NoNULL(string url, Dictionary<string, object> dicts)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);

            foreach (KeyValuePair<string, object> kv in dicts)
            {
                if (kv.Value != null)
                {
                    string pkey = kv.Key;
                    var pvalue = kv.Value;
                    request.AddParameter(pkey, pvalue);
                }
            }

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return content;
        }
    }


    //只有code和name的
    public class codeAndName
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    //运企查询对象
    public class operationEnAndLic
    {
        public string operationEnterpriseCode { get; set; }
        public string operationEnterprise { get; set; }

    }

    //车队查询
    public class fleetAndCode
    {
        public string fleetcode { get; set; }
        public string fleet { get; set; }

    }

    //成功 success
    public class successObj
    {
        public string success { get; set; }
    }
    //短信上失败的
    public class failedObj
    {
        public string success { get; set; }
        public string message { get; set; }
    }

    //设备绑定的失败
    public class failedBindObj
    {
        public string success { get; set; }
        public string errCode { get; set; }
        public string errMsg { get; set; }
    }
    //设备开网的失败
    public class failedErrObj
    {
        public string success { get; set; }
        public string err { get; set; }
    }

    //用户收益查询
    public class successUserWallet
    {
        public string total { get; set; }
        public string today { get; set; }
        public string valid { get; set; }
    }

    //收益排行榜
    public class successUserRank
    {
        public string mine { get; set; }
        public List<RankItem> rank { get; set; }
    }

    //收益排行榜中的rankItem
    public class RankItem
    {

        public string userId { get; set; }
        public int order { get; set; }
        public string busNo { get; set; }
        public double money { get; set; }
    }

    //查询每日收益
    public class successUserWalletDetail
    {
        public string day { get; set; }
        public string money { get; set; }
    }

    //实名认证车牌号
    public class successBusNo
    {
        public string busNo { get; set; }

    }

    //查询每日收益
    public class successDriverLic
    {
        public string name { get; set; }
        public string lic { get; set; }
    }

    //用户收益的对象
    public class UserRankRequest
    {
        public string prov { get; set; }
        public string city { get; set; }
        public string company { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string pageSize { get; set; }
        public string pageNo { get; set; }
    }
}
