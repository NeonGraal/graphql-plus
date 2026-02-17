//HintName: test_generic-parent-param+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Output;

public interface ItestGnrcPrntParamOutp
  : ItestRefGnrcPrntParamOutp<ItestAltGnrcPrntParamOutp>
{
  ItestGnrcPrntParamOutpObject? As_GnrcPrntParamOutp { get; }
}

public interface ItestGnrcPrntParamOutpObject
  : ItestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>
{
}

public interface ItestRefGnrcPrntParamOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcPrntParamOutpObject<TRef>? As_RefGnrcPrntParamOutp { get; }
}

public interface ItestRefGnrcPrntParamOutpObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestAltGnrcPrntParamOutp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltGnrcPrntParamOutpObject? As_AltGnrcPrntParamOutp { get; }
}

public interface ItestAltGnrcPrntParamOutpObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
