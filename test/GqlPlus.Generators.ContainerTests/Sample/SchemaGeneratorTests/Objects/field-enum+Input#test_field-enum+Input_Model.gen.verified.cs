//HintName: test_field-enum+Input_Model.gen.cs
// Generated from {CurrentDirectory}field-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Input;

public class testFieldEnumInp
  : GqlpModelImplementationBase
  , ItestFieldEnumInp
{
  public ItestFieldEnumInpObject? As_FieldEnumInp { get; set; }
}

public class testFieldEnumInpObject
  : GqlpModelImplementationBase
  , ItestFieldEnumInpObject
{
  public testEnumFieldEnumInp Field { get; set; }

  public testFieldEnumInpObject
    ( testEnumFieldEnumInp field
    )
  {
    Field = field;
  }
}
