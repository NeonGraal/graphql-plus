//HintName: Gqlp_Intro_Category_Intf.gen.cs
// Generated from Intro_Category.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro_Category;

public interface I_Categories
  : I_AndType
{
  _Category category { get; }
  _Category As_Category { get; }
}

public interface I_Category
  : I_Aliased
{
  _Resolution resolution { get; }
  _TypeRef<_TypeKind> output { get; }
  _Modifiers modifiers { get; }
}
