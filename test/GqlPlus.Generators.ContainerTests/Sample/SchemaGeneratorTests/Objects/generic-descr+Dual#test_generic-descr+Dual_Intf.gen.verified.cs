//HintName: test_generic-descr+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Dual;

public interface ItestGnrcDescrDual<TType>
  : IGqlpInterfaceBase
{
  ItestGnrcDescrDualObject<TType>? As_GnrcDescrDual { get; }
}

public interface ItestGnrcDescrDualObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}
