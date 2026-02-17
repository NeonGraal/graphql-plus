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
  ItestRefGnrcValueDual<testEnumGnrcValueDual> AsEnumGnrcValueDualgnrcValueDual { get; }
  ItestGnrcValueDualObject AsGnrcValueDual { get; }
}

public interface ItestGnrcValueDualObject
{
}

public interface ItestRefGnrcValueDual<TType>
  : IGqlpModelImplementationBase
{
  ItestRefGnrcValueDualObject<TType> AsRefGnrcValueDual { get; }
}

public interface ItestRefGnrcValueDualObject<TType>
{
  TType Field { get; }
}
