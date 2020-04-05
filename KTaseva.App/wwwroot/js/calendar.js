var getDateTime = [];
var currentData

var cDate;
var cHour;


let k = document.getElementById("GetBusy").value;
getDateTime = $.parseJSON(k);

$('#datetimepicker').datetimepicker({
    allowTimes: [
        '09:00',
        '11:00',
        '13:00',
        '15:00',
        '17:00'
    ],
    disabledDates: '2020/04/12',
    formatDate: 'Y/m/d'
});
$.datetimepicker.setLocale('bg');

let isCreatedSpan = true;
let currentD;
let arr = [];

var div = document.getElementById("busyId");
var span = document.createElement("span");
var span2 = document.createElement("span");
span.setAttribute("class", "badge badge-warning");
span2.setAttribute("class", "badge badge-danger");


$("#datetimepicker").change(function () {
    currentData = $("#datetimepicker").val();
    let split = currentData.split(' ');
    cDate = split[0];
    cHour = split[1];

    getDateTime.forEach(x => {
        let datesHours = x.split(' ');
        let d = datesHours[0];
        let h = datesHours[1];

        if (d === cDate) {
            if (!arr.hasOwnProperty(d)) {
                arr[d] = new Array();
                arr[d].push(h);
            }
            else if (!arr[d].includes(h)) {
                arr[d].push(h);
            }

        }
    });

    if (currentD !== cDate) {
        currentD = cDate;

        for (const [key, value] of Object.entries(arr)) {
            if (key === cDate) {
                span.textContent = "Заети часове:";
                span2.textContent = value;
                div.appendChild(span);
                div.appendChild(span2);
            }
            else if (!arr.hasOwnProperty(cDate)) {
                span.textContent = '';
                span2.textContent = '';
            }
        }
    }
})