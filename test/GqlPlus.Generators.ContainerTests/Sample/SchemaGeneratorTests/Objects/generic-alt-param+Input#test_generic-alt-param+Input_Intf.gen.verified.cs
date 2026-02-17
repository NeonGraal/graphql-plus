//HintName: test_generic-alt-param+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Input;

public interface ItestGnrcAltParamInp
  : IGqlpModelImplementationBase
{
  ItestRefGnrcAltParamInp<ItestAltGnrcAltParamInp>? AsRefGnrcAltParamInp { get; }
  ItestGnrcAltParamInpObject? As_GnrcAltParamInp { get; }
}

public interface ItestGnrcAltParamInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefGnrcAltParamInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltParamInpObject<TRef>? As_RefGnrcAltParamInp { get; }
}

public interface ItestRefGnrcAltParamInpObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestAltGnrcAltParamInp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltGnrcAltParamInpObject? As_AltGnrcAltParamInp { get; }
}

public interface ItestAltGnrcAltParamInpObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
