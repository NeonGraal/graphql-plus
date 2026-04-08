//HintName: test_generic-descr+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Output;

public interface ItestGnrcDescrOutp<TType>
  // No Base because it's Class
{
  ItestGnrcDescrOutpObject<TType>? As_GnrcDescrOutp { get; }
}

public interface ItestGnrcDescrOutpObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}
