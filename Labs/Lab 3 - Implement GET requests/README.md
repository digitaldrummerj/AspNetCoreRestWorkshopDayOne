# Implement the GET `/jobs` endpoint

The goal of this is to create a fully end-to-end API that gets real data! Yay!

## Concepts

- Creating request objects that will be your entry point for HTTP requests. 
- Validating the requests using FluentValidation.
- Writing handlers to handle the request's intent and return data to the caller.
- Write the response object.

## Tasks

### Hydrate your database

1. We need to make sure that our database has some data to get, so let's add some definitely-not-production code to our Configure method in the Startup class:

```csharp
using (var scope = app.ApplicationServices.CreateScope())
{
    var scopedServices = scope.ServiceProvider;
    var db = scopedServices.GetRequiredService<WorkshopDbContext>();

    db.Database.EnsureCreated();

    db.Jobs.Add(new Job
    {
        Number = "12345-",
        Name = "Building a Wal-Mart",
        Description = null,
        StartDate = new DateTime(2019, 5, 15)
    });

    db.Jobs.Add(new Job
    {
        Number = "George",
        Name = "George's Day Spa",
        Description = null,
        StartDate = new DateTime(2019, 7, 15)
    });

    db.SaveChanges();
}
```

### Create the response record

1. Add a class to the Jobs/GetJobs folder called GetJobsResponse.
2. Copy and paste all properties from the Job class to this one.

### Create the map

1. Open up WorkshopMapper and add the following line to the `config => {}` lambda: `config.CreateMap<Job, GetJobsResponse>();`

### Create the request

1. Add a class to the GetJobs folder called GetJobsRequest.
2. Add the `IRequest<IEnumerable<GetJobsResponse>>` interface to the class.

### Create the validator 

1. Add a class to the GetJobs folder called GetJobsValidator.
2. Inherit from the `AbstractValidator<GetJobsRequest>` class.

Note that this class will not do anything right now - we're just adding it in to 

### Create the request handler

1. Add a class to the GetJobs folder called GetJobsRequestHandler.
2. Inherit from the `ValidatedRequestHandler<GetJobsRequest, IEnumerable<GetJobsResponse>>` class.
3. Use the tooling to auto-add the constructor, then add in `WorkshopDbContext` and `IMapper` as parameters to the constructor and set them to private fields or properties.
4. Use the tooling to auto-add the `OnHandle` method that will be executed.
5. Write your `OnHandle` method implementation like so:

```csharp
protected override async Task<IEnumerable<GetJobsResponse>> OnHandle(GetJobsRequest message, CancellationToken cancellationToken)
{
    IQueryable<Job> jobs = _workshopDbContext.Jobs;

    return await jobs
        .ProjectTo<GetJobsResponse>(_mapper.ConfigurationProvider)
        .ToArrayAsync(cancellationToken);
}
```

### Add the HTTP method to the `WorkshopController`

1. Add a method to the `JobsController` that takes in the request and passes it to HandleRequestAsync, like so:

```csharp
public Task<IActionResult> GetJobs()
{
    return HandleRequestAsync(new GetJobsRequest());
}
```

2. Add the `HttpGet` attribute to the method.

### Test your method out

1. Fire up your API project using your favorite tool or the command line: `dotnet run`
2. Wherever you're running it from, note the port number of the application that was started (will usually be 8000).
3. Open up Postman and create a GET request to: `http://localhost:8000/api/jobs`
4. Execute that request!