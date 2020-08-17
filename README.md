# Race track app
# Assumption:
- There's only one race at the time

# Implemetation:
- Front-end
  - Angular to display simple form to add new vehicle
  - race-track.service.ts is injected in the component to handles essential requests to load & create vehicle
  - to keep it simple, validation is done in back end
  
- Back-end
  - .Net Core Api
    - Controllers have their db context injected so that they don't have to worry about how to create the context.
    - As for now, they handle DB operations which we can do better by using Microservies pattern by moving those operation into their own services to reduce the weight of the controllers.
  - Code first Entiry Framework
    - Database context and its initializer is placed under RaceApp\DAL.
    - Vehicle model:
      - Store participant info and its validation.
      - To use composition for inspection types, instead of have 2 different models: Truck and Car inherit from Vehicle to have their own inspection type. By using composition, it makes it easier to update or expand when there're more many different vehicle types.
    - Track model store track's info and its validation
