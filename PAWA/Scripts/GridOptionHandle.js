if (pop != window.alert) { var pop = function () { } }// Disableable test alert

/**
  * <summary> 
  *   On the document load, the submit event for the album grid form is edited to handle the function for each required action.
  * </summary>
  *
  * <input>
  *   None
  * </input>
  *
  * TODO :
  *
  */
$(document).ready(function () {
    $("#resultPopup").dialog({ autoOpen: false, resizable: false, height: 140, width: 340 });
    $("#resultPopup").attr("title", "Move selected");
    $("form").first().submit(clickMoveSelected(event));
});

dropdownMoveselected = function (event) {
    if ($("#DropDownList").val() == "Move") {
        clickMoveSelected(event);// Handle for submit on where dropdown is Move.
    }
}

clickMoveSelected = function (event) {
    // If no images are selected, cancel the submit action.
    if (hasChecked()) {
        event.preventDefault();
        pop("before");
        // .POST 
        var albumPost = $.post("../../Home/GetAlbumList", function (data) {
            // .POST Success function
            pop("The chidren are safe");
            $("#resultPopup").empty().append(data);
            $("#resultPopup").dialog("open");
        });
        pop("after");
        $("#resultPopup").dialog("open");
        pop("after post");
    }
}

/**
  * <summary> 
  *   returns an array of checked elements
  *   either for each folder or for each
  *   or for each image.
  * </summary>
  *
  * <input>
  *   o: (options)
  *     If set to ( true, "f", or "folder")
  *     will return the ID list of selected 
  *     folders.
  * </input>
  *
  * TODO :
  *   Make the options a switch case and
  *   have room for the possible inclusion
  *   of more checkbox types (ie: video, 
  *   writing)
  *
  */
var getCheckedIDArray = function (o) {
    var returnValue = [];
    /*Magic*/if (o) { if (o === true || o.toString().charAt(0).toLowerCase() == "f" || o[0].toString().charAt(0).toLowerCase() == "f") { o = true } else { o = false } } else { o = false }
    // Get list of all checked elements
    // Loop through each checkbox, find the checkboxs ID value,
    // determine whether it is an image or folder, add the ID 
    // to the return list.
    var inputs = $("input[type='checkbox']");
    for (var i = 0; i < inputs.length; i++) {
        var checkedInputID = "" + inputs[i].id;
        pop("id : " + checkedInputID + "\nchecked : " + inputs[i].checked + "\nNot Folder : " + (checkedInputID.search('_folder') == -1));
        if (inputs[i].checked) {
            // This should be a switch case statement
            // Here it jumps through each possible state for
            //  the options object and checks to see if the
            //  required condition is true. If true, the
            //  appropriate value is added to the returnArray.
            pop(o.toString() + " :"+ checkedInputID +": " + (checkedInputID.search('folder') != -1) );
            if (o && (checkedInputID.search('folder') != -1)) {
                checkedInputID = checkedInputID.replace("_folder", "");//substring(0,checkedInputID.search("_folder"));
                returnValue.push([checkedInputID]);
                pop("submit btn working\n\nFolder ID : " + checkedInputID);
            } else if (!o && (checkedInputID.search('_folder') == -1)) {
                returnValue.push([checkedInputID]);
            }
        }
    }
    return returnValue;
}

/**
  * <summary>
  *   When the Go button for the Move Selected dialog box is clicked,
  *   send post messages to each controller that is ment for tht request.
  *   Currently, only sends data to the move folder and move image
  *   handles on the home controller.
  * </summary>
  */
var moveSubmitButton = function () {

    var checkedImageIDs = getCheckedIDArray(false);
    var checkedFolderIDs = getCheckedIDArray(true);
    // Get list of all checked elements
    // Loop through each checkbox, find the checkboxs ID value,
    // determine whether it is an image or folder, add the ID 
    // to the return list.
    pop("Folder : " + $("#folderList").val() + "\nLength : " + checkedImageIDs.length + "\nValues : " + checkedImageIDs.toString() );
    var currentFolder = "" + getCurrentFolderID();
    
    var postCompleate = false;
    { "/Home/Album/" }
    // Setting up the return url based on the current url
    var destinationURL = ("" + window.location).substring(0, ("" + window.location).search("/Home/Album"));
    if (currentFolder == "-1") 
    {
        destinationURL += "/Home/Album/?folderID=" + $("#folderList").val(); 
    }
    else 
    {
        if ($("#folderList").val() == "-1") { destinationURL += "/Home/Album/";}
        else { destinationURL += "/Home/Album/?folderID=" + $("#folderList").val(); }
    }



    // .POST >>>
    // >>>>   Post for move _IMAGES
    $.post("../../Home/MoveImageTo",
        /*POSTED Values*/{ destinationFolder: $("#folderList").val(), selected: checkedImageIDs.toString(), sourceFolder: currentFolder }, function (data) {
            // .POST Success function
            pop(">>Image works<<\n\n" + data);

            // Make sure that the page is not refreshed before completion
            if (!(postCompleate = !postCompleate)) {
                pop("Image was moved : " + postCompleate);
                window.location.href = (destinationURL);
            } else {
                pop("Image was moved : " + postCompleate);
            }
        });
    // >>>>   Post for move _FOLDERS
    $.post("../../Home/MoveFolderTo",
        /*POSTED Values*/{ destinationFolder: $("#folderList").val(), selected: checkedFolderIDs.toString(), sourceFolder: currentFolder }, function (data) {
            // .POST Success function
            pop(">>Folder works<<\n\n" + data);

            // Make sure that the page is not refreshed before completion
            if (!(postCompleate = !postCompleate)) { 
                pop("Folder was moved : " + postCompleate);
                window.location.href = (destinationURL);
            } else { 
                pop("Folder was moved : " + postCompleate); 
            }
        });
};

/**
  * <summary> 
  * Grabs the current folder ID through the window.location string(if no folderID exists, returns "-1")
  * </summary>
  *
  * <input>
  * </input>
  *
  * TODO :
  *
  */
var getCurrentFolderID = function () {
    var returnValue = "" + window.location;
    // IF the current folder is not = to Root
    if (returnValue.search("folderID=") != -1) {
        returnValue = returnValue.substring(returnValue.search("folderID=") + 9, returnValue.toString().length);
        pop("Working Result : " + returnValue);
    } else { returnValue = "-1" };
    return returnValue;
}


/**
  * <summary> 
  * </summary>
  *
  * <input>
  * </input>
  *
  * TODO :
  *
  */
function hasChecked() {
    pop("hasChecked");
    //Get List of all checked elements
    //Loop through List to find if any
    //element has been checked.
    var inputs = $("input[type='checkbox']");
    for (var i = 0; i < inputs.length; i++) {
        pop(inputs[i].checked);
        if (inputs[i].checked) {
            return true; // Immiedate true returned if a check is found
        }
    }
    /*If no checked box was found*/ return false;
};