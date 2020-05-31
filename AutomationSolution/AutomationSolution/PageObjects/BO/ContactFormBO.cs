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
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(currentDir);
            FileInfo file = new FileInfo("page_error.png");

            string fullDirectory = directory.FullName;
            string fullFile = file.FullName;

            return fullFile;
        }

    }
}
