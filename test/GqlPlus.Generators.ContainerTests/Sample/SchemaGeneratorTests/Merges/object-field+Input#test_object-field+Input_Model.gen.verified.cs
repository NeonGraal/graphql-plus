//HintName: test_object-field+Input_Model.gen.cs
// Generated from {CurrentDirectory}object-field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Input;

public class testObjFieldInp
  : GqlpModelBase
  , ItestObjFieldInp
{
  public ItestObjFieldInpObject? As_ObjFieldInp { get; set; }
}

public class testObjFieldInpObject
  : GqlpModelBase
  , ItestObjFieldInpObject
{
  public ItestFldObjFieldInp Field { get; set; }

  public testObjFieldInpObject
    ( ItestFldObjFieldInp pfield
    )
  {
    Field = pfield;
  }
}

public class testFldObjFieldInp
  : GqlpModelBase
  , ItestFldObjFieldInp
{
  public ItestFldObjFieldInpObject? As_FldObjFieldInp { get; set; }
}

public class testFldObjFieldInpObject
  : GqlpModelBase
  , ItestFldObjFieldInpObject
{

  public testFldObjFieldInpObject
    ()
  {
  }
}
