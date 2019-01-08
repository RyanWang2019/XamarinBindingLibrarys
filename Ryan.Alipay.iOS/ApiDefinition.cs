using System;
using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Alipay
{
    // The first step to creating a binding is to add your native library ("libNativeLibrary.a")
    // to the project by right-clicking (or Control-clicking) the folder containing this source
    // file and clicking "Add files..." and then simply select the native library (or libraries)
    // that you want to bind.
    //
    // When you do that, you'll notice that MonoDevelop generates a code-behind file for each
    // native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
    // architectures that the native library supports and fills in that information for you,
    // however, it cannot auto-detect any Frameworks or other system libraries that the
    // native library may depend on, so you'll need to fill in that information yourself.
    //
    // Once you've done that, you're ready to move on to binding the API...
    //
    //
    // Here is where you'd define your API definition for the native Objective-C library.
    //
    // For example, to bind the following Objective-C class:
    //
    //     @interface Widget : NSObject {
    //     }
    //
    // The C# binding would look like this:
    //
    //     [BaseType (typeof (NSObject))]
    //     interface Widget {
    //     }
    //
    // To bind Objective-C properties, such as:
    //
    //     @property (nonatomic, readwrite, assign) CGPoint center;
    //
    // You would add a property definition in the C# interface like so:
    //
    //     [Export ("center")]
    //     CGPoint Center { get; set; }
    //
    // To bind an Objective-C method, such as:
    //
    //     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
    //
    // You would add a method definition to the C# interface like so:
    //
    //     [Export ("doSomething:atIndex:")]
    //     void DoSomething (NSObject object, int index);
    //
    // Objective-C "constructors" such as:
    //
    //     -(id)initWithElmo:(ElmoMuppet *)elmo;
    //
    // Can be bound as:
    //
    //     [Export ("initWithElmo:")]
    //     IntPtr Constructor (ElmoMuppet elmo);
    //
    // For more information, see http://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/
    //
    // @interface APayAuthInfo : NSObject

    // @interface APayAuthInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface APayAuthInfo
    {
        // @property (copy, nonatomic) NSString * appID;
        [Export("appID")]
        string AppID { get; set; }

        // @property (copy, nonatomic) NSString * pid;
        [Export("pid")]
        string Pid { get; set; }

        // @property (copy, nonatomic) NSString * redirectUri;
        [Export("redirectUri")]
        string RedirectUri { get; set; }

        // -(id)initWithAppID:(NSString *)appIDStr pid:(NSString *)pidStr redirectUri:(NSString *)uriStr;
        [Export("initWithAppID:pid:redirectUri:")]
        IntPtr Constructor(string appIDStr, string pidStr, string uriStr);

        // -(NSString *)description;
        [Export("description")]
        string Description { get; }

        // -(NSString *)wapDescription;
        [Export("wapDescription")]
        string WapDescription { get; }
    }

    // typedef void (^CompletionBlock)(NSDictionary *);
    delegate void CompletionBlock(NSDictionary arg0);

    // @interface AlipaySDK : NSObject
    [BaseType(typeof(NSObject))]
    interface AlipaySDK
    {
        // +(AlipaySDK *)defaultService;
        [Static]
        [Export("defaultService")]
        AlipaySDK DefaultService { get; }

        // @property (nonatomic, weak) UIWindow * targetWindow;
        [Export("targetWindow", ArgumentSemantic.Weak)]
        UIWindow TargetWindow { get; set; }

        // -(void)payOrder:(NSString *)orderStr fromScheme:(NSString *)schemeStr callback:(CompletionBlock)completionBlock;
        [Export("payOrder:fromScheme:callback:")]
        void PayOrder(string orderStr, string schemeStr, CompletionBlock completionBlock);

        // -(void)processOrderWithPaymentResult:(NSURL *)resultUrl standbyCallback:(CompletionBlock)completionBlock;
        [Export("processOrderWithPaymentResult:standbyCallback:")]
        void ProcessOrderWithPaymentResult(NSUrl resultUrl, CompletionBlock completionBlock);

        // -(NSString *)fetchTradeToken;
        [Export("fetchTradeToken")]
        string FetchTradeToken { get; }

        // -(BOOL)isLogined;
        [Export("isLogined")]
        bool IsLogined { get; }

        // -(NSString *)currentVersion;
        [Export("currentVersion")]
        string CurrentVersion { get; }

        // -(void)setUrl:(NSString *)url;
        [Export("setUrl:")]
        void SetUrl(string url);

        // -(BOOL)payInterceptorWithUrl:(NSString *)urlStr fromScheme:(NSString *)schemeStr callback:(CompletionBlock)completionBlock;
        [Export("payInterceptorWithUrl:fromScheme:callback:")]
        bool PayInterceptorWithUrl(string urlStr, string schemeStr, CompletionBlock completionBlock);

        // -(NSString *)fetchOrderInfoFromH5PayUrl:(NSString *)urlStr;
        [Export("fetchOrderInfoFromH5PayUrl:")]
        string FetchOrderInfoFromH5PayUrl(string urlStr);

        // -(void)payUrlOrder:(NSString *)orderStr fromScheme:(NSString *)schemeStr callback:(CompletionBlock)completionBlock;
        [Export("payUrlOrder:fromScheme:callback:")]
        void PayUrlOrder(string orderStr, string schemeStr, CompletionBlock completionBlock);

        // -(void)auth_V2WithInfo:(NSString *)infoStr fromScheme:(NSString *)schemeStr callback:(CompletionBlock)completionBlock;
        [Export("auth_V2WithInfo:fromScheme:callback:")]
        void Auth_V2WithInfo(string infoStr, string schemeStr, CompletionBlock completionBlock);

        // -(void)processAuth_V2Result:(NSURL *)resultUrl standbyCallback:(CompletionBlock)completionBlock;
        [Export("processAuth_V2Result:standbyCallback:")]
        void ProcessAuth_V2Result(NSUrl resultUrl, CompletionBlock completionBlock);

        // -(void)authWithInfo:(APayAuthInfo *)authInfo callback:(CompletionBlock)completionBlock;
        [Export("authWithInfo:callback:")]
        void AuthWithInfo(APayAuthInfo authInfo, CompletionBlock completionBlock);

        // -(void)processAuthResult:(NSURL *)resultUrl standbyCallback:(CompletionBlock)completionBlock;
        [Export("processAuthResult:standbyCallback:")]
        void ProcessAuthResult(NSUrl resultUrl, CompletionBlock completionBlock);
    }
}

