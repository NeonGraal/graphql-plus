//HintName: test_generic-parent-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Input;

public interface ItestGnrcPrntDualInp
  : ItestRefGnrcPrntDualInp<ItestAltGnrcPrntDualInp>
{
  ItestGnrcPrntDualInpObject? As_GnrcPrntDualInp { get; }
}

public interface ItestGnrcPrntDualInpObject
  : ItestRefGnrcPrntDualInpObject<ItestAltGnrcPrntDualInp>
{
}

public interface ItestRefGnrcPrntDualInp<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefGnrcPrntDualInpObject<TRef>? As_RefGnrcPrntDualInp { get; }
}

public interface ItestRefGnrcPrntDualInpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcPrntDualInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcPrntDualInpObject? As_AltGnrcPrntDualInp { get; }
}

public interface ItestAltGnrcPrntDualInpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
