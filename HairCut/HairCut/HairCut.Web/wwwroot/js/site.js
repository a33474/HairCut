$(document).ready(function () {
    $(".add-appointment-container").hide();
})

function showAppointmentContainer(sender) {
    var clientId = $(sender.currentTarget).attr("clientId");
    var showHideContainer = $(".add-appointment-container[clientid='" + clientId + "']")
    showHideContainer.toggle(750);                                                  // 1000 = 1s so we use 750s
    $(".show-appointment-container").click(showAppointmentContainer);
}

function addAppointmentHandler(sender) {
    var clientId = $(sender.target.parentNode.parentNode).attr("clientId");
    var textArea = $(sender.target.parentNode).find(".appointment-text");
    if (textArea.val().trim() === "" || textArea().val() === undefined) {
        alert("Type a appointment.");
    }
    else {
        $.post("/appointment/AddClient", $param({ clientId: clientId, text: textArea.val() }),
            function () {
                $.get("/Client/Index",
                    function (getResult) {
                        $(".rendered-content").html(getResult)
                    }
                );
            }
        );
    }
}