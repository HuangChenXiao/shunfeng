﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using UFIDA.U8.U8APIFramework;
using UFIDA.U8.U8APIFramework.Parameter;
using UFIDA.U8.U8MOMAPIFramework;
using MSXML2;
using shunfeng.model;

namespace shunfeng.api.API
{
    public class U8_TransVouch_Add
    {
        public bool U8_TransVouch(TransVouch main,List<TransVouchs> detailList,out string resultmsg) 
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

            //第三步：设置API地址标识(Url)
            //当前API：添加新单据的地址标识为：U8API/TransVouch/Add
            U8ApiAddress myApiAddress = new U8ApiAddress("U8API/TransVouch/Add");

            //第四步：构造APIBroker
            U8ApiBroker broker = new U8ApiBroker(myApiAddress, envContext);

            //第五步：API参数赋值

            //给普通参数sVouchType赋值。此参数的数据类型为System.String，此参数按值传递，表示单据类型：12
            broker.AssignNormalValue("sVouchType", "12");

            //给BO表头参数DomHead赋值，此BO参数的业务类型为调拨单，属表头参数。BO参数均按引用传递
            //提示：给BO表头参数DomHead赋值有两种方法

            //方法一是直接传入MSXML2.DOMDocumentClass对象
            //broker.AssignNormalValue("DomHead", new MSXML2.DOMDocumentClass())

            //方法二是构造BusinessObject对象，具体方法如下：
            BusinessObject DomHead = broker.GetBoParam("DomHead");
            DomHead.RowCount = 1; //设置BO对象(表头)行数，只能为一行
            //给BO对象(表头)的字段赋值，值可以是真实类型，也可以是无类型字符串
            //以下代码示例只设置第一行值。各字段定义详见API服务接口定义

            /****************************** 以下是必输字段 ****************************/
            DomHead[0]["id"] = ""; //主关键字段，int类型
            DomHead[0]["ctvcode"] = main.cTVCode; //单据号，string类型
            DomHead[0]["dtvdate"] = main.dTVDate; //日期，DateTime类型
            DomHead[0]["cwhname"] = ""; //转出仓库，string类型
            DomHead[0]["cwhname_1"] = ""; //转入仓库，string类型
            DomHead[0]["chinvsn"] = ""; //序列号，string类型
            DomHead[0]["ireturncount"] = ""; //ireturncount，string类型
            DomHead[0]["iverifystate"] = ""; //iverifystate，string类型
            DomHead[0]["iswfcontrolled"] = ""; //iswfcontrolled，string类型
            DomHead[0]["cbustype"] = ""; //业务类型，string类型
            DomHead[0]["csourcecodels"] = ""; //零售来源单号，string类型
            DomHead[0]["csysbarcode"] = ""; //单据条码，string类型
            DomHead[0]["cmaker"] = main.cMaker; //制单人，string类型
            DomHead[0]["dverifydate"] = main.dVerifyDate; //审核日期，DateTime类型
            DomHead[0]["codepcode"] = main.cODepCode; //转出部门编码，string类型
            DomHead[0]["cidepcode"] = main.cIDepCode; //转入部门编码，string类型
            DomHead[0]["cowhcode"] = main.cOWhCode; //转出仓库编码，string类型
            DomHead[0]["ciwhcode"] = main.cIWhCode; //转入仓库编码，string类型
            DomHead[0]["cordcode"] = main.cORdCode; //出库类别编码，string类型
            DomHead[0]["cirdcode"] = main.cIRdCode; //入库类别编码，string类型

            /***************************** 以下是非必输字段 ****************************/
            DomHead[0]["cmodifyperson"] = ""; //修改人，string类型
            DomHead[0]["dmodifydate"] = ""; //修改日期，DateTime类型
            DomHead[0]["dnmaketime"] = ""; //制单时间，DateTime类型
            DomHead[0]["dnmodifytime"] = ""; //修改时间，DateTime类型
            DomHead[0]["dnverifytime"] = ""; //审核时间，DateTime类型
            DomHead[0]["ctranrequestcode"] = ""; //调拨申请单号，string类型
            DomHead[0]["cdepname_1"] = ""; //转出部门，string类型
            DomHead[0]["cdepname"] = ""; //转入部门，string类型
            DomHead[0]["crdname_1"] = ""; //出库类别，string类型
            DomHead[0]["crdname"] = ""; //入库类别，string类型
            DomHead[0]["cpersonname"] = ""; //经手人，string类型
            DomHead[0]["ctvmemo"] = ""; //备注，string类型
            DomHead[0]["parentscrp"] = ""; //母件损耗率(％)，double类型
            DomHead[0]["csource"] = ""; //单据来源，int类型
            DomHead[0]["iamount"] = ""; //现存量，string类型
            DomHead[0]["cverifyperson"] = ""; //审核人，string类型
            DomHead[0]["cfree1"] = ""; //自由项1，string类型
            DomHead[0]["cfree2"] = ""; //自由项2，string类型
            DomHead[0]["cfree3"] = ""; //自由项3，string类型
            DomHead[0]["cfree4"] = ""; //自由项4，string类型
            DomHead[0]["cfree5"] = ""; //自由项5，string类型
            DomHead[0]["cfree6"] = ""; //自由项6，string类型
            DomHead[0]["cfree7"] = ""; //自由项7，string类型
            DomHead[0]["cfree8"] = ""; //自由项8，string类型
            DomHead[0]["cfree9"] = ""; //自由项9，string类型
            DomHead[0]["cfree10"] = ""; //自由项10，string类型
            DomHead[0]["ufts"] = ""; //时间戳，string类型
            DomHead[0]["cpersoncode"] = ""; //经手人编码，string类型
            DomHead[0]["cmpocode"] = ""; //订单号，string类型
            DomHead[0]["cpspcode"] = ""; //产品结构，string类型
            DomHead[0]["btransflag"] = ""; //是否传递，string类型
            DomHead[0]["vt_id"] = ""; //模版号，int类型
            DomHead[0]["iquantity"] = ""; //产量，double类型
            DomHead[0]["iavaquantity"] = ""; //可用量，string类型
            DomHead[0]["iavanum"] = ""; //可用件数，string类型
            DomHead[0]["ipresentnum"] = ""; //现存件数，string类型
            DomHead[0]["iproorderid"] = ""; //生产订单ID，string类型
            DomHead[0]["cversion"] = ""; //版本号／替代标识，string类型
            DomHead[0]["bomid"] = ""; //bomid，string类型
            DomHead[0]["cordertype"] = ""; //订单类型，string类型
            DomHead[0]["cinvname"] = ""; //产品名称，string类型
            DomHead[0]["ilowsum"] = ""; //最低库存量，string类型
            DomHead[0]["itopsum"] = ""; //最高库存量，string类型
            DomHead[0]["cdefine16"] = ""; //表头自定义项16，double类型
            DomHead[0]["isafesum"] = ""; //安全库存量，string类型
            DomHead[0]["caccounter"] = ""; //记账人，string类型
            DomHead[0]["ipresent"] = ""; //现存量，string类型
            DomHead[0]["cdefine1"] = ""; //表头自定义项1，string类型
            DomHead[0]["cdefine2"] = ""; //表头自定义项2，string类型
            DomHead[0]["cdefine3"] = ""; //表头自定义项3，string类型
            DomHead[0]["cdefine4"] = ""; //表头自定义项4，DateTime类型
            DomHead[0]["itransflag"] = ""; //调拨方向，int类型
            DomHead[0]["cdefine5"] = ""; //表头自定义项5，int类型
            DomHead[0]["cdefine6"] = ""; //表头自定义项6，DateTime类型
            DomHead[0]["cdefine7"] = ""; //表头自定义项7，double类型
            DomHead[0]["cdefine8"] = ""; //表头自定义项8，string类型
            DomHead[0]["cdefine9"] = ""; //表头自定义项9，string类型
            DomHead[0]["cdefine10"] = ""; //表头自定义项10，string类型
            DomHead[0]["cdefine11"] = ""; //表头自定义项11，string类型
            DomHead[0]["cdefine12"] = ""; //表头自定义项12，string类型
            DomHead[0]["cdefine13"] = ""; //表头自定义项13，string类型
            DomHead[0]["cdefine14"] = ""; //表头自定义项14，string类型
            DomHead[0]["cdefine15"] = ""; //表头自定义项15，int类型

            //给BO表体参数domBody赋值，此BO参数的业务类型为调拨单，属表体参数。BO参数均按引用传递
            //提示：给BO表体参数domBody赋值有两种方法

            //方法一是直接传入MSXML2.DOMDocumentClass对象
            //broker.AssignNormalValue("domBody", new MSXML2.DOMDocumentClass())

            //方法二是构造BusinessObject对象，具体方法如下：
            BusinessObject domBody = broker.GetBoParam("domBody");
            domBody.RowCount = 10; //设置BO对象行数
            //可以自由设置BO对象行数为大于零的整数，也可以不设置而自动增加行数
            //给BO对象的字段赋值，值可以是真实类型，也可以是无类型字符串
            //以下代码示例只设置第一行值。各字段定义详见API服务接口定义
            foreach (var item in detailList)
            {
            /****************************** 以下是必输字段 ****************************/
            domBody[0]["autoid"] = ""; //主关键字段，int类型
            domBody[0]["cinvcode"] = item.cInvCode; //存货编码，string类型
            domBody[0]["editprop"] = ""; //编辑属性：A表新增，M表修改，D表删除，string类型
            domBody[0]["strowguid"] = ""; //rowguid，string类型
            domBody[0]["cbatchproperty7"] = ""; //批次属性7，string类型
            domBody[0]["cbatchproperty8"] = ""; //批次属性8，string类型
            domBody[0]["cbatchproperty9"] = ""; //批次属性9，string类型
            domBody[0]["cbatchproperty10"] = ""; //批次属性10，string类型
            domBody[0]["cciqbookcode"] = ""; //手册号，string类型
            domBody[0]["cbmemo"] = ""; //备注，string类型
            domBody[0]["irowno"] = item.irowno; //行号，string类型
            domBody[0]["cbinvsn"] = ""; //序列号，string类型
            domBody[0]["cbatchproperty1"] = ""; //批次属性1，string类型
            domBody[0]["iinvsncount"] = ""; //序列号个数，string类型
            domBody[0]["cbatchproperty2"] = ""; //批次属性2，string类型
            domBody[0]["cbatchproperty3"] = ""; //批次属性3，string类型
            domBody[0]["cbatchproperty4"] = ""; //批次属性4，string类型
            domBody[0]["cbatchproperty5"] = ""; //批次属性5，string类型
            domBody[0]["cbatchproperty6"] = ""; //批次属性6，string类型
            domBody[0]["ipresent"] = ""; //现存量，string类型
            domBody[0]["ipresentnum"] = ""; //现存件数，string类型
            domBody[0]["iavaquantity"] = ""; //可用量，string类型
            domBody[0]["iavanum"] = ""; //可用件数，string类型
            domBody[0]["cbsysbarcode"] = ""; //单据行条码，string类型
            domBody[0]["cinvouchtype"] = ""; //对应入库单类型，string类型
            domBody[0]["cbsourcecodels"] = ""; //零售来源单号，string类型
            domBody[0]["cmolotcode"] = ""; //生产批号，string类型
            domBody[0]["cinvoucherlineid"] = ""; //源单行ID，string类型
            domBody[0]["cinvouchercode"] = ""; //源单号，string类型
            domBody[0]["cinvouchertype"] = ""; //源单类型，string类型
            domBody[0]["taskguid"] = ""; //taskguid，string类型
            domBody[0]["itvquantity"] = item.iTVQuantity; //数量，double类型

            /***************************** 以下是非必输字段 ****************************/
            domBody[0]["issodid"] = ""; //销售订单子表ID，string类型
            domBody[0]["idsodid"] = ""; //目标销售订单子表ID，string类型
            domBody[0]["itrids"] = ""; //调拨申请单子表ID，int类型
            domBody[0]["cbarcode"] = ""; //条形码，string类型
            domBody[0]["cbvencode"] = ""; //供应商编码，string类型
            domBody[0]["cinvaddcode"] = ""; //存货代码，string类型
            domBody[0]["cinvname"] = ""; //存货名称，string类型
            domBody[0]["cvenname"] = ""; //供应商，string类型
            domBody[0]["imassdate"] = ""; //保质期，int类型
            domBody[0]["cassunit"] = ""; //库存单位码，string类型
            domBody[0]["dmadedate"] = ""; //生产日期，DateTime类型
            domBody[0]["corufts"] = ""; //对应单据时间戳，string类型
            domBody[0]["cinvstd"] = ""; //规格型号，string类型
            domBody[0]["cmassunit"] = ""; //保质期单位，int类型
            domBody[0]["cdsocode"] = ""; //目标需求跟踪号，string类型
            domBody[0]["csocode"] = ""; //需求跟踪号，string类型
            domBody[0]["cinvm_unit"] = ""; //主计量单位，string类型
            domBody[0]["cinposname"] = ""; //调入货位，string类型
            domBody[0]["cinposcode"] = ""; //调入货位编码，string类型
            domBody[0]["coutposname"] = ""; //调出货位，string类型
            domBody[0]["coutposcode"] = ""; //调出货位编码，string类型
            domBody[0]["cvmivencode"] = ""; //代管商代码，string类型
            domBody[0]["cvmivenname"] = ""; //代管商，string类型
            domBody[0]["cfree1"] = ""; //存货自由项1，string类型
            domBody[0]["cfree3"] = ""; //存货自由项3，string类型
            domBody[0]["cfree4"] = ""; //存货自由项4，string类型
            domBody[0]["cfree5"] = ""; //存货自由项5，string类型
            domBody[0]["cfree6"] = ""; //存货自由项6，string类型
            domBody[0]["cfree7"] = ""; //存货自由项7，string类型
            domBody[0]["cfree8"] = ""; //存货自由项8，string类型
            domBody[0]["cfree9"] = ""; //存货自由项9，string类型
            domBody[0]["cfree10"] = ""; //存货自由项10，string类型
            domBody[0]["cfree2"] = ""; //存货自由项2，string类型
            domBody[0]["ctvbatch"] = ""; //批号，string类型
            domBody[0]["itvnum"] = ""; //件数，double类型
            domBody[0]["iinvexchrate"] = ""; //换算率，double类型
            domBody[0]["cinvdefine13"] = ""; //存货自定义项13，string类型
            domBody[0]["cinvdefine14"] = ""; //存货自定义项14，string类型
            domBody[0]["itvacost"] = ""; //单价，double类型
            domBody[0]["csdemandmemo"] = ""; //需求分类代号说明，string类型
            domBody[0]["cddemandmemo"] = ""; //目标需求分类代号说明，string类型
            domBody[0]["comcode"] = ""; //委外订单号，string类型
            domBody[0]["cmocode"] = ""; //生产订单号，string类型
            domBody[0]["invcode"] = ""; //产品编码，string类型
            domBody[0]["invname"] = ""; //产品，string类型
            domBody[0]["imoseq"] = ""; //生产订单行号，string类型
            domBody[0]["iomids"] = ""; //iomids，int类型
            domBody[0]["imoids"] = ""; //imoids，int类型
            domBody[0]["iexpiratdatecalcu"] = ""; //有效期推算方式，int类型
            domBody[0]["cexpirationdate"] = ""; //有效期至，string类型
            domBody[0]["dexpirationdate"] = ""; //有效期计算项，string类型
            domBody[0]["itvaprice"] = ""; //金额，double类型
            domBody[0]["itvpcost"] = ""; //计划单价／售价，double类型
            domBody[0]["isoseq"] = ""; //需求跟踪行号，string类型
            domBody[0]["issotype"] = ""; //需求跟踪方式，int类型
            domBody[0]["idsoseq"] = ""; //目标需求跟踪行号，string类型
            domBody[0]["idsotype"] = ""; //目标需求跟踪方式，int类型
            domBody[0]["bcosting"] = ""; //是否核算，string类型
            domBody[0]["itvpprice"] = ""; //计划金额／售价金额，double类型
            domBody[0]["cinva_unit"] = ""; //库存单位，string类型
            domBody[0]["ddisdate"] = ""; //失效日期，DateTime类型
            domBody[0]["cdefine36"] = ""; //表体自定义项15，DateTime类型
            domBody[0]["cdefine37"] = ""; //表体自定义项16，DateTime类型
            domBody[0]["cinvdefine15"] = ""; //存货自定义项15，string类型
            domBody[0]["cinvdefine16"] = ""; //存货自定义项16，string类型
            domBody[0]["cposition"] = ""; //货位编码，string类型
            domBody[0]["creplaceitem"] = ""; //替换件，string类型
            domBody[0]["cinvdefine1"] = ""; //存货自定义项1，string类型
            domBody[0]["cinvdefine2"] = ""; //存货自定义项2，string类型
            domBody[0]["cinvdefine3"] = ""; //存货自定义项3，string类型
            domBody[0]["rdsid"] = ""; //对应入库单id，int类型
            domBody[0]["cdefine34"] = ""; //表体自定义项13，int类型
            domBody[0]["cdefine35"] = ""; //表体自定义项14，int类型
            domBody[0]["impoids"] = ""; //生产订单子表Id，int类型
            domBody[0]["ctvcode"] = ""; //单据号，string类型
            domBody[0]["cinvouchcode"] = ""; //对应入库单号，string类型
            domBody[0]["cdefine22"] = ""; //表体自定义项1，string类型
            domBody[0]["cdefine28"] = ""; //表体自定义项7，string类型
            domBody[0]["cdefine29"] = ""; //表体自定义项8，string类型
            domBody[0]["cdefine30"] = ""; //表体自定义项9，string类型
            domBody[0]["cdefine31"] = ""; //表体自定义项10，string类型
            domBody[0]["cdefine32"] = ""; //表体自定义项11，string类型
            domBody[0]["cdefine33"] = ""; //表体自定义项12，string类型
            domBody[0]["cinvdefine4"] = ""; //存货自定义项4，string类型
            domBody[0]["cinvdefine5"] = ""; //存货自定义项5，string类型
            domBody[0]["cinvdefine6"] = ""; //存货自定义项6，string类型
            domBody[0]["cinvdefine7"] = ""; //存货自定义项7，string类型
            domBody[0]["cinvdefine8"] = ""; //存货自定义项8，string类型
            domBody[0]["cinvdefine9"] = ""; //存货自定义项9，string类型
            domBody[0]["cinvdefine10"] = ""; //存货自定义项10，string类型
            domBody[0]["cinvdefine11"] = ""; //存货自定义项11，string类型
            domBody[0]["cinvdefine12"] = ""; //存货自定义项12，string类型
            domBody[0]["cdefine23"] = ""; //表体自定义项2，string类型
            domBody[0]["cdefine24"] = ""; //表体自定义项3，string类型
            domBody[0]["cdefine25"] = ""; //表体自定义项4，string类型
            domBody[0]["cdefine26"] = ""; //表体自定义项5，double类型
            domBody[0]["cdefine27"] = ""; //表体自定义项6，double类型
            domBody[0]["citemcode"] = ""; //项目编码，string类型
            domBody[0]["cname"] = ""; //项目，string类型
            domBody[0]["citem_class"] = ""; //项目大类编码，string类型
            domBody[0]["fsalecost"] = ""; //零售单价，double类型
            domBody[0]["fsaleprice"] = ""; //零售金额，double类型
            domBody[0]["citemcname"] = ""; //项目大类名称，string类型
            domBody[0]["igrossweight"] = ""; //毛重，string类型
            domBody[0]["inetweight"] = ""; //净重，string类型


            }
            //给普通参数domPosition赋值。此参数的数据类型为System.Object，此参数按引用传递，表示货位：传空
            broker.AssignNormalValue("domPosition", new System.Object());

            //该参数errMsg为OUT型参数，由于其数据类型为System.String，为一般值类型，因此不必传入一个参数变量。在API调用返回时，可以通过GetResult("errMsg")获取其值

            //给普通参数cnnFrom赋值。此参数的数据类型为ADODB.Connection，此参数按引用传递，表示连接对象,如果由调用方控制事务，则需要设置此连接对象，否则传空
            broker.AssignNormalValue("cnnFrom", new ADODB.Connection());

            //该参数VouchId为INOUT型普通参数。此参数的数据类型为System.String，此参数按值传递。在API调用返回时，可以通过GetResult("VouchId")获取其值
            broker.AssignNormalValue("VouchId", "");

            //该参数domMsg为OUT型参数，由于其数据类型为MSXML2.IXMLDOMDocument2，非一般值类型，因此必须传入一个参数变量。在API调用返回时，可以直接使用该参数
            MSXML2.IXMLDOMDocument2 domMsg = new DOMDocument();
            broker.AssignNormalValue("domMsg", domMsg);

            //给普通参数bCheck赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否控制可用量。
            broker.AssignNormalValue("bCheck", new System.Boolean());

            //给普通参数bBeforCheckStock赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示检查可用量
            broker.AssignNormalValue("bBeforCheckStock", new System.Boolean());

            //给普通参数bIsRedVouch赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否红字单据
            broker.AssignNormalValue("bIsRedVouch", new System.Boolean());

            //给普通参数sAddedState赋值。此参数的数据类型为System.String，此参数按值传递，表示传空字符串
            broker.AssignNormalValue("sAddedState", "");

            //给普通参数bReMote赋值。此参数的数据类型为System.Boolean，此参数按值传递，表示是否远程：转入false
            broker.AssignNormalValue("bReMote", new System.Boolean());

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
                        Console.WriteLine("系统异常：" + sysEx.Message);
                        //todo:异常处理
                    }
                    else if (apiEx is MomBizException)
                    {
                        MomBizException bizEx = apiEx as MomBizException;
                        Console.WriteLine("API异常：" + bizEx.Message);
                        //todo:异常处理
                    }
                    //异常原因
                    String exReason = broker.GetExceptionString();
                    if (exReason.Length != 0)
                    {
                        Console.WriteLine("异常原因：" + exReason);
                    }
                }
                //结束本次调用，释放API资源
                broker.Release();
                return false;
            }

            //第七步：获取返回结果

            //获取返回值
            //获取普通返回值。此返回值数据类型为System.Boolean，此参数按值传递，表示返回值:true:成功,false:失败
            System.Boolean result = Convert.ToBoolean(broker.GetReturnValue());

            //获取out/inout参数值

            //获取普通OUT参数errMsg。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
            resultmsg = broker.GetResult("errMsg") as System.String;

            //获取普通INOUT参数VouchId。此返回值数据类型为System.String，在使用该参数之前，请判断是否为空
            System.String VouchIdRet = broker.GetResult("VouchId") as System.String;

            //获取普通OUT参数domMsg。此返回值数据类型为MSXML2.IXMLDOMDocument2，在使用该参数之前，请判断是否为空
            //MSXML2.IXMLDOMDocument2 domMsgRet = Convert.ToObject(broker.GetResult("domMsg"));

            //结束本次调用，释放API资源
            broker.Release();
            return true;
        }
    }
}
