//HintName: test_generic-field-param+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

public interface ItestGnrcFieldParamInp
  // No Base because it's Class
{
  ItestGnrcFieldParamInpObject? As_GnrcFieldParamInp { get; }
}

public interface ItestGnrcFieldParamInpObject
  // No Base because it's Class
{
  ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> Field { get; }
}

public interface ItestRefGnrcFieldParamInp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcFieldParamInpObject<TRef>? As_RefGnrcFieldParamInp { get; }
}

public interface ItestRefGnrcFieldParamInpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcFieldParamInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcFieldParamInpObject? As_AltGnrcFieldParamInp { get; }
}

public interface ItestAltGnrcFieldParamInpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
