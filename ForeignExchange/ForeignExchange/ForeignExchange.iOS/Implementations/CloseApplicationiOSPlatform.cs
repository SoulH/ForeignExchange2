using Xamarin.Forms;

[assembly: Dependency(typeof(ForeignExchange.iOS.Implementations.CloseApplicationiOSPlatform))]
namespace ForeignExchange.iOS.Implementations
{
    using ForeignExchange.Interfaces;
    using System.Threading;

    class CloseApplicationiOSPlatform : ICloseApplicationPlatform
    {
        public void Close()
        {
            //UIApplication.SharedApplication.PerformSelector(new MonoTouch.ObjCRuntime.Selector("terminateWithSuccess"),null,0f);
            Thread.CurrentThread.Abort();
        }
    }
}
