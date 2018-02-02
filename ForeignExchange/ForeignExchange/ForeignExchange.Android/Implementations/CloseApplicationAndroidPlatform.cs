using Xamarin.Forms;

[assembly: Dependency(typeof(ForeignExchange.Droid.Implementations.CloseApplicationAndroidPlatform))]
namespace ForeignExchange.Droid.Implementations
{
    using ForeignExchange.Interfaces;

    class CloseApplicationAndroidPlatform : ICloseApplicationPlatform
    {
        public void Close()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}