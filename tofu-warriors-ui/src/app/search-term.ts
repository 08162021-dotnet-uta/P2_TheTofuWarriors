
export interface SearchTerm {
  type: number,
  value: string
}

export interface RecipeTag {
  tagId: number;
  name: string;
  tagType: number;
}

export class TagInfo {
  static getValidTags() {
    return _validTags;
  }

  private static _labelToTag: { [key: string]: number };

  static getLabelConversions() {
    if (this._labelToTag) return this._labelToTag;
    this._labelToTag = {};
    for (let group of _validTags) {
      for (let tag of group.tags) {
        this._labelToTag[tag] = group.tagType;
      }
    }
    return this._labelToTag;
  }

  static getTagForLabel(label: string): RecipeTag {
    let converter = this.getLabelConversions();
    let result = {
      tagId: 0,
      name: label,
      tagType: converter[label]
    }
    return result;
  }
}

const _validTags: { tagType: number, label: string, tags: string[] }[] = [
  {
    tagType: 1,
    label: "Diet",
    tags: [
      "balanced",
      "high-fiber",
      "high-protein",
      "low-carb",
      "low-fat",
      "low-sodium"
    ]
  },
  {
    tagType: 2,
    label: "Health",
    tags: [
      "alcohol-free",
      "celery-free",
      "crustacean-free",
      "dairy-free",
      "DASH",
      "egg-free",
      "fish-free",
      "fodmap-free",
      "gluten-free",
      "immuno-supportive",
      "keto-friendly",
      "kidney-friendly",
      "kosher",
      "low-fat-abs",
      "low-potassium",
      "low-sugar",
      "lupine-free",
      "Mediterranean",
      "mustard-free",
      "no-oil-added",
      "paleo",
      "peanut-free",
      "pescatarian",
      "pork-free",
      "red-meat-free",
      "sesame-free",
      "shellfish-free",
      "soy-free",
      "sugar-conscious",
      "tree-nut-free",
      "vegan",
      "vegetarian",
      "wheat-free"
    ]
  },
  {
    tagType: 4,
    label: "Cuisine",
    tags: [
      "American",
      "Asian",
      "British",
      "Caribbean",
      "Central Europe",
      "Chinese",
      "Eastern Europe",
      "French",
      "Indian",
      "Italian",
      "Japanese",
      "Kosher",
      "Mediterranean",
      "Mexican",
      "Middle Eastern",
      "Nordic",
      "South American",
      "South East Asian"
    ]
  },
  {
    tagType: 5,
    label: "Dish",
    tags: [
      "Biscuits and cookies",
      "Bread",
      "Cereals",
      "Condiments and sauces",
      "Desserts",
      "Drinks",
      "Main course",
      "Pancake",
      "Preps",
      "Preserve",
      "Salad",
      "Sandwiches",
      "Side dish",
      "Soup",
      "Starter",
      "Sweets"
    ]
  },
  {
    tagType: 6,
    label: "Meal",
    tags: [
      "Breakfast",
      "Dinner",
      "Lunch",
      "Snack",
      "Teatime"
    ]
  }
  /*
  3: {
    label: "",
    tags: [
    ]
  },
  */
]

