//HintName: test_object-constraint+Input_Intf.gen.cs
// Generated from object-constraint+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Input;

public interface ItestObjCnstInp<Ttype>
{
  public testObjCnstInp ObjCnstInp { get; set; }
}

public interface ItestObjCnstInpObject<Ttype>
{
  public Ttype field { get; set; }
  public Ttype str { get; set; }
}
