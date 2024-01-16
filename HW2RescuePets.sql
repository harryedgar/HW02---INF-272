Use Master
Go

If Exists (Select * from sys.databases where name = 'PetsDB')
DROP DATABASE PetsDB
Go

Create Database PetsDB
Go

Use PetsDB
Go

create table [User](
UserID int Identity (1,1) Primary key not null,
FullName varchar (255) not null,
Phone int
)
go 

create table Donation(
DonationID int Identity (1,1) Primary key not null,
DonationAmount decimal(10,2),
UserID int references [User](UserID)
)
go

Create table Breed(
BreedID int Identity (1,1) Primary key not null,
BreedDescription varchar (255) not null
)
go

Create table Gender(
GenderID int Identity (1,1) Primary key not null,
GenderDescription varchar (255) not null
)
go

Create table [Location](
LocationID int Identity (1,1) Primary key not null,
LocationDescription varchar (255) not null
)
go

Create table AdoptionStatus(
StatusID int Identity (1,1) Primary key not null,
StatusDescription varchar (255) not null
)
go

Create table PetType(
TypeID int Identity (1,1) Primary key not null,
TypeDescription varchar (255) not null
)
go

Create table Pets(
PetID int Identity (1,1) Primary key not null,
PetName varchar (255) not null,
PetAge int,
PetWeight decimal(10,2),
PetImage nvarchar(max),
PetStory varchar(255),
PetFullStory varchar(255),
TypeID int references PetType(TypeID),
StatusID int references AdoptionStatus(StatusID),
GenderID int references Gender(GenderID),
BreedID int references Breed(BreedID),
LocationID int references [Location](LocationID),
UserID int references [User](UserID)
)
go

Create table Adoption(
AdoptionID int Identity (1,1) Primary key not null,
PetID int references Pets(PetID),
UserID int references [User](UserID)
)
go

insert into [User] values
('Harry Edgar', 0833771827),
('Amy Trawin', 0837289960),
('Lwandile Ngece', 0659320085),
('Emihle Manyoni', 0608757909),
('Brad Becker', 0718513924),
('Connor Andrew', 0762886044),
('Thomas Schmidt', 0834675892),
('Cameron Banks', 0702746528),
('Amy Carey', 0839627583),
('Choloe Launder', 0836478935)

insert into Donation values
(152.50,1),
(1000,2),
(1345,3),
(340.50,4),
(156.70,5),
(784.50,6),
(150.78,7),
(400.56,8),
(450.60,9),
(150.40,10)


insert into Breed values
('Golden Retriever'),
('African Grey'),
('Fantail'),
('Roborovski Dwarf'),
('Panther'),
('Red-Eared Slider'),
('Albino'),
('Abyssinian pig'),
('Boa Constrictor'),
('Scottish Fold')

insert into Gender values
('Male'),
('Female'),
('Male'),
('Male'),
('Female'),
('Female'),
('Female'),
('Male'),
('Female'),
('Female')

insert into [Location] values
('Greenside'),
('Parkhurst'),
('Radnburg'),
('Sandton'),
('Shefield'),
('Spain'),
('Hatfield'),
('Cradock'),
('Linksfield'),
('Illovo')


insert into AdoptionStatus values
('Available'),
('Adopted'),
('Available'),
('Available'),
('Adopted'),
('Available'),
('Adopted'),
('Available'),
('Adopted'),
('Available')

insert into PetType values
('Dog'),
('Parrot'),
('GoldFIsh'),
('Hamster'),
('Chamelon'),
('Turtle'),
('Ferret'),
('Guinea pig'),
('Snake'),
('Cat')

insert into Pets values
('Champ', 10, 22.53,'goldenretriever.jpeg','','Champ is a golden retriever and is 10 years old he likes to play catch and love his family and lives in greenside and goes for walks at the dam nearby',1,1,1,1,1,1),
('Polly', 3, 1.53,'Africangrey.jpeg','','A mischievous parrot named Polly delighted in mimicking her owners voice, often leading to hilarious confusion in their household',2,2,2,2,2,2),
('Max', 2, 0.53,'Faintail.jpeg','','Max, the adventurous goldfish, explored his watery world with zest, discovering new corners of his tank every day.',3,1,1,3,3,3),
('Luna', 4, 2.60,'Roborovski.jpeg','','Luna, the graceful ballerina hamster, twirled and pirouetted on her tiny wheel, bringing joy to everyone who watched her dance.',4,1,1,4,4,4),
('Rocky', 5, 3.50,'Pantherchameleon.jpeg','','Rocky, the brave chameleon, changed colors to blend into his surroundings, making him the ultimate hide-and-seek champion.',5,2,2,5,5,5),
('Whiskers', 2, 8.83,'Redearedslider.jpeg','','Whiskers, the curious turtle, embarked on a slow but steady journey through life, savoring every moment in his cozy terrarium.',6,1,2,6,6,6),
('Oreo', 1, 2.42,'albinoferret.jpeg','','Oreo, the mischievous ferret, loved to burrow into hidden nooks and crannies, always keeping his owners on their toes.',7,2,2,7,7,7),
('Sparkle', 3, 1.50,'Abyssinian.jpeg','','Sparkle, the pampered guinea pig, enjoyed luxurious spa days complete with miniature cucumber facials and massages.',8,1,1,8,8,8),
('Ziggy', 6, 7.73,'Boaconstrictor.jpeg','','Ziggy, the talkative snake, fascinated his owner with his hissing serenades and cryptic riddles.',9,2,2,9,9,9),
('Raffel', 12, 4.53,'Scottishfold.jpeg','','Raffel, the nocturnal sugar glider, glided gracefully through the night sky, casting tiny shadows that danced on the walls, enchanting her owners.',10,1,2,10,10,10)


insert into Adoption values
(2,2),
(5,5),
(7,7),
(9,9)