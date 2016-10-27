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
    exports.dateSingleAddZero = function (num) {
        if (num < 10) {
            return "0" + num;
        }
        return num;
    };
    exports.datetimeFormat = function (datetimeStr) {
        if (!datetimeStr) {
            return "";
        }
        var that = this;
        var date = eval(datetimeStr.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"));
        var year = date.getFullYear();
        var month = that.dateSingleAddZero(date.getMonth() + 1);
        var day = that.dateSingleAddZero(date.getDate());
        var hours = that.dateSingleAddZero(date.getHours());
        var minute = that.dateSingleAddZero(date.getMinutes());
        var seconds = that.dateSingleAddZero(date.getSeconds());
        return year + "-" + month + "-" + day + " " + hours + ":" + minute + ":" + seconds;
    };
    exports.setStatus = function (statu) {
        if (statu == true || statu == "true") {
            return '<span class="monk-iconfont icon-monk-dagou tipcolor"></span>';
        }
        else {
            return '<span class="monk-iconfont icon-monk-dacha"></span>';
        }
    };
    // 成功提示
    exports.successTip = function (msg, options, end) {
        options = options || {};
        var defaults = { icon: 1, offset: 0 };
        var config = $.extend(true, defaults, options);
        var _layer = parent.layer ? parent.layer : layer;
        return _layer.msg(msg, config, end);
    };
    // 错误提示
    exports.errorTip = function (msg, options, end) {
        options = options || {};
        var defaults = { icon: 2, offset: 0 };
        var config = $.extend(true, defaults, options);
        var _layer = parent.layer ? parent.layer : layer;
        return _layer.msg(msg, config, end);
    };
    // 加载提示
    exports.loadTip = function (msg, options, end) {
        options = options || {};
        var defaults = { icon: 16, time: 30000, offset: 0 };
        var config = $.extend(true, defaults, options);
        var _layer = parent.layer ? parent.layer : layer;
        return _layer.msg(msg, config, end);
    };
    // 正常提示
    exports.Tip = function (msg, options, end) {
        options = options || {};
        var defaults = { icon: 0, offset: 0 };
        var config = $.extend(true, defaults, options);
        var _layer = parent.layer ? parent.layer : layer;
        return _layer.msg(msg, config, end);
    };
    // 确认提示
    exports.confirm = function (msg, options, yes, cancel) {
        var defaults = { icon: 3, title: "确认询问", offset: 0, shade: 0.1 };
        var config = $.extend(true, defaults, options);
        var _layer = parent.layer ? parent.layer : layer;
        return _layer.confirm(msg, config, yes, cancel);
    };
    // post提交
    exports.post = function (url, data, callback, dataType) {
        var that = this;
        that.loadTip("正在执行相关操作...");
        $.post(url, data, function (data) {
            if (data.status == "y") {
                that.successTip(data.info);
                if (typeof callback == "function") {
                    callback(data);
                }
            }
            else {
                that.errorTip(data.info + data.others.Message);
            }
        }, dataType);
        that.ajaxError();
    };
    // get获取
    exports.get = function (url, data, callback, dataType) {
        var that = this;
        that.loadTip("正在执行相关操作...");
        $.get(url, data, function (data) {
            if (data.status == "y") {
                that.successTip(data.info);
                if (typeof callback == "function") {
                    callback(data);
                }
            }
            else {
                that.errorTip(data.info + data.others.Message);
            }
        }, dataType);
        that.ajaxError();
    };
    // 打开搜索
    exports.openSearch = function () {
        var speed = 200;
        var $search = $(".backend-searchs");
        var width = $search.outerWidth(true);
        var right = Number($search.css("right").replace("px", ""));
        if (!$search.is(":animated")) {
            if (right < 0) {
                $(".backend-searchs").animate({
                    right: 0
                }, speed, function () { });
            }
            else {
                $(".backend-searchs").animate({
                    right: -width
                }, speed, function () { });
            }
        }
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
        var config = $.extend(true, defaults, options);
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
    exports.ajaxError = function (callback) {
        $(document).ajaxComplete(function (event, xhr, options) {
            if (xhr.status == 404) {
                backend.errorTip("远程地址没找到");
            }
            else if (xhr.status >= 500) {
                backend.errorTip("应用程序异常");
            }
            else {
                if (typeof callback == "function") {
                    callback(event, xhr, options);
                }
            }
        });
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
        var config = $.extend(true, defaults, options);
        return jqueryObj.niceScroll(config);
    };
    // 文件上传（目前只支持单文件）
    exports.fileUpload = function (options) {
        var that = this;
        options = options || {};
        var uploader, state = "pending";
        var defaults = {
            options: {
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
                fileSingleSizeLimit: 2 * 1024 * 1024
            },
            // 显示上传状态文本框
            input: "#uploadUrl",
            // 进度条
            progress: "#uploadProgress",
            // 选择按钮
            selectBtn: "#selectFiles",
            // 开始按钮
            startBtn: "#startUpload",
            //移除按钮
            removeBtn: "#removeFile",
            // 重置按钮
            clearBtn: "#clearUpload",
            data: {},
            headers: { "SecretKey": "d86c2c08c8c2247ec59c4ddeaaf4598a" },
            fileQueued: function (file) {
            },
            fileDequeued: function (file) {
            },
            startUpload: function () {
            },
            uploadBeforeSend: function (obj, data, headers) {
            },
            uploadProgress: function (file, percentage) {
            },
            uploadSuccess: function (file, response) {
            },
            uploadError: function (file, reason) {
            },
            uploadComplete: function (file) {
            },
            error: function (type) {
            },
            all: function (type) {
            },
            reset: function () {
            }
        };
        var config = $.extend(true, defaults, options);
        config.options.pick.id = config.selectBtn;

        var $input = $(config.input)
                , $progress = $(config.progress)
                , $btn = $(config.startBtn)
                , $rmbtn = $(config.removeBtn)
               , $clearbtn = $(config.clearBtn);
        uploader = WebUploader.create(config.options);
        // 当有文件添加进来的时候
        uploader.on('fileQueued', function (file) {
            state = "pending";
            if (uploader.getStats().queueNum > 0) {
                uploader.removeFile($input.attr("data-fileId"));
            }
            $input.val("等待上传：" + file.name).attr("data-fileId", file.id);
            $progress.css('width', '0%');
            if (typeof config.fileQueued == "function") {
                config.fileQueued(file);
            }
        });
        // 移除上传
        uploader.on('fileDequeued', function (file) {
            that.Tip("已将已选择的文件从上传队列中移除");
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
            data = $.extend(true, data, config.data);
            headers = $.extend(true, headers, config.headers);
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
                $input.val("上传失败：" + file.name).attr("data-fileId", file.id);
                that.errorTip(response.info);
            }
            else if (response.status == "not_allow") {
                $input.val("上传失败：" + file.name).attr("data-fileId", file.id);
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
                that.errorTip("该文件超过最大限制：" + (config.options.fileSingleSizeLimit / 1024 / 1024) + " M");
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
            if (typeof config.fileDequeued == "function") {
                config.fileDequeued();
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
            $clearbtn.attr("disabled", "disabled");
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
    // 分页
    exports.pagination = function (url, pageSize, params, success, selector, options) {
        var that = this;
        selector = selector ? selector : "#page";
        options = options || {};
        params = params || {};
        pageSize = Number(pageSize) ? Math.abs(Number(pageSize)) : 15;
        var defaults = {
            pageSize: pageSize,
            total: 1000,
            pageBtnCount: 7,
            showInfo: true,
            infoFormat: "共 {total} 条记录",
            noInfoText: "共 0 条记录",
            showJump: true,
            jumpBtnText: "转到",
            showPageSizes: true,
            pageSizeItems: [5, 10, 15, 20, 25, 30],
            remote: {
                url: url,
                params: params,
                success: function (data) {
                    if (typeof success == "function") {
                        if (data.status == "y") {
                            success(data);
                        }
                    }
                },
                beforeSend: function (xhr) {
                    that.loadTip("正在加载数据...");
                },
                complete: function (xhr, status) {
                    var result = eval("(" + xhr.responseText + ")");
                    if (xhr.status == 404) {
                        that.errorTip("远程地址没找到");
                    }
                    else if (xhr.status >= 500) {
                        that.errorTip("应用程序异常");
                    }
                    else if (xhr.responseText.status == "n") {
                        that.errorTip(xhr.responseText.info);
                    }
                    else if (xhr.responseText.status == "not_allow") {
                        that.errorTip(xhr.responseText.info);
                    }
                    else if (result.status == "y") {
                        that.successTip(result.info);
                    }
                    else {
                    }
                },
                totalName: 'others.total',
                traditional: true
            }
        };
        var config = $.extend(true, defaults, options);
        $(selector).pagination(config);
    };
    // 绑定行点击
    exports.rowClick = function () {
        $(".monk-table table").on("click", "tr", function (e) {
            var that = $(this);
            e = window.event || e;
            var current = e.srcElement || e.target;

            if (!$(current).is(".list-textbox-sort")) {
                var radio = that.children(".monk-td-radio").find(".list-radio");
                if (radio.hasClass("checked")) {
                    radio.removeClass("checked");
                }
                else {
                    radio.addClass("checked");
                }
            }
        });
    }();
    // 全选
    exports.checkall = function (e) {
        if ($.trim($(e).text()) == "全选") {
            $(".monk-table .monk-td-radio .list-radio").addClass("checked");
            $(e).children("label").text("反选");
        }
        else {
            $(".monk-table .monk-td-radio .list-radio").each(function () {
                if ($(this).hasClass("checked")) {
                    $(this).removeClass("checked");
                }
                else {
                    $(this).addClass("checked");
                }
            });
            $(e).children("label").text("全选");
        }
    };
    // 获取选中的id
    exports.getCheckIds = function () {
        var ids = [];
        $(".monk-table .monk-td-radio .list-radio.checked").each(function (e) {
            var id = $(this).attr("data-id");
            if (id) {
                ids.push(id);
            }
        });
        return ids;
    };
});
