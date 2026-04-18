//HintName: test_input-field-Number_Intf.gen.cs
// Generated from {CurrentDirectory}input-field-Number.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Number;

public interface ItestInpFieldNmbr
  : IGqlpInterfaceBase
{
  ItestInpFieldNmbrObject? As_InpFieldNmbr { get; }
}

public interface ItestInpFieldNmbrObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}
