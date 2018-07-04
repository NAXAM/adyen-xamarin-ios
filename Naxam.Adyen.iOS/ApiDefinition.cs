using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using SafariServices;
using UIKit;

namespace Adyen
{
    // @protocol OneClickInfo
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "_TtP5Adyen12OneClickInfo_")]
    interface OneClickInfo
    {
    }

    // @interface CardOneClickInfo : NSObject <OneClickInfo>
    [BaseType(typeof(NSObject), Name = "_TtC5Adyen16CardOneClickInfo")]
    [DisableDefaultCtor]
    interface CardOneClickInfo : OneClickInfo
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull number;
        [Export("number")]
        string Number { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull holderName;
        [Export("holderName")]
        string HolderName { get; }

        // @property (readonly, nonatomic) NSInteger expiryMonth;
        [Export("expiryMonth")]
        nint ExpiryMonth { get; }

        // @property (readonly, nonatomic) NSInteger expiryYear;
        [Export("expiryYear")]
        nint ExpiryYear { get; }

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        CardOneClickInfo New();
    }

    partial interface ICheckoutViewControllerDelegateBridgeDelegate {}

    // @interface CheckoutViewController : UIViewController <SFSafariViewControllerDelegate>
    [BaseType(typeof(UIViewController), Name = "_TtC5Adyen22CheckoutViewController")]
    interface CheckoutViewController : ISFSafariViewControllerDelegate
    {
        // -(instancetype _Nonnull)initWithDelegate:(id<CheckoutViewControllerDelegateBridgeDelegate> _Nonnull)delegate appearanceConfiguration:(AppearanceConfiguration * _Nonnull)appearanceConfiguration __attribute__((objc_designated_initializer));
        [Export("initWithDelegate:appearanceConfiguration:")]
        [DesignatedInitializer]
        IntPtr Constructor(ICheckoutViewControllerDelegateBridgeDelegate @delegate, AppearanceConfiguration appearanceConfiguration);

		[Wrap ("WeakCardScanDelegate")]
		[NullAllowed]
		CheckoutViewControllerCardScanDelegate CardScanDelegate { get; set; }

		// @property (nonatomic, weak) id<CheckoutViewControllerCardScanDelegate> _Nullable cardScanDelegate;
		[NullAllowed, Export ("cardScanDelegate", ArgumentSemantic.Weak)]
		NSObject WeakCardScanDelegate { get; set; }

        // -(void)viewDidLoad;
        [Export("viewDidLoad")]
        void ViewDidLoad();

        // -(void)viewWillAppear:(BOOL)animated;
        [Export("viewWillAppear:")]
        void ViewWillAppear(bool animated);

        // -(void)viewWillLayoutSubviews;
        [Export("viewWillLayoutSubviews")]
        void ViewWillLayoutSubviews();

        // @property (readonly, nonatomic, strong) UINavigationItem * _Nonnull navigationItem;
        [Export("navigationItem", ArgumentSemantic.Strong)]
        UINavigationItem NavigationItem { get; }

        // @property (readonly, nonatomic) UIStatusBarStyle preferredStatusBarStyle;
        [Export("preferredStatusBarStyle")]
        UIStatusBarStyle PreferredStatusBarStyle { get; }

        // @property (readonly, nonatomic) BOOL shouldAutorotate;
        [Export("shouldAutorotate")]
        bool ShouldAutorotate { get; }

        // @property (readonly, nonatomic) UIInterfaceOrientationMask supportedInterfaceOrientations;
        [Export("supportedInterfaceOrientations")]
        UIInterfaceOrientationMask SupportedInterfaceOrientations { get; }

        // -(void)safariViewControllerDidFinish:(SFSafariViewController * _Nonnull)controller;
        [Export("safariViewControllerDidFinish:")]
        void SafariViewControllerDidFinish(SFSafariViewController controller);
    }

	// @protocol CheckoutViewControllerCardScanDelegate
	[Protocol, Model]
    [BaseType(typeof(NSObject), Name = "_TtP5Adyen38CheckoutViewControllerCardScanDelegate_")]
	interface CheckoutViewControllerCardScanDelegate
	{
		// @required -(BOOL)shouldShowCardScanButtonFor:(CheckoutViewController * _Nonnull)checkoutViewController __attribute__((warn_unused_result));
		[Abstract]
		[Export ("shouldShowCardScanButtonFor:")]
		bool ShouldShowCardScanButtonFor (CheckoutViewController checkoutViewController);

		// @required -(void)scanCardFor:(CheckoutViewController * _Nonnull)checkoutViewController completion:(void (^ _Nonnull)(NSString * _Nullable, NSString * _Nullable, NSString * _Nullable))completion;
		[Abstract]
		[Export ("scanCardFor:completion:")]
		void ScanCardFor (CheckoutViewController checkoutViewController, Action<NSString, NSString, NSString> completion);
	}

    // @protocol CheckoutViewControllerDelegateBridgeDelegate
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "_TtP5Adyen44CheckoutViewControllerDelegateBridgeDelegate_")]
    interface CheckoutViewControllerDelegateBridgeDelegate
    {
        // @required -(void)checkoutViewController:(CheckoutViewController * _Nonnull)controller requiresPaymentDataForToken:(NSString * _Nonnull)token completion:(void (^ _Nonnull)(NSData * _Nonnull))completion;
        [Abstract]
        [Export("checkoutViewController:requiresPaymentDataForToken:completion:")]
        void RequiresPaymentDataForToken(CheckoutViewController controller, string token, Action<NSData> completion);

        // @required -(void)checkoutViewController:(CheckoutViewController * _Nonnull)controller requiresReturnURL:(void (^ _Nonnull)(NSUrl * _Nonnull))completion;
        [Abstract]
        [Export("checkoutViewController:requiresReturnURL:")]
        void RequiresReturnURL(CheckoutViewController controller, Action<NSUrl> completion);

        // @required -(void)checkoutViewController:(CheckoutViewController * _Nonnull)controller didFinishWith:(Payment * _Nullable)result error:(NSError * _Nullable)error;
        [Abstract]
        [Export("checkoutViewController:didFinishWith:error:")]
        void DidFinishWith(CheckoutViewController controller, [NullAllowed] Payment result, [NullAllowed] NSError error);
    }

    // @interface IBANTextField : UITextField
    [BaseType(typeof(UITextField), Name = "_TtC5Adyen13IBANTextField")]
    interface IBANTextField
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface InputDetail : NSObject
    [BaseType(typeof(NSObject), Name ="_TtC5Adyen11InputDetail")]
    [DisableDefaultCtor]
    interface InputDetail
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull inputType;
        [Export("inputType")]
        string InputType { get; }

        // @property (readonly, nonatomic) BOOL optional;
        [Export("optional")]
        bool Optional { get; }

        // @property (readonly, copy, nonatomic) NSArray<InputSelectItem *> * _Nullable items;
        [NullAllowed, Export("items", ArgumentSemantic.Copy)]
        InputSelectItem[] Items { get; }

        // @property (readonly, copy, nonatomic) NSArray<InputDetail *> * _Nullable inputDetails;
        [NullAllowed, Export("inputDetails", ArgumentSemantic.Copy)]
        InputDetail[] InputDetails { get; }

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        InputDetail New();
    }

    // @interface InputSelectItem : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC5Adyen15InputSelectItem")]
    [DisableDefaultCtor]
    interface InputSelectItem
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
        [Export("identifier")]
        string Identifier { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, copy, nonatomic) NSUrl * _Nullable imageURL;
        [NullAllowed, Export("imageURL", ArgumentSemantic.Copy)]
        NSUrl ImageURL { get; }

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        InputSelectItem New();
    }

    // @interface PayPalOneClickInfo : NSObject <OneClickInfo>
    [BaseType(typeof(NSObject), Name = "_TtC5Adyen18PayPalOneClickInfo")]
    [DisableDefaultCtor]
    interface PayPalOneClickInfo : OneClickInfo
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull emailAddress;
        [Export("emailAddress")]
        string EmailAddress { get; }

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        PayPalOneClickInfo New();
    }

    // @interface Payment : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC5Adyen7Payment")]
    [DisableDefaultCtor]
    interface Payment
    {
        // @property (readonly, nonatomic, strong) PaymentMethod * _Nonnull method;
        [Export("method", ArgumentSemantic.Strong)]
        PaymentMethod Method { get; }

        // @property (readonly, nonatomic, strong) PaymentMethod * _Nonnull method;
        [Export("paymentStatus", ArgumentSemantic.Strong)]
        string PaymentStatus { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull payload;
        [Export("payload")]
        string Payload { get; }

        // @property (readonly, nonatomic) NSInteger amount;
        [Export("amount")]
        nint Amount { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull currencyCode;
        [Export("currencyCode")]
        string CurrencyCode { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull merchantReference;
        [Export("merchantReference")]
        string MerchantReference { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable shopperReference;
        [NullAllowed, Export("shopperReference")]
        string ShopperReference { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull shopperCountryCode;
        [Export("shopperCountryCode")]
        string ShopperCountryCode { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable shopperLocaleIdentifier;
        [NullAllowed, Export("shopperLocaleIdentifier")]
        string ShopperLocaleIdentifier { get; }

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        Payment New();
    }

    // @interface PaymentDetails : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC5Adyen14PaymentDetails")]
    [DisableDefaultCtor]
    interface PaymentDetails
    {
        // @property (copy, nonatomic) NSArray<InputDetail *> * _Nonnull list;
        [Export("list", ArgumentSemantic.Copy)]
        InputDetail[] List { get; set; }

        // -(void)setDetailWithValue:(NSString * _Nonnull)value forKey:(NSString * _Nonnull)key;
        [Export("setDetailWithValue:forKey:")]
        void SetDetailWithValue(string value, string key);

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        PaymentDetails New();
    }

    // @interface Adyen_Swift_392 (PaymentDetails)
    [Category]
    [BaseType(typeof(PaymentDetails))]
    interface PaymentDetails_Adyen_Swift_392
    {
        // -(void)fillApplePayWithToken:(NSString * _Nonnull)token;
        [Export("fillApplePayWithToken:")]
        void FillApplePayWithToken(string token);
    }

    // @interface Adyen_Swift_398 (PaymentDetails)
    [Category]
    [BaseType(typeof(PaymentDetails))]
    interface PaymentDetails_Adyen_Swift_398
    {
        // -(void)fillIdealWithIssuerIdentifier:(NSString * _Nonnull)issuerIdentifier;
        [Export("fillIdealWithIssuerIdentifier:")]
        void FillIdealWithIssuerIdentifier(string issuerIdentifier);
    }

    // @interface Adyen_Swift_404 (PaymentDetails)
    [Category]
    [BaseType(typeof(PaymentDetails))]
    interface PaymentDetails_Adyen_Swift_404
    {
        // -(void)fillSepaWithName:(NSString * _Nonnull)name iban:(NSString * _Nonnull)iban;
        [Export("fillSepaWithName:iban:")]
        void FillSepaWithName(string name, string iban);
    }

    // @interface Adyen_Swift_410 (PaymentDetails)
    [Category]
    [BaseType(typeof(PaymentDetails))]
    interface PaymentDetails_Adyen_Swift_410
    {
        // -(void)fillCardWithCvc:(NSString * _Nonnull)cvc;
        [Export("fillCardWithCvc:")]
        void FillCardWithCvc(string cvc);

        // -(void)fillCardWithInstallmentPlanIdentifier:(NSString * _Nonnull)installmentPlanIdentifier;
        [Export("fillCardWithInstallmentPlanIdentifier:")]
        void FillCardWithInstallmentPlanIdentifier(string installmentPlanIdentifier);
    }

    partial interface IOneClickInfo {}

    // @interface PaymentMethod : NSObject
    [BaseType(typeof(NSObject), Name ="_TtC5Adyen13PaymentMethod")]
    [DisableDefaultCtor]
    interface PaymentMethod
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull type;
        [Export("type")]
        string Type { get; }

        // @property (readonly, copy, nonatomic) NSUrl * _Nullable logoURL;
        [NullAllowed, Export("logoURL", ArgumentSemantic.Copy)]
        NSUrl LogoURL { get; }

        // @property (readonly, copy, nonatomic) NSArray<PaymentMethod *> * _Nullable members;
        [NullAllowed, Export("members", ArgumentSemantic.Copy)]
        PaymentMethod[] Members { get; }

        // @property (readonly, nonatomic) BOOL isOneClick;
        [Export("isOneClick")]
        bool IsOneClick { get; }

        // @property (readonly, nonatomic, strong) id<OneClickInfo> _Nullable oneClickInfo;
        [NullAllowed, Export("oneClickInfo", ArgumentSemantic.Strong)]
        IOneClickInfo OneClickInfo { get; }

        // @property (readonly, copy, nonatomic) NSArray<InputDetail *> * _Nullable inputDetails;
        [NullAllowed, Export("inputDetails", ArgumentSemantic.Copy)]
        InputDetail[] InputDetails { get; }

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        PaymentMethod New();
    }

    partial interface IPaymentRequestDelegateBridgeDelegate {}

    // @interface PaymentRequest : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC5Adyen14PaymentRequest")]
    [DisableDefaultCtor]
    interface PaymentRequest
    {
        // -(instancetype _Nonnull)initWithDelegate:(id<PaymentRequestDelegateBridgeDelegate> _Nonnull)delegate __attribute__((objc_designated_initializer));
        [Export("initWithDelegate:")]
        [DesignatedInitializer]
        IntPtr Constructor(IPaymentRequestDelegateBridgeDelegate @delegate);

        // -(void)start;
        [Export("start")]
        void Start();

        // -(void)deletePreferredWithPaymentMethod:(PaymentMethod * _Nonnull)paymentMethod completion:(void (^ _Nonnull)(BOOL, NSError * _Nullable))completion;
        [Export("deletePreferredWithPaymentMethod:completion:")]
        void DeletePreferredWithPaymentMethod(PaymentMethod paymentMethod, Action<bool, NSError> completion);

        // -(void)cancel;
        [Export("cancel")]
        void Cancel();

        // +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
        [Static]
        [Export("new")]
        PaymentRequest New();
    }

    // @protocol PaymentRequestDelegateBridgeDelegate
    [Protocol, Model]
    [BaseType(typeof(NSObject), Name = "_TtP5Adyen36PaymentRequestDelegateBridgeDelegate_")]
    interface PaymentRequestDelegateBridgeDelegate
    {
        // @required -(void)paymentRequest:(PaymentRequest * _Nonnull)request requiresPaymentDataForToken:(NSString * _Nonnull)token completion:(void (^ _Nonnull)(NSData * _Nonnull))completion;
        [Abstract]
        [Export("paymentRequest:requiresPaymentDataForToken:completion:")]
        void RequiresPaymentDataForToken(PaymentRequest request, string token, Action<NSData> completion);

        // @required -(void)paymentRequest:(PaymentRequest * _Nonnull)request requiresPaymentMethodFrom:(NSArray<PaymentMethod *> * _Nullable)preferredMethods available:(NSArray<PaymentMethod *> * _Nonnull)availableMethods completion:(void (^ _Nonnull)(PaymentMethod * _Nonnull))completion;
        [Abstract]
        [Export("paymentRequest:requiresPaymentMethodFrom:available:completion:")]
        void RequiresPaymentMethodFrom(PaymentRequest request, [NullAllowed] PaymentMethod[] preferredMethods, PaymentMethod[] availableMethods, Action<PaymentMethod> completion);

        // @required -(void)paymentRequest:(PaymentRequest * _Nonnull)request requiresReturnURLFrom:(NSUrl * _Nonnull)url completion:(void (^ _Nonnull)(NSUrl * _Nonnull))completion;
        [Abstract]
        [Export("paymentRequest:requiresReturnURLFrom:completion:")]
        void RequiresReturnURLFrom(PaymentRequest request, NSUrl url, Action<NSUrl> completion);

        // @required -(void)paymentRequest:(PaymentRequest * _Nonnull)request requiresPaymentDetails:(PaymentDetails * _Nonnull)details completion:(void (^ _Nonnull)(PaymentDetails * _Nonnull))completion;
        [Abstract]
        [Export("paymentRequest:requiresPaymentDetails:completion:")]
        void RequiresPaymentDetails(PaymentRequest request, PaymentDetails details, Action<PaymentDetails> completion);

        // @required -(void)paymentRequest:(PaymentRequest * _Nonnull)request didFinishWith:(Payment * _Nullable)result error:(NSError * _Nullable)error;
        [Abstract]
        [Export("paymentRequest:didFinishWith:error:")]
        void DidFinishWith(PaymentRequest request, [NullAllowed] Payment result, [NullAllowed] NSError error);
    }

    // @interface AppearanceConfiguration : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC5Adyen23AppearanceConfiguration")]
    interface AppearanceConfiguration
    {
        // @property (nonatomic) UIStatusBarStyle preferredStatusBarStyle;
        [Export("preferredStatusBarStyle", ArgumentSemantic.Assign)]
        UIStatusBarStyle PreferredStatusBarStyle { get; set; }

        // @property (copy, nonatomic) NSDictionary<NSAttributedStringKey,id> * _Nullable navigationBarTitleTextAttributes;
        [NullAllowed, Export("navigationBarTitleTextAttributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> NavigationBarTitleTextAttributes { get; set; }

        // @property (copy, nonatomic) NSDictionary<NSAttributedStringKey,id> * _Nullable navigationBarLargeTitleTextAttributes;
        [NullAllowed, Export("navigationBarLargeTitleTextAttributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> NavigationBarLargeTitleTextAttributes { get; set; }

        // @property (nonatomic) enum NavigationBarLargeTitleDisplayMode navigationBarLargeTitleDisplayMode;
        [Export("navigationBarLargeTitleDisplayMode", ArgumentSemantic.Assign)]
        NavigationBarLargeTitleDisplayMode NavigationBarLargeTitleDisplayMode { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable navigationBarTintColor;
        [NullAllowed, Export("navigationBarTintColor", ArgumentSemantic.Strong)]
        UIColor NavigationBarTintColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable navigationBarBackgroundColor;
        [NullAllowed, Export("navigationBarBackgroundColor", ArgumentSemantic.Strong)]
        UIColor NavigationBarBackgroundColor { get; set; }

        // @property (nonatomic) BOOL isNavigationBarTranslucent;
        [Export("isNavigationBarTranslucent")]
        bool IsNavigationBarTranslucent { get; set; }

        // @property (nonatomic, strong) UIImage * _Nullable navigationBarCancelButtonImage;
        [NullAllowed, Export("navigationBarCancelButtonImage", ArgumentSemantic.Strong)]
        UIImage NavigationBarCancelButtonImage { get; set; }

        // @property (nonatomic) Class _Nonnull checkoutButtonType;
        [Export("checkoutButtonType", ArgumentSemantic.Assign)]
        Class CheckoutButtonType { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable checkoutButtonTitle;
        [NullAllowed, Export("checkoutButtonTitle")]
        string CheckoutButtonTitle { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable safariBarTintColor;
        [NullAllowed, Export("safariBarTintColor", ArgumentSemantic.Strong)]
        UIColor SafariBarTintColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable safariControlTintColor;
        [NullAllowed, Export("safariControlTintColor", ArgumentSemantic.Strong)]
        UIColor SafariControlTintColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable tintColor;
        [NullAllowed, Export("tintColor", ArgumentSemantic.Strong)]
        UIColor TintColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull backgroundColor;
        [Export("backgroundColor", ArgumentSemantic.Strong)]
        UIColor BackgroundColor { get; set; }

        // @property (readonly, getter = default, nonatomic, strong, class) AppearanceConfiguration * _Nonnull default_;
        [Static]
        [Export("default_", ArgumentSemantic.Strong)]
        AppearanceConfiguration Default { [Bind("default")] get; }
    }
}
