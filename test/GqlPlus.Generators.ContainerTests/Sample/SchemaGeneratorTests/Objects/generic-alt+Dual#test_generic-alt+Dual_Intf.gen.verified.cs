//HintName: test_generic-alt+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_Dual;

public interface ItestGnrcAltDual<TType>
  : IGqlpModelImplementationBase
{
  TType Astype { get; }
  ItestGnrcAltDualObject<TType> AsGnrcAltDual { get; }
}

public interface ItestGnrcAltDualObject<TType>
{
}
