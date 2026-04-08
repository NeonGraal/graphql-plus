//HintName: test_generic-value+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Dual;

public interface ItestGnrcValueDual
  // No Base because it's Class
{
  ItestRefGnrcValueDual<testEnumGnrcValueDual>? AsEnumGnrcValueDualgnrcValueDual { get; }
  ItestGnrcValueDualObject? As_GnrcValueDual { get; }
}

public interface ItestGnrcValueDualObject
  // No Base because it's Class
{
}

public interface ItestRefGnrcValueDual<TType>
  // No Base because it's Class
{
  ItestRefGnrcValueDualObject<TType>? As_RefGnrcValueDual { get; }
}

public interface ItestRefGnrcValueDualObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}

public enum testEnumGnrcValueDual
{
  gnrcValueDual,
}
