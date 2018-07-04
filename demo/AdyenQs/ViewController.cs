using System;

using UIKit;
using Adyen;
using Foundation;
using ObjCRuntime;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace AdyenQs
{
    public partial class ViewController : UITableViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


        void PresentCheckoutViewController()
        {
            var checkoutViewController = new CheckoutViewController(this, appearanceConfiguration: AppearanceConfiguration.Default);
            checkoutViewController.WeakCardScanDelegate = this;
            PresentViewController(checkoutViewController, true, null);
        }

        void PresentSuccessAlertController()
        {
            var alertController = UIAlertController.Create(
                    title: "Payment successful",
                    message: null,
                    preferredStyle: UIAlertControllerStyle.Alert);

            var dismissAction = UIAlertAction.Create("OK", UIAlertActionStyle.Default, null);
            alertController.AddAction(dismissAction);

            PresentViewController(alertController, true, null);
        }

        void PresentFailureAlertController()
        {
            var alertController = UIAlertController.Create(title: "Payment failed", message: null, preferredStyle: UIAlertControllerStyle.Alert);

            var dismissAction = UIAlertAction.Create(title: "OK", style: UIAlertActionStyle.Default, handler: null);
            alertController.AddAction(dismissAction);

            PresentViewController(alertController, true, null);
        }

        public Action<NSUrl> URLCompletion;

        public void DidReceive(NSUrl url)
        {
            URLCompletion?.Invoke(url);
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            if (indexPath.Section == 1)
            {
                PresentCheckoutViewController();
            }
        }
    }

    partial class ViewController : ICheckoutViewControllerDelegateBridgeDelegate
    {
        public void DidFinishWith(CheckoutViewController controller, Payment result, NSError error)
        {
            var isSuccess = false;
            var isCancelled = false;

            if (error != null)
            {
                if (error.Domain.Contains("cancelled"))
                {
                    isCancelled = true;
                }
            }
            else if (result != null)
            {
                isSuccess = result.PaymentStatus == "received"
                                  || result.PaymentStatus == "authorised";
            }

            DismissViewController(true, delegate
            {
                if (isSuccess)
                {
                    PresentSuccessAlertController();
                }
                else if (!isCancelled)
                {
                    PresentFailureAlertController();
                }
            });
        }

        public async void RequiresPaymentDataForToken(CheckoutViewController controller, string token, Action<NSData> completion)
        {
            var value = int.Parse(amountField.Text);

            Dictionary<string, object> paymentDetails = new Dictionary<string, object> {
                {"amount", new Dictionary<string, object> {
                        {"currency", currencyField.Text},
                        {"value", value}
                    }},
                {"channel", "ios"},
                {"reference", referenceField.Text },
                {"token", token},
                {"returnUrl", "nx-adyen://"},
                {"countryCode", countryField.Text},
                {"shopperReference", shopperReferenceField.Text},
                {"shopperLocale", shopperLocaleField.Text},
                {"company", new Dictionary<string, object> {
                        {"name", "Test Company"},
                        {"registrationNumber", "9501412121"},
                        {"taxId", "94-2404110"},
                        {"registryLocation", "California"},
                        {"type", "Computer"},
                        {"homepage", "http://www.google.com"}
                    }
                }
            };

            // Mock line item values
            var lineItem1AmountIncludingTax = value / 2;
            var lineItem1TaxAmount = lineItem1AmountIncludingTax / 4;
            var lineItem1AmountExcludingTax = lineItem1AmountIncludingTax - lineItem1TaxAmount;
            var lineItem2AmountIncludingTax = value - lineItem1AmountIncludingTax;
            var lineItem2TaxAmount = lineItem2AmountIncludingTax / 4;
            var lineItem2AmountExcludingTax = lineItem2AmountIncludingTax - lineItem2TaxAmount;


            if (lineItem1AmountExcludingTax > 0 && lineItem2AmountExcludingTax > 0)
            {
                paymentDetails["lineItems"] = new Dictionary<string, object>[] {
                        new Dictionary<string, object>{
                            {"id", "1"},
                            {"description", "Test Item 1"},
                            {"amountExcludingTax", lineItem1AmountExcludingTax},
                            {"amountIncludingTax", lineItem1AmountIncludingTax},
                            {"taxAmount", (lineItem1TaxAmount / lineItem1AmountExcludingTax) * 100},
                            {"taxPercentage", 1800},
                            {"quantity", 1},
                            {"taxCategory", "High"}
                        },
                        new Dictionary<string, object> {
                            {"id", "2"},
                            {"description", "Test Item 2"},
                            {"amountExcludingTax", lineItem2AmountExcludingTax},
                            {"amountIncludingTax", lineItem2AmountIncludingTax},
                            {"taxAmount", lineItem2TaxAmount},
                            {"taxPercentage", (lineItem2TaxAmount / lineItem2AmountExcludingTax) * 100},
                            { "quantity", 5},
                            { "taxCategory", "Low"}
                        }
                    };
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-demo-server-api-key", Configuration.AppSecretKey);

            var content = new StringContent(JsonConvert.SerializeObject(paymentDetails));

            var result = await client.PostAsync(
                "https://checkoutshopper-test.adyen.com/checkoutshopper/demoserver/setup",
                content
            );

            if (result.IsSuccessStatusCode) {
                var data = NSData.FromStream(await result.Content.ReadAsStreamAsync());
                completion(data);
            }
        }

        public void RequiresReturnURL(CheckoutViewController controller, Action<NSUrl> completion)
        {
            URLCompletion = completion;
        }
    }

    partial class ViewController : ICheckoutViewControllerCardScanDelegate
    {
        public void ScanCardFor(CheckoutViewController checkoutViewController, Action<NSString, NSString, NSString> completion)
        {
            var alertController = UIAlertController.Create(
                title: "Scan Card",
                message: "This is the entry point for integrating your card scanning SDK.",
                preferredStyle: UIAlertControllerStyle.Alert);
            alertController.AddAction(UIAlertAction.Create(title: "OK", style: UIAlertActionStyle.Cancel, handler: delegate
            {
                var number = "5555444433331111";
                var expiryDate = "12/18";
                var cvc = "123";

                completion(new NSString(number), new NSString(expiryDate), new NSString(cvc));
            }));

            checkoutViewController.PresentViewController(alertController, true, null);
        }

        public bool ShouldShowCardScanButtonFor(CheckoutViewController checkoutViewController)
        {
            return true;
        }
    }
}
