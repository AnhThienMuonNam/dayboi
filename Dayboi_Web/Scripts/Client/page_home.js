var MainModel = function (data) {
    var self = this;
    self.registerCourseModel = ko.observable(new RegisterCourseModel(self, data));
    self.TempPriceOfOrder = ko.observable(0);
    self.Courses = ko.observableArray(data.Home && data.Home.Courses ? data.Home.Courses : []);

    self.SelectedCourse = ko.observable(self.Courses() ? self.Courses()[0] : null);
    self.registerCourseModel().CourseId(self.SelectedCourse().Id);

    self.RegisterCourseButtonName = ko.observable(self.SelectedCourse() ? 'Đăng ký: ' + self.SelectedCourse().Name : 'Bạn chưa chọn khoá học nào đăng ký');

    self.selectCourse = function (item) {
        if (!self.SelectedCourse() || (item.Id !== self.SelectedCourse().Id)) {
            self.SelectedCourse(item);
            self.RegisterCourseButtonName('Đăng ký: ' + item.Name);
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
    self.FullName = ko.observable('');
    self.Phone = ko.observable('');
    self.StartDate = ko.observable('');
    self.Note = ko.observable('');
    self.CourseId = ko.observable(null);

    self.register = function () {

        //var startDate = $('#datetimepicker1').data('datetimepicker').date();
        var my = new Date();
        self.StartDate(my);

        var model = self.toJSON();
        $.ajax({
            url: data.API_URLs.RegisterCourse,
            type: "POST",
            data: { model: model },
            success: function (response) {
                if (response.IsSuccess === true) {
                    alert(0);
                }
            },
            error: function (xhr, error) {
            }
        });
    };

    RegisterCourseModel.prototype.toJSON = function () {
        var model = {
            FullName: ko.utils.unwrapObservable(this.FullName),
            Phone: ko.utils.unwrapObservable(this.Phone),
            StartDate: ko.utils.unwrapObservable(this.StartDate),
            Note: ko.utils.unwrapObservable(this.Note),
            CourseId: ko.utils.unwrapObservable(this.CourseId),
        };

        return model;
    };
};









