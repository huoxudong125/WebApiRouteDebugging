(function() {
    var rendererProto = marked.Renderer.prototype;

    rendererProto._code = rendererProto.code;

    rendererProto.code = function (code, lang, escaped) {
        var addon = '';
        switch (lang) {
            case 'immediately':
                eval(code);
                break;
            case 'button':
                var escapedCode = code.replace('"', '\\"');
                addon = '<button class="minibutton" onclick="' + escapedCode + '">Выполнить</button>';
                break;
        }

        return '<div class="code">' + this._code.apply(this, arguments) + addon + '</div>';
    };
})();

