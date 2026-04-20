//HintName: test_object-field-alias+Input_Model.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Input;

public class testObjFieldAliasInp
  : GqlpModelBase
  , ItestObjFieldAliasInp
{
  public ItestObjFieldAliasInpObject? As_ObjFieldAliasInp { get; set; }
}

public class testObjFieldAliasInpObject
  : GqlpModelBase
  , ItestObjFieldAliasInpObject
{
  public ItestFldObjFieldAliasInp Field { get; set; }

  public testObjFieldAliasInpObject
    ( ItestFldObjFieldAliasInp pfield
    )
  {
    Field = pfield;
  }
}

public class testFldObjFieldAliasInp
  : GqlpModelBase
  , ItestFldObjFieldAliasInp
{
  public ItestFldObjFieldAliasInpObject? As_FldObjFieldAliasInp { get; set; }
}

public class testFldObjFieldAliasInpObject
  : GqlpModelBase
  , ItestFldObjFieldAliasInpObject
{

  public testFldObjFieldAliasInpObject
    ()
  {
  }
}
