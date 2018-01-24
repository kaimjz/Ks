/*! jQuery Validation Plugin - v1.17.0 - 7/29/2017
 * http://jqueryvalidation.org/
 * Copyright (c) 2014 Jörn Zaefferer; Licensed MIT */
! function (a) {
    "function" == typeof define && define.amd ? define(["jquery", "jquery.validate.min"], a) : a(jQuery)
}(function (a) {
    var icon = "<i class='fa fa-times-circle'></i>  ";
    a.extend(a.validator.messages, {
        required: icon + "必填",
        remote: icon + "请修正此栏位",
        email: icon + "请输入有效的邮箱",
        url: icon + "请输入有效的网址",
        date: icon + "请输入有效的日期",
        dateISO: icon + "请输入有效的日期 (YYYY-MM-DD)",
        number: icon + "请输入正确的数字",
        digits: icon + "只能输入数字",
        creditcard: icon + "请输入有效的信用卡号码",
        equalTo: icon + "您的两次输入不相同",
        extension: icon + "请输入有效的后缀",
        maxlength: a.validator.format(icon + "最多 {0} 个字"),
        minlength: a.validator.format(icon + "最少 {0} 个字"),
        rangelength: a.validator.format(icon + "请输入长度为 {0} 至 {1} 之间的字串"),
        range: a.validator.format(icon + "请输入 {0} 至 {1} 之间的数值"),
        max: a.validator.format(icon + "请输入不大于 {0} 的数值"),
        min: a.validator.format(icon + "请输入不小于 {0} 的数值")
    });
    a.validator.addMethod("telephone", function (value, element) {//自定义手机号验证
        return this.optional(element) || /^(1)\d{10}$/.test(value);
    }, icon + "请输入有效的手机号码");
    a.validator.addMethod("email", function (value, element) {//自定义邮箱验证  
        return this.optional(element) || /^[a-zA-Z0-9_-]{2,20}@([a-zA-Z0-9_-]{1,8}\.){1,3}[a-zA-Z0-9_-]{2,5}$/.test(value);
    }, icon + "请输入有效的邮箱");
    a.validator.addMethod("noChinese", function (value, element) {//自定义无中文
        return this.optional(element) || !/[\u4E00-\u9FA5]/.test(value);
    }, icon + "不能输入中文");
    a.validator.addMethod("noSign", function (value, element) {//自定义无特殊符号
        return this.optional(element) || !/<|>|'|&quot;?|&amp;?|&lt;?|&gt;?|&nbsp;?/.test(value);
    }, icon + "请输入有效的字符");
    a.validator.addMethod("rangelengthSqace", function (value, element, params) {//限制字符串长度空格除外
        return this.optional(element) || value.replace(/\s/g, "").length >= params[0] && value.replace(/\s/g, "").length <= params[1];
    }, icon + "请输入长度为 {0} 至 {1} 之间的字串");
});
