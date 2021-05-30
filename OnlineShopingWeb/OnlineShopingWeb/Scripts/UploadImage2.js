
$('#ImageUpload').click(function () {
    //$('#BrowsePhoto1').trigger('click');
    UploadClickEvent();
});

function UploadClickEvent() {
    $('#UploadImage').trigger('click');
};

$('#UploadImage').change(function () {
    if(this.files && this.files[0])
    {
        var fileReader = new FileReader();
        fileReader.readAsDataURL(this.files[0]);
        fileReader.onload = function (x) {
            $('#UserImage').attr('src', x.target.result);
        }
    }
});

$('#RemoveImage').click(function () {
   
        $('#UserImage').attr('src', "/Images/img-not-found.png");
  
        $('#Photo').val('~/Images/img-not-found.png');
        
});


//$('.user-profile').click(function () {
//    $('#BrowsePhoto1').trigger('click');
//})