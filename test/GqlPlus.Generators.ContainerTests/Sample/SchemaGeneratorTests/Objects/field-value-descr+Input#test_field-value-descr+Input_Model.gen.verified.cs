//HintName: test_field-value-descr+Input_Model.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Input;

public class testFieldValueDescrInp
  : GqlpModelImplementationBase
  , ItestFieldValueDescrInp
{
  public ItestFieldValueDescrInpObject? As_FieldValueDescrInp { get; set; }
}

public class testFieldValueDescrInpObject
  : GqlpModelImplementationBase
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
