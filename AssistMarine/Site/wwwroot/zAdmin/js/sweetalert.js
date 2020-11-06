!(function ($) {
    "use strict";
    $(function () {
        $("#delete").click(function () {
            swal({
                title: "Careful",
                text: "The File Was Deleted Successfully",
                icon: "warning",
                dangerMode: true,
            })
        });
    });

})(jQuery);