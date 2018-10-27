var MainModel = function (data) {

    var self = this;

    self.Course = ko.observable(data.Course || '');

    self.Tags = ko.observableArray(data.Course && data.Course.Tags ? data.Course.Tags : []);

    self.OtherCourses = ko.observableArray(data.Course && data.Course.OtherCourses ? data.Course.OtherCourses : []);

    self.showContent = function (text) {
        if (text) {
            return unescape(text);
        }
        return '';
    }
}

