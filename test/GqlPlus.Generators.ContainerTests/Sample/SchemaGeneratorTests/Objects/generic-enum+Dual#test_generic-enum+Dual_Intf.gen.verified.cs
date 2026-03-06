//HintName: test_generic-enum+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Dual;

public interface ItestGnrcEnumDual
  : IGqlpModelImplementationBase
{
  ItestRefGnrcEnumDual<testEnumGnrcEnumDual>? AsEnumGnrcEnumDualgnrcEnumDual { get; }
  ItestGnrcEnumDualObject? As_GnrcEnumDual { get; }
}

public interface ItestGnrcEnumDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefGnrcEnumDual<TType>
  : IGqlpModelImplementationBase
{
  ItestRefGnrcEnumDualObject<TType>? As_RefGnrcEnumDual { get; }
}

public interface ItestRefGnrcEnumDualObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
}
