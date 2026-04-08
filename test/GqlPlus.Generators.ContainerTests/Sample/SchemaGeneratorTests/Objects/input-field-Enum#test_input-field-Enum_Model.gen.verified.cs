//HintName: test_input-field-Enum_Model.gen.cs
// Generated from {CurrentDirectory}input-field-Enum.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Enum;

public class testInpFieldEnum
  : GqlpModelBase
  , ItestInpFieldEnum
{
  public ItestInpFieldEnumObject? As_InpFieldEnum { get; set; }
}

public class testInpFieldEnumObject
  : GqlpModelBase
  , ItestInpFieldEnumObject
{
  public testEnumInpFieldEnum Field { get; set; }

  public testInpFieldEnumObject
    ( testEnumInpFieldEnum field
    )
  {
    Field = field;
  }
}
