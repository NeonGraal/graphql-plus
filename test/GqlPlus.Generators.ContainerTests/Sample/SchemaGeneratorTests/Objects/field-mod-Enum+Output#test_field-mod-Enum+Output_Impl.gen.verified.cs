//HintName: test_field-mod-Enum+Output_Impl.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Output;

public class testFieldModEnumOutp
  : GqlpModelImplementationBase
  , ItestFieldModEnumOutp
{
  public ItestFieldModEnumOutpObject? As_FieldModEnumOutp { get; set; }
}

public class testFieldModEnumOutpObject
  : GqlpModelImplementationBase
  , ItestFieldModEnumOutpObject
{
  public IDictionary<testEnumFieldModEnumOutp, string> Field { get; set; }

  public testFieldModEnumOutpObject(IDictionary<testEnumFieldModEnumOutp, string> field)
  {
    Field = field;
  }
}
