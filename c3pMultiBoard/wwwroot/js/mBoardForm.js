
//초기화
$(function () {
    //alert(bEdit);
    if (bEdit) {
        $('#summernote').summernote('code', $('#mBoard_Content').val());
        $('#mBoard_Content').val("");

    }
});


//서브전송
$('#btnSave').click(function () {
    var markup = $('#summernote').summernote('code');
    $('#mBoard_Content').val(markup);
});

//에디터 초기화
$('#summernote').summernote({
    tabsize: 3,
    height: 200,
    lang: 'ko-KR'

});
