
--SELECT * FROM App.MeasureUnit;
--SELECT * FROM App.Ingredient;

use TheTofuWarriorsDB;
go

INSERT INTO App.MeasureUnit (Unit, [Description])
VALUES ('tsp', 'Teaspoon')
	,('tbsp', 'Tablespoon')
	,('1/2 tsp', 'One-Half of one Teaspoon')
	,('1/4 tsp', 'One-Quarter of one Teaspoon')
	,('1/4 cup', 'One-Quarter of one Cup')
	,('1/3 cup', 'One-Third of one Cup')
	,('1/2 cup', 'One-Half of one Cup')
	,('cloves', 'One clove of garlic')
	,('mL', 'Milliliter')
	,('L', 'Liter')
	,('g', 'Gram')
	,('oz', 'Ounce')
	,('fl oz', 'Fluid Ounce')
	,('lb', 'Pound')
	,('kg', 'Kilogram')
	,('cup', 'One Cup');

INSERT INTO App.Ingredient ([Name], [Description])
VALUES
('Chicken breast', 'Skinned chicken breast'),
('Canned Pumpkin', 'Pumpkin from a can'),
('Jasmine Rice', 'Rice of the Jasmine variety'),
('Green Bell Pepper', 'A bell pepper that is green'),
('Onion', 'An onion'),
('Garlic', 'Fresh garlic cloves'),
('Ground Beef', '80/20 ground beef'),
('Banana', 'Fresh banana'),
('Pork', 'Any cut of pork'),
('Bacon', 'mmmm bacon'),
('Cheese', 'Any variety of cheese'),
('Beer', 'Probably something light'),
('Ketchup', 'Who doesn''t use ketchup?'),
('Mayonnaise', 'I hope I spelled mayonnaise right'),
('Bread', 'Sliced bread'),
('Anchovies', 'Fish'),
('Pizza dough', 'Dough for making pizzas'),
('Salt', 'Iodized salt'),
('Pepper', 'Ground black peppercorns'),
('Garlic Butter', 'Garlic flavored butter, YUM'),
('Garlic Powder', 'Powdered Garlic');


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

INSERT INTO App.RecipeIngredient (RecipeId, IngredientId, Quantity, MeasureUnitId)
VALUES
(1, 1, 1, 14),
(2, 1, 2, 14),
(2, 5, 1, 16),
(3, 5, 1, 16),
(4, 4, 2, 16),
(5, 7, 5, 12),
(6, 6, 2, 8),
(7, 1, 18, 12),
(8, 1, 2, 14);


-- TagType isn't defined yet, but we could start with something like
--			1 = Allergy/Diet info,
--			2 = Cuisine type (Chinese vs Italian vs American etc.),
--			3 = Recipe Type (Dinner vs Dessert vs Lunch vs 30-mins-or-less? etc)
INSERT INTO App.Tag ([Name], TagType)
VALUES
('balanced', 1),
('high-fiber', 1),
('high-protein', 1),
('low-carb', 1),
('low-fat', 1),
('low-sodium', 1),
('alcohol-free', 2),
('celery-free', 2),
('crustacean-free', 2),
('dairy-free', 2),
('DASH', 2),
('egg-free', 2),
('fish-free', 2),
('fodmap-free', 2),
('gluten-free', 2),
('immuno-supportive', 2),
('keto-friendly', 2),
('kidney-friendly', 2),
('kosher', 2),
('low-fat-abs', 2),
('low-potassium', 2),
('low-sugar', 2),
('lupine-free', 2),
('Mediterranean', 2),
('mustard-free', 2),
('no-oil-added', 2),
('paleo', 2),
('peanut-free', 2),
('pescatarian', 2),
('pork-free', 2),
('red-meat-free', 2),
('sesame-free', 2),
('shellfish-free', 2),
('soy-free', 2),
('sugar-conscious', 2),
('tree-nut-free', 2),
('vegan', 2),
('vegetarian', 2),
('wheat-free', 2),
('American', 4),
('Asian', 4),
('British', 4),
('Caribbean', 4),
('Central Europe', 4),
('Chinese', 4),
('Eastern Europe', 4),
('French', 4),
('Indian', 4),
('Italian', 4),
('Japanese', 4),
('Kosher', 4),
('Mediterranean', 4),
('Mexican', 4),
('Middle Eastern', 4),
('Nordic', 4),
('South American', 4),
('South East Asian', 4),
('Biscuits and cookies', 5),
('Bread', 5),
('Cereals', 5),
('Condiments and sauces', 5),
('Desserts', 5),
('Drinks', 5),
('Main course', 5),
('Pancake', 5),
('Preps', 5),
('Preserve', 5),
('Salad', 5),
('Sandwiches', 5),
('Side dish', 5),
('Soup', 5),
('Starter', 5),
('Sweets', 5),
('Breakfast', 6),
('Dinner', 6),
('Lunch', 6),
('Snack', 6),
('Teatime', 6);

INSERT INTO App.Comment(UserId,RecipeId,CommentText,CommentTime)
VALUES(1,1,'So delicious!',GETDATE()),
    (3,1,'So good!',GETDATE()),
        (1,1,'Very good !',GETDATE()),
        (2,1,'So delicious!',GETDATE()),
        (4,1,'Good Stuff!',GETDATE()),
        (5,1,'So delicious!',GETDATE());

INSERT INTO App.Comment(UserId,RecipeId,CommentText,CommentTime,PrevCommentId)
VALUES
    (2,1,'So good!',GETDATE(),3),
        (3,1,'Very good !',GETDATE(),2),
        (5,1,'So delicious!',GETDATE(),4),
        (1,1,'Good Stuff!',GETDATE(),5),
    (4,1,'So delicious!',GETDATE(),1); 