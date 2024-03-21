function loadComments(projectId) {
    $ajax({

        url: '/ProjectManagement/ProjectComment/GetComments?projectId=' + projectId,
        method: 'GET',
        success: function (data) {
            var commentHtml = '';
            for (var i = 0; data.length; i++) {
                commentHtml += '<div class="comment"';
                commentHtml += '<p>' + data[i].content + '</p>'
                commentHtml += '<span>Posted on ' + new Date(data[i].datePosted).toLocaledString() + '<span>';
                commentHtml += '</div>'
            }
            $('#commentList').html(commentHtml);


        }

    });

}

$(document).ready(function ()){
    var projectId = $('#projectComments input[name="ProjectId"]').val();

    loadComments(projectId);

    $('#addCommentForm').submit(function (e) {
        e.preventDefault();
        var formData = {
            ProjectId: projectId,
            Content: $('#projectComments textarea[name="Content]').val()
        };

        $ajax({

            url: '/ProjectManagement/ProjectComment/AddComments',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(),

            success: function (response) {
                if (response.success) {
                    $('#projectComments textarea[name="Content]').val(''); //clear message area
                    loadComments(projectId);

                } else {
                    alert(response.message);
                }

            }

            error: function (xhr, status, error) {
                alert("Error " + error);
            }

        });



    });



});