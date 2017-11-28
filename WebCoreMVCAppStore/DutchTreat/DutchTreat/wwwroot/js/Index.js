$(document).ready(function () {
    var x = 0;
    var s = "";

    //alert("Hello Me");

    console.log("Debuging...");

    //using jQuery
    //var theForm = document.getElementById("theForm"); - the same as = $("#theForm");
    var theForm = $("#theForm");
    theForm.hidden = true;

    var button = $("#buyButton");
    //button.addEventListener the same as button.on
    button.on("click", function () {
        console.log("Buying Item");
    });

    var productInfo = $(".product-props li");
    productInfo.on("click", function () {
        console.log("You clicked on " + $(this).text());
    });

    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-form");

    $loginToggle.on("click", function () {
        //$popupForm.css("display") == "none";
        //$popupForm.toggle(1000);// in millisecond 
        //$popupForm.slideToggle(1000); 
        $popupForm.fadeToggle(1000);
    });
});

