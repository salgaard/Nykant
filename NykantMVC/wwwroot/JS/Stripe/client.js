﻿// Set your publishable key: remember to change this to your live publishable key in production
// See your keys here: https://dashboard.stripe.com/account/apikeys
var stripe = Stripe('pk_test_51Hyy3eKS99T7pxPWSbrIYqKDcyKomhVp3hrXymvg8cPkupAmEcbeEoV26ckeJF9GZnfKdvTeQwyKdnwO6uNrIaih001cWPBSI2');

var email = document.getElementById("customer-email").value;
var firstname = document.getElementById("customer-firstname").value;
var lastname = document.getElementById("customer-lastname").value;
var address = document.getElementById("customer-address").value;
var city = document.getElementById("customer-city").value;
var country = document.getElementById("customer-country").value;
var postal = document.getElementById("customer-postal").value;
var phone = document.getElementById("customer-phone").value;
var pricesum = parseInt(document.getElementById("pricesum").value);
var shippingName = document.getElementById("shipping-name").value;
var shippingPrice = document.getElementById("shipping-price").value;

var Items = {
    Customer: {
        Email: email,
        Name: firstname,
        Address: address,
        City: city,
        Country: country,
        Postal: postal,
        Phone: phone
    },
    Price: {
        Amount: pricesum
    },
    Shipping: {
        Name: shippingName
    }
};

document.querySelector(".button").disabled = true;

fetch("/payment/createpaymentintent", {
    method: "POST",
    headers: {
        "Content-Type": "application/json"
    },
    body: JSON.stringify(Items)
})
    .then(function (response) {
        if (response.status !== 200) {
            console.Log('fetch returned not ok' + response.status)
        }
        if (response.status === 200) {
            return response.json();
        }
    })
    .then(function (data) {
        var elements = stripe.elements();

        var style = {
            base: {
                color: "#32325d",
                fontFamily: 'Arial, sans-serif',
                fontSmoothing: "antialiased",
                fontSize: "16px",
                "::placeholder": {
                    color: "#32325d"
                }
            },
            invalid: {
                fontFamily: 'Arial, sans-serif',
                color: "#fa755a",
                iconColor: "#fa755a"
            }
        };

        var cardNumber = elements.create("cardNumber", { style: style });
        var cardExpiry = elements.create("cardExpiry", { style: style });
        var cardCvc = elements.create("cardCvc", { style: style });

        // Stripe injects an iframe into the DOM
        cardNumber.mount("#card-element-number");
        cardExpiry.mount("#card-element-expiry");
        cardCvc.mount("#card-element-cvc");
        cardNumber.on("change", function (event) {
            // Disable the Pay button if there are no card details in the Element
            document.querySelector(".button").disabled = event.empty;
            document.querySelector("#card-error").textContent = event.error ? event.error.message : "";
        });
        var form = document.getElementById("payment-form");
        form.addEventListener("submit", function (event) {
            event.preventDefault();
            // Complete payment when the submit button is clicked
            payWithCard(stripe, cardNumber, data.clientSecret);
        });
    });


// Calls stripe.confirmCardPayment
// If the card requires authentication Stripe shows a pop-up modal to
// prompt the user to enter authentication details without leaving your page.
var payWithCard = function (stripe, card, clientSecret) {
    loading(true);
    stripe
        .confirmCardPayment(clientSecret, {
            receipt_email: document.getElementById("email").value,
            payment_method: {
                card: card,
                billing_details: {
                    name: firstname,
                    address: {
                        line1: address,
                        city: city,
                        country: "DK",
                        postal_code: postal
                    },
                    email: email,
                    phone: phone,
                }
            }
        })
        .then(function (result) {
            if (result.error) {
                // Show error to your customer
                showError(result.error.message);
            } else {
                // The payment succeeded!
                orderComplete(result.paymentIntent.id);
            }
        });
};
/* ------- UI helpers ------- */
// Shows a success message when the payment is complete
var orderComplete = function (paymentIntentId) {
    loading(false);
    document
        .querySelector(".result-message a")
        .setAttribute(
            "href",
            "https://dashboard.stripe.com/test/payments/" + paymentIntentId
        );
    document.querySelector(".result-message").classList.remove("hidden");
    document.querySelector("button").disabled = true;
};
// Show the customer the error from Stripe if their card fails to charge
var showError = function (errorMsgText) {
    loading(false);
    var errorMsg = document.querySelector("#card-error");
    errorMsg.textContent = errorMsgText;
    setTimeout(function () {
        errorMsg.textContent = "";
    }, 4000);
};
// Show a spinner on payment submission
var loading = function (isLoading) {
    if (isLoading) {
        // Disable the button and show a spinner
        document.querySelector("button").disabled = true;
        document.querySelector("#spinner").classList.remove("hidden");
        document.querySelector("#button-text").classList.add("hidden");
    } else {
        document.querySelector("button").disabled = false;
        document.querySelector("#spinner").classList.add("hidden");
        document.querySelector("#button-text").classList.remove("hidden");
    }
};




// Set up Stripe.js and Elements to use in checkout form
//var elements = stripe.elements();

//var style = {
//    base: {
//        color: "",
//    }
//};

//var cardElement = elements.create("card", { style: style });
//cardElement.mount("#card-element");

//cardElement.on("change", function (event) {
//    var displayError = document.getElementById("card-errors");
//    if (event.error) {
//        displayError.textContent = event.error.message;
//    } else {
//        displayError.textContent = '';
//    }
//});

//var secret = document.getElementById("clientSecret").value;
//var form = document.getElementById("payment-form");
//var email = document.getElementById("email-input").value;

//form.addEventListener("submit", function (ev) {
//    stripe.confirmCardPayment(secret, {
//        payment_method: {
//            card: cardElement,
//            billing_details: {
//                name: "Jenny Rosen"
//            }
//        }
//    }).then(function (result) {
//        if (result.error) {
//            // Show error to your customer (e.g., insufficient funds)
//            alert("payment failed")
            
//        } else {
//            // The payment has been processed!
//            if (result.paymentIntent.status === "succeeded") {
//                // Show a success message to your customer
//                alert("payment succeeded")
//                var url = "https://localhost:5002/checkout/paymentsuccess/" + email;
//                window.location.replace(url)
//                // There's a risk of the customer closing the window before callback
//                // execution. Set up a webhook or plugin to listen for the
//                // payment_intent.succeeded event that handles any business critical
//                // post-payment actions.
//            }
//        }
//    });
//});