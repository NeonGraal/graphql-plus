//HintName: test_generic-alt-param+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-param+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_param_Output;

public interface ItestGnrcAltParamOutp
  : IGqlpModelImplementationBase
{
  ItestRefGnrcAltParamOutp<ItestAltGnrcAltParamOutp>? AsRefGnrcAltParamOutp { get; }
  ItestGnrcAltParamOutpObject? As_GnrcAltParamOutp { get; }
}

public interface ItestGnrcAltParamOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefGnrcAltParamOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltParamOutpObject<TRef>? As_RefGnrcAltParamOutp { get; }
}

public interface ItestRefGnrcAltParamOutpObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestAltGnrcAltParamOutp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltGnrcAltParamOutpObject? As_AltGnrcAltParamOutp { get; }
}

public interface ItestAltGnrcAltParamOutpObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
