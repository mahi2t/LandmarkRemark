# LandmarkRemark

This project enables its ursers to add notes to their location and can see other remarks as well.

## Technical details

> Frontend : Angular 8 <br>
> Backend: .net core 3.0 <br>
> Database: (localDB) <br>
> IDE: Visual Studio 2019

## Framework details

> Entity Framework Core<br>
> Repository Pattern<br>
> .net core WebApi<br>
> Reactive Forms
> Rxjs

## Build

- Open the solution in VS 2019
- Restore the nuget packages.
- Run command
<strong>'update-database'</strong> to create database named "LandmarkRemark" in package manager console
- Navigate to angular app i.e. "ClientApp" and install node_modules (command: npm install) (if visual studio unable to install the dependencies)

## Launch application

To launch the app, simply run the application from visual studio.

- create user by clicking Register link. upon successful registration gets redirected to login page.
- Login takes to dashboard where user can add remarks
- Click the desired location in the map and provide the notes and click "Add Remark" button which saves the location coordinates to database and Marker gets created on the map.
- Click on the marker to see the note added by user.

## Efforts
 - Frontend 4.5 hours
 - Backend 3.5 hours
 - Tests 1 hour


 ***Note: Update the google maps api key with valid one.*** <br>
 Replace the "Api-key" with valid value in  ~/LandmarkRemark/LandmarkRemark/ClientApp/src/app/landmark/landmark.module.ts
