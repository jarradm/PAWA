if (pop != window.alert) { var pop = window.alert }// Disableable test alert

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
    $("#resultPopup").dialog({ autoOpen: false, resizable: false, height: 140,  width: 280 });
    $("form").first().submit(function (event) {
        // Handle for submit on where dropdown is Move.
        // If no images are selected, cancel the submit action.
        if ($("#DropDownList").val() == "Move") {
            if (hasChecked()) {
                event.preventDefault();
                pop("before");
                // .POST 
                var albumPost = $.post("../../Home/GetAlbumList", { userID: "1" }, function (data) {
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
    });
});

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
            if (o && (checkedInputID.search('_folder') != -1)) {
                pop("submit btn working\nFolder ID : " + checkedInputID.substring(checkedInputID.search("_folder") + 7, checkedInputID.toString().length));
                returnValue.push([checkedInputID.substring(checkedInputID.search("_folder") + 7, checkedInputID.toString().length)]);
            } else if (!o && (checkedInputID.search('_folder') == -1)) {
                returnValue.push([checkedInputID]);
            }
        }
    }
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
var moveSubmitButton = function () {

    var checkedImageIDs = getCheckedIDArray(false);
    var checkedFolderIDs = getCheckedIDArray(true);
    // Get list of all checked elements
    // Loop through each checkbox, find the checkboxs ID value,
    // determine whether it is an image or folder, add the ID 
    // to the return list.
    pop("Folder : " + $("#folderList").val() + "\nLength : " + checkedImageIDs.length + "\nValues : " + checkedImageIDs.toString() );
    var currentFolder = "" + getCurrentFolderID();
    // .POST
    $.post("../../Home/MoveImageTo",
        /*POSTED Values*/{ destinationFolder: $("#folderList").val(), selected: checkedImageIDs.toString(), sourceFolder: currentFolder }, function (data) {
            // .POST Success function
            pop("works" + data);
            window.location.href = window.location;
        });
    $.post("../../Home/MoveImageTo",
        /*POSTED Values*/{ destinationFolder: $("#folderList").val(), selected: checkedImageIDs.toString(), sourceFolder: currentFolder }, function (data) {
            // .POST Success function
            pop("works" + data);
            window.location.href = window.location;
        });
};

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