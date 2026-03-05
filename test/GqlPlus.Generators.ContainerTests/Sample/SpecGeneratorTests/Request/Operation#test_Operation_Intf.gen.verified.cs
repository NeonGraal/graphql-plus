//HintName: test_Operation_Intf.gen.cs
// Generated from {CurrentDirectory}Operation.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Operation;

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
