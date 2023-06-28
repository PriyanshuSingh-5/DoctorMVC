function setEndTime(startTime) {
    var startTimeInput = document.getElementById('startTime');
    var endTimeInput = document.getElementById('endTime');

    // Split the start time into hours and minutes
    var [startHour, startMinute] = startTime.split(':');

    // Parse the hours and minutes as integers
    var hours = parseInt(startHour, 10);
    var minutes = parseInt(startMinute, 10);

    // Calculate the end time by adding 30 minutes to the start time
    var endMinutes = minutes + 30;
    var endHours = hours;
    if (endMinutes >= 60) {
        endMinutes -= 60;
        endHours += 1;
    }

    // Format the end time to a string in the format 'HH:mm'
    var formattedEndTime = ('0' + endHours).slice(-2) + ':' + ('0' + endMinutes).slice(-2);

    // Set the calculated end time as the value of the end time input element
    endTimeInput.value = formattedEndTime;




}


function validateAppointmentDate() {
    var appointmentDateInput = document.getElementById('appointmentDate');
    var selectedDate = new Date(appointmentDateInput.value);

    // Get the current date
    var currentDate = new Date();

    // Remove the time portion from the current date
    currentDate.setHours(0, 0, 0, 0);

    if (selectedDate < currentDate) {
        alert('Please select a future date for the appointment.');
        appointmentDateInput.value = '';
    }
}
