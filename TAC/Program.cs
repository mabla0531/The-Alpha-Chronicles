using System;

namespace TAC
{
    public static class Program
    {
        static void Main()
        {
            var factory = new MonoGame.Framework.GameFrameworkViewSource<Game1>();
            Windows.ApplicationModel.Core.CoreApplication.Run(factory);
        }
    }
}
