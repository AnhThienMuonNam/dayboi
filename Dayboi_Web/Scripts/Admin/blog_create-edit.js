﻿var MainModel = function (data) {
    //properties
    var self = this;
    self.blogModel = new BlogModel(data);
}

var BlogModel = function (data, parent) {
    //properties
    var self = this;
    self.Id = ko.observable(null);
    self.Title = ko.observable('');
    self.Alias = ko.observable('');
    self.Image = ko.observable(null);
    self.SortDescription = ko.observable('');
    self.MetaKeyword = ko.observable('');
    self.IsActive = ko.observable(true);
    self.Content = ko.observable('');

    self.Title.subscribe(function (value) {
        self.Alias(getAlias(value));
    });
    self.Tags = ko.observableArray([]);

    if (data && data.Blog) {
        ko.mapping.fromJS(data.Blog, {}, self);
    }


    self.changeTag = function () {
        self.Tags($('#blogTag').val());
    };

    self.uploadImage = function () {
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            self.Image(url);
        }
        finder.popup();
    };

    self.create = function () {
        var content = CKEDITOR.instances['editor1'].getData();
        self.Content(escape(content));
        var blog = self.toJSON();
        $.ajax({
            url: data.API_URLs.CreateBlog,
            type: "POST",
            data: { model: blog },
            success: function (response) {
                if (response.IsSuccess == true) {
                    alertify.success('Tạo sản phẩm thành công');
                    setTimeout(function () {
                        window.location.replace(data.API_URLs.EditBlogPage + '/' + response.Data.Id);
                    }, 200);
                }
            },
            error: function (xhr, error) {

            },
        });
    };

    self.update = function () {
        var content = CKEDITOR.instances['editor1'].getData();
        self.Content(escape(content));
        var blog = self.toJSON();
        $.ajax({
            url: data.API_URLs.UpdateBlog,
            type: "POST",
            data: { model: blog },
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
                url: data.API_URLs.DeleteBlog,
                type: "POST",
                data: { id: self.Id() },
                success: function (response) {
                    if (response.IsSuccess == true) {
                        alertify.success('Xoá thành công');
                        window.location.replace(data.API_URLs.BlogIndexUrl);
                    }
                },
                error: function (xhr, error) {
                    var e = 0;
                },
            });
        }
            , function () { alertify.error('Cancel') });

    }

    function Init() {
        CKEDITOR.instances['editor1'].setData(unescape(self.Content()));
        for (var i = 0; i < self.Tags().length; i++) {
            var data = self.Tags()[i];
            var newOption = new Option(data, data, true, true);
            $('#blogTag').append(newOption).trigger('change');
        }
    };

    Init();

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

    BlogModel.prototype.toJSON = function () {
        var model = {
            Id: ko.utils.unwrapObservable(this.Id),
            Title: ko.utils.unwrapObservable(this.Title),
            Alias: ko.utils.unwrapObservable(this.Alias),
            Image: ko.utils.unwrapObservable(this.Image),
            SortDescription: ko.utils.unwrapObservable(this.SortDescription),
            MetaKeyword: ko.utils.unwrapObservable(this.MetaKeyword),
            IsActive: ko.utils.unwrapObservable(this.IsActive),
            Content: ko.utils.unwrapObservable(this.Content),
            Tags: ko.utils.unwrapObservable(this.Tags),
        };

        return model;
    };


}
