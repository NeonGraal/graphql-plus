using System.Runtime.CompilerServices;

namespace GqlPlus.Verifier.Ast;

internal class BaseAstChecks<I, T>
{
  internal delegate T Creator();
  internal delegate T CreateBy<B>(B input);

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

  public void InequalityBetween<B>(B input1, B input2, CreateBy<B> factory, bool skipIf,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
    => Inequality(() => factory(input1), () => factory(input2), skipIf, factoryExpression);

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
