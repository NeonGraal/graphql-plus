//HintName: test_generic-alt-dual+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Input;

public interface ItestGnrcAltDualInp
  : IGqlpModelImplementationBase
{
  ItestRefGnrcAltDualInp<ItestAltGnrcAltDualInp>? AsRefGnrcAltDualInp { get; }
  ItestGnrcAltDualInpObject? As_GnrcAltDualInp { get; }
}

public interface ItestGnrcAltDualInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefGnrcAltDualInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltDualInpObject<TRef>? As_RefGnrcAltDualInp { get; }
}

public interface ItestRefGnrcAltDualInpObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestAltGnrcAltDualInp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltGnrcAltDualInpObject? As_AltGnrcAltDualInp { get; }
}

public interface ItestAltGnrcAltDualInpObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
