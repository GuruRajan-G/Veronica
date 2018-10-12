var executionsTable;
var executablesTable;
var executablesWrapper;
var messagesTable;
var messagesWrapper;

var detailsTable;
var detailType;
var detailId;
var interval;
var EFconnectionString = "Atlastest";

function UpdateKPI() {
    //alert("Here");
    var data = App.GetApiData("/GetAPPCount", { servername: EFconnectionString })
    if (data) {
        //reset all to 0
        $('.statusCount').html(0);
        $.each(data, function (i, item) {
            $('#' + item.ExecutionStatus).html(item.RowCount);
        });        
        return true;
    }
    else {
        return false;
    }
}


function GeErrortable() {
    var data = App.GetApiData("/GetErrorList", { servername: EFconnectionString });
    if (!executionsTable) {
        IntialiseExecutablesTable();
    }
    executionsTable.clear();
    if (data) {
        executionsTable.rows.add(data);
        $('#container').css('display', 'block');
        executionsTable.columns.adjust().draw();
        executionsTable.draw();
    }
    detailTable = executionsTable;
    return myGrid_wrapper;
}

function FilterProjectList(status) {
    var statusText = status;

     if (status == 'All') {
        status = '';
    }

     if (status.includes("ExternalServices")) {
        status = "External Services";
    }
    if (status.includes("AuthService")) {
        status = "Auth Service";
    }
    if (status.includes("BatchRulesProcessor")) {
        status = "Batch Rules Processor";
    }
    if (status.includes("PDWBatchRulesProcessor")) {
        status = "PDW Batch Rules Processor";
    }
    if (status.includes("PharmacyService")) {
        status = "Pharmacy Service";
    }
    if (status.includes("NTAReprocessorTask")) {
        status = "NTAReprocessor";
    }
    //filter the table
    executionsTable.column(4).search(status, false, true).draw(true);

    // add in status text to table header
    var statusLabel = $("#statusFilter");
    if (statusLabel) {
        statusLabel.remove();
    }

    var html = '<label id="statusFilter">&nbsp &nbsp' + statusText + ' Executions</label>';
    $(html).insertAfter('#executions_length label');
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

        if (UpdateKPI()) {
            GeErrortable();
        }

    }
    catch (error) {
        App.MsgDialog('type-warning', error);
    }
    window.setTimeout(function () { $('.blockUI').unblock(); }, 100); //without a delay we dont get the block ui mask....no idea why
}

$(document).ready(function () {

    $("#OLTPdatabase").change(function () {
                EFconnectionString = $(this).val();
                executablesWrapper= UpdateTables();
    });


        $(".statusPanel").click(function () {
            //unselect any selected panels
            $(".statusPanel").removeClass("selected");
            //set selected style to this panel
            $(this).addClass("selected");
            var status = $(this).attr('data-status');
            FilterProjectList(status);
        });


    // Executions section
    //    // keep ref here so its not lost
    executablesWrapper = $("#myGrid_wrapper");

    executionsTable = $('#myGrid').DataTable({
               
            "pageLength": 5,
            "bSort": true,
            "lengthMenu": [[2, 5, 10, 25, 50, -1], [2, 5, 10, 25, 50, "All"]],
            "order": [[0, "desc"]],
            rowId: 'UniqueIDError',
            "columns": [
                { "data": "UniqueIDError" },
                { "data": "Description" },
                { "data": "SysBeginDateTime" },
                { "data": "MachineName" },              
                { "data": "AppName" },
                { "data": "TransactionID" },
                { "data": "BucketID" }
              ]
           
        });
        UpdateTables();
});




