using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ManageProgramFlow
{
    public static class AsyncAwait
    {
        //P1: Use Async and await operators
        //Source: Kort, W. de. (2013). Exam ref 70-483: programming in C#. Redmond, WA: Microsoft Press.
        //Chapter: 1, Page: 18, Listing 1-18

        #region Original source code
        //This method calls the DownloadContent function which will run on a seperate thread
        public static void RunOriginalExample()
        {
            //The DownloadContent function returns a Task so we use the result property to get our string
            string result = DownloadContent().Result;
            Console.WriteLine(result);

        }

        public static async Task<string> DownloadContent()
        {
            using(HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://microsoft.com");
                return result; 
            }
        }
        #endregion

        #region Modified code
        //This modified program calculates the same of three list sequential and in parallel
        public static void RunModifiedExample()
        {
            //We did not ask for the result when we called the modified download function, so the download will start and our program will continue
            Console.WriteLine("This is meant to show the DownloadContent call does not block the current UI");
            var task = ModifiedDownloadContent();
            Console.WriteLine("This will show before the website and before the 'Download Complete' message since we did not wait for the ModifiedDownloadContent to finish.....");
            
            //This is where we stop running our program and wait for the Modified DownloadContent to finish
            task.Wait();
            //I used a substring to prevent the entire page from printing
            Console.WriteLine(task.Result.Substring(0, 600));
        }

        public static async Task<string> ModifiedDownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://microsoft.com");
                //This will print after our second Console message showing that the RunModifiedExample program continue after it ran this function
                Console.WriteLine("Download complete");
                return result;
            }
        }

        #endregion

        #region Code output
        //The original code prints a very long HTML page
        /*
           This is meant to show the DownloadContent call does not block the current UI
             Console.WriteLine("This will show before the website and before the 'Download Complete' message since we did not wait for the ModifiedDownloadContent to finish.....");
            Download complete



            <!DOCTYPE html>
            <html lang="en-us" dir="ltr">
            <head data-info="{&quot;v&quot;:&quot;1.0.7237.42332&quot;,&quot;a&quot;:&quot;b8eb892d-55eb-4b47-920e-8f52e9b6c292&quot;,&quot;cn&quot;:&quot;OneDeployContainer&quot;,&quot;az&quot;:&quot;{did:92e7dc58ca2143cfb2c818b047cc5cd1, rid: OneDeployContainer, sn: marketingsites-prod-odeastus, dt: 2018-05-03T20:14:23.4188992Z, bt: 2019-10-26T07:31:04.0000000Z}&quot;,&quot;ddpi&quot;:&quot;1&quot;,&quot;dpio&quot;:&quot;&quot;,&quot;dpi&quot;:&quot;1&quot;,&quot;dg&quot;:&quot;uplevel.web.pc&quot;,&quot;th&quot;:&quot;default&quot;,&quot;m&quot;:&qu

            C:\Users\izmac\source\repos\csc440FinalPortfolio\ManageProgramFlow\bin\Debug\netcoreapp3.0\ManageProgramFlow.exe (process 2696) exited with code 0.
            Press any key to close this window . . .

         */
        #endregion
    }
}
