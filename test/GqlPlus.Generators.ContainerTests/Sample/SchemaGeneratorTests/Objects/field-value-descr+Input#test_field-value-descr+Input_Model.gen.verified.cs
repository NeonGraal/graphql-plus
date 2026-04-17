//HintName: test_field-value-descr+Input_Model.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Input;

public class testFieldValueDescrInp
  : GqlpModelBase
  , ItestFieldValueDescrInp
{
  public ItestFieldValueDescrInpObject? As_FieldValueDescrInp { get; set; }
}

public class testFieldValueDescrInpObject
  : GqlpModelBase
  , ItestFieldValueDescrInpObject
{
  public testEnumFieldValueDescrInp Field { get; set; }

  public testFieldValueDescrInpObject
    ( testEnumFieldValueDescrInp field
    )
  {
    Field = field;
  }
}
