using KantinPro.Database;

namespace KantinPro
{
    public class SingletonContext : KantinProDataContext
    {
        private static SingletonContext dc;

        private SingletonContext() { }

        public static SingletonContext nesne()
        {
            if (dc == null)
                dc = new SingletonContext();

            return dc;
        }
    }
}