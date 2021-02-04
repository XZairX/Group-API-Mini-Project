# Group-API-Mini-Project



## Project Goal
Deliver an API test framework for the Current Weather service for OpenWeatherAPI - https://openweathermap.org/current

## Class Diagram



![](https://github.com/XZairX/Group-API-Mini-Project/blob/main/images/class-diagram.png)



## Sprint One Overview



### Sprint Goal

- [x] Produce and populate the project board

- [x] Investigate and explore the response from the API

- [x] Build the framework to test our weather API

- [x] Write the appropriate tests for the API relevant to our user stories

- [x] Create a ReadME for the project, completed with documentation, including sprint review and retrospective

- [x] Document any issues/bugs with the framework or API that arise

- [x] Class Diagram produced for API framework

- [x] Plan how we intend to present our project 

  

### Sprint Definition of Done

- [ ] All user stories are marked as done
- [ ] All user stories have been covered by tests
- [ ] All bugs/issues have been recorded
- [ ] All tests pass
- [ ] The product has been reviewed and approved
- [ ] The framework is published to GitHub before 05/02/2021, 11:00
- [ ] The project has a complete README.md file



### SP-API Project Board Start

![](https://github.com/XZairX/Group-API-Mini-Project/blob/main/images/sprint-1-start.png)

### Sprint Lifecycle

After our initial planning, researching and playing with a few APIs on Postman, we settled on building our framework to test the functionality of the OpenWeatherAPI.  We read through the APIs documentation, and tested the various endpoints to identify what our frameworks tests needed to cover.

The API can only perform GET requests, and there were restrictions in place on our API key due to us only having a free account.  An example of one restriction such restriction was being unable to access historical weather data. None-the-less, we still had an extensive API to test, with multiple calls to implement.

Initially, we needed to create the model for the framework.  We moulded the model using a JSON response from the API.  To have a separation of concerns within our test framework, we would access the model through a Data Transfer Object (DTO).  The DTO allowed us to build a scalable framework from the start with low coupling between the model and the points at which we would execute requests.

We wanted to test the API directly through the DTO to make sure our requests were functioning properly, from here we created a service layer as our entry point to make and call requests.

At this point we had a service layer containing all the code. We decided to extract this layer into a call manager which would handle all the requests.  This request could then be returned and passed into the DTO.  Whilst the framework now followed the separation of concerns, and had high cohesion and low coupling, we could make it more efficient.  To do this we further added a base class from which our service layer would inherit.  This base class would  create a RestClient and execute requests with the API.

Using a constructor, once this base class is instantiated we could pass the necessary parameters to request and retrieve data from the API, and thus were well setup to proceed with testing the API.

Passing different parameters into the service would call specific methods within the call manager, based off the information we wanted to retrieve.  Each of these methods needed to be tested to ensure we were connecting with the API and retrieving the correct information. We created a test class for each separate API call we wanted to test.

### Sprint Review

We successfully created a working framework that allowed us to receive requests from our API.  It was built in a way that separates the concerns of the frameworks layers.  This makes the framework more reliable and scalable to add further functionality moving forward.  We can send requests to receive data from the majority of the APIs endpoints available to us, allowing us to conduct the required tests on these endpoints.  There are 2 endpoints we did not implement call functionality for and will be pushed for future sprints.   We actualised all our goals for this sprint.

Throughout this sprint, we discovered some inconsistencies with the API responses, they include:

- When using the longitude and latitude API call for certain cities (Birmingham), the API would seemingly randomly return one of many city ID's relating to these coordinates.  We had to test for the eventuality of any of these city ID's being returned.
- When using the API call for zip codes, the API would return the correct location (eg. 37188 would return "White House") but the ID for every call would return 0 as opposed to this locations correct ID.
- The API states that the two argument version used to query a city by name required a state code for its second parameter. After testing, this returned a NullReferenceException and we found that we could instead supply a country code which worked as intended.

During this sprint we only suffered one major problem.  Having built our framework, we were getting an error whenever we attempted to query the database.  Following a debug and careful inspection we realised that in our app.config it was necessary to have the base_url as "http://api.openweathermap.org/data/2.5" as opposed to "api.openweathermap.org.data/2.5/" that was in the API documentation.

### Sprint Retrospective

As mentioned in the review, there are 2 endpoints we haven't tested thus far.  We had planned a test the API "Bounding box" request, whereby you could retrieve the latest weather from within a specified region, but didn't have the time to achieve this.  We did investigate into the API "Cities in a Circle" request, but found the documentation difficult to implement in order to retrieve a response when exploring on Postman.

The frequent small issues with the API, coupled with documentation we didn't find particularly user friendly or comprehensive led to the framework being created slower than we'd hoped.  One observation we made once testing the API was that we potentially chose a limited API to test in the first place, due to the documentation and that the API was constrained to GET requests.  Ideally we would have liked our framework to test the spectrum of HTTP requests.

Regardless of this, we feel like we have achieved what we set out to achieve in creating a extensive test framework for the API.

As a team we worked efficiently in setting up the project, organising ourselves and progressing with the workload.  Our ability to work well in our team aided our smooth interaction with GitHub and our successful delivery of the desired progress on time.

In further sprints, we would add onto the framework the ability to test the further endpoints we were unable to test in this sprint and we would refactor the code further to create more of a reliable and scalable product.

One observation we made once testing the API was that we potentially chose a limited API to test in the first place, as we found the documentation difficult and the API was constrained to GET requests.

### SP-1 Project Board Finish

![](https://github.com/XZairX/Group-API-Mini-Project/blob/main/images/sprint-1-end.png)

### 

