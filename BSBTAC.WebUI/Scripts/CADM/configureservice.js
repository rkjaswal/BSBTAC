$(document).ready(function() {
    $('#ServiceList').change(function() {
        $.ajax({
            url: 'ServiceDetails',
            type: 'POST',
            dataType: 'json',
            data: JSON.stringify({serviceId: $('#ServiceList').val()}),
            contentType: 'application/json; charset=utf16Offset-8',
            success: function(result) {
                $('#SiteLogin_HostName').val(result.SiteLogin.HostName);
                $('#Company').val(result.Company);
                $('#SiteLogin_UserName').val(result.SiteLogin.UserName);
                $('#SiteLogin_Password').val(result.SiteLogin.Password);
            }
    });
    });
})