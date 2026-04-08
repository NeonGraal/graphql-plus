//HintName: test_input-field-String_Model.gen.cs
// Generated from {CurrentDirectory}input-field-String.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_String;

public class testInpFieldStr
  : GqlpModelBase
  , ItestInpFieldStr
{
  public ItestInpFieldStrObject? As_InpFieldStr { get; set; }
}

public class testInpFieldStrObject
  : GqlpModelBase
  , ItestInpFieldStrObject
{
  public string Field { get; set; }

  public testInpFieldStrObject
    ( string field
    )
  {
    Field = field;
  }
}
