//HintName: test_generic-field-param+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

public interface ItestGnrcFieldParamDual
  : IGqlpInterfaceBase
{
  ItestGnrcFieldParamDualObject? As_GnrcFieldParamDual { get; }
}

public interface ItestGnrcFieldParamDualObject
  : IGqlpInterfaceBase
{
  ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> Field { get; }
}

public interface ItestRefGnrcFieldParamDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldParamDualObject<TRef>? As_RefGnrcFieldParamDual { get; }
}

public interface ItestRefGnrcFieldParamDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcFieldParamDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcFieldParamDualObject? As_AltGnrcFieldParamDual { get; }
}

public interface ItestAltGnrcFieldParamDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
