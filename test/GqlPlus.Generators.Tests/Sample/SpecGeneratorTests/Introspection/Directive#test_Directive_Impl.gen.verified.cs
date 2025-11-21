//HintName: test_Directive_Impl.gen.cs
// Generated from Directive.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Directive;

public class test_Directives
  : test_AndType
  , Itest_Directives
{
  public test_Directive directive { get; set; }
  public test_Directive As_Directive { get; set; }
  public test_Directives _Directives { get; set; }
}

public class test_Directive
  : test_Aliased
  , Itest_Directive
{
  public ICollection<test_InputParam> parameters { get; set; }
  public testBoolean repeatable { get; set; }
  public IDictionary<test_Location, testUnit> locations { get; set; }
  public test_Directive _Directive { get; set; }
}
