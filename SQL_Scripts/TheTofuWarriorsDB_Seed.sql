
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
	,('kg', 'Kilogram');

INSERT INTO App.Ingredient ([Name], [Description])
VALUES ('Chicken breast', 'Skinned chicken breast'),
	('Canned Pumpkin', 'Pumpkin from a can'),
	('Jasmine Rice', 'Rice of the Jasmine variety'),
	('Green Bell Pepper', 'A bell pepper that is green'),
	('Onion', 'An onion'),
	('Garlic', 'Fresh garlic cloves'),
	('Garlic Powder', 'Powdered Garlic');