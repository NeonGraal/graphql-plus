//HintName: test_field-descr+Input_Intf.gen.cs
// Generated from {CurrentDirectory}field-descr+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_descr_Input;

public interface ItestFieldDescrInp
  : IGqlpInterfaceBase
{
  ItestFieldDescrInpObject? As_FieldDescrInp { get; }
}

public interface ItestFieldDescrInpObject
  : IGqlpInterfaceBase
{
  string Field { get; }
}
