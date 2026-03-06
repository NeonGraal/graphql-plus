//HintName: test_field-mod-Enum+Input_Model.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Input;

public class testFieldModEnumInp
  : GqlpModelImplementationBase
  , ItestFieldModEnumInp
{
  public ItestFieldModEnumInpObject? As_FieldModEnumInp { get; set; }
}

public class testFieldModEnumInpObject
  : GqlpModelImplementationBase
  , ItestFieldModEnumInpObject
{
  public IDictionary<testEnumFieldModEnumInp, string> Field { get; set; }

  public testFieldModEnumInpObject
    ( IDictionary<testEnumFieldModEnumInp, string> field
    )
  {
    Field = field;
  }
}
