//HintName: test_generic-field-param+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

public interface ItestGnrcFieldParamDual
  : IGqlpModelImplementationBase
{
  ItestGnrcFieldParamDualObject? As_GnrcFieldParamDual { get; }
}

public interface ItestGnrcFieldParamDualObject
  : IGqlpModelImplementationBase
{
  ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> Field { get; }
}

public interface ItestRefGnrcFieldParamDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldParamDualObject<TRef>? As_RefGnrcFieldParamDual { get; }
}

public interface ItestRefGnrcFieldParamDualObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestAltGnrcFieldParamDual
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltGnrcFieldParamDualObject? As_AltGnrcFieldParamDual { get; }
}

public interface ItestAltGnrcFieldParamDualObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
