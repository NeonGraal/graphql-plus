//HintName: test_Directive_Impl.gen.cs
// Generated from Directive.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Directive;

public class test_Directives
  : test_AndType
  , Itest_Directives
{
  public Itest_Directive Directive { get; set; }
}

public class test_Directive
  : test_Aliased
  , Itest_Directive
{
  public ICollection<Itest_InputParam> Parameters { get; set; }
  public bool Repeatable { get; set; }
  public IDictionary<test_Location, GqlpUnit> Locations { get; set; }
}
