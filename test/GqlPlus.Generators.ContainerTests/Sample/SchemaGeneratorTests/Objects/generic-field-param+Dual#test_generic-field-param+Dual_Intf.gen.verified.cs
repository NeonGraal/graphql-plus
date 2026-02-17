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
  ItestGnrcFieldParamDualObject AsGnrcFieldParamDual { get; }
}

public interface ItestGnrcFieldParamDualObject
{
  ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> Field { get; }
}

public interface ItestRefGnrcFieldParamDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcFieldParamDualObject<TRef> AsRefGnrcFieldParamDual { get; }
}

public interface ItestRefGnrcFieldParamDualObject<TRef>
{
}

public interface ItestAltGnrcFieldParamDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcFieldParamDualObject AsAltGnrcFieldParamDual { get; }
}

public interface ItestAltGnrcFieldParamDualObject
{
  decimal Alt { get; }
}
