//HintName: test_Directive_Intf.gen.cs
// Generated from Directive.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Directive;

public interface Itest_Directives
  : Itest_AndType
{
  _Directive directive { get; }
  _Directive As_Directive { get; }
}

public interface Itest_Directive
  : Itest_Aliased
{
  _InputParam parameters { get; }
  Boolean repeatable { get; }
  Unit locations { get; }
}
