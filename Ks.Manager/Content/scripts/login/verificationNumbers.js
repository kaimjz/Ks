function showCheck(a) {
    var c = document.getElementById("codeCanvas");
    var ctx = c.getContext("2d");
    ctx.fillStyle = "#fff";
    ctx.clearRect(0, 0, 1000, 1000);
    ctx.font = "80px 'Microsoft Yahei'";
    ctx.fillText(a, 0, 100)
}
var code;
function createCode() {
    code = "";
    var codeLength = 4;
    var selectChar = new Array(1, 2, 3, 4, 5, 6, 7, 8, 9, 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
    for (var i = 0; i < codeLength; i++) {
        var charIndex = Math.floor(Math.random() * 60);
        code += selectChar[charIndex];
    }
    if (code.length != codeLength) {
        createCode();
    }
    showCheck(code);
}

function validate() {
    var codeDom = document.getElementById("codeText"), inputCode = codeDom.value.toUpperCase();
    var codeToUp = code.toUpperCase();
    createCode();
    codeDom.value = "";
    codeDom.focus();
    if (inputCode.length <= 0) {
        codeDom.setAttribute("placeholder", "输入验证码");
        return false;
    }
    else if (inputCode != codeToUp) {
        codeDom.value = "";
        codeDom.setAttribute("placeholder", "验证码错误");
        return false;
    }
    else {
        codeDom.setAttribute("placeholder", "输入验证码");
        return true;
    }
}