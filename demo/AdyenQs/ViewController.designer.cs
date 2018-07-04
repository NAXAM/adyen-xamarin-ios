// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AdyenQs
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField amountField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField countryField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField currencyField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField referenceField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField shopperLocaleField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField shopperReferenceField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (amountField != null) {
                amountField.Dispose ();
                amountField = null;
            }

            if (countryField != null) {
                countryField.Dispose ();
                countryField = null;
            }

            if (currencyField != null) {
                currencyField.Dispose ();
                currencyField = null;
            }

            if (referenceField != null) {
                referenceField.Dispose ();
                referenceField = null;
            }

            if (shopperLocaleField != null) {
                shopperLocaleField.Dispose ();
                shopperLocaleField = null;
            }

            if (shopperReferenceField != null) {
                shopperReferenceField.Dispose ();
                shopperReferenceField = null;
            }
        }
    }
}