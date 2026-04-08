//HintName: test_generic-field-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

public interface ItestGnrcFieldDualOutp
  // No Base because it's Class
{
  ItestGnrcFieldDualOutpObject? As_GnrcFieldDualOutp { get; }
}

public interface ItestGnrcFieldDualOutpObject
  // No Base because it's Class
{
  ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp> Field { get; }
}

public interface ItestRefGnrcFieldDualOutp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcFieldDualOutpObject<TRef>? As_RefGnrcFieldDualOutp { get; }
}

public interface ItestRefGnrcFieldDualOutpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcFieldDualOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcFieldDualOutpObject? As_AltGnrcFieldDualOutp { get; }
}

public interface ItestAltGnrcFieldDualOutpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
