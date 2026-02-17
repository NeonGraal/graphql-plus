//HintName: test_generic-parent-dual+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
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
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcPrntDualInpObject<TRef>? As_RefGnrcPrntDualInp { get; }
}

public interface ItestRefGnrcPrntDualInpObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestAltGnrcPrntDualInp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltGnrcPrntDualInpObject? As_AltGnrcPrntDualInp { get; }
}

public interface ItestAltGnrcPrntDualInpObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
