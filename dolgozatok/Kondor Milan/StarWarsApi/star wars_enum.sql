CREATE TABLE ForceUsers
(
    Id INT PRIMARY KEY,
    Name NVARCHAR(100),
    OrderType NVARCHAR(10),
    Species NVARCHAR(50),
    Homeworld NVARCHAR(50),
    Era NVARCHAR(50),
    Rank NVARCHAR(50),
    LightsaberColor NVARCHAR(20),
    Master NVARCHAR(100),
    Apprentice NVARCHAR(100),
    ForceSpecialty NVARCHAR(100),
    IsAlive BIT
);

INSERT INTO ForceUsers (Id, Name, OrderType, Species, Homeworld, Era, Rank, LightsaberColor, Master, Apprentice, ForceSpecialty, IsAlive)
VALUES
(1,'Yoda',0,'Unknown','Unknown',1,3,'Green','None','Luke Skywalker','Force Wisdom',0),
(2,'Luke Skywalker',0,'Human','Tatooine',2,3,'Green','Yoda','Ben Solo','Force Projection',1),
(3,'Obi-Wan Kenobi',0,'Human','Stewjon',1,3,'Blue','Qui-Gon Jinn','Anakin Skywalker','Mind Trick',0),
(4,'Anakin Skywalker',0,'Human','Tatooine',1,2,'Blue','Obi-Wan Kenobi','Ahsoka Tano','Force Power',0),
(5,'Mace Windu',0,'Human','Haruun Kal',1,3,'Purple','None','Depa Billaba','Vaapad',0),
(6,'Ahsoka Tano',0,'Human','Shili',1,1,'Green','Anakin Skywalker','None','Force Stealth',1),
(7,'Kit Fisto',0,'Nautolan','Glee Anselm',1,3,'Green','None','None','Underwater Combat',1),
(8,'Plo Koon',0,'Kel Dor','Dorin',1,3,'Blue','None','Aayla Secura','Force Lightning Resistance',0),
(9,'Saesee Tiin',0,'Iktotchi','Iktotch',1,3,'Blue','None','None','Starfighter Combat',0),
(10,'Ki-Adi-Mundi',0,'Cerean','Cerea',1,3,'Blue','None','Stass Allie','Force Strategy',0),
(11,'Darth Sidious',1,'Human','Naboo',2,6,'Red','Darth Plagueis','Darth Vader','Force Lightning',0),
(12,'Darth Vader',1,'Human','Tatooine',2,4,'Red','Darth Sidious','None','Force Choke',0),
(13,'Darth Maul',1,'Zabrak','Dathomir',1,5,'Red','Darth Sidious','None','Double Saber',0),
(14,'Count Dooku',1,'Human','Serenno',1,4,'Red','Darth Sidious','Asajj Ventress','Force Lightning',0),
(15,'Kylo Ren',1,'Human','Chandrila',4,4,'Red','Luke Skywalker','None','Force Freeze',0),
(16,'Asajj Ventress',1,'Human','Dathomir',1,5,'Red','Count Dooku','None','Stealth',0),
(17,'Revan',0,'Human','Korriban',0,3,'Purple','None','Meetra Surik','Force Tactics',0),
(18,'Bastila Shan',0,'Human','Coruscant',0,3,'Yellow','Stark Hyperspace','None','Force Battle Meditation',0),
(19,'Exar Kun',1,'Human','Dantooine',0,6,'Red','None','None','Force Magic',0),
(20,'Malak',1,'Human','Mandalore',0,4,'Red','Exar Kun','None','Force Combat',0),
(21,'Depa Billaba',0,'Human','Korriban',1,3,'Blue','Mace Windu','None','Force Stealth',0),
(22,'Ben Solo',0,'Human','Chandrila',4,1,'Blue','Luke Skywalker','None','Force Projection',1),
(23,'Luminara Unduli',0,'Mirialan','Mirial',1,3,'Blue','None','Aayla Secura','Force Healing',0),
(24,'Aayla Secura',0,'Twi''lek','Ryloth',1,3,'Blue','Kit Fisto','None','Agility',0),
(25,'Qui-Gon Jinn',0,'Human','Coruscant',1,3,'Green','None','Obi-Wan Kenobi','Force Meditation',0);