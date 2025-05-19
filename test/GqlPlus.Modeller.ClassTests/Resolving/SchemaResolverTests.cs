namespace GqlPlus.Resolving;

public class SchemaResolverTests
  : ResolverClassTestBase<SchemaModel>
{
  private readonly IResolver<BaseTypeModel> _typeResolver;

  public SchemaResolverTests()
  {
    _typeResolver = RFor<BaseTypeModel>();
    Resolver = new SchemaResolver(_typeResolver);
  }

  protected override IResolver<SchemaModel> Resolver { get; }

  [Theory, RepeatData]
  public void Resolve_ResolvesAllTypes_AndReturnsNewSchemaModel(string name1, string name2)
  {
    TypeEnumModel type1 = new(name1, "");
    TypeUnionModel type2 = new(name2, "");

    TypeEnumModel resolved1 = new(name1, "");
    TypeUnionModel resolved2 = new(name2, "");

    _typeResolver.Resolve(type1, Context).Returns(resolved1);
    _typeResolver.Resolve(type2, Context).Returns(resolved2);

    SchemaModel model = new("", [], [], [], [type1, type2], null);

    SchemaModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .Types.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Count.ShouldBe(2),
        r => r[name1].ShouldBe(resolved1),
        r => r[name2].ShouldBe(resolved2)
      );
  }
}
