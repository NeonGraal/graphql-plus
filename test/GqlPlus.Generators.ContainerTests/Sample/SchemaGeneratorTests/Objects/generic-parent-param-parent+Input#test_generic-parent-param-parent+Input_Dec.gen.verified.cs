//HintName: test_generic-parent-param-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-param-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Input;

public interface ItestGnrcPrntParamPrntInp
  : ItestRefGnrcPrntParamPrntInp<ItestAltGnrcPrntParamPrntInp>
{
  ItestGnrcPrntParamPrntInpObject? As_GnrcPrntParamPrntInp { get; }
}

public interface ItestGnrcPrntParamPrntInpObject
  : ItestRefGnrcPrntParamPrntInpObject<ItestAltGnrcPrntParamPrntInp>
{
}

public interface ItestRefGnrcPrntParamPrntInp<TRef>
  // No Base because it's Class
{
  TRef? As_Parent { get; }
  ItestRefGnrcPrntParamPrntInpObject<TRef>? As_RefGnrcPrntParamPrntInp { get; }
}

public interface ItestRefGnrcPrntParamPrntInpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcPrntParamPrntInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcPrntParamPrntInpObject? As_AltGnrcPrntParamPrntInp { get; }
}

public interface ItestAltGnrcPrntParamPrntInpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
