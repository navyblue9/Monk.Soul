﻿/*!
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

    // 对象深度拷贝（https://github.com/sindresorhus/deep-assign）
    function isObj(x) {
        var type = typeof x;
        return x !== null && (type === 'object' || type === 'function');
    }
    var hasOwnProperty = Object.prototype.hasOwnProperty;
    var propIsEnumerable = Object.prototype.propertyIsEnumerable;
    function toObject(val) {
        if (val === null || val === undefined) {
            throw new TypeError('Cannot convert undefined or null to object');
        }
        return Object(val);
    }
    function assignKey(to, from, key) {
        var val = from[key];
        if (val === undefined || val === null) {
            return;
        }
        if (hasOwnProperty.call(to, key)) {
            if (to[key] === undefined || to[key] === null) {
                throw new TypeError('Cannot convert undefined or null to object (' + key + ')');
            }
        }
        if (!hasOwnProperty.call(to, key) || !isObj(val)) {
            to[key] = val;
        } else {
            to[key] = assign(Object(to[key]), from[key]);
        }
    }
    function assign(to, from) {
        if (to === from) {
            return to;
        }
        from = Object(from);
        for (var key in from) {
            if (hasOwnProperty.call(from, key)) {
                assignKey(to, from, key);
            }
        }
        if (Object.getOwnPropertySymbols) {
            var symbols = Object.getOwnPropertySymbols(from);
            for (var i = 0; i < symbols.length; i++) {
                if (propIsEnumerable.call(from, symbols[i])) {
                    assignKey(to, from, symbols[i]);
                }
            }
        }
        return to;
    }
    exports.deepAssign = function (target) {
        target = toObject(target);
        for (var s = 1; s < arguments.length; s++) {
            assign(target, arguments[s]);
        }
        return target;
    }
    ;

    // 成功提示
    exports.successTip = function (msg, options, end) {
        options = options || {};
        var defaults = { icon: 1, offset: 0 };
        var config = $.extend({}, defaults, options);
        var _layer = parent.layer ? parent.layer : layer;
        return _layer.msg(msg, config, end);
    };
    // 错误提示
    exports.errorTip = function (msg, options, end) {
        options = options || {};
        var defaults = { icon: 2, offset: 0 };
        var config = $.extend({}, defaults, options);
        var _layer = parent.layer ? parent.layer : layer;
        return _layer.msg(msg, config, end);
    };
    // 加载提示
    exports.loadTip = function (msg, options, end) {
        options = options || {};
        var defaults = { icon: 16, time: 30000, offset: 0 };
        var config = $.extend({}, defaults, options);
        var _layer = parent.layer ? parent.layer : layer;
        return _layer.msg(msg, config, end);
    };
    // 正常提示
    exports.Tip = function (msg, options, end) {
        options = options || {};
        var defaults = { icon: 0, offset: 0 };
        var config = $.extend({}, defaults, options);
        var _layer = parent.layer ? parent.layer : layer;
        return _layer.msg(msg, config, end);
    };

    // 表单验证
    exports.validform = function (success, beforeSubmit, options) {
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
                if (typeof beforeSubmit == "function") {
                    beforeSubmit(curform);
                }
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
                if (data.status == "n" || data.status == "not_allow") {
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
        return $(config.form).Validform(config);
    };
    // ajax返回结果处理
    exports.ajaxResultHandle = function (data, end) {
        var that = this;
        if (data.status == "not_allow") {
            that.errorTip(data.info);
            return false;
        }
        if (typeof end == "function") {
            end(data);
        }
    };
    // 美化滚动条
    exports.nicescroll = function (jqueryObj, options) {
        options = options || {};
        var defaults = {
            cursorcolor: "#9f9f9f",
            cursoropacitymax: 1,
            touchbehavior: false,
            cursorwidth: "2px",
            cursorborder: "0",
            cursorborderradius: "2px",
            autohidemode: true
        };
        var config = $.extend({}, defaults, options);
        return jqueryObj.niceScroll(config);
    };
    // 文件上传（目前只支持单文件）
    exports.fileUpload = function (options) {
        var that = this;
        options = options || {};
        var uploader, state = "pending";
        var defaults = {
            upload: {
                auto: false,
                swf: '/Areas/Backend/Assets/Vendors/webuploader-v0.1.6/dist/Uploader.swf',
                server: '/Services/Common/UploadImage ',
                pick: {
                    id: '',
                    multiple: false
                },
                accept: {
                    title: '已选择图片',
                    extensions: 'gif,jpg,jpeg,bmp,png',
                    mimeTypes: 'image/*'
                },
                compress: false,
                fileSizeLimit: 1 * 1024 * 1024
            },
            input: "#uploadUrl",
            progress: "#uploadProgress",
            selectBtn: "#selectFiles",
            startBtn: "#startUpload",
            removeBtn: "#removeFile",
            clearBtn: "#clearUpload",
            data: {},
            headers: {},
            fileQueued: function (file) { },
            fileDequeued: function (file) { },
            startUpload: function () { },
            uploadBeforeSend: function (obj, data, headers) { },
            uploadProgress: function (file, percentage) { },
            uploadSuccess: function (file, response) { },
            uploadError: function (file, reason) { },
            uploadComplete: function (file) { },
            error: function (type) { },
            all: function (type) { },
            reset: function () { }
        };
        var config = that.deepAssign({}, defaults, options);
        config.upload.pick.id = config.selectBtn;
        var $input = $(config.input)
                , $progress = $(config.progress)
                , $btn = $(config.startBtn)
                , $rmbtn = $(config.removeBtn)
               , $clearbtn = $(config.clearBtn);
        uploader = WebUploader.create(config.upload);
        // 当有文件添加进来的时候
        uploader.on('fileQueued', function (file) {
            $input.val("等待上传：" + file.name).attr("data-fileId", file.id);
            $progress.css('width', '0%');
            if (typeof config.fileQueued == "function") {
                config.fileQueued(file);
            }
        });
        // 移除上传
        uploader.on('fileDequeued', function (file) {
            that.Tip("已将该文件从上传队列中移除");
            if (typeof config.fileDequeued == "function") {
                config.fileDequeued(file);
            }
        });
        // 上传之前
        uploader.on('startUpload', function () {
            if (uploader.getStats().queueNum == 0) {
                that.errorTip("没有检测到文件或文件已上传");
            }
            if (typeof config.startUpload == "function") {
                config.startUpload();
            }
        });
        // 提交之前
        uploader.on('uploadBeforeSend', function (obj, data, headers) {
            data = that.deepAssign(data, config.data);
            headers = that.deepAssign(headers, config.headers);
            if (typeof config.uploadBeforeSend == "function") {
                config.uploadBeforeSend(obj, data, headers);
            }
        });
        // 文件上传过程中创建进度条实时显示。
        uploader.on('uploadProgress', function (file, percentage) {
            $input.val("上传中：" + file.name);
            $progress.css('width', percentage * 100 + '%');
            if (typeof config.uploadProgress == "function") {
                config.uploadProgress(file, percentage);
            }
        });
        // 上传成功
        uploader.on('uploadSuccess', function (file, response) {
            if (response.status == "n") {
                that.errorTip(response.info);
            }
            else if (response.status == "y") {
                $input.val("上传成功：" + file.name).attr("data-fileId", file.id);
                $clearbtn.removeAttr("disabled");
                that.successTip(response.info);
                if (typeof config.uploadSuccess == "function") {
                    config.uploadSuccess(file, response);
                }
            }
        });
        // 上传出错
        uploader.on('uploadError', function (file, reason) {
            that.errorTip("上传出错" + reason);
            if (typeof config.uploadError == "function") {
                config.uploadError(file, reason);
            }
        });
        // 上传完成（包括失败，成功）
        uploader.on('uploadComplete', function (file) {
            $progress.css('width', '0%');
            if (typeof config.uploadComplete == "function") {
                config.uploadComplete(file);
            }
        });
        // 文件选择错误
        uploader.on('error', function (type) {
            if (type == "Q_TYPE_DENIED") {
                that.errorTip("不支持该文件类型");
            }
            else if (type == "Q_EXCEED_SIZE_LIMIT") {
                that.errorTip("该文件超过最大限制：" + (config.fileSizeLimit / 1024 / 1024) + " M");
            }
            else if (type == "Q_EXCEED_NUM_LIMIT") {
                that.errorTip("选择文件的总数已超过可选的大小");
            }
            $clearbtn.attr("disabled", "disabled");
            if (typeof config.error == "function") {
                config.error(type);
            }
        });
        // 监听上传所有状态
        uploader.on('all', function (type) {
            if (type === 'startUpload') {
                state = 'uploading';
            } else if (type === 'stopUpload') {
                state = 'paused';
            } else if (type === 'uploadFinished') {
                state = 'done';
            }
            if (state === 'uploading') {
                $input.val($input.val().replace("上传中：", "暂停上传："));
                $btn.text('暂停上传');
            } else {
                $btn.text('开始上传');
            }
            if (typeof config.all == "function") {
                config.all(type);
            }
        });
        // 重置
        uploader.on('reset', function () {
            that.Tip("上传组件已恢复初始值");
            if (typeof config.reset == "function") {
                config.reset();
            }
        });
        // 开始上传
        $btn.on('click', function () {
            if (state === 'uploading') {
                uploader.stop();
            } else {
                uploader.upload();
            }
        });
        // 清空队列
        $rmbtn.on("click", function () {
            uploader.removeFile($input.attr("data-fileId"));
            $input.val("未选择文件");
        });
        // 重置上传，删除服务器文件
        $clearbtn.on("click", function () {
            uploader.reset();
            $input.val("未选择文件");
            $(this).attr("disabled", "disabled");
        });
        return uploader;
    };
});
