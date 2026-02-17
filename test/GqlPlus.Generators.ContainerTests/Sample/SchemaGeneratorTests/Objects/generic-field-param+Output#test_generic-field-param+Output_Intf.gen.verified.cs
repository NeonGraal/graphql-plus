//HintName: test_generic-field-param+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Output;

public interface ItestGnrcFieldParamOutp
  : IGqlpModelImplementationBase
{
  ItestGnrcFieldParamOutpObject? As_GnrcFieldParamOutp { get; }
}

public interface ItestGnrcFieldParamOutpObject
  : IGqlpModelImplementationBase
{
  ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp> Field { get; }
}

public interface ItestRefGnrcFieldParamOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldParamOutpObject<TRef>? As_RefGnrcFieldParamOutp { get; }
}

public interface ItestRefGnrcFieldParamOutpObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestAltGnrcFieldParamOutp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltGnrcFieldParamOutpObject? As_AltGnrcFieldParamOutp { get; }
}

public interface ItestAltGnrcFieldParamOutpObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
