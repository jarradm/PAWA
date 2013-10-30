GOH = {};
apop = window.alert; // Disableable test alert
try{
    if ( document.getElementById("gridForm") !== null) {
        apop("Success")
        GOH = document.getElementById("gridForm");
    
    } else { delete GOH; }

    checkGOH = function (o) {
        var f = {};
        for(var i=0;i<document.forms.length;i++){Object.defineProperty(f,document.forms[i].name,document.forms.}
        var result=false;
        if (f["gridForm"] == null) {
            result = true;
            window.alert(result);
        } else {
            var alertString = "";
            for (var i in f) {
                alertString += "(name: " + f[i] + " || Length:" + f[i].length + "), ";
            }
            window.alert(alertString);
        }
        return result;

    }
}catch(e){apop("Uncaught error:\n")}