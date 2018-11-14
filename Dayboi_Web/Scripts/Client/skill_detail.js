var MainModel = function (data) {
    var self = this;

    self.Skill = ko.observable(data.Skill || null);

    self.Tags = ko.observableArray(data.Skill && data.Skill.Tags ? data.Skill.Tags : []);

    self.OtherSkills = ko.observableArray(data.Skill && data.Skill.OtherSkills ? data.Skill.OtherSkills : []);

    self.showContent = function (text) {
        if (text) {
            return unescape(text);
        }
        return '';
    }
}

