namespace GqlPlus.Resolving;

public class AllTypesResolverTests
{
  private readonly IList<ITypeResolver> _typeResolvers;
  private readonly AllTypesResolver _resolver;

  public AllTypesResolverTests()
  {
    _typeResolvers = [];
    _resolver = new AllTypesResolver(_typeResolvers);
  }

  [Theory, RepeatData]
  public void Resolve_ReturnsResolvedType_WhenTypeResolverMatches(string name, string contents)
  {
    TypeEnumModel model = new(name, contents);
    IResolveContext context = Substitute.For<IResolveContext>();
    TypeEnumModel expected = new(name, contents);

    ITypeResolver typeResolver = Substitute.For<ITypeResolver>();
    typeResolver.ForType(model).Returns(true);
    typeResolver.ResolveType(model, context).Returns(expected);

    _typeResolvers.Add(typeResolver);

    BaseTypeModel result = _resolver.Resolve(model, context);

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void Resolve_ReturnsOriginalModel_WhenNoTypeResolverMatches(string name, string contents)
  {
    TypeEnumModel model = new(name, contents);
    IResolveContext context = Substitute.For<IResolveContext>();

    ITypeResolver typeResolver = Substitute.For<ITypeResolver>();
    typeResolver.ForType(model).Returns(false);

    _typeResolvers.Add(typeResolver);

    BaseTypeModel result = _resolver.Resolve(model, context);

    result.ShouldBe(model);
  }
}
