//HintName: test_generic-field+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Output;

public interface ItestGnrcFieldOutp<TType>
  // No Base because it's Class
{
  ItestGnrcFieldOutpObject<TType>? As_GnrcFieldOutp { get; }
}

public interface ItestGnrcFieldOutpObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}
