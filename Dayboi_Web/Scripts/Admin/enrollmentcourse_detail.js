var MainModel = function (data) {
    //properties
    var self = this;
    self.EnrollmentCourseStatues = ko.observableArray(data.EnrollmentCourseStatues || []);
    self.Courses = ko.observableArray(data.Courses || []);
    self.enrollmentCourseModel = ko.observable(new EnrollmentCourseModel(self, data));
}

var EnrollmentCourseModel = function (parent, data) {
    var self = this;
    self.Id = ko.observable(null);
    self.FullName = ko.observable(null);
    self.Phone = ko.observable(null);
    self.Note = ko.observable(null);
    self.CreatedOn = ko.observable(null);
    self.UpdatedOn = ko.observable(null);
    self.CourseId = ko.observable(null);
    self.EnrollmentCourseStatusId = ko.observable(null);

    if (data && data.EnrollmentCourse) {
        ko.mapping.fromJS(data.EnrollmentCourse, {}, self);
    }

    self.update = function () {
        var model = self.toJSON();
        $.ajax({
            url: data.API_URLs.Update,
            type: "POST",
            data: { model: model },
            success: function (response) {
                if (response.IsSuccess == true) {
                    alertify.success('Cập nhật đăng ký khoá học thành công');
                }
            },
            error: function (xhr, error) {
            },
        });
    }

    EnrollmentCourseModel.prototype.toJSON = function () {
        var model = {
            Id: ko.utils.unwrapObservable(this.Id),
            FullName: ko.utils.unwrapObservable(this.FullName),
            Phone: ko.utils.unwrapObservable(this.Phone),
            Note: ko.utils.unwrapObservable(this.Note),
            CourseId: ko.utils.unwrapObservable(this.CourseId),
            EnrollmentCourseStatusId: ko.utils.unwrapObservable(this.EnrollmentCourseStatusId),
        };
        return model;
    };
}
