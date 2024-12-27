namespace AbstractFactoryPatternSample.Utilities
{
    public sealed class Logger
    {
        // Private static instance to ensure only one instance is created
        private static Logger _instance;

        // Lock object for thread safety
        private static readonly object _lock = new object();

        // Private constructor to prevent instantiation
        private Logger() { }

        // Public property to access the single instance
        public static Logger Instance
        {
            get
            {
                // Ensure the instance is created only once, even in multi-threaded scenarios
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
                return _instance;
            }
        }

        public void Log(string message)
        {
            Console.WriteLine($"Log: {message}");
        }
    }
}
