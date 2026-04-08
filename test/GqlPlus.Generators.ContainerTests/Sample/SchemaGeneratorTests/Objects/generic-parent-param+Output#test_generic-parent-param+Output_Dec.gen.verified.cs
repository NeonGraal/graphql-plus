//HintName: test_generic-parent-param+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Output;

public interface ItestGnrcPrntParamOutp
  : ItestRefGnrcPrntParamOutp<ItestAltGnrcPrntParamOutp>
{
  ItestGnrcPrntParamOutpObject? As_GnrcPrntParamOutp { get; }
}

public interface ItestGnrcPrntParamOutpObject
  : ItestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>
{
}

public interface ItestRefGnrcPrntParamOutp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcPrntParamOutpObject<TRef>? As_RefGnrcPrntParamOutp { get; }
}

public interface ItestRefGnrcPrntParamOutpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcPrntParamOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcPrntParamOutpObject? As_AltGnrcPrntParamOutp { get; }
}

public interface ItestAltGnrcPrntParamOutpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
