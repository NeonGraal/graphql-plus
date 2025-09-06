//HintName: Gqlp_+Global_Intf.gen.cs
// Generated from +Global.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp__Global;

public interface I_AndType
  : I_Named
{
  _Type type { get; }
  _Type As_Type { get; }
}

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

public interface I_Directives
  : I_AndType
{
  _Directive directive { get; }
  _Directive As_Directive { get; }
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
  _Value value { get; }
}
