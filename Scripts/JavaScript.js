function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var optObj = {
        oid: $('#oid').val(),
        oName: $('#oName').val(),
        oDoctor: $('#oDoctor').val(),
    };
    $.ajax({
        url: "/Home/Add",
        data: JSON.stringify(optObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModel').model('hide');
            window.location.reload();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}