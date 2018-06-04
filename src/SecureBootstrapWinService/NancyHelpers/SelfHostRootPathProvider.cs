using Nancy;
using System;
using System.IO;

namespace SecureBootstrapWinService.NancyHelpers
{
    public class SelfHostRootPathProvider : Nancy.IRootPathProvider
    {
        public string GetRootPath()
        {
            return StaticConfiguration.IsRunningDebug
                ? Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", ".."))
                : AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
