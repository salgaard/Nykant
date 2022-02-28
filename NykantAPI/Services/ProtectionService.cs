﻿using Microsoft.AspNetCore.DataProtection;
using NykantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Services
{
    public class ProtectionService : IProtectionService
    {
        IDataProtector _customerProtector;
        IDataProtector _orderProtector;
        IDataProtector _newsSubProtector;
        IDataProtector _consentProtector;
        IDataProtector _paymentCaptureProtector;
        public ProtectionService(IDataProtectionProvider provider)
        {
            _newsSubProtector = provider.CreateProtector("Nykant.NewsSub.Protect.v1");
            _customerProtector = provider.CreateProtector("Nykant.Customer.Protect.v1");
            _orderProtector = provider.CreateProtector("Nykant.Order.Protect.v1");
            _consentProtector = provider.CreateProtector("Nykant.Consent.Protect.v1");
            _paymentCaptureProtector = provider.CreateProtector("Nykant.PaymentCapture.Protect.v1");
        }

        public Consent ProtectConsent(Consent consent)
        {
            if (consent.Email != null)
            {
                consent.Email = _consentProtector.Protect(consent.Email);
            }
            if (consent.IPAddress != null)
            {
                consent.IPAddress = _consentProtector.Protect(consent.IPAddress);
            }
            if (consent.Name != null)
            {
                consent.Name = _consentProtector.Protect(consent.Name);
            }
            if (consent.UserId != null)
            {
                consent.UserId = _consentProtector.Protect(consent.UserId);
            }

            return consent;
        }

        public Consent UnprotectConsent(Consent consent)
        {
            if (consent.Email != null)
            {
                consent.Email = _consentProtector.Unprotect(consent.Email);
            }
            if (consent.IPAddress != null)
            {
                consent.IPAddress = _consentProtector.Unprotect(consent.IPAddress);
            }
            if (consent.Name != null)
            {
                consent.Name = _consentProtector.Unprotect(consent.Name);
            }
            if (consent.UserId != null)
            {
                consent.UserId = _consentProtector.Unprotect(consent.UserId);
            }

            return consent;
        }

        public PaymentCapture ProtectPaymentCapture(PaymentCapture paymentCapture)
        {
            paymentCapture.PaymentIntent_Id = _newsSubProtector.Protect(paymentCapture.PaymentIntent_Id);

            for(int i = 0; i < paymentCapture.Orders.Count(); i++)
            {
                paymentCapture.Orders[i] = ProtectOrder(paymentCapture.Orders[i]);
            }
            
            return paymentCapture;
        }

        public PaymentCapture UnprotectPaymentCapture(PaymentCapture paymentCapture)
        {
            paymentCapture.PaymentIntent_Id = _newsSubProtector.Unprotect(paymentCapture.PaymentIntent_Id);

            for (int i = 0; i < paymentCapture.Orders.Count(); i++)
            {
                paymentCapture.Orders[i] = UnprotectOrder(paymentCapture.Orders[i]);
            }

            return paymentCapture;
        }


        public NewsSub ProtectNewsSub(NewsSub newsSub)
        {
            newsSub.Email = _newsSubProtector.Protect(newsSub.Email);

            return newsSub;
        }

        public NewsSub UnprotectNewsSub(NewsSub newsSub)
        {
            newsSub.Email = _newsSubProtector.Unprotect(newsSub.Email);

            return newsSub;
        }

        public Customer ProtectCustomer(Customer customer)
        {
            customer.Email = _customerProtector.Protect(customer.Email);
            customer.Phone = _customerProtector.Protect(customer.Phone);

            return customer;
        }



        public Customer UnprotectCustomer(Customer customer)
        {
            customer.Email = _customerProtector.Unprotect(customer.Email);
            customer.Phone = _customerProtector.Unprotect(customer.Phone);

            return customer;
        }

        public Customer UnprotectWholeCustomer(Customer customer)
        {
            customer.Email = _customerProtector.Unprotect(customer.Email);
            customer.Phone = _customerProtector.Unprotect(customer.Phone);

            customer.ShippingAddress.Name = _customerProtector.Unprotect(customer.ShippingAddress.Name);
            customer.ShippingAddress.Address = _customerProtector.Unprotect(customer.ShippingAddress.Address);
            customer.ShippingAddress.City = _customerProtector.Unprotect(customer.ShippingAddress.City);
            customer.ShippingAddress.Country = _customerProtector.Unprotect(customer.ShippingAddress.Country);
            customer.ShippingAddress.Postal = _customerProtector.Unprotect(customer.ShippingAddress.Postal);

            customer.BillingAddress.Address = _customerProtector.Unprotect(customer.BillingAddress.Address);
            customer.BillingAddress.City = _customerProtector.Unprotect(customer.BillingAddress.City);
            customer.BillingAddress.Country = _customerProtector.Unprotect(customer.BillingAddress.Country);
            customer.BillingAddress.Postal = _customerProtector.Unprotect(customer.BillingAddress.Postal);
            customer.BillingAddress.Name = _customerProtector.Unprotect(customer.BillingAddress.Name);

            return customer;
        }

        public Customer ProtectWholeCustomer(Customer customer)
        {
            customer.Email = _customerProtector.Protect(customer.Email);
            customer.Phone = _customerProtector.Protect(customer.Phone);

            customer.ShippingAddress.Name = _customerProtector.Protect(customer.ShippingAddress.Name);
            customer.ShippingAddress.Address = _customerProtector.Protect(customer.ShippingAddress.Address);
            customer.ShippingAddress.City = _customerProtector.Protect(customer.ShippingAddress.City);
            customer.ShippingAddress.Country = _customerProtector.Protect(customer.ShippingAddress.Country);
            customer.ShippingAddress.Postal = _customerProtector.Protect(customer.ShippingAddress.Postal);

            customer.BillingAddress.Address = _customerProtector.Protect(customer.BillingAddress.Address);
            customer.BillingAddress.City = _customerProtector.Protect(customer.BillingAddress.City);
            customer.BillingAddress.Country = _customerProtector.Protect(customer.BillingAddress.Country);
            customer.BillingAddress.Postal = _customerProtector.Protect(customer.BillingAddress.Postal);
            customer.BillingAddress.Name = _customerProtector.Protect(customer.BillingAddress.Name);

            return customer;
        }

        public ShippingAddress ProtectShippingAddress(ShippingAddress shippingAddress)
        {
            shippingAddress.Name = _customerProtector.Protect(shippingAddress.Name);
            shippingAddress.Address = _customerProtector.Protect(shippingAddress.Address);
            shippingAddress.City = _customerProtector.Protect(shippingAddress.City);
            shippingAddress.Country = _customerProtector.Protect(shippingAddress.Country);
            shippingAddress.Postal = _customerProtector.Protect(shippingAddress.Postal);

            return shippingAddress;
        }

        public ShippingAddress UnprotectShippingAddress(ShippingAddress shippingAddress)
        {
            shippingAddress.Name = _customerProtector.Unprotect(shippingAddress.Name);
            shippingAddress.Address = _customerProtector.Unprotect(shippingAddress.Address);
            shippingAddress.City = _customerProtector.Unprotect(shippingAddress.City);
            shippingAddress.Country = _customerProtector.Unprotect(shippingAddress.Country);
            shippingAddress.Postal = _customerProtector.Unprotect(shippingAddress.Postal);

            return shippingAddress;
        }

        public BillingAddress UnprotectInvoiceAddress(BillingAddress invoiceAddress)
        {
            invoiceAddress.Address = _customerProtector.Unprotect(invoiceAddress.Address);
            invoiceAddress.City = _customerProtector.Unprotect(invoiceAddress.City);
            invoiceAddress.Country = _customerProtector.Unprotect(invoiceAddress.Country);
            invoiceAddress.Postal = _customerProtector.Unprotect(invoiceAddress.Postal);
            invoiceAddress.Name = _customerProtector.Unprotect(invoiceAddress.Name);

            return invoiceAddress;
        }

        public BillingAddress ProtectInvoiceAddress(BillingAddress invoiceAddress)
        {
            invoiceAddress.Address = _customerProtector.Protect(invoiceAddress.Address);
            invoiceAddress.City = _customerProtector.Protect(invoiceAddress.City);
            invoiceAddress.Country = _customerProtector.Protect(invoiceAddress.Country);
            invoiceAddress.Postal = _customerProtector.Protect(invoiceAddress.Postal);
            invoiceAddress.Name = _customerProtector.Protect(invoiceAddress.Name);

            return invoiceAddress;
        }

        public Order UnprotectOrder(Order order)
        {
            order.Currency = _orderProtector.Unprotect(order.Currency);
            order.PaymentIntent_Id = _orderProtector.Unprotect(order.PaymentIntent_Id);
            order.TotalPrice = _orderProtector.Unprotect(order.TotalPrice);
            order.Taxes = _orderProtector.Protect(order.Taxes);
            order.TaxLessPrice = _orderProtector.Protect(order.TaxLessPrice);
            return order;
        }

        public Order ProtectOrder(Order order)
        {
            order.Currency = _orderProtector.Protect(order.Currency);
            order.PaymentIntent_Id = _orderProtector.Protect(order.PaymentIntent_Id);
            order.TotalPrice = _orderProtector.Protect(order.TotalPrice);
            order.Taxes = _orderProtector.Unprotect(order.Taxes);
            order.TaxLessPrice = _orderProtector.Unprotect(order.TaxLessPrice);
            return order;
        }
    }

    public interface IProtectionService
    {
        PaymentCapture UnprotectPaymentCapture(PaymentCapture paymentCapture);
        PaymentCapture ProtectPaymentCapture(PaymentCapture paymentCapture);
        public Consent ProtectConsent(Consent consent);
        public Consent UnprotectConsent(Consent consent);
        public NewsSub ProtectNewsSub(NewsSub newsSub);
        public NewsSub UnprotectNewsSub(NewsSub newsSub);
        public Customer ProtectCustomer(Customer customerInf);
        public Customer UnprotectCustomer(Customer customerInf);
        public Customer UnprotectWholeCustomer(Customer customer);
        public Customer ProtectWholeCustomer(Customer customer);

        public ShippingAddress ProtectShippingAddress(ShippingAddress customerInf);
        public ShippingAddress UnprotectShippingAddress(ShippingAddress customerInf);

        public BillingAddress ProtectInvoiceAddress(BillingAddress customerInf);
        public BillingAddress UnprotectInvoiceAddress(BillingAddress customerInf);
        public Order ProtectOrder(Order order);
        public Order UnprotectOrder(Order order);
    }
}
