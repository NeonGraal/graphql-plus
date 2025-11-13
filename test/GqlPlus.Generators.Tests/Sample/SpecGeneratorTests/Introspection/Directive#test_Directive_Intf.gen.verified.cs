//HintName: test_Directive_Intf.gen.cs
// Generated from Directive.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Directive;

public interface Itest_Directives
  : Itest_AndType
{
  public test_Directive As_Directive { get; set; }
  public test_Directives _Directives { get; set; }
}

public interface Itest_DirectivesField
  : Itest_AndTypeField
{
  public test_Directive directive { get; set; }
}

public interface Itest_Directive
  : Itest_Aliased
{
  public test_Directive _Directive { get; set; }
}

public interface Itest_DirectiveField
  : Itest_AliasedField
{
  public ICollection<test_InputParam> parameters { get; set; }
  public testBoolean repeatable { get; set; }
  public IDictionary<test_Location, testUnit> locations { get; set; }
}
