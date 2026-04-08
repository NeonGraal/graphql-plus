//HintName: test_generic-alt-simple+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Output;

public interface ItestGnrcAltSmplOutp
  // No Base because it's Class
{
  ItestRefGnrcAltSmplOutp<string>? AsRefGnrcAltSmplOutp { get; }
  ItestGnrcAltSmplOutpObject? As_GnrcAltSmplOutp { get; }
}

public interface ItestGnrcAltSmplOutpObject
  // No Base because it's Class
{
}

public interface ItestRefGnrcAltSmplOutp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcAltSmplOutpObject<TRef>? As_RefGnrcAltSmplOutp { get; }
}

public interface ItestRefGnrcAltSmplOutpObject<TRef>
  // No Base because it's Class
{
}
