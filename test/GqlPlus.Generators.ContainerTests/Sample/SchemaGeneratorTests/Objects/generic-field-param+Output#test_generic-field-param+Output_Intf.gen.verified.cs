//HintName: test_generic-field-param+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Output;

public interface ItestGnrcFieldParamOutp
  : IGqlpInterfaceBase
{
  ItestGnrcFieldParamOutpObject? As_GnrcFieldParamOutp { get; }
}

public interface ItestGnrcFieldParamOutpObject
  : IGqlpInterfaceBase
{
  ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp> Field { get; }
}

public interface ItestRefGnrcFieldParamOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldParamOutpObject<TRef>? As_RefGnrcFieldParamOutp { get; }
}

public interface ItestRefGnrcFieldParamOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcFieldParamOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcFieldParamOutpObject? As_AltGnrcFieldParamOutp { get; }
}

public interface ItestAltGnrcFieldParamOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
