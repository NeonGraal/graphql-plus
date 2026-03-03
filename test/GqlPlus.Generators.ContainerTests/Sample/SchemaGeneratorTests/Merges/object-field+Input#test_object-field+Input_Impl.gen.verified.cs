//HintName: test_object-field+Input_Impl.gen.cs
// Generated from {CurrentDirectory}object-field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Input;

public class testObjFieldInp
  : GqlpModelImplementationBase
  , ItestObjFieldInp
{
  public ItestObjFieldInpObject? As_ObjFieldInp { get; set; }
}

public class testObjFieldInpObject
  : GqlpModelImplementationBase
  , ItestObjFieldInpObject
{
  public ItestFldObjFieldInp Field { get; set; }

  public testObjFieldInpObject
    ( ItestFldObjFieldInp field
    )
  {
    Field = field;
  }
}

public class testFldObjFieldInp
  : GqlpModelImplementationBase
  , ItestFldObjFieldInp
{
  public ItestFldObjFieldInpObject? As_FldObjFieldInp { get; set; }
}

public class testFldObjFieldInpObject
  : GqlpModelImplementationBase
  , ItestFldObjFieldInpObject
{

  public testFldObjFieldInpObject
    ()
  {
  }
}
