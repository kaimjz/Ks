layui.use('form', function () {
    var form = layui.form;
    form.verify({
        username: function (value, item) {
            return this.public(value, item);
        },
        password: function (value, item) {
            return this.public(value, item);
        },
        public: function (value, item) {
            if (!value) {
                return "必填";
            }
            else if (value.length < 6 || value.length > 10) {
                return "长度为6-10位";
            }
        }
    });

    form.on("submit(*)", function (data) {

    })
})