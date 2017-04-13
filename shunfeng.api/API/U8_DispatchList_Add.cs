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
    public class U8_DispatchList_Add
    {
        public bool U8_DispatchList(DispatchList main, List<DispatchLists> detailList, out string resultmsg)
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

            //销售所有接口均支持内部独立事务和外部事务，默认内部事务
            //如果是外部事务，则需要传递ADO.Connection对象，并将IsIndependenceTransaction属性设置为false
            //envContext.BizDbConnection = new ADO.Connection();
            //envContext.IsIndependenceTransaction = false;

            //设置上下文参数
            envContext.SetApiContext("VoucherType", 9); //上下文数据类型：int，含义：单据类型：9

            //第三步：设置API地址标识(Url)
            //当前API：新增或修改的地址标识为：U8API/Consignment/Save
            U8ApiAddress myApiAddress = new U8ApiAddress("U8API/Consignment/Save");

            //第四步：构造APIBroker
            U8ApiBroker broker = new U8ApiBroker(myApiAddress, envContext);

            //第五步：API参数赋值

            //给BO表头参数domHead赋值，此BO参数的业务类型为发货单，属表头参数。BO参数均按引用传递
            //提示：给BO表头参数domHead赋值有两种方法

            //方法一是直接传入MSXML2.DOMDocumentClass对象
            //broker.AssignNormalValue("domHead", new MSXML2.DOMDocumentClass())

            //方法二是构造BusinessObject对象，具体方法如下：
            BusinessObject domHead = broker.GetBoParam("domHead");
            domHead.RowCount = 1; //设置BO对象(表头)行数，只能为一行
            //给BO对象(表头)的字段赋值，值可以是真实类型，也可以是无类型字符串
            //以下代码示例只设置第一行值。各字段定义详见API服务接口定义

            /****************************** 以下是必输字段 ****************************/
            domHead[0]["dlid"] = ""; //主关键字段，int类型
            domHead[0]["cdlcode"] = main.cDLCode; //发货单号，string类型
            domHead[0]["ddate"] = main.dDate; //发货日期，DateTime类型
            domHead[0]["cbustype"] = ""; //业务类型，int类型
            domHead[0]["cstname"] = ""; //销售类型，string类型
            domHead[0]["ccusabbname"] = ""; //客户简称，string类型
            domHead[0]["cdepname"] = ""; //销售部门，string类型
            domHead[0]["cstcode"] = main.cSTCode; //销售类型编码，string类型
            domHead[0]["separateid"] = ""; //分拣号，string类型
            domHead[0]["cchangememo"] = ""; //变更原因，string类型
            domHead[0]["bsigncreate"] = ""; //签回损失生成，string类型
            domHead[0]["cinvoicecompany"] = ""; //开票单位编码，string类型
            domHead[0]["cinvoicecompanyabbname"] = ""; //开票单位简称，string类型
            domHead[0]["febweight"] = ""; //重量，string类型
            domHead[0]["cebweightunit"] = ""; //重量单位，string类型
            domHead[0]["cebexpresscode"] = ""; //快递单号，string类型
            domHead[0]["iebexpresscoid"] = ""; //物流公司ID，string类型
            domHead[0]["cexpressconame"] = ""; //物流公司名称，string类型
            domHead[0]["iflowid"] = ""; //流程id，string类型
            domHead[0]["cflowname"] = ""; //流程分支描述，string类型
            domHead[0]["bcashsale"] = ""; //现款结算，string类型
            domHead[0]["cgathingcode"] = ""; //收款单号，string类型
            domHead[0]["cchanger"] = ""; //变更人，string类型
            domHead[0]["ccushand"] = ""; //客户联系人手机，string类型
            domHead[0]["cpsnophone"] = ""; //业务员办公电话，string类型
            domHead[0]["cpsnmobilephone"] = ""; //业务员手机，string类型
            domHead[0]["ccuspersoncode"] = ""; //联系人编码，string类型
            domHead[0]["brequestsign"] = ""; //需要签回，string类型
            domHead[0]["bmustbook"] = ""; //必有定金，string类型
            domHead[0]["baccswitchflag"] = ""; //存货核算切换选项，string类型
            domHead[0]["dsverifydate"] = ""; //来源单据审核日期，string类型
            domHead[0]["csourcecode"] = ""; //来源单据号，string类型
            domHead[0]["csscode"] = ""; //结算方式编码，string类型
            domHead[0]["cssname"] = ""; //结算方式，string类型
            domHead[0]["csysbarcode"] = ""; //单据条码，string类型
            domHead[0]["bsaleoutcreatebill"] = ""; //出库单开发票，string类型
            domHead[0]["bnottogoldtax"] = ""; //bnottogoldtax，string类型
            domHead[0]["dverifydate"] = main.dverifydate; //审核日期，DateTime类型
            domHead[0]["ccuscode"] = main.cCusCode; //客户编码，string类型
            domHead[0]["cdepcode"] = main.cDepCode; //部门编码，string类型
            domHead[0]["cexch_name"] = main.cexch_name; //币种，string类型
            domHead[0]["iexchrate"] = main.iExchRate; //汇率，double类型
            domHead[0]["cmaker"] = main.cMaker; //制单人，string类型
            domHead[0]["cverifier"] = main.cVerifier; //审核人，string类型

            /***************************** 以下是非必输字段 ****************************/
            domHead[0]["caddcode"] = ""; //收货地址编码，string类型
            domHead[0]["cdeliverunit"] = ""; //收货单位，string类型
            domHead[0]["ccontactname"] = ""; //收货联系人，string类型
            domHead[0]["cofficephone"] = ""; //收货联系电话，string类型
            domHead[0]["cmobilephone"] = ""; //收货联系人手机，string类型
            domHead[0]["fstockquanO"] = ""; //现存件数，double类型
            domHead[0]["fcanusequanO"] = ""; //可用件数，double类型
            domHead[0]["iverifystate"] = ""; //iverifystate，string类型
            domHead[0]["ireturncount"] = ""; //ireturncount，string类型
            domHead[0]["icreditstate"] = ""; //icreditstate，string类型
            domHead[0]["iswfcontrolled"] = ""; //iswfcontrolled，string类型
            domHead[0]["csocode"] = ""; //订单号，string类型
            domHead[0]["csbvcode"] = ""; //发票号，string类型
            domHead[0]["cpersonname"] = ""; //业 务 员，string类型
            domHead[0]["cshipaddress"] = ""; //发货地址，string类型
            domHead[0]["cscname"] = ""; //发运方式，string类型
            domHead[0]["cpayname"] = ""; //付款条件，string类型
            domHead[0]["itaxrate"] = ""; //税率，double类型
            domHead[0]["cmemo"] = ""; //备    注，string类型
            domHead[0]["ccloser"] = ""; //关闭人，string类型
            domHead[0]["ccuspaycond"] = ""; //客户付款条件，string类型
            domHead[0]["sbvid"] = ""; //销售发票ID，string类型
            domHead[0]["isale"] = ""; //是否先发货，string类型
            domHead[0]["ivtid"] = ""; //单据模版号，int类型
            domHead[0]["ccusname"] = ""; //客户名称，string类型
            domHead[0]["ccusphone"] = ""; //联系电话，string类型
            domHead[0]["ccusperson"] = ""; //联系人，string类型
            domHead[0]["ccuspostcode"] = ""; //邮政编码，string类型
            domHead[0]["icuscreline"] = ""; //用户信用度，double类型
            domHead[0]["ccusaddress"] = ""; //客户地址，string类型
            domHead[0]["iarmoney"] = ""; //客户应收余额，double类型
            domHead[0]["cpersoncode"] = ""; //业务员编码，string类型
            domHead[0]["bfirst"] = ""; //期初标志，string类型
            domHead[0]["cvouchname"] = ""; //单据类型名称，int类型
            domHead[0]["cvouchtype"] = ""; //单据类型编码，string类型
            domHead[0]["cmodifier"] = ""; //修改人，string类型
            domHead[0]["dmoddate"] = ""; //修改日期，DateTime类型
            domHead[0]["csvouchtype"] = ""; //csvouchtype，string类型
            domHead[0]["dcreatesystime"] = ""; //制单时间，DateTime类型
            domHead[0]["dverifysystime"] = ""; //审核时间，DateTime类型
            domHead[0]["dmodifysystime"] = ""; //修改时间，DateTime类型
            domHead[0]["csccode"] = ""; //发运方式编码，string类型
            domHead[0]["cpaycode"] = ""; //付款条件编码，string类型
            domHead[0]["breturnflag"] = ""; //退货标识，string类型
            domHead[0]["brefdisp"] = ""; //单据来源，string类型
            domHead[0]["ccrechpname"] = ""; //信用审核人，string类型
            domHead[0]["fstockquan"] = ""; //现存数量，double类型
            domHead[0]["fcanusequan"] = ""; //可用数量，double类型
            domHead[0]["ccusdefine1"] = ""; //客户自定义项1，string类型
            domHead[0]["ccusdefine2"] = ""; //客户自定义项2，string类型
            domHead[0]["ccusdefine3"] = ""; //客户自定义项3，string类型
            domHead[0]["ccusdefine4"] = ""; //客户自定义项4，string类型
            domHead[0]["ccusdefine5"] = ""; //客户自定义项5，string类型
            domHead[0]["ccusdefine6"] = ""; //客户自定义项6，string类型
            domHead[0]["ccusdefine7"] = ""; //客户自定义项7，string类型
            domHead[0]["ccusdefine8"] = ""; //客户自定义项8，string类型
            domHead[0]["ccusdefine9"] = ""; //客户自定义项9，string类型
            domHead[0]["ccusdefine10"] = ""; //客户自定义项10，string类型
            domHead[0]["ccusdefine11"] = ""; //客户自定义项11，string类型
            domHead[0]["ccusdefine12"] = ""; //客户自定义项12，string类型
            domHead[0]["ccusdefine13"] = ""; //客户自定义项13，string类型
            domHead[0]["ccusdefine14"] = ""; //客户自定义项14，string类型
            domHead[0]["ccusdefine15"] = ""; //客户自定义项15，string类型
            domHead[0]["ccusdefine16"] = ""; //客户自定义项16，string类型
            domHead[0]["cdefine1"] = ""; //表头自定义项1，string类型
            domHead[0]["cdefine2"] = ""; //表头自定义项2，string类型
            domHead[0]["cdefine3"] = ""; //表头自定义项3，string类型
            domHead[0]["cdefine4"] = ""; //表头自定义项4，DateTime类型
            domHead[0]["cdefine5"] = ""; //表头自定义项5，int类型
            domHead[0]["cdefine6"] = ""; //表头自定义项6，DateTime类型
            domHead[0]["cdefine7"] = ""; //表头自定义项7，double类型
            domHead[0]["cdefine8"] = ""; //表头自定义项8，string类型
            domHead[0]["cdefine9"] = ""; //表头自定义项9，string类型
            domHead[0]["cdefine10"] = ""; //表头自定义项10，string类型
            domHead[0]["cdefine11"] = ""; //表头自定义项11，string类型
            domHead[0]["cdefine12"] = ""; //表头自定义项12，string类型
            domHead[0]["cdefine13"] = ""; //表头自定义项13，string类型
            domHead[0]["cdefine14"] = ""; //表头自定义项14，string类型
            domHead[0]["cdefine15"] = ""; //表头自定义项15，int类型
            domHead[0]["cdefine16"] = ""; //表头自定义项16，double类型
            domHead[0]["ufts"] = ""; //时间戳，string类型
            domHead[0]["zdsumdx"] = ""; //整单合计（大写），string类型
            domHead[0]["isumdx"] = ""; //价税合计（大写），string类型
            domHead[0]["zdsum"] = ""; //整单合计，double类型
            domHead[0]["isumx"] = ""; //价税合计，double类型
            domHead[0]["ccrechppass"] = ""; //信用审核口令，string类型
            domHead[0]["clowpricepass"] = ""; //最低售价口令，string类型
            domHead[0]["bcredit"] = ""; //是否为立账单据，int类型
            domHead[0]["ccreditcuscode"] = ""; //信用单位编码，string类型
            domHead[0]["ccreditcusname"] = ""; //信用单位名称，string类型
            domHead[0]["cgatheringplan"] = ""; //收付款协议编码，string类型
            domHead[0]["cgatheringplanname"] = ""; //收付款协议名称，string类型
            domHead[0]["dcreditstart"] = ""; //立账日，DateTime类型
            domHead[0]["dgatheringdate"] = ""; //到期日，DateTime类型
            domHead[0]["icreditdays"] = ""; //账期，int类型
            domHead[0]["bcontinue"] = ""; //是否继续，string类型

            //给BO表体参数domBody赋值，此BO参数的业务类型为发货单，属表体参数。BO参数均按引用传递
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
                domBody[0]["idlsid"] = ""; //主关键字段，0类型
                domBody[0]["cinvname"] = ""; //存货名称，string类型
                domBody[0]["cinvcode"] = item.cInvCode; //存货编码，string类型
                domBody[0]["iquantity"] = item.iQuantity; //数量，double类型
                domBody[0]["editprop"] = ""; //编辑属性：A表新增，M表修改，D表删除，string类型
                domBody[0]["fstockquano"] = ""; //现存件数，string类型
                domBody[0]["fcanusequano"] = ""; //可用件数，string类型
                domBody[0]["bneedsign"] = ""; //需要签回，string类型
                domBody[0]["bsignover"] = ""; //发货签回完成，string类型
                domBody[0]["bneedloss"] = ""; //需要损失处理，string类型
                domBody[0]["flossrate"] = ""; //发货合理损耗率，string类型
                domBody[0]["frlossqty"] = ""; //合理损耗数量，string类型
                domBody[0]["fulossqty"] = ""; //非合理损耗数量，string类型
                domBody[0]["isettletype"] = ""; //责任承担处理，string类型
                domBody[0]["crelacuscode"] = ""; //责任客户编码，string类型
                domBody[0]["crelacusname"] = ""; //责任客户名称，string类型
                domBody[0]["creasoncode"] = ""; //退货原因编码，string类型
                domBody[0]["creasonname"] = ""; //退货原因，string类型
                domBody[0]["iinvsncount"] = ""; //序列号个数，string类型
                domBody[0]["bserial"] = ""; //序列号管理，string类型
                domBody[0]["cmemo"] = ""; //备注，string类型
                domBody[0]["binvmodel"] = ""; //是否模型件，string类型
                domBody[0]["btracksalebill"] = ""; //PE跟单，string类型
                domBody[0]["cinvouchtype"] = ""; //cinvouchtype，string类型
                domBody[0]["dkeepdate"] = ""; //记账日期，string类型
                domBody[0]["cscloser"] = ""; //行关闭人，string类型
                domBody[0]["fcanusequan"] = ""; //可用量，string类型
                domBody[0]["fstockquan"] = ""; //现存量，string类型
                domBody[0]["bsaleprice"] = ""; //报价含税，string类型
                domBody[0]["bgift"] = ""; //赠品，string类型
                domBody[0]["autoid2"] = ""; //序列号行号，string类型
                domBody[0]["cvencode"] = ""; //入库单供应商编码，string类型
                domBody[0]["irowno"] =item.irowno; //行号，string类型
                domBody[0]["snlist"] = ""; //序列号，string类型
                domBody[0]["bmpforderclosed"] = ""; //是否订单关闭，string类型
                domBody[0]["cbsysbarcode"] = ""; //单据行条码，string类型
                domBody[0]["fxjquantity"] = ""; //已拣货量，string类型
                domBody[0]["fxjnum"] = ""; //已拣货件数，string类型
                domBody[0]["bptomodel"] = ""; //bptomodel，string类型
                domBody[0]["cparentcode"] = ""; //父节点编码，string类型
                domBody[0]["cchildcode"] = ""; //子节点编码，string类型
                domBody[0]["icalctype"] = ""; //发货模式，string类型
                domBody[0]["fchildqty"] = ""; //使用数量，string类型
                domBody[0]["fchildrate"] = ""; //权重比例，string类型
                domBody[0]["crtnappcode"] = ""; //退货申请单号，string类型
                domBody[0]["irtnappid"] = ""; //退货申请单id，string类型
                domBody[0]["taskguid"] = ""; //退货申请单id，string类型
                domBody[0]["fappretwkpqty"] = ""; //未开票退货申请数量，string类型
                domBody[0]["fappretwkpsum"] = ""; //未开票退货申请金额，string类型
                domBody[0]["fappretykpqty"] = ""; //已开票退货申请数量，string类型
                domBody[0]["fappretykpsum"] = ""; //已开票退货申请金额，string类型
                domBody[0]["itaxunitprice"] = item.iTaxUnitPrice; //含税单价，double类型
                domBody[0]["itaxrate"] = item.iTaxRate; //税率（％），double类型
                domBody[0]["iunitprice"] = item.iUnitPrice; //无税单价，double类型
                domBody[0]["imoney"] = item.iMoney; //无税金额，double类型
                domBody[0]["itax"] = item.iTax; //税额，double类型
                domBody[0]["inatunitprice"] = item.iNatUnitPrice; //本币单价，double类型
                domBody[0]["inatmoney"] = item.iNatMoney; //本币金额，double类型
                domBody[0]["inattax"] = item.iNatTax; //本币税额，double类型
                domBody[0]["cwhcode"] = item.cWhCode; //仓库编码，string类型

                /***************************** 以下是非必输字段 ****************************/
                domBody[0]["cwhname"] = ""; //仓库名称，string类型
                domBody[0]["autoid"] = ""; //自动编号，string类型
                domBody[0]["ccontractid"] = ""; //合同编码，string类型
                domBody[0]["ccontractrowguid"] = ""; //合同标的RowGuid，string类型
                domBody[0]["ccontracttagcode"] = ""; //合同标的编码，string类型
                domBody[0]["csettleall"] = ""; //关闭标志，int类型
                domBody[0]["cinvstd"] = ""; //规格型号，string类型
                domBody[0]["ippartqty"] = ""; //母件数量，string类型
                domBody[0]["ippartid"] = ""; //母件物料ID，string类型
                domBody[0]["batomodel"] = ""; //是否ATO件，int类型
                domBody[0]["ippartseqid"] = ""; //选配序号，string类型
                domBody[0]["cmassunit"] = ""; //保质期单位，int类型
                domBody[0]["inum"] = ""; //件数，double类型
                domBody[0]["isettlenum"] = ""; //开票金额，double类型
                domBody[0]["isettlequantity"] = ""; //开票数量，double类型
                domBody[0]["iquotedprice"] = ""; //报价，double类型
                domBody[0]["isum"] = ""; //价税合计，double类型
                domBody[0]["cfree1"] = ""; //自由项1，string类型
                domBody[0]["cfree2"] = ""; //自由项2，string类型
                domBody[0]["idiscount"] = ""; //折扣额，double类型
                domBody[0]["dlid"] = ""; //发货单 38，int类型
                domBody[0]["icorid"] = ""; //原发货单ID，int类型
                domBody[0]["inatsum"] = ""; //本币价税合计，double类型
                domBody[0]["inatdiscount"] = ""; //本币折扣额，double类型
                domBody[0]["iinvlscost"] = ""; //最低售价，double类型
                domBody[0]["ibatch"] = ""; //批次，string类型
                domBody[0]["bfree1"] = ""; //是否有自由项1，string类型
                domBody[0]["bfree2"] = ""; //是否有自由项2，string类型
                domBody[0]["bfree3"] = ""; //是否有自由项3，string类型
                domBody[0]["bfree4"] = ""; //是否有自由项4，string类型
                domBody[0]["bfree5"] = ""; //是否有自由项5，string类型
                domBody[0]["bfree6"] = ""; //是否有自由项6，string类型
                domBody[0]["bfree7"] = ""; //是否有自由项7，string类型
                domBody[0]["bfree8"] = ""; //是否有自由项8，string类型
                domBody[0]["bfree9"] = ""; //是否有自由项9，string类型
                domBody[0]["bfree10"] = ""; //是否有自由项10，string类型
                domBody[0]["cbatch"] = ""; //批号，string类型
                domBody[0]["cinvdefine1"] = ""; //存货自定义项1，string类型
                domBody[0]["cexpirationdate"] = ""; //有效期至，string类型
                domBody[0]["iexpiratdatecalcu"] = ""; //有效期推算方式，int类型
                domBody[0]["dexpirationdate"] = ""; //有效期计算项，string类型
                domBody[0]["bsalepricefree1"] = ""; //是否自由项定价1，string类型
                domBody[0]["bsalepricefree2"] = ""; //是否自由项定价2，string类型
                domBody[0]["bsalepricefree3"] = ""; //是否自由项定价3，string类型
                domBody[0]["bsalepricefree4"] = ""; //是否自由项定价4，string类型
                domBody[0]["bsalepricefree5"] = ""; //是否自由项定价5，string类型
                domBody[0]["bsalepricefree6"] = ""; //是否自由项定价6，string类型
                domBody[0]["bsalepricefree7"] = ""; //是否自由项定价7，string类型
                domBody[0]["bsalepricefree8"] = ""; //是否自由项定价8，string类型
                domBody[0]["bsalepricefree9"] = ""; //是否自由项定价9，string类型
                domBody[0]["bsalepricefree10"] = ""; //是否自由项定价10，string类型
                domBody[0]["idemandtype"] = ""; //需求跟踪方式，int类型
                domBody[0]["cdemandcode"] = ""; //需求跟踪号，string类型
                domBody[0]["cdemandmemo"] = ""; //需求分类说明，string类型
                domBody[0]["cdemandid"] = ""; //需求跟踪id，string类型
                domBody[0]["idemandseq"] = ""; //需求跟踪行号，string类型
                domBody[0]["cbatchproperty1"] = ""; //批次属性1，double类型
                domBody[0]["cbatchproperty2"] = ""; //批次属性2，double类型
                domBody[0]["cbatchproperty3"] = ""; //批次属性3，double类型
                domBody[0]["cbatchproperty4"] = ""; //批次属性4，double类型
                domBody[0]["cbatchproperty5"] = ""; //批次属性5，double类型
                domBody[0]["cbatchproperty6"] = ""; //批次属性6，string类型
                domBody[0]["cbatchproperty7"] = ""; //批次属性7，string类型
                domBody[0]["cbatchproperty8"] = ""; //批次属性8，string类型
                domBody[0]["cbatchproperty9"] = ""; //批次属性9，string类型
                domBody[0]["cbatchproperty10"] = ""; //批次属性10，DateTime类型
                domBody[0]["bbatchproperty1"] = ""; //是否启用批次属性1，string类型
                domBody[0]["bbatchproperty2"] = ""; //是否启用批次属性2，string类型
                domBody[0]["bbatchproperty3"] = ""; //是否启用批次属性3，string类型
                domBody[0]["bbatchproperty4"] = ""; //是否启用批次属性4，string类型
                domBody[0]["bbatchproperty5"] = ""; //是否启用批次属性5，string类型
                domBody[0]["bbatchproperty6"] = ""; //是否启用批次属性6，string类型
                domBody[0]["bbatchproperty7"] = ""; //是否启用批次属性7，string类型
                domBody[0]["bbatchproperty8"] = ""; //是否启用批次属性8，string类型
                domBody[0]["bbatchproperty9"] = ""; //是否启用批次属性9，string类型
                domBody[0]["bbatchproperty10"] = ""; //是否启用批次属性10，string类型
                domBody[0]["bbatchcreate"] = ""; //批次属性是否建档，string类型
                domBody[0]["cinvdefine4"] = ""; //存货自定义项4，string类型
                domBody[0]["cinvdefine5"] = ""; //存货自定义项5，string类型
                domBody[0]["cinvdefine6"] = ""; //存货自定义项6，string类型
                domBody[0]["cinvdefine7"] = ""; //存货自定义项7，string类型
                domBody[0]["cinvdefine8"] = ""; //存货自定义项8，string类型
                domBody[0]["cinvdefine9"] = ""; //存货自定义项9，string类型
                domBody[0]["cinvdefine10"] = ""; //存货自定义项10，string类型
                domBody[0]["cinvdefine11"] = ""; //存货自定义项11，string类型
                domBody[0]["cinvdefine12"] = ""; //存货自定义项12，string类型
                domBody[0]["cinvdefine13"] = ""; //存货自定义项13，string类型
                domBody[0]["cinvdefine14"] = ""; //存货自定义项14，string类型
                domBody[0]["cinvdefine15"] = ""; //存货自定义项15，string类型
                domBody[0]["cinvdefine16"] = ""; //存货自定义项16，string类型
                domBody[0]["cinvdefine2"] = ""; //存货自定义项2，string类型
                domBody[0]["cinvdefine3"] = ""; //存货自定义项3，string类型
                domBody[0]["binvtype"] = ""; //存货类型，string类型
                domBody[0]["itb"] = ""; //退补标志，int类型
                domBody[0]["dvdate"] = ""; //失效日期，DateTime类型
                domBody[0]["cdefine22"] = ""; //表体自定义项1，string类型
                domBody[0]["cdefine23"] = ""; //表体自定义项2，string类型
                domBody[0]["cdefine24"] = ""; //表体自定义项3，string类型
                domBody[0]["cdefine25"] = ""; //表体自定义项4，string类型
                domBody[0]["cdefine26"] = ""; //表体自定义项5，double类型
                domBody[0]["cdefine27"] = ""; //表体自定义项6，double类型
                domBody[0]["kl2"] = ""; //扣率2（％），double类型
                domBody[0]["isosid"] = ""; //对应订单子表ID，int类型
                domBody[0]["citemcode"] = ""; //项目编码，string类型
                domBody[0]["citem_class"] = ""; //项目大类编码，string类型
                domBody[0]["csocode"] = ""; //订单号，string类型
                domBody[0]["iinvweight"] = ""; //单位重量，double类型
                domBody[0]["dkl1"] = ""; //倒扣1（％），double类型
                domBody[0]["dkl2"] = ""; //倒扣2（％），double类型
                domBody[0]["cvenabbname"] = ""; //产地，string类型
                domBody[0]["fsalecost"] = ""; //零售单价，double类型
                domBody[0]["fsaleprice"] = ""; //零售金额，double类型
                domBody[0]["citemname"] = ""; //项目名称，string类型
                domBody[0]["citem_cname"] = ""; //项目大类名称，string类型
                domBody[0]["cfree3"] = ""; //自由项3，string类型
                domBody[0]["cfree4"] = ""; //自由项4，string类型
                domBody[0]["cfree5"] = ""; //自由项5，string类型
                domBody[0]["cfree6"] = ""; //自由项6，string类型
                domBody[0]["cfree7"] = ""; //自由项7，string类型
                domBody[0]["cfree8"] = ""; //自由项8，string类型
                domBody[0]["cfree9"] = ""; //自由项9，string类型
                domBody[0]["cfree10"] = ""; //自由项10，string类型
                domBody[0]["corufts"] = ""; //对应单据时间戳，string类型
                domBody[0]["inufts"] = ""; //入库单时间戳，string类型
                domBody[0]["iretquantity"] = ""; //退货数量，double类型
                domBody[0]["iinvexchrate"] = ""; //换算率，double类型
                domBody[0]["cunitid"] = ""; //销售单位编码，string类型
                domBody[0]["cinva_unit"] = ""; //销售单位，string类型
                domBody[0]["cinvm_unit"] = ""; //主计量单位，string类型
                domBody[0]["cgroupcode"] = ""; //计量单位组，string类型
                domBody[0]["igrouptype"] = ""; //单位类型，uint类型
                domBody[0]["cdefine28"] = ""; //表体自定义项7，string类型
                domBody[0]["cdefine29"] = ""; //表体自定义项8，string类型
                domBody[0]["cdefine30"] = ""; //表体自定义项9，string类型
                domBody[0]["cdefine31"] = ""; //表体自定义项10，string类型
                domBody[0]["cdefine32"] = ""; //表体自定义项11，string类型
                domBody[0]["cdefine33"] = ""; //表体自定义项12，string类型
                domBody[0]["fsumsignquantity"] = ""; //累计签回数量，double类型
                domBody[0]["cvmivencode"] = ""; //供货商编码，string类型
                domBody[0]["cvmivenname"] = ""; //供货商名称，string类型
                domBody[0]["cordercode"] = ""; //订单号，string类型
                domBody[0]["iorderrowno"] = ""; //订单行号，string类型
                domBody[0]["fcusminprice"] = ""; //客户最低售价，double类型
                domBody[0]["imoneysum"] = ""; //累计本币收款金额，double类型
                domBody[0]["iexchsum"] = ""; //累计原币收款金额，double类型
                domBody[0]["cdefine34"] = ""; //表体自定义项13，int类型
                domBody[0]["fsumsignnum"] = ""; //累计签回件数，double类型
                domBody[0]["cdefine35"] = ""; //表体自定义项14，int类型
                domBody[0]["cdefine36"] = ""; //表体自定义项15，DateTime类型
                domBody[0]["funsignquantity"] = ""; //可签收数量，double类型
                domBody[0]["funsignnum"] = ""; //可签收件数，double类型
                domBody[0]["cdefine37"] = ""; //表体自定义项16，DateTime类型
                domBody[0]["dmdate"] = ""; //生产日期，DateTime类型
                domBody[0]["bgsp"] = ""; //是否gsp检验，int类型
                domBody[0]["imassdate"] = ""; //保质期，int类型
                domBody[0]["binvquality"] = ""; //是否保质期管理，int类型
                domBody[0]["ccode"] = ""; //入库单号，string类型
                domBody[0]["btrack"] = ""; //是否追踪，int类型
                domBody[0]["bproxywh"] = ""; //是否代管仓，int类型
                domBody[0]["bisstqc"] = ""; //库存期初，int类型
                domBody[0]["csrpolicy"] = ""; //供需政策，string类型
                domBody[0]["cinvaddcode"] = ""; //存货代码，string类型
                domBody[0]["iqanum"] = ""; //检验合格件数，double类型
                domBody[0]["iqaquantity"] = ""; //检验合格数量，double类型
                domBody[0]["ccusinvcode"] = ""; //客户存货编码，string类型
                domBody[0]["ccusinvname"] = ""; //客户存货名称，string类型
                domBody[0]["bqachecking"] = ""; //是否在检，int类型
                domBody[0]["bqaneedcheck"] = ""; //是否质量检验，int类型
                domBody[0]["bqachecked"] = ""; //是否报检，int类型
                domBody[0]["bqaurgency"] = ""; //是否急料，int类型
                domBody[0]["cbaccounter"] = ""; //记账人，string类型
                domBody[0]["binvbatch"] = ""; //是否批次管理，string类型
                domBody[0]["bsettleall"] = ""; //结算标志，string类型
                domBody[0]["bservice"] = ""; //是否应税劳务，string类型
                domBody[0]["kl"] = ""; //扣率（％），double类型
            }

            //给普通参数VoucherState赋值。此参数的数据类型为int，此参数按值传递，表示状态:0增加;1修改
            broker.AssignNormalValue("VoucherState", 0);


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
            //获取普通返回值。此返回值数据类型为System.String，此参数按值传递，表示成功返回空串
            resultmsg = broker.GetReturnValue() as System.String;

            //获取out/inout参数值

            //获取普通INOUT参数vNewID。此返回值数据类型为string，在使用该参数之前，请判断是否为空
            string vNewIDRet = broker.GetResult("vNewID") as string;

            //结束本次调用，释放API资源
            broker.Release();
            return false;

        }
    }
}
