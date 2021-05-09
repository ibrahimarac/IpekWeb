
var STATUS = {
    Ok: 0,
    BadRequest: 1,
    NotFound: 2,
    Error: 3
}

$.ShowConfirm = function (contentMessage,okFunction) {
    $.confirm({
        title: 'Uyarı!',
        content: contentMessage,
        type: 'blue',
        typeAnimated: true,
        closeIcon: true,
        buttons: {
            Ok: {
                text: 'Onaylıyorum',
                btnClass: 'btn-red',
                action: okFunction
            },
            close: function () {
            }
        }
    });
}

$.ShowSuccess = function (contentMessage) {
    $.alert({
        title: 'Başarılı!',
        content: contentMessage,
        type: 'green',
        typeAnimated: true,
        closeIcon: true
    });
}


$.ShowError = function (contentMessage) {
    $.alert({
        title: 'Hata!',
        content: contentMessage,
        type: 'red',
        typeAnimated: true,
        closeIcon: true
    });
}

$.AjaxTableDelete = function (reqUrl, confirmMessage, deleteItemId, successFunc, errorFunc) {
    $.ShowConfirm
    (
        confirmMessage,
        function () {
            $.ajax({
                type: "POST",
                url: reqUrl,
                contentType: "application/json",
                dataType: "json",
                data: JSON.stringify({
                    id: deleteItemId
                }),
                success: successFunc,
                error: errorFunc
            }); 
        }        
    )
        
}
