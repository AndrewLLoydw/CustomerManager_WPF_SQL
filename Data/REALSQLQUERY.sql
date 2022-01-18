DROP TABLE Customers
DROP TABLE Addresses
DROP TABLE CustomerErrands

CREATE TABLE CustomerErrands (
	Id int not null identity primary key,
	ErrandTitle nvarchar(100) not null,
	ErrandDescription nvarchar(100) not null,
	ErrandCreatedTime nvarchar(20) not null,
	ErrandChangedTime nvarchar(20) not null,
	ErrandStatus nvarchar(20) not null
)

CREATE TABLE Addresses (
	Id int not null identity primary key,
	StreetName nvarchar(100) not null,
	StreetNumber int not null,
	PostalCode char(5) not null,
	City nvarchar (50) not null,
	Country nvarchar(50) not null
)
GO

CREATE TABLE Customers (
	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email nvarchar(50) not null unique,
	PhoneNumber char(10) not null unique,
	AddressId int not null references Addresses(Id),
	ErrandId int references CustomerErrands(Id)
)
