var MainModel = function (data) {
    //properties
    var self = this;
    self.EditEnrollmentCourseUrl = ko.observable(data.API_URLs.EditEnrollmentCourseUrl);
    self.EnrollmentCourses = ko.observableArray(data.EnrollmentCourses || []);
}

