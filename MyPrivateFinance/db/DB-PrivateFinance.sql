create database privatefinance

use privatefinance

create table Categories (
	Id int identity(1,1) not null,
	Name varchar(60)
	constraint pk_categories primary key (Id)
)

create table Payments(
	Id int identity(1,1) not null,
	Description varchar(100),
	Date datetime,
	Amount float,
	IsIncome bit,
	CategoryId int not null,
	Constraint pk_payments primary key (id),
	constraint fk_categories foreign key (CategoryId) references Categories (id)
)

insert into Categories(Name) Values 
	('Salary'),
	('Meal'),
	('Fun'),
	('Car');

select * from Categories

insert into Payments(Description, Date, Amount, IsIncome, CategoryId) Values 
	('Salary 12.16', '16-12-23', 4300, 1, 1),
	('Hot Dog', '16-12-28', 8.00, 0, 2),
	('Pizza', '16-12-30', 20.00, 0, 2),
	('Skiing', '17-01-02', 130.00, 0, 3),
	('Salary 1.17', '17-01-26', 4300, 1, 1),
	('Fuel', '17-01-27', 90.00, 0, 4);
	
select * from Payments