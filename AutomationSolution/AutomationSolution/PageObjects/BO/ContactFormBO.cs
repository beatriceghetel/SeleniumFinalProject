using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSolution.PageObjects.BO
{
    /*
 * // enter the file path onto the file-selection input field
uploadElement.sendKeys("C:\\newhtml.html");

// check the "I accept the terms of service" check box
driver.findElement(By.id("terms")).click();

// click the "UploadFile" button
driver.findElement(By.name("send")).click();*/
    public class ContactFormBO
    {
        public String subjectHeading { get; set; } = "Webmaster";
        public String fileAddress { get; set; } = getAttachmentFilePath();

        public String message { get; set; } = "Hello,\nKindly check the issue from the printscreen attach :).\n\n BR Geo Ac1";


        private static String getAttachmentFilePath()
        {
            string directory = Directory.GetCurrentDirectory();

            string[] pathTokens = directory.Split(new char[] { '\\' });

            var counter = 0;
            // directory variable has  \bin\Debug\ as last 2 folder ; we applied a little "hack" to get rid of those
            StringBuilder correctedPath = new StringBuilder();
            for (counter = 0; counter < pathTokens.Length - 2; counter ++)
            {                
                correctedPath.Append(pathTokens[counter]);
                correctedPath.Append("\\");
            }
            // then we appended to the extracted path the actual sub-folders where our page_error.png is present
            correctedPath.Append("PageObjects\\BO\\page_error.png");

            Console.WriteLine("DEBUG: {0}", correctedPath.ToString());
            return correctedPath.ToString();
        }

    }
}
