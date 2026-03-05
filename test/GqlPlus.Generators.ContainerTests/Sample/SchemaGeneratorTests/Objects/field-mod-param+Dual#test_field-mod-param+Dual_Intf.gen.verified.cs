//HintName: test_field-mod-param+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Dual;

public interface ItestFieldModParamDual<TMod>
  : IGqlpModelImplementationBase
{
  ItestFieldModParamDualObject<TMod>? As_FieldModParamDual { get; }
}

public interface ItestFieldModParamDualObject<TMod>
  : IGqlpModelImplementationBase
{
  IDictionary<TMod, ItestFldFieldModParamDual> Field { get; }
}

public interface ItestFldFieldModParamDual
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestFldFieldModParamDualObject? As_FldFieldModParamDual { get; }
}

public interface ItestFldFieldModParamDualObject
  : IGqlpModelImplementationBase
{
  decimal Field { get; }
}
