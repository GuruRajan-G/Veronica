var executionsTable;
var executablesTable;
var executablesWrapper;
var messagesTable;
var messagesWrapper;

var detailsTable;
var detailType;
var detailId;
var interval;


function GetActivejoblist() {
    var data = App.GetApiData("/GetActiveJob");
    executionsTable.clear();
    if (data) {
        executionsTable.rows.add(data);
        $('#container').css('display', 'block');
        executionsTable.columns.adjust().draw();
        executionsTable.draw();
    }
    detailTable = executionsTable;
    return Dollargrid_wrapper;
}

function UpdateTables() {
    $('.blockUI').block({
        message: '<h1>loading...</h1>',
        fadein: 200,
        fadeout: 400,
        overlayCSS: {
            backgroundColor: '#000',
            opacity: 0.45,
            cursor: 'wait'
        },
    });
    try {
        GetActivejoblist();
            }
    catch (error) {
        App.MsgDialog('type-warning', error);
    }
    window.setTimeout(function () { $('.blockUI').unblock(); }, 100); //without a delay we dont get the block ui mask....no idea why
}

$(document).ready(function () {

    // Executions section
    //    // keep ref here so its not lost
    executablesWrapper = $("#Dollargrid_wrapper");

    executionsTable = $('#Dollargrid').DataTable({

        "pageLength": 5,
        "bSort": true,
        "lengthMenu": [[2, 5, 10, 25, 50, -1], [2, 5, 10, 25, 50, "All"]],
        "order": [[0, "desc"]],
        rowId: 'Session',
        "columns": [
            { "data": "Session" },
            { "data": "Jobname" },
            { "data": "Status" },
            { "data": "Frequency" },
            { "data": "Avgduration" },
            { "data": "Description" },
            { "data": "RunningOn" }
        ]

    });
    UpdateTables();
});




