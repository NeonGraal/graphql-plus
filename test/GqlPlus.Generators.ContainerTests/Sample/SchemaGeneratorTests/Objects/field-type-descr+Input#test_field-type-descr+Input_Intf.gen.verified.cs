//HintName: test_field-type-descr+Input_Intf.gen.cs
// Generated from {CurrentDirectory}field-type-descr+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_type_descr_Input;

public interface ItestFieldTypeDescrInp
  : IGqlpInterfaceBase
{
  ItestFieldTypeDescrInpObject? As_FieldTypeDescrInp { get; }
}

public interface ItestFieldTypeDescrInpObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}
