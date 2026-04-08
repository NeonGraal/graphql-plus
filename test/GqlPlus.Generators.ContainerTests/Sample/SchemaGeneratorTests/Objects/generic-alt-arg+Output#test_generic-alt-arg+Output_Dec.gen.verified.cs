//HintName: test_generic-alt-arg+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Output;

public interface ItestGnrcAltArgOutp<TType>
  // No Base because it's Class
{
  ItestRefGnrcAltArgOutp<TType>? AsRefGnrcAltArgOutp { get; }
  ItestGnrcAltArgOutpObject<TType>? As_GnrcAltArgOutp { get; }
}

public interface ItestGnrcAltArgOutpObject<TType>
  // No Base because it's Class
{
}

public interface ItestRefGnrcAltArgOutp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcAltArgOutpObject<TRef>? As_RefGnrcAltArgOutp { get; }
}

public interface ItestRefGnrcAltArgOutpObject<TRef>
  // No Base because it's Class
{
}
