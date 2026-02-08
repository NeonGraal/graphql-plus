//HintName: test_object-field-alias+Input_Intf.gen.cs
// Generated from object-field-alias+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_alias_Input;

public interface ItestObjFieldAliasInp
{
  public ItestObjFieldAliasInpObject AsObjFieldAliasInp { get; set; }
}

public interface ItestObjFieldAliasInpObject
{
  public ItestFldObjFieldAliasInp Field { get; set; }
}

public interface ItestFldObjFieldAliasInp
{
  public ItestFldObjFieldAliasInpObject AsFldObjFieldAliasInp { get; set; }
}

public interface ItestFldObjFieldAliasInpObject
{
}
