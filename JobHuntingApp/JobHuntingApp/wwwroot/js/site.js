

//  --------- CoverLetter in Modal on Home/Index page
$(document).ready(function () {
    $('.cl-save').click(function (event) {
        var jobID = $(event.target).siblings('.modal-body').children('hidden:first').value;
        console.log(jobID);
    });
});

