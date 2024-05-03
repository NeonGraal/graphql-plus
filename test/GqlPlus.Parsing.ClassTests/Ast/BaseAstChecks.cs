using System.Runtime.CompilerServices;

namespace GqlPlus.Ast;

#pragma warning disable CA1822 // Mark members as static
internal class BaseAstChecks<TAst>
{
  internal delegate TAst AstCreator();
  internal delegate TAst CreateBy<TBy>(TBy input);

  public void HashCode(AstCreator factory,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
  {
    int expected = factory()!.GetHashCode();

    int result = factory()!.GetHashCode();

    result.Should().Be(expected, factoryExpression);
  }

  public void Equality(AstCreator factory,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
  {
    TAst? left = factory();
    TAst? right = factory();

    bool result = left!.Equals(right);

    result.Should().BeTrue(factoryExpression);

    left.Should().NotBeSameAs(right);
  }

  public void Inequality(AstCreator factory1, AstCreator factory2,
    [CallerArgumentExpression(nameof(factory1))] string factoryExpression = "")
  {
    TAst? left = factory1();
    TAst? right = factory2();

    bool result = left!.Equals(right);

    result.Should().BeFalse(factoryExpression);

    left.Should().NotBeSameAs(right);
  }

  public void Inequality(AstCreator factory1, AstCreator factory2, bool skipIf,
    [CallerArgumentExpression(nameof(factory1))] string factoryExpression = "")
  {
    Skip.If(skipIf);

    Inequality(factory1, factory2, factoryExpression);
  }

  public void InequalityBetween<TBy>(TBy input1, TBy input2, CreateBy<TBy> factory,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
    => Inequality(() => factory(input1), () => factory(input2), factoryExpression);

  public void InequalityBetween<TBy>(TBy input1, TBy input2, CreateBy<TBy> factory, bool skipIf,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
    => Inequality(() => factory(input1), () => factory(input2), skipIf, factoryExpression);

  public void Text(AstCreator factory, string expected,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
  {
    string result = $"{factory()}";

    result.Should().Be(expected, factoryExpression);
  }

  public void Text(AstCreator factory, string expected, bool skipIf,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
  {
    Skip.If(skipIf);

    Text(factory, expected, factoryExpression);
  }
}
