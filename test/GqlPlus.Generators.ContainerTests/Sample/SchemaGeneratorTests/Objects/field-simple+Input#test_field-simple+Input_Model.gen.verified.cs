//HintName: test_field-simple+Input_Model.gen.cs
// Generated from {CurrentDirectory}field-simple+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Input;

public class testFieldSmplInp
  : GqlpModelBase
  , ItestFieldSmplInp
{
  public ItestFieldSmplInpObject? As_FieldSmplInp { get; set; }
}

public class testFieldSmplInpObject
  : GqlpModelBase
  , ItestFieldSmplInpObject
{
  public decimal Field { get; set; }

  public testFieldSmplInpObject
    ( decimal field
    )
  {
    Field = field;
  }
}
