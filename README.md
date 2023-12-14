# naturdanmark-api
Backend solution for REST service for NaturDanmark Exam project.
<br>
https://mapnaturetest324842390482903.azurewebsites.net/map.html <br>
**NOTICE**
_______________________________________________________
This is for a school project, just for fun no serious use intended.
All information you upload to an observation will be displayed on the map 
_______________________________________________________

Backend implemented with C#
[Front end implemented with  JS , HTML , CSS, (Also used : Bootstrap, Vue , Axios)](https://github.com/eudk/map)
_______________________________________________________
- [Selenium tests](https://github.com/eudk/naturdanmark-tests)
- Unittests in the C# code (For model and repository classes) / Testfirst used on most occasions
- Manual usertests done a few times
- POSTMAN tests done
- Continuous deployment used with Github


**Examples of Unittests from the code:**

 ```
   [TestMethod()]
        public void ValidateLongitudeTest()
        {
            Observation obs1 = new Observation { AnimalName = "animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = 181 };
            Observation obs2 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = -181 };
            Observation obs3 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = 180 };
            Observation obs4 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = -180 };
            Observation obs5 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = -180.1 };
            Observation obs6 = new Observation { AnimalName = "Animal", ID = 1, Picture = null, Date = DateTime.Now, Description = null, Latitude = 0, Longitude = 180.1 };
            obs3.ValidateLongitude();
            obs4.ValidateLongitude();
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=> obs1.ValidateLongitude());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs2.ValidateLongitude());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs5.ValidateLongitude());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => obs6.ValidateLongitude());

        }
``` 
_______________________________________________________
[Client / Server code w. UDP](https://github.com/eudk/naturdanmark-raspberrypi)
<img src="https://download.logo.wine/logo/Raspberry_Pi/Raspberry_Pi-Logo.wine.png" alt="logo" style="height: 50px;">

_______________________________________________________
**The Webapp allows you to see and create observations of animals**

By creating new observations you send the following data to a REST service:
- NAME
- LOCATION (SELECTED MANUALLY ON A MAP, OR TRACKED WITH RASPBERRY PI GPS (DATA SENT FROM CLIENT TO SERVER (REST))
- ANIMAL NAME (SELECTED FROM THE ANIMAL API)
- PHOTO  (Photo stored as BASE64 in seperate table)
- DESCRIPTION
- Upload time Automatically
- Observation date and time (automatic or manually selected)
________________________________________________________

**API's used**

Animals API: (Limited to 10.000 free API calls/month)
https://api-ninjas.com/api/animals

Map API & external JS: (Unlimited use)
https://leafletjs.com/index.html


API for converting coordinates to cities: (Unlimited use)
https://www.bigdatacloud.com/free-api/free-reverse-geocode-to-city-api

Own REST service for Animal Observations: (Unlimited use) / Deployement of this repository!
https://naturdanmark-api20231124193012.azurewebsites.net/Api/Observation
<img src="https://download.logo.wine/logo/Microsoft_Azure/Microsoft_Azure-Logo.wine.png" alt="logo" style="height: 50px;">

_________________________________________________________________

Database on Simply.com (Limited to 20GB est. 1000 observations with photos)
<img src="https://cdn.freebiesupply.com/logos/large/2x/amazon-database-logo-black-and-white.png" alt="logo" style="height: 50px;">

**Table content in Database:**
Photo table (FOr BASE64 formated photos) 
Method for conversion from Photo to Base64 is done in the front end code with Vue js [here)](https://github.com/eudk/map)

 ```
CREATE TABLE [dbo].[observationphotos] (
[id] INT IDENTITY (1, 1) NOT NULL,
[photo] VARCHAR (MAX) NULL,
[observationid] INT NULL,
PRIMARY KEY CLUSTERED ([id] ASC),
FOREIGN KEY ([observationid]) REFERENCES [dbo].[Observations]
([Id])
);
```
Observation table 
```
CREATE TABLE [dbo].[Observations] (
[Id] INT IDENTITY (1, 1) NOT NULL,
[AnimalName] VARCHAR (90) NOT NULL,
[Date] DATETIME NOT NULL,
[Description] VARCHAR (1000) NULL,
[Longitude] FLOAT (53) NOT NULL,
[Latitude] FLOAT (53) NOT NULL,
[Picture] VARCHAR (100) NULL,
[PostingDate] DATETIME NULL,
[UserName] VARCHAR (100) NOT NULL,
PRIMARY KEY CLUSTERED ([Id] ASC)
);
 
 ``` 
_________________________________________________________________


