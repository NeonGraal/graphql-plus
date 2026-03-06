//HintName: test_field-enum-parent+Input_Model.gen.cs
// Generated from {CurrentDirectory}field-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_parent_Input;

public class testFieldEnumPrntInp
  : GqlpModelImplementationBase
  , ItestFieldEnumPrntInp
{
  public ItestFieldEnumPrntInpObject? As_FieldEnumPrntInp { get; set; }
}

public class testFieldEnumPrntInpObject
  : GqlpModelImplementationBase
  , ItestFieldEnumPrntInpObject
{
  public testEnumFieldEnumPrntInp Field { get; set; }

  public testFieldEnumPrntInpObject
    ( testEnumFieldEnumPrntInp field
    )
  {
    Field = field;
  }
}
