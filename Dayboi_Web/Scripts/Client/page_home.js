var MainModel = function (data) {
    var self = this;
    self.registerCourseModel = ko.observable(new RegisterCourseModel(self, data));
    self.TempPriceOfOrder = ko.observable(0);
    self.Courses = ko.observableArray(data.Home && data.Home.Courses ? data.Home.Courses : []);

    self.SelectedCourse = ko.observable(self.Courses() ? self.Courses()[0] : null);
    self.registerCourseModel().CourseId(self.SelectedCourse().Id);

    self.RegisterCourseButtonName = ko.observable(self.SelectedCourse() ? self.SelectedCourse().Name : 'Bạn chưa chọn khoá học nào đăng ký');

    self.selectCourse = function (item) {
        if (!self.SelectedCourse() || (item.Id !== self.SelectedCourse().Id)) {
            self.SelectedCourse(item);
            self.RegisterCourseButtonName(item.Name);
            self.registerCourseModel().CourseId(item.Id);
        } else {
            self.SelectedCourse(null);
            self.RegisterCourseButtonName('Bạn chưa chọn khoá học nào đăng ký');
            self.registerCourseModel().CourseId(null);
        }
    };
};

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









