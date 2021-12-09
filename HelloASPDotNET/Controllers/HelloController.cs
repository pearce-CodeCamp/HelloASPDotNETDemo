using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloASPDotNET.Controllers
{
    public class HelloController : Controller
    {
        // GET: /hello/
        // Automatically handles get requests at the root path
        // of this controller
        // Root path: /hello
        public IActionResult Index()
        {
            string text = "<form method='POST' action='hello/greeting'>" +
                "<input type='text' name='name' autocomplete='off' placeholder='Enter Name...'/>" +
                "<select name='language'>" +
                "<option value='english'>English</option>" +
                "<option value='french'>French</option>" +
                "<option value='spanish'>Spanish</option>" +
                "<option value='hindi'>Hindi</option>" +
                "<option value='german'>German</option>" +
                "</select>" +
                "<input type='submit' value='submit'/>" +
                "</form>";
            return Content(text, "text/html");
        }

        // POST: /hello/
        // Any post requests made at the hello path will be
        // handled by this method
        [HttpPost]
        [Route("hello/greeting")]
        // when we put parameters in a post request handler
        // method, it will automatically try to find
        // a value for that parameter in the form that gets
        // handled by this method
        public IActionResult FormSubmission(string name, string language)
        {
            //If the language is english,
            //display a greeting to the effect of:
            //Hello, {name}!
            //If the language is hindi,
            //Namaste, {name}!
            //We could build this logic right in this method, but let's
            //create a separate method that does this for us so that
            //the code in this handler stays clean
            string greeting = CreateMessage(name, language);
            return Content(greeting, "text/html");
        }

        // We make this method static so we don't have to create
        // an instance of HelloController. We pretty much never
        // instantiate Controllers!
        // inputs: string name, string language
        // output: greeting string
        public static string CreateMessage(string name, string lang) 
        {
            // We determine what language to say hello in
            // based on the value of lang (english, hindi, french, etc...)
            if(lang == "english")
            {
                // if selected language is english, english greeting
                return $"Greetings, {name} :)";
            }
            else if (lang == "french")
            {
                return $"Bonjour, {name}!?";
            }
            else if (lang == "spanish")
            {
                return $"¡Hola, {name}!";
            }
            else if (lang == "hindi")
            {
                return $"Namaste, {name}!";
            }
            else if (lang == "german")
            {
                return $"Guten tag, {name}!?!!??";
            }
            return "No language provided";
        }
    }
}
