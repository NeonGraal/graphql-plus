//HintName: test_generic-alt-param+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Input;

public interface ItestGnrcAltParamInp
  // No Base because it's Class
{
  ItestRefGnrcAltParamInp<ItestAltGnrcAltParamInp>? AsRefGnrcAltParamInp { get; }
  ItestGnrcAltParamInpObject? As_GnrcAltParamInp { get; }
}

public interface ItestGnrcAltParamInpObject
  // No Base because it's Class
{
}

public interface ItestRefGnrcAltParamInp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcAltParamInpObject<TRef>? As_RefGnrcAltParamInp { get; }
}

public interface ItestRefGnrcAltParamInpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcAltParamInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcAltParamInpObject? As_AltGnrcAltParamInp { get; }
}

public interface ItestAltGnrcAltParamInpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
