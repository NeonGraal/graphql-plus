//HintName: test_generic-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Output;

public interface ItestGnrcEnumOutp
  // No Base because it's Class
{
  ItestRefGnrcEnumOutp<testEnumGnrcEnumOutp>? AsEnumGnrcEnumOutpgnrcEnumOutp { get; }
  ItestGnrcEnumOutpObject? As_GnrcEnumOutp { get; }
}

public interface ItestGnrcEnumOutpObject
  // No Base because it's Class
{
}

public interface ItestRefGnrcEnumOutp<TType>
  // No Base because it's Class
{
  ItestRefGnrcEnumOutpObject<TType>? As_RefGnrcEnumOutp { get; }
}

public interface ItestRefGnrcEnumOutpObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}

public enum testEnumGnrcEnumOutp
{
  gnrcEnumOutp,
}
