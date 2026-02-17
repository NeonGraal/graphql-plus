//HintName: test_object-field-alias+Input_Impl.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Input;

public class testObjFieldAliasInp
  : GqlpModelImplementationBase
  , ItestObjFieldAliasInp
{
  public ItestObjFieldAliasInpObject? As_ObjFieldAliasInp { get; set; }
}

public class testObjFieldAliasInpObject
  : GqlpModelImplementationBase
  , ItestObjFieldAliasInpObject
{
  public ItestFldObjFieldAliasInp Field { get; set; }

  public testObjFieldAliasInpObject(ItestFldObjFieldAliasInp field)
  {
    Field = field;
  }
}

public class testFldObjFieldAliasInp
  : GqlpModelImplementationBase
  , ItestFldObjFieldAliasInp
{
  public ItestFldObjFieldAliasInpObject? As_FldObjFieldAliasInp { get; set; }
}

public class testFldObjFieldAliasInpObject
  : GqlpModelImplementationBase
  , ItestFldObjFieldAliasInpObject
{

  public testFldObjFieldAliasInpObject()
  {
  }
}
