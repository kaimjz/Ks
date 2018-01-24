/*********************************jqGrid拓展方法*****************************************/
$.fn.jqGridEx = function (obj) {
    var id = $(this).attr('id');
    if (!id) {
        return;
    }
    var selectedRowIndex;
    var $jqGrid = $('#' + id);
    var defaults = {
        url: "",//获取数据的地址
        datatype: "json",/*从服务器端返回的数据类型，默认xml。
                               可选类型：xml，local，json，jsonnp，script，xmlstring，jsonstring，clientside*/
        height: $(window).height() - 140,//表格高度，可以是数字，像素值或者百分比
        autowidth: true,/*如果为ture时，则当表格在首次被创建时会根据父元素比例重新调整表格宽度。
                              如果父元素宽度改变，为了使表格宽度能够自动调整则需要实现函数：setGridWidth*/
        colModel: [],/*常用到的属性：name 列显示的名称；index 传到服务器端用来排序用的列名称；width 列宽度；
                           align 对齐方式；sortable 是否可以排序*/
        viewrecords: true,//是否要显示总记录数
        rowNum: 30,//在grid上显示记录条数，这个参数是要被传递到后台
        rowList: [30, 50, 100],//一个下拉选择框，用来改变显示记录数，当选择时会覆盖rowNum参数传递到后台
        pager: "#gridPager",//定义翻页用的导航栏，必须是有效的html元素。翻页工具栏可以放置在html页面任意位置
        //sortname: 'CreateDate desc',//默认的排序列。可以是列名称或者是一个数字，这个参数会被提交到后台
        rownumbers: true,//如果为ture则会在表格左边新增一列，显示行顺序号，从1开始递增。此列名为'rn'
        shrinkToFit: false,/*此属性用来说明当初始化列宽度时候的计算类型，如果为ture，则按比例初始化列宽度。
                                 如果为false，则列宽度使用colModel指定的宽度*/
        gridview: true,/*构造一行数据后添加到grid中，如果设为true则是将整个表格的数据都构造完成后再添加到grid中，
                             但treeGrid, subGrid, or afterInsertRow 不能用*/
        onSelectRow: function () {
            selectedRowIndex = $("#" + this.id).getGridParam('selrow');
        },//选择或反选指定行。如果onselectrow为ture则会触发事件onSelectRow，onselectrow默认为ture
        gridComplete: function () {
            $("#" + this.id).setSelection(selectedRowIndex, false);
        }//当表格所有数据都加载完成而且其他的处理也都完成时触发此事件，排序，翻页同样也会触发此事件
    };
    var options = $.extend(defaults, obj);
    $jqGrid.jqGrid(options);
}
$.fn.jqGridRowValue = function (code) {
    var $jgrid = $(this),
        json = [],
        selectedRowIds = $jgrid.jqGrid("getGridParam", "selarrrow");
    if (selectedRowIds && selectedRowIds.length > 1) {
        var len = selectedRowIds.length;
        for (var i = 0; i < selectedRowIds.length; i++) {
            var rowData = $jgrid.jqGrid('getRowData', selectedRowIds[i]);
            json.push(rowData[code]);
        }
    } else {
        var rowData = $jgrid.jqGrid('getRowData', $jgrid.jqGrid('getGridParam', 'selrow'));
        json.push(rowData[code]);
    }
    return String(json);
}
$.fn.jqGridRow = function () {
    var $jgrid = $(this);
    var json = [];
    var selectedRowIds = $jgrid.jqGrid("getGridParam", "selarrrow");
    if (selectedRowIds != "") {
        var len = selectedRowIds.length;
        for (var i = 0; i < len; i++) {
            var rowData = $jgrid.jqGrid('getRowData', selectedRowIds[i]);
            json.push(rowData);
        }
    } else {
        var rowData = $jgrid.jqGrid('getRowData', $jgrid.jqGrid('getGridParam', 'selrow'));
        json.push(rowData);
    }
    return json;
}

/*********************************pangination拓展方法*****************************************/
$.fn.panginationEx = function (obj) {
    var id = $(this).attr('id');
    if (!id) {
        return;
    }
    var defaults = {
        firstBtnText: '首页',
        lastBtnText: '尾页',
        prevBtnText: '上一页',
        nextBtnText: '下一页',
        showInfo: true,
        showJump: true,
        jumpBtnText: '跳转',
        showPageSizes: true,
        infoFormat: '{start} ~ {end}条，共{total}条',
        //sortname: '',
        url: "",
        success: null,
        beforeSend: null,
        complete: null
    };
    var options = $.extend(defaults, obj);
    var params = $.extend({ sidx: options.sortname, sord: "asc" }, options.params);
    options.remote = {
        url: options.url,  //请求地址
        params: params,       //自定义请求参数
        beforeSend: function (XMLHttpRequest) {
            if (options.beforeSend != null) {
                options.beforeSend(XMLHttpRequest);
            }
        },
        success: function (result, pageIndex) {
            //回调函数
            //result 为 请求返回的数据，呈现数据
            if (options.success != null) {
                options.success(result.rows, pageIndex);
            }
        },
        complete: function (XMLHttpRequest, textStatu) {
            if (options.complete != null) {
                options.complete(XMLHttpRequest, textStatu);
            }
            //...
        },
        pageIndexName: 'page',     //请求参数，当前页数，索引从0开始
        pageSizeName: 'rows',       //请求参数，每页数量
        totalName: 'records'              //指定返回数据的总数据量的字段名
    }
    $pager.page(options);
}

/*********************************layer拓展方法*****************************************/
//layer type 0（信息框，默认）1（页面层）2（iframe层）3（加载层）4（tips层）
//layer icon 0 警告 1 成功 2 错误 3 疑问 4 锁 5 不开心 6 开心

//layer 加载动画
function layerLoading(isShow) {
    layui.use('layer', function () {
        var layer = layui.layer;
        if (isShow) {
            layer.load(1);
        }
        else {
            layer.closeAll('loading')
        }
    })
}

//layer 消息弹窗
function layerMsg(content, type) {
    if ($isNullOrEmpty(type)) {
        type = 2;
    }
    layer.msg(content, {
        icon: type,
        time: 2000,
        shift: 5
    });
}

//layer Iframe页面
function layerIframe(obj) {
    var defaults = {
        id: null,
        title: '系统窗口',
        width: "100px",
        height: "100px",
        url: '',
        shade: 0.3,
        maxmin: true,
        btn: false,//['确认', '关闭'],
        callBack: null
    };
    var options = $.extend(defaults, obj);
    var _url = options.url;
    var _width = top.$windowWidth() > parseInt(options.width.replace('px', '')) ? options.width : top.$windowWidth() + 'px';
    var _height = top.$windowHeight() > parseInt(options.height.replace('px', '')) ? options.height : top.$windowHeight() + 'px';
    layer.open({
        id: options.id,
        type: 2,
        shade: options.shade,
        title: options.title,
        fix: false,
        area: [_width, _height],
        content: options.url,
        maxmin: options.maxmin,
        btn: options.btn,
        yes: function () {
            options.callBack(options.id)
        }, cancel: function () {
            if (options.cancel != undefined) {
                options.cancel();
            }
            return true;
        }
    });
}

//layer 页面层
//配置, 一般只提供id, title, width, height, content即可
function layerContent(obj) {
    var defaults = {
        id: null,
        title: '系统窗口',
        width: "100px",
        height: "100px",
        content: '',
        btn: false,//['确认', '关闭'],
        callBack: null
    };
    var options = $.extend(defaults, obj);
    layer.open({
        id: options.id,
        type: 1,
        title: options.title,
        fix: false,
        area: [options.width, options.height],
        content: options.content,
        btn: options.btn,
        yes: function () {
            options.callBack(options.id)
        }
    });
}

//layer 弹窗
function layerAlert(content, type) {
    if ($isNullOrEmpty(type)) {
        type = 2;
    }
    layer.alert(content, {
        icon: type,
        title: "提示"
    });
}

//layer 确认框
function layerConfirm(content, callBack) {
    layer.confirm(content, {
        icon: 0,
        title: "提示",
        btn: ['确认', '取消'],
    }, function () {
        callBack(true);
    }, function () {
        callBack(false)
    });
}

/*********************************基本公共方法*****************************************/
function $isbrowsername() {
    var userAgent = navigator.userAgent; //取得浏览器的userAgent字符串
    var isOpera = userAgent.indexOf("Opera") > -1;
    if (isOpera) {
        return "Opera"
    }; //判断是否Opera浏览器
    if (userAgent.indexOf("Firefox") > -1) {
        return "FF";
    } //判断是否Firefox浏览器
    if (userAgent.indexOf("Chrome") > -1) {
        if (window.navigator.webkitPersistentStorage.toString().indexOf('DeprecatedStorageQuota') > -1) {
            return "Chrome";
        } else {
            return "360";
        }
    }//判断是否Chrome浏览器//360浏览器
    if (userAgent.indexOf("Safari") > -1) {
        return "Safari";
    } //判断是否Safari浏览器
    if (userAgent.indexOf("compatible") > -1 && userAgent.indexOf("MSIE") > -1 && !isOpera) {
        return "IE";
    }; //判断是否IE浏览器
}
function $isNullOrEmpty(obj) {
    if ((typeof (obj) == "string" && obj == "") || obj == null || obj == undefined) {
        return true;
    }
    else {
        return false;
    }
}
function $arrayClone(data) {
    return $.map(data, function (obj) {
        return $.extend(true, {}, obj);
    });
}
function $windowWidth() {
    return $(window).width();
}
function $windowHeight() {
    return $(window).height();
}

//是否选中表格行
function checkedArray(obj) {
    var isOK = true;
    if ($isNullOrEmpty(obj)) {
        isOK = false;
        dialogMsg('您没有选中任何项,请您选中后再操作。', 0);
    }
    return isOK;
}
//是否选中单行
function checkedRow(obj) {
    var isOK = true;
    if ($isNullOrEmpty(obj)) {
        isOK = false;
        dialogMsg('您没有选中任何数据项,请选中后再操作！', 0);
    }
    else if (obj.split(",").length > 1) {
        isOK = false;
        dialogMsg('很抱歉,一次只能选择一条记录！', 0);
    }
    return isOK;
}
//刷新页面
function reload() {
    location.reload();
    return false;
}
//获取guid
function newGuid() {
    var guid = "";
    for (var i = 1; i <= 32; i++) {
        var n = Math.floor(Math.random() * 16.0).toString(16);
        guid += n;
        if ((i == 8) || (i == 12) || (i == 16) || (i == 20)) guid += "-";
    }
    return guid;
}
//时间格式转化
function formatDate(v, format) {
    if (!v) return "";
    var d = v;
    if (typeof v === 'string') {
        if (v.indexOf("/Date(") > -1)
            d = new Date(parseInt(v.replace("/Date(", "").replace(")/", ""), 10));
        else
            d = new Date(Date.parse(v.replace(/-/g, "/").replace("T", " ").split(".")[0]));//.split(".")[0] 用来处理出现毫秒的情况，截取掉.xxx，否则会出错
    }
    var o = {
        "M+": d.getMonth() + 1,  //month
        "d+": d.getDate(),       //day
        "h+": d.getHours(),      //hour
        "m+": d.getMinutes(),    //minute
        "s+": d.getSeconds(),    //second
        "q+": Math.floor((d.getMonth() + 3) / 3),  //quarter
        "S": d.getMilliseconds() //millisecond
    };
    if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1, (d.getFullYear() + "").substr(4 - RegExp.$1.length));
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
};
//数值类型转化
function toDecimal(num) {
    if (num == null) {
        num = "0";
    }
    num = num.toString().replace(/\$|\,/g, '');
    if (isNaN(num))
        num = "0";
    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num * 100 + 0.50000000001);
    cents = num % 100;
    num = Math.floor(num / 100).toString();
    if (cents < 10)
        cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
        num = num.substring(0, num.length - (4 * i + 3)) + '' +
            num.substring(num.length - (4 * i + 3));
    return (((sign) ? '' : '-') + num + '.' + cents);
}
//时间增加
Date.prototype.DateAdd = function (strInterval, Number) {
    //y年 q季度 m月 d日 w周 h小时 n分钟 s秒 ms毫秒
    var dtTmp = this;
    switch (strInterval) {
        case 's': return new Date(Date.parse(dtTmp) + (1000 * Number));
        case 'n': return new Date(Date.parse(dtTmp) + (60000 * Number));
        case 'h': return new Date(Date.parse(dtTmp) + (3600000 * Number));
        case 'd': return new Date(Date.parse(dtTmp) + (86400000 * Number));
        case 'w': return new Date(Date.parse(dtTmp) + ((86400000 * 7) * Number));
        case 'm': return new Date(dtTmp.getFullYear(), (dtTmp.getMonth()) + Number, dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());
        case 'q': return new Date(dtTmp.getFullYear(), (dtTmp.getMonth()) + Number * 3, dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());
        case 'y': return new Date((dtTmp.getFullYear() + Number), dtTmp.getMonth(), dtTmp.getDate(), dtTmp.getHours(), dtTmp.getMinutes(), dtTmp.getSeconds());
    }
}
//接收地址栏参数
function request(keyValue) {
    var search = location.search.slice(1);
    var arr = search.split("&");
    for (var i = 0; i < arr.length; i++) {
        var ar = arr[i].split("=");
        if (ar[0] == keyValue) {
            if (unescape(ar[1]) == 'undefined') {
                return "";
            } else {
                return unescape(ar[1]);
            }
        }
    }
    return "";
}
//改变地址栏参数
function changeUrlParam(url, key, value) {
    var newUrl = "";
    var reg = new RegExp("(^|)" + key + "=([^&]*)(|$)");
    var tmp = key + "=" + value;
    if (url.match(reg) != null) {
        newUrl = url.replace(eval(reg), tmp);
    } else {
        if (url.match("[\?]")) {
            newUrl = url + "&" + tmp;
        }
        else {
            newUrl = url + "?" + tmp;
        }
    }
    return newUrl;
}
//异步请求
function getAjax(obj) {
    var defaults = {
        type: 'post',
        dataType: "text",
        url: '',
        data: {},
        cache: false,
        async: false,
        success: null
    };
    var options = $.extend(defaults, obj);
    $.ajax({
        type: options.type,
        dataType: options.datatype,
        dataType: options.datatype,
        url: options.url,
        data: options.data,
        cache: options.cache,
        async: options.async,
        success: options.success
    });
}