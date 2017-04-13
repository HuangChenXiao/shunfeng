using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using UFIDA.U8.U8APIFramework;
using UFIDA.U8.U8APIFramework.Parameter;
using UFIDA.U8.U8MOMAPIFramework;
using MSXML2;
using shunfeng.model;

namespace shunfeng.api
{
    public class U8_fAp_Voucah_Add
    {
        public bool U8_fAp_Voucah(Ap_Vouch main,List<Ap_Vouchs> detailList,out string resultmsg)
        {
            //第一步：构造u8login对象并登陆(引用U8API类库中的Interop.U8Login.dll)
            //如果当前环境中有login对象则可以省去第一步
            U8Login.clsLogin u8Login = new U8Login.clsLogin();
            String sSubId = "AS";
            String sAccID = "(default)@888";
            String sYear = "2008";
            String sUserID = "demo";
            String sPassword = "";
            String sDate = "2008-11-11";
            String sServer = "localhost";
            String sSerial = "";
            if (!u8Login.Login(ref sSubId, ref sAccID, ref sYear, ref sUserID, ref sPassword, ref sDate, ref sServer, ref sSerial))
            {
                resultmsg = "登陆失败，原因：" + u8Login.ShareString;
                Marshal.FinalReleaseComObject(u8Login);
                return false;
            }

            //第二步：构造环境上下文对象，传入login，并按需设置其它上下文参数
            U8EnvContext envContext = new U8EnvContext();
            envContext.U8Login = u8Login;

            //设置上下文参数
            envContext.SetApiContext("VouchType", "应付单"); //上下文数据类型：string，含义：单据类型：应付单

            //第三步：设置API地址标识(Url)
            //当前API：新增或修改的地址标识为：U8API/APVouch/SaveVouch
            U8ApiAddress myApiAddress = new U8ApiAddress("U8API/APVouch/SaveVouch");

            //第四步：构造APIBroker
            U8ApiBroker broker = new U8ApiBroker(myApiAddress, envContext);

            //第五步：API参数赋值

            //给BO表头参数ohead赋值，此BO参数的业务类型为应付单，属表头参数。BO参数均按引用传递
            //提示：给BO表头参数ohead赋值有两种方法

            //方法一是直接传入MSXML2.DOMDocumentClass对象
            //broker.AssignNormalValue("ohead", new MSXML2.DOMDocumentClass())

            //方法二是构造BusinessObject对象，具体方法如下：
            BusinessObject ohead = broker.GetBoParam("ohead");
            ohead.RowCount = 1; //设置BO对象(表头)行数，只能为一行
            //给BO对象(表头)的字段赋值，值可以是真实类型，也可以是无类型字符串
            //以下代码示例只设置第一行值。各字段定义详见API服务接口定义

            /****************************** 以下是必输字段 ****************************/
            ohead[0]["cLink"] = ""; //主关键字段，2类型
            ohead[0]["dVouchDate"] = main.dVouchDate; //单据日期，DateTime类型
            ohead[0]["cVenAbbName"] = ""; //供应商名称，string类型
            ohead[0]["cexch_name"] = main.cexch_name; //币种，string类型
            ohead[0]["iAmount_f"] = main.iAmount_f; //金额，double类型
            ohead[0]["cVenName"] = ""; //供应商全称，string类型
            ohead[0]["cPluginsourcetype"] = ""; //插件单据来源，string类型
            ohead[0]["iPluginsourceautoid"] = ""; //插件单据子表id_int型，string类型
            ohead[0]["cPluginsourceautoid"] = ""; //插件单据子表id_文本型，string类型
            ohead[0]["csysbarcode"] = ""; //单据条码，string类型
            ohead[0]["cVouchID"] = main.cVouchID; //单据编号，string类型
            ohead[0]["dverifydate"] = main.dverifydate; //审核日期，DateTime类型
            ohead[0]["iExchRate"] = main.iExchRate; //汇率，double类型
            ohead[0]["cDeptCode"] = main.cDeptCode; //部门编号，string类型
            ohead[0]["cCode"] = main.cCode; //科目，string类型
            ohead[0]["iAmount"] = main.iAmount; //本币金额，double类型

            /***************************** 以下是非必输字段 ****************************/
            ohead[0]["cGatheringPlan"] = ""; //收付款协议编码，string类型
            ohead[0]["cGatheringPlanName"] = ""; //收付款协议，string类型
            ohead[0]["dCreditStart"] = ""; //立账日，DateTime类型
            ohead[0]["iCreditPeriod"] = ""; //账期，int类型
            ohead[0]["dGatheringDate"] = ""; //到期日，DateTime类型
            ohead[0]["iAmount_s"] = ""; //数量，double类型
            ohead[0]["cDepName"] = ""; //部门，string类型
            ohead[0]["cPersonName"] = ""; //业务员，string类型
            ohead[0]["cItemName"] = ""; //项目，string类型
            ohead[0]["cPayName"] = ""; //付款条件，string类型
            ohead[0]["cDigest"] = ""; //摘要，string类型
            ohead[0]["cOperator"] = ""; //录入人，string类型
            ohead[0]["cCheckMan"] = ""; //审核人，string类型
            ohead[0]["cDefine15"] = ""; //表头自定义项15，int类型
            ohead[0]["cDefine11"] = ""; //表头自定义项11，string类型
            ohead[0]["cDefine13"] = ""; //表头自定义项13，string类型
            ohead[0]["cDefine12"] = ""; //表头自定义项12，string类型
            ohead[0]["cDefine14"] = ""; //表头自定义项14，string类型
            ohead[0]["cDefine16"] = ""; //表头自定义项16，double类型
            ohead[0]["cCoVouchType"] = ""; //对应单据类型，string类型
            ohead[0]["VT_ID"] = ""; //模版号，string类型
            ohead[0]["Auto_ID"] = ""; //自动编号，int类型
            ohead[0]["cTypeName"] = ""; //单据类型，string类型
            ohead[0]["cFlag"] = ""; //应收应付标志，string类型
            ohead[0]["cVouchType"] = ""; //单据类型编号，string类型
            ohead[0]["cVouchID1"] = ""; //对应单据，string类型
            ohead[0]["cDefine1"] = ""; //表头自定义项1，string类型
            ohead[0]["cDwCode"] = ""; //供应商编号，string类型
            ohead[0]["iRAmount"] = ""; //本币余额，double类型
            ohead[0]["iRAmount_f"] = ""; //余额，double类型
            ohead[0]["cItem_Class"] = ""; //项目大类编码，string类型
            ohead[0]["iRAmount_s"] = ""; //数量余额，double类型
            ohead[0]["dcreatesystime"] = ""; //制单时间，DateTime类型
            ohead[0]["dverifysystime"] = ""; //审核时间，DateTime类型
            ohead[0]["dmodifysystime"] = ""; //修改时间，DateTime类型
            ohead[0]["cmodifier"] = ""; //修改人，string类型
            ohead[0]["dmoddate"] = ""; //修改日期，DateTime类型
            ohead[0]["cItemCode"] = ""; //项目编码，string类型
            ohead[0]["cPerson"] = ""; //业务员号，string类型
            ohead[0]["cPayCode"] = ""; //付款条件编号，string类型
            ohead[0]["Ufts"] = ""; //时间戳，string类型
            ohead[0]["cDefine10"] = ""; //表头自定义项10，string类型
            ohead[0]["cDefine2"] = ""; //表头自定义项2，string类型
            ohead[0]["cDefine3"] = ""; //表头自定义项3，string类型
            ohead[0]["cDefine4"] = ""; //表头自定义项4，DateTime类型
            ohead[0]["cDefine5"] = ""; //表头自定义项5，int类型
            ohead[0]["cDefine6"] = ""; //表头自定义项6，DateTime类型
            ohead[0]["cDefine8"] = ""; //表头自定义项8，string类型
            ohead[0]["cDefine7"] = ""; //表头自定义项7，double类型
            ohead[0]["cDefine9"] = ""; //表头自定义项9，string类型
            ohead[0]["ccode_name"] = ""; //科目名称，string类型

            //给BO表体参数obody赋值，此BO参数的业务类型为应付单，属表体参数。BO参数均按引用传递
            //提示：给BO表体参数obody赋值有两种方法

            //方法一是直接传入MSXML2.DOMDocumentClass对象
            //broker.AssignNormalValue("obody", new MSXML2.DOMDocumentClass())

            //方法二是构造BusinessObject对象，具体方法如下：
            BusinessObject obody = broker.GetBoParam("obody");
            obody.RowCount = 10; //设置BO对象行数
            //可以自由设置BO对象行数为大于零的整数，也可以不设置而自动增加行数
            //给BO对象的字段赋值，值可以是真实类型，也可以是无类型字符串
            //以下代码示例只设置第一行值。各字段定义详见API服务接口定义
            foreach (var item in detailList)
            {
            /****************************** 以下是必输字段 ****************************/
            obody[0]["Auto_id"] = ""; //主关键字段，0类型
            obody[0]["editprop"] = ""; //编辑属性：A表新增，M表修改，D表删除，string类型
            obody[0]["bd_c"] = item.bd_c; //借贷方向，string类型
            obody[0]["cCode"] = item.cCode; //科目，string类型
            obody[0]["iAmount"] = item.iAmount; //本币金额，double类型
            obody[0]["iAmount_f"] = item.iAmount_f; //金额，double类型
            obody[0]["iExchRate"] = item.iExchRate; //汇率，double类型
            obody[0]["cDigest"] = item.cDigest; //摘要，string类型

            /***************************** 以下是非必输字段 ****************************/
            obody[0]["cDefine22"] = ""; //表体自定义项1，string类型
            obody[0]["cDefine23"] = ""; //表体自定义项2，string类型
            obody[0]["cDefine24"] = ""; //表体自定义项3，string类型
            obody[0]["cDefine25"] = ""; //表体自定义项4，string类型
            obody[0]["cDefine26"] = ""; //表体自定义项5，double类型
            obody[0]["iAmt_s"] = ""; //数量，double类型
            obody[0]["cDefine27"] = ""; //表体自定义项6，double类型
            obody[0]["cDefine28"] = ""; //表体自定义项7，string类型
            obody[0]["cDefine29"] = ""; //表体自定义项8，string类型
            obody[0]["cDefine30"] = ""; //表体自定义项9，string类型
            obody[0]["cExpCode"] = ""; //费用项目编码，string类型
            obody[0]["cDefine31"] = ""; //表体自定义项10，string类型
            obody[0]["cDefine32"] = ""; //表体自定义项11，string类型
            obody[0]["cExpName"] = ""; //费用项目，string类型
            obody[0]["iTaxRate"] = ""; //税率，int类型
            obody[0]["cDefine33"] = ""; //表体自定义项12，string类型
            obody[0]["cDefine34"] = ""; //表体自定义项13，int类型
            obody[0]["iTax"] = ""; //税额，double类型
            obody[0]["iNatTax"] = ""; //本币税额，double类型
            obody[0]["cDefine35"] = ""; //表体自定义项14，int类型
            obody[0]["cDefine36"] = ""; //表体自定义项15，DateTime类型
            obody[0]["cDefine37"] = ""; //表体自定义项16，DateTime类型
            obody[0]["ccode_name"] = ""; //科目名称，string类型
            obody[0]["cLink"] = ""; //联结号，string类型
            obody[0]["cDirection"] = ""; //方向，string类型
            obody[0]["cDeptCode"] = ""; //部门编号，string类型
            obody[0]["cPerson"] = ""; //业务员号，string类型
            obody[0]["cPersonName"] = ""; //业务员，string类型
            obody[0]["cItem_Class"] = ""; //项目大类编码，string类型
            obody[0]["cItemCode"] = ""; //项目编码，string类型
            obody[0]["cDepName"] = ""; //部门，string类型
            obody[0]["cItemName"] = ""; //项目，string类型


            }
            //该参数xmlmsg为INOUT型普通参数。此参数的数据类型为System.String，此参数按值传递。在API调用返回时，可以通过GetResult("xmlmsg")获取其值
            broker.AssignNormalValue("xmlmsg", "");

            //给普通参数isadd赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示true新增，false修改
            broker.AssignNormalValue("isadd", true);

            //第六步：调用API
            if (!broker.Invoke())
            {
                resultmsg = "系统调用api异常!";
                //错误处理
                Exception apiEx = broker.GetException();
                if (apiEx != null)
                {
                    if (apiEx is MomSysException)
                    {
                        MomSysException sysEx = apiEx as MomSysException;
                        resultmsg = "系统异常：" + sysEx.Message;
                        //todo:异常处理
                    }
                    else if (apiEx is MomBizException)
                    {
                        MomBizException bizEx = apiEx as MomBizException;
                        resultmsg = "API异常：" + bizEx.Message;
                        //todo:异常处理
                    }
                    //异常原因
                    String exReason = broker.GetExceptionString();
                    if (exReason.Length != 0)
                    {
                        resultmsg = "异常原因：" + exReason;
                    }
                }
                //结束本次调用，释放API资源
                broker.Release();
                return false;
            }


            //第七步：获取返回结果

            //获取返回值
            //获取普通返回值。此返回值数据类型为System.Boolean，此参数按值传递，表示
            System.Boolean result = Convert.ToBoolean(broker.GetReturnValue());

            //获取out/inout参数值

            //获取普通INOUT参数xmlmsg。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
            resultmsg = broker.GetResult("xmlmsg") as System.String;

            //结束本次调用，释放API资源
            broker.Release();
            return true;
        }
    }
}
