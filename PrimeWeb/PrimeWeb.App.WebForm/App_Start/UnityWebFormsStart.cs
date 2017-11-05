using System.Web;
using Microsoft.Practices.Unity;
using Unity.WebForms;

[assembly: WebActivatorEx.PostApplicationStartMethod( typeof(PrimeWeb.App.WebForm.App_Start.UnityWebFormsStart), "PostStart" )]
namespace PrimeWeb.App.WebForm.App_Start
{
	internal static class UnityWebFormsStart
	{
		internal static void PostStart()
		{
			IUnityContainer container = new UnityContainer();
			HttpContext.Current.Application.SetContainer( container );

            //Framework.Dependency.DependencyRegistrar.RegisterBase(container);

			RegisterDependencies( container );
		}

		private static void RegisterDependencies( IUnityContainer container )
		{
			// TODO: Add any dependencies needed here

		}
	}
}