var MainModel = function (data) {
    //properties
    var self = this;
    self.EditCourseUrl = ko.observable(data.API_URLs.EditCourseUrl);
    self.Courses = ko.observableArray(data.Courses || []);
}

