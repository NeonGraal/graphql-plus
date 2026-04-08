//HintName: test_generic-alt-param+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Output;

public interface ItestGnrcAltParamOutp
  // No Base because it's Class
{
  ItestRefGnrcAltParamOutp<ItestAltGnrcAltParamOutp>? AsRefGnrcAltParamOutp { get; }
  ItestGnrcAltParamOutpObject? As_GnrcAltParamOutp { get; }
}

public interface ItestGnrcAltParamOutpObject
  // No Base because it's Class
{
}

public interface ItestRefGnrcAltParamOutp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcAltParamOutpObject<TRef>? As_RefGnrcAltParamOutp { get; }
}

public interface ItestRefGnrcAltParamOutpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcAltParamOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcAltParamOutpObject? As_AltGnrcAltParamOutp { get; }
}

public interface ItestAltGnrcAltParamOutpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
