//HintName: test_generic-field-arg+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Dual;

public interface ItestGnrcFieldArgDual<TType>
  : IGqlpInterfaceBase
{
  ItestGnrcFieldArgDualObject<TType>? As_GnrcFieldArgDual { get; }
}

public interface ItestGnrcFieldArgDualObject<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcFieldArgDual<TType> Field { get; }
}

public interface ItestRefGnrcFieldArgDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldArgDualObject<TRef>? As_RefGnrcFieldArgDual { get; }
}

public interface ItestRefGnrcFieldArgDualObject<TRef>
  : IGqlpInterfaceBase
{
}
