var MainModel = function (data) {
    //properties
    var self = this;
    self.EditProductUrl = ko.observable(data.API_URLs.EditProductUrl);
    self.Products = ko.observableArray(data.Products || []);
    self.Categories = ko.observableArray(data.Categories || []);

    self.searchModel = ko.observable(new SearchModel(self, data));
};

var SearchModel = function (parent, data) {
    var self = this;
    self.KeyWord = ko.observable('');
    self.Id = ko.observable(null);
    self.CategoryId = ko.observable(null);
    self.IsActive = ko.observable(true);

    self.search = function () {
        var search = self.toJSON();
        $.ajax({
            url: data.API_URLs.Search,
            type: "POST",
            data: { model: search },
            success: function (response) {
                if (response.IsSuccess === true) {
                    parent.Products(response.Data);
                }
            },
            error: function (xhr, error) {

            },
        });
    };

    SearchModel.prototype.toJSON = function () {
        var model = {
            Id: ko.utils.unwrapObservable(this.Id),
            KeyWord: ko.utils.unwrapObservable(this.KeyWord),
            IsActive: ko.utils.unwrapObservable(this.IsActive),
            CategoryId: ko.utils.unwrapObservable(this.CategoryId)
        };

        return model;
    };
};

