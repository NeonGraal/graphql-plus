//HintName: test_Directive_Impl.gen.cs
// Generated from Directive.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Directive;

public class Outputtest_Directives
  : Outputtest_AndType
  , Itest_Directives
{
  public _Directive directive { get; set; }
  public _Directive As_Directive { get; set; }
}

public class Outputtest_Directive
  : Outputtest_Aliased
  , Itest_Directive
{
  public _InputParam parameters { get; set; }
  public Boolean repeatable { get; set; }
  public Unit locations { get; set; }
}
