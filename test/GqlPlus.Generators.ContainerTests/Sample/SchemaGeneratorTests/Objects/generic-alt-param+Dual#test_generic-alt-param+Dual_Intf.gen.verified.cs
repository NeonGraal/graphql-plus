//HintName: test_generic-alt-param+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Dual;

public interface ItestGnrcAltParamDual
  : IGqlpModelImplementationBase
{
  ItestRefGnrcAltParamDual<ItestAltGnrcAltParamDual> AsRefGnrcAltParamDual { get; }
  ItestGnrcAltParamDualObject AsGnrcAltParamDual { get; }
}

public interface ItestGnrcAltParamDualObject
{
}

public interface ItestRefGnrcAltParamDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcAltParamDualObject<TRef> AsRefGnrcAltParamDual { get; }
}

public interface ItestRefGnrcAltParamDualObject<TRef>
{
}

public interface ItestAltGnrcAltParamDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcAltParamDualObject AsAltGnrcAltParamDual { get; }
}

public interface ItestAltGnrcAltParamDualObject
{
  decimal Alt { get; }
}
