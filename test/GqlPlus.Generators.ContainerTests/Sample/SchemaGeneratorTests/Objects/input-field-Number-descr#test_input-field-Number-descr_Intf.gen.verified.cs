//HintName: test_input-field-Number-descr_Intf.gen.cs
// Generated from {CurrentDirectory}input-field-Number-descr.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Number_descr;

public interface ItestInpFieldNmbrDescr
  : IGqlpInterfaceBase
{
  ItestInpFieldNmbrDescrObject? As_InpFieldNmbrDescr { get; }
}

public interface ItestInpFieldNmbrDescrObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}
