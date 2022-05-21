using System;
using System.Collections.Generic;

public class Recipe
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    public string? Book { get; set; }
    public string? Author { get; set; }

    public List<Ingredient> Ingredients { get; set; } = new();
}

public class Ingredient
{
    public string Name { get; set; } = "";
}
