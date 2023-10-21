using System.Runtime.CompilerServices;

namespace GqlPlus.Verifier.Ast;

internal class BaseAstChecks<T>
{
  internal delegate T Creator();
  internal delegate T CreateByName(string name);

  public void HashCode(Creator factory,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
  {
    var expected = factory()!.GetHashCode();

    var result = factory()!.GetHashCode();

    result.Should().Be(expected, factoryExpression);
  }

  public void Equality(Creator factory,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
  {
    var left = factory();
    var right = factory();

    var result = left!.Equals(right);

    result.Should().BeTrue(factoryExpression);

    left.Should().NotBeSameAs(right);
  }

  public void Inequality(Creator factory1, Creator factory2, bool skipIf = false,
    [CallerArgumentExpression(nameof(factory1))] string factoryExpression = "")
  {
    if (skipIf) {
      return;
    }

    var left = factory1();
    var right = factory2();

    var result = left!.Equals(right);

    result.Should().BeFalse(factoryExpression);

    left.Should().NotBeSameAs(right);
  }

  public void InequalityBetween(string name1, string name2, CreateByName factory,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
    => Inequality(() => factory(name1), () => factory(name2), name1 == name2, factoryExpression);

  public void String(Creator factory, string expected, bool skipIf = false,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
  {
    if (skipIf) {
      return;
    }

    var result = $"{factory()}";

    result.Should().Be(expected, factoryExpression);
  }
}
