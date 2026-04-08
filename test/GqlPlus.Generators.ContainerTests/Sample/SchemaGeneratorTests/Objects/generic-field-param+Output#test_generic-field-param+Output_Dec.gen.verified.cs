//HintName: test_generic-field-param+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Output;

public interface ItestGnrcFieldParamOutp
  // No Base because it's Class
{
  ItestGnrcFieldParamOutpObject? As_GnrcFieldParamOutp { get; }
}

public interface ItestGnrcFieldParamOutpObject
  // No Base because it's Class
{
  ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp> Field { get; }
}

public interface ItestRefGnrcFieldParamOutp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcFieldParamOutpObject<TRef>? As_RefGnrcFieldParamOutp { get; }
}

public interface ItestRefGnrcFieldParamOutpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcFieldParamOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcFieldParamOutpObject? As_AltGnrcFieldParamOutp { get; }
}

public interface ItestAltGnrcFieldParamOutpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
