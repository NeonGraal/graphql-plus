//HintName: test_field-mod-param+Output_Intf.gen.cs
// Generated from {CurrentDirectory}field-mod-param+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_param_Output;

public interface ItestFieldModParamOutp<TMod>
  : IGqlpInterfaceBase
{
  ItestFieldModParamOutpObject<TMod>? As_FieldModParamOutp { get; }
}

public interface ItestFieldModParamOutpObject<TMod>
  : IGqlpInterfaceBase
{
  IDictionary<TMod, ItestFldFieldModParamOutp> Field { get; }
}

public interface ItestFldFieldModParamOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestFldFieldModParamOutpObject? As_FldFieldModParamOutp { get; }
}

public interface ItestFldFieldModParamOutpObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}
