//HintName: test_Operation_Intf.gen.cs
// Generated from {CurrentDirectory}Operation.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Operation;

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
