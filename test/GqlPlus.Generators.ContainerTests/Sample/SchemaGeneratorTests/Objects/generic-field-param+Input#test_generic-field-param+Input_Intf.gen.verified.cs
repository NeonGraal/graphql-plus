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
  ItestGnrcFieldParamInpObject? As_GnrcFieldParamInp { get; }
}

public interface ItestGnrcFieldParamInpObject
  : IGqlpModelImplementationBase
{
  ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> Field { get; }
}

public interface ItestRefGnrcFieldParamInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldParamInpObject<TRef>? As_RefGnrcFieldParamInp { get; }
}

public interface ItestRefGnrcFieldParamInpObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestAltGnrcFieldParamInp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltGnrcFieldParamInpObject? As_AltGnrcFieldParamInp { get; }
}

public interface ItestAltGnrcFieldParamInpObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
