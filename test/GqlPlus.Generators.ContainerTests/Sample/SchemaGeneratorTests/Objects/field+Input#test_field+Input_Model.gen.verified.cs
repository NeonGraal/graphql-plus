//HintName: test_field+Input_Model.gen.cs
// Generated from {CurrentDirectory}field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Input;

public class testFieldInp
  : GqlpModelImplementationBase
  , ItestFieldInp
{
  public ItestFieldInpObject? As_FieldInp { get; set; }
}

public class testFieldInpObject
  : GqlpModelImplementationBase
  , ItestFieldInpObject
{
  public string Field { get; set; }

  public testFieldInpObject
    ( string field
    )
  {
    Field = field;
  }
}
