
# <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTbEexd6uALtO6V3yZmdcAMP_QTTQQXleXcwg&usqp=CAU" alt="drawing" width="80"/> .Net 7 Features

- A major part of Microsoft’s “cloud-first” .NET 7 release in November, ASP.NET Core 7 brings powerful new tools to the web development framework to help developers create modern web applications. Built on top of the .NET Core runtime, ASP.NET Core 7 has everything you need to build cutting-edge web user interfaces and robust back-end services on Windows, Linux, and macOS alike..

- This article discusses the biggest highlights in ASP.NET Core 7, and includes some code examples to get you started with the new features.

## Let's see all the .Net 7 features with examples

- ### **Output caching middleware :**
    
    ASP.NET Core 7 allows you to use output caching in all ASP.NET Core apps: Minimal API, MVC, Razor Pages, and Web API apps with controllers. To add the output caching middleware to the services collection, invoke the IServiceCollection.AddOutputCache extension method. To add the middleware to the request processing pipeline, call the IApplicationBuilder.UseOutputCache extension method.
    
    ![image](https://github.com/jil1710/readmedemo/assets/125335932/378d88b4-be13-4444-b694-cfdb1d7b8887)

    Then, to add a caching layer to an endpoint, you can use the following code.

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/40b8cab6-cd95-4005-bbe7-f3d00528ae3f)


    - Click here to see demo : [Output cache middleware](https://github.com/jil1710/dotnet7/tree/master/OutputcacheFeature)


- ### **Rate-limiting middleware :**

    Controlling the rate at which clients can make requests to endpoints is an important security measure that allows web applications to ward off malicious attacks. You can prevent denial-of-service attacks, for example, by limiting the number of requests coming from a single IP address in a given period of time. The term for this capability is rate limiting.

    The Microsoft.AspNetCore.RateLimiting middleware in ASP.NET Core 7 can help you enforce rate limiting in your application. You can configure rate-limiting policies and then attach those policies to the endpoints.

    You can use the rate-limiting middleware with ASP.NET Core Web API, ASP.NET Core MVC, and ASP.NET Core Minimal API apps. To get started using this built-in middleware, add the Microsoft.AspNetCore.RateLimiting NuGet package to your project by executing the following command at the Visual Studio command prompt.

    ```
        dotnet add package Microsoft.AspNetCore.RateLimiting
    ```
    
    ![image](https://github.com/jil1710/readmedemo/assets/125335932/29b1af44-0719-432b-af0b-6c9cce67beae)

    Then, to add a rate limiting to particular endpoint, you can use the following code.

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/f94fc7ad-6495-4ca3-bac9-a801c698c627)

    - Click here to see demo : [Rate Limiting by IP address](https://github.com/jil1710/dotnet7/tree/master/RateLimitingFeature) 


- ### **Request decompression middleware :**

    ASP.NET Core 7 includes a new request decompression middleware that allows endpoints to accept requests that have compressed content. This eliminates the need to write code explicitly to decompress requests with compressed content. It works by using a Content-Encoding HTTP header to identify and decompress compressed content in HTTP requests.

    In response to an HTTP request that matches the Content-Encoding header value, the middleware encapsulates the HttpRequest.Body in a suitable decompression stream using the matching provider. This is followed by the removal of the Content-Encoding header, which indicates that the request body is no longer compressed. Note that the request decompression middleware ignores requests without a Content-Encoding header.

    The code snippet below shows how you can enable request decompression for the default Content-Encoding types.

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/f1ab1e4a-ab5b-466a-a908-ec32d696252b)

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/14980634-3f89-47e7-9ec8-c3f915fb04ee)

    - Click here to see demo : [Request decompression middleware](https://github.com/jil1710/dotnet7/tree/master/RequestDecompressionMiddleware)


- ### **Filters in minimal APIs :**

    Filters let you execute code during certain stages in the request processing pipeline. A filter runs before or after the execution of an action method. You can take advantage of filters to track web page visits or validate the request parameters. By using filters, you can focus on the business logic of your application rather than on writing code for the cross-cutting concerns in your application.

    An endpoint filter enables you to intercept, modify, short-circuit, and aggregate cross-cutting issues such as authorization, validation, and exception handling. The new IEndpointFilter interface in ASP.NET Core 7 lets us design filters and connect them to API endpoints. These filters may change request or response objects or short-circuit request processing. An endpoint filter can be invoked on actions and on route endpoints.

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/cc87a76e-b95f-4cfe-af58-e2d6c093eb6c)
  
    - Click here to see demo : [Filters in minimal APIs](https://github.com/jil1710/dotnet7/tree/master/FilterInMinimalApi)


- ### **Parameter binding in action methods using DI :**

    With ASP.NET Core 7, you can take advantage of dependency injection to bind parameters in the action methods of your API controllers. So, if the type is configured as a service, you no longer need to add the [FromServices] attribute to your method parameters. The following code snippet illustrates this.

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/5580a1d7-ac21-42ea-a443-8402498d34bd)

    - Click here to see demo : [Parameter binding in action methods using DI](https://github.com/jil1710/dotnet7/tree/master/ParameterBindingServiceWithDI)


- ### **Route groups in minimal APIs :**

    With ASP.NET Core 7, you can leverage the new MapGroup extension method to organize groups of endpoints that share a common prefix in your minimal APIs. The MapGroup extension method not only reduces repetitive code, but also makes it easier to customize entire groups of endpoints.

    The following code snippet shows how MapGroup can be used.

    ```csharp
        app.MapGroup("/public/authors")
            .MapAuthorsApi()
            .WithTags("Public");
    ```

    The next code snippet illustrates the MapAuthorsApi extension method.

    ```csharp
        public static class MyRouteBuilder
        { 
        public static RouteGroupBuilder MapAuthorsApi(this RouteGroupBuilder group)
            {
                group.MapGet("/", GetAllAuthors);
                group.MapGet("/{id}", GetAuthor);
                group.MapPost("/", CreateAuthor);
                group.MapPut("/{id}", UpdateAuthor);
                group.MapDelete("/{id}", DeleteAuthor);
                return group;
            }
        }
    ```

    - Click here to see demo : [Route groups in minimal APIs](https://github.com/jil1710/dotnet7/tree/master/RouteGroupInMinimalApi)


- ### **File uploads in minimal APIs :**

    You can now use IFormFile and IFormFileCollection in minimal APIs to upload files in ASP.NET Core 7. The following code snippet illustrates how IFormFile can be used.

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/1f996cc9-6beb-40bb-b691-a57c140f6041)

    If you want to upload multiple files, you can use the following piece of code instead.

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/6748811b-66cd-468d-a1a7-8d1c87b9ca83)

    - Click here to see demo : [File uploads in minimal APIs](https://github.com/jil1710/dotnet7/tree/master/FileUploadInMinimalApi)


 - ### **JSON property names in validation errors :**

    By default, when a validation error occurs, model validation produces a ModelStateDictionary with the property name as the error key. Some apps, such as single page apps, benefit from using JSON property names for validation errors generated from Web APIs. The following code configures validation to use the SystemTextJsonValidationMetadataProvider to use JSON property names:

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/757cf498-dc36-4d41-8cca-cfdc99e4416a)

    - Click here to see demo : [JSON property names in validation errors](https://github.com/jil1710/dotnet7/tree/master/JsonPropertyNameInValidation)


- ### **Bind arrays and string values from headers and query strings :**

    In ASP.NET 7, binding query strings to an array of primitive types, string arrays, and StringValues is supported:

    ```csharp
        // Bind query string values to a primitive type array.
        // GET  /tags?q=1&q=2&q=3
        app.MapGet("/tags", (int[] q) => $"tag1: {q[0]} , tag2: {q[1]}, tag3: {q[2]}");

        // Bind to a string array.
        // GET /tags2?names=john&names=jack&names=jane
        app.MapGet("/tags2", (string[] names) => $"tag1: {names[0]} , tag2: {names[1]}, tag3: {names[2]}");

        // Bind to StringValues.
        // GET /tags3?names=john&names=jack&names=jane
        app.MapGet("/tags3", (StringValues names) => $"tag1: {names[0]} , tag2: {names[1]}, tag3: {names[2]}");
    ```

## MVC and Razor pages

- ### **Support for nullable models in MVC views and Razor Pages :**

    Nullable page or view models are supported to improve the experience when using null state checking with ASP.NET Core apps:

    ```csharp
        @model Product?
    ```

## Servers and Runtime
 
- Limit the rate of handled requests using flexible endpoint configuration and policies.
- Configure caching for responses to handle requests more efficiently.
- Accept requests with compressed content.
- Built-in support for HTTP/3, the latest HTTP version based on the new QUIC multiplexed transport protocol.
- Use WebSockets over HTTP/2 connections.
- Create streams and datagrams over HTTP/3 with experimental support for WebTransport.

## Performance Optimization
- In the .NET 7-based application, you will analyze a boost to speed and performance. Microsoft has     released several performance-accelerating components in this version, which includes the following: 

    - **OSR (On-Stack Replacement) :**

        OSR helps in improving the code execution during runtime, as it allows the currently running process to change the methods in between. In addition, it also gets considered as a tiered compilation complement. Due to this, .NET developers prefer it for implementing method switching for extended or time-consuming processes.

    - **PGO (Profile-guided Optimization) :**

        This is the big deal in .NET 7.0. Dynamic PGO allows the JIT to use profiling data to change the way code is compiled in the background at runtime, meaning that the code’s execution performance will change as the JIT utilizes information collected as a single instance of an application runs.

    In .NET 7, Microsoft allows you to run PGO and OSR simultaneously, which you can enable in only the following two steps: 

    ```
    Step 1: Open the project file. 
    ```
    ```
    Step 2: Add the code: <TieredPGO>true</TieredPGO> and save the file. 
    ```
    Once you complete the PGO enablement, .NET 7 will improve the overall application performance.

## Blazor Changes

- Build standard HTML custom elements with Blazor to integrate Blazor components with any JavaScript-based application.
- Intercept location changing events to create custom user experiences when navigating.
- Run async logic after data binding and independently control how data binding gets and sets the data.
- Create dynamic authentication requests at runtime with custom parameters to handle advanced authentication scenarios in Blazor WebAssembly apps.
- Optimize JavaScript interop call on WebAssembly using the new [JSImport]/[JSExport] support for improvement.
- Improve performance with .NET WebAssembly ahead-of-time (AOT) compilation using WebAssembly SIMD and exception handling support.


## gRPC

- gRPC JSON Transcoding support in .Net 7.
 
    gRPC JSON transcoding is an extension for ASP.NET Core that creates RESTful JSON APIs for gRPC services. 
    - ***gRPC JSON transcoding allows:***

        - Apps to call gRPC services with familiar HTTP concepts.
        - ASP.NET Core gRPC apps to support both gRPC and RESTful JSON APIs without replicating functionality.
        - Experimental support for generating OpenAPI from transcoded RESTful APIs by integrating with Swashbuckle.
    

    .NET 7 gRPC performance now exceeds popular frameworks like Rust, Go and C++.

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/4f925c02-7a2a-4f2d-b4e1-25d5b863af80)


    - [click here for more detail on gRPC with .net 7](https://medium.com/geekculture/build-high-performance-services-using-grpc-and-net7-7c0c434abbb0#:~:text=gRPC%20JSON%20Transcoding,-.&text=NET7%20provides%20an%20extension%20for,HTTP%20Verbs)



    
