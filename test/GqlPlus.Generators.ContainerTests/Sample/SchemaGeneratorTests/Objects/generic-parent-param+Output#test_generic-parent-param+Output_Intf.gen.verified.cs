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
  ItestGnrcPrntParamOutpObject AsGnrcPrntParamOutp { get; }
}

public interface ItestGnrcPrntParamOutpObject
  : ItestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>
{
}

public interface ItestRefGnrcPrntParamOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcPrntParamOutpObject<TRef> AsRefGnrcPrntParamOutp { get; }
}

public interface ItestRefGnrcPrntParamOutpObject<TRef>
{
}

public interface ItestAltGnrcPrntParamOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcPrntParamOutpObject AsAltGnrcPrntParamOutp { get; }
}

public interface ItestAltGnrcPrntParamOutpObject
{
  decimal Alt { get; }
}
