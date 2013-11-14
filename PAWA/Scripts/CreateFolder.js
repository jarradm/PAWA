/// <reference path="../Views/Home/Album.cshtml" />
/// <reference path="../Views/Home/Album.cshtml" />
/// <reference path="../Views/Home/Album.cshtml" />
/// <reference path="../Views/Home/Album.cshtml" />
        $(function () {
            $("#create-folder").dialog({
                autoOpen: false,
                width: 400,
                height: 300,
                show: {
                    effect: "blind",
                    duration: 1000
                },
                hide: {
                    effect: "explode",
                    duration: 1000
                }
            });

            $("#body-content-button-create").click(function () {
                $("#create-folder").dialog("open");


            });
        });

        function onSuccess() {

        

    $("#create-folder").dialog("close");
        }

        create = function () {
            var folder = {
                FolderName: $('#FolderName').val(),
                InFolderID: $('#InfolderID').val(),
            };

            $.ajax({
                url: '../../Folders/CreateFolder', /*may be something else*/
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify(folder),
                statusCode: {
                    201 /*Created*/: function (data) {
                        folders.push(data);
                    }
                }
            })
        }

        $(function () {
            $("#Stupid-folder-create").dialog({
                autoOpen: false,
                width: 400,
                height: 300,
                show: {
                    effect: "blind",
                    duration: 1000
                },
                hide: {
                    effect: "explode",
                    duration: 1000
                }
            });

            $("#CreateFolderNOW").click(function () {
                $("#Stupid-folder-create").dialog("open");


            });
        });

        function folderAlert() {
            alert("You idiot");

            var folder = {
                FolderName: $('#FolderName').val(),
                InFolderID: $('#InfolderID').val(),
            };

            $.ajax({
                type: "POST",
                url: "../../Folders/createFolder",
                //data: folder,
                success: alert("Success! You have made it here"),
                data: JSON.stringify(folder)
                //dataType: html5
                //url: "www.google.com"

                // I hate this so much

            }).done(function () {
                alert("successfully successed this" + folder.FolderName);
            }).fail(function () {
                alert("you broke something, dumbass");
            }).always(function () {
                alert("always see this coz i am sexy");
            });

            $("#Stupid-folder-create").dialog("close"); //closes the popup
        }