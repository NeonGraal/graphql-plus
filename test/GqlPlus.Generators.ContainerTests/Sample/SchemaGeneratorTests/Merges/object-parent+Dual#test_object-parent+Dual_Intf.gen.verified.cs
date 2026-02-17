//HintName: test_object-parent+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}object-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Dual;

public interface ItestObjPrntDual
  : ItestRefObjPrntDual
{
  ItestObjPrntDualObject AsObjPrntDual { get; }
}

public interface ItestObjPrntDualObject
  : ItestRefObjPrntDualObject
{
}

public interface ItestRefObjPrntDual
  : IGqlpModelImplementationBase
{
  ItestRefObjPrntDualObject AsRefObjPrntDual { get; }
}

public interface ItestRefObjPrntDualObject
{
}
