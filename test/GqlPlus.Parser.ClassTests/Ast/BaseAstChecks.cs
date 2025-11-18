namespace GqlPlus.Ast;

#pragma warning disable CA1822 // Mark members as static
internal class BaseAstChecks<TAst>
{
  internal delegate TAst AstCreator();
  internal delegate TAst CreateBy<TBy>(TBy input);
  internal delegate TAst CloneBy<TBy>(TAst original, TBy input);

  public void HashCode(AstCreator factory,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
  {
    int expected = factory().ThrowIfNull().GetHashCode();

    int result = factory().ThrowIfNull().GetHashCode();

    result.ShouldBe(expected, factoryExpression);
  }

  public void Equality(AstCreator factory1, AstCreator factory2,
    [CallerArgumentExpression(nameof(factory1))] string factory1Expression = "",
    [CallerArgumentExpression(nameof(factory2))] string factory2Expression = "")
  {
    TAst? left = factory1();
    TAst? right = factory2();

    bool result = left.ThrowIfNull().Equals(right);

    result.ShouldSatisfyAllConditions(
      () => result.ShouldBeTrue(factory1Expression),
      () => left.ShouldNotBeSameAs(right, factory2Expression));
  }

  public void Equality(AstCreator factory,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
    => Equality(factory, factory, factoryExpression, factoryExpression);

  public void Inequality(AstCreator factory1, AstCreator factory2,
    [CallerArgumentExpression(nameof(factory1))] string factory1Expression = "",
    [CallerArgumentExpression(nameof(factory2))] string factory2Expression = "")
  {
    TAst? left = factory1();
    TAst? right = factory2();

    bool result = left.ThrowIfNull().Equals(right);

    result.ShouldSatisfyAllConditions(
      () => result.ShouldBeFalse(factory1Expression),
      () => left.ShouldNotBeSameAs(right, factory2Expression));
  }

  public void Inequality(AstCreator factory1, AstCreator factory2, bool skipIf,
    [CallerArgumentExpression(nameof(factory1))] string factory1Expression = "",
    [CallerArgumentExpression(nameof(factory2))] string factory2Expression = "",
    [CallerArgumentExpression(nameof(skipIf))] string skipIfExpression = "")
  {
    Assert.SkipWhen(skipIf, skipIfExpression);

    Inequality(factory1, factory2, factory1Expression, factory2Expression);
  }

  public void InequalityBetween<TBy>(TBy input1, TBy input2, CreateBy<TBy> factory,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
    => Inequality(() => factory(input1), () => factory(input2), factoryExpression);

  public void InequalityBetween<TBy>(TBy input1, TBy input2, CreateBy<TBy> factory, bool skipIf,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "",
    [CallerArgumentExpression(nameof(skipIf))] string skipIfExpression = "")
    => Inequality(() => factory(input1), () => factory(input2), skipIf, factoryExpression, factoryExpression, skipIfExpression);

  public void Text(AstCreator factory, string expected,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "")
  {
    string result = $"{factory()}";

    result.ShouldBe(expected, factoryExpression);
  }

  public void Text(AstCreator factory, string expected, bool skipIf,
    [CallerArgumentExpression(nameof(factory))] string factoryExpression = "",
    [CallerArgumentExpression(nameof(skipIf))] string skipIfExpression = "")
  {
    Assert.SkipWhen(skipIf, skipIfExpression);

    Text(factory, expected, factoryExpression);
  }
}
