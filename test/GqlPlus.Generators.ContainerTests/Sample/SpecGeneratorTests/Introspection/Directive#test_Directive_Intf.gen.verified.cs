//HintName: test_Directive_Intf.gen.cs
// Generated from Directive.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Directive;

public interface Itest_Directives
  : Itest_AndType
{
  public Itest_Directive As_Directive { get; set; }
  public Itest_DirectivesObject As_Directives { get; set; }
}

public interface Itest_DirectivesObject
  : Itest_AndTypeObject
{
  public Itest_Directive Directive { get; set; }
}

public interface Itest_Directive
  : Itest_Aliased
{
  public Itest_DirectiveObject As_Directive { get; set; }
}

public interface Itest_DirectiveObject
  : Itest_AliasedObject
{
  public ICollection<Itest_InputParam> Parameters { get; set; }
  public ItestBoolean Repeatable { get; set; }
  public IDictionary<test_Location, ItestUnit> Locations { get; set; }
}
