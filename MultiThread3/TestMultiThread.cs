using System;
using System.Collections.Generic;
using System.Threading;

namespace MultiThread3
{
    public class TestMultiThread
    {
        public event GetAString OnCompletedThread;

        public void ProcessStringArrayInMultipleThreads(Dictionary<string, string> nameAndEmails)
        {
            foreach (KeyValuePair<string,string> kvp in nameAndEmails)
            {
                Thread thread = new Thread(() => {
                    TestSingleThread ts = new TestSingleThread(Environment.UserName);
                    ts.OnGettingAString += new GetAString(FetchResult);
                    ts.ProcessAThread(kvp.Key, kvp.Value);
                });
                thread.Start();
            }
        }

        public void FetchResult(string x)
        {
            OnCompletedThread(x);
        }

    }
}
