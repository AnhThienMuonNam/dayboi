var MainModel = function (data) {
    //properties
    var self = this;
    self.categoryModel = new CategoryModel(data);
}

var CategoryModel = function (data, parent) {
    //properties
    var self = this;
    self.Id = ko.observable(null);
    self.Name = ko.observable('');
    self.Alias = ko.observable('');
    self.Description = ko.observable('');
    self.Image = ko.observable('');
    self.MetaKeyword = ko.observable('');
    self.IsActive = ko.observable(true);

    self.Name.subscribe(function (value) {
        self.Alias(getAlias(value));
    });

    if (data && data.Category) {
        ko.mapping.fromJS(data.Category, {}, self);
    }

    self.uploadImage = function () {
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            self.Image(url);
        }
        finder.popup();
    };
    self.create = function () {
        var category = self.toJSON();
        $.ajax({
            url: data.API_URLs.CreateCategory,
            type: "POST",
            data: { model: category },
            success: function (response) {
                var data = response;
            },
            error: function (xhr, error) {
                var e = 0;
            },
        });
    };


    function getAlias(input) {
        if (input == undefined || input == '')
            return '';
        //Đổi chữ hoa thành chữ thường
        var slug = input.toLowerCase();

        //Đổi ký tự có dấu thành không dấu
        slug = slug.replace(/á|à|ả|ạ|ã|ă|ắ|ằ|ẳ|ẵ|ặ|â|ấ|ầ|ẩ|ẫ|ậ/gi, 'a');
        slug = slug.replace(/é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ/gi, 'e');
        slug = slug.replace(/i|í|ì|ỉ|ĩ|ị/gi, 'i');
        slug = slug.replace(/ó|ò|ỏ|õ|ọ|ô|ố|ồ|ổ|ỗ|ộ|ơ|ớ|ờ|ở|ỡ|ợ/gi, 'o');
        slug = slug.replace(/ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự/gi, 'u');
        slug = slug.replace(/ý|ỳ|ỷ|ỹ|ỵ/gi, 'y');
        slug = slug.replace(/đ/gi, 'd');
        //Xóa các ký tự đặt biệt
        slug = slug.replace(/\`|\~|\!|\@|\#|\||\$|\%|\^|\&|\*|\(|\)|\+|\=|\,|\.|\/|\?|\>|\<|\'|\"|\:|\;|_/gi, '');
        //Đổi khoảng trắng thành ký tự gạch ngang
        slug = slug.replace(/ /gi, "-");
        //Đổi nhiều ký tự gạch ngang liên tiếp thành 1 ký tự gạch ngang
        //Phòng trường hợp người nhập vào quá nhiều ký tự trắng
        slug = slug.replace(/\-\-\-\-\-/gi, '-');
        slug = slug.replace(/\-\-\-\-/gi, '-');
        slug = slug.replace(/\-\-\-/gi, '-');
        slug = slug.replace(/\-\-/gi, '-');
        //Xóa các ký tự gạch ngang ở đầu và cuối
        slug = '@' + slug + '@';
        slug = slug.replace(/\@\-|\-\@|\@/gi, '');

        return slug;
    }

    CategoryModel.prototype.toJSON = function () {
        var model = {
            Id: ko.utils.unwrapObservable(this.Id),
            Name: ko.utils.unwrapObservable(this.Name),
            Alias: ko.utils.unwrapObservable(this.Alias),
            Description: ko.utils.unwrapObservable(this.Description),
            Image: ko.utils.unwrapObservable(this.Image),
            MetaKeyword: ko.utils.unwrapObservable(this.MetaKeyword),
            IsActive: ko.utils.unwrapObservable(this.IsActive)
        };

        return model;
    };


}
