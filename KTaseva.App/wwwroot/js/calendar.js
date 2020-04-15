let procedure = document.getElementById("procedureId")
procedure.addEventListener("change", GetProcedure);
let procedureId = procedure.value;

let connection =
    new signalR.HubConnectionBuilder()
        .withUrl("/Appointments/Add")
        .build();
connection.start();

function GetProcedure() {
    procedureId = procedure.value;
    connection.invoke("GetUpdateAppointment", currentData, procedureId);
};

$('#datetimepicker').datetimepicker({
    timepicker: false,
    dayOfWeekStart: 1,
    format: 'd.m.Y'
});
$.datetimepicker.setLocale('bg');
var time = $('#timepicker').datetimepicker({
    datepicker: false,
    format: 'H:i'
});

$("#datetimepicker").change(function () {
    currentData = $("#datetimepicker").val()

    connection.invoke("GetUpdateAppointment", currentData, procedureId);


});

connection.on("Get",
    function (hours) {
        if (hours.length > 0) {
            time.datetimepicker('setOptions', {
                allowTimes: hours
            });
        }
        else {
            time.datetimepicker('setOptions', {
                allowTimes: ["00:00"]
            });
        }
    });


$("#timepicker").click(function () {
    currentData = document.getElementById("datetimepicker").value;
    connection.invoke("GetUpdateAppointment", currentData, procedureId);
    console.log(currentData);
});
