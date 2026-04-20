//HintName: test_field-type-descr+Input_Model.gen.cs
// Generated from {CurrentDirectory}field-type-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_type_descr_Input;

public class testFieldTypeDescrInp
  : GqlpModelBase
  , ItestFieldTypeDescrInp
{
  public ItestFieldTypeDescrInpObject? As_FieldTypeDescrInp { get; set; }
}

public class testFieldTypeDescrInpObject
  : GqlpModelBase
  , ItestFieldTypeDescrInpObject
{
  public decimal Field { get; set; }

  public testFieldTypeDescrInpObject
    ( decimal pfield
    )
  {
    Field = pfield;
  }
}
