var MainModel = function (data) {
    //properties
    var self = this;
    self.poolCategoryModel = new PoolCategoryModel(data);
}

var PoolCategoryModel = function (data, parent) {
    var self = this;
    self.Id = ko.observable(null);
    self.Name = ko.observable('');
    self.Alias = ko.observable('');
    self.Image = ko.observable(null);
    self.MetaKeyword = ko.observable('');
    self.IsActive = ko.observable(true);

    self.Name.subscribe(function (value) {
        self.Alias(getAlias(value));
    });

    if (data && data.PoolCategory) {
        ko.mapping.fromJS(data.PoolCategory, {}, self);
    }


    self.uploadImage = function () {
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            self.Image(url);
        }
        finder.popup();
    };

    self.create = function () {
        var skill = self.toJSON();
        $.ajax({
            url: data.API_URLs.CreatePoolCategory,
            type: "POST",
            data: { model: skill },
            success: function (response) {
                if (response.IsSuccess == true) {
                    alertify.success('Thêm kỹ năng bơi thành công');
                    setTimeout(function () {
                        window.location.replace(data.API_URLs.EditPoolCategoryPage + '/' + response.Data.Id);
                    }, 200);
                }
            },
            error: function (xhr, error) {

            },
        });
    };

    self.update = function () {
        var skill = self.toJSON();
        $.ajax({
            url: data.API_URLs.UpdatePoolCategory,
            type: "POST",
            data: { model: skill },
            success: function (response) {
                if (response.IsSuccess == true)
                    alertify.success('Cập nhật thành công');
            },
            error: function (xhr, error) {

            },
        });
    };

    self.deleteItem = function () {
        alertify.confirm('Xác nhận', 'Bạn chắc chắn muốn xoá?', function () {
            $.ajax({
                url: data.API_URLs.DeletePoolCategory,
                type: "POST",
                data: { id: self.Id() },
                success: function (response) {
                    if (response.IsSuccess == true) {
                        alertify.success('Xoá thành công');
                        window.location.replace(data.API_URLs.PoolCategoryIndexUrl);
                    }
                },
                error: function (xhr, error) {
                    var e = 0;
                },
            });
        }
            , function () { alertify.error('Cancel') });
    }

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

    PoolCategoryModel.prototype.toJSON = function () {
        var model = {
            Id: ko.utils.unwrapObservable(this.Id),
            Name: ko.utils.unwrapObservable(this.Name),
            Alias: ko.utils.unwrapObservable(this.Alias),
            Image: ko.utils.unwrapObservable(this.Image),
            MetaKeyword: ko.utils.unwrapObservable(this.MetaKeyword),
            IsActive: ko.utils.unwrapObservable(this.IsActive),
        };
        return model;
    };
}
