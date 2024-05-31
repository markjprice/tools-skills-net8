# Template Method pattern

The **Template Method** pattern defines the skeleton of an algorithm in the superclass but allows its subclasses to override specific steps of the algorithm without changing its structure. This pattern is particularly useful when multiple classes share a common method but have different implementations of some steps in that method. By using the Template Method pattern, you can encapsulate the invariant parts of the algorithm in a base class and let subclasses implement the variant parts.

Components of the Template Method pattern:
- **Template**: Defines abstract methods for the steps that need to be customized and implements the template method defining the skeleton of an algorithm. The template method calls the abstract methods, as well as other methods.
- **Concrete Classes**: Implements the abstract methods to complete the algorithm's specific steps.

Let's illustrate the Template Method pattern with an example of cooking recipes. Suppose we have a general process for cooking a meal, but the details vary depending on the specific meal being prepared.

First, define the abstract class with the template method aka the Template, as shown in the following code:
```cs
public abstract class CookingRecipe
{
  // Template method.
  public void CookMeal()
  {
    PrepareIngredients();
    Cook();
    Serve();
  }

  protected abstract void PrepareIngredients();
  protected abstract void Cook();
    
  // Common method used by all subclasses.
  protected void Serve()
  {
    WriteLine("Serving the meal.");
  }
}
```

Next, implement Concrete Classes for specific meals, as shown in the following code:
```cs
public class PastaRecipe : CookingRecipe
{
  protected override void PrepareIngredients()
  {
    WriteLine("Preparing pasta and sauce.");
  }

  protected override void Cook()
  {
    WriteLine("Cooking pasta in boiling water.");
  }
}

public class SaladRecipe : CookingRecipe
{
  protected override void PrepareIngredients()
  {
    WriteLine("Chopping vegetables.");
  }

  protected override void Cook()
  {
    WriteLine("Mixing vegetables with dressing.");
  }
}
```

Finally, demonstrate the Template Method in action, as shown in the following code:
```cs
CookingRecipe pasta = new PastaRecipe();
pasta.CookMeal();

CookingRecipe salad = new SaladRecipe();
salad.CookMeal();
```

In this example, `CookingRecipe` defines the template method `CookMeal()` that outlines the steps for cooking a meal. The steps `PrepareIngredients()` and `Cook()` are declared as abstract methods, forcing subclasses like `PastaRecipe` and `SaladRecipe` to provide their own implementations for these steps. The `Serve()` method is a concrete implementation within the abstract class because it's common across all subclasses.

This setup allows the subclasses to alter parts of the algorithm by overriding certain steps without changing the algorithm's structure defined by the template method. The Template Method pattern is beneficial for enforcing a certain structure while allowing flexibility in the details of the execution.

[Previous: Chain of Responsibility](chain-of-responsibility.md)
[Parent: Behavioral patterns](behavioral.md)
