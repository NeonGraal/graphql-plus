//HintName: test_generic-parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Output;

public interface ItestGnrcPrntOutp<TType>
  // No Base because it's Class
{
  TType? As_Parent { get; }
  ItestGnrcPrntOutpObject<TType>? As_GnrcPrntOutp { get; }
}

public interface ItestGnrcPrntOutpObject<TType>
  // No Base because it's Class
{
}
