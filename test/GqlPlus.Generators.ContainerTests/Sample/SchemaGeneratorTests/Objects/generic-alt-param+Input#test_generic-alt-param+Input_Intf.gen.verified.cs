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
  ItestRefGnrcAltParamInp<ItestAltGnrcAltParamInp> AsRefGnrcAltParamInp { get; }
  ItestGnrcAltParamInpObject AsGnrcAltParamInp { get; }
}

public interface ItestGnrcAltParamInpObject
{
}

public interface ItestRefGnrcAltParamInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcAltParamInpObject<TRef> AsRefGnrcAltParamInp { get; }
}

public interface ItestRefGnrcAltParamInpObject<TRef>
{
}

public interface ItestAltGnrcAltParamInp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcAltParamInpObject AsAltGnrcAltParamInp { get; }
}

public interface ItestAltGnrcAltParamInpObject
{
  decimal Alt { get; }
}
