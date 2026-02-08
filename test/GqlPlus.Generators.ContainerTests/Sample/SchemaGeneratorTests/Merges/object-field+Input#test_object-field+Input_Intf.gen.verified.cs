//HintName: test_object-field+Input_Intf.gen.cs
// Generated from object-field+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_field_Input;

public interface ItestObjFieldInp
{
  public ItestObjFieldInpObject AsObjFieldInp { get; set; }
}

public interface ItestObjFieldInpObject
{
  public ItestFldObjFieldInp Field { get; set; }
}

public interface ItestFldObjFieldInp
{
  public ItestFldObjFieldInpObject AsFldObjFieldInp { get; set; }
}

public interface ItestFldObjFieldInpObject
{
}
