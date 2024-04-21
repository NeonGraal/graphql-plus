using System.Runtime.CompilerServices;

namespace GqlPlus.Verifier.Ast;

[SuppressMessage("Performance", "CA1822:Mark members as static")]
internal class BaseAstChecks<TAst>
{
  internal delegate TAst AstCreator();
  internal delegate TAst CreateBy<TBy>(TBy input);

  public void HashCode(AstCreator factory,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
  {
    var expected = factory()!.GetHashCode();

    var result = factory()!.GetHashCode();

    result.Should().Be(expected, factoryExpression);
  }

  public void Equality(AstCreator factory,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
  {
    var left = factory();
    var right = factory();

    var result = left!.Equals(right);

    result.Should().BeTrue(factoryExpression);

    left.Should().NotBeSameAs(right);
  }

  public void Inequality(AstCreator factory1, AstCreator factory2,
    [CallerArgumentExpression(nameof(factory1))] string factoryExpression = "")
  {
    var left = factory1();
    var right = factory2();

    var result = left!.Equals(right);

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
    var result = $"{factory()}";

    result.Should().Be(expected, factoryExpression);
  }

  public void Text(AstCreator factory, string expected, bool skipIf,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
  {
    Skip.If(skipIf);

    Text(factory, expected, factoryExpression);
  }
}
