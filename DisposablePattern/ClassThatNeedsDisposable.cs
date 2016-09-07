using System;
using System.IO;

namespace NetCore.DisposablePattern
{
    public class ClassThatNeedsDisposable : IDisposable
    {
        private readonly Stream _stream = Stream.Null;
        protected virtual void Dispose(bool disposing)
        {
            Console.WriteLine(@"I am being disposed. Help me!");
            _stream.Dispose();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        ~ClassThatNeedsDisposable()
        {
            Dispose(false);
        }
    }
}
