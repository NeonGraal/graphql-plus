//HintName: Gqlp_Intro_+Global_Intf.gen.cs
// Generated from Intro_+Global.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro__Global;

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

public interface I_Directives
{
  _Directive directive { get; }
  _Type type { get; }
  _Directive As_Directive { get; }
  _Type As_Type { get; }
}

public interface I_Directive
  : I_Aliased
{
  _InputParam parameters { get; }
  Boolean repeatable { get; }
  Unit locations { get; }
}

public interface I_Setting
  : I_Named
{
  _Constant value { get; }
}
