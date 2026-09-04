//HintName: test_Selections_Intf.gen.cs
// Generated from {CurrentDirectory}Selections.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Selections;

public interface Itest_OpSelection
  : IGqlpInterfaceBase
{
  Itest_OpField? As_OpField { get; }
  Itest_OpSpread? As_OpSpread { get; }
  Itest_OpInline? As_OpInline { get; }
  Itest_OpSelectionObject? As__OpSelection { get; }
}

public interface Itest_OpSelectionObject
  : IGqlpInterfaceBase
{
}

public interface Itest_OpField
  : Itest_OpDirectives
{
  Itest_OpFieldObject? As__OpField { get; }
}

public interface Itest_OpFieldObject
  : Itest_OpDirectivesObject
{
  Itest_Identifier? FieldAlias { get; }
  Itest_OpArgument? Argument { get; }
  ICollection<Itest_Modifiers> Modifiers { get; }
}

public interface Itest_OpInline
  : IGqlpInterfaceBase
{
  Itest_OpInlineObject? As__OpInline { get; }
}

public interface Itest_OpInlineObject
  : IGqlpInterfaceBase
{
  Itest_Identifier? Type { get; }
  ICollection<Itest_OpDirective> Directives { get; }
}

public interface Itest_OpSpread
  : IGqlpInterfaceBase
{
  Itest_OpSpreadObject? As__OpSpread { get; }
}

public interface Itest_OpSpreadObject
  : IGqlpInterfaceBase
{
  Itest_Identifier Fragment { get; }
  ICollection<Itest_OpDirective> Directives { get; }
}
