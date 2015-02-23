using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefensiveCoding
{
    using System.Net.Mime;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            // UI Global exception handler
            // For windows app - UI Exception thread
            // Application.ThreadException += new ThreadExceptionEventHandler.GlobalExceptionHandler;

            // Force all windows global exceptions to go through our handler
            //Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            //AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionEventHandler(GlobalExceptionHandler);


        }

        static void GlobalExceptionHandler(object sender, EventArgs eventArgs)
        {
            // Log issue
        }
    }
}
