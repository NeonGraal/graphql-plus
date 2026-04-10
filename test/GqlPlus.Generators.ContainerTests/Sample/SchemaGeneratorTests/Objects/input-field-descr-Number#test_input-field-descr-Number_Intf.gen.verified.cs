//HintName: test_input-field-descr-Number_Intf.gen.cs
// Generated from {CurrentDirectory}input-field-descr-Number.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_descr_Number;

public interface ItestInpFieldDescrNmbr
  : IGqlpInterfaceBase
{
  ItestInpFieldDescrNmbrObject? As_InpFieldDescrNmbr { get; }
}

public interface ItestInpFieldDescrNmbrObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}
