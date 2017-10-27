using System.Threading;

namespace MultiThread3
{
    public delegate void GetAString(string x);

    public class TestSingleThread
    {
        private string _initialString;

        public event GetAString OnGettingAString;

        public TestSingleThread(string initialString)
        {
            _initialString = initialString;
        }

        public void ProcessAThread(string myName, string myEmail)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            string result = string.Format("Thread Id {3}: Hello {0}, my name is {1} and my email is {2}", _initialString, myName, myEmail, threadId);
            OnGettingAString(result);
        }
    }
  
}
