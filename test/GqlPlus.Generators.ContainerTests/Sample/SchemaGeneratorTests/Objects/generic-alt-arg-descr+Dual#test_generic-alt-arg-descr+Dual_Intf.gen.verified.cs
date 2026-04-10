//HintName: test_generic-alt-arg-descr+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Dual;

public interface ItestGnrcAltArgDescrDual<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltArgDescrDual<TType>? AsRefGnrcAltArgDescrDual { get; }
  ItestGnrcAltArgDescrDualObject<TType>? As_GnrcAltArgDescrDual { get; }
}

public interface ItestGnrcAltArgDescrDualObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltArgDescrDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltArgDescrDualObject<TRef>? As_RefGnrcAltArgDescrDual { get; }
}

public interface ItestRefGnrcAltArgDescrDualObject<TRef>
  : IGqlpInterfaceBase
{
}
