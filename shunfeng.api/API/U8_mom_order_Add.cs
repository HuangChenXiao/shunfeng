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

namespace shunfeng.api.API
{
    public class U8_mom_order_Add
    {
        public bool U8_mom_order(mom_order main, List<mom_orderdetail> detailList,List<mom_moallocate> mocateList, out string resultmsg)
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
            //当前API：新增生产订单的地址标识为：U8API/MOrder/MOrderAdd
            U8ApiAddress myApiAddress = new U8ApiAddress("U8API/MOrder/MOrderAdd");

            //第四步：构造APIBroker
            U8ApiBroker broker = new U8ApiBroker(myApiAddress, envContext);

            //第五步：API参数赋值

            //给扩展BO参数extbo赋值，此扩展BO参数的业务类型为生产订单表头。扩展BO参数均按引用传递
            //提示：给扩展BO参数extbo赋值有两种方法

            //方法一：直接传入xml字符串，具体方法如下：
            //string extboXml = new string();
            //broker.AssignNormalValue("extbo", extboXml)

            //方法二：构造扩展BO实体对象，具体方法如下：
            //首先，获取扩展BO实体（通过扩展BO参数名）
            ExtensionBusinessEntity extbo = broker.GetExtBoEntity("extbo");
            //设置扩展BO实体的初始容量（可以自由设置扩展BO实体项目数为大于零的整数，也可以"不设置"而自动增加）
            //extbo.ItemCount = 10; //该步骤可省略
            //然后，使扩展BO实体增加一个新的数据项
            //ExtensionItem newItem = extbo.NewItem();
            //其次，设置新增项的各个字段值
            //1).主表或直接字段赋值：
            //newItem["字段名"] = new object();
            //newItem["字段名"] = "字段值";
            //2).子表字段赋值：
            //先获取子扩展BO实体（通过子表名）
            //ExtensionBusinessEntity subEntity1 = newItem.SubEntity["子表名"];
            //ExtensionBusinessEntity subEntity2 = extbo[0].SubEntity["子表名"];
            //……（获取其他子实体）
            //然后设置子扩展BO实体的直接字段值（与上同）
            //subEntity1[0].["字段名"] = new object();
            //subEntity2[0].["字段名"] = "字段值";
            //以此类推，构造整个扩展BO实体（一棵"树"结构）
            //注：给扩展BO对象的各字段赋值，值可以是真实类型，也可以是无类型字符串

            //以下代码示例只设置新增扩展BO实体第一项的值。扩展BO对象的各字段定义详见API服务接口定义

            #region 主表

            /****************************** 必输字段 ******************************/
            extbo[0]["MoId"] = ""; //主键，int类型
            extbo[0]["MoCode"] = main.MoCode; //生产订单号(必须)，string类型

            /***************************** 非必输字段 *****************************/
            extbo[0]["CreateUser"] = main.CreateUser; //制单人(导出用)，string类型
            extbo[0]["CreateDate"] = main.CreateDate; //制单日期(导出用)，DateTime类型
            extbo[0]["CreateTime"] = ""; //制单时间(导出用)，DateTime类型
            extbo[0]["ModifyUser"] = ""; //修改人(导出用)，string类型
            extbo[0]["ModifyDate"] = ""; //修改日期(导出用)，DateTime类型
            extbo[0]["ModifyTime"] = ""; //修改时间(导出用)，DateTime类型
            extbo[0]["Define_1"] = ""; //表头自定义项1，string类型
            extbo[0]["Define_2"] = ""; //表头自定义项2，string类型
            extbo[0]["Define_3"] = ""; //表头自定义项3，string类型
            extbo[0]["Define_4"] = ""; //表头自定义项4，DateTime类型
            extbo[0]["Define_5"] = ""; //表头自定义项5，int类型
            extbo[0]["Define_6"] = ""; //表头自定义项6，DateTime类型
            extbo[0]["Define_7"] = ""; //表头自定义项7，double类型
            extbo[0]["Define_8"] = ""; //表头自定义项8，string类型
            extbo[0]["Define_9"] = ""; //表头自定义项9，string类型
            extbo[0]["Define_10"] = ""; //表头自定义项10，string类型
            extbo[0]["Define_11"] = ""; //表头自定义项11，string类型
            extbo[0]["Define_12"] = ""; //表头自定义项12，string类型
            extbo[0]["Define_13"] = ""; //表头自定义项13，string类型
            extbo[0]["Define_14"] = ""; //表头自定义项14，string类型
            extbo[0]["Define_15"] = ""; //表头自定义项15，int类型
            extbo[0]["Define_16"] = ""; //表头自定义项16，double类型

            #endregion 主表

            #region 子表[Mom_OrderDetail]

            ExtensionBusinessEntity Mom_OrderDetail = extbo[0].SubEntity["Mom_OrderDetail"];

            #region 主表

            /****************************** 必输字段 ******************************/
            Mom_OrderDetail[0]["DMoClass"] = ""; //类型(1标准/2非标准/3重复计划)，int类型
            Mom_OrderDetail[0]["DInvCode"] = ""; //物料编码(必须)，string类型
            Mom_OrderDetail[0]["DStartDate"] = ""; //开工日期(必须)，DateTime类型
            Mom_OrderDetail[0]["DDueDate"] = ""; //完工日期(必须)，DateTime类型
            Mom_OrderDetail[0]["DQty"] = ""; //生产数量(必须)，double类型
            Mom_OrderDetail[0]["DSortSeq"] = ""; //行号(必须)，int类型

            /***************************** 非必输字段 *****************************/
            Mom_OrderDetail[0]["DInvAddCode"] = ""; //物料代号(导出用)，string类型
            Mom_OrderDetail[0]["DInvName"] = ""; //物料名称(导出用)，string类型
            Mom_OrderDetail[0]["DInvStd"] = ""; //物料规格(导出用)，string类型
            Mom_OrderDetail[0]["DInvFree_1"] = ""; //物料自由项1，string类型
            Mom_OrderDetail[0]["DInvFree_2"] = ""; //物料自由项2，string类型
            Mom_OrderDetail[0]["DInvFree_3"] = ""; //物料自由项3，string类型
            Mom_OrderDetail[0]["DInvFree_4"] = ""; //物料自由项4，string类型
            Mom_OrderDetail[0]["DInvFree_5"] = ""; //物料自由项5，string类型
            Mom_OrderDetail[0]["DInvFree_6"] = ""; //物料自由项6，string类型
            Mom_OrderDetail[0]["DInvFree_7"] = ""; //物料自由项7，string类型
            Mom_OrderDetail[0]["DInvFree_8"] = ""; //物料自由项8，string类型
            Mom_OrderDetail[0]["DInvFree_9"] = ""; //物料自由项9，string类型
            Mom_OrderDetail[0]["DInvFree_10"] = ""; //物料自由项10，string类型
            Mom_OrderDetail[0]["DInvDefine_1"] = ""; //物料自定义项1，string类型
            Mom_OrderDetail[0]["DInvDefine_2"] = ""; //物料自定义项2，string类型
            Mom_OrderDetail[0]["DInvDefine_3"] = ""; //物料自定义项3，string类型
            Mom_OrderDetail[0]["DInvDefine_4"] = ""; //物料自定义项4，string类型
            Mom_OrderDetail[0]["DInvDefine_5"] = ""; //物料自定义项5，string类型
            Mom_OrderDetail[0]["DInvDefine_6"] = ""; //物料自定义项6，string类型
            Mom_OrderDetail[0]["DInvDefine_7"] = ""; //物料自定义项7，string类型
            Mom_OrderDetail[0]["DInvDefine_8"] = ""; //物料自定义项8，string类型
            Mom_OrderDetail[0]["DInvDefine_9"] = ""; //物料自定义项9，string类型
            Mom_OrderDetail[0]["DInvDefine_10"] = ""; //物料自定义项10，string类型
            Mom_OrderDetail[0]["DInvDefine_11"] = ""; //物料自定义项11，int类型
            Mom_OrderDetail[0]["DInvDefine_12"] = ""; //物料自定义项12，int类型
            Mom_OrderDetail[0]["DInvDefine_13"] = ""; //物料自定义项13，double类型
            Mom_OrderDetail[0]["DInvDefine_14"] = ""; //物料自定义项14，double类型
            Mom_OrderDetail[0]["DInvDefine_15"] = ""; //物料自定义项15，DateTime类型
            Mom_OrderDetail[0]["DInvDefine_16"] = ""; //物料自定义项16，DateTime类型
            Mom_OrderDetail[0]["DMoTypeCode"] = ""; //订单类别，string类型
            Mom_OrderDetail[0]["DMoTypeDesc"] = ""; //类别说明(导出用)，string类型
            Mom_OrderDetail[0]["DStatus"] = ""; //状态，int类型
            Mom_OrderDetail[0]["DLeadTime"] = ""; //提前期，int类型
            Mom_OrderDetail[0]["DInvUnitName"] = ""; //计量单位名称(导出用)，string类型
            Mom_OrderDetail[0]["DMrpQty"] = ""; //MRP净算量，double类型
            Mom_OrderDetail[0]["DChangeRate"] = ""; //换算率，double类型
            Mom_OrderDetail[0]["DAuxUnitCode"] = ""; //辅助单位，string类型
            Mom_OrderDetail[0]["DAuxUnitName"] = ""; //辅助单位名称(导出用)，string类型
            Mom_OrderDetail[0]["DAuxQty"] = ""; //辅助生产量(导出用)，double类型
            Mom_OrderDetail[0]["DMoLotCode"] = ""; //生产批号，string类型
            Mom_OrderDetail[0]["DWhCode"] = ""; //预入仓库，string类型
            Mom_OrderDetail[0]["DWhName"] = ""; //仓库名称(导出用)，string类型
            Mom_OrderDetail[0]["DMDeptCode"] = ""; //生产部门，string类型
            Mom_OrderDetail[0]["DDeptName"] = ""; //部门名称(导出用)，string类型
            Mom_OrderDetail[0]["DBomType"] = ""; //BOM选择(导出用)，int类型
            Mom_OrderDetail[0]["DBomVersion"] = ""; //BOM版本号(导出用)，int类型
            Mom_OrderDetail[0]["DBomVersionDesc"] = ""; //BOM版本说明(导出用)，string类型
            Mom_OrderDetail[0]["DBomVersionDate"] = ""; //BOM版本日期(导出用)，DateTime类型
            Mom_OrderDetail[0]["DBomIdentCode"] = ""; //BOM替代标识(导出用)，string类型
            Mom_OrderDetail[0]["DBomIdentDesc"] = ""; //BOM替代说明(导出用)，string类型
            Mom_OrderDetail[0]["DRoutingType"] = ""; //工艺路线选择，int类型
            Mom_OrderDetail[0]["DRoutingVersion"] = ""; //工艺路线版本号，int类型
            Mom_OrderDetail[0]["DRoutingVersionDesc"] = ""; //工艺路线版本说明(导出用)，string类型
            Mom_OrderDetail[0]["DRoutingVersionDate"] = ""; //工艺路线版本日期，DateTime类型
            Mom_OrderDetail[0]["DRoutingIdentCode"] = ""; //工艺路线替代标识，string类型
            Mom_OrderDetail[0]["DRoutingIdentDesc"] = ""; //工艺路线替代说明(导出用)，string类型
            Mom_OrderDetail[0]["DRemark"] = ""; //备注，string类型
            Mom_OrderDetail[0]["DDefine_22"] = ""; //表体自定义项1，string类型
            Mom_OrderDetail[0]["DDefine_23"] = ""; //表体自定义项2，string类型
            Mom_OrderDetail[0]["DDefine_24"] = ""; //表体自定义项3，string类型
            Mom_OrderDetail[0]["DDefine_25"] = ""; //表体自定义项4，string类型
            Mom_OrderDetail[0]["DDefine_26"] = ""; //表体自定义项5，double类型
            Mom_OrderDetail[0]["DDefine_27"] = ""; //表体自定义项6，double类型
            Mom_OrderDetail[0]["DDefine_28"] = ""; //表体自定义项7，string类型
            Mom_OrderDetail[0]["DDefine_29"] = ""; //表体自定义项8，string类型
            Mom_OrderDetail[0]["DDefine_30"] = ""; //表体自定义项9，string类型
            Mom_OrderDetail[0]["DDefine_31"] = ""; //表体自定义项10，string类型
            Mom_OrderDetail[0]["DDefine_32"] = ""; //表体自定义项11，string类型
            Mom_OrderDetail[0]["DDefine_33"] = ""; //表体自定义项12，string类型
            Mom_OrderDetail[0]["DDefine_34"] = ""; //表体自定义项13，int类型
            Mom_OrderDetail[0]["DDefine_35"] = ""; //表体自定义项14，int类型
            Mom_OrderDetail[0]["DDefine_36"] = ""; //表体自定义项15，DateTime类型
            Mom_OrderDetail[0]["DDefine_37"] = ""; //表体自定义项16，DateTime类型
            Mom_OrderDetail[0]["DPartId"] = ""; //母件物料ID(导出用)，string类型
            Mom_OrderDetail[0]["DRelsUser"] = ""; //审核人(导出用)，string类型
            Mom_OrderDetail[0]["DRelsDate"] = ""; //审核日期(导出用)，DateTime类型
            Mom_OrderDetail[0]["DBomId"] = ""; //物料清单ID(导出用)，int类型
            Mom_OrderDetail[0]["DQcFlag"] = ""; //质检，int类型
            Mom_OrderDetail[0]["DWIPType"] = ""; //供应类型，int类型
            Mom_OrderDetail[0]["DSupplyWhCode"] = ""; //供应仓库，string类型
            Mom_OrderDetail[0]["DSupplyWhName"] = ""; //供应仓库名称(导出用)，string类型
            Mom_OrderDetail[0]["DOpScheduleType"] = ""; //排程类型，int类型
            Mom_OrderDetail[0]["DReasonCode"] = ""; //原因码，string类型
            Mom_OrderDetail[0]["DReasonDesc"] = ""; //原因说明(导出用)，string类型
            Mom_OrderDetail[0]["DBasEngineerFigNo"] = ""; //工程图号(导出用)，string类型
            Mom_OrderDetail[0]["DRelsTime"] = ""; //审核时间(导出用)，DateTime类型
            Mom_OrderDetail[0]["DCloseUser"] = ""; //关闭人(导出用)，string类型
            Mom_OrderDetail[0]["DCloseDate"] = ""; //关闭日期(导出用)，DateTime类型
            Mom_OrderDetail[0]["DCloseTime"] = ""; //关闭时间(导出用)，DateTime类型
            Mom_OrderDetail[0]["DOrderType"] = ""; //销售订单类别，int类型
            Mom_OrderDetail[0]["DOrderCode"] = ""; //销售订单，string类型
            Mom_OrderDetail[0]["DOrderSeq"] = ""; //销售订单行号，int类型
            Mom_OrderDetail[0]["DMoDId"] = ""; //订单明细ID，int类型
            Mom_OrderDetail[0]["DMoTypeId"] = ""; //生产订单类别ID，int类型
            Mom_OrderDetail[0]["DInvUnit"] = ""; //计量单位编码(导出用)，string类型
            Mom_OrderDetail[0]["DInvGroupType"] = ""; //计量单位组类型(导出用)，int类型
            Mom_OrderDetail[0]["DInvGroupCode"] = ""; //计量单位组编码(导出用)，string类型
            Mom_OrderDetail[0]["DInvGroupName"] = ""; //计量单位组名称(导出用)，string类型
            Mom_OrderDetail[0]["DRoutingId"] = ""; //工艺路线ID(导出用)，int类型
            Mom_OrderDetail[0]["DRunCardFlag"] = ""; //是否启用流转卡，int类型

            #endregion 主表

            #region 子表[Mom_MoAllocate]

            ExtensionBusinessEntity Mom_MoAllocate = Mom_OrderDetail[0].SubEntity["Mom_MoAllocate"];


            /****************************** 必输字段 ******************************/
            Mom_MoAllocate[0]["DSortSeq"] = ""; //子件行号(必须)，int类型
            Mom_MoAllocate[0]["DOpSeq"] = ""; //工序行号，string类型
            Mom_MoAllocate[0]["DInvCode"] = ""; //子件编码(必须)，string类型
            Mom_MoAllocate[0]["DBaseQtyN"] = ""; //基本用量，double类型
            Mom_MoAllocate[0]["DBaseQtyD"] = ""; //基础数量，double类型
            Mom_MoAllocate[0]["DStartDemDate"] = ""; //需求日期，DateTime类型

            /***************************** 非必输字段 *****************************/
            Mom_MoAllocate[0]["DOpDesc"] = ""; //工序说明(导出用)，string类型
            Mom_MoAllocate[0]["DInvName"] = ""; //子件名称(导出用)，string类型
            Mom_MoAllocate[0]["DInvStd"] = ""; //子件规格(导出用)，string类型
            Mom_MoAllocate[0]["DInvAddCode"] = ""; //子件代号(导出用)，string类型
            Mom_MoAllocate[0]["DInvFree_1"] = ""; //子件自由项1，string类型
            Mom_MoAllocate[0]["DInvFree_2"] = ""; //子件自由项2，string类型
            Mom_MoAllocate[0]["DInvFree_3"] = ""; //子件自由项3，string类型
            Mom_MoAllocate[0]["DInvFree_4"] = ""; //子件自由项4，string类型
            Mom_MoAllocate[0]["DInvFree_5"] = ""; //子件自由项5，string类型
            Mom_MoAllocate[0]["DInvFree_6"] = ""; //子件自由项6，string类型
            Mom_MoAllocate[0]["DInvFree_7"] = ""; //子件自由项7，string类型
            Mom_MoAllocate[0]["DInvFree_8"] = ""; //子件自由项8，string类型
            Mom_MoAllocate[0]["DInvFree_9"] = ""; //子件自由项9，string类型
            Mom_MoAllocate[0]["DInvFree_10"] = ""; //子件自由项10，string类型
            Mom_MoAllocate[0]["DInvDefine_1"] = ""; //子件自定义项1，string类型
            Mom_MoAllocate[0]["DInvDefine_2"] = ""; //子件自定义项2，string类型
            Mom_MoAllocate[0]["DInvDefine_3"] = ""; //子件自定义项3，string类型
            Mom_MoAllocate[0]["DInvDefine_4"] = ""; //子件自定义项4，string类型
            Mom_MoAllocate[0]["DInvDefine_5"] = ""; //子件自定义项5，string类型
            Mom_MoAllocate[0]["DInvDefine_6"] = ""; //子件自定义项6，string类型
            Mom_MoAllocate[0]["DInvDefine_7"] = ""; //子件自定义项7，string类型
            Mom_MoAllocate[0]["DInvDefine_8"] = ""; //子件自定义项8，string类型
            Mom_MoAllocate[0]["DInvDefine_9"] = ""; //子件自定义项9，string类型
            Mom_MoAllocate[0]["DInvDefine_10"] = ""; //子件自定义项10，string类型
            Mom_MoAllocate[0]["DInvDefine_11"] = ""; //子件自定义项11，int类型
            Mom_MoAllocate[0]["DInvDefine_12"] = ""; //子件自定义项12，int类型
            Mom_MoAllocate[0]["DInvDefine_13"] = ""; //子件自定义项13，double类型
            Mom_MoAllocate[0]["DInvDefine_14"] = ""; //子件自定义项14，double类型
            Mom_MoAllocate[0]["DInvDefine_15"] = ""; //子件自定义项15，DateTime类型
            Mom_MoAllocate[0]["DInvDefine_16"] = ""; //子件自定义项16，DateTime类型
            Mom_MoAllocate[0]["DInvUnitName"] = ""; //主计量单位名称(导出用)，string类型
            Mom_MoAllocate[0]["DCompScrap"] = ""; //子件损耗率％，double类型
            Mom_MoAllocate[0]["DFVFlag"] = ""; //固定用量，int类型
            Mom_MoAllocate[0]["DBaseQty"] = ""; //使用数量，double类型
            Mom_MoAllocate[0]["DByproductFlag"] = ""; //产出品，int类型
            Mom_MoAllocate[0]["DWIPType"] = ""; //供应类型，int类型
            Mom_MoAllocate[0]["DWhCode"] = ""; //供应仓库，string类型
            Mom_MoAllocate[0]["DWhName"] = ""; //仓库名称(导出用)，string类型
            Mom_MoAllocate[0]["DLotNo"] = ""; //批号，string类型
            Mom_MoAllocate[0]["DQty"] = ""; //应领数量，double类型
            Mom_MoAllocate[0]["DIssQty"] = ""; //已领数量，double类型
            Mom_MoAllocate[0]["DAllocateSubFlag"] = ""; //替代标志(导出用)，string类型
            Mom_MoAllocate[0]["DSubDate"] = ""; //替换日期(导出用)，DateTime类型
            Mom_MoAllocate[0]["DIsLot"] = ""; //是否批量(导出用)，int类型
            Mom_MoAllocate[0]["DDefine_22"] = ""; //表体自定义项1，string类型
            Mom_MoAllocate[0]["DDefine_23"] = ""; //表体自定义项2，string类型
            Mom_MoAllocate[0]["DDefine_24"] = ""; //表体自定义项3，string类型
            Mom_MoAllocate[0]["DDefine_25"] = ""; //表体自定义项4，string类型
            Mom_MoAllocate[0]["DDefine_26"] = ""; //表体自定义项5，double类型
            Mom_MoAllocate[0]["DDefine_27"] = ""; //表体自定义项6，double类型
            Mom_MoAllocate[0]["DDefine_28"] = ""; //表体自定义项7，string类型
            Mom_MoAllocate[0]["DDefine_29"] = ""; //表体自定义项8，string类型
            Mom_MoAllocate[0]["DDefine_30"] = ""; //表体自定义项9，string类型
            Mom_MoAllocate[0]["DDefine_31"] = ""; //表体自定义项10，string类型
            Mom_MoAllocate[0]["DDefine_32"] = ""; //表体自定义项11，string类型
            Mom_MoAllocate[0]["DDefine_33"] = ""; //表体自定义项12，string类型
            Mom_MoAllocate[0]["DDefine_34"] = ""; //表体自定义项13，int类型
            Mom_MoAllocate[0]["DDefine_35"] = ""; //表体自定义项14，int类型
            Mom_MoAllocate[0]["DDefine_36"] = ""; //表体自定义项15，DateTime类型
            Mom_MoAllocate[0]["DDefine_37"] = ""; //表体自定义项16，DateTime类型
            Mom_MoAllocate[0]["DQcFlag"] = ""; //质检标识(导出用)，int类型
            Mom_MoAllocate[0]["DAuxUnitCode"] = ""; //辅助单位，string类型
            Mom_MoAllocate[0]["DAuxUnitName"] = ""; //辅助单位名称(导出用)，string类型
            Mom_MoAllocate[0]["DChangeRate"] = ""; //换算率，double类型
            Mom_MoAllocate[0]["DAuxBaseQtyN"] = ""; //辅助基本用量，double类型
            Mom_MoAllocate[0]["DAuxBaseQty"] = ""; //辅助使用量，double类型
            Mom_MoAllocate[0]["DAuxQty"] = ""; //应领辅助量，double类型
            Mom_MoAllocate[0]["DAuxIssQty"] = ""; //已领辅助量，double类型
            Mom_MoAllocate[0]["DATPFlag"] = ""; //检查ATP(导出用)，int类型
            Mom_MoAllocate[0]["DInfiniteSupplyDate"] = ""; //无限供应日(导出用)，DateTime类型
            Mom_MoAllocate[0]["DATPQty"] = ""; //ATP数量(导出用)，double类型
            Mom_MoAllocate[0]["DReplenishQty"] = ""; //补料量，double类型
            Mom_MoAllocate[0]["DGroupCode"] = ""; //计量单位组编码(导出用)，string类型
            Mom_MoAllocate[0]["DGroupType"] = ""; //级联单位组类型(导出用)，string类型
            Mom_MoAllocate[0]["DBasEngineerFigNo"] = ""; //工程图号(导出用)，string类型
            Mom_MoAllocate[0]["DRemark"] = ""; //备注，string类型
            Mom_MoAllocate[0]["DProductType"] = ""; //产出类型，int类型
            Mom_MoAllocate[0]["DSoType"] = ""; //需求跟踪方式，int类型
            Mom_MoAllocate[0]["DSoCode"] = ""; //需求跟踪号，string类型
            Mom_MoAllocate[0]["DSoSeq"] = ""; //需求跟踪行号，string类型
            Mom_MoAllocate[0]["DDemandCode"] = ""; //需求分类，string类型
            Mom_MoAllocate[0]["DDemandCodeDesc"] = ""; //需求分类说明(导出用)，string类型
            Mom_MoAllocate[0]["DTransQty"] = ""; //已调拨量，double类型
            Mom_MoAllocate[0]["DPolicy"] = ""; //DPolicy，string类型
            Mom_MoAllocate[0]["DQmFlag"] = ""; //DQmFlag，int类型
            Mom_MoAllocate[0]["DInvBatch_1"] = ""; //批次属性1，double类型
            Mom_MoAllocate[0]["DInvBatch_2"] = ""; //批次属性2，double类型
            Mom_MoAllocate[0]["DInvBatch_3"] = ""; //批次属性3，double类型
            Mom_MoAllocate[0]["DInvBatch_4"] = ""; //批次属性4，double类型
            Mom_MoAllocate[0]["DInvBatch_5"] = ""; //批次属性5，double类型
            Mom_MoAllocate[0]["DInvBatch_6"] = ""; //批次属性6，string类型
            Mom_MoAllocate[0]["DInvBatch_7"] = ""; //批次属性7，string类型
            Mom_MoAllocate[0]["DInvBatch_8"] = ""; //批次属性8，string类型
            Mom_MoAllocate[0]["DInvBatch_9"] = ""; //批次属性9，string类型
            Mom_MoAllocate[0]["DInvBatch_10"] = ""; //批次属性10，DateTime类型
            Mom_MoAllocate[0]["DDirectFlag"] = ""; //是否直接供应(导出用)，int类型
            Mom_MoAllocate[0]["DInvGroupType"] = ""; //计量单位组类型(导出用)，int类型
            Mom_MoAllocate[0]["DInvGroupCode"] = ""; //计量单位组编码(导出用)，string类型
            Mom_MoAllocate[0]["DInvGroupName"] = ""; //计量单位组名称(导出用)，string类型
            Mom_MoAllocate[0]["DPartId"] = ""; //子件物料ID(导出用)，string类型
            Mom_MoAllocate[0]["DInvUnit"] = ""; //主计量单位编码(导出用)，string类型

            #endregion 子表[Mom_MoAllocate]
            #endregion 子表[Mom_OrderDetail]

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
            //获取普通返回值。此返回值数据类型为System.Boolean，此参数按值传递，表示返回值: true:成功, false: 失败
            System.Boolean result = Convert.ToBoolean(broker.GetReturnValue());
            if (result)
            {
                resultmsg = "成功";   
            }
            else
            {
                resultmsg = "失败";
            }
            //结束本次调用，释放API资源
            broker.Release();
            return true;
        }
    }
}
