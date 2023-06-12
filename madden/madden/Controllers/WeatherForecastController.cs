using Microsoft.AspNetCore.Mvc;

namespace madden.Controllers;


/*
 * This file contains actions that handle requests to endpoints
 * 
 * routing systen sekects endpoint for HTTP Request
 * A route --> a rule used to decide how a request is handled 
 * 
 * for MVC: / /Home /Home/Index --> Index()
 * 
 * 
 */
[ApiController]
[Route("[controller]")]

/* Controller --> has Views
   ControllerBase --> no views */
public class WeatherForecastController : Controller/*Base*/
{
    
    //public ViewResult Gets()
    //{
      //  int viewModel = 0;

        /* Create a View Model --> data provided to the view */
        /* calls View method of the Controller Class */
        //return View("view", viewModel);

        // return View() checks for  func name
    //}


    /*
    [HttpGet(Name = "GetWeatherForecast")]
    public string Get()
    {
        return "Hi";
    }
    */

    /* ViewResult tells ASP.NET to render a view */
    // It is a type of Action result object
    [HttpGet(Name = "GetWeatherForecast")]
    // IActionResult
    public ViewResult Get()
    {
        int viewModel = 0;

        /* Create a View Model --> data provided to the view */
        /* calls View method of the Controller Class */
        return View("MyView", viewModel);
    }


}
 