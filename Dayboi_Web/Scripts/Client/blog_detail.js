var MainModel = function (data) {
    var self = this;
    self.Blog = ko.observable(data.Blog || '');

    self.showContent = function (text) {
        if (text) {
            return unescape(text);
        }
        return '';
    }
}

