
use TheTofuWarriorsDB;
go

INSERT INTO App.[User](FirstName,LastName,Email,Username,[Password])
VALUES
('Star','Cloud','star@gmail.com','starandcloud','0234'),
('Sky','Earth','sky@gmail.com','skyandearth','4321'),
('Fish','water','fish@gmail.com','fishandwater','4121'),
('Pot','Dirt','Pot@gmail.com','potanddirt','4111'),
('Tree','Green','Tree@gmail.com','treeandgreen','3333');


INSERT INTO App.Recipe (CreatorUserId, [Name], Instructions, CreationTime)
VALUES
(1, 'Meatballs and sauce', 'Mix up some meatballs and add some sauce', DATEFROMPARTS(2021, 9, 16)),
(2, 'White chicken chili', 'Cook some chicken, add stock, add beans and vegetables, then simmer and eat', DATEFROMPARTS(2021, 9, 10)),
(3, 'Burritos', 'Brown the beef, spoon into tortillas, add cheese and toppings, bake for 10 mins at 425F', DATEFROMPARTS(2021, 9, 11)),
(4, 'Turkey Club Sandwich', 'Put turkey and cheese between two slices of bread and serve. Don''t forget mayo!', DATEFROMPARTS(2021, 9, 12)),
(5, 'Garlic Bread', 'Put garlic butter on bread and bake at 375 for 20 mins', DATEFROMPARTS(2021, 9, 13)),
(5, 'Omelette', 'Scramble some eggs, fry them into a wrap, and fill it with meats, veggies, and cheese', DATEFROMPARTS(2021, 9, 14)),
(5, 'Hot dogs', 'Take a weiner and put it in the microwave for 5 mins', DATEFROMPARTS(2021, 9, 15)),
(1, 'Chicken', 'Just boil it until it is cooked', GETDATE());


-- TagType isn't defined yet, but we could start with something like
--			1 = Allergy/Diet info,
--			2 = Cuisine type (Chinese vs Italian vs American etc.),
--			3 = Recipe Type (Dinner vs Dessert vs Lunch vs 30-mins-or-less? etc)
INSERT INTO App.Tag ([Name], TagType)
VALUES
('Gluten-Free', 1),
('Non-Dairy', 1),
('Peanut-Free', 1),
('Pro-biotic', 1),
('Chinese', 2),
('Italian', 2),
('Japanese', 2),
('Thai', 2),
('Asian', 2),
('Polish', 2),
('Dessert', 3),
('Quick Meal', 3),
('Lunch', 3),
('Breakfast', 3);


--SELECT * FROM App.[User];
--SELECT * FROM App.Recipe;