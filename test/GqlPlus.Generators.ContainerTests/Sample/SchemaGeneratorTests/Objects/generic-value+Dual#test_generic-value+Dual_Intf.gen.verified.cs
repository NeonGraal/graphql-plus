//HintName: test_generic-value+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-value+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Dual;

public interface ItestGnrcValueDual
  : IGqlpModelImplementationBase
{
  ItestRefGnrcValueDual<testEnumGnrcValueDual>? AsEnumGnrcValueDualgnrcValueDual { get; }
  ItestGnrcValueDualObject? As_GnrcValueDual { get; }
}

public interface ItestGnrcValueDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefGnrcValueDual<TType>
  : IGqlpModelImplementationBase
{
  ItestRefGnrcValueDualObject<TType>? As_RefGnrcValueDual { get; }
}

public interface ItestRefGnrcValueDualObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
}

public enum testEnumGnrcValueDual
{
  gnrcValueDual,
}
