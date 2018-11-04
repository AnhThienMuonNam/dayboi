var MainModel = function (data) {
    var self = this;
    self.TempPriceOfOrder = ko.observable(0);
    self.Courses = ko.observableArray(data.Home && data.Home.Courses ? data.Home.Courses : []);

    self.SelectedCourse = ko.observable(self.Courses() ? self.Courses()[0] : null);

    self.RegisterCourseButtonName = ko.observable(self.SelectedCourse() ? 'Đăng ký: ' + self.SelectedCourse().Name : 'Bạn chưa chọn khoá học nào đăng ký');

    self.selectCourse = function (item) {
        if (!self.SelectedCourse() || (item.Id != self.SelectedCourse().Id)) {
            self.SelectedCourse(item);
            self.RegisterCourseButtonName('Đăng ký: ' + item.Name);
        } else {
            self.SelectedCourse(null);
            self.RegisterCourseButtonName('Bạn chưa chọn khoá học nào đăng ký');
        }
    };
}





