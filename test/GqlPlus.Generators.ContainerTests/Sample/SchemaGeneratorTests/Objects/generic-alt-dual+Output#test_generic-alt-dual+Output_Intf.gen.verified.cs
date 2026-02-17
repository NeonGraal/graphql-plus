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
  ItestRefGnrcAltDualOutp<ItestAltGnrcAltDualOutp> AsRefGnrcAltDualOutp { get; }
  ItestGnrcAltDualOutpObject AsGnrcAltDualOutp { get; }
}

public interface ItestGnrcAltDualOutpObject
{
}

public interface ItestRefGnrcAltDualOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcAltDualOutpObject<TRef> AsRefGnrcAltDualOutp { get; }
}

public interface ItestRefGnrcAltDualOutpObject<TRef>
{
}

public interface ItestAltGnrcAltDualOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcAltDualOutpObject AsAltGnrcAltDualOutp { get; }
}

public interface ItestAltGnrcAltDualOutpObject
{
  decimal Alt { get; }
}
