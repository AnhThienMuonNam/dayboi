var MainModel = function (data) {
    //properties
    var self = this;
    self.EditBlogUrl = ko.observable(data.API_URLs.EditBlogUrl);
    self.Blogs = ko.observableArray(data.Blogs || []);
}

