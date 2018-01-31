
"use strict";

function renderSchedule(item) {
    addPeriod(item);

    $("#schedule").jqs({
        mode: "read",
        days: [
            "Mon",
            "Thue",
            "Wen",
            "Thur",
            "Friday",
            "Sat",
            "Sun"
        ],
    });

    $("#schedule").jqs();
};

function clearSchedule() {
    $("#schedule").jqs('reset');
}

function addPeriod(item) {
    $("#schedule").jqs('import', [
        {
            "day": item.day,
            "periods": [
                [item.startDate, item.endDate],
            ]
        },
    ]);
}

