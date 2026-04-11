//HintName: test_field-mod-param+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Dual;

public interface ItestFieldModParamDual<TMod>
  : IGqlpInterfaceBase
{
  ItestFieldModParamDualObject<TMod>? As_FieldModParamDual { get; }
}

public interface ItestFieldModParamDualObject<TMod>
  : IGqlpInterfaceBase
{
  IDictionary<TMod, ItestFldFieldModParamDual> Field { get; }
}

public interface ItestFldFieldModParamDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestFldFieldModParamDualObject? As_FldFieldModParamDual { get; }
}

public interface ItestFldFieldModParamDualObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}
