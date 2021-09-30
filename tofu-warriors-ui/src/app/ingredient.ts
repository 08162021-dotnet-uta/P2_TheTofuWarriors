
export interface MeasureUnit {
  measureUnitId: number;
  unit: string;
  description: string;
}

export interface Ingredient {
  ingredientId: number;
  ingredientName: string;
  ingredientDescription: string;
  quantity: number;
  measureUnitId: number;
  measureUnit: MeasureUnit | null;

  /*
  public int RecipeIngredientId { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public int Quantity { get; set; }
        public int MeasureUnitId { get; set; }

		/************************* "Extension" properties for returning extra data from controllers ************************** /
		public string IngredientName { get; set; }
		public string IngredientDescription { get; set; }
		public string MeasureUnit { get; set; }
		public string MeasureDescription { get; set; }
*/
}
