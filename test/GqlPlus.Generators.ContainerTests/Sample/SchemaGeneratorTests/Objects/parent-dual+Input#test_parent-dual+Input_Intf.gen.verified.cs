//HintName: test_parent-dual+Input_Intf.gen.cs
// Generated from {CurrentDirectory}parent-dual+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Input;

public interface ItestPrntDualInp
  : ItestRefPrntDualInp
{
  ItestPrntDualInpObject? As_PrntDualInp { get; }
}

public interface ItestPrntDualInpObject
  : ItestRefPrntDualInpObject
{
}

public interface ItestRefPrntDualInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntDualInpObject? As_RefPrntDualInp { get; }
}

public interface ItestRefPrntDualInpObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}
