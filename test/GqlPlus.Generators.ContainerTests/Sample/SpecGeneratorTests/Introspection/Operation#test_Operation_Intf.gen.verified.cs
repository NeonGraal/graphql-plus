//HintName: test_Operation_Intf.gen.cs
// Generated from {CurrentDirectory}Operation.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Operation;

public interface Itest_Operations
  : IGqlpInterfaceBase
{
  Itest_Operation? As_Operation { get; }
  Itest_Type? As_Type { get; }
  Itest_OperationsObject? As__Operations { get; }
}

public interface Itest_OperationsObject
  : IGqlpInterfaceBase
{
  Itest_Operation Operation { get; }
  Itest_Type Type { get; }
}

public interface Itest_OpDirectives
  : Itest_Named
{
  Itest_OpDirectivesObject? As__OpDirectives { get; }
}

public interface Itest_OpDirectivesObject
  : Itest_NamedObject
{
  ICollection<Itest_OpDirective> Directives { get; }
}

public interface Itest_Operation
  : Itest_Aliased
{
  Itest_OperationObject? As__Operation { get; }
}

public interface Itest_OperationObject
  : Itest_AliasedObject
{
  Itest_Name Category { get; }
  IDictionary<Itest_Name, Itest_OpVariable> Variables { get; }
  ICollection<Itest_OpDirective> Directives { get; }
  IDictionary<Itest_Name, Itest_OpFragment> Fragments { get; }
  Itest_OpResult Result { get; }
  IDictionary<Itest_Path, ICollection<Itest_OpSelection>> Selections { get; }
}

public interface Itest_OpVariable
  : Itest_OpDirectives
{
  Itest_OpVariableObject? As__OpVariable { get; }
}

public interface Itest_OpVariableObject
  : Itest_OpDirectivesObject
{
  Itest_TypeRef<Itest_TypeKind> Type { get; }
  ICollection<Itest_Modifiers> Modifiers { get; }
  GqlpValue? DefaultValue { get; }
}

public interface Itest_OpDirective
  : Itest_Named
{
  Itest_OpDirectiveObject? As__OpDirective { get; }
}

public interface Itest_OpDirectiveObject
  : Itest_NamedObject
{
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
  Itest_TypeRef<Itest_TypeKind> Type { get; }
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
  Itest_Name Variable { get; }
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
  Itest_Name ByVariable { get; }
}

public interface Itest_OpResult
  : IGqlpInterfaceBase
{
  Itest_TypeRef<Itest_SimpleKind>? As_TypeRef { get; }
  Itest_OpResultObject? As__OpResult { get; }
}

public interface Itest_OpResultObject
  : IGqlpInterfaceBase
{
  Itest_OpArgument? Argument { get; }
}

public interface Itest_Path
  : IGqlpDomainString
{
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
  string? FieldAlias { get; }
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
  Itest_TypeRef<Itest_TypeKind>? Type { get; }
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
  string Fragment { get; }
  ICollection<Itest_OpDirective> Directives { get; }
}
