//HintName: test_generic-alt-param+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Output;

public interface ItestGnrcAltParamOutp
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltParamOutp<ItestAltGnrcAltParamOutp>? AsRefGnrcAltParamOutp { get; }
  ItestGnrcAltParamOutpObject? As_GnrcAltParamOutp { get; }
}

public interface ItestGnrcAltParamOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltParamOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltParamOutpObject<TRef>? As_RefGnrcAltParamOutp { get; }
}

public interface ItestRefGnrcAltParamOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcAltParamOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcAltParamOutpObject? As_AltGnrcAltParamOutp { get; }
}

public interface ItestAltGnrcAltParamOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
