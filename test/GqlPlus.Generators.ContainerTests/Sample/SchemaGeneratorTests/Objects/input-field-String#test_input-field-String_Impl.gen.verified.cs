//HintName: test_input-field-String_Impl.gen.cs
// Generated from {CurrentDirectory}input-field-String.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_String;

public class testInpFieldStr
  : GqlpModelImplementationBase
  , ItestInpFieldStr
{
  public ItestInpFieldStrObject? As_InpFieldStr { get; set; }
}

public class testInpFieldStrObject
  : GqlpModelImplementationBase
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
