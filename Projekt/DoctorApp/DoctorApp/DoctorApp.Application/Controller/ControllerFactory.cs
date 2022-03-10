namespace DoctorApp.Application.Controller
{
    using DoctorApp.Application.Model;
    using DoctorApp.Application.Utilities;
    using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;


  public static class ControllerFactory
  {
    private static IController controller;

    public static IController GetController( IEventDispatcher dispatcher )
    {
      if( controller == null )
      {
        IModel newModel = new Model( dispatcher ) as IModel;

        IController newController = new Controller( dispatcher, newModel );

        controller = newController;
      }
      return controller;
    }
  }
}
