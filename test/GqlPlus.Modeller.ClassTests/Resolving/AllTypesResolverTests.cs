namespace GqlPlus.Resolving;

public class AllTypesResolverTests
  : ResolverClassTestBase<BaseTypeModel>
{
  private readonly IList<ITypeResolver> _typeResolvers;

  protected override IResolver<BaseTypeModel> Resolver { get; }

  public AllTypesResolverTests()
  {
    _typeResolvers = [];
    Resolver = new AllTypesResolver(_typeResolvers);
  }

  [Theory, RepeatData]
  public void Resolve_ReturnsResolvedType_WhenTypeResolverMatches(string name, string contents)
  {
    TypeEnumModel model = new(name, contents);
    TypeEnumModel expected = new(name, contents);

    ITypeResolver typeResolver = Substitute.For<ITypeResolver>();
    typeResolver.ForType(model).Returns(true);
    typeResolver.ResolveType(model, Context).Returns(expected);

    _typeResolvers.Add(typeResolver);

    BaseTypeModel result = Resolver.Resolve(model, Context);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void Resolve_ReturnsOriginalModel_WhenNoTypeResolverMatches(string name, string contents)
  {
    TypeEnumModel model = new(name, contents);
    ITypeResolver typeResolver = Substitute.For<ITypeResolver>();
    typeResolver.ForType(model).Returns(false);

    _typeResolvers.Add(typeResolver);

    BaseTypeModel result = Resolver.Resolve(model, Context);

    result.ShouldBe(model);
  }
}
