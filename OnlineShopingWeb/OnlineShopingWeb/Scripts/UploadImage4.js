
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
  
    //We can use property name as id name
        $('#Product_Image').val('~/Images/img-not-found.png');
    
    //to reset file control when file selected and removed 
        var input = $("#UploadImage");
            input.replaceWith(input.val('').clone(true));

});


//$('.user-profile').click(function () {
//    $('#BrowsePhoto1').trigger('click');
//})