//HintName: Gqlp_Intro_Directive_Intf.gen.cs
// Generated from Intro_Directive.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro_Directive;

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
