//HintName: test_generic-parent-param-parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Output;

public interface ItestGnrcPrntParamPrntOutp
  : ItestRefGnrcPrntParamPrntOutp<ItestAltGnrcPrntParamPrntOutp>
{
  ItestGnrcPrntParamPrntOutpObject? As_GnrcPrntParamPrntOutp { get; }
}

public interface ItestGnrcPrntParamPrntOutpObject
  : ItestRefGnrcPrntParamPrntOutpObject<ItestAltGnrcPrntParamPrntOutp>
{
}

public interface ItestRefGnrcPrntParamPrntOutp<TRef>
  // No Base because it's Class
{
  TRef? As_Parent { get; }
  ItestRefGnrcPrntParamPrntOutpObject<TRef>? As_RefGnrcPrntParamPrntOutp { get; }
}

public interface ItestRefGnrcPrntParamPrntOutpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcPrntParamPrntOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcPrntParamPrntOutpObject? As_AltGnrcPrntParamPrntOutp { get; }
}

public interface ItestAltGnrcPrntParamPrntOutpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
