

//  --------- CoverLetter in Modal on Home/Index page
$(document).ready(function () {


});

function CoverLetterNode(CoverLetterID, JobID, CoverLetterText) {
    var self = this;
    self.CoverLetterID = CoverLetterID;
    self.JobID = JobID;
    self.CoverLetterText = CoverLetterText;
}



$('.cl-save').bind('click', function (event) {
    var jobID = event.target.parentElement.previousElementSibling.firstElementChild.getAttribute('value');
    var coverLetterText = $(event.target.parentElement.previousElementSibling.lastElementChild).val();

    var sendingCoverLetter = new CoverLetterNode();
    sendingCoverLetter.JobID = jobID;
    sendingCoverLetter.CoverLetterText = coverLetterText;
    
    $.ajax("/api/CoverLettersAPI", {
        data: JSON.stringify(sendingCoverLetter),
        type: "post", contentType: "application/json",
        success: function (result) {
            self.alertMessage("Coverletter given to server.");
        }
    });
});
