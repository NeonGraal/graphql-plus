//HintName: test_Request_Intf.gen.cs
// Generated from {CurrentDirectory}Request.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Request;

public interface Itest_Request
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  Itest_RequestObject? As__Request { get; }
}

public interface Itest_RequestObject
  : IGqlpInterfaceBase
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
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  Itest_OperationObject? As__Operation { get; }
}

public interface Itest_OperationObject
  : IGqlpInterfaceBase
{
  ICollection<Itest_OpVariable> Variables { get; }
  ICollection<Itest_OpDirective> Directives { get; }
  ICollection<Itest_OpFragment> Fragments { get; }
  Itest_OpResult Result { get; }
}

public interface Itest_OpVariable
  : IGqlpInterfaceBase
{
  Itest_OpVariableObject? As__OpVariable { get; }
}

public interface Itest_OpVariableObject
  : IGqlpInterfaceBase
{
  Itest_Identifier Name { get; }
  Itest_Identifier? Type { get; }
  ICollection<Itest_Modifier> Modifiers { get; }
  GqlpValue? Default { get; }
  ICollection<Itest_OpDirective> Directives { get; }
}

public interface Itest_OpDirective
  : IGqlpInterfaceBase
{
  Itest_OpDirectiveObject? As__OpDirective { get; }
}

public interface Itest_OpDirectiveObject
  : IGqlpInterfaceBase
{
  Itest_Identifier Name { get; }
  Itest_OpArgument? Argument { get; }
}

public interface Itest_OpFragment
  : IGqlpInterfaceBase
{
  Itest_OpFragmentObject? As__OpFragment { get; }
}

public interface Itest_OpFragmentObject
  : IGqlpInterfaceBase
{
  Itest_Identifier Name { get; }
  Itest_Identifier? Type { get; }
  ICollection<Itest_OpDirective> Directives { get; }
  ICollection<Itest_OpObject> Body { get; }
}

public enum test_ModifierKind
{
  Opt,
  Optional = Opt,
  List,
  Dict,
  Dictionary = Dict,
  Param,
  TypeParam = Param,
}

public interface Itest_Modifier
  : IGqlpInterfaceBase
{
  Itest_ModifierObject? As__Modifier { get; }
}

public interface Itest_ModifierObject
  : IGqlpInterfaceBase
{
  test_ModifierKind ModifierKind { get; }
  Itest_Identifier? By { get; }
  bool? Optional { get; }
}

public interface Itest_OpArgument
  : IGqlpInterfaceBase
{
  Itest_OpArgValue? As_OpArgValue { get; }
  Itest_OpArgList? As_OpArgList { get; }
  Itest_OpArgMap? As_OpArgMap { get; }
  Itest_OpArgumentObject? As__OpArgument { get; }
}

public interface Itest_OpArgumentObject
  : IGqlpInterfaceBase
{
}

public interface Itest_OpArgValue
  : IGqlpInterfaceBase
{
  GqlpValue? AsValue { get; }
  Itest_OpArgValueObject? As__OpArgValue { get; }
}

public interface Itest_OpArgValueObject
  : IGqlpInterfaceBase
{
  Itest_Identifier Variable { get; }
}

public interface Itest_OpArgList
  : IGqlpInterfaceBase
{
  ICollection<Itest_OpArgValue>? As_OpArgValue { get; }
  Itest_OpArgListObject? As__OpArgList { get; }
}

public interface Itest_OpArgListObject
  : IGqlpInterfaceBase
{
}

public interface Itest_OpArgMap
  : IGqlpInterfaceBase
{
  IDictionary<GqlpScalar, Itest_OpArgValue>? As_OpArgValue { get; }
  Itest_OpArgMapObject? As__OpArgMap { get; }
}

public interface Itest_OpArgMapObject
  : IGqlpInterfaceBase
{
  Itest_OpArgValue Value { get; }
  Itest_Identifier ByVariable { get; }
}

public interface Itest_OpResult
  : IGqlpInterfaceBase
{
  Itest_OpResultObject? As__OpResult { get; }
}

public interface Itest_OpResultObject
  : IGqlpInterfaceBase
{
  Itest_Identifier? Domain { get; }
  Itest_OpArgument? Argument { get; }
  ICollection<Itest_OpObject> Body { get; }
}

public interface Itest_OpObject
  : IGqlpInterfaceBase
{
  Itest_OpField? As_OpField { get; }
  Itest_OpSpread? As_OpSpread { get; }
  Itest_OpInline? As_OpInline { get; }
  Itest_OpObjectObject? As__OpObject { get; }
}

public interface Itest_OpObjectObject
  : IGqlpInterfaceBase
{
}

public interface Itest_OpField
  : IGqlpInterfaceBase
{
  Itest_OpFieldObject? As__OpField { get; }
}

public interface Itest_OpFieldObject
  : IGqlpInterfaceBase
{
  Itest_Identifier? Alias { get; }
  Itest_Identifier Field { get; }
  Itest_OpArgument? Argument { get; }
  ICollection<Itest_Modifier> Modifiers { get; }
  ICollection<Itest_OpDirective> Directives { get; }
  string Body { get; }
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
  string Body { get; }
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
