//HintName: test_object-field-alias+Output_Model.gen.cs
// Generated from {CurrentDirectory}object-field-alias+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Output;

public class testObjFieldAliasOutp
  : GqlpModelImplementationBase
  , ItestObjFieldAliasOutp
{
  public ItestObjFieldAliasOutpObject? As_ObjFieldAliasOutp { get; set; }
}

public class testObjFieldAliasOutpObject
  : GqlpModelImplementationBase
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
  : GqlpModelImplementationBase
  , ItestFldObjFieldAliasOutp
{
  public ItestFldObjFieldAliasOutpObject? As_FldObjFieldAliasOutp { get; set; }
}

public class testFldObjFieldAliasOutpObject
  : GqlpModelImplementationBase
  , ItestFldObjFieldAliasOutpObject
{
}
