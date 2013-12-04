/// <reference path="../Views/Home/Album.cshtml" />
/// <reference path="../Views/Home/Album.cshtml" />
/// <reference path="../Views/Home/Album.cshtml" />
/// <reference path="../Views/Home/Album.cshtml" />
/*        $(function () {
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
*/
/*
        create = function () {
            var folder = {
                FolderName: $('#FolderName').val(),
                InFolderID: $('#InfolderID').val(),
            };

            $.ajax({
                url: '../../Folders/CreateFolder', 
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify(folder),
                statusCode: {
                    201 /*Created*//*: function (data) {
                        folders.push(data);
                    }
                }
            })
        }
*/
                    $(function () {
                        $("#folder-create").dialog({
                            autoOpen: false,
                            width: 400,
                            height: 190,
                            resizable: false,
                        });

                        $("#body-content-button-create").click(function () {
                            $("#folder-create").dialog("open");


                        });
                    });

                    function folderAlert() {

                        if ($('#FolderName').val() == "" || $('#FolderName').val().length <= 1) {
                            alert("Please enter a valid folder name; mininum characters 1");
                        }
                        else {
                            var folder = {
                                FolderName: $('#FolderName').val(),
                                InFolderID: $('#SelectInFolderID').val(),
                            };

                            $.get("../Folders/createFolder?FolderName=" + folder.FolderName
                                + "&InFolderID=" + folder.InFolderID, function () {

                                    if (folder.InFolderID == -1) {
                                        window.location.href = "../Home/Album"
                                    } else {
                                        window.location.href = "../Home/Album?folderID=" + folder.InFolderID
                                    }
                                });

                            //alert("Data sent :" + JSON.stringify(folder).toString())

                            /*$.ajax({
                                type: "POST",
                                url: "../Folders/createFolder",
                                //data: folder,
                                success: alert("hi" + folder.FolderName + ":" + folder.InFolderID),
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
                            */
                            $("#folder-create").dialog("close"); //closes the popup
                            //alert("Success! Folder created");
                        }
                    }

                    function previousFolder() {
                        var address = window.location.toString();
   
                        address = address.substring(address.search("/Home/Album"), address.length);
                        var subaddress = "folderID=";

                        if (address != "/Home/Album") {
                            var searchVal = address.substring(address.search("folderID=")+9, address.length);
                            
                            var prevPage = null;

                            $.get("../Folders/getParentID?folderId=" + searchVal,
                                function (data) {
                                    prevPage = data;
                                    if (!isNaN(data)) {
                                        window.location.href = address.substring(0, address.search("folderID=") + 9) + prevPage;
                                    }
                                });                            
                        }
                        else { ;}
                        
                    }

                    