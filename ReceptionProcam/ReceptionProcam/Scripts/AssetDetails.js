function returnPass() {


    var assetId = $("#hidSubmitAsset").val();
    $.ajax({
        type: "POST",
        url: "/Areas/Area/AssetManagement/SubmitAsset?id=" + assetId,
        dataType: "text",
        success: function (data) {
            $('#confirmModal').modal('toggle');
            location.reload();
        },
        error: function () {
            alert("Error occured!!")
        }
    });
}