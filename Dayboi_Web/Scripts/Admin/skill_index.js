var MainModel = function (data) {
    //properties
    var self = this;
    self.EditSkillUrl = ko.observable(data.API_URLs.EditSkillUrl);
    self.Skills = ko.observableArray(data.Skills || []);
}

