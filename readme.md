The Project's goal is around [asp.net routing](http://www.asp.net/web-api/overview/web-api-routing-and-actions): understanding, debugging, playing.

## Quick Setup and Run

- Open Solution in Visual Studio 2013
- Within the Visual Studio Solution Explorer right-click on the solution and choose 'Enable NuGet Package Restore'
- In Package Manager Console run `Update-Package -Reinstall`
- You're ready to run: Press buttons in browser to send ajax-requests and watch browser's console.


## Where to start

See:

- `index.html` - Ajax request configurations
- `WebApiConfig` - Route template definition
- `TestParamBindingController`


## Next Steps

- `PM> Install-Package WebApiRouteDebugger`
- To Run Http-queries you can also use Fiddler and browser's development tools


## Explanations on Setup and run

I prefere not to store external libraries and resources in CVS-repo. 
Unfortunately `nuget restore` does not copy content folders to project. [Here is why](http://nuget.codeplex.com/workitem/2094). In short: 
> We cannot allow package restore to modify project content. 
It would lead to inconsistent builds from machine to machine, 
and situations where the continuous integration build would be modifying the project, which is terrible.

So there is ugly workaround: `Update-Package -Reinstall` as [explained on SO](http://stackoverflow.com/questions/14942374/nuget-package-files-not-being-copied-to-project-content-during-build/24800493).


## Used Components & Libs

It's listed in package.config, but most interesting is:

- [strapdown](https://github.com/arturadib/strapdown)
- [google-code-prettify](https://code.google.com/p/google-code-prettify/)
- [marked](https://github.com/chjj/marked/)