﻿

var coll2 = document.getElementsByClassName("collapsible-button2");
var i;

for (i = 0; i < coll2.length; i++) {
    coll2[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var content = this.nextElementSibling;
        if (content.style.maxHeight) {
            content.style.maxHeight = null;
        } else {
            content.style.maxHeight = content.scrollHeight + "px";
        }
    });
}

var select = document.getElementById('length-select');
select.addEventListener('change', function () {
    var opt = select.options[select.selectedIndex];
    var id = opt.getAttribute('data-product-id');
    document.getElementById('length-input').value = parseInt(id);
    document.getElementById('length-form').submit();
});

$("#product-counter-down").on('click', function () {
    var productcount = $('#product-counter-input').val();
    productcount = parseInt(productcount);
    if (productcount > 1) {
        productcount -= 1;
        $('#product-counter-input').val(productcount);
    }
});

$("#product-counter-up").on('click', function () {
    var productcount = $('#product-counter-input').val();
    productcount = parseInt(productcount);
    productcount += 1;
    $('#product-counter-input').val(productcount);
});


//$('#length-select').change(function () {

//    var selected = select.options
//    var productId = selectOption.
//});