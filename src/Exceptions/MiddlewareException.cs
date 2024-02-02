namespace boombang_emulator.src.Exceptions
{
    internal class MiddlewareException : Exception
    {
        public MiddlewareException() : base() { }
        public MiddlewareException(string message) : base(message) { }
        public MiddlewareException(string message, Exception inner) : base(message, inner) { }
    }
}
