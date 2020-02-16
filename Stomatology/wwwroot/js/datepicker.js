

function rmySpecificdays(date) {
    return (date.getDay() === 0 || date.getDay() === 6);

}
$("#basicDate").flatpickr({
    altInput: true,
    altFormat: "F j, Y",
    dateFormat: "Y-m-d",
    disable: [rmySpecificdays],
    locale: {
        firstDayOfWeek: 1
    }
});
