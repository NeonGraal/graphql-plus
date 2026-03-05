//HintName: test_field-value+Input_Model.gen.cs
// Generated from {CurrentDirectory}field-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Input;

public class testFieldValueInp
  : GqlpModelImplementationBase
  , ItestFieldValueInp
{
  public ItestFieldValueInpObject? As_FieldValueInp { get; set; }
}

public class testFieldValueInpObject
  : GqlpModelImplementationBase
  , ItestFieldValueInpObject
{
  public testEnumFieldValueInp Field { get; set; }

  public testFieldValueInpObject
    ( testEnumFieldValueInp field
    )
  {
    Field = field;
  }
}
