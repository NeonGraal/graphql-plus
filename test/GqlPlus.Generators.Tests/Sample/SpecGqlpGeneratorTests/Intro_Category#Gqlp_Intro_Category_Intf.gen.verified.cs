//HintName: Gqlp_Intro_Category_Intf.gen.cs
// Generated from Intro_Category.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro_Category;

public interface I_Categories
{
  _Category category { get; }
  _Type type { get; }
  _Category As_Category { get; }
  _Type As_Type { get; }
}

public interface I_Category
  : I_Aliased
{
  _Resolution resolution { get; }
  _TypeRef<_TypeKind> name { get; }
  _Modifiers modifiers { get; }
}
