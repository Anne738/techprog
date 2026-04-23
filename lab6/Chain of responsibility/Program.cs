using System;

namespace SupportServiceChain
{
    abstract class SupportHandler
    {
        protected SupportHandler successor;

        public void SetSuccessor(SupportHandler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleRequest(string request);
    }

    class BasicSupport : SupportHandler
    {
        public override void HandleRequest(string request)
        {
            if (request == "password reset" || request == "account unlock")
            {
                Console.WriteLine("Basic Support handled: " + request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }

    class IntermediateSupport : SupportHandler
    {
        public override void HandleRequest(string request)
        {
            if (request == "software bug" || request == "installation issue")
            {
                Console.WriteLine("Intermediate Support handled: " + request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }

    class SeniorSupport : SupportHandler
    {
        public override void HandleRequest(string request)
        {
            if (request == "server crash" || request == "security breach")
            {
                Console.WriteLine("Senior Support handled: " + request);
            }
            else
            {
                Console.WriteLine("Request not handled: " + request);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SupportHandler basic = new BasicSupport();
            SupportHandler intermediate = new IntermediateSupport();
            SupportHandler senior = new SeniorSupport();


            basic.SetSuccessor(intermediate);
            intermediate.SetSuccessor(senior);

            string[] requests =
            {
                "password reset",
                "software bug",
                "server crash",
                "installation issue",
                "account unlock",
                "security breach",
                "unknown problem"
            };


            foreach (var request in requests)
            {
                basic.HandleRequest(request);
            }

            Console.ReadKey();
        }
    }
}