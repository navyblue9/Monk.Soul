/*!
 * backend.js
 * version: 1.0.0
 * author: 百小僧（QQ：8020292）
 * site：http://www.baisoft.org
 */
; !function (factory) {
    "use strict";
    if (typeof require === 'function' && typeof exports === 'object' && typeof module === 'object') {
        var target = module['exports'] || exports;
        factory(target);
    } else if (typeof define === 'function' && define['amd']) {
        define(['exports'], factory);
    } else {
        factory(window['backend'] = {});
    }
}(function (HExports) {
    var exports = typeof HExports !== 'undefined' ? HExports : {};
    exports.v = "1.0.0";

    // 成功提示
    exports.successTip = function (msg, options) {
        options = options || {};
        var defaults = { icon: 1, offset: 0 };
        var config = $.extend({}, defaults, options);
        var _layer = parent.layer ? parent.layer : layer;
        _layer.msg(msg, config);
    };
    // 错误提示
    exports.errorTip = function (msg, options) {
        options = options || {};
        var defaults = { icon: 2, offset: 0 };
        var config = $.extend({}, defaults, options);
        var _layer = parent.layer ? parent.layer : layer;
        _layer.msg(msg, config);
    };
    // 加载提示
    exports.loadTip = function (msg, options) {
        options = options || {};
        var defaults = { icon: 16, time: 30000, offset: 0 };
        var config = $.extend({}, defaults, options);
        var _layer = parent.layer ? parent.layer : layer;
        _layer.msg(msg, config);
    };
    // 正常提示
    exports.Tip = function (msg, options) {
        options = options || {};
        var defaults = { icon: 0, offset: 0 };
        var config = $.extend({}, defaults, options);
        var _layer = parent.layer ? parent.layer : layer;
        _layer.msg(msg, config);
    };

    // 表单验证
    exports.validform = function (success, options) {
        var that = this;
        options = options || {};
        var defaults = {
            form: ".monk-form",
            btnSubmit: ".monk-form-submit",
            btnReset: ".monk-form-reset",
            tiptype: function (msg, o, cssctl) {
                switch (o.type) {
                    case 1:
                        that.loadTip("正在校检数据合法性...")
                        break;
                    case 2:
                        that.successTip(msg)
                        break;
                    case 3:
                        that.errorTip(msg)
                        break;
                    case 4:
                        that.Tip(msg)
                        break;
                }
            },
            ignoreHidden: false,
            dragonfly: false,
            tipSweep: true,
            label: "",
            showAllError: false,
            postonce: true,
            ajaxPost: true,
            datatype: {},
            usePlugin: {},
            beforeCheck: function (curform) { },
            beforeSubmit: function (curform) {
                that.loadTip("正在校检数据合法性...");
            },
            callback: function (data) {
                if (data.status == 404) {
                    that.errorTip("远程地址没找到");
                    return false;
                }
                if (data.status >= 500) {
                    that.errorTip("应用程序异常");
                    return false;
                }
                if (data.status == "n") {
                    that.errorTip(data.info);
                    if (data.selector && $(data.selector)) {
                        $(data.selector).focus();
                    }
                    return false;
                }
                if (data.status == "y") {
                    that.successTip(data.info);
                    if (typeof success == "function") {
                        success(data);
                    }
                }
            }
        };
        var config = $.extend({}, defaults, options);
        $(config.form).Validform(config);
    };
});
