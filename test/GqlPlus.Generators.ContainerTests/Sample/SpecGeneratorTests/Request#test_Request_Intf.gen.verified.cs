//HintName: test_Request_Intf.gen.cs
// Generated from {CurrentDirectory}Request.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
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
  object? Parameters { get; }
}

public interface Itest_Identifier
  : IGqlpDomainString
{
}

public interface Itest_Collections
  : IGqlpInterfaceBase
{
  Itest_Modifier<test_ModifierKind>? As_ModifierKindList { get; }
  Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindDictionary { get; }
  Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindTypeParam { get; }
  Itest_CollectionsObject? As__Collections { get; }
}

public interface Itest_CollectionsObject
  : IGqlpInterfaceBase
{
}

public interface Itest_ModifierKeyed<TModifierKind>
  : Itest_Modifier<TModifierKind>
{
  Itest_ModifierKeyedObject<TModifierKind>? As__ModifierKeyed { get; }
}

public interface Itest_ModifierKeyedObject<TModifierKind>
  : Itest_ModifierObject<TModifierKind>
{
  Itest_Identifier By { get; }
  bool IsOptional { get; }
}

public interface Itest_Modifiers
  : IGqlpInterfaceBase
{
  Itest_Modifier<test_ModifierKind>? As_ModifierKindOptional { get; }
  Itest_Collections? As_Collections { get; }
  Itest_ModifiersObject? As__Modifiers { get; }
}

public interface Itest_ModifiersObject
  : IGqlpInterfaceBase
{
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

public interface Itest_Modifier<TModifierKind>
  : IGqlpInterfaceBase
{
  Itest_ModifierObject<TModifierKind>? As__Modifier { get; }
}

public interface Itest_ModifierObject<TModifierKind>
  : IGqlpInterfaceBase
{
  TModifierKind ModifierKind { get; }
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
  IDictionary<Itest_Path, ICollection<Itest_OpSelection>> Selections { get; }
}

public interface Itest_Path
  : IGqlpDomainString
{
}

public interface Itest_OpDirectives
  : IGqlpInterfaceBase
{
  Itest_OpDirectivesObject? As__OpDirectives { get; }
}

public interface Itest_OpDirectivesObject
  : IGqlpInterfaceBase
{
  Itest_Identifier Name { get; }
  ICollection<string> Description { get; }
  ICollection<Itest_OpDirective> Directives { get; }
}

public interface Itest_OpVariable
  : Itest_OpDirectives
{
  Itest_OpVariableObject? As__OpVariable { get; }
}

public interface Itest_OpVariableObject
  : Itest_OpDirectivesObject
{
  Itest_Identifier? Type { get; }
  ICollection<Itest_Modifiers> Modifiers { get; }
  GqlpValue? DefaultValue { get; }
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
  : Itest_OpDirectives
{
  Itest_OpFragmentObject? As__OpFragment { get; }
}

public interface Itest_OpFragmentObject
  : Itest_OpDirectivesObject
{
  Itest_Identifier? Type { get; }
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
