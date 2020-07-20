# Async-Inn

# Console Application README Example

## Databases & ERDs

Lab-Async-Inn

*Authors: Lesley Rivera, Yasir Mohamud, Lami Beach, Trevor Stubbs
----

## Description
This is a C# console application that will ask a user several questions about me, the
developer. There are multiple question types ranging from inputting a number to True or False.
At the end of the game the user receives their total score.

---

### Getting Started
Clone this repository to your local machine.

```
$ git clone [https://github.com/les1208/Async-Inn.git]
```

### To run the program from Visual Studio:
Select ```File``` -> ```Open``` -> ```Project/Solution```

Next navigate to the location you cloned the Repository.

Double click on the ```Async-Inn``` directory. ```

---

### Entity Relationship Diagram
![Image1](https://https://github.com/les1208/Async-Inn/blob/master/assets/%5BERD%5DAsyncInn.pdf)



* Async Inn - Table 1:
The table holds the primary key ID. You could do without the first table, however, you can’t start a table with many to many. You need one to many. 

* Hotel Locations - Table 2:
The table holds a primary key for the hotel location and a foreign key of the Async Inn ID as the Hotel Location references Async Inn. It has the properties of name, city, state, address, and phone number.
Navigation: Hotel Rooms, Async Inn


* Hotel Rooms(Joint Entity Table with Payload) - Table 3:
Has a composite key/foreign key of HotelID as it references Hotel Locations. It also has a composite key of RoomNumbers which is specific to the rooms. It references the Price and whether PetsFriendly as the payload.
Navigation: Hotel Location, Room.


* Room - Table 4:
This table has a primary key of ID as its reference. It contains the properties of Nicknames of hotel rooms, Layout which is an enum to determine how many bedrooms.
Navigation: Hotel Rooms, Room Amenities.

* Enum Layout (Enum) - Table 5:
The enum Layout table contains the properties of studio set equal to zero, one bedroom equal to one, two bedrooms  equal to two, and three bedrooms equal to three. These properties specify the number of rooms to pick from. 
	

* Amenities - Table 6:
This table has a primary key of ID for its reference. The property is the Name of the amenities. 
Room Amenities.


* Room Amenities (Pure Joint Entity Table) - Table 7:
The table contains a composite key/foreign key of the RoomID as to reference the Room table. It also has a composite key/foreign key of AmenitiesID as to reference the actual amenities. 
Navigation: Room, Amenities.


---

### Change Log
1.1: *App created* - 20 July 2020*


------------------------------
For more information on Markdown: https://www.markdownguide.org/cheat-sheet