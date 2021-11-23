namespace TAC
{
    public static class Program
    {
        static void Main()
        {
            var factory = new MonoGame.Framework.GameFrameworkViewSource<TAC_Game>();
            Windows.ApplicationModel.Core.CoreApplication.Run(factory);
        }
    }
}
