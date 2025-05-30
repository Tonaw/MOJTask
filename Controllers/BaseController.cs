using Microsoft.AspNetCore.Mvc;

namespace MOJTask.Controllers
{
    public class BaseController : Controller
    {
    public enum AlertType { success, danger, warning, info }
    // Implements General functionality which is then accessible to any   // Controller inheriting from BaseController
        

      // set alert message
      public void Alert(string message, AlertType type = AlertType.info)
      {          
          TempData["Alert.Message"] = message;
          TempData["Alert.Type"] = type.ToString();      
        
      }
    }
}

