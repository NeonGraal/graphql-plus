using GqlPlus.Token;

namespace GqlPlus.Resolving;

public class SchemaResolverTests
{
  private readonly IResolver<BaseTypeModel> _typeResolver;
  private readonly SchemaResolver _resolver;

  public SchemaResolverTests()
  {
    _typeResolver = Substitute.For<IResolver<BaseTypeModel>>();
    _resolver = new SchemaResolver(_typeResolver);
  }

  [Theory, RepeatData]
  public void Resolve_ResolvesAllTypes_AndReturnsNewSchemaModel(string name1, string name2)
  {
    TypeEnumModel type1 = new(name1, "");
    TypeUnionModel type2 = new(name2, "");

    TypeEnumModel resolved1 = new(name1, "");
    TypeUnionModel resolved2 = new(name2, "");

    _typeResolver.Resolve(type1, Arg.Any<IResolveContext>()).Returns(resolved1);
    _typeResolver.Resolve(type2, Arg.Any<IResolveContext>()).Returns(resolved2);

    SchemaModel model = new("", [], [], [], [type1, type2], TokenMessages.New);

    IResolveContext context = Substitute.For<IResolveContext>();

    SchemaModel result = _resolver.Resolve(model, context);

    result.ShouldNotBeNull()
      .Types.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Count.ShouldBe(2),
        r => r[name1].ShouldBe(resolved1),
        r => r[name2].ShouldBe(resolved2)
      );
  }
}
