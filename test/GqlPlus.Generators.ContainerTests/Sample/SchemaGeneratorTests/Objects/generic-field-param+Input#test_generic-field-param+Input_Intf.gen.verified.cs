//HintName: test_generic-field-param+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

public interface ItestGnrcFieldParamInp
  : IGqlpModelImplementationBase
{
  ItestGnrcFieldParamInpObject AsGnrcFieldParamInp { get; }
}

public interface ItestGnrcFieldParamInpObject
{
  ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> Field { get; }
}

public interface ItestRefGnrcFieldParamInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcFieldParamInpObject<TRef> AsRefGnrcFieldParamInp { get; }
}

public interface ItestRefGnrcFieldParamInpObject<TRef>
{
}

public interface ItestAltGnrcFieldParamInp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcFieldParamInpObject AsAltGnrcFieldParamInp { get; }
}

public interface ItestAltGnrcFieldParamInpObject
{
  decimal Alt { get; }
}
