//HintName: test_input-field-Enum_Impl.gen.cs
// Generated from {CurrentDirectory}input-field-Enum.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Enum;

public class testInpFieldEnum
  : GqlpModelImplementationBase
  , ItestInpFieldEnum
{
  public ItestInpFieldEnumObject? As_InpFieldEnum { get; set; }
}

public class testInpFieldEnumObject
  : GqlpModelImplementationBase
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
