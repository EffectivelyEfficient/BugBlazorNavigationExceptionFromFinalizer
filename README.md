# BugBlazorNavigationExceptionFromFinalizer
This is a reproduction case for https://github.com/dotnet/aspnetcore/issues/62167

It demonstrates the navigationManager.NavigateTo() creating a NavigationException in a OnInitializedAsync method. It will create an error in the console indicating the "unobserved exception was rethrown by the finalizer thread" error.

**Instructions:**
- Start project. Web browser should open.
- On visiting the root URI the first time, the user will be redirected to the root URI again.
- On visiting the root URI the second time, the finalizer queue is cleared and error is shown in the console.

**Exception that occurs in console:**
```
Unhandled caught: System.AggregateException: A Task's exception(s) were not observed either by Waiting on the Task or accessing its Exception property. As a result, the unobserved exception was rethrown by the finalizer thread. (Exception of type 'Microsoft.AspNetCore.Components.NavigationException' was thrown.)
 ---> Microsoft.AspNetCore.Components.NavigationException: Exception of type 'Microsoft.AspNetCore.Components.NavigationException' was thrown.
   at Microsoft.AspNetCore.Components.Endpoints.HttpNavigationManager.NavigateToCore(String uri, NavigationOptions options)
   at Microsoft.AspNetCore.Components.NavigationManager.NavigateToCore(String uri, Boolean forceLoad)
   at Microsoft.AspNetCore.Components.NavigationManager.NavigateTo(String uri, Boolean forceLoad, Boolean replace)
   at BlazorApp1.Pages.Index.OnInitializedAsync() in C:\Users\xxx\source\repos\BugBlazorNavigationExceptionFromFinalizer\BlazorApp1\Pages\Index.razor:line 15
   at Microsoft.AspNetCore.Components.ComponentBase.RunInitAndSetParametersAsync()
   at Microsoft.AspNetCore.Components.RenderTree.Renderer.GetErrorHandledTask(Task taskToHandle, ComponentState owningComponentState)
   at Microsoft.AspNetCore.Components.RenderTree.Renderer.GetErrorHandledTask(Task taskToHandle, ComponentState owningComponentState)
   at Microsoft.AspNetCore.Components.Endpoints.EndpointHtmlRenderer.<WaitForNonStreamingPendingTasks>g__Execute|43_0()
   at Microsoft.AspNetCore.Components.Endpoints.EndpointHtmlRenderer.WaitForResultReady(Boolean waitForQuiescence, PrerenderedComponentHtmlContent result)
   at Microsoft.AspNetCore.Components.Endpoints.EndpointHtmlRenderer.RenderEndpointComponent(HttpContext httpContext, Type rootComponentType, ParameterView parameters, Boolean waitForQuiescence)
   --- End of inner exception stack trace ---
```
