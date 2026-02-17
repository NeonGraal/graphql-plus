//HintName: test_generic-field+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Dual;

public interface ItestGnrcFieldDual<TType>
  : IGqlpModelImplementationBase
{
  ItestGnrcFieldDualObject<TType>? As_GnrcFieldDual { get; }
}

public interface ItestGnrcFieldDualObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
}
