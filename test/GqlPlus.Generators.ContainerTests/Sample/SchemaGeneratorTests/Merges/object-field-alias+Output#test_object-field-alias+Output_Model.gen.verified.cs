//HintName: test_object-field-alias+Output_Model.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Output;

public class testObjFieldAliasOutp
  : GqlpModelBase
  , ItestObjFieldAliasOutp
{
  public ItestObjFieldAliasOutpObject? As_ObjFieldAliasOutp { get; set; }
}

public class testObjFieldAliasOutpObject
  : GqlpModelBase
  , ItestObjFieldAliasOutpObject
{
  public ItestFldObjFieldAliasOutp Field { get; set; }

  public testObjFieldAliasOutpObject
    ( ItestFldObjFieldAliasOutp field
    )
  {
    Field = field;
  }
}

public class testFldObjFieldAliasOutp
  : GqlpModelBase
  , ItestFldObjFieldAliasOutp
{
  public ItestFldObjFieldAliasOutpObject? As_FldObjFieldAliasOutp { get; set; }
}

public class testFldObjFieldAliasOutpObject
  : GqlpModelBase
  , ItestFldObjFieldAliasOutpObject
{

  public testFldObjFieldAliasOutpObject
    ()
  {
  }
}
