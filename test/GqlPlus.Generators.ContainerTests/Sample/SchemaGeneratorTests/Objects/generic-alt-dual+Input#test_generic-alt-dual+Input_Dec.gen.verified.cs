//HintName: test_generic-alt-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Input;

public interface ItestGnrcAltDualInp
  // No Base because it's Class
{
  ItestRefGnrcAltDualInp<ItestAltGnrcAltDualInp>? AsRefGnrcAltDualInp { get; }
  ItestGnrcAltDualInpObject? As_GnrcAltDualInp { get; }
}

public interface ItestGnrcAltDualInpObject
  // No Base because it's Class
{
}

public interface ItestRefGnrcAltDualInp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcAltDualInpObject<TRef>? As_RefGnrcAltDualInp { get; }
}

public interface ItestRefGnrcAltDualInpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcAltDualInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcAltDualInpObject? As_AltGnrcAltDualInp { get; }
}

public interface ItestAltGnrcAltDualInpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
