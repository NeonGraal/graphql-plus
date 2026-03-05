//HintName: test_Result_Intf.gen.cs
// Generated from {CurrentDirectory}Result.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Result;

public interface Itest_OpResult
  : IGqlpModelImplementationBase
{
  Itest_OpResultObject? As__OpResult { get; }
}

public interface Itest_OpResultObject
  : IGqlpModelImplementationBase
{
  Itest_Identifier? Domain { get; }
  Itest_OpArgument? Argument { get; }
  ICollection<Itest_OpObject> Body { get; }
}

public interface Itest_OpObject
  : IGqlpModelImplementationBase
{
  Itest_OpField? As_OpField { get; }
  Itest_OpSpread? As_OpSpread { get; }
  Itest_OpInline? As_OpInline { get; }
  Itest_OpObjectObject? As__OpObject { get; }
}

public interface Itest_OpObjectObject
  : IGqlpModelImplementationBase
{
}

public interface Itest_OpField
  : IGqlpModelImplementationBase
{
  Itest_OpFieldObject? As__OpField { get; }
}

public interface Itest_OpFieldObject
  : IGqlpModelImplementationBase
{
  Itest_Identifier? Alias { get; }
  Itest_Identifier Field { get; }
  Itest_OpArgument? Argument { get; }
  ICollection<Itest_Modifier> Modifiers { get; }
  ICollection<Itest_OpDirective> Directives { get; }
  string Body { get; }
}

public interface Itest_OpInline
  : IGqlpModelImplementationBase
{
  Itest_OpInlineObject? As__OpInline { get; }
}

public interface Itest_OpInlineObject
  : IGqlpModelImplementationBase
{
  Itest_Identifier? Type { get; }
  ICollection<Itest_OpDirective> Directives { get; }
  string Body { get; }
}

public interface Itest_OpSpread
  : IGqlpModelImplementationBase
{
  Itest_OpSpreadObject? As__OpSpread { get; }
}

public interface Itest_OpSpreadObject
  : IGqlpModelImplementationBase
{
  Itest_Identifier Fragment { get; }
  ICollection<Itest_OpDirective> Directives { get; }
}
