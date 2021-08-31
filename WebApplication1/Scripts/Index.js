

angular.module('LinkedInNetworkApp', [angularDragula(angular)])
    .controller('kanbanController', ['$scope', 'dragulaService', function ($scope, dragulaService) {
        dragulaService.options($scope, 'records-bag', {
            copy: false,
            invalid: function (el, handle) {
                return el.classList.contains('no-drag');
            }
        });

        $scope.$on('records-bag.drop', function (e, el) {
            el[0].getElementsByClassName("card-header")[0].classList.remove('bg-info');
            el.removeClass('bg-info');
            el[0].getElementsByClassName("card-header")[0].classList.remove('bg-primary');
            el.removeClass('bg-primary');
            el[0].getElementsByClassName("card-header")[0].classList.remove('bg-dark');
            el.removeClass('bg-dark');
            el[0].getElementsByClassName("card-header")[0].classList.remove('bg-success');
            el.removeClass('bg-success');
            el[0].getElementsByClassName("card-header")[0].classList.remove('bg-secondary');
            el.removeClass('bg-secondary');
            el.removeClass('text-white');
            el.removeClass('bg-dark');
            if (el[0].parentElement.id == "Prospect") {
                el[0].getElementsByClassName("card-header")[0].classList.add('bg-info');
                el.addClass('bg-info');
            } else if (el[0].parentElement.id == "Outreach") {
                el[0].getElementsByClassName("card-header")[0].classList.add('bg-primary');
                el.addClass('bg-primary');
            } else if (el[0].parentElement.id == "Waiting") {
                el[0].getElementsByClassName("card-header")[0].classList.add('bg-dark');
                el.addClass('bg-dark');
            } else if (el[0].parentElement.id == "Respond") {
                el[0].getElementsByClassName("card-header")[0].classList.add('bg-success');
                el.addClass('bg-success');
            } else if (el[0].parentElement.id == "Cold") {
                el[0].getElementsByClassName("card-header")[0].classList.add('bg-secondary');
                el.addClass('bg-secondary');
            }
        });

        $scope.meow = function () {
            console.log("hey");
            console.log("you");
        }

        $scope.editRecord = {};

        $scope.edit = function (record) {
            $scope.editRecord = record; 
        }

        $scope.infoRecord = {};

        $scope.info = function (record) {
            $scope.infoRecord = record;
        }

        $scope.records = [
            {
                "id": 1,
                "name": "Kelly Spisak",
                "company": "Twitch",
                "stage": "Prospect",
                "platform": "LinkedIn",
                "platformURL": "http://linkedin.com",
                "email": "hello@twitch.com",
                "firstContacted": "07/02/2021",
                "lastContacted": "08/01/2021",
                "priority": 1 ,
                "action": "",
                "notes": "comments here"
            },
            {
                "id": 2,
                "name": "Jon Snow",
                "company": "Facebook",
                "stage": "Outreach",
                "platform": "Handshake",
                "platformURL": "http://linkedin.com",
                "email": "hello@twitch.com",
                "firstContacted": "07/02/2021",
                "lastContacted": "08/01/2021",
                "priority": 3,
                "action": "",
                "notes": "comments here"
            },
            {
                "id": 3,
                "name": "Nick Voltema",
                "company": "Google",
                "stage": "Waiting",
                "platform": "LinkedIn",
                "platformURL": "http://linkedin.com",
                "email": "hello@twitch.com",
                "firstContacted": "07/02/2021",
                "lastContacted": "08/01/2021",
                "priority": 4,
                "action": "",
                "notes": "comments here"
            },
            {
                "id": 4,
                "name": "Mary Sue",
                "company": "Snapchat",
                "stage": "Respond",
                "platform": "LinkedIn",
                "platformURL": "http://linkedin.com",
                "email": "hello@twitch.com",
                "firstContacted": "07/02/2021",
                "lastContacted": "08/01/2021",
                "priority": 5,
                "action": "",
                "notes": "comments here"
            },
            {
                "id": 5,
                "name": "Vikram Ganesh",
                "company": "IBM",
                "stage": "Cold",
                "platform": "LinkedIn",
                "platformURL": "http://linkedin.com",
                "email": "hello@twitch.com",
                "firstContacted": "07/02/2021",
                "lastContacted": "08/01/2021",
                "priority": 2,
                "action": "",
                "notes": "comments here"
            }
        ]
    }]);

$(document).ready(function () {
    $('#myModal').on('shown.bs.modal', function () {
        $('#myInput').focus()
    })

    $('#newSaveButton').click(function () {
        name = $('#newContactForm').find('#name').val();
        company = $('#newContactForm').find('#company').val();
        stage = $('#newContactForm').find('#stage').val();
        platform = $('#newContactForm').find('#platform').val();
        platformURL = $('#newContactForm').find('#platformURL').val();
        email = $('#newContactForm').find('#email').val();
        lastContacted = $('#newContactForm').find('#lastContacted').val();
        firstContacted = $('#newContactForm').find('#firstContacted').val();
        priority = $('#newContactForm').find('#priority').val();
        iduser = $('#newContactForm').find('#iduser').val();
        createRecord(name, company, stage, platform, platformURL, email, lastContacted, firstContacted, priority, iduser);
    });

});

function createRecord(name) {
    $.ajax({
        url: '/test/CreateRecord',
        type: 'POST',
        dataType: 'json',
        cache: false,
        data: {
            name: name,
            company: company,
            stage: stage,
            platform: platform,
            platformURL: platformURL,
            email: email,
            lastContacted: lastContacted,
            firstContacted: firstContacted,
            priority: priority,
            iduser: iduser
        },
        success: function () {
            $('#newModal').modal('hide');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus);
            alert("Error: " + errorThrown);
        }
    });
}


//$(document).ready(function () {
//    $(".colSortable").sortable({
//        connectWith: ".colSortable",
//        receive: function (event, ui) {
//            //alert(ui.item.text())
//            ui.item.removeClass("bg-success");
//            ui.item.addClass("bg-primary");
//            ui.item.next().removeClass("bg-success");
//        }
//    });
//    $(".sortable").disableSelection();




//    console.log("hello, world");
//});