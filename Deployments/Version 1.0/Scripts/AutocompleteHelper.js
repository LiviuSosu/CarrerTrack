$(document).ready(function () {
    $("#CompanyName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '@Url.Action("GetCompanies", "JobAnnouncement")',
                datatype: "json",
                data: {
                    Areas: 'Sales',
                    term: request.term
                },
                success: function (data) {
                    response($.map(data, function (val, item) {
                        return {
                            label: val.CompanyName,
                            value: val.CompanyName,
                            customerId: val.CompanyId
                        }
                    }))
                }
            })
        },
        select: function (event, ui) {
            $("#CompanyId").val(ui.item.CompanyId);
        }
    });
});