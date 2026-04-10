//HintName: test_field-descr+Input_Model.gen.cs
// Generated from {CurrentDirectory}field-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_descr_Input;

public class testFieldDescrInp
  : GqlpModelBase
  , ItestFieldDescrInp
{
  public ItestFieldDescrInpObject? As_FieldDescrInp { get; set; }
}

public class testFieldDescrInpObject
  : GqlpModelBase
  , ItestFieldDescrInpObject
{
  public string Field { get; set; }

  public testFieldDescrInpObject
    ( string field
    )
  {
    Field = field;
  }
}
