let auth_token;
$(document).ready(function () {
    $.ajax({
        type: 'get',
        url: 'https://www.universal-tutorial.com/api/getaccesstoken',
        success: function (data) {
            auth_token = data.auth_token
            getCountry(data.auth_token);
        },
        error: function (error) {
            console.log(error);
        },
        headers: {
            "Accept": "application/json",
            "api-token": "yLwKiX58DSjXk68kfdIaP-CKauLdtNuN28UKYcnqhxUBplvnCgB2AaZW8p3zRknPADI",
            "user-email": "bukhosibakhem@gmail.com"
        }

    })

    /*
    var myId = $('#testId').text();
    var myId = $('#testId').val();
    var myId = $(this).closest('.testId').text();
    //var url = $('form').attr('AddorEdit') + '/' + id;
    var url_ = 'AddorEdit/{{ $id }}/AddressBookContacts/getCountry/';
    console.log("idClosest: "+myId);
    console.log("idText: "+myId);
    console.log("idVal: " + myId);
    console.log("url_: " + url_);

    const params = new URLSearchParams(location.search);
    const data = { id: params.get('id') }

    $.getJSON('', data, function (response) {
        // do stuff with response
    })
    $.ajax({
        type: "POST",
        url: ur_,
        data: { id:  myId},
        success: function (data) {
            console.log(data);
        }
    });

    $.ajax({
        type: "GET",
        url: "/AddressBookContacts/getCountry",
        data: "{}",
        success: function (data) {
            console.log("Get data: "+data);
            $("#country option:contains(" + (data) + ")".attr('selected', 'selected'));
        }
    });
    */
    $('#country').change(function () {
        getState();
    })
    $('#state').change(function () {
        getCity();
    })

    function getCountry(auth_token) {
        $.ajax({
            type: 'get',
            url: 'https://www.universal-tutorial.com/api/countries/',
            success: function (data) {
                data.forEach(element => {
                    $('#country').append('<option value="' + element.country_name + '">' + element.country_name + '</option>');
                });

                //getState(auth_token)
            },
            error: function (error) {
                console.log(error);
            },
            headers: {
                "Authorization": "Bearer " + auth_token,
                "Accept": "application/json"
            }

        })
    }
    function getState() {
        let country_name = $('#country').val();
        $.ajax({
            type: 'get',
            url: 'https://www.universal-tutorial.com/api/states/' + country_name,
            success: function (data) {
                $('#state').empty();
                data.forEach(element => {
                    $('#state').append('<option value="' + element.state_name + '">' + element.state_name + '</option>');
                });
                //getCity(auth_token);
            },
            error: function (error) {
                console.log(error);
            },
            headers: {
                "Authorization": "Bearer " + auth_token,
                "Accept": "application/json"
            }

        })
    }
    function getCity() {
        let state_name = $('#state').val();
        $.ajax({
            type: 'get',
            url: 'https://www.universal-tutorial.com/api/cities/' + state_name,
            success: function (data) {
                $('#city').empty();
                data.forEach(element => {
                    $('#city').append('<option value="' + element.city_name + '">' + element.city_name + '</option>');
                });
            },
            error: function (error) {
                console.log(error);
            },
            headers: {
                "Authorization": "Bearer " + auth_token,
                "Accept": "application/json"
            }

        })

    }
})
