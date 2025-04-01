mergeInto(LibraryManager.library, {
    InitLanguage: function() {
        if (typeof YaGames === 'undefined') {
            console.log("YaGames не найден, возможно, не на платформе Яндекс Игр");
            var lang = navigator.language || navigator.userLanguage || "en";
            var bufferSize = lengthBytesUTF8(lang) + 1;
            var buffer = _malloc(bufferSize);
            stringToUTF8(lang, buffer, bufferSize);
            SendMessage("Language", "SetLanguage", buffer);
            _free(buffer);
            return;
        }

        YaGames.init().then(function(ysdk) {
            window.ysdk = ysdk; // Сохраняем для дальнейшего использования
            console.log("Yandex SDK инициализирован через JSLib");
            var lang = ysdk.environment.i18n.lang;
            var bufferSize = lengthBytesUTF8(lang) + 1;
            var buffer = _malloc(bufferSize);
            stringToUTF8(lang, buffer, bufferSize);
            SendMessage("Language", "SetLanguage", buffer);
            _free(buffer);
        }).catch(function(err) {
            console.error("Ошибка инициализации Yandex SDK: " + err);
            SendMessage("Language", "OnYandexError", "Ошибка инициализации: " + err.message);
        });
    },

    // Для вызова позже (если нужно)
    GetLang: function() {
        if (window.ysdk) {
            var lang = window.ysdk.environment.i18n.lang;
            var bufferSize = lengthBytesUTF8(lang) + 1;
            var buffer = _malloc(bufferSize);
            stringToUTF8(lang, buffer, bufferSize);
            return buffer;
        } else {
            var lang = navigator.language || navigator.userLanguage || "en";
            var bufferSize = lengthBytesUTF8(lang) + 1;
            var buffer = _malloc(bufferSize);
            stringToUTF8(lang, buffer, bufferSize);
            return buffer;
        }
    }
});