using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Moxitech_Tasklist_Open_Source;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}
