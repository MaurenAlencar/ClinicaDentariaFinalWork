$(document).ready(function () {
    $('#position').attr('disabled', true);
    $('#specialty').attr('disabled', true);
    LoadPositions();
    $('#position').change(function () {
        var positionID = $(this).val();
        if (positionID == 2) {
            LoadSpecialties(positionID);
        }
        else {
            alert("Select Position Doctor for Specialty");
            $('#specialty').empty();
            $('#specialty').attr('disabled', true);
            $('#specialty').append('<option>--Select Specialty--</option');
        }
    });

});

function LoadPositions() {
    $('#position').empty();

    $.ajax({
        url: '/ProfessionalTeams/GetPositions',
        success: function (response) {
            if (response != null && response != undefined && response.length > 0) {
                $('#position').attr('disabled', false);
                $('#position').append('<option>--Select Position--</option');
                $('#specialty').append('<option>--Select Specialty--</option');
                $.each(response, function (i, data) {
                    $('#position').append('<option value=' + data.id + '>' + data.name + '</option');
                });
            }
            else {
                $('#position').attr('disabled', true);
                $('#specialty').attr('disabled', true);
                $('#position').append('<option>--Position not available--</option');
                $('#specialty').append('<option>--Specialty not available--</option');
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}


function LoadSpecialties(positionID) {
    $('#specialty').empty();

    $.ajax({
        url: '/ProfessionalTeams/GetSpecialties?ID=' + positionID,
        success: function (response) {
            if (response != null && response != undefined && response.length > 0) {
                $('#specialty').attr('disabled', false);
                $('#specialty').append('<option>--Select Specialty--</option');
                $.each(response, function (i, data) {
                    $('#specialty').append('<option value=' + data.id + '>' + data.name + '</option');
                });
            }
            else {
               
                $('#specialty').attr('disabled', true);
                $('#specialty').append('<option>--Specialty not available--</option');
            }
        },
        error: function (error) {
            alert(error);
        }
    });
}