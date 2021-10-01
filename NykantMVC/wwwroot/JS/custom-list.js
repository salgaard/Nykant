﻿var x, i, j, l, ll, selElmnt, a, b, c;
x = document.getElementsByClassName("custom-list");
l = x.length;

var elem = document.getElementById("custom-list-options");
var button = document.getElementById("custom-list-button");
var shippingdelivery_id = document.getElementById("shipping-delivery-id");
var shippingdelivery_name = document.getElementById("shipping-delivery-name");
var shippingdelivery_price = document.getElementById("shipping-delivery-price");
button.disabled = true;

for (i = 0; i < l; i++) {
    selElmnt = x[i].getElementsByTagName("select")[0];
    ll = selElmnt.length;
    for (j = 1; j < ll; j++) {
        c = document.createElement("div");
        c.setAttribute("class", "custom-list-option notselected");
        c.innerHTML = selElmnt.options[j].innerHTML;

        c.addEventListener("click", function (e) {
            var y, i, k, select, h, selectlength, yl;
            select = this.parentNode.parentNode.getElementsByTagName("select")[0];
            selectlength = select.length;
            h = this.parentNode.previousSibling;
            for (i = 1; i < selectlength; i++) {
                if (select.options[i].innerHTML == this.innerHTML) {
                    select.selectedIndex = i;
                    shippingdelivery_name.value = this.textContent;
                    shippingdelivery_id.value = i;
                    button.disabled = false;
                    y = this.parentNode.getElementsByClassName("custom-list-option selected");
                    yl = y.length;
                    for (k = 0; k < yl; k++) {
                        y[k].setAttribute("class", "custom-list-option notselected");
                    }
                    this.setAttribute("class", "custom-list-option selected");

                    if (this.textContent == 'Shop') {
                        fetch('/checkout/GetNearbyShopsJson?Street=' + shippingaddress_address.value + '&ZipCode=' + shippingaddress_postal.value + '&CountryIso=DK&Amount=5'
                        ).then(function (result) {
                            result.json().then(function (json) {
                                return null;
                            })
                        });
                    }
                    break;
                }
            }
            h.click();
        });
        elem.appendChild(c);
    }
}



