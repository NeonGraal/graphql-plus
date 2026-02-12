//HintName: test_Directive_Intf.gen.cs
// Generated from Directive.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Directive;

public interface Itest_Directives
  : Itest_AndType
{
  Itest_Directive As_Directive { get; }
  Itest_DirectivesObject As_Directives { get; }
}

public interface Itest_DirectivesObject
  : Itest_AndTypeObject
{
  Itest_Directive Directive { get; }
}

public interface Itest_Directive
  : Itest_Aliased
{
  Itest_DirectiveObject As_Directive { get; }
}

public interface Itest_DirectiveObject
  : Itest_AliasedObject
{
  ICollection<Itest_InputParam> Parameters { get; }
  bool Repeatable { get; }
  IDictionary<test_Location, GqlpUnit> Locations { get; }
}
