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
  ItestRefGnrcAltParamOutp<ItestAltGnrcAltParamOutp> AsRefGnrcAltParamOutp { get; }
  ItestGnrcAltParamOutpObject AsGnrcAltParamOutp { get; }
}

public interface ItestGnrcAltParamOutpObject
{
}

public interface ItestRefGnrcAltParamOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcAltParamOutpObject<TRef> AsRefGnrcAltParamOutp { get; }
}

public interface ItestRefGnrcAltParamOutpObject<TRef>
{
}

public interface ItestAltGnrcAltParamOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcAltParamOutpObject AsAltGnrcAltParamOutp { get; }
}

public interface ItestAltGnrcAltParamOutpObject
{
  decimal Alt { get; }
}
