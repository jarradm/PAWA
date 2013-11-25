
if (pop != window.alert) { var pop = window.alert }// Disableable test alert

$(document).ready(function () {
    $("#resultPopup").dialog({ autoOpen: false });
    $("form").first().submit(function (event) {
        // Handle for submit on where dropdown is Delete.
        // If no images are selected, cancel the submit action.
        if ($('#DropDownList').val() == "Delete") {
            if (hasChecked() == false) {
                alert("You have not selected any images to delete.");
                event.preventDefault();
                return;
            } else {
                if (window.confirm('These images will be permanently deleted. Do you wish to continue?')) {
                    $('#DropDownList').val() = "Delete";
                    $("form:first").submit();
                } else event.preventDefault();
            }
        }
        // Handle for submit on where dropdown is Move.
        // If no images are selected, cancel the submit action.
        if ($("#DropDownList").val() == "Move") {
            if (hasChecked()) {
                event.preventDefault();
                pop("before");
                var albumPost = $.post("../../Home/GetAlbumList", { userID: "1" }, function (data) {
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
            if (o && (checkedInputID.search('_folder') != -1)) {
                pop("submit btn working");
                returnValue.push([checkedInputID.substring(checkedInputID.search("_folder") + 7, checkedInputID.toString().length)]);
            } else if (!o && (checkedInputID.search('_folder') == -1)) {
                returnValue.push([checkedInputID]);
            }
        }
    }
    return returnValue;
}

var moveSubmitButton = function () {

    var checkedImageIDs = getCheckedIDArray(false);
    // Get list of all checked elements
    // Loop through each checkbox, find the checkboxs ID value,
    // determine whether it is an image or folder, add the ID 
    // to the return list.
    /*var inputs = $("input[type='checkbox']");
    for (var i = 0; i < inputs.length; i++) {
        var checkedInputID = inputs[i].id;
        pop("id : " + checkedInputID + "\nchecked : " + inputs[i].checked + "\nNot Folder : " + (checkedInputID.search('_folder') == -1));
        if (inputs[i].checked && (checkedInputID.search('_folder') == -1)) {
            pop("submit btn working");
            checkedImageIDs.push([checkedInputID]);
        }
    }*/
    pop("Folder : " + $("#folderList").val() + "\nLength : " + checkedImageIDs.length + "\nValues : " + checkedImageIDs.toString() );
    var currentFolder = "" + window.location;
    pop("serch : " + currentFolder.search("folderID"))
    if (currentFolder.search("folderID=") > 0) {
        currentFolder = currentFolder.substring(currentFolder.search("folderID=") + 9, currentFolder.toString().length);
        pop("Working Result : " + currentFolder);
    } else { currentFolder = "-1" };
    $.post("../../Home/MoveImageTo", { destinationFolder: $("#folderList").val(), selected: checkedImageIDs.toString(), sourceFolder: currentFolder }, function (data) { pop("works" + data); });
};


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