//HintName: test_generic-field-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Input;

public interface ItestGnrcFieldDualInp
  // No Base because it's Class
{
  ItestGnrcFieldDualInpObject? As_GnrcFieldDualInp { get; }
}

public interface ItestGnrcFieldDualInpObject
  // No Base because it's Class
{
  ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp> Field { get; }
}

public interface ItestRefGnrcFieldDualInp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcFieldDualInpObject<TRef>? As_RefGnrcFieldDualInp { get; }
}

public interface ItestRefGnrcFieldDualInpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcFieldDualInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcFieldDualInpObject? As_AltGnrcFieldDualInp { get; }
}

public interface ItestAltGnrcFieldDualInpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
