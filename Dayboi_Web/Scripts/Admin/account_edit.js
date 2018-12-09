var MainModel = function (data) {
    //properties
    var self = this;
    self.Roles = ko.observableArray(data.Roles);

    self.accountModel = new AccountModel(data);

}

var AccountModel = function (data, parent) {
    var self = this;
    self.Id = ko.observable(null);
    self.FullName = ko.observable('');
    self.Email = ko.observable('');
    self.PhoneNumber = ko.observable('');
    self.Address = ko.observable('');
    self.RoleId = ko.observable('');

    self.IsActive = ko.observable(true);

   

    if (data && data.Account) {
        ko.mapping.fromJS(data.Account, {}, self);
    }


    self.update = function () {
        var skill = self.toJSON();
        $.ajax({
            url: data.API_URLs.UpdateAccount,
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



    AccountModel.prototype.toJSON = function () {
        var model = {
            Id: ko.utils.unwrapObservable(this.Id),
            FullName: ko.utils.unwrapObservable(this.FullName),
            Address: ko.utils.unwrapObservable(this.Address),
            RoleId: ko.utils.unwrapObservable(this.RoleId),
            IsActive: ko.utils.unwrapObservable(this.IsActive),
        };
        return model;
    };
}
