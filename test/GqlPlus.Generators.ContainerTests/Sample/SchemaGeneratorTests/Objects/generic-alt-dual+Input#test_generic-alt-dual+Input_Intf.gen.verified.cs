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
  ItestRefGnrcAltDualInp<ItestAltGnrcAltDualInp> AsRefGnrcAltDualInp { get; }
  ItestGnrcAltDualInpObject AsGnrcAltDualInp { get; }
}

public interface ItestGnrcAltDualInpObject
{
}

public interface ItestRefGnrcAltDualInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcAltDualInpObject<TRef> AsRefGnrcAltDualInp { get; }
}

public interface ItestRefGnrcAltDualInpObject<TRef>
{
}

public interface ItestAltGnrcAltDualInp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcAltDualInpObject AsAltGnrcAltDualInp { get; }
}

public interface ItestAltGnrcAltDualInpObject
{
  decimal Alt { get; }
}
