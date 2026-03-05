//HintName: test_Request_Intf.gen.cs
// Generated from {CurrentDirectory}Request.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Request;

public interface Itest_Request
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  Itest_RequestObject? As__Request { get; }
}

public interface Itest_RequestObject
  : IGqlpModelImplementationBase
{
  Itest_Identifier? Category { get; }
  Itest_Identifier? Operation { get; }
  Itest_Operation Definition { get; }
  Itest_Any? Parameters { get; }
}

public interface Itest_Identifier
  : IGqlpDomainString
{
}

public interface Itest_Operation
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  Itest_OperationObject? As__Operation { get; }
}

public interface Itest_OperationObject
  : IGqlpModelImplementationBase
{
  ICollection<Itest_OpVariable> Variables { get; }
  ICollection<Itest_OpDirective> Directives { get; }
  ICollection<Itest_OpFragment> Fragments { get; }
  Itest_OpResult Result { get; }
}

public interface Itest_OpVariable
  : IGqlpModelImplementationBase
{
  Itest_OpVariableObject? As__OpVariable { get; }
}

public interface Itest_OpVariableObject
  : IGqlpModelImplementationBase
{
  Itest_Identifier Name { get; }
  Itest_Identifier? Type { get; }
  ICollection<Itest_Modifier> Modifiers { get; }
  GqlpValue? Default { get; }
  ICollection<Itest_OpDirective> Directives { get; }
}

public interface Itest_OpDirective
  : IGqlpModelImplementationBase
{
  Itest_OpDirectiveObject? As__OpDirective { get; }
}

public interface Itest_OpDirectiveObject
  : IGqlpModelImplementationBase
{
  Itest_Identifier Name { get; }
  Itest_OpArgument? Argument { get; }
}

public interface Itest_OpFragment
  : IGqlpModelImplementationBase
{
  Itest_OpFragmentObject? As__OpFragment { get; }
}

public interface Itest_OpFragmentObject
  : IGqlpModelImplementationBase
{
  Itest_Identifier Name { get; }
  Itest_Identifier? Type { get; }
  ICollection<Itest_OpDirective> Directives { get; }
  ICollection<Itest_OpObject> Body { get; }
}

public interface Itest_Modifier
  : IGqlpModelImplementationBase
{
  Itest_ModifierObject? As__Modifier { get; }
}

public interface Itest_ModifierObject
  : IGqlpModelImplementationBase
{
  test_ModifierKind ModifierKind { get; }
  Itest_Identifier? By { get; }
  bool? Optional { get; }
}

public interface Itest_OpArgument
  : IGqlpModelImplementationBase
{
  Itest_OpArgValue? As_OpArgValue { get; }
  Itest_OpArgList? As_OpArgList { get; }
  Itest_OpArgMap? As_OpArgMap { get; }
  Itest_OpArgumentObject? As__OpArgument { get; }
}

public interface Itest_OpArgumentObject
  : IGqlpModelImplementationBase
{
}

public interface Itest_OpArgValue
  : IGqlpModelImplementationBase
{
  GqlpValue? AsValue { get; }
  Itest_OpArgValueObject? As__OpArgValue { get; }
}

public interface Itest_OpArgValueObject
  : IGqlpModelImplementationBase
{
  Itest_Identifier Variable { get; }
}

public interface Itest_OpArgList
  : IGqlpModelImplementationBase
{
  ICollection<Itest_OpArgValue>? As_OpArgValue { get; }
  Itest_OpArgListObject? As__OpArgList { get; }
}

public interface Itest_OpArgListObject
  : IGqlpModelImplementationBase
{
}

public interface Itest_OpArgMap
  : IGqlpModelImplementationBase
{
  IDictionary<GqlpScalar, Itest_OpArgValue>? As_OpArgValue { get; }
  Itest_OpArgMapObject? As__OpArgMap { get; }
}

public interface Itest_OpArgMapObject
  : IGqlpModelImplementationBase
{
  Itest_OpArgValue Value { get; }
  Itest_Identifier ByVariable { get; }
}

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
