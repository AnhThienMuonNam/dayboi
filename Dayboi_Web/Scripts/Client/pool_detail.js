var MainModel = function (data) {

    var self = this;

    self.Pool = ko.observable(data.Pool || '');

    self.Tags = ko.observableArray(data.Pool && data.Pool.Tags ? data.Pool.Tags : []);

    self.OtherPools = ko.observableArray(data.Pool && data.Pool.OtherPools ? data.Pool.OtherPools : []);

    self.showContent = function (text) {
        if (text) {
            return unescape(text);
        }
        return '';
    }
}

