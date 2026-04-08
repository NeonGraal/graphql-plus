//HintName: test_generic-parent-dual-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Input;

public interface ItestGnrcPrntDualPrntInp
  : ItestRefGnrcPrntDualPrntInp<ItestAltGnrcPrntDualPrntInp>
{
  ItestGnrcPrntDualPrntInpObject? As_GnrcPrntDualPrntInp { get; }
}

public interface ItestGnrcPrntDualPrntInpObject
  : ItestRefGnrcPrntDualPrntInpObject<ItestAltGnrcPrntDualPrntInp>
{
}

public interface ItestRefGnrcPrntDualPrntInp<TRef>
  // No Base because it's Class
{
  TRef? As_Parent { get; }
  ItestRefGnrcPrntDualPrntInpObject<TRef>? As_RefGnrcPrntDualPrntInp { get; }
}

public interface ItestRefGnrcPrntDualPrntInpObject<TRef>
  // No Base because it's Class
{
}

public interface ItestAltGnrcPrntDualPrntInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestAltGnrcPrntDualPrntInpObject? As_AltGnrcPrntDualPrntInp { get; }
}

public interface ItestAltGnrcPrntDualPrntInpObject
  // No Base because it's Class
{
  decimal Alt { get; }
}
