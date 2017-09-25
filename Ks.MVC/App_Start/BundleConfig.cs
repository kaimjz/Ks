using System.Web.Optimization;

namespace Ks.MVC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            string minStr = "min.";
            bundles.Add(new ScriptBundle("~/scripts/jquery").Include(
                        $"~/content/plugins/jquery/jquery.{minStr}js"));

            bundles.Add(new ScriptBundle("~/scripts/validate").Include(
                        $"~/content/plugins/jquery.validate/jquery.validate.{minStr}js",
                        $"~/content/plugins/jquery.validate/jquery.validate.zh.js"));

            #region layui-js

            //包含layui.js和所有模块的合并文件 较大 慎用  包含jquery
            bundles.Add(new ScriptBundle("~/scripts/layui/all").Include(
                      "~/content/plugins/layui/layui.all.js"));
            //核心库
            bundles.Add(new ScriptBundle("~/scripts/layui").Include(
                          "~/content/plugins/layui/layui.js"));

            #region 模块单个

            ////通用轮播组件 http://www.layui.com/doc/modules/carousel.html
            //bundles.Add(new ScriptBundle("~/scripts/layui/carousel").Include(
            //              "~/content/plugins/layui/lay/modules/carousel.js"));
            ////代码修饰器 http://www.layui.com/doc/modules/code.html
            //bundles.Add(new ScriptBundle("~/scripts/layui/code").Include(
            //              "~/content/plugins/layui/lay/modules/code.js"));
            ////常用元素操作 http://www.layui.com/doc/modules/element.html
            //bundles.Add(new ScriptBundle("~/scripts/layui/element").Include(
            //              "~/content/plugins/layui/lay/modules/element.js"));
            ////流加载 http://www.layui.com/doc/modules/flow.html
            //bundles.Add(new ScriptBundle("~/scripts/layui/flow").Include(
            //              "~/content/plugins/layui/lay/modules/flow.js"));
            ////表单模块 http://www.layui.com/doc/modules/form.html
            //bundles.Add(new ScriptBundle("~/scripts/layui/form").Include(
            //              "~/content/plugins/layui/lay/modules/form.js"));
            ////日期和时间组件 http://www.layui.com/doc/modules/laydate.html
            //bundles.Add(new ScriptBundle("~/scripts/layui/laydate").Include(
            //              "~/content/plugins/layui/lay/modules/laydate.js"));
            ////富文本编辑器 http://www.layui.com/doc/modules/layedit.html
            //bundles.Add(new ScriptBundle("~/scripts/layui/layedit").Include(
            //              "~/content/plugins/layui/lay/modules/layedit.js"));

            ////弹层组件 http://www.layui.com/doc/modules/layer.html
            //bundles.Add(new ScriptBundle("~/scripts/layui/layer").Include(
            //              "~/content/plugins/layui/lay/modules/layer.js"));

            ////分页模块 http://www.layui.com/doc/modules/laypage.html
            //bundles.Add(new ScriptBundle("~/scripts/layui/laypage").Include(
            //              "~/content/plugins/layui/lay/modules/laypage.js"));
            ////模板引擎 http://www.layui.com/doc/modules/laytpl.html
            //bundles.Add(new ScriptBundle("~/scripts/layui/laytpl").Include(
            //              "~/content/plugins/layui/lay/modules/laytpl.js"));
            ////移动端
            //bundles.Add(new ScriptBundle("~/scripts/layui/mobile").Include(
            //              "~/content/plugins/layui/lay/modules/mobile.js"));

            ////table模块/数据表格 http://www.layui.com/doc/modules/table.html
            //bundles.Add(new ScriptBundle("~/scripts/layui/table").Include(
            //              "~/content/plugins/layui/lay/modules/table.js"));

            ////树形菜单 http://www.layui.com/doc/modules/tree.html
            //bundles.Add(new ScriptBundle("~/scripts/layui/tree").Include(
            //              "~/content/plugins/layui/lay/modules/tree.js"));

            ////图片/文件上传 http://www.layui.com/doc/modules/upload.html
            //bundles.Add(new ScriptBundle("~/scripts/layui/upload").Include(
            //              "~/content/plugins/layui/lay/modules/upload.js"));
            ////工具集 http://www.layui.com/doc/modules/util.html
            //bundles.Add(new ScriptBundle("~/scripts/layui/util").Include(
            //              "~/content/plugins/layui/lay/modules/util.js"));

            #endregion

            #endregion

            bundles.Add(new StyleBundle("~/styles/css").Include(
                      "~/content/plugins/layui/css/layui.css"));
        }
    }
}