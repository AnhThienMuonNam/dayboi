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
    };

    self.RegisterCourseButtonName = ko.observable(data.Course.Name || '');
    self.registerCourseModel = ko.observable(new RegisterCourseModel(self, data));
    self.registerCourseModel().CourseId(data.Course.Id);
}

var RegisterCourseModel = function (parent, data) {
    var self = this;
    self.FullName = ko.observable('').extend({
        required: {
            message: "Bạn chưa nhập họ tên"
        }
    });
    self.Phone = ko.observable('').extend({
        required: {
            message: "Bạn chưa nhập số điện thoại"
        }
    });
    self.StartDate = ko.observable('');
    self.Note = ko.observable('');
    self.CourseId = ko.observable(null).extend({
        required: {
            message: "Bạn chưa chọn khoá học nào"
        }
    });

    self.HasError = ko.observable(false);
    self.showErrorValidations = function () {
        var errors = ko.validation.group(self);
        if (errors().length > 0) {
            errors.showAllMessages(true);
            self.HasError(true);
        } else {
            self.HasError(false);
        }
    };

    self.IsSuccess = ko.observable(false);
    self.Message = ko.observable('');
    self.register = function () {
        self.IsSuccess(false);
        self.Message('');
        self.showErrorValidations();
        if (self.HasError() === true)
            return;
        var model = self.toJSON();
        $.ajax({
            url: data.API_URLs.RegisterCourse,
            type: "POST",
            data: { model: model },
            success: function (response) {
                if (response.IsSuccess === true) {
                    self.IsSuccess(true);
                    self.Message("Bạn đã đăng ký thành công khoá học " + parent.RegisterCourseButtonName() + ". Chúng tôi sẽ liên hệ với bạn ngay khi nhận được thông tin!")
                } else {
                    self.Message(response.Message);
                    self.IsSuccess(false);
                }
                self.FullName('');
                self.Phone('');
                self.Note('');
            },
            error: function (xhr, error) {
            }
        });
    };

    RegisterCourseModel.prototype.toJSON = function () {
        var model = {
            FullName: ko.utils.unwrapObservable(this.FullName),
            Phone: ko.utils.unwrapObservable(this.Phone),
            Note: ko.utils.unwrapObservable(this.Note),
            CourseId: ko.utils.unwrapObservable(this.CourseId),
        };

        return model;
    };
};

