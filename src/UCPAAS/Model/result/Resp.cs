using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCPAAS.Model {
    public class Resp {
        public string respCode { get; set; }
        private static readonly List<string> StatesCode = new List<string> { "000000" };
        private static readonly List<string> SuccessCode = new List<string> { "000000" };
        private static readonly List<string> FailCode = new List<string> {
            "100000","100001","100002","100003","100004","100005","100006","100015",
            "100500","100007","100008","100009","100010","100011","100012","100013",
            "100014","100016","100017","100018", "100699","100019","100020","100104",
            "100105","100108",
            "101100","101101","101102","101103", "101104","101105","101106","101107",
            "101108","101109","101110","101111", "101112","101113","101114","101115",
            "101116","101117",
            "102100","102101","102102","102103","102104","102105","102106","102107",
            "102108","102109","102110","102111","102112","102113","102114",
            "103100","103101","103102","103103","103104","103105","103106","103107",
            "103108","103109","103110","103111","103112","103113","103114","103115",
            "103116","103117","103118","103119","103120","103121","103122","103123",
            "103124","103125","103126","103127","103128","103129","103130","103131",
            "104100","104101","104102","104103","104104","104105","104106","104107",
            "104108","104109","104110","104111","104112","104113","104114","104115",
            "104116","104117","104118","104119","104120","104121","104122","104123",
            "104124","104125","104126","104127","104128","104129","104130","104132",
            "104133",
            "105100","105101","105102","105103","105104","105105","105106","105107",
            "105108","105109","105110","105111","105112","105113","105114","105115",
            "105116","105117","105118","105119","105120","105121","105122","105123",
            "105124","105125","105126","105127","105128","105129","103123","103124",
            "103125","103126","103127","105130","105131","105132","105133","105134",
            "105135","105136","105137","105138","105139"
        };

        public bool IsSucceedCode {
            get { return SuccessCode.Contains(respCode); }
        }

        public bool IsFailed {
            get {
                return !string.IsNullOrEmpty(Desc) || (FailCode.Contains(respCode));
            }
        }

        public bool IsDataReceived {
            get { return StatesCode.Contains(respCode); }
        }

        /// <summary>
        /// Gets a value indicating whether the request is error.
        /// </summary>
        /// <value><c>true</c> if the request is error; otherwise, <c>false</c>.</value>
        public bool IsRequestError {
            get {
                return (!string.IsNullOrEmpty(Desc));
            }
        }

        public string Desc { get; set; }
        public string Message {
            get {
                if (!string.IsNullOrEmpty(Desc)) {
                    return Desc;
                }

                switch (respCode) {
                   case "100000": return "金额不为整数";
                   case "100001": return "余额不足";
                    case "100002": return "数字非法";
                    case "100003": return "不允许有空值";
                    case "100004": return "枚举类型取值错误";
                    case "100005": return "访问IP不合法";
                    case "100006": return "手机号不合法";
                    case "100015": return "号码不合法";
                    case "100500": return "HTTP状态码不等于200";
                    case "100007": return "查无数据";
                    case "100008": return "手机号码为空";
                    case "100009": return "手机号为受保护的号码";
                    case "100010": return "登录邮箱或手机号为空";
                    case "100011": return "邮箱不合法";
                    case "100012": return "密码不能为空";
                    case "100013": return "没有测试子账号";
                    case "100014": return "金额过大,不要超过12位数字";
                    case "100016": return "余额被冻结";
                    case "100017": return "余额已注销";
                    case "100018": return "通话时长需大于60秒";
                    case "100699": return "系统内部错误";
                    case "100019": return "应用餘額不足";
                    case "100020": return "字符长度太长";
                    case "100104": return "callId不能为空";
                    case "100105": return "日期格式错误";
                    case "100108": return "取消回拨失败";
                    case "101100": return "请求包头Authorization参数为空";
                    case "101101": return "请求包头Authorization参数Base64解码失败";
                    case "101102": return "请求包头Authorization参数解码后账户ID为空";
                    case "101103": return "请求包头Authorization参数解码后时间戳为空";
                    case "101104": return "请求包头Authorization参数解码后格式有误";
                    case "101105": return "主账户ID存在非法字符";
                    case "101106": return "请求包头Authorization参数解码后时间戳过期";
                    case "101107": return "请求地址SoftVersion参数有误";
                    case "101108": return "主账户已关闭";
                    case "101109": return "主账户未激活";
                    case "101110": return "主账户已锁定";
                    case "101111": return "主账户不存在";
                    case "101112": return "主账户ID为空";
                    case "101113": return "请求包头Authorization参数中账户ID跟请求地址中的账户ID不一致";
                    case "101114": return "请求地址Sig参数为空";
                    case "101115": return "请求token校验失败";
                    case "101116": return "主账号sig加密串不匹配";
                    case "101117": return "主账号token不存在";
                    case "102100": return "应用ID为空";
                    case "102101": return "应用ID存在非法字符";
                    case "102102": return "应用不存在";
                    case "102103": return "应用未审核通过";
                    case "102104": return "测试应用不允许创建client";
                    case "102105": return "应用不属于该主账号";
                    case "102106": return "应用类型错误";
                    case "102107": return "应用类型为空";
                    case "102108": return "应用名为空";
                    case "102109": return "行业类型为空";
                    case "102110": return "行业信息错误";
                    case "102111": return "是否允许拨打国际填写错误";
                    case "102112": return "是否允许拨打国际不能为空";
                    case "102113": return "创建应用失败";
                    case "102114": return "应用名称已存在";
                    case "103100": return "子账户昵称为空";
                    case "103101": return "子账户名称存在非法字符";
                    case "103102": return "子账户昵称长度有误";
                    case "103103": return "子账户clientNumber为空";
                    case "103104": return "同一应用下，friendlyname重复";
                    case "103105": return "子账户friendlyname只能包含数字和字母和下划线";
                    case "103106": return "client_number长度有误";
                    case "103107": return "client_number不存在或不属于该主账号";
                    case "103108": return "client已经关闭";
                    case "103109": return "client充值失败";
                    case "103110": return "client计费类型为空";
                    case "103111": return "clientType只能取值0,1";
                    case "103112": return "clientType为1时，charge不能为空";
                    case "103113": return "clientNumber未绑定手机号";
                    case "103114": return "同一应用下同一手机号只能绑定一次";
                    case "103115": return "单次查询记录数不能超过100";
                    case "103116": return "绑定手机号失败";
                    case "103117": return "子账号是否显号(isplay)不能为空";
                    case "103118": return "子账号是否显号(display)取值只能是0(不显号)和1(显号)";
                    case "103119": return "应用下该子账号不存在";
                    case "103120": return "friendlyname不能为空";
                    case "103121": return "查询client参数不能为空";
                    case "103122": return "client不属于应用";
                    case "103123": return "未上线应用不能超过100个client";
                    case "103124": return "已经是开通状态";
                    case "103125": return "子账号余额不足";
                    case "103126": return "未上线应用或demo只能使用白名单中号码";
                    case "103127": return "测试demo不能创建子账号";
                    case "103128": return "校验码不能为空";
                    case "103129": return "校验码错误或失效";
                    case "103130": return "校验号码失败";
                    case "103131": return "解绑失败,信息错误或不存在绑定关系";
                    case "104100": return "主叫clientNumber为空";
                    case "104101": return "主叫clientNumber未绑定手机号";
                    case "104102": return "验证码为空";
                    case "104103": return "显示号码不合法";
                    case "104104": return "语音验证码位4 - 8位";
                    case "104105": return "语音验证码位4 - 8位";
                    case "104106": return "语音通知类型错误";
                    case "104107": return "语音通知内容为空";
                    case "104108": return "语音ID非法";
                    case "104109": return "文本内容存储失败";
                    case "104110": return "语音文件不存在或未审核";
                    case "104111": return "号码与绑定的号码不一致";
                    case "104112": return "开通或关闭呼转失败";
                    case "104113": return "不能同时呼叫同一被叫";
                    case "104114": return "内容包含敏感词";
                    case "104115": return "语音通知发送多语音ID不能超过5个";
                    case "104116": return "不在线呼转模式只能取1,2,3,4";
                    case "104117": return "呼转模式为2,4则必须填写forwardPhone";
                    case "104118": return "呼转模式为2,4则前转号码与绑定手机号码不能相等";
                    case "104119": return "群聊列表格式不合法";
                    case "104120": return "群聊呼叫模式参数错误";
                    case "104121": return "群聊ID不能为空";
                    case "104122": return "群聊超过最大方数";
                    case "104123": return "群聊ID发送错误";
                    case "104124": return "群聊操作失败服务出错";
                    case "104125": return "呼转号码不存在";
                    case "104126": return "订单号不能为空";
                    case "104127": return "订单号不存在";
                    case "104128": return "号码释放失败或号码已经自动释放";
                    case "104129": return "显手机号必须是呼叫列表中的号码";
                    case "104130": return "主被叫不能相同";
                    case "104132": return "callid不能为空";
                    case "104133": return "发起者不能为空";
                    case "105100": return "短信服务请求异常";
                    case "105101": return "url关键参数为空";
                    case "105102": return "号码不合法";
                    case "105103": return "没有通道类别";
                    case "105104": return "该类别为冻结状态";
                    case "105105": return "没有足够金额";
                    case "105106": return "不是国内手机号码并且不是国际电话";
                    case "105107": return "黑名单";
                    case "105108": return "含非法关键字";
                    case "105109": return "该通道类型没有第三方通道";
                    case "105110": return "短信模板ID不存在";
                    case "105111": return "短信模板未审核通过";
                    case "105112": return "短信模板替换个数与实际参数个数不匹配";
                    case "105113": return "短信模板ID为空";
                    case "105114": return "短信内容为空";
                    case "105115": return "短信类型长度应为1";
                    case "105116": return "同一天同一用户不能发超过3条相同的短信";
                    case "105117": return "模板ID含非法字符";
                    case "105118": return "短信模板有替换内容，但参数为空";
                    case "105119": return "短信模板替换内容过长，不能超过70个字符";
                    case "105120": return "手机号码不能超过100个";
                    case "105121": return "短信模板已删除";
                    case "105122": return "同一天同一用户不能发超过N条验证码";
                    case "105123": return "短信模板名称为空";
                    case "105124": return "短信模板内容为空";
                    case "105125": return "创建短信模板失败";
                    case "105126": return "短信模板名称错误";
                    case "105127": return "短信模板内容错误";
                    case "105128": return "短信模板id为空";
                    case "105129": return "短信模板id不存在";
                    case "105130": return "30秒内不能连续发同样的内容";
                    case "105131": return "30秒内不能给同一号码发送相同模板消息";
                    case "105132": return "验证码短信参数长度不能超过100位";
                    case "105133": return "模板短信整体长度不能超过500位";
                    case "105134": return "自签名短信内容只能包含一对【】且不能只有短信签名，短信签名只能在开头或结尾";
                    case "105135": return "非自签短信内容中不允许出现【】";
                    case "105136": return "自签短信签名长度为2到12位";
                    case "105137": return "群发短信全部失败";
                    case "105138": return "群发短信号码不能重复";
                    case "105139": return "补发短信模板不规范";
                    default:
                        return "";
                }


            }
        }

        public static implicit operator Resp(string code) {
            return new Resp { respCode = code };
        }

        public static implicit operator string(Resp result) {
            return result.respCode;
        }
    }
}
