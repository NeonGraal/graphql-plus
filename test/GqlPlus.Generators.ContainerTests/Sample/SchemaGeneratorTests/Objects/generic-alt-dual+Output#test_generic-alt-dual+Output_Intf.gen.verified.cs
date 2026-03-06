//HintName: test_generic-alt-dual+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Output;

public interface ItestGnrcAltDualOutp
  : IGqlpModelImplementationBase
{
  ItestRefGnrcAltDualOutp<ItestAltGnrcAltDualOutp>? AsRefGnrcAltDualOutp { get; }
  ItestGnrcAltDualOutpObject? As_GnrcAltDualOutp { get; }
}

public interface ItestGnrcAltDualOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefGnrcAltDualOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltDualOutpObject<TRef>? As_RefGnrcAltDualOutp { get; }
}

public interface ItestRefGnrcAltDualOutpObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestAltGnrcAltDualOutp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltGnrcAltDualOutpObject? As_AltGnrcAltDualOutp { get; }
}

public interface ItestAltGnrcAltDualOutpObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
