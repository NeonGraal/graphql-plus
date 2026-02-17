//HintName: test_Directive_Intf.gen.cs
// Generated from {CurrentDirectory}Directive.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Directive;

public interface Itest_Directives
  : Itest_AndType
{
  Itest_Directive? As_Directive { get; }
  Itest_DirectivesObject? As__Directives { get; }
}

public interface Itest_DirectivesObject
  : Itest_AndTypeObject
{
  Itest_Directive Directive { get; }
}

public interface Itest_Directive
  : Itest_Aliased
{
  Itest_DirectiveObject? As__Directive { get; }
}

public interface Itest_DirectiveObject
  : Itest_AliasedObject
{
  Itest_InputFieldType? Parameter { get; }
  bool Repeatable { get; }
  IDictionary<test_Location, GqlpUnit> Locations { get; }
}
