//HintName: test_field-mod-Enum+Output_Model.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Output;

public class testFieldModEnumOutp
  : GqlpModelBase
  , ItestFieldModEnumOutp
{
  public ItestFieldModEnumOutpObject? As_FieldModEnumOutp { get; set; }
}

public class testFieldModEnumOutpObject
  : GqlpModelBase
  , ItestFieldModEnumOutpObject
{
  public IDictionary<testEnumFieldModEnumOutp, string> Field { get; set; }

  public testFieldModEnumOutpObject
    ( IDictionary<testEnumFieldModEnumOutp, string> field
    )
  {
    Field = field;
  }
}
