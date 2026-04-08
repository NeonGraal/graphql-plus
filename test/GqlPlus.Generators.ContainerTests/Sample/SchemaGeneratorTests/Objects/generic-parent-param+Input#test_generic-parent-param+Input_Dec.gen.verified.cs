//HintName: test_generic-parent-param+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Input;

public interface ItestGnrcPrntParamInp
  : ItestRefGnrcPrntParamInp<ItestAltGnrcPrntParamInp>
{
  ItestGnrcPrntParamInpObject? As_GnrcPrntParamInp { get; }
}

public interface ItestGnrcPrntParamInpObject
  : ItestRefGnrcPrntParamInpObject<ItestAltGnrcPrntParamInp>
{
}

public interface ItestRefGnrcPrntParamInp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcPrntParamInpObject<TRef>? As_RefGnrcPrntParamInp { get; }
}

public interface ItestRefGnrcPrntParamInpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcPrntParamInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcPrntParamInpObject? As_AltGnrcPrntParamInp { get; }
}

public interface ItestAltGnrcPrntParamInpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
