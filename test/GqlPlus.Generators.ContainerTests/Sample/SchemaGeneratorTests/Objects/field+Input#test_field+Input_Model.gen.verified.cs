//HintName: test_field+Input_Model.gen.cs
// Generated from {CurrentDirectory}field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Input;

public class testFieldInp
  : GqlpModelBase
  , ItestFieldInp
{
  public ItestFieldInpObject? As_FieldInp { get; set; }
}

public class testFieldInpObject
  : GqlpModelBase
  , ItestFieldInpObject
{
  public string Field { get; set; }

  public testFieldInpObject
    ( string pfield
    )
  {
    Field = pfield;
  }
}
