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