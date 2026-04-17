//HintName: test_generic-enum+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Dual;

public interface ItestGnrcEnumDual
  : IGqlpInterfaceBase
{
  ItestRefGnrcEnumDual<testEnumGnrcEnumDual>? AsEnumGnrcEnumDualgnrcEnumDual { get; }
  ItestGnrcEnumDualObject? As_GnrcEnumDual { get; }
}

public interface ItestGnrcEnumDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcEnumDual<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcEnumDualObject<TType>? As_RefGnrcEnumDual { get; }
}

public interface ItestRefGnrcEnumDualObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumGnrcEnumDual
{
  gnrcEnumDual,
}
