var ProductModel = function (data) {
    self.products = ko.observableArray(data.Products || []);
  
    self.optionSortId = ko.observable(1);

    self.Images = ko.observableArray([]);

    self.uploadImage = function () {
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            self.Images.push(url);
        }
        finder.onchange = function (ok) {
            ok;
        }
        finder.popup();
    };

}
