//HintName: test_generic-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Dual;

public interface ItestGnrcEnumDual
  // No Base because it's Class
{
  ItestRefGnrcEnumDual<testEnumGnrcEnumDual>? AsEnumGnrcEnumDualgnrcEnumDual { get; }
  ItestGnrcEnumDualObject? As_GnrcEnumDual { get; }
}

public interface ItestGnrcEnumDualObject
  // No Base because it's Class
{
}

public interface ItestRefGnrcEnumDual<TType>
  // No Base because it's Class
{
  ItestRefGnrcEnumDualObject<TType>? As_RefGnrcEnumDual { get; }
}

public interface ItestRefGnrcEnumDualObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}

public enum testEnumGnrcEnumDual
{
  gnrcEnumDual,
}
