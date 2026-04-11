//HintName: test_generic-alt-param+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Input;

public interface ItestGnrcAltParamInp
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltParamInp<ItestAltGnrcAltParamInp>? AsRefGnrcAltParamInp { get; }
  ItestGnrcAltParamInpObject? As_GnrcAltParamInp { get; }
}

public interface ItestGnrcAltParamInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltParamInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltParamInpObject<TRef>? As_RefGnrcAltParamInp { get; }
}

public interface ItestRefGnrcAltParamInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcAltParamInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcAltParamInpObject? As_AltGnrcAltParamInp { get; }
}

public interface ItestAltGnrcAltParamInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
