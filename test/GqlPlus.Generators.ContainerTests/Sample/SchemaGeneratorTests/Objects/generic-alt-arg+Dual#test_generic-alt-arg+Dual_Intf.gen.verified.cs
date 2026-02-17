//HintName: test_generic-alt-arg+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Dual;

public interface ItestGnrcAltArgDual<TType>
  : IGqlpModelImplementationBase
{
  ItestRefGnrcAltArgDual<TType>? AsRefGnrcAltArgDual { get; }
  ItestGnrcAltArgDualObject<TType>? As_GnrcAltArgDual { get; }
}

public interface ItestGnrcAltArgDualObject<TType>
  : IGqlpModelImplementationBase
{
}

public interface ItestRefGnrcAltArgDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltArgDualObject<TRef>? As_RefGnrcAltArgDual { get; }
}

public interface ItestRefGnrcAltArgDualObject<TRef>
  : IGqlpModelImplementationBase
{
}
