//HintName: test_field-mod-param+Input_Intf.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Input;

public interface ItestFieldModParamInp<TMod>
  : IGqlpInterfaceBase
{
  ItestFieldModParamInpObject<TMod>? As_FieldModParamInp { get; }
}

public interface ItestFieldModParamInpObject<TMod>
  : IGqlpInterfaceBase
{
  IDictionary<TMod, ItestFldFieldModParamInp> Field { get; }
}

public interface ItestFldFieldModParamInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestFldFieldModParamInpObject? As_FldFieldModParamInp { get; }
}

public interface ItestFldFieldModParamInpObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}
