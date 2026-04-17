//HintName: test_generic-value+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-value+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Dual;

public interface ItestGnrcValueDual
  : IGqlpInterfaceBase
{
  ItestRefGnrcValueDual<testEnumGnrcValueDual>? AsEnumGnrcValueDualgnrcValueDual { get; }
  ItestGnrcValueDualObject? As_GnrcValueDual { get; }
}

public interface ItestGnrcValueDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcValueDual<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcValueDualObject<TType>? As_RefGnrcValueDual { get; }
}

public interface ItestRefGnrcValueDualObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumGnrcValueDual
{
  gnrcValueDual,
}
